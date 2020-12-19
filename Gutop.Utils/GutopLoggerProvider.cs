using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace Gutop.Utils
{
    public class GutopLoggerProvider : Microsoft.Extensions.Logging.ILoggerProvider
    {
        Action<LogWrapper> adapterHandler;
        public GutopLoggerProvider(Action<LogWrapper> adapterHandler)
        {
            this.adapterHandler = adapterHandler;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new GutopLogger(categoryName,this.adapterHandler);
        }

        public void Dispose()
        {
            
        }
    }
}