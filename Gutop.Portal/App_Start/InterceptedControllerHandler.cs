using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using Autofac;
namespace Gutop.Portal.App_Start
{
    public  class InterceptedControllerHandler : Castle.DynamicProxy.IInterceptor, Gutop.Entity.Autofac.ISingleton
    {
        static Type ControllerMeta = typeof(System.Web.Mvc.Controller);
        static Type ControllerBaseMeta = typeof(System.Web.Mvc.ControllerBase);
        static Type AuthenticationedMeta = typeof(Controllers.AuthenticationedController);
        public Util.LogHelper logInfoHelper { set; get; }
        public InterceptedControllerHandler()
        {
            //this.logInfoHelper = Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Util.LogInfoHelper>();
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.ReflectedType == ControllerMeta ||
                invocation.Method.ReflectedType == ControllerBaseMeta)
            {
                invocation.Proceed();
                return;
            }
            try
            {
                DateTime beginTime = DateTime.Now;
                invocation.Proceed();
                //处理审计日志
                ProcessAudit(invocation, beginTime);
            }
            catch (Exception ex)
            {
                //发生异常一定记录日志，记录请求参数，方便开发复现和调试
                var arguments = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(invocation.Arguments);
                this.logInfoHelper.Add(new Gutop.Entity.LogInfo()
                {
                    Id = Guid.NewGuid(),
                    Message = string.Format("请求发生异常,请求参数为{0},具体异常信息为:{1}", arguments, ex.ToString()),
                    Source = invocation.Method.Name,
                });
                throw ex;
            }
        }

        private void ProcessAudit(IInvocation invocation, DateTime beginTime)
        {
            var userInfo= Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Model.UserInfo>();
            //审计日志，不需要要记录请求参数，记录每次请求的耗时，当前用户，url，方法等信息
            this.logInfoHelper.Add(new Gutop.Entity.LogInfo()
            {
                Id = Guid.NewGuid(),
                Message = string.Format("请求耗时{0}s,请求的方法{1},当前用户{2}",Math.Round((DateTime.Now - beginTime).TotalSeconds,MidpointRounding.AwayFromZero),invocation.Method.Name,userInfo.LoginName),
                Source = invocation.Method.Name,
            });
        }
    }
}