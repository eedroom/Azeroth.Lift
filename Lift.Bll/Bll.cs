using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Lift.Bll
{
    public class Bll<T>:Model.Autofac.ITransient where T:class
    {

        protected Model.DbContext dbcontext;

        public Bll(Model.DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        /// <summary>
        /// 获取指定筛选条件的数据
        /// 场景：单表，简单的筛选条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetEntities(Expression<Func<T,bool>> predicate)
        {
            var lst= this.dbcontext.Set<T>().Where(predicate).ToList();
            return lst;
        }

        public List<T> GetEntities()
        {
            var lst = this.dbcontext.Set<T>().ToList();
            return lst;
        }
    }
}
