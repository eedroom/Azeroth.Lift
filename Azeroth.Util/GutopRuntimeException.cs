using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
     public class GutopRuntimeException:Exception
    {
        public object requestArgs { get; set; }

        public GutopRuntimeException(object args,string msg):base(msg)
        {
            this.requestArgs = args;
        }
        public GutopRuntimeException(object args,string msg,Exception ex) : base(msg,ex)
        {
            this.requestArgs = args;
        }

        public System.Reflection.MethodInfo Method { get; set; }
    }
}
