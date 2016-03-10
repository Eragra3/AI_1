using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Helpers
{
    public class CommonMethods
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BCPIsValid(int weight, int color1, int color2)
        {
            return color1 > 0 && color2 > 0 && Math.Abs(color1 - color2) >= weight;
        }
    }
}
