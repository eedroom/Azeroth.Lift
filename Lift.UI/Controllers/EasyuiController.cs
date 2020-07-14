using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lift.UI.Controllers
{
    public class EasyuiController : AuthenticationedController
    {
        // GET: Easyui
        public ActionResult DemoList()
        {
            return View();
        }

        public ActionResult Tree()
        {
            return View();
        }
    }
}