using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Program
{
    class My_Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public My_Color()
        {

        }

        public My_Color(byte R, byte G, byte B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }
}