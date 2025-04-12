using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    public partial class FormStart: Form
    {
        FormGame frm = new FormGame();
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

            foreach (string s in frm.cmbgame.Items) cmbgame.Items.Add(s);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!frm.IsDisposed)
            {
                if (cmbgame.Text != "Editor")
                {
                    this.Hide();
                    frm.cmbgame.Text = cmbgame.Text;
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
        }


        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {Application.Exit();}

        private void cmbgame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbgame.Text == "Editor") btnStart.Text = "New";
            else btnStart.Text = "Start Game";

            if (cmbgame.Text == "Import") btnStart.Text = "Import Game";
            else if (cmbgame.Text == "Editor") btnStart.Text = "New";
            else btnStart.Text = "Start Game";
        }
    }
}