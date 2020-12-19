using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace Gutop.Utils
{
    public class Log4netLoggerProvider : Microsoft.Extensions.Logging.ILoggerProvider
    {
        public Log4netLoggerProvider()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Log4netLogger(categoryName);
        }

        public void Dispose()
        {
            
        }
    }
}