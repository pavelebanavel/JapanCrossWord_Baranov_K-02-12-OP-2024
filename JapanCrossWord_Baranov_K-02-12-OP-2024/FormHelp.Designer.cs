namespace JapanCrossWord_Baranov_K_02_12_OP_2024
{
    partial class FormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            this.btnblack = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.lbllcm = new System.Windows.Forms.Label();
            this.lblrcm = new System.Windows.Forms.Label();
            this.lblss = new System.Windows.Forms.Label();
            this.lblDel = new System.Windows.Forms.Label();
            this.btnE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnblack
            // 
            this.btnblack.BackColor = System.Drawing.Color.Black;
            this.btnblack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnblack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnblack.ForeColor = System.Drawing.Color.White;
            this.btnblack.Location = new System.Drawing.Point(12, 15);
            this.btnblack.Name = "btnblack";
            this.btnblack.Size = new System.Drawing.Size(35, 35);
            this.btnblack.TabIndex = 0;
            this.btnblack.UseVisualStyleBackColor = false;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.White;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.Black;
            this.btnX.Location = new System.Drawing.Point(12, 65);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(35, 35);
            this.btnX.TabIndex = 1;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            // 
            // lbllcm
            // 
            this.lbllcm.AutoSize = true;
            this.lbllcm.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllcm.ForeColor = System.Drawing.Color.Black;
            this.lbllcm.Location = new System.Drawing.Point(53, 15);
            this.lbllcm.Name = "lbllcm";
            this.lbllcm.Size = new System.Drawing.Size(191, 32);
            this.lbllcm.TabIndex = 33;
            this.lbllcm.Text = "Left Mouse Click";
            // 
            // lblrcm
            // 
            this.lblrcm.AutoSize = true;
            this.lblrcm.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrcm.ForeColor = System.Drawing.Color.Black;
            this.lblrcm.Location = new System.Drawing.Point(53, 65);
            this.lblrcm.Name = "lblrcm";
            this.lblrcm.Size = new System.Drawing.Size(207, 32);
            this.lblrcm.TabIndex = 34;
            this.lblrcm.Text = "Right Mouse Click";
            // 
            // lblss
            // 
            this.lblss.AutoSize = true;
            this.lblss.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblss.ForeColor = System.Drawing.Color.Black;
            this.lblss.Location = new System.Drawing.Point(39, 204);
            this.lblss.Name = "lblss";
            this.lblss.Size = new System.Drawing.Size(189, 32);
            this.lblss.TabIndex = 35;
            this.lblss.Text = "Sample Solution";
            // 
            // lblDel
            // 
            this.lblDel.AutoSize = true;
            this.lblDel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDel.ForeColor = System.Drawing.Color.Black;
            this.lblDel.Location = new System.Drawing.Point(53, 115);
            this.lblDel.Name = "lblDel";
            this.lblDel.Size = new System.Drawing.Size(160, 32);
            this.lblDel.TabIndex = 37;
            this.lblDel.Text = "Retap to clear";
            // 
            // btnE
            // 
            this.btnE.BackColor = System.Drawing.Color.White;
            this.btnE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnE.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE.ForeColor = System.Drawing.Color.Black;
            this.btnE.Location = new System.Drawing.Point(12, 115);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(35, 35);
            this.btnE.TabIndex = 36;
            this.btnE.UseVisualStyleBackColor = false;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(270, 485);
            this.Controls.Add(this.lblDel);
            this.Controls.Add(this.btnE);
            this.Controls.Add(this.lblss);
            this.Controls.Add(this.lblrcm);
            this.Controls.Add(this.lbllcm);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnblack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHelp";
            this.Text = "Game rules & Help";
            this.Load += new System.EventHandler(this.FormHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnblack;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lbllcm;
        private System.Windows.Forms.Label lblrcm;
        private System.Windows.Forms.Label lblss;
        private System.Windows.Forms.Label lblDel;
        private System.Windows.Forms.Button btnE;
    }
}