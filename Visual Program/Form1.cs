using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace Visual_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Считываем цвета с файла
            Bitmap bitmap = Read_File();
        }
        List<Color> input = new List<Color>();
        //Объявление очереди
        static ProducerConsumer queue;
        //Чтение изображения
        private Bitmap Read_File()
        {
            Bitmap bitmap = (Bitmap)Image.FromFile("mypix.png");
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    input.Add(pixel);
                }
            }
            return bitmap;
        }
        //Деятельность потребителя
        void ConsumerJob()
        {
            Bitmap bitmap = (Bitmap)Image.FromFile("mypix.png");
            Graphics g = pictureBox1.CreateGraphics();
            My_Color cur_color = new My_Color();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    object o = queue.Consume();
                    cur_color = (My_Color)o;
                    SolidBrush solidBrush = new SolidBrush(Color.FromArgb(cur_color.R, cur_color.G, cur_color.B));
                    g.FillRectangle(solidBrush, x, y, 1, 1);
                }
            }
        }
        //Деятельность производителя
        void ProduceJob()
        {
            Bitmap bitmap = (Bitmap)Image.FromFile("mypix.png");
            double[,] kernel = new double[,]
            {
                { 1, 2, 4, 8, 4, 2, 1 },
                { 2, 4, 8, 16, 8, 4, 2 },
                { 4, 8, 16, 32, 16, 8, 4 },
                { 8, 16, 32, 64, 32, 16, 8 },
                { 4, 8, 16, 32, 16, 8, 4 },
                { 2, 4, 8, 16, 8, 4, 2 },
                { 1, 2, 4, 8, 4, 2, 1 }
            };

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);

            byte[,] R = new byte[bitmap.Width, bitmap.Height];
            byte[,] G = new byte[bitmap.Width, bitmap.Height];
            byte[,] B = new byte[bitmap.Width, bitmap.Height];

            int x = 0, y = 0;
            //Заполнение массивов цветами
            foreach (Color pixel in input)
            {
                if (y < bitmap.Height - 1)
                {
                    R[x, y] = pixel.R;
                    G[x, y] = pixel.G;
                    B[x, y] = pixel.B;
                    y++;
                }
                else
                {
                    y = 0;
                    x++;
                }
            }

            for (x = 0; x < bitmap.Width; x++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    double rSum = 0, gSum = 0, bSum = 0, kSum = 0;

                    for (int i = 0; i < kernelWidth; i++)
                    {
                        for (int j = 0; j < kernelHeight; j++)
                        {
                            int pixelPosX = x + (i - (kernelWidth / 2));
                            int pixelPosY = y + (j - (kernelHeight / 2));
                            if ((pixelPosX < 0) || (pixelPosX >= bitmap.Width) ||
                            (pixelPosY < 0) || (pixelPosY >= bitmap.Height))
                            {
                                continue;
                            }

                            rSum += R[pixelPosX, pixelPosY] * kernel[i, j];
                            gSum += G[pixelPosX, pixelPosY] * kernel[i, j];
                            bSum += B[pixelPosX, pixelPosY] * kernel[i, j];

                            kSum += kernel[i, j];
                        }
                    }

                    if (kSum <= 0) kSum = 1;

                    //Контролируем переполнения переменных
                    rSum /= kSum;
                    if (rSum < 0) rSum = 0;
                    if (rSum > 255) rSum = 255;

                    gSum /= kSum;
                    if (gSum < 0) gSum = 0;
                    if (gSum > 255) gSum = 255;

                    bSum /= kSum;
                    if (bSum < 0) bSum = 0;
                    if (bSum > 255) bSum = 255;

                    My_Color cur_color = new My_Color((byte)rSum, (byte)gSum, (byte)bSum);

                    queue.Produce(cur_color);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Создаем очередь
            queue = new ProducerConsumer();
            new Thread(new ThreadStart(ProduceJob)).Start();
            new Thread(new ThreadStart(ConsumerJob)).Start();
        }
    }

    public class ProducerConsumer
    {
        readonly object listLock = new object();
        Queue<object> queue = new Queue<object>();
        //Разблокировка потребителя производителем
        public void Produce(object o)
        {
            lock (listLock)
            {
                queue.Enqueue(o);        
                Monitor.Pulse(listLock);
            }
        }
        //Блокировка потребителя
        public object Consume()
        {
            lock (listLock)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(listLock);
                }
                return queue.Dequeue();
            }
        }
    }
}