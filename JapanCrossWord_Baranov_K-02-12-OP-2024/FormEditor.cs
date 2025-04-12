using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    public partial class FormEditor : Form
    {
        char[,] grdb = null; // сетка кнопок
        public int sz; // размер кнопок
        string gov = ""; // значение горизонтали
        string gog = ""; // значение вертикали
        string level = "";

        public FormEditor()
        {
            InitializeComponent();
        }

        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            FormStart frm = new FormStart();
            this.Hide();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            change_game();
            grid();
            gorizontal();
            vertical();
        }

        private void change_game() //задаём параметры
        {
            lblgame.Text = txtname.Text;

            if (grdb != null)
            {
                if (grdb.GetLength(0) != (int)numx.Value) gog = "";
                if (grdb.GetLength(1) != (int)numy.Value) gov = "";
            }
            if (sz != numb.Value) sz = (int)numb.Value;
            if (grdb == null) grdb = new char[(int)numx.Value, (int)numy.Value];
            else grdb=transform(grdb);
        }

        private char[,] transform(char[,] matrix)
        {
            char[,] grdc = new char[(int)numx.Value, (int)numy.Value];

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

                    if (grdb != null && grdb[x, y] == '1') btn.BackColor = Color.Black;
                    else btn.BackColor = Color.White;
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
        private void gorizontal() //горизонталь
        {
            int index = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    // настройка стиля
                    Label lbl = new Label();
                    if (gog == "") lbl.BackColor = Color.White;
                    lbl.Width = sz; lbl.Height = sz;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", sz / 3);

                    lbl.Tag = new Point(x, y); //записываем координаты в Tag

                    // настройка положения
                    lbl.Location = new Point(x * sz, y * sz);

                    if (gog != "" && index + 1 < gog.Length)
                    {
                        lbl.Text = $"{gog[index]}{gog[index + 1]}";

                        if (lbl.Text == "00")
                        {
                            lbl.Text = "";
                            lbl.BackColor = Color.White;
                        }
                        if (lbl.Text != "" && lbl.Text[0] == '0') lbl.Text = lbl.Text[1].ToString();
                        index += 2;//потому что данные хранятся по 2 символа
                    }

                    pnlg.Controls.Add(lbl); //добавляем горизонталь на панель
                    lbl.MouseDown += lbl_Click;
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
                    if (gov == "") lbl.BackColor = Color.White;
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
                        lbl.Text = $"{gov[index]}{gov[index + 1]}";

                        if (lbl.Text == "00")
                        {
                            lbl.Text = "";
                            lbl.BackColor = Color.White;
                        }
                        if (lbl.Text != "" && lbl.Text[0] == '0') lbl.Text = lbl.Text[1].ToString();
                        index += 2;//потому что данные хранятся по 2 символа
                    }

                    pnlv.Controls.Add(lbl); //добавляем вертикаль на панель
                    lbl.MouseDown += lbl_Click;
                }
            }
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            int vl = 0;
            Point lbll = new Point(0, 0);
            if (lbl.Text != "") vl = int.Parse(lbl.Text);
            if (lbl.Parent.Name == "pnlv")
            {
                if (vl >= grdb.GetLength(0)) vl = 0;
                else vl++;
            }
            else
            {
                if (vl >= grdb.GetLength(1)) vl = 0; 
                else vl++;
            }
            if (vl != 0)
            {
                lbl.Text = vl.ToString();
                lbl.BackColor = Color.LightGray;
            }
            else
            {
                lbl.Text = "";
                lbl.BackColor = Color.White;
            }
            gog = "";
            gov = "";
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    lbll.X = x;
                    lbll.Y = y;
                    foreach (Label lblc in pnlv.Controls)
                    {
                        if (((Point)lblc.Tag).X == lbll.X && ((Point)lblc.Tag).Y == lbll.Y) lbl = lblc;
                    }
                    if (lbl.Parent.Name == "pnlv")
                    {
                        if (lbll.X == ((Point)lbl.Tag).X && lbll.Y == ((Point)lbl.Tag).Y)
                        {
                            if (lbl.Text != "") gov += $"{int.Parse(lbl.Text):D2}";
                            else gov += "00";
                        }
                    }
                }
            }

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    lbll.X = x;
                    lbll.Y = y;
                    foreach (Label lblc in pnlg.Controls)
                    {
                        if (((Point)lblc.Tag).X == lbll.X && ((Point)lblc.Tag).Y == lbll.Y) lbl = lblc;
                    }
                    if (lbl.Parent.Name == "pnlg")
                    {
                        if (lbll.X == ((Point)lbl.Tag).X && lbll.Y == ((Point)lbl.Tag).Y)
                        {
                            if (lbl.Text != "") gog += $"{int.Parse(lbl.Text):D2}";
                            else gog += "00";
                        }
                    }
                }
            }
        }
        

        private void buttonApply_Click(object sender, EventArgs e)
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
            foreach (Button btn in pnlpole.Controls) btn.BackColor = Color.White; // перекрашиваем

            //очищаем
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    grdb[x, y] = '0';
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string notv = "";
            for (int y = 0; y < grdb.GetLength(1); y++)
            {
                for (int x = 0; x < grdb.GetLength(0); x++)
                {
                    notv += grdb[x, y];
                }
            }
            if (notv.Contains("1"))
            {
                if (gov != "")
                {
                    if (gog != "")
                    {
                        Console.WriteLine(notv);
                        level = $"{numx.Value}x{numy.Value}\n";
                        level += $"{numb.Value}\n";
                        level += $"{gov}\n{gog}\n";
                        level += $"{notv}";

                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Level files (*.lvl)|*.lvl|All files (*.*)|*.*";
                        saveFileDialog.FileName = $"{lblgame.Text}.lvl";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filepath = saveFileDialog.FileName;
                            FileStream lvl = new FileStream(filepath, FileMode.Create);
                            StreamWriter lvlf = new StreamWriter(lvl);
                            lvlf.WriteLine(level);
                            lvlf.Close();
                            lvlf.Dispose();
                            lvl.Dispose();
                        }
                        
                     }
                     else MessageBox.Show("Горизонаталь не заполненна", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Вертикаль не заполненна", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Поле пусто", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
