using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
    public class ExceptionInterceptedWrapper:System.Exception
    {
        public ExceptionInterceptedWrapper(string msg):base(msg)
        {
            
        }
    }
}
