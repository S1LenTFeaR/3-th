using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Program
{
    public partial class MouseBox : UserControl
    {
        public event EventHandler MoveMouseCircularPath;
        //Радиус
        public double R;
        //Допуск
        public double Q;
        //Статус
        private bool isCircle = false;
        public bool Status
        {
            get
            {
                return isCircle;
            }
        }
        //Инициализация списка координат движений мыши
        private List<PointF> path = new List<PointF>();
        //Инициализация класса "окружность"
        Circle circ = new Circle();
        public MouseBox()
        {
            InitializeComponent();
        }
        //Проверка на пустоту списка делегатов подписанных на это событие
        protected virtual void OnMoveMouseCircularPath(EventArgs e)
        {
            if (MoveMouseCircularPath != null) MoveMouseCircularPath(this, e);
        }
        int count = 0;
        //Событие движения мыши
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
        //Событие отпускания ЛКМ
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            double fi = 0;
            double h = 360.0 / (count / 10.0);
            foreach (PointF s in path)
            {
                if ((s.X >= circ.FuncX(fi, R) - Q) && (s.X <= circ.FuncX(fi, R) + Q)
                    && (s.Y >= circ.FuncY(fi, R) - Q) && (s.Y <= circ.FuncY(fi, R) + Q)
                    && count > 20)
                {
                    isCircle = true;
                    this.OnMoveMouseCircularPath(EventArgs.Empty);
                    fi += h;
                }
                else
                {
                    isCircle = false;
                    this.OnMoveMouseCircularPath(EventArgs.Empty);
                    break;
                }
            }
            path.Clear();
            count = 0;
        }
    }
}
