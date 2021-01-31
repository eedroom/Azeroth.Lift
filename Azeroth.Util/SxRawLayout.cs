using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace Azeroth.Util {
    public class SxRawLayout : log4net.Layout.IRawLayout {
        public string Name { get; set; }
        public object Format(LoggingEvent loggingEvent) {
            var pp= loggingEvent.MessageObject.GetType().GetProperty(this.Name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            var value= pp.GetValue(loggingEvent.MessageObject);
            return value;
        }
    }
}
