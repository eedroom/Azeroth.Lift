using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
    public class MenuInfo:Bll<Gutop.Entity.MenuInfo>
    {
        public MenuInfo(Entity.DbContext dbcontext):base(dbcontext)
        {

        }
        public int Init()
        {
           var lstMenu= System.Linq.Enumerable.Range(0, 10)
                .Select(x => new Gutop.Entity.MenuInfo()
                {
                    Id = Guid.NewGuid(),
                    Name = "menu" + x.ToString(),
                    Pid = Guid.Empty,
                    Url = "url" + x.ToString()
                }).ToList();
            this.dbcontext.Set<Gutop.Entity.MenuInfo>().AddRange(lstMenu);
            var rt = this.dbcontext.SaveChanges();
            return rt;
        }
    }
}
