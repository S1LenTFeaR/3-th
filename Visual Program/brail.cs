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
    public partial class brail : UserControl
    {
        //Размер шрифта
        public float size { get; set; }
        //Выводимый текст
        public string text { get; set; }
        //Функция, которая определяет, какие круги закрашивать у выбранной буквы
        public bool[] BoolSign(char sign)
        {
            bool[] BoolPoints = new bool[6];

            if (sign == 'а' || sign == 'А')
            {
                BoolPoints = new bool[] { true, false, false, false, false, false };
            }
            else if (sign == 'б' || sign == 'Б')
            {
                BoolPoints = new bool[] { true, true, false, false, false, false };
            }
            else if (sign == 'в' || sign == 'В')
            {
                BoolPoints = new bool[] { false, true, false, true, true, true };
            }
            else if (sign == 'г' || sign == 'Г')
            {
                BoolPoints = new bool[] { true, true, false, true, true, false };
            }
            else if (sign == 'д' || sign == 'Д')
            {
                BoolPoints = new bool[] { true, false, false, true, true, false };
            }
            else if (sign == 'е' || sign == 'Е')
            {
                BoolPoints = new bool[] { true, false, false, false, true, false };
            }
            else if (sign == 'ё' || sign == 'Ё')
            {
                BoolPoints = new bool[] { true, false, false, false, false, true };
            }
            else if (sign == 'ж' || sign == 'Ж')
            {
                BoolPoints = new bool[] { false, true, false, true, true, false };
            }
            else if (sign == 'з' || sign == 'З')
            {
                BoolPoints = new bool[] { true, false, true, false, true, true };
            }
            else if (sign == 'и' || sign == 'И')
            {
                BoolPoints = new bool[] { false, true, false, true, false, false };
            }
            else if (sign == 'й' || sign == 'Й')
            {
                BoolPoints = new bool[] { true, true, true, true, false, true };
            }
            else if (sign == 'к' || sign == 'К')
            {
                BoolPoints = new bool[] { true, false, true, false, false, false };
            }
            else if (sign == 'л' || sign == 'Л')
            {
                BoolPoints = new bool[] { true, true, true, false, false, false };
            }
            else if (sign == 'м' || sign == 'М')
            {
                BoolPoints = new bool[] { true, false, true, true, false, false };
            }
            else if (sign == 'н' || sign == 'Н')
            {
                BoolPoints = new bool[] { true, false, true, true, true, false };
            }
            else if (sign == 'о' || sign == 'О')
            {
                BoolPoints = new bool[] { true, false, true, false, true, false };
            }
            else if (sign == 'п' || sign == 'П')
            {
                BoolPoints = new bool[] { true, true, true, true, false, false };
            }
            else if (sign == 'р' || sign == 'Р')
            {
                BoolPoints = new bool[] { true, true, true, false, true, false };
            }
            else if (sign == 'с' || sign == 'С')
            {
                BoolPoints = new bool[] { false, true, true, true, false, false };
            }
            else if (sign == 'т' || sign == 'Т')
            {
                BoolPoints = new bool[] { false, true, true, true, true, false };
            }
            else if (sign == 'у' || sign == 'У')
            {
                BoolPoints = new bool[] { true, false, true, false, false, true };
            }
            else if (sign == 'ф' || sign == 'Ф')
            {
                BoolPoints = new bool[] { true, true, false, true, false, false };
            }
            else if (sign == 'х' || sign == 'Х')
            {
                BoolPoints = new bool[] { true, true, false, false, true, false };
            }
            else if (sign == 'ц' || sign == 'Ц')
            {
                BoolPoints = new bool[] { true, false, false, true, false, false };
            }
            else if (sign == 'ч' || sign == 'Ч')
            {
                BoolPoints = new bool[] { true, true, true, true, true, false };
            }
            else if (sign == 'ш' || sign == 'Ш')
            {
                BoolPoints = new bool[] { true, false, false, false, true, true };
            }
            else if (sign == 'щ' || sign == 'Щ')
            {
                BoolPoints = new bool[] { true, false, true, true, false, true };
            }
            else if (sign == 'ъ' || sign == 'Ъ')
            {
                BoolPoints = new bool[] { true, true, true, false, true, true };
            }
            else if (sign == 'ы' || sign == 'Ы')
            {
                BoolPoints = new bool[] { false, true, true, true, false, true };
            }
            else if (sign == 'ь' || sign == 'Ь')
            {
                BoolPoints = new bool[] { false, true, true, true, true, true };
            }
            else if (sign == 'э' || sign == 'Э')
            {
                BoolPoints = new bool[] { false, true, false, true, false, true };
            }
            else if (sign == 'ю' || sign == 'Ю')
            {
                BoolPoints = new bool[] { true, true, false, false, true, true };
            }
            else if (sign == 'я' || sign == 'Я')
            {
                BoolPoints = new bool[] { true, true, false, true, false, true };
            }
            return BoolPoints;
        }
        //Функция для отрисовки буквы
        public void BrailChar(char sign, int NumberInString, int NumberString, Graphics g)
        {
            //Инициализация закрашивающей кисти
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            //Проверяем, какие круги закрашивать
            bool[] BoolPoints = BoolSign(sign);
            //Интервал между кругами
            float interval = size / 5;
            //Счетчик
            int n = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //Если символ пустой, пропускаем букву
                    if (sign == ' ')
                    {
                        
                    }
                    //Круг с закрашиванием
                    else if (BoolPoints[n] == true)
                    {
                        g.DrawEllipse(Pens.Black, i * (size + interval) + 2 * NumberInString * (size + 2 * interval), j * (size + interval) + 3 * NumberString * (size + 2 * interval), size, size);
                        g.FillEllipse(solidBrush, i * (size + interval) + 2 * NumberInString * (size + 2 * interval), j * (size + interval) + 3 * NumberString * (size + 2 * interval), size, size);
                    }
                    //Пустой круг
                    else
                    {
                        g.DrawEllipse(Pens.Black, i * (size + interval) + 2 * NumberInString * (size + 2 * interval), j * (size + interval) + 3 * NumberString * (size + 2 * interval), size, size);
                    }
                    n++;
                }
            }
        }
        //Отрисовка строки
        public void BrailString(string MyString, Graphics g)
        {
            //Интервалл
            float interval = size / 5;
            /*Расстояние по горизонтали
            Область, выделяемая под строку*/
            double range = 0;
            //Счетчики позиций символа и строки
            int NumberInString = 0;
            int NumberString = 0;
            //Отрисовка строки в цикле
            for (int i = 0; i < MyString.Length; i++)
            {
                //Если символ выходит за область, переносим его
                if(range > Width)
                {
                    //Выделяем область под первую букву на текущей строке
                    range = 2 * size + interval;
                    //Осуществлляем переход на следующую строку
                    NumberString++;
                    //Позиция символа в строке зануляется
                    NumberInString = 0;
                    //Отрисовка символа
                    BrailChar(MyString[i], NumberInString, NumberString, g);
                    //Выделяется область под следущую букву в строке
                    range += 2 * size + 4 * interval;
                    //Увеличение номера позиции буквы в строке
                    NumberInString++;
                }
                else
                {
                    //Отрисовка символа
                    BrailChar(MyString[i], NumberInString, NumberString, g);
                    //Выделяется область под следущую букву в строке
                    range += 2 * size + 4 * interval;
                    //Увеличение номера позиции буквы в строке
                    NumberInString++;
                }
                
            }
        }
        //Отрисовка компонента управления
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            BrailString(text, g);
        }
    }
}
