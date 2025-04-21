//Баранов Павел
//Проект JapanCrossword
//Группа K-02-12-OП-2024
//github есть
 
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    public partial class FormGame : Form
    {
        char[,] grdb = null; // сетка нажатия кнопок
        string grdo = ""; // сетка правильного ответа
        public int sz; // размер кнопок
        string gov = ""; // значение горизонтали
        string gog = ""; // значение вертикали
        int sec = 0, min = 0; //таймер
        Color cc = Color.White; // акцентный цвет
        bool isGameLoaded = false; //пока параметры игры не будут заданны, то остальные воиды не смогут работать
        public FormGame(string gametext,int gameSI)
        {
            InitializeComponent();
            //передаем параметры через конструктор формы
            cmbgame.Text = gametext;
            cmbgame.SelectedIndex = gameSI;
        }


        public void FormGame_Load(object sender, EventArgs e)
        {
            //запускаем войды
            change_game(); //выбор уровня
            if (isGameLoaded)
            { 
                grid(); //сетка
                gorizontal(); //горизонталь
                vertical(); //вертикаль
            }
        }
        private void change_game() //задаём параметры
        {
            string pgame = ""; //сюда задаются параметры из вне
            otvet.Enabled = false;
            otvet.BackColor = Color.LightGray;

            if (cmbgame.SelectedIndex == 4)
            {
                //переход на редактор уровней
                FormEditor frme = new FormEditor();
                this.Hide();
                frme.ShowDialog();
                this.Close();
            }
            else
            {
                //подгружаем параметры для игры
                if (cmbgame.SelectedIndex == 3)
                {
                    //открываем файлпикер и используем данные полученные из него
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Level files (*.lvl)|*.lvl|All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //передаем данные из файл пикера
                        string filepath = openFileDialog.FileName;
                        
                        //открываем выбранный файл для чтения
                        FileStream lvl = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                        StreamReader lvlf = new StreamReader(lvl);

                        //присваиваем данные из файла
                        pgame = lvlf.ReadToEnd();
                        cmbgame.Text = Path.GetFileName(filepath);

                        //закрываем
                        lvlf.Close();
                        lvlf.Dispose();
                        lvl.Dispose();
                    }
                    else
                    {
                        //переходим на стартовую форму
                        FormStart frms = new FormStart();
                        this.Hide();
                        frms.ShowDialog();
                        this.Close();
                    }  
                }
                else pgame = (string)Properties.Resources.ResourceManager.GetObject(cmbgame.Text);

                if (pgame == "" || pgame == null)
                {
                    //если что-то пошло не так то не позволяем игре идти далее
                    isGameLoaded = false;
                    return; 
                }

                this.Text = cmbgame.Text;
                string[] game = pgame.Split('\n'); //разбиваем данные из файла на массив строк
                string[] gz = game[0].Split('x'); //разбиваем на 2 значения. Например 13x10 превращаются в 2 int значения
                grdb = new char[int.Parse(gz[0]), int.Parse(gz[1])]; //задаем размеры игровой сетки
                sz = int.Parse(game[1]); //задаем размер клетки
                string[] sc = game[2].Split(','); //вытягиваем акцентный цвет записанный в формате ARGB через запятую
                cc = Color.FromArgb(int.Parse(sc[0]), int.Parse(sc[1]), int.Parse(sc[2]), int.Parse(sc[3])); //присваиваем цвет
                this.Height = 175 + grdb.GetLength(1)*sz; //задаем размер формы по вертикали

                //присваиваем остальные значения
                gov = game[3]; 
                gog = game[4];
                grdo = game[5];
            }
            isGameLoaded = true; //теперь остальные воиды могут выполняться
        }
        public void grid() //создаем игровую сетку
        {
            for (int x = 0; x < grdb.GetLength(0); x++)
                {
                for (int y = 0; y < grdb.GetLength(1); y++)
                {
                    grdb[x, y] = '0'; //заполняем сетку нажатий нулями
                    Button btn = new Button();

                    //настройка стиля
                    btn.Width = sz; btn.Height = sz;
                    btn.Location = new Point(x * sz, y * sz);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.Black;
                    btn.Font = btn.Font = new Font("Microsoft Sans Serif", sz / 3);
                    btn.BackColor = cc;
                    btn.Tag = new Point(x, y); //записываем координаты в Tag
                    pnlpole.Controls.Add(btn); //добаляем на форму

                    //подписываем на события
                    btn.MouseDown += Button_MouseDown;
                    btn.MouseEnter += Button_MouseEnter;
                }
            }
        }

        private void vertical() //вертикаль
        {
            int index = 0; // индекс
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // настройка стиля
                    Label lbl = new Label();
                    lbl.BackColor = ApplyGray(cc, 30);
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz / 3);
                    lbl.FlatStyle = FlatStyle.Flat;
                    
                    //настройка положения
                    lbl.Location = new Point(x * sz, y * sz);

                    //заполнение
                    if (gov != "")
                    {
                        lbl.Text = $"{gov.Substring(index,2)}";
                        if (lbl.Text == "00") 
                            {
                            //если клетка пуста
                                lbl.Text = "";
                                lbl.BackColor = cc;
                            }
                        //если клетка не пуста
                        else lbl.Text = lbl.Text[1].ToString();

                        index += 2; //потому что данные хранятся по 2 символа
                    }
                    pnlv.Controls.Add(lbl); //добавляем вертикаль на панель
                }
            }
        } 

        private void gorizontal() //горизонталь
        {
            int index = 0; //индекс

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    // настройка стиля
                    Label lbl = new Label();
                    lbl.BackColor = ApplyGray(cc, 30);
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz/3);

                    // настройка положения
                    lbl.Location = new Point(x * sz, y * sz);

                    //заполнение
                    if (gog != "")
                    {
                        lbl.Text = $"{gog.Substring(index,2)}";

                        if (lbl.Text == "00")
                        {
                            //если клетка пуста
                            lbl.Text = "";
                            lbl.BackColor = cc;
                        }
                        ////если клетка не пуста
                        else lbl.Text = lbl.Text[1].ToString();
                        index += 2;//потому что данные хранятся по 2 символа
                    }
                    pnlg.Controls.Add(lbl); //добавляем горизонталь на панель
                }
            }
        }
        private void Button_MouseEnter(object sender, EventArgs e) // "крестик" по наводимой клетки
        {
            //объявляем переменные
            Button btn = sender as Button;
            Point pos = (Point)btn.Tag; //вытягиваем позицию из нажатой кнопки
            int x;
            int y;
            foreach (Button btnc in pnlpole.Controls)
            {
                if (btnc.BackColor != Color.Black) // чтобы не закрасить рисунок пользователя
                {
                    //присваивания
                    x = ((Point)btnc.Tag).X;
                    y = ((Point)btnc.Tag).Y;    
                    btnc.BackColor = cc;
                    
                    if (pos.X == x || pos.Y == y) btnc.BackColor = ApplyGray(cc,30); //рисуем крестик
                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e) //обрабатываем взаимодействие с сеткой кнопок
        {
            Button sbtn = (Button)sender; //нажатая кнопка

            //левый клик
            if (e.Button == MouseButtons.Left)
            {
                if (grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] == '0')
                {
                    sbtn.BackColor = Color.Black;
                    sbtn.Text = "";
                    grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '1';
                }
                else
                {
                    sbtn.BackColor = cc;
                    sbtn.Text = "";
                    grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0';
                }

            }

            //правый клик
            else if (sbtn.Text != "X")
            {
                sbtn.Text = "X"; //пометка пользователем ни на что не влияет
                sbtn.BackColor = cc;
                grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0'; //она равна пустой клетке
            }
            else
            {
                sbtn.Text = "";
                sbtn.BackColor = cc;
                grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0';
            }
            string otv = grdo.Trim(); //обрезаем
            string notv = ""; //то что натыкал игрок

            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    notv+= grdb[x, y];
                }
            }
            if (otv == notv) win(); // запускаем победный void
        }

        private void exit_Click(object sender, EventArgs e) //выход в главное меню
        { 
            FormStart frms = new FormStart();
            this.Hide();
            frms.ShowDialog();
            this.Close();
        }

        private void exit_MouseEnter(object sender, EventArgs e) //минианимация для кнопки выхода
        {
            exit.BackgroundImage = Properties.Resources.redexit;
            exit.BackColor = Color.Red;
        }
        private void exit_MouseLeave(object sender, EventArgs e)  //минианимация для кнопки выхода
        {
            exit.BackgroundImage = Properties.Resources.exit;
            exit.BackColor = Color.White;
        }

        private void info_Click(object sender, EventArgs e) //форма с правилами игры
        {
            FormHelp helpform = new FormHelp();
            helpform.Show();
            helpform.Top = this.Top;
            helpform.Left = this.Left + this.Width;
            helpform.Dispose();
        }
         
        private void otvet_Click(object sender, EventArgs e)
        {
            //тут ничего интерсного кроме paintform.Show();
            Form paintform = new Form();
            paintform.Text = "Answer";
            paintform.Icon = Properties.Resources.otvetform;
            paintform.Size = new Size((grdb.GetLength(0)+1)*25-5,(grdb.GetLength(1)+1)*25+18);
            paintform.MaximizeBox = false; paintform.MinimizeBox = false;
            paintform.FormBorderStyle = FormBorderStyle.Fixed3D;
            paintform.Paint += new PaintEventHandler(paint_form);
            paintform.StartPosition = FormStartPosition.CenterScreen;
            paintform.Show();
            paintform.Top = this.Top;
            paintform.Left = this.Left + this.Width;
        }
        private void paint_form(object sender, PaintEventArgs e) //рисуем на форме рисунок ответа
        {
            Graphics g = e.Graphics;
            int x=0, y=0;
            for (int r = 0; r < grdb.GetLength(1); r++)
            {
                for (int c = 0; c < grdb.GetLength(0); c++)
                { 
                    //подгоняем под размер формы
                    x = c * 25;
                    y = r * 25;

                    if (grdo[r*grdb.GetLength(0)+c] == '1') g.FillRectangle(Brushes.Black, x, y, 25, 25); //черный прямоугольник
                    else g.FillRectangle(Brushes.White, x, y, 25, 25); //белый прямоугольник
                }
            }
        }
        private void del(object sender, EventArgs e) //удаление данных текущего поля
        {
            foreach (Button btn in pnlpole.Controls) btn.BackColor = cc; // перекрашиваем

            //очищаем
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    grdb[x, y] = '0';
                }
            }
        }

        private void cmbgame_SelectedIndexChanged(object sender, EventArgs e) //выбор уровня
        {
            if (isGameLoaded)
            {
                clear(); //очистка

                //запускаем войды
                change_game(); //выбор уровня
                grid(); //сетка
                gorizontal(); //горизонталь
                vertical(); //вертикаль
            }
        }

        private Color ApplyGray(Color original, float da) //применение серого на любой входящий цвет
        {
            return Color.FromArgb(
                original.A,
                (int)(original.R * (1 - da / 100) * 0.8 + 211 * 0.2),
                (int)(original.G * (1 - da / 100) * 0.8 + 211 * 0.2),
                (int)(original.B * (1 - da / 100) * 0.8 + 211 * 0.2));
        }


        private void clear() //очистка текущего уровня
        {
            //все очищаем
            time.Stop();
            lblt.Text = "00:00";
            sec = 0;
            min = 0;
            pnlpole.Controls.Clear();
            pnlv.Controls.Clear();
            pnlg.Controls.Clear();
            time.Start();
        }
        private void time_Tick(object sender, EventArgs e) //таймер
        {
            sec++;
            lblt.Text = $"{min:D2}:{sec:D2}"; //присваиваем время
            if (sec >= 60)
            {
                sec = 0;
                min++;
            }
            if (min >= 60) //зачем считать часы?
            {
                time.Stop();
                lblt.Text += "+";
            }

            if (min >= 2) //врубаем подсказку
            {
                otvet.Enabled = true;
                otvet.BackColor = Color.White;
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e) // закрываем игру
        {
            //при нажатиии крестика закрывается все приложение
            Application.Exit(); 
        } 

        private void pnlpole_Leave(object sender, EventArgs e) //убираем крестик когда пользователь не взаимодействует с полем
        {
            foreach (Button btn in pnlpole.Controls) if (btn.BackColor == ApplyGray(cc, 30)) btn.BackColor = cc;
        }

        private void win() //действия при победе
        {
            time.Stop();
            this.Opacity = 0.5;

            FormWin frmw = new FormWin(sec,min);
            frmw.ShowDialog();
            frmw.Dispose();
            
            //все сбрасываем
            this.Opacity = 1;
            lblt.Text = "00:00";
            sec = 0;
            min = 0;
            del(null,null);

            time.Start();
        }
    }
}
