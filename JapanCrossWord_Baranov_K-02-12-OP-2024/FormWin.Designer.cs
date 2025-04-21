namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    partial class FormWin
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
            this.winlbl = new System.Windows.Forms.Label();
            this.sclbl = new System.Windows.Forms.Label();
            this.anim = new System.Windows.Forms.Timer(this.components);
            this.exit = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // winlbl
            // 
            this.winlbl.AutoSize = true;
            this.winlbl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winlbl.ForeColor = System.Drawing.Color.Black;
            this.winlbl.Location = new System.Drawing.Point(73, 30);
            this.winlbl.Name = "winlbl";
            this.winlbl.Size = new System.Drawing.Size(138, 47);
            this.winlbl.TabIndex = 0;
            this.winlbl.Text = "Victory!";
            // 
            // sclbl
            // 
            this.sclbl.AutoSize = true;
            this.sclbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sclbl.ForeColor = System.Drawing.Color.Black;
            this.sclbl.Location = new System.Drawing.Point(80, 118);
            this.sclbl.Name = "sclbl";
            this.sclbl.Size = new System.Drawing.Size(121, 32);
            this.sclbl.TabIndex = 1;
            this.sclbl.Text = "You score:";
            this.sclbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anim
            // 
            this.anim.Interval = 20;
            this.anim.Tick += new System.EventHandler(this.anim_Tick);
            // 
            // exit
            // 
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.exit.ForeColor = System.Drawing.Color.Black;
            this.exit.Location = new System.Drawing.Point(12, 200);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(122, 36);
            this.exit.TabIndex = 12;
            this.exit.Text = "Menu";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // restart
            // 
            this.restart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restart.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.restart.ForeColor = System.Drawing.Color.Black;
            this.restart.Location = new System.Drawing.Point(155, 200);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(122, 36);
            this.restart.TabIndex = 13;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // FormWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 248);
            this.ControlBox = false;
            this.Controls.Add(this.restart);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.sclbl);
            this.Controls.Add(this.winlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label winlbl;
        private System.Windows.Forms.Label sclbl;
        private System.Windows.Forms.Timer anim;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button restart;
    }
}