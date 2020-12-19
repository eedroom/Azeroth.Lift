using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
     public class GutopRuntimeException:Exception
    {
        public object requestParameter { get; set; }

        public GutopRuntimeException(object parameter,string msg):base(msg)
        {
            this.requestParameter = parameter;
        }
        public GutopRuntimeException(object parameter,string msg,Exception ex) : base(msg,ex)
        {
            this.requestParameter = parameter;
        }
    }
}
