using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            /* Внутри кажждого блока с условием происходит вызов соответствующих
            конструктора фигуры нужного типа, 
            информации о фигуре, а также методов нахождения площади и периметра */
            if (radioButton1.Checked == true)
            {
                Figure f1 = new Rectangle(5, 2);
                textBox1.Text = f1.GetInfo();
                textBox2.Text = Convert.ToString(f1.Area());
                textBox3.Text = Convert.ToString(f1.Perimeter());

            }
            else if (radioButton2.Checked == true)
            {
                Figure f1 = new Trapezium(3, 5, 5, 5);
                textBox1.Text = f1.GetInfo();
                textBox2.Text = Convert.ToString(f1.Area());
                textBox3.Text = Convert.ToString(f1.Perimeter());
            }
            else if (radioButton3.Checked == true)
            {
                Figure f1 = new Circle(5);
                textBox1.Text = f1.GetInfo();
                textBox2.Text = Convert.ToString(f1.Area());
                textBox3.Text = Convert.ToString(f1.Perimeter());
            }
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
