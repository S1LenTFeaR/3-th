using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Program
{
    //Коллекция цветов
    [Serializable]
    public class My_Colors
    {
        public List<My_Color> ColorsList { get; set; } = new List<My_Color>();

        public My_Colors()
        {

        }
    }
    //Цвет
    [Serializable]
    public class My_Color
    {
        public int Number { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public My_Color()
        {

        }

        public My_Color(int Number, byte R, byte G, byte B)
        {
            this.Number = Number;
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }
}
