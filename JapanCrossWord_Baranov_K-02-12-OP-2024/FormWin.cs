using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    public partial class FormWin: Form
    {
        int t=0; //время
        int sc = 1000; //макс. очки
        int index; //индекс для таймера
        int result = 0; //результат
        public FormWin(int s,int m)
        {
            t=m*60+s;
            InitializeComponent();
        } 

        private void FormWin_Load(object sender, EventArgs e)
        {
            //вычисляем очки
            if (t > 120 && t < 240) sc = sc - t;
            else if (t > 240 && t < 420) sc = sc - t * 2;
            else if (t>420) sc = 0;
            anim.Start();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            //выход на начальную форму
            FormStart frm = new FormStart();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            //убиваем эту форму
            this.Dispose();
        }

        private void anim_Tick(object sender, EventArgs e)
        {
            index++;
            result = (int)(sc * Math.Sin((double)index / 300 * Math.PI / 2)); //анимация циферок по синусу
            sclbl.Text = $"You score:\n{result}"; //выводим анимацию
            if (result >= sc) anim.Stop(); //завершаем
        }
    }
}
