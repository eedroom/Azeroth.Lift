using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using Autofac;
using Azeroth.Util.Autofac;
using Azeroth.Util;

namespace Gutop.App_Start
{
    public  class InterceptedHandler : Castle.DynamicProxy.IInterceptor, ISingleton
    {
        Azeroth.Util.ILog<InterceptedHandler> logger;
        public InterceptedHandler(Azeroth.Util.ILog<InterceptedHandler> logger) {
            this.logger = logger;
        }

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
            catch (InvokeFaildException gex)
            {
                if(gex.Method==null)
                    gex.Method = invocation.MethodInvocationTarget;
                throw gex;
            }
            catch (Exception ex)
            {
                var gex = new InvokeFaildException(invocation.Arguments, "请查看内部异常详情", ex);
                gex.Method = invocation.MethodInvocationTarget;
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
            var gex = new InvokeFaildException(invocation.Arguments, msg);
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
            //审计日志，记录请求参数，记录每次请求的耗时，当前用户，url，方法等信息
            int time = (int)(DateTime.Now - beginTime).TotalMilliseconds;
            logger.InfoFormat("{0}",invocation.Arguments);
        }
    }
}