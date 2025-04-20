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
                //переход на игровую форму
                FormGame frm = new FormGame(cmbgame.Text, cmbgame.SelectedIndex); //передаем параметры в конструктор формы
                this.Hide(); 
                frm.ShowDialog();
                frm.Dispose();
            }
            else  
            {
                //переход на редактор уровней
                FormEditor frme = new FormEditor();
                this.Hide();
                frme.ShowDialog();
                frme.Dispose();
            } 
        }
         
        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            //при нажатиии крестика закрывается все приложение
            Application.Exit();
        }

        private void cmbgame_SelectedIndexChanged(object sender, EventArgs e)
        {
            //меняем названия кнопки при определенных пунктах
            if (cmbgame.Text == "Import") btnStart.Text = "Import Game";
            else if (cmbgame.Text == "Editor") btnStart.Text = "New";
            else btnStart.Text = "Start Game";
        }
    }
}