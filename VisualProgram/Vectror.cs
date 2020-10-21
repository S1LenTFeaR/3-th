using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualProgram
{
    public partial class Vector : Form
    {
        public Vector()
        {
            InitializeComponent();
        }
        MyVector v1 = new MyVector();
        MyVector v2 = new MyVector();
        MyVector v3 = new MyVector();
        double[] X = new double[2];
        double[] Y = new double[2];
        double[] Z = new double[2];
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Label7_Click(object sender, EventArgs e)
        {

        }
        private void Label8_Click(object sender, EventArgs e)
        {

        }
        private void X1_TextChanged(object sender, EventArgs e)
        {
            v1.x = Convert.ToDouble(X1.Text);
        }
        private void Y1_TextChanged(object sender, EventArgs e)
        {
            v1.y = Convert.ToDouble(X1.Text);
        }
        private void Z1_TextChanged(object sender, EventArgs e)
        {
            v1.z = Convert.ToDouble(X1.Text);
        }
        private void X2_TextChanged(object sender, EventArgs e)
        {
            v2.x = Convert.ToDouble(X1.Text);
        }
        private void Y2_TextChanged(object sender, EventArgs e)
        {
            v2.y = Convert.ToDouble(X1.Text);
        }
        private void Z2_TextChanged(object sender, EventArgs e)
        {
            v2.z = Convert.ToDouble(X1.Text);
        }
        private void X3_TextChanged(object sender, EventArgs e)
        {

        }
        private void Y3_TextChanged(object sender, EventArgs e)
        {

        }
        private void Z3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e) //Сумма
        {
            if(radioButton1.Checked == true)
            {
               
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e) //Разность
        {
            if (radioButton2.Checked == true)
            {

            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e) //Произведение на скаляр
        {
            if (radioButton3.Checked == true)
            {

            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e) //Модулль
        {
            if (radioButton4.Checked == true)
            {

            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e) //Проекция
        {
            if (radioButton5.Checked == true)
            {

            }
        }
    }
}

