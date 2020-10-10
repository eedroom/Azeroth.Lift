using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model.DTO
{
    public class BizContext:Model.Autofac.IScoped
    {
        public Model.UserInfo UserInfo { get; set; }

        public Gutop.Util.IIndex<Enum.CacheIndex> ICache { get; set; }

        public Gutop.Util.IIndex<Enum.SessionIndex> ISession { get; set; }
    }
}
