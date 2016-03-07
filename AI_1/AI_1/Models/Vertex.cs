using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Vertex
    {
        [Obsolete("This property is not used in current problem")]
        public int Weight { get; set; }

        public int Color { get; set; }

        public const char ABBREVIATION = 'n';

        public Vertex()
        {
            Color = 0;
        }

        public string Print()
        {
            //var weight = Weight.ToString().PadLeft(3, ' ');
            var color = Color.ToString().PadLeft(3, ' ');

            return string.Format("{0} c:{1}", ABBREVIATION, color);
        }
    }
}
