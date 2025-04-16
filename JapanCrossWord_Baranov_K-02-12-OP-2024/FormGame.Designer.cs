namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.lblt = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.otvet = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.pnlpole = new System.Windows.Forms.Panel();
            this.pnlg = new System.Windows.Forms.Panel();
            this.pnlv = new System.Windows.Forms.Panel();
            this.cmbgame = new System.Windows.Forms.ComboBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblt
            // 
            this.lblt.AutoSize = true;
            this.lblt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblt.Location = new System.Drawing.Point(42, 41);
            this.lblt.Name = "lblt";
            this.lblt.Size = new System.Drawing.Size(66, 25);
            this.lblt.TabIndex = 1;
            this.lblt.Text = "00:00";
            this.lblt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time
            // 
            this.time.Enabled = true;
            this.time.Interval = 1000;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // otvet
            // 
            this.otvet.BackgroundImage = global::JapanCrossWord_Baranov_K_02_12_OP_2024.Properties.Resources.otvet;
            this.otvet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.otvet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otvet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.otvet.Location = new System.Drawing.Point(79, 75);
            this.otvet.Name = "otvet";
            this.otvet.Size = new System.Drawing.Size(30, 30);
            this.otvet.TabIndex = 4;
            this.tt.SetToolTip(this.otvet, "Правильный ответ");
            this.otvet.UseVisualStyleBackColor = true;
            this.otvet.Click += new System.EventHandler(this.otvet_Click);
            // 
            // delete
            // 
            this.delete.BackgroundImage = global::JapanCrossWord_Baranov_K_02_12_OP_2024.Properties.Resources.delete;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.delete.Location = new System.Drawing.Point(114, 75);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(30, 30);
            this.delete.TabIndex = 5;
            this.tt.SetToolTip(this.delete, "Очистка поля!");
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.del);
            // 
            // info
            // 
            this.info.BackgroundImage = global::JapanCrossWord_Baranov_K_02_12_OP_2024.Properties.Resources.info;
            this.info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info.Location = new System.Drawing.Point(44, 75);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(30, 30);
            this.info.TabIndex = 3;
            this.tt.SetToolTip(this.info, "Правила игры");
            this.info.UseVisualStyleBackColor = true;
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // exit
            // 
            this.exit.BackgroundImage = global::JapanCrossWord_Baranov_K_02_12_OP_2024.Properties.Resources.exit;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Location = new System.Drawing.Point(9, 75);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(30, 30);
            this.exit.TabIndex = 2;
            this.tt.SetToolTip(this.exit, "Выход в меню");
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseEnter += new System.EventHandler(this.exit_MouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            // 
            // pnlpole
            // 
            this.pnlpole.Location = new System.Drawing.Point(159, 125);
            this.pnlpole.Name = "pnlpole";
            this.pnlpole.Size = new System.Drawing.Size(358, 355);
            this.pnlpole.TabIndex = 6;
            // 
            // pnlg
            // 
            this.pnlg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlg.Location = new System.Drawing.Point(159, 4);
            this.pnlg.Name = "pnlg";
            this.pnlg.Size = new System.Drawing.Size(358, 115);
            this.pnlg.TabIndex = 7;
            // 
            // pnlv
            // 
            this.pnlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlv.Location = new System.Drawing.Point(4, 125);
            this.pnlv.Name = "pnlv";
            this.pnlv.Size = new System.Drawing.Size(149, 355);
            this.pnlv.TabIndex = 8;
            // 
            // cmbgame
            // 
            this.cmbgame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbgame.BackColor = System.Drawing.Color.White;
            this.cmbgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbgame.ForeColor = System.Drawing.Color.Black;
            this.cmbgame.FormattingEnabled = true;
            this.cmbgame.Items.AddRange(new object[] {
            "Game1",
            "Game2",
            "Game3",
            "Import",
            "Editor"});
            this.cmbgame.Location = new System.Drawing.Point(19, 4);
            this.cmbgame.Name = "cmbgame";
            this.cmbgame.Size = new System.Drawing.Size(121, 39);
            this.cmbgame.TabIndex = 9;
            this.cmbgame.Text = "Game1";
            this.cmbgame.SelectedIndexChanged += new System.EventHandler(this.cmbgame_SelectedIndexChanged);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 481);
            this.Controls.Add(this.cmbgame);
            this.Controls.Add(this.pnlv);
            this.Controls.Add(this.pnlg);
            this.Controls.Add(this.pnlpole);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.otvet);
            this.Controls.Add(this.info);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.lblt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblt;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button info;
        private System.Windows.Forms.Button otvet;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Panel pnlpole;
        private System.Windows.Forms.Panel pnlg;
        private System.Windows.Forms.Panel pnlv;
        public System.Windows.Forms.ComboBox cmbgame;
        private System.Windows.Forms.ToolTip tt;
    }
}

