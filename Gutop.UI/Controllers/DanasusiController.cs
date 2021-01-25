using Azeroth.Util;
using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.UI.Controllers
{
    public class DanasusiController : AuthenticationedController, IControllerIntercepted
    {
        // GET: Danasusi
        [UrlMap("幽影谷", UrlMapCategory.页面)]
        public ActionResult Youyingu()
        {
            return View();
        }
    }
}