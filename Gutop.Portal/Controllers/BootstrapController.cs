using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers
{
    public class BootstrapController : AuthenticationedController, IControllerIntercepted
    {
        // GET: Bootstrap
        [Gutop.Model.UrlMap("表单", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Biaodan()
        {
            return View();
        }
    }
}