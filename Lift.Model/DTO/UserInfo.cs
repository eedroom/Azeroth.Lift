using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Model.DTO
{
    public class UserInfo:Model.Autofac.IScoped
    {
        public string Account { get; set; }
        public string NikeName { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
