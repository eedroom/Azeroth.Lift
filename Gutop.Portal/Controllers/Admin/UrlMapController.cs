using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers.Admin
{
    public class UrlMapController : AuthenticationedController
    {
        // GET: Account
        [Gutop.Model.UrlMap("同步UrlMap", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Index()
        {
            return View();
        }
    }
}