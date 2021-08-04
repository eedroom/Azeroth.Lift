using Azeroth.Util;
using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Controllers.Admin
{
    public class AccountController : ExceptionedController, IControllerIntercepted
    {
        Bll.User bllUser;
        public AccountController(Bll.User bllUser) {
            this.bllUser = bllUser;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Login(Model.VO.Account.Login parameter)
        {
            Model.Entity.User user=null;
            if (!this.bllUser.ValidLogin(parameter,out user))
                return this.Json(ApiResult.Error("用户名或密码错误"));
            //表单校验，写人信息
            System.Web.Security.FormsAuthentication.SetAuthCookie(user.LoginName, parameter.IsPersistent??false);
            var targetUrl= System.Web.Security.FormsAuthentication.GetRedirectUrl(user.LoginName, parameter.IsPersistent ?? false);
            return this.Json(ApiResult.OK(new { targetUrl}));
        }
    }
}