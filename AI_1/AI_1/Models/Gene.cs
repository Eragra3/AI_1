using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Gene
    {
        public int id;

        public int color;

        public Edge[] edges; 

        public Gene(int id)
        {
            this.id = id;

            color = 0;
        }

        public string Print()
        {
            var id = this.id.ToString().PadLeft(3, ' ');
            var color = this.color.ToString().PadLeft(3, ' ');

            return string.Format("{0} c:{1}", id, color);
        }
    }
}
