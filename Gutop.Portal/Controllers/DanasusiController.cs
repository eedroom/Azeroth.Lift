using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lift.UI.Controllers
{
    public class DanasusiController : AuthenticationedController
    {
        // GET: Danasusi
        public ActionResult Youyingu()
        {
            return View();
        }
    }
}