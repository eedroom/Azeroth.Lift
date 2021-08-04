using Azeroth.Util;
using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Controllers
{
    public class KlzController : AuthenticationedController, IControllerIntercepted
    {
        // GET: Klz
        [UrlMap("午夜", UrlMapCategory.页面)]
        public ActionResult Wuye()
        {
            return View();
        }
        [UrlMap("埃兰", UrlMapCategory.页面)]
        public ActionResult Ailan()
        {
            return View();
        }
    }
}