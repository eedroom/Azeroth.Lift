using Gutop.Model.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
    public class UserWrapper :IScoped
    {
        public Model.Entity.User User { get; set; }
        public List<Entity.UrlMap> MenuCollection{ get; set; }

    }
}
