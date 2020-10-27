using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace _3_lab
{

    class Rectangle //Класс "Прямоуголльник"
    {
        private double A;
        private double B;
        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }
        public double Area(Rectangle f1) //Функция нахождения площади
        {
            return f1.A * f1.B;
        }
        public double Perimeter(Rectangle f1) //Функция нахождения периметра
        {
            return 2 * (f1.A + f1.B);
        }
        public string GetInfo(Rectangle f1)
        {
            return "A, B = " + Convert.ToString(f1.A) + ", " + Convert.ToString(f1.B);
        }
    }
    class Circle //Класс "Окружность"
    {
        private double R;
        public Circle(double r)
        {
            R = r;
        }
        public double Area(Circle f1) //Функция нахождения площади
        {
            return Math.PI * R * R;
        }
        public double Perimeter(Circle f1) //Функция нахождения периметра
        {
            return 2 * Math.PI * R;
        }
        public string GetInfo(Circle f1)
        {
            return "R = " + Convert.ToString(f1.R);
        }
    }
    class Trapezium //Класс "Трапеция"
    {
        private double A, B, C, D;
        public Trapezium(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public double Area(Trapezium f1) //Функция нахождения площади
        {
            return Math.Sqrt(C*C - Math.Pow((Math.Pow(B - A, 2) + C*C - D*D) / (2.0 * (B - A)), 2)) * (A + B) / 2.0;
        }
        public double Perimeter(Trapezium f1) //Функция нахождения периметра
        {
            return A + B + C + D;
        }
        public string GetInfo(Trapezium f1)
        {
            return "A, B, C, D = " + Convert.ToString(f1.A) + ", " + Convert.ToString(f1.B) + ", " + Convert.ToString(f1.C) + ", " + Convert.ToString(f1.D);
        }
    }
}
*/