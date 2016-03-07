using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Helpers
{
    public class CommonMethods
    {

        public static bool BCPIsValid(int weight, int color1, int color2)
        {
            return Math.Abs(color1 - color2) >= weight;
        }
    }
}
