using Gutop.Model.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
    public class UserInfo :IScoped
    {
        public string LoginName { get; set; }

        public List<Entity.MenuInfo> MenuInfos{ get; set; }

    }
}
