using System;
using System.Windows.Forms;

namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    public partial class FormStart: Form
    {
        public FormStart()
        {
            InitializeComponent();
        }  

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (cmbgame.Text != "Editor")
            {
                FormGame frm = new FormGame(cmbgame.Text, cmbgame.SelectedIndex);
                this.Hide();
                frm.ShowDialog();
                frm.Dispose();
            }
            else 
            {
                FormEditor frme = new FormEditor();
                this.Hide();
                frme.ShowDialog();
                frme.Dispose();
            } 
        }
         
        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cmbgame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbgame.Text == "Import") btnStart.Text = "Import Game";
            else if (cmbgame.Text == "Editor") btnStart.Text = "New";
            else btnStart.Text = "Start Game";
        }
    }
}