using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Gutop.Model.Autofac;

namespace Gutop.Bll
{
    public class Bll: IScoped 
    {

        protected Gutop.Model.Entity.DbContext dbcontext;

        public Bll(Gutop.Model.Entity.DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        /// <summary>
        /// 获取指定筛选条件的数据
        /// 场景：单表，简单的筛选条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetEntities<T>(Expression<Func<T,bool>> predicate) where T : class
        {
            var lst= this.dbcontext.Set<T>().Where(predicate).ToList();
            return lst;
        }

        public T GetEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var lst = this.dbcontext.Set<T>().Where(predicate).FirstOrDefault();
            return lst;
        }

        public List<T> GetEntities<T>() where T : class
        {
            var lst = this.dbcontext.Set<T>().ToList();
            return lst;
        }

        public int Add<T>(IEnumerable<T> lst) where T : class
        {
            this.dbcontext.Set<T>().AddRange(lst);
            return this.dbcontext.SaveChanges();
        }

    }
}
