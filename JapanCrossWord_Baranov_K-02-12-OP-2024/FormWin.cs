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
        int t=0;
        int sc = 1000;
        int index;
        int result = 0;
        public FormWin(int s,int m)
        {
            t=m*60+s;
            InitializeComponent();
        } 

        private void FormWin_Load(object sender, EventArgs e)
        {
            if (t > 120 && t < 240) sc = sc - t;
            else if (t > 240 && t < 420) sc = sc - t * 2;
            else if (t>420) sc = 0;
            anim.Start();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            FormStart frm = new FormStart();
            this.Hide();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void anim_Tick(object sender, EventArgs e)
        {
            index++;
            result = (int)(sc * Math.Sin((double)index / 300 * Math.PI / 2));
            sclbl.Text = $"You score:\n{result}";
            if (result >= sc) anim.Stop();
        }
    }
}
