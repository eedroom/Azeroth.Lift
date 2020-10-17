using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
   public  class LogInfo: Bll<Gutop.Entity.LogInfo>
    {
        public LogInfo(Entity.DbContext dbcontext):base(dbcontext)
        {

        }
    }
}
