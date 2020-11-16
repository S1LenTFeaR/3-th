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
        //Инициализация списка координат движений мыши
        private List<PointF> path = new List<PointF>();
        //Инициализация класа "окружность"
        Circle circ = new Circle();
        //Статус
        bool isCircle = false;
        //Счетчик
        int count = 0;
        //Событие, отвечающее за сохранение коррдинат при движении мыши
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //Отслеживаем координаты в реальном времени
            lcoord.Text = e.Location.ToString();
            //Считываем каждую десятую корординату с зажатой ЛКМ
            if (e.Button == MouseButtons.Left)
            {
                if (count % 10 == 0)
                { 
                    // Добавляем позицию мыши в список точек
                    path.Add(e.Location);
                }
                count++;
            }
        }
        //Событие, которое отвечает за проверку условия окружности
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            double fi = 0;
            double h = 360.0 / (count / 10.0);
            foreach (PointF s in path)
            {
                if (s.X >= circ.FuncX(fi, Convert.ToDouble(numericR.Value)) - Convert.ToDouble(numericQ.Value) && (s.X <= circ.FuncX(fi, Convert.ToDouble(numericR.Value)) + Convert.ToDouble(numericQ.Value))
                    && s.Y >= circ.FuncY(fi, Convert.ToDouble(numericR.Value)) - Convert.ToDouble(numericQ.Value) && (s.Y <= circ.FuncY(fi, Convert.ToDouble(numericR.Value)) + Convert.ToDouble(numericQ.Value)))
                {
                    fi += h;
                    isCircle = true;
                }
                else
                {
                    isCircle = false;
                    break;
                }
            }
            path.Clear();
            count = 0;
            if (isCircle == true)
            {
                label3.Text = "Окружность";
            }
            else
            {
                label3.Text = "Ведите курсор по окружности";
            }
        }
    }
}
