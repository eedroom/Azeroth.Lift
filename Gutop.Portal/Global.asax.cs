using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Extras.DynamicProxy;
using Gutop.Model.Autofac;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Gutop.UI {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            System.Web.Mvc.AreaRegistration.RegisterAllAreas();
            //mvc相关
            System.Web.Routing.RouteTable.Routes.MapRoute("l2",
                "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });

            //ioc和aop相关
            Type flagIScoped = typeof(IScoped);
            Type flagISingleton = typeof(ISingleton);
            Type flagITransient = typeof(ITransient);
            //bin目录下的所有的类型
            var lstType = System.Web.Compilation.BuildManager.GetReferencedAssemblies()
                .Cast<System.Reflection.Assembly>()
                .SelectMany(x => x.GetTypes())
                .ToList();
            var lstTypeIScoped = lstType.Where(x => flagIScoped.IsAssignableFrom(x))
                .Where(x => x != flagIScoped).ToArray();
            var lstTypeISingleton = lstType.Where(x => flagISingleton.IsAssignableFrom(x))
                .Where(x => x != flagISingleton).ToArray();
            var lstTypeITransient = lstType.Where(x => flagITransient.IsAssignableFrom(x))
                .Where(x => x != flagITransient).ToArray();

            var builder = new Autofac.ContainerBuilder();
            builder.RegisterTypes(lstTypeIScoped).AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .InstancePerRequest();
            builder.RegisterTypes(lstTypeISingleton).AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();
            builder.RegisterTypes(lstTypeITransient).AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .InstancePerDependency();

            builder.RegisterType<Microsoft.Extensions.Logging.LoggerFactory>()
                .As<Microsoft.Extensions.Logging.ILoggerFactory>()
                .SingleInstance();
            builder.RegisterGeneric(typeof(Microsoft.Extensions.Logging.Logger<>))
                .As(typeof(Microsoft.Extensions.Logging.ILogger<>))
                .InstancePerDependency();

            builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly())
                .AsSelf()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .InstancePerRequest()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(App_Start.InterceptedHandler));
            var container = builder.Build();
            var resolver = new Autofac.Integration.Mvc.AutofacDependencyResolver(container);
            System.Web.Mvc.DependencyResolver.SetResolver(resolver);
            //日志信息相关的处理
            var logFactory = Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Microsoft.Extensions.Logging.ILoggerFactory>();
            var logBll = Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Bll.Log>();
            this.LogConfigure(logFactory, logBll);
        }

        static ConcurrentQueue<Model.Entity.Log> logQueue = new ConcurrentQueue<Model.Entity.Log>();
        static int logSaveHandlerInitFlag = 0;
        private void LogConfigure(Microsoft.Extensions.Logging.ILoggerFactory logFactory, Bll.Log logBll) {
            logFactory.AddProvider(new Gutop.Utils.Log4netLoggerProvider());
            logFactory.AddProvider(new Gutop.Utils.GutopLoggerProvider(lw => {
                Model.Entity.Log logInfo = new Model.Entity.Log() {
                    CategoryName = lw.CategoryName,
                    Content = lw.Content,
                    CreateTime = DateTime.Now,
                    EventId = lw.EventId.Id,
                    EventName = lw.EventId.Name,
                    Exception = lw.Exception?.ToString(),
                    LogLevel = (int)lw.LogLevel,
                    Id = Guid.NewGuid()
                };
                var userInfo= Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Model.UserWrapper>();
                logInfo.Creator = userInfo.User?.LoginName ?? "system";
                logQueue.Enqueue(logInfo);
            }));
            if (System.Threading.Interlocked.Exchange(ref logSaveHandlerInitFlag, 1) != 0)
                return;//防御代码，已经执行过下面的代码了，避免因为调用多次这个方法就启动多个线程去保存
            System.Threading.ThreadPool.QueueUserWorkItem(x => {
                List<Gutop.Model.Entity.Log> lst = new List<Gutop.Model.Entity.Log>(50);
                Gutop.Model.Entity.Log tmp;
                while (true) {
                    if (logQueue.Count <= 0) {
                        System.Threading.Thread.Sleep(10 * 1000);
                        continue;
                    }
                    lst.Clear();
                    while (lst.Count < 50 && logQueue.TryDequeue(out tmp)) {
                        lst.Add(tmp);
                    }
                    try {
                        logBll.Add(lst);
                    } catch (Exception ex) {
                        //最后办法，写入windows事件日志中，System.Diagnostics.EventLog.WriteEntry好像需要在IIS把应用程序用localsystem用户运行
                        System.Diagnostics.EventLog.WriteEntry("Gutop", "保存日志信息到数据库发生异常，详细信息:" + ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            });
        }

        public override void Init() {
            base.Init();
        }
    }
}