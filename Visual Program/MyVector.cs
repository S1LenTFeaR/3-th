using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Program
{
    class MyVector
    {
        private double X;
        private double Y;
        private double Z;
        public MyVector(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public MyVector() { }
        //MyVector v1 = new MyVector();
        public double x
        {
            set { this.X = value; }
            get { return X; }
        }
        public double y
        {
            set { this.Y = value; }
            get { return Y; }
        }

        public double z
        {
            set { this.Z = value; }
            get { return Z; }
        }
        /* r - расстояние от начала координат до точки
        fi - угол, образованный проекцией радиус-вектора точки M на плоскость ху с положительным направлением оси х
        θ – угол между положительным направлением оси Oz и радиус-вектором точки М */
        public MyVector spher(double r, double fi, double O)
        {
            double O_grad = O * Math.PI / 180;
            double fi_grad = fi * Math.PI / 180;
            MyVector v1 = new MyVector();
            v1.X = r * Math.Sin(O_grad) * Math.Cos(fi_grad);
            v1.Y = r * Math.Sin(O_grad) * Math.Sin(fi_grad);
            v1.Z = r * Math.Cos(O_grad);
            return v1;
        }
        public static MyVector operator +(MyVector v1, MyVector v2)
        {
            MyVector v3 = new MyVector();
            v3.X = v1.X + v2.X;
            v3.Y = v1.Y + v2.Y;
            v3.Z = v1.Z + v2.Z;
            return v3;
        }
        public static MyVector operator -(MyVector v1, MyVector v2)
        {
            MyVector v3 = new MyVector();
            v3.X = v1.X - v2.X;
            v3.Y = v1.Y - v2.Y;
            v3.Z = v1.Z - v2.Z;
            return v3;
        }
        public static MyVector operator *(MyVector v1, double Sk)
        {
            MyVector v3 = new MyVector();
            v3.X = v1.X * Sk;
            v3.Y = v1.Y * Sk;
            v3.Z = v1.Z * Sk;
            return v3;
        }
        
        public double scalarmult(MyVector v1, MyVector v2)
        {
            double SM;
            SM = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
            return SM;
        }
        public double projection(MyVector v1, MyVector v2)
        {
            double proj = scalarmult(v1, v2) / moodle(v2);
            return proj;
        }
        public double moodle(MyVector v1)
        {
            double mod = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            return mod;
        }
    }
}
