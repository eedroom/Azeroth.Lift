using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gutop.Model;
using Azeroth.Util;

namespace Gutop.UI.Controllers
{
    public class ExceptionedController : Controller
    {
        public log4net.ILog Logger { set; get; }

        protected override void OnException(ExceptionContext filterContext)
        {
            var gex = filterContext.Exception as GutopRuntimeException;
            if (gex == null) {
                gex = new GutopRuntimeException("未知", "发生未知异常",filterContext.Exception);
            }
            string eidName = gex.Method == null ? "未知" : gex.Method.DeclaringType.FullName + "." + gex.Method.Name;
            this.Logger.ErrorFormat("请求地址{0},控制器入参{1}", this.Request.Url.AbsolutePath, gex.requestArgs);

            filterContext.Result = this.OnException(filterContext, gex);
            filterContext.ExceptionHandled = true;
        }

        private ActionResult OnException(ExceptionContext filterContext, GutopRuntimeException ex)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                return this.Json(ApiResult.Error(ex.Message));
            }
            else
            {
                return this.Redirect("/home/error");
            }
        }
    }
}