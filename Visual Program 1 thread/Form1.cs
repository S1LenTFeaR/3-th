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
            Bitmap bitmap = Read_File();
        }
        List<Color> input = new List<Color>();
        List<My_Color> output = new List<My_Color>();

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        void Drawing(Bitmap bitmap, Graphics g)
        {
            int x = 0, y = 0;
            foreach (My_Color pixel in output)
            {
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(pixel.R, pixel.G, pixel.B));
                g.FillRectangle(solidBrush, x, y, 1, 1);
                if (y < bitmap.Height - 1)
                {
                    y++;
                }
                else
                {
                    x++;
                    y = 0;
                }
            }
        }

        void Convert(Bitmap bitmap)
        {
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
            //Производим вычисления
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

                    output.Add(new My_Color() { R = (byte)rSum, G = (byte)gSum, B = (byte)bSum });
                }
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile("mypix.png");
            Convert(bitmap);
            Graphics g = pictureBox1.CreateGraphics();
            Drawing(bitmap, g);
        }
    }

}
