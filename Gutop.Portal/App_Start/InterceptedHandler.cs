using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace Gutop.Portal.App_Start
{
    public abstract class InterceptedHandler : Castle.DynamicProxy.IInterceptor
    {
        static Type ControllerMeta = typeof(System.Web.Mvc.Controller);
        static Type ControllerBaseMeta = typeof(System.Web.Mvc.ControllerBase);
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.ReflectedType == ControllerMeta ||
                invocation.Method.ReflectedType == ControllerBaseMeta)
            {
                invocation.Proceed();
                return;
            }
            this.Execute(invocation);
        }

        protected abstract void Execute(IInvocation invocation);
    }
}