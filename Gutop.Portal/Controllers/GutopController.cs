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
            
            var ex = filterContext.Exception as Model.ExceptionInterceptedWrapper;
            if (ex != null)
            {
                filterContext.Result = this.OnException(filterContext, ex);
                filterContext.ExceptionHandled = true;
                return;
            }
            var log= new Gutop.Model.Entity.Log() { Id = Guid.NewGuid(), Message = filterContext.Exception.ToString(), Source = this.Request.Url.AbsolutePath };
            this.Logger.LogError("OnException",log);
            filterContext.Result = this.OnException(filterContext, new ExceptionInterceptedWrapper("服务器内部发生异常"));
            filterContext.ExceptionHandled = true;
        }

        private ActionResult OnException(ExceptionContext filterContext, ExceptionInterceptedWrapper ex)
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