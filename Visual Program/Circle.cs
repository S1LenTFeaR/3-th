using System;

namespace Visual_Program
{
    class Circle
    {
        //Пустой конструктор
        public Circle()
        {

        }
        //Радианы в градусы
        private double FuncFi(double fi)
        {
            return fi * Math.PI / 180;
        }
        //Рассчет X через угол и радиус
        public double FuncX(double fi, double r)
        {
            return 150 + r * Math.Cos(FuncFi(fi));
        }
        //Рассчет X через угол и радиус
        public double FuncY(double fi, double r)
        {
            return 150 - r * Math.Sin(FuncFi(fi));
        }
    }
}
