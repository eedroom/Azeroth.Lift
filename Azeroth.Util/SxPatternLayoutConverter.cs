using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace Azeroth.Util {
    public class SxPatternLayoutConverter : log4net.Layout.Pattern.PatternLayoutConverter {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent) {
            var pp= loggingEvent.MessageObject.GetType().GetProperty(this.Option, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (pp == null) {
                writer.Write(string.Format("指定的属性[{0}]未找到", this.Option));
                return;
            }
            var value= pp.GetValue(loggingEvent.MessageObject);
            var valuestr= Newtonsoft.Json.JsonConvert.SerializeObject(value);
            if (!valuestr.StartsWith("\"")) {
                writer.Write(valuestr);
                return;
            }
            var tmp = valuestr.Substring(1, valuestr.Length - 2);
            writer.Write(tmp);
        }
    }
}
