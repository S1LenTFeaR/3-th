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
        void v2_disabled()
        {
            TextX2.Enabled = false;
            TextY2.Enabled = false;
            TextZ2.Enabled = false;
        }
        void v2_enebled()
        {
            TextX2.Enabled = true;
            TextY2.Enabled = true;
            TextZ2.Enabled = true;
        }
        void v3_disabled()
        {
            TextX3.Enabled = false;
            TextY3.Enabled = false;
            TextZ3.Enabled = false;
        }
        void v3_enebled()
        {
            TextX3.Enabled = true;
            TextY3.Enabled = true;
            TextZ3.Enabled = true;
        }
        void v1_on_display(MyVector v1)
        {
            TextX1.Text = Convert.ToString(v1.x);
            Text1.Text = Convert.ToString(v1.y);
            TextZ1.Text = Convert.ToString(v1.z);
        }
        void v3_on_display(MyVector v3)
        {
            TextX3.Text = Convert.ToString(v3.x);
            TextY3.Text = Convert.ToString(v3.y);
            TextZ3.Text = Convert.ToString(v3.z);
        }
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
            v1.x = Convert.ToDouble(TextX1.Text);
        }
        private void Y1_TextChanged(object sender, EventArgs e)
        {
            v1.y = Convert.ToDouble(Text1.Text);
        }
        private void Z1_TextChanged(object sender, EventArgs e)
        {
            v1.z = Convert.ToDouble(TextZ1.Text);
        }
        private void X2_TextChanged(object sender, EventArgs e)
        {
            v2.x = Convert.ToDouble(TextX2.Text);
        }
        private void Y2_TextChanged(object sender, EventArgs e)
        {
            v2.y = Convert.ToDouble(TextY2.Text);
        }
        private void Z2_TextChanged(object sender, EventArgs e)
        {
            v2.z = Convert.ToDouble(TextZ2.Text);
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
                label8.Text = "+";
            }
        }
        private void RadioButton2_CheckedChanged(object sender, EventArgs e) //Разность
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "-";
            }
        }
        private void RadioButton3_CheckedChanged(object sender, EventArgs e) //Произведение на скаляр
        {
            if (radioButton3.Checked == true)
            {
                v2_disabled();
                textScal.Enabled = true;
                label8.Text = "*";
            }
            else
            {
                v2_enebled();
                textScal.Enabled = false;
            }
        }
        private void RadioButton4_CheckedChanged(object sender, EventArgs e) //Модуль
        {
            if (radioButton4.Checked == true)
            {
                v3_disabled();
                textPro.Enabled = true;
                textMod.Enabled = true;
            }
            else
            {
                v3_enebled();
                textPro.Enabled = false;
                textMod.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Label12_Click(object sender, EventArgs e)
        {

        }
        private void Label15_Click(object sender, EventArgs e)
        {

        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MyVector v1 = new MyVector();
            v1 = v1.spher(Convert.ToDouble(TextR.Text), Convert.ToDouble(TextFI.Text), Convert.ToDouble(TextO.Text));
            v1_on_display(v1);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                MyVector v3 = new MyVector();
                v3 = v1 + v2;
                v3_on_display(v3);
            }
            else if (radioButton2.Checked == true)
            {
                MyVector v3 = new MyVector();
                v3 = v1 - v2;
                v3_on_display(v3);
            }
            else if (radioButton3.Checked == true)
            {
                MyVector v3 = new MyVector();
                double Sk = Convert.ToDouble(textScal.Text);
                v3 = v1 * Sk;
                v3_on_display(v3);
            }
            else if (radioButton4.Checked == true)
            {
                textMod.Text = Convert.ToString(v1.moodle(v1));
                textPro.Text = Convert.ToString(v1.projection(v1, v2)); 
            }
        }
        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

