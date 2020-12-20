using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers
{
    public class KlzController : AuthenticationedController, IControllerIntercepted
    {
        // GET: Klz
        [Gutop.Model.UrlMap("午夜", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Wuye()
        {
            return View();
        }
        [Gutop.Model.UrlMap("埃兰", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Ailan()
        {
            return View();
        }
    }
}