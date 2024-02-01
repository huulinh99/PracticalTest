using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PracticalTest.Utils
{
    public static class TraceLog
    {

        // Methods
        static TraceLog()
        {
        }

        public static string GetAllErrMessages(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            for (Exception exception = ex; exception != null; exception = exception.InnerException)
            {
                builder.AppendLine(exception.Message + " at " + exception.Source + ", trace: " + exception.StackTrace);
            }
            return builder.ToString();
        }

        public static void WriteToLog(string message)
        {
            Log.Information(message);
        }

        public static void WriteToLog(string message, Exception ex)
        {
            Log.Error(ex, message + " - " + GetAllErrMessages(ex));
        }
    }
}