using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace Lift.UI.App_Start
{
    /// <summary>
    /// 用于处理控制器的异常处理，审计日志
    /// </summary>
    public class ExceptionHandler: InterceptedHandler, Model.Autofac.ISingleton
    {
        protected override void Execute(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                
                
            }
        }
    }
}