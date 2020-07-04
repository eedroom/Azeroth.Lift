using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Lift.UI.Controllers
{
    public class AuthenticationedController : Controller
    {
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            //filterContext.Result = this.Redirect("/Account/Login");
            //base.OnAuthentication(filterContext);
        }

    }
}