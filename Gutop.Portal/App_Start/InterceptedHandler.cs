using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace Gutop.Portal.App_Start
{
    public abstract class InterceptedHandler : Castle.DynamicProxy.IInterceptor
    {
        static Type ControllerMETA = typeof(System.Web.Mvc.Controller);
        static Type ControllerBaseMETA = typeof(System.Web.Mvc.ControllerBase);
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.ReflectedType == ControllerMETA ||
                invocation.Method.ReflectedType == ControllerBaseMETA)
            {
                invocation.Proceed();
                return;
            }
            this.Execute(invocation);
        }

        protected abstract void Execute(IInvocation invocation);
    }
}