using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gutop.Model;
using Microsoft.Extensions.Logging;
namespace Gutop.Portal.Controllers
{
    public class GutopController : Controller
    {
        public Microsoft.Extensions.Logging.ILogger<GutopController> Logger { set; get; }

        protected override void OnException(ExceptionContext filterContext)
        {
            var gex = filterContext.Exception as Model.GutopRuntimeException;
            if (gex == null) {
                gex = new Model.GutopRuntimeException("未知", "发生未知异常",filterContext.Exception);
            }
            string eidName = gex.Method == null ? "未知" : gex.Method.DeclaringType.FullName + "." + gex.Method.Name;
            EventId eid = new EventId(0, eidName);
            this.Logger.LogError(eid, "请求地址{url},控制器入参{args}", this.Request.Url.AbsolutePath, gex.requestArgs);

            filterContext.Result = this.OnException(filterContext, gex);
            filterContext.ExceptionHandled = true;
        }

        private ActionResult OnException(ExceptionContext filterContext, Model.GutopRuntimeException ex)
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