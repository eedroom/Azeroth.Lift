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
        public ActionResult Biaodan()
        {
            return View();
        }
    }
}