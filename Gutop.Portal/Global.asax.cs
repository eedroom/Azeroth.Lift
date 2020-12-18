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

namespace Gutop.Portal
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
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
            var lstType= System.Web.Compilation.BuildManager.GetReferencedAssemblies()
                .Cast<System.Reflection.Assembly>()
                .SelectMany(x => x.GetTypes())
                .ToList();
            var lstTypeIScoped= lstType.Where(x => flagIScoped.IsAssignableFrom(x))
                .Where(x=>x!=flagIScoped).ToArray();
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

            builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly())
                .AsSelf()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .InstancePerRequest()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(App_Start.InterceptedControllerHandler));
            var container = builder.Build();
            var resolver = new Autofac.Integration.Mvc.AutofacDependencyResolver(container);
            System.Web.Mvc.DependencyResolver.SetResolver(resolver);
            //日志信息相关的处理
            Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Util.LogHelper>().StartPersist();
        }

        public override void Init()
        {
            base.Init();
        }
    }
}