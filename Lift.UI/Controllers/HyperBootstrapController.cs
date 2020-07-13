using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lift.UI.Controllers
{
    public class HyperBootstrapController : AuthenticationedController
    {
        // GET: HyperBootstrap
        public ActionResult Biaodan()
        {
            return View();
        }
    }
}