using Gutop.Model.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
    public class BizContext : IScoped
    {
        public Entity.UserInfo UserInfo { get; set; }

        public Gutop.Util.IIndex<Model.CacheIndex> ICache { get; set; }

        public Gutop.Util.IIndex<Model.SessionIndex> ISession { get; set; }
    }
}
