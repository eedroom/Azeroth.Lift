using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace Azeroth.Util {
    public class Log<T> : ILog<T> {
        public log4net.ILog LogInternal { get; set; }
        public Log() {
            this.LogInternal = log4net.LogManager.GetLogger(typeof(T));
        }
        public bool IsDebugEnabled {
            get {
                return this.LogInternal.IsDebugEnabled;
            }
        }

        public bool IsErrorEnabled {
            get {
                return this.LogInternal.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled {
            get {
                return this.LogInternal.IsFatalEnabled;
            }
        }

        public bool IsInfoEnabled {
            get {
                return this.LogInternal.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled {
            get {
                return this.LogInternal.IsWarnEnabled;
            }
        }

        public ILogger Logger {
            get {
                return this.LogInternal.Logger;
            }
        }

        public void Debug(object message) {
            this.LogInternal.Debug(message);
        }

        public void Debug(object message, Exception exception) {
            this.LogInternal.Debug(message, exception);
        }

        public void DebugFormat(string format, object arg0) {
            this.LogInternal.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, params object[] args) {
            this.LogInternal.DebugFormat(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args) {
            this.LogInternal.DebugFormat(provider, format, args);
        }

        public void DebugFormat(string format, object arg0, object arg1) {
            this.LogInternal.DebugFormat(format,arg0,arg1);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2) {
            this.LogInternal.DebugFormat(format, arg0, arg1, arg2);
        }

        public void Error(object message) {
            this.LogInternal.Error(message);
        }

        public void Error(object message, Exception exception) {
            this.LogInternal.Error(message, exception);
        }

        public void ErrorFormat(string format, object arg0) {
            this.LogInternal.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, params object[] args) {
            this.LogInternal.ErrorFormat(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args) {
            this.LogInternal.ErrorFormat(provider, format, args);
        }

        public void ErrorFormat(string format, object arg0, object arg1) {
            this.LogInternal.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2) {
            this.LogInternal.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void Fatal(object message) {
            this.LogInternal.Fatal(message);
        }

        public void Fatal(object message, Exception exception) {
            this.LogInternal.Fatal(message, exception);
        }

        public void FatalFormat(string format, object arg0) {
            this.LogInternal.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, params object[] args) {
            this.LogInternal.FatalFormat(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args) {
            this.LogInternal.FatalFormat(provider, format, args);
        }

        public void FatalFormat(string format, object arg0, object arg1) {
            this.LogInternal.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2) {
            this.LogInternal.FatalFormat(format, arg0, arg1, arg2);
        }

        public void Info(object message) {
            this.LogInternal.Info(message);
        }

        public void Info(object message, Exception exception) {
            this.LogInternal.Info(message, exception);
        }

        public void InfoFormat(string format, object arg0) {
            this.LogInternal.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, params object[] args) {
            this.LogInternal.InfoFormat(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args) {
            this.LogInternal.InfoFormat(provider, format, args);
        }

        public void InfoFormat(string format, object arg0, object arg1) {
            this.LogInternal.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2) {
            this.LogInternal.InfoFormat(format, arg0, arg1, arg2);
        }

        public void Warn(object message) {
            this.LogInternal.Warn(message);
        }

        public void Warn(object message, Exception exception) {
            this.LogInternal.Warn(message, exception);
        }

        public void WarnFormat(string format, object arg0) {
            this.LogInternal.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, params object[] args) {
            this.LogInternal.WarnFormat(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args) {
            this.LogInternal.WarnFormat(provider, format, args);
        }

        public void WarnFormat(string format, object arg0, object arg1) {
            this.LogInternal.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2) {
            this.LogInternal.WarnFormat(format, arg0, arg1, arg2);
        }
    }
}
