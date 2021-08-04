using Azeroth.Util;
using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Controllers
{
    public class BootstrapController : AuthenticationedController, IControllerIntercepted
    {
        // GET: Bootstrap
        [UrlMap("表单", UrlMapCategory.页面)]
        public ActionResult Biaodan()
        {
            return View();
        }
    }
}