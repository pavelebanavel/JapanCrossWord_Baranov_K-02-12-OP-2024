//Баранов Павел
//Проект JapanCrossword
//Группа K-02-12-OП-2024

using System;
using System.Diagnostics;
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
        bool isGameLoaded = false;
        public FormGame(string gametext,int gameSI)
        {
            InitializeComponent();
            cmbgame.Text = gametext;
            cmbgame.SelectedIndex = gameSI;
        }


        public void FormGame_Load(object sender, EventArgs e)
        {
            //запускаем войды
            Console.WriteLine("load game1!");
            change_game(); //выбор уровня
            Console.WriteLine("load game2!");
            grid(); //сетка
            Console.WriteLine("load game3!");
            gorizontal(); //горизонталь
            Console.WriteLine("load game4!");
            vertical(); //вертикаль
        }
        private void change_game() //задаём параметры
        {
            Console.WriteLine("change game!");
            string pgame = "";

            if (cmbgame.SelectedIndex == 4)
            {
                //открываем форму для редактирования уровней
                FormEditor frme = new FormEditor();
                this.Hide();
                frme.ShowDialog();
                frme.Dispose();
            }
            else
            {
                //подгружаем параметры для игры
                if (cmbgame.SelectedIndex == 3)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog(); // диалог
                    openFileDialog.Filter = "Level files (*.lvl)|*.lvl|All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = openFileDialog.FileName;
                        FileStream lvl = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                        StreamReader lvlf = new StreamReader(lvl);
                        pgame = lvlf.ReadToEnd();
                        cmbgame.Text = Path.GetFileName(filepath);
                        lvlf.Close();
                        lvlf.Dispose();
                        lvl.Dispose();
                    }
                    else
                    {
                        FormStart frms = new FormStart();
                        this.Hide();
                        frms.ShowDialog();
                        frms.Dispose();
                    } 
                }
                else pgame = (string)Properties.Resources.ResourceManager.GetObject(cmbgame.Text);
                    this.Text = cmbgame.Text;
                    string[] game = pgame.Split('\n');
                    string[] gz = game[0].Split('x');
                    grdb = new char[int.Parse(gz[0]), int.Parse(gz[1])];
                    sz = int.Parse(game[1]);
                    gov = game[2];
                    gog = game[3];
                    grdo = game[4];
            }
            isGameLoaded = true;
        }
        public void grid() //создаем игровую сетку
        {
            for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    for (int y = 0; y < grdb.GetLength(1); y++)
                    {
                        grdb[x, y] = '0';
                        Button btn = new Button();

                        //настройка стиля
                        btn.Width = sz; btn.Height = sz;
                        btn.Location = new Point(x * sz, y * sz);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.ForeColor = Color.Black;

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
            string gv = ""; //переменная отвечает за заполнение вертикали
            int index = 0; // индекс

            if (grdb.GetLength(1) <= (gov.Length / 8) + 1) gv = gov;
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // настройка стиля
                    Label lbl = new Label();
                    lbl.BackColor = Color.LightGray;
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz / 3);
                    lbl.FlatStyle = FlatStyle.Flat;
                    
                    //настройка положения
                    lbl.Location = new Point(x * sz, y * sz);

                    //заполнение
                    if (gv != "")
                    {
                        lbl.Text = $"{gv[index]}{gv[index + 1]}";

                        if (lbl.Text == "00") 
                            {
                                lbl.Text = "";
                                lbl.BackColor = Color.White;
                            }
                        if (lbl.Text != "" && lbl.Text[0] == '0') lbl.Text = lbl.Text[1].ToString();

                        index += 2; //потому что данные хранятся по 2 символа
                    }
                    pnlv.Controls.Add(lbl); //добавляем вертикаль на панель
                }
            }
        }

        private void gorizontal() //горизонталь
        {
            string gg = ""; //переменная отвечает за заполнение горизонтали
            int index = 0; //индекс

            if (grdb.GetLength(0) <= (gog.Length / 6) + 1) gg = gog;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    // настройка стиля
                    Label lbl = new Label();
                    lbl.BackColor = Color.LightGray;
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz/3);

                    // настройка положения
                    lbl.Location = new Point(x * sz, y * sz);

                    //заполнение
                    if (gg != "")
                    {
                        lbl.Text = $"{gg[index]}{gg[index + 1]}";

                        if (lbl.Text == "00")
                        {
                            lbl.Text = "";
                            lbl.BackColor = Color.White;
                        }
                        if (lbl.Text != "" && lbl.Text[0] == '0') lbl.Text = lbl.Text[1].ToString();
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
            Point pos = (Point)(btn.Tag);
            int x;
            int y;
            foreach (Button btnc in pnlpole.Controls)
            {
                if (btnc.BackColor != Color.Black && btnc.BackColor != Color.Red) // чтобы не закрасить рисунок пользователя
                {
                    //присваивания
                    x = ((Point)btnc.Tag).X;
                    y = ((Point)btnc.Tag).Y;
                    btnc.BackColor = Color.White;
                    
                    if (pos.X == x || pos.Y == y) btnc.BackColor = Color.LightGray; //рисуем крестик
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
                    grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '1';
                }
                else
                {
                    sbtn.BackColor = Color.White;
                    grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0';
                }

            }
            //правый клик
            else if (sbtn.BackColor != Color.Red)
            {
                sbtn.BackColor = Color.Red;
                grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0';
            }
            else
            {
                sbtn.BackColor = Color.White;
                grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0';
            }
            string otv = grdo.Trim();
            string notv = "";

            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    notv+= grdb[x, y];
                }
            }
            if (otv == notv) win(); // запускаем победный void
        }

        private void exit_Click(object sender, EventArgs e)
        { 
            FormStart frms = new FormStart();
            this.Hide();
            frms.ShowDialog();
            frms.Dispose();
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackgroundImage = Properties.Resources.redexit;
            exit.BackColor = Color.Red;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackgroundImage = Properties.Resources.exit;
            exit.BackColor = Color.White;
        }

        private void info_Click(object sender, EventArgs e)
        {
            Form helpform = new Form();
            helpform.Text = "Help";
            helpform.Icon = Properties.Resources.inform;
            helpform.Size = new Size(200, 200);
            helpform.MaximizeBox = false; helpform.MinimizeBox = false;
            helpform.FormBorderStyle = FormBorderStyle.Fixed3D;
            PictureBox pichelp = new PictureBox();
            pichelp.SizeMode = PictureBoxSizeMode.StretchImage;
            pichelp.Image = Properties.Resources.information;
            pichelp.Size = new Size(helpform.Width - 15, helpform.Height - 35);
            helpform.Controls.Add(pichelp);
            helpform.Show();
            helpform.Top = this.Top;
            helpform.Left = this.Left + this.Width;
        }

        private void otvet_Click(object sender, EventArgs e)
        {
            Form paintform = new Form();
            paintform.Text = "Answer";
            paintform.Icon = Properties.Resources.otvetform;
            paintform.Size = new Size((grdb.GetLength(0)+1)*25-5,(grdb.GetLength(1)+1)*25+18);
            paintform.MaximizeBox = false; paintform.MinimizeBox = false;
            paintform.FormBorderStyle = FormBorderStyle.Fixed3D;
            paintform.Paint += new PaintEventHandler(paint_form);
            paintform.Show();
            paintform.Top = this.Top;
            paintform.Left = this.Left + this.Width;
        }
        private void paint_form(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int cz = 25;
            string grds = grdo;
            char[,] grdf = new char[grdb.GetLength(0), grdb.GetLength(1)];
            int ct = 0;
            for (int r = 0; r < grdb.GetLength(1); r++)
            {
                for (int c = 0; c < grdb.GetLength(0); c++)
                {
                    int x = c * cz;
                    int y = r * cz;
                        if (grds[ct] == '1') g.FillRectangle(Brushes.Black, x, y, cz, cz);
                        else g.FillRectangle(Brushes.White, x, y, cz, cz);
                    ct++;
                }
            }
        }
        private void del(object sender, EventArgs e) //удаление данных текущего поля
        {
            time.Stop();
            lblt.Text = "00:00";
            sec = 0;
            min = 0;
            foreach (Button btn in pnlpole.Controls) btn.BackColor = Color.White; // перекрашиваем

            //очищаем
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    grdb[x, y] = '0';
                }
            }
            time.Start();
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
        private void clear() //очистка текущего уровня
        {
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
            lblt.Text = $"{min:D2}:{sec:D2}";
            if (sec >= 60)
            {
                sec = 0;
                min++;
            }
            if (min >= 60)
            {
                time.Stop();
                lblt.Text += "+";
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        } // закрываем игру

        private void win() //действия при победе
        {
            MessageBox.Show("Вы победили");
            del(null,null);
        }
    }
}
