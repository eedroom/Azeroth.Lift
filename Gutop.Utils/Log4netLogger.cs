using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace Azeroth.Util {
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
            string msg = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Trace:
                    this.logger.Debug(msg, exception);
                    break;
                case LogLevel.Debug:
                    this.logger.Debug(msg, exception);
                    break;
                case LogLevel.Information:
                    this.logger.Info(msg, exception);
                    break;
                case LogLevel.Warning:
                    this.logger.Warn(msg, exception);
                    break;
                case LogLevel.Error:
                    this.logger.Error(msg, exception);
                    break;
                case LogLevel.Critical:
                    this.logger.Fatal(msg, exception);
                    break;
                case LogLevel.None:
                    this.logger.Fatal(msg, exception);
                    break;
                default:
                    break;
            }
        }
    }
}