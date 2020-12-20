using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
    public class MenuInfo:Bll
    {
        public MenuInfo(Gutop.Model.Entity.DbContext dbcontext):base(dbcontext)
        {

        }
        public int Init()
        {
           var lstUrlMap= System.Linq.Enumerable.Range(0, 10)
                .Select(x => new Gutop.Model.Entity.UrlMap()
                {
                    Id = Guid.NewGuid(),
                    Description = "menu" + x.ToString(),
                    Pid = Guid.Empty,
                    Action = "url" + x.ToString()
                }).ToList();
            this.dbcontext.Set<Gutop.Model.Entity.UrlMap>().AddRange(lstUrlMap);
            var rt = this.dbcontext.SaveChanges();
            return rt;
        }
    }
}
