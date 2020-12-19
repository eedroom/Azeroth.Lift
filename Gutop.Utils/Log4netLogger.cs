using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace Gutop.Utils
{
    public class Log4netLogger : Microsoft.Extensions.Logging.ILogger
    {
        string categoryName;
        log4net.ILog logger;
        public Log4netLogger(string categoryName)
        {
            this.categoryName = categoryName;
            this.logger= log4net.LogManager.GetLogger("loginfo");
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    break;
                case LogLevel.Debug:
                    this.logger.Debug("debug", exception);
                    break;
                case LogLevel.Information:
                    break;
                case LogLevel.Warning:
                    break;
                case LogLevel.Error:
                    break;
                case LogLevel.Critical:
                    break;
                case LogLevel.None:
                    break;
                default:
                    break;
            }
        }
    }
}