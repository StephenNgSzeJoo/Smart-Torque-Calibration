namespace LoginForm
{
    partial class ChooseForm
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
            this.buttonCEDAR = new System.Windows.Forms.Button();
            this.buttonHIOS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCEDAR
            // 
            this.buttonCEDAR.BackColor = System.Drawing.Color.IndianRed;
            this.buttonCEDAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCEDAR.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCEDAR.Location = new System.Drawing.Point(70, 105);
            this.buttonCEDAR.Name = "buttonCEDAR";
            this.buttonCEDAR.Size = new System.Drawing.Size(123, 52);
            this.buttonCEDAR.TabIndex = 0;
            this.buttonCEDAR.Text = "CEDAR";
            this.buttonCEDAR.UseVisualStyleBackColor = false;
            this.buttonCEDAR.Click += new System.EventHandler(this.btnCEDAR_Click);
            // 
            // buttonHIOS
            // 
            this.buttonHIOS.BackColor = System.Drawing.Color.IndianRed;
            this.buttonHIOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHIOS.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonHIOS.Location = new System.Drawing.Point(226, 105);
            this.buttonHIOS.Name = "buttonHIOS";
            this.buttonHIOS.Size = new System.Drawing.Size(126, 52);
            this.buttonHIOS.TabIndex = 1;
            this.buttonHIOS.Text = "HIOS";
            this.buttonHIOS.UseVisualStyleBackColor = false;
            this.buttonHIOS.Click += new System.EventHandler(this.btnHIOS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select your calibrator";
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 271);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonHIOS);
            this.Controls.Add(this.buttonCEDAR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calibrator Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCEDAR;
        private System.Windows.Forms.Button buttonHIOS;
        public System.Windows.Forms.Label label2;
    }
}