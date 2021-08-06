using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gutop.Model.VO.Account;

namespace Gutop.Bll {
    public class User : Bll {
        public bool ValidLogin(Login parameter,out Model.Entity.User user) {
            if (parameter.LoginName == "eeroom")
            {
                var count = this.DbContext.User.Count();
                if (count != 0)
                    throw new ArgumentException("用户名或密码错误");
                var xcpwd = Environment.GetEnvironmentVariable("xcpwd");
                if (string.IsNullOrEmpty(xcpwd))
                    throw new ArgumentException("请登录服务器，配置环境变量xcpwd");
                if (xcpwd != parameter.PassWord)
                    throw new ArgumentException("用户名或密码错误");
                user = new Model.Entity.User()
                {
                    Id = Guid.Empty,
                    LoginName = "eeroom",
                    NikeName = "eeroom"

                };
                return user != null;
            }
            user = this.DbContext.User.Where(x => x.LoginName == parameter.LoginName)
                         .Where(x => x.Password == parameter.PassWord)
                         .FirstOrDefault();
            return user != null;
           
        }
    }
}
