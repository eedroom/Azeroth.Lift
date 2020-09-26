using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Tools
{
   public interface  IIndex<T>
    {
        object this[T key] { get; set; }

    }
}
