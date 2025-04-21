using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{ 
    public partial class FormEditor : Form
    {
        char[,] grdb = null; // сетка кнопок
        public int sz; // размер кнопок
        string gov = ""; // значение горизонтали
        string gog = ""; // значение вертикали
        string level = ""; //вся инфа о уровне
        int vl = 0; //временное значение числа в клетке
        Color cc = Color.White;

        public FormEditor()
        {
            InitializeComponent();
        }

        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //при нажатиии крестика закрывается все приложение
            Application.Exit();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            //выход в меню
            FormStart frm = new FormStart();
            this.Hide();
            frm.ShowDialog();
            this.Close(); 
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            //запускаем воиды
            change_game(); //задаем параметры
            grid(); //рисуем сетку
            gorizontal(); //рисуем горизонталь
            vertical(); //рисуем вертикаль
        }

        private void change_game() //задаём параметры
        {
            lblgame.Text = txtname.Text; //дублируем текст
            cc = piccolor.BackColor; //задаем выбранный пользователем цвет
            sz = (int)numb.Value;

            //преобразовываем grdb
            if (grdb == null) grdb = new char[(int)numx.Value, (int)numy.Value];
            else grdb=transform(grdb);
        }

        private char[,] transform(char[,] matrix)
        {
            char[,] grdc = new char[(int)numx.Value, (int)numy.Value]; //массив по новым размерам

            // Копируем данные из исходного массива в новый
            for (int i = 0; i < Math.Min(matrix.GetLength(0), grdc.GetLength(0)); i++)
            {
                for (int j = 0; j < Math.Min(matrix.GetLength(1), grdc.GetLength(1)); j++)
                {
                    grdc[i, j] = matrix[i, j];
                }
            }
            return grdc;
        }

        public void grid() //создаем игровую сетку
        {
            for (int x = 0; x < grdb.GetLength(0); x++)
            {
                for (int y = 0; y < grdb.GetLength(1); y++)
                {
                    Button btn = new Button();

                    //перекрашиваем по grdb
                    if (grdb != null && grdb[x, y] == '1') btn.BackColor = Color.Black;
                    else btn.BackColor = cc;
                    if (grdb[x, y] == '\0') grdb[x, y] = '0';

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
        private void Button_MouseEnter(object sender, EventArgs e) // "крестик" по наводимой клетки
        {
            //объявляем переменные
            Button btn = sender as Button;
            Point pos = (Point)(btn.Tag);
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

                    if (pos.X == x || pos.Y == y) btnc.BackColor = ApplyGray(cc, 30); //рисуем крестик
                }
            }
        }
        private void Button_MouseDown(object sender, MouseEventArgs e) //обрабатываем взаимодействие с сеткой кнопок
        {
            Button sbtn = (Button)sender; //нажатая кнопка
            if (grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] == '0')
            {
                //добавляем нажатие кнопки в массив
                sbtn.BackColor = Color.Black;
                grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '1';
            }
            else
            {
                //стираем нажатие кнопки из массива
                sbtn.BackColor = cc;
                grdb[((Point)sbtn.Tag).X, ((Point)sbtn.Tag).Y] = '0';

            }
        }
        private void gorizontal() //горизонталь
        {
            int index = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    // настройка стиля
                    Label lbl = new Label(); 
                    if (gog == "") lbl.BackColor = cc;
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz / 3);

                    lbl.Tag = new Point(x, y); //записываем координаты в Tag

                    lbl.Location = new Point(x * sz, y * sz); // настройка положения

                    if (gog != "" && index + 1 < gog.Length)
                    {
                        lbl.Text = $"{gog.Substring(index,2)}";

                        if (lbl.Text == "00")
                        {
                            //пустая клетка
                            lbl.Text = "";
                            lbl.BackColor = cc;
                        }
                        else
                        { 
                            //заполняем клетку
                            lbl.Text = lbl.Text[1].ToString(); 
                            lbl.BackColor = ApplyGray(cc,30);
                        }
                        index += 2;//потому что данные хранятся по 2 символа
                    }

                    pnlg.Controls.Add(lbl); //добавляем горизонталь на панель
                    lbl.MouseDown += lblg_Click; //подписываем на событие
                }
            }
            
        }
        private void vertical() //вертикаль
        {
            int index = 0;
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // настройка стиля
                    Label lbl = new Label();
                    if (gov == "") lbl.BackColor = cc;
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz / 3);
                    lbl.Tag = new Point(x, y); //записываем координаты в Tag

                    //настройка положения
                    lbl.Location = new Point(x * sz, y * sz);

                    if (gov != "" && index + 1 < gov.Length)
                    {
                        lbl.Text = $"{gov.Substring(index,2)}";

                        if (lbl.Text == "00")
                        {
                            //пустая клетка
                            lbl.Text = "";
                            lbl.BackColor = cc;
                        }
                        else
                        {
                            //заполняем клетку
                            lbl.Text = lbl.Text[1].ToString(); 
                            lbl.BackColor = ApplyGray(cc,30);
                        }

                        index += 2;//потому что данные хранятся по 2 символа
                    }

                    pnlv.Controls.Add(lbl); //добавляем вертикаль на панель
                    lbl.MouseDown += lblv_Click; //подписываем на событие
                }
            }
        }
        private void lblv_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender; //нажатая label
            vl = 0;

            if (lbl.Text != "") vl = int.Parse(lbl.Text); //заталкиваем текст из label
            if (vl >= grdb.GetLength(0))
            {
                //очищаем клетку  
                vl = 0;
                lbl.BackColor = cc;
                lbl.Text = "";
            }
            else
            {
                //заполняем клетку
                vl++;
                lbl.Text = vl.ToString();
                lbl.BackColor = ApplyGray(cc, 30);
            }

            gov = ""; //обнуляем


            //алгоритм превращения вертикали в gov
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < 4; x++)
                { 
                    foreach (Label lblc in pnlv.Controls) if (((Point)lblc.Tag).X == x && ((Point)lblc.Tag).Y == y) lbl = lblc; //находим lbl 
                        if (lbl.Text != "") gov += $"{int.Parse(lbl.Text):D2}";
                        else gov += "00";
                }
            }
        }

        private void lblg_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender; //нажатая label
            vl = 0;

            if (lbl.Text != "") vl = int.Parse(lbl.Text); //заталкиваем текст из label
            if (vl >= grdb.GetLength(1))
            {
                //очищаем клетку
                vl = 0;
                lbl.Text = "";
                lbl.BackColor = cc;

            }
            else 
            {
                //заполняем клетку
                vl++;
                lbl.Text = vl.ToString();
                lbl.BackColor = ApplyGray(cc, 30);
               
            } 

            gog = ""; //обнуляем

            //алгоритм превращения горизонтали в gog
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    foreach (Label lblc in pnlg.Controls) if (((Point)lblc.Tag).X == x && ((Point)lblc.Tag).Y == y) lbl = lblc; //находим lbl 
                    if (lbl.Text != "") gog += $"{int.Parse(lbl.Text):D2}";
                    else gog += "00";
                }
            }
        }

        private Color ApplyGray(Color original, float da) //применяем gray на любой входной цвет
        {
            return Color.FromArgb(
                original.A,
                (int)(original.R * (1 - da / 100) * 0.8 + 211 * 0.2),
                (int)(original.G * (1 - da / 100) * 0.8 + 211 * 0.2),
                (int)(original.B * (1 - da / 100) * 0.8 + 211 * 0.2));
        }

        private void buttonApply_Click(object sender, EventArgs e) //технически просто все перезапускаем
        {
            clear();
            change_game();
            grid();
            gorizontal();
            vertical();
        }
        
        private void clear() //очистка
        {
            pnlpole.Controls.Clear();
            pnlv.Controls.Clear();
            pnlg.Controls.Clear();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (Button btn in pnlpole.Controls) btn.BackColor = cc; // перекрашиваем
            foreach (Label lbl in pnlv.Controls)
            {
                lbl.BackColor = cc; // перекрашиваем
                lbl.Text = ""; //очищаем
            }

            foreach (Label lbl in pnlg.Controls)
            {
                lbl.BackColor = cc; // перекрашиваем
                lbl.Text = ""; //очищаем
            }

            //очищаем
            gov = "";
            gog = "";

            //очищаем поле
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    grdb[x, y] = '0';
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e) //экспорт
        {
            string notv = ""; //то что натыкал юзер
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    notv += grdb[x, y]; //заполняем
                }
            }

            //проверки
            if (notv.Contains("1"))
            {
                if (gov != "")
                { 
                    if (gog != "")
                    {
                        //заталкиваем всю созданную инфу в level
                        level = $"{numx.Value}x{numy.Value}\n";
                        level += $"{numb.Value}\n";
                        level += $"{cc.A},{cc.R},{cc.G},{cc.B}\n";
                        level += $"{gov}\n{gog}\n";
                        level += $"{notv}";

                        //открываем openfiledialog
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Level files (*.lvl)|*.lvl|All files (*.*)|*.*";
                        saveFileDialog.FileName = $"{lblgame.Text}.lvl";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //сохраняем
                            string filepath = saveFileDialog.FileName;
                            FileStream lvl = new FileStream(filepath, FileMode.Create);
                            StreamWriter lvlf = new StreamWriter(lvl);
                            lvlf.WriteLine(level);

                            //закрываем
                            lvlf.Close();
                            lvlf.Dispose();
                            lvl.Dispose();
                        }
                        
                     }
                     else MessageBox.Show("Horizontal field is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Vertical field is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Game field is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
         
        private void piccolor_Click(object sender, EventArgs e) //цвет который задает пользователь
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                piccolor.BackColor = CD.Color;
            }
        }

        private void pnlpole_Leave(object sender, EventArgs e) //убираем крестик когда пользователь не взаимодействует с полем
        {
            foreach (Button btn in pnlpole.Controls) if (btn.BackColor == ApplyGray(cc, 30)) btn.BackColor = cc;
        }
    }
}
