using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lift.UI.Controllers
{
    public class HomeController : AuthenticationedController
    {
        public Bll.MenuInfo BllMenuInfo { get; set; }

        public Bll.UserInfo BllUserInfo{ get; set; }
        /// <summary>
        /// 如果这个方法需要被aop拦截，就加virtual修饰
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            var rt= this.BllMenuInfo.Init();
            var lst= this.BllMenuInfo.GetEntities();
            this.ViewData["lstMenuInfo"] = lst;
            return View();
        }


    }
}