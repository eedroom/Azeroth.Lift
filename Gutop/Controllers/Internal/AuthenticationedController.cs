﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Autofac;
using Azeroth.Util;

namespace Gutop.Controllers
{
    public class AuthenticationedController : ExceptionedController
    {
        public Bll.Bll Bll { get; set; }

        static Func<string, bool, string> GetLoginPage = 
            (Func<string, bool, string>)System.Delegate.CreateDelegate(typeof(Func<string, bool, string>),
                typeof(System.Web.Security.FormsAuthentication).GetMethod("GetLoginPage", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static, 
                    null, 
                    new Type[] { typeof(string), typeof(bool) },
                    null));
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {//验证登陆，微软的iis管道的认证模块会去解析cookie中的表单认证信息，如果ok，就会把对应的信息赋值到filterContext.HttpContext.User
                //System.Web.Security.FormsAuthentication.RedirectToLoginPage();//这个在mvc的filter里面不适用
                var loginurl = GetLoginPage(null, false);
                filterContext.Result = this.Redirect(loginurl);
                return;
            }
            var formsIdentity = filterContext.HttpContext.User.Identity as System.Web.Security.FormsIdentity;
            //处理当前登录用户的信息，借助ioc的scop生命周期，实现本次请求内的当前用户信息共享，
            //传统的共享方式，借助session，这里不采用
            var userWrapper = Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Model.UserWrapper>();
            var user= this.Bll.GetEntity<Model.Entity.User>(x => x.LoginName == formsIdentity.Name);
            if (user == null) {
                var loginurl = GetLoginPage(null, false);
                filterContext.Result = this.Redirect(loginurl);
                return;
            }
            userWrapper.User = user;
            //如果表单校验，超过5分钟就刷新表单校验cookie，默认策略是到期时间过半再刷新表单校验cookie
            if (formsIdentity != null && formsIdentity.Ticket.IssueDate.AddMinutes(5)<DateTime.Now)
                System.Web.Security.FormsAuthentication.SetAuthCookie(formsIdentity.Ticket.Name, formsIdentity.Ticket.IsPersistent);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //验证菜单,逻辑，以数据库菜单列表为基准，
            //如果被访问资源和菜单列表可以匹配上，就校验用户能否访问，否则忽略
            var lst = Gutop.Model.MenuCollections.GetAll();
            lst.ForEach(x => x.Url = x.Url?.ToLower());
            var lstMenuTree = lst.Select(x => new Azeroth.Util.TreeNode<UrlMapWrapper>(x))
                //.OrderBy(x=>x.value.Url?.Length)
                .ToList();
            var dictMenu = lstMenuTree.ToDictionary(x => x.value.Id, x => x);
            lstMenuTree.ForEach(x => x.parent = dictMenu.ContainsKey(x.value.Pid ?? Guid.Empty) ? dictMenu[x.value.Pid ?? Guid.Empty] : default(Azeroth.Util.TreeNode<UrlMapWrapper>));
            lstMenuTree.ForEach(x => x.parent?.children.Add(x));
            //根级的所有菜单菜单
            var lstNav = lstMenuTree.Where(x => x.parent == null).ToList();
            
            var route= ((System.Web.Routing.Route)filterContext.RouteData.Route);
            //{controller}/{action}
            var dictRoutData= filterContext.RouteData.Values.ToDictionary(x => "{" + x.Key + "}", x => x.Value);
            //根据匹配的路由，还原url值，比如/反推回/home/index
            string url = route.Url;
            foreach (var kv in dictRoutData)
            {
                url = url.Replace(kv.Key, kv.Value.ToString());
            }
            url = url.ToLower();

            var mathedItem = lstMenuTree.FirstOrDefault(x => x.value.Url?.Contains(url)??false);
            if (mathedItem != null)
            {
                mathedItem.value.Active = true;
                mathedItem.parent.value.Collapsing = true;
            }
            Gutop.Model.MenuCollections wrapperMenuInfo = new Gutop.Model.MenuCollections() {
                Value = lstNav,
                 MathedItem= mathedItem
            };
            this.ViewData["__wrapperMenuInfo"] = wrapperMenuInfo;

        }
    }
}