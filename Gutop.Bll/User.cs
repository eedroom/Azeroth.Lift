using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gutop.Model.VO.Account;

namespace Gutop.Bll {
    public class User : Bll {
        public bool ValidLogin(Login parameter,out Model.Entity.User user) {
            user= this.DbContext.User.Where(x => x.LoginName == parameter.LoginName)
               .Where(x => x.Password == parameter.PassWord)
               .FirstOrDefault();
            return user != null;
        }
    }
}
