using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers
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

        public ActionResult Treedata()
        {
            var path= this.HttpContext.Server.MapPath("~/Assets/jquery-easyui-1.5.2/demo");
            var lstTreedata= new System.IO.DirectoryInfo(path)
                .GetDirectories()
                .Select(x => new
                {
                    id = x.Name,
                    text = x.Name,
                    state = "closed",
                    children = x.GetFiles().Select(a => new
                    {
                        id = x.Name + "-" + a.Name,
                        text = a.Name,
                        attributes = new
                        {
                            url=this.Url.Content(string.Format("~/Assets/jquery-easyui-1.5.2/demo/{0}/{1}",x.Name,a.Name))
                        }
                    }).ToList()
                }).ToList();
            return this.Json(lstTreedata, JsonRequestBehavior.AllowGet);
        }
    }
}