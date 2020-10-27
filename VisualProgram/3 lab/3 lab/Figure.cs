using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_lab
{
    public abstract class Figure //Класс "Фигура"
    {
        public abstract double Area(); //Абстракный метод нахождения площади
        public abstract double Perimeter(); //Абстракный метод нахождения периметра
        public abstract string GetInfo(); //Абстракный метод показа информации о фигурах
    }
    class Rectangle : Figure //Класс "Прямоуголльник"
    {
        private double A, B; //Объявлление и инициализация сторон прямоугльника
        public Rectangle(double a, double b) //Конструктор
        {
            A = a;
            B = b;
        }
        public override double Area() //Функция нахождения площади
        {
            return A * B;
        }
        public override double Perimeter() //Функция нахождения периметра
        {
            return 2 * (A + B);
        }
        public override string GetInfo() //Метод показа информации о фигурах
        {
            return "A, B = " + Convert.ToString(A) + ", " + Convert.ToString(B);
        }
    }
    class Circle : Figure //Класс "Окружность"
    {
        private double R; //Объявлление и инициализация радиуса
        public Circle(double r) //Конструктор
        {
            R = r;
        }
        public override double Area() //Функция нахождения площади
        {
            return Math.PI * R * R;
        }
        public override double Perimeter() //Функция нахождения периметра
        {
            return 2 * Math.PI * R;
        }
        public override string GetInfo() //Метод показа информации о фигурах
        {
            return "R = " + Convert.ToString(R);
        }
    }
    class Trapezium : Figure //Класс "Трапеция"
    {
        private double A, B; //Объявлление и инициализация оснований трапеции
        private double C, D; //Объявлление и инициализация боковых сторон трапеции
        public Trapezium(double a, double b, double c, double d) //Конструктор
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public override double Area() //Функция нахождения площади
        {
            return Math.Sqrt(C * C - Math.Pow((Math.Pow(B - A, 2) + C * C - D * D) / (2.0 * (B - A)), 2)) * (A + B) / 2.0;
        }
        public override double Perimeter() //Функция нахождения периметра
        {
            return A + B + C + D;
        }
        public override string GetInfo()
        {
            return "A, B, C, D = " + Convert.ToString(A) + ", " + Convert.ToString(B) + ", " + Convert.ToString(C) + ", " + Convert.ToString(D);
        }
    }
}
