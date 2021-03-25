using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AVM
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

        private void Button1_Click_1(object sender, EventArgs e)
        {
            // Создаём объект ManagementObjectSearcher и передаём ему WMI-запрос,
            // указывающий, что нужно получить всю имеющуюся информацию
            // из WMI-класса с названием Win32_PhysicalMedia
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            try // try-catch здесь используется для того чтобы
            { // можно было отловить внезапно возникшую ошибку
              // Получаем результаты запроса.
                foreach (ManagementObject hdd in searcher.Get())
                { // Если в системе несколько жестких дисков - то мы
                  // получим по одному результату для каждого жесткого диска.
                  // Результат запроса (в формате класса Win32_PhysicalMedia)
                  // содержится в переменной hdd и мы можем обратиться
                  // к его свойствам с помощью квадратных скобок.
                  // Получаем значение свойства SerialNumber
                    object hdd_serial = hdd["SerialNumber"];
                    // если поле SerialNumber для этого устройства не заполнено -
                    // то пропускаем его (в этом случае оно равно null)
                    if (hdd_serial == null) continue;
                    // конвертируем значение в тип String
                    string hdd_serial_string = hdd_serial.ToString();
                    // Метод Trim позволяет удалить лишние пробелы до и после
                    // строки с текстом (серийного номера)
                    hdd_serial_string = hdd_serial_string.Trim();
                    // Выводим серийных номер на экран
                    MessageBox.Show("Серийный номер: " + hdd_serial_string);
                    // break; // Если нам нужно получить информацию только об
                    // одном жестком диске (из одного результата запроса),
                    // то мы можем выйти из цикла после того как
                    // его получили с помощью break.
                }
            }
            catch
            { // Если вдруг в процесс получения результата запроса произошла ошибка -
              // выводим сообщение об ошибке
                MessageBox.Show("Ошибка получения серийного номера HDD.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listView1.Columns[0].Text = "Имя";
            listView1.Columns[1].Text = "Значение";
            listView1.Items.Clear(); // Очищаем список
                                     // Формируем WMI-запрос для получения информации из класса
                                     // написанного в textBox1.Text
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("SELECT * FROM " + textBox1.Text);
            try // try-catch здесь используется для того чтобы
            { // можно было отловить внезапно возникшую ошибку
              // Получаем результаты запроса.
                foreach (ManagementObject queryRes in searcher.Get())
                {
                    // Цикл по свойствам результата запроса
                    foreach (PropertyData property in queryRes.Properties)
                    {
                        // Создаем строчку для отображения в listView1
                        string[] row = new string[2];
                        row[0] = property.Name; // В ячейку 0 записываем имя свойства
                                                // Во вторую ячейку записываем значение свойства
                                                // если значение отсутствует (равно null), то записываем null
                        row[1] =
                        (property.Value != null) ? property.Value.ToString() : "null";
                        // Добавляем в listView1 строку с именем и значением свойства
                        listView1.Items.Add(new ListViewItem(row));
                    }
                    // Для разделения результатов между собой после каждого
                    // результата добавляем пустую строку (разделитель)
                    listView1.Items.Add(new ListViewItem(new string[] { "", "" }));
                }
            }
            catch
            {
                // Если вдруг в процесс получения результата запроса произошла // ошибка - выводим сообщение об ошибке
                // (так же эта ошибка выведена и при других проблемах с WMI).
                MessageBox.Show("Имя класса WMI введёно некорректно!");
                return;
            }
            textBox1.Text = "Введите сюда WMI-класс";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listView1.Columns[0].Text = "Директория";
            listView1.Columns[1].Text = "Путь";
            listView1.Items.Clear(); // Очищаем список
                                     // Формируем WMI-запрос для получения информации из класса
                                     // написанного в textBox1.Text
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("SELECT BootDirectory, TempDirectory FROM Win32_BootConfiguration");
            try // try-catch здесь используется для того чтобы
            { // можно было отловить внезапно возникшую ошибку
              // Получаем результаты запроса.
                foreach (ManagementObject directoryRes in searcher.Get())
                {
                    // Цикл по свойствам результата запроса
                    foreach (PropertyData property in directoryRes.Properties) // Цикл по свойствам
                    {
                        // Создаем строчку для отображения в listView1
                        string[] row = new string[2];
                        row[0] = property.Name; // имя свойства
                        row[1] = property.Value.ToString(); // значение свойства
                                                            // Добавляем в listView1 строку с именем и значением свойства
                        listView1.Items.Add(new ListViewItem(row));
                    }
                    // Для разделения результатов между собой после каждого
                    // результата добавляем пустую строку (разделитель)
                    listView1.Items.Add(new ListViewItem(new string[] { "", "" }));
                }
            }
            catch
            {
                // Если вдруг в процесс получения результата запроса произошла // ошибка - выводим сообщение об ошибке
                // (так же эта ошибка выведена и при других проблемах с WMI).
                MessageBox.Show("Имя класса WMI введёно некорректно!");
                return;
            }
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox1.Text == "Введите сюда WMI-класс")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }
    }
}
