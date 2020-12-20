using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
    public class Log:Model.Autofac.ISingleton
    {
        public Log(Model.Entity.DbContext dbContext) {
            this.dbContext = dbContext;
        }
        Model.Entity.DbContext dbContext;

        public int Add(IList<Model.Entity.Log> lstLog) {
             this.dbContext.Log.AddRange(lstLog);
            return this.dbContext.SaveChanges();
        }
    }
}
