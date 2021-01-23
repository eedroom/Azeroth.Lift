using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
    public class LogWrapper {
        public string Content { get; set; }
        public LogLevel LogLevel { get; set; }

        public EventId EventId { get; set; }

        public Exception Exception { get; set; }

        public string CategoryName { get; set; }
    }
}
