using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
namespace Gutop.Bll
{
    public class Bll<T>: Entity.Autofac.IScoped where T:class
    {

        protected Entity.DbContext dbcontext;

        public Bll(Entity.DbContext dbcontext)
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

        public T GetEntity(Expression<Func<T, bool>> predicate)
        {
            var lst = this.dbcontext.Set<T>().Where(predicate).FirstOrDefault();
            return lst;
        }

        public List<T> GetEntities()
        {
            var lst = this.dbcontext.Set<T>().ToList();
            return lst;
        }

        public int Add(IEnumerable<T> lst)
        {
            this.dbcontext.Set<T>().AddRange(lst);
            return this.dbcontext.SaveChanges();
        }

    }
}
