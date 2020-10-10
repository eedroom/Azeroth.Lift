using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers
{
    public class KlzController : AuthenticationedController
    {
        // GET: Klz
        public ActionResult Wuye()
        {
            return View();
        }

        public ActionResult Ailan()
        {
            return View();
        }
    }
}