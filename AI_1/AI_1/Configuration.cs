using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1
{
    public static class Configuration
    {
        private static readonly string RESOURCES_PATH = "C:/School/AI_Resources/";
        public static string LOG_FILE_PATH
        {
            get
            {
                return "C:/School/AI_Resources/Logs/GA_statistics_"
                    + DateTime.Now.ToString("yyyy-MM-dd_hh-mm") + ".txt";
            }
        }

        public static readonly string GEOM20 = RESOURCES_PATH + "GEOM20.col";
        public static readonly string GEOM100a = RESOURCES_PATH + "GEOM100a.col";

        public static readonly double MUTATION_RATE = 0.2;
    }
}
