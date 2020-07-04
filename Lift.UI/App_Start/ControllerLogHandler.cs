using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace Lift.UI.App_Start
{
    /// <summary>
    /// 对用户的总共耗时
    /// </summary>
    public class ControllerLogHandler : ControllerHandler, Model.Autofac.ISingleton
    {
        protected override void Execute(IInvocation invocation)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed();
            var allTime = watch.ElapsedMilliseconds;
            watch.Stop();
        }
    }
}