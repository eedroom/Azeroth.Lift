using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lift.UI.Controllers
{
    public class BootstrapController : AuthenticationedController
    {
        // GET: Bootstrap
        public ActionResult Biaodan()
        {
            return View();
        }
    }
}