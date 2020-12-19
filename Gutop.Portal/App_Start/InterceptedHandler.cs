using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using Autofac;
using Gutop.Model.Autofac;
using Microsoft.Extensions.Logging;
namespace Gutop.Portal.App_Start
{
    public  class InterceptedHandler : Castle.DynamicProxy.IInterceptor, ISingleton
    {
        public void Intercept(IInvocation invocation)
        {
            if (!invocation.Method.IsPublic)
            {//必须为public方法，并且方法所在类实现标识接口IControllerIntercepted，才进行aop拦截，进行异常日志记录和审计日志
                invocation.Proceed();
                return;
            }
            try
            {
                this.ValidRequestParameter(invocation);
                DateTime beginTime = DateTime.Now;
                invocation.Proceed();
                this.Audit(invocation, beginTime);
            }
            catch (Gutop.Model.GutopRuntimeException gex)
            {
                throw gex;
            }
            catch (Exception ex)
            {
                var gex = new Model.GutopRuntimeException(invocation.Arguments, "请查看内部异常详情", ex);
                throw gex;
            }
        }

        private void ValidRequestParameter(IInvocation invocation)
        {
            var arguments = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(invocation.Arguments);
            var controller = invocation.Proxy as System.Web.Mvc.Controller;
            if (controller.ModelState.IsValid)
                return;
            string msg = string.Join(";", controller.ModelState.Values.SelectMany(x => x.Errors.Select(a => a.ErrorMessage)).ToList());
            var gex = new Model.GutopRuntimeException(invocation.Arguments, msg);
            throw gex;
        }


        /// <summary>
        /// 审计
        /// 记录请求，每次请求的时间
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="beginTime"></param>
        private void Audit(IInvocation invocation, DateTime beginTime)
        {
            var userInfo= Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Model.UserInfo>();
            //审计日志，不需要要记录请求参数，记录每次请求的耗时，当前用户，url，方法等信息
            string msg = string.Format("请求耗时{0}s,请求的方法{1},当前用户{2}",
                Math.Round((DateTime.Now - beginTime).TotalSeconds, MidpointRounding.AwayFromZero),
                invocation.Method.Name,
                userInfo.LoginName ?? "system");
            var log = new Gutop.Model.Entity.Log()
            {
                Id = Guid.NewGuid(),
                Message = msg,
                Source = invocation.Method.Name,
            };
            var logger= Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Microsoft.Extensions.Logging.ILogger<InterceptedHandler>>();
            logger.LogInformation("Audit",log);
        }
    }
}