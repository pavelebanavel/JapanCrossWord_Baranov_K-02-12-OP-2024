using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    public partial class FormHelp: Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        private void FormHelp_Load(object sender, EventArgs e)
        { //простая реализация основной игры
             
            //вертикальная подсказка
            string p = "0100010" +
                       "0112110";

            //заполнение поля
            string o = "0100010" +
                       "0000000" +
                       "0101010" +
                       "0011100";

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Label lbl = new Label();

                    //настройка стиля
                    lbl.BackColor = Color.White;
                    lbl.Width = 35; lbl.Height = 35;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", 11);
                    lbl.Location = new Point(x * 35 + 12, y * 35 + 245);

                    this.Controls.Add(lbl); //добаляем на форму

                    if (p[y * 7 + x] != '0')
                    {
                        //забиваем значения если клетка не пуста
                        lbl.Text = $"{p[y*7+x]}"; //y*7+x по формуле вместо индекса
                        lbl.BackColor= Color.DarkGray;
                    } 
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Label lbl = new Label();

                    //настройка стиля
                    lbl.BackColor = Color.White;
                    lbl.Width = 35; lbl.Height = 35;
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", 11);
                    lbl.Location = new Point(x * 35 + 12, y * 35 + 330);

                    this.Controls.Add(lbl); //добаляем на форму

                    if (o[y * 7 + x] != '0')
                    {
                        //закрашиваем клетку
                        lbl.BackColor = Color.Black;
                    }
                }
            }
        }
    }
}
