using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.Portal.Controllers.Admin
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Model.VO.LoginUserInfo loginUserInfo)
        {
            var userInfo = new Model.UserInfo() { LoginName = loginUserInfo.LoginName };
            if (userInfo == null)
                return this.Json(Model.ApiResult.Error("用户名或密码错误"));
            //表单校验，写人信息
            System.Web.Security.FormsAuthentication.SetAuthCookie(userInfo.LoginName, true);
            var targetUrl= System.Web.Security.FormsAuthentication.GetRedirectUrl(userInfo.LoginName, true);
            return this.Json(Model.ApiResult.OK(new { targetUrl}));
        }
    }
}