using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
    public class MenuInfo:Bll<Model.MenuInfo>
    {
        public MenuInfo(Model.DbContext dbcontext):base(dbcontext)
        {

        }
        public int Init()
        {
           var lstMenu= System.Linq.Enumerable.Range(0, 10)
                .Select(x => new Model.MenuInfo()
                {
                    Id = Guid.NewGuid(),
                    Name = "menu" + x.ToString(),
                    Pid = Guid.Empty,
                    Url = "url" + x.ToString()
                }).ToList();
            this.dbcontext.Set<Model.MenuInfo>().AddRange(lstMenu);
            var rt = this.dbcontext.SaveChanges();
            return rt;
        }
    }
}
