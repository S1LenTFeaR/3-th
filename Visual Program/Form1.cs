using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        GenericsFIFO<decimal> n = new GenericsFIFO<decimal>();

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string text = "";
                n.Push(numericUpDown2.Value);
                foreach (decimal i in n)
                {
                    text += Convert.ToString(i + " ");
                }
                textBox1.Text = text;
            }
            else if(radioButton2.Checked == true)
            {
                string text = "";
                n.Pop();
                foreach (decimal i in n)
                {
                    text += Convert.ToString(i + " ");
                }
                textBox1.Text = text;
            }
            else
            {
                numericUpDown3.Value = n.Get(Convert.ToInt32(numericUpDown2.Value));
            }
            numericUpDown1.Value = n.Count;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = true;
            label1.Text = "Число";
            numericUpDown3.Enabled = false;
            button1.Text = "Добавить";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            button1.Text = "Изъять";
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = true;
            label1.Text = "Номер";
            numericUpDown3.Enabled = true;
            button1.Text = "Получить";
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
