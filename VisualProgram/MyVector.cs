using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProgram
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
        MyVector v1 = new MyVector();
        public double x
        {
            set
            {
                this.X = value;
            }
            get { return X; }
        }
        public double y
        {
            set
            {
                this.Y = value;
            }
            get { return Y; }
        }
 
        public double z
        {
            set
            {
                this.Z = value;
            }
            get { return Z; }
        }
        public void sum(MyVector v1, MyVector v2)
        {
            MyVector v3(v1.x + v2.x , v1.y + v2.y , v1.z + v2.z);
            return v3;
        }
    }



}
