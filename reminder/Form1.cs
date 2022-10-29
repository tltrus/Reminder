using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace reminder
{
    public partial class Form1 : Form
    {
        private Point last;

        private int screenWidth;

        // 
        private double stepOpacity;     // Шаг прозрачности
        private int actX;               // Координата Х положения формы
        private int actY;               // Координата Y положения формы

        Form formAbout;

        public Form1()
        {

            InitializeComponent();

            notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;

            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            screenWidth = resolution.Width;
            //this.Width = 303;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainFormShow();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Normal)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }

        private void MainFormShow()
        {
            if (WindowState != FormWindowState.Normal)
            {
                // делаем нашу иконку скрытой
                notifyIcon1.Visible = false;
                // возвращаем отображение окна в панели
                this.ShowInTaskbar = true;
                //разворачиваем окно
                WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuFormShow_Click(object sender, EventArgs e)
        {
            MainFormShow();
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point cur = MousePosition;
            this.Opacity = 1;
            timerOpacity.Stop();
            timerHide.Stop();

            // Сдвиг формы влево (выползание формы) при наведении курсора
            //if (formRightHide == true && cur.X < (screenWidth - 20))
            //{
            //    formRightHide = false;
            //    Point loc = new Point(Location.X - 303 + FormAnimation.rightHidewidth, Location.Y);
            //    Location = loc;
            //}
            Location = FormAnimation.MoveFormToLeft(cur, screenWidth, Location);

            // Перетаскивание формы левой кнопкой мыши
            if (e.Button == MouseButtons.Left)
            {
                int dx = cur.X - last.X;
                int dy = cur.Y - last.Y;
                Point loc = new Point(Location.X + dx, Location.Y + dy);
                Location = loc;
                last = cur;
            }
        }

        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            // Плавная прозрачность при отводе мышки с формы
            stepOpacity = 1;
            timerOpacity.Start();

            // Прячем форму за правый край
            if (toolStripMenuRightHide.Checked)
            {
                if (toolStripMenuAnime.Checked)
                {
                    actX = Location.X;
                    actY = Location.Y;
                    timerHide.Start();
                } else
                {
                    Location = FormAnimation.MoveFormToRight(screenWidth, Location);
                }
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // чтение из файла
            using (FileStream fstream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "reminderlist.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                richTextBox1.AppendText(textFromFile);
            }


            // загружаем данные из файла program.xml 
            using (Stream stream = new FileStream("program.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(iniSettings));

                // в тут же созданную копию класса iniSettings под именем iniSet
                iniSettings iniSet = (iniSettings)serializer.Deserialize(stream);

                // и устанавливаем прочитанные координаты окну
                this.Location = new Point(iniSet.X_pos, iniSet.Y_pos);

                if (iniSet.TopMost == 1)
                {
                    toolStripMenuTopMost.Checked = true;
                    this.TopMost = true;
                }

                if (iniSet.RightHide == 1)
                {
                    toolStripMenuRightHide.Checked = true;
                    FormAnimation.formRightHide = true;
                    if (iniSet.Anime == 1) toolStripMenuAnime.Checked = true;
                }
                else toolStripMenuAnime.Enabled = false;

                //if (iniSet.Autorun == 1) toolStripMenuAutorun.Checked = true;
                toolStripMenuAutorun.Enabled = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLinesToFile();

            // создаём копию класса iniSettings с именем iniSet
            iniSettings iniSet = new iniSettings();

            // записываем в переменные класса текущие координаты верхнего левого угла окна
            if (WindowState == FormWindowState.Normal)
            {
                iniSet.X_pos = Location.X;
                iniSet.Y_pos = Location.Y;
            }
            else
            {
                iniSet.X_pos = 100;
                iniSet.Y_pos = 100;
            }

            iniSet.TopMost = (toolStripMenuTopMost.Checked) ? 1 : 0;
            iniSet.RightHide = (toolStripMenuRightHide.Checked) ? 1 : 0;
            iniSet.Anime = (toolStripMenuAnime.Checked) ? 1 : 0;
            iniSet.Autorun = (toolStripMenuAutorun.Checked) ? 1 : 0;

            // выкидываем класс iniSet целиком в файл program.xml
            using (Stream writer = new FileStream("program.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(iniSettings));
                serializer.Serialize(writer, iniSet);
            }
        }

        private void toolStripMenuTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripMenuTopMost.Checked) this.TopMost = true;
            else this.TopMost = false;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Activate();
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    MainFormShow();
                }
            }
        }

        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            // Плавная прозрачность при отводе мышки с формы
            if (stepOpacity > 0.5)
            {
                this.Opacity = stepOpacity;
                stepOpacity -= 0.05;
            }
            else if (stepOpacity == 0.5) timerOpacity.Stop();
        }

        private void timerHide_Tick(object sender, EventArgs e)
        {
            int targetX = screenWidth - FormAnimation.rightHidewidth;
            // Прячем форму за правый край
            if (actX < targetX)
            {
                // положение Формы
                FormAnimation.hideFormPos = new Point(actX, actY);
                Location = FormAnimation.hideFormPos;
                actX += 4;
            }
            else if (actX >= targetX)
            {
                timerHide.Stop();
                FormAnimation.formRightHide = true;
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        // Автозагрузка
        private void toolStripMenuAutorun_CheckedChanged(object sender, EventArgs e)
        {
            //if (toolStripMenuAutorun.Checked)
            //{
            //    // ткрываем нужную ветку в реестре   
            //    // @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"  
            //    var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);

            //    // добавляем первый параметр - название ключа  
            //    // Второй параметр - это путь к исполняемому файлу нашей программы.  
            //    key.SetValue("reminder-rus", Application.ExecutablePath);
            //    key.Close();
            //}
            //else
            //{
            //    var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
            //    key.DeleteValue("reminder-rus");
            //}
        }

        public void SaveLinesToFile()
        {
            // запись в файл
            using (FileStream fstream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "reminderlist.txt", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(richTextBox1.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }

        private void toolStripMenuRightHide_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripMenuRightHide.Checked) toolStripMenuAnime.Enabled = true;
            else
            {
                // Сбрасываем галочку с Анимации, если отключается режим Скрытия окна справа
                toolStripMenuAnime.Enabled = false;
                toolStripMenuAnime.Checked = false;
            }

        }

        private void toolStripMenuAbout_Click(object sender, EventArgs e)
        {
            //Получаем координаты курсора
            int CursorX = Cursor.Position.X;
            int CursorY = Cursor.Position.Y;

            formAbout = new FormAbout();
            //Определяем координиаты диалогового окна "О программе..."
            formAbout.Left = CursorX - formAbout.Width - 10;
            formAbout.Top = CursorY - formAbout.Height - 10;
            //Выводим окно на экран
            formAbout.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    // вот этот самый класс, который мы будем сохранять
    public class iniSettings // имя выбрано просто для читаемости кода впоследствии
    {
        public int X_pos; // это собственно для хранения X верхнего левого угла окна
        public int Y_pos; // ну а это, соответственно Y
        public int TopMost;
        public int RightHide;
        public int Anime;
        public int Autorun;
    }

}
