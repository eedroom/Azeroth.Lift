using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Gutop.Entity;

namespace Gutop.Portal.Controllers
{
    public class AuthenticationedController : Controller
    {
        public Bll.UserInfo BllUserInfo { get; set; }

        public Gutop.Model.UserInfo UserInfo { set; get; }

        static Func<string, bool, string> GetLoginPage = 
            (Func<string, bool, string>)System.Delegate.CreateDelegate(typeof(Func<string, bool, string>),
                typeof(System.Web.Security.FormsAuthentication).GetMethod("GetLoginPage", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static, 
                    null, 
                    new Type[] { typeof(string), typeof(bool) },
                    null));
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            this.UserInfo.LoginName = "eeroom";
            //验证登陆
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var loginurl = GetLoginPage(null, false);
                filterContext.Result = this.Redirect(loginurl);
                return;
            }
            var userInfo = this.Session.GetValue(Model.SessionIndex.UserInfo) as Gutop.Entity.UserInfo;
            if (userInfo == null)//session丢失或者过期，重新从数据库取
            {
                Guid id = Guid.Parse(filterContext.HttpContext.User.Identity.Name);
                userInfo = this.BllUserInfo.GetEntity(x=>x.Id==id);
                this.Session.SetValue(Model.SessionIndex.UserInfo, userInfo);
            }
            //this.UserInfo.LoginName = userInfo.LoginName;
            //滑动过期处理
            //System.Web.Security.FormsAuthentication.SetAuthCookie(filterContext.HttpContext.User.Identity.Name, true);

            
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            //验证菜单,逻辑，以数据库菜单列表为基准，
            //如果被访问资源和菜单列表可以匹配上，就校验用户能否访问，否则忽略
            var lst = Gutop.Model.MenuInfoWrapper.GetAll();
            lst.ForEach(x => x.Url = x.Url?.ToLower());
            var lstMenuTree = lst.Select(x => new Gutop.Model.Treedata<Gutop.Model.MenuInfo>(x))
                //.OrderBy(x=>x.value.Url?.Length)
                .ToList();
            var dictMenu = lstMenuTree.ToDictionary(x => x.value.Id, x => x);
            lstMenuTree.ForEach(x => x.parent = dictMenu.ContainsKey(x.value.Pid ?? Guid.Empty) ? dictMenu[x.value.Pid ?? Guid.Empty] : default(Gutop.Model.Treedata<Gutop.Model.MenuInfo>));
            lstMenuTree.ForEach(x => x.parent?.children.Add(x));
            //根级的所有菜单菜单
            var lstNav = lstMenuTree.Where(x => x.parent == null).ToList();
            
            var route= ((System.Web.Routing.Route)filterContext.RouteData.Route);
            //{controller}/{action}
            var dictRoutData= filterContext.RouteData.Values.ToDictionary(x => "{" + x.Key + "}", x => x.Value);
            //根据匹配的路由，还原url值，比如/反推回/home/index
            string url = route.Url;
            dictRoutData.ForEach(x => url = url.Replace(x.Key, x.Value.ToString()));
            url = url.ToLower();

            var mathedItem = lstMenuTree.FirstOrDefault(x => x.value.Url?.Contains(url)??false);
            if (mathedItem != null)
            {
                mathedItem.value.Active = true;
                mathedItem.parent.value.Collapsing = true;
            }
            Gutop.Model.MenuInfoWrapper wrapperMenuInfo = new Gutop.Model.MenuInfoWrapper() {
                Value = lstNav,
                 MathedItem= mathedItem
            };
            this.ViewData["__wrapperMenuInfo"] = wrapperMenuInfo;

        }

    }
}