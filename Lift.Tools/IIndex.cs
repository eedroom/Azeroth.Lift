using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Tools
{
   public interface  IIndex
    {
        object this[string key] { get; set; }

    }
}
