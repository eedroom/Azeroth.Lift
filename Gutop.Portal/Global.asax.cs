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
namespace Lift.UI
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
            Type flagIScoped = typeof(Model.Autofac.IScoped);
            Type flagISingleton = typeof(Model.Autofac.ISingleton);
            Type flagITransient = typeof(Model.Autofac.ITransient);
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
                .InterceptedBy(typeof(UI.App_Start.ControllerLogHandler))
                .InterceptedBy(typeof(UI.App_Start.ControllerExceptionHandler));
            var container = builder.Build();
            var resolver = new Autofac.Integration.Mvc.AutofacDependencyResolver(container);
            System.Web.Mvc.DependencyResolver.SetResolver(resolver);
        }

        public override void Init()
        {
            base.Init();
        }
    }
}