using System;
using System.Diagnostics;

namespace ConsoleApplication.AquaSharp.Utils
{
    public static class Logger
    {
        public static void Error(string message, string module)
        {
            WriteEntry(message, "ERROR", module);
        }

        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.Message, "ERROR", module);
        }

        public static void Warning(string message, string module)
        {
            WriteEntry(message, "WARNING", module);
        }

        public static void Info(string message, string module)
        {
            WriteEntry(message, "INFO", module);
        }

        private static void WriteEntry(string message, string type, string module)
        {
            Console.WriteLine(
                string.Format("{0} {1} {2}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    type,
                    message));
        }
    }
}