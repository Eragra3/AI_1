using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Helpers
{
    public static class StaticWriter
    {
        private static string _logPath = Configuration.RESOURCES_PATH + "Logs/";

        public static string Description = string.Empty;

        public static void Log(string msg)
        {
            using (var writer = File.AppendText(_logPath + Description))
            {
                writer.WriteLine(msg);
                writer.Flush();
            }
        }
    }
}
