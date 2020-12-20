using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers
{
    public class HomeController : AuthenticationedController, IControllerIntercepted
    {


        /// <summary>
        /// 如果这个方法需要被aop拦截，就加virtual修饰
        /// </summary>
        /// <returns></returns>
        [Gutop.Model.UrlMap("首页", Model.Enum.UrlMapCategory.页面)]
        public virtual ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }

        public ActionResult TableData()
        {
            var lst= System.Linq.Enumerable.Range(1, 10)
                .Select(x => new
                {
                    name = "部门" + x,
                    stargazers_count = "上级部门" + x,
                    forks_count = x,
                    description = "描述" + x
                }).ToList();
            return this.Json(new { total = 100, rows = lst }, JsonRequestBehavior.AllowGet);
        }

        [Gutop.Model.UrlMap("伊利丹", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Yilidan()
        {
            return this.View();
        }

        public ActionResult Error()
        {
            return this.View();
        }
    }
}