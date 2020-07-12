using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Model.DTO
{
    public class BizContext:Model.Autofac.IScoped
    {
        public Model.UserInfo UserInfo { get; set; }

        public Tools.IIndex<Enum.CacheIndex> ICache { get; set; }

        public Tools.IIndex<Enum.SessionIndex> ISession { get; set; }
    }
}
