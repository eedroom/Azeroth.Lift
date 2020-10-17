using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gutop.Model;

namespace Gutop.Portal.Controllers
{
    public class GutopController : Controller
    {
        public Util.LogHelper LogHelper { set; get; }

        protected override void OnException(ExceptionContext filterContext)
        {
            var ex = filterContext.Exception as Model.ExceptionInterceptedWrapper;
            if (ex != null)
            {
                filterContext.Result = this.OnException(filterContext, ex);
                return;
            }
            this.LogHelper.Add(new Entity.Log() {  Id=Guid.NewGuid(), Message=filterContext.Exception.ToString(), Source=this.Request.Url.AbsolutePath});
            filterContext.Result = this.OnException(filterContext, new ExceptionInterceptedWrapper("服务器内部发生异常"));
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