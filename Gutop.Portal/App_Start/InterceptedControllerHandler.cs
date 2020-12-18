using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using Autofac;
using Gutop.Model.Autofac;

namespace Gutop.Portal.App_Start
{
    public  class InterceptedControllerHandler : Castle.DynamicProxy.IInterceptor, ISingleton
    {
        static Type IControllerInterceptedMeta = typeof(Gutop.Model.IControllerIntercepted);
        public Util.LogHelper logHelper { set; get; }

        public void Intercept(IInvocation invocation)
        {
            if (!invocation.Method.IsPublic || !IControllerInterceptedMeta.IsAssignableFrom(invocation.Method.ReflectedType))
            {//必须为public方法，并且方法所在类实现标识接口IControllerIntercepted，才进行aop拦截，进行异常日志记录和审计日志
                invocation.Proceed();
                return;
            }
            try
            {
                var controller= invocation.Proxy as System.Web.Mvc.Controller;
                if (!controller.ModelState.IsValid)
                    throw new ArgumentException(string.Join(";", controller.ModelState.Values.SelectMany(x => x.Errors.Select(a => a.ErrorMessage)).ToList()));
                DateTime beginTime = DateTime.Now;
                invocation.Proceed();
                Audit(invocation, beginTime);
            }
            catch (Exception ex)
            {
                //发生异常一定记录日志，记录请求参数，方便开发复现和调试
                var arguments = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(invocation.Arguments);
                this.logHelper.Add(new Gutop.Model.Entity.Log()
                {
                    Id = Guid.NewGuid(),
                    Message = string.Format("请求发生异常,请求参数为{0},具体异常信息为:{1}", arguments, ex.ToString()),
                    Source = invocation.Method.Name,
                });
                throw ex;
            }
        }

        private void Audit(IInvocation invocation, DateTime beginTime)
        {
            var userInfo= Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Model.UserInfo>();
            //审计日志，不需要要记录请求参数，记录每次请求的耗时，当前用户，url，方法等信息
            this.logHelper.Add(new Gutop.Model.Entity.Log()
            {
                Id = Guid.NewGuid(),
                Message = string.Format("请求耗时{0}s,请求的方法{1},当前用户{2}",Math.Round((DateTime.Now - beginTime).TotalSeconds,MidpointRounding.AwayFromZero),
                invocation.Method.Name,
                userInfo.LoginName??"system"),
                Source = invocation.Method.Name,
            });
        }
    }
}