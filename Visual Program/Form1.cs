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

        List<MyVector> vectors = new List<MyVector>();

        private void Form1_Load(object sender, EventArgs e)
        {
            vectors.Add(new MyVector() { x = 2, y = 3, z = 0 });
            vectors.Add(new MyVector() { x = 5, y = 7, z = 2 });
            vectors.Add(new MyVector() { x = 7, y = 5, z = 0 });
            vectors.Add(new MyVector() { x = 8, y = 3, z = 1 });
            vectors.Add(new MyVector() { x = 4, y = 3, z = 0 });
            vectors.Add(new MyVector() { x = 4, y = 9, z = 0 });
            vectors.Add(new MyVector() { x = 12, y = 22, z = 0 });
            vectors.Add(new MyVector() { x = 7, y = 5, z = 2 });
            vectors.Add(new MyVector() { x = 5, y = 7, z = 0 });
            vectors.Add(new MyVector() { x = 3, y = 8, z = 1 });
            vectors.Add(new MyVector() { x = 3, y = 4, z = 0 });
            textBox1.Text = "X\tY\tZ\tМодуль" + Environment.NewLine;
            foreach (MyVector vector in vectors)
            {
                textBox1.Text += vector.x + "\t" + vector.y + "\t" + vector.z + "\t" + vector.moodle(vector) + Environment.NewLine;
            }

        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            var vectorQuery1 = from vector in vectors where vector.z == 0 orderby vector.moodle(vector) descending select vector;
            textBox1.Text = "X\tY\tZ\tМодуль" + Environment.NewLine;
            foreach (MyVector vector in vectorQuery1)
            {
                textBox1.Text += vector.x + "\t" + vector.y + "\t" + vector.z + "\t" + vector.moodle(vector) + Environment.NewLine;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var vectorQuery2 = from vector in vectors group vector by vector.moodle(vector);
            textBox1.Text = "X\tY\tZ\tМодуль" + Environment.NewLine;
            foreach (IGrouping<double, MyVector> g in vectorQuery2)
            {
                //textBox1.Text += g.Key + Environment.NewLine;
                foreach (var t in g)
                    textBox1.Text += t.x + "\t" + t.y + "\t" + t.z + "\t" + t.moodle(t) + Environment.NewLine;
                textBox1.Text += Environment.NewLine;
            }
        }
    }
}
