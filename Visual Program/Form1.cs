using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Visual_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Извлекаем значение статуса
        private void MouseBox_MoveMouseCircularPath(object sender, EventArgs e)
        {
            if (((MouseBox)sender).Status)
            {
                labelStatus.Text = "Окружность";
                labelStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labelStatus.Text = "Не окружность";
                labelStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        //Передаем значение допуска
        private void NumericQ_Validated(object sender, EventArgs e)
        {
            mouseBox.Q = (double)((NumericUpDown)sender).Value;
        }
        //Передаем значение радиуса
        private void NumericR_Validated(object sender, EventArgs e)
        {
            mouseBox.R = (double)((NumericUpDown)sender).Value;
        }
    }
}
