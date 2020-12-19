using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace Gutop.Utils
{
    public class GutopLogger : Microsoft.Extensions.Logging.ILogger
    {
        string categoryName;
        Action<LogWrapper> adapterHandler;
        public GutopLogger(string categoryName, Action<LogWrapper> adapterHandler)
        {
            this.categoryName = categoryName;
            this.adapterHandler = adapterHandler;
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
            LogWrapper lw = new LogWrapper() {
                CategoryName = this.categoryName,
                EventId = eventId,
                Exception = exception,
                LogLevel = logLevel,
                 Content=formatter(state,exception)
            };
            this.adapterHandler(lw);
        }
    }
}