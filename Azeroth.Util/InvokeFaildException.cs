using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
     public class InvokeFaildException:Exception
    {
        public object RequestArgs { get; set; }

        public InvokeFaildException(object args,string msg):base(msg)
        {
            this.RequestArgs = args;
        }
        public InvokeFaildException(object args,string msg,Exception ex) : base(msg,ex)
        {
            this.RequestArgs = args;
        }

        public System.Reflection.MethodInfo Method { get; set; }
    }
}
