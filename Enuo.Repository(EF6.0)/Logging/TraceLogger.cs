using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enuo.Infrastructure.Logging
{
    public class TraceLogger : ILogger
    {
        private static string FormatExceptionMessage(Exception exception, string fmt, object[] vars)
        {
            // Simple exception formatting: for a more comprehensive version see 
            // http://code.msdn.microsoft.com/windowsazure/Fix-It-app-for-Building-cdd80df4
            var sb = new StringBuilder();
            sb.Append(string.Format(fmt, vars));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            return sb.ToString();
        }

        public void Critical<T>(string message) where T : class
        {
            throw new NotImplementedException();
        }

        public void Debug<T>(string message) where T : class
        {
            throw new NotImplementedException();
        }

        public void Defined<T>(string message, string category) where T : class
        {
            throw new NotImplementedException();
        }

        public void Error<T>(Exception exception) where T : class
        {
            throw new NotImplementedException();
        }

        public void Error<T>(string message)where T :class
        {
            Trace.TraceError(message);
        }

        public void Information<T>(Exception exception) where T : class
        {
            throw new NotImplementedException();
        }

        public void Information<T>(string message) where T:class
        {
            Trace.TraceInformation(message);
        }

        public void Warning<T>(Exception exception) where T : class
        {
            throw new NotImplementedException();
        }

        public void Warning<T>(string message)where T :class
        {
            Trace.TraceWarning(message);
        }
    }
}
