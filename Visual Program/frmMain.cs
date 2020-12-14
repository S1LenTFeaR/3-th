using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Visual_Program
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Read_File();
            In_XML();
        }
        List<ListViewItem> tags = new List<ListViewItem>();
        //Чтение изображения
        private void Read_File()
        {
            var bitmap = (Bitmap)Image.FromFile("RAL_2.gif");
            int k = 1;
            for (var j = 68; j < bitmap.Height; j += 72)
            {
                for (var i = 39; i < bitmap.Width; i += 72)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    My_Color color = new My_Color(k, pixel.R, pixel.G, pixel.B);
                    Add(color);
                    k++;
                }
            }
        }
        //Отрисовка палитры
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            this.Invalidate();
            //Чтение цветов из XML
            My_Colors colors = From_XML();
            Graphics g = e.Graphics;

            float RectWidth = 60.0f;
            float RectHeight = 40.0f;
            float PosX = 0;
            float PosY = 0;
            float interval = (RectHeight + RectWidth) / 6.0f;
            int i = 0;

            foreach (My_Color color in colors.ColorsList)
            {
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(color.R, color.G, color.B));
                g.FillRectangle(solidBrush, PosX, PosY, RectWidth, RectHeight);
                //По 7 цветов в ряд
                if (i == 7)
                {
                    PosY += RectHeight + interval;
                    PosX = 0;
                    i = 0;
                }
                else
                {
                    PosX += RectWidth + interval;
                    i++;
                }
            }
        }
        //Запись в XML
        private void In_XML()
        {
            My_Colors colors = new My_Colors();

            foreach (ListViewItem item in tags)
            {
                if (item.Tag != null)
                {
                    colors.ColorsList.Add((My_Color)item.Tag);
                }
            }

            SerializeXML(colors);
        }
        //Получение информации из XML
        private My_Colors From_XML()
        {
            My_Colors colors = DeserializeXML();

            foreach (My_Color color in colors.ColorsList)
            {
                Add(color);
            }
            return colors;
        }
        //Добавление нового цвета
        private void Add(My_Color color)
        {
            ListViewItem LVI = new ListViewItem(Convert.ToString(color.Number));
            LVI.Tag = color;
            tags.Add(LVI);
        }
        //Сериализация XML
        private void SerializeXML(My_Colors colors)
        {
            XmlSerializer xml = new XmlSerializer(typeof(My_Colors));

            using (FileStream fs = new FileStream("Colors.xml", FileMode.Create))
            {
                xml.Serialize(fs, colors);
            }
        }
        //Десериализация XML
        private My_Colors DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(My_Colors));

            using (FileStream fs = new FileStream("Colors.xml", FileMode.Open))
            {
                return (My_Colors)xml.Deserialize(fs);
            }
        }
    }
}
