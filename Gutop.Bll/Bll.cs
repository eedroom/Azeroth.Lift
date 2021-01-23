using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Azeroth.Util.Autofac;

namespace Gutop.Bll
{
    public class Bll: IScoped 
    {

        public Gutop.Model.Entity.DbContext DbContext { set; get; }

        /// <summary>
        /// 获取指定筛选条件的数据
        /// 场景：单表，简单的筛选条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetEntities<T>(Expression<Func<T,bool>> predicate) where T : class
        {
            var lst= this.DbContext.Set<T>().Where(predicate).ToList();
            return lst;
        }

        public T GetEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var lst = this.DbContext.Set<T>().Where(predicate).FirstOrDefault();
            return lst;
        }

        public List<T> GetEntities<T>() where T : class
        {
            var lst = this.DbContext.Set<T>().ToList();
            return lst;
        }

        public int Add<T>(IEnumerable<T> lst) where T : class
        {
            this.DbContext.Set<T>().AddRange(lst);
            return this.DbContext.SaveChanges();
        }

    }
}
