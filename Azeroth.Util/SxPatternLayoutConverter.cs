using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace Azeroth.Util {
    public class SxPatternLayoutConverter : log4net.Layout.Pattern.PatternLayoutConverter {
        static System.Reflection.Assembly fwAsm = typeof(string).Assembly;
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent) {
            var meta = loggingEvent.MessageObject.GetType();
            if (meta.Assembly == fwAsm)
                return;
            var sxMeta= meta.GetProperty(this.Option, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (sxMeta == null)
                return;
            var value= sxMeta.GetValue(loggingEvent.MessageObject);
            if (value == null)
                return;
            if (sxMeta.PropertyType.Assembly == fwAsm) {
                writer.Write(value.ToString());
            }
            var valuejson= Newtonsoft.Json.JsonConvert.SerializeObject(value);
            writer.Write(valuejson);
        }
    }
}
