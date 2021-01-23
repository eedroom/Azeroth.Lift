using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.UI.Controllers
{
    public class EasyuiController : AuthenticationedController, IControllerIntercepted
    {
        // GET: Easyui
        [Gutop.Model.UrlMap("官方demo", Model.Enum.UrlMapCategory.页面)]
        public ActionResult DemoList()
        {
            return View();
        }

        [Gutop.Model.UrlMap("树", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Tree()
        {
            return View();
        }
        [Gutop.Model.UrlMap("easyui的所有demo列表", Model.Enum.UrlMapCategory.api)]
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