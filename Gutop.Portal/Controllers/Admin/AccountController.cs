using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers.Admin
{
    public class AccountController : GutopController, IControllerIntercepted
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Login(Model.VO.AccountLoginInput parameter)
        {
            var userInfo = new Model.UserWrapper() { LoginName = parameter.LoginName };
            if (userInfo == null)
                return this.Json(Model.ApiResult.Error("用户名或密码错误"));
            //表单校验，写人信息
            System.Web.Security.FormsAuthentication.SetAuthCookie(userInfo.LoginName, parameter.IsPersistent??false);
            var targetUrl= System.Web.Security.FormsAuthentication.GetRedirectUrl(userInfo.LoginName, parameter.IsPersistent ?? false);
            return this.Json(Model.ApiResult.OK(new { targetUrl}));
        }
    }
}