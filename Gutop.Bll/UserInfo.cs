using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
    public class UserInfo : Bll<Gutop.Entity.UserInfo>
    {
        public UserInfo(Entity.DbContext dbcontext):base(dbcontext)
        {

        }
    }
}
