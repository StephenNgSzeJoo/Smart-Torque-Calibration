namespace LoginForm
{
    partial class ThresholdMaint
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPre = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPre = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveTorqueSetting = new System.Windows.Forms.Button();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.txtLastDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(136, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pre-Calculation Threshold (%)";
            // 
            // txtPre
            // 
            this.txtPre.Location = new System.Drawing.Point(287, 269);
            this.txtPre.Name = "txtPre";
            this.txtPre.Size = new System.Drawing.Size(100, 20);
            this.txtPre.TabIndex = 1;
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(287, 311);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(100, 20);
            this.txtPost.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(136, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Post-Calculation Threshold (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(136, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Post-Calculation Threshold (%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(141, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pre-Calculation Threshold (%)";
            // 
            // txt1
            // 
            this.txt1.AutoSize = true;
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt1.Location = new System.Drawing.Point(83, 240);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(127, 18);
            this.txt1.TabIndex = 6;
            this.txt1.Text = "Set Threshold (%)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(83, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Current Threshold (%)";
            // 
            // lblPre
            // 
            this.lblPre.AutoSize = true;
            this.lblPre.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPre.Location = new System.Drawing.Point(292, 109);
            this.lblPre.Name = "lblPre";
            this.lblPre.Size = new System.Drawing.Size(88, 15);
            this.lblPre.TabIndex = 36;
            this.lblPre.Text = "curPreCalThresh";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPost.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPost.Location = new System.Drawing.Point(292, 145);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(93, 15);
            this.lblPost.TabIndex = 37;
            this.lblPost.Text = "curPostCalThresh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(23, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(287, 22);
            this.label8.TabIndex = 38;
            this.label8.Text = "Torque Threshold Maintenance Module";
            // 
            // btnSaveTorqueSetting
            // 
            this.btnSaveTorqueSetting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveTorqueSetting.Location = new System.Drawing.Point(354, 379);
            this.btnSaveTorqueSetting.Name = "btnSaveTorqueSetting";
            this.btnSaveTorqueSetting.Size = new System.Drawing.Size(71, 23);
            this.btnSaveTorqueSetting.TabIndex = 39;
            this.btnSaveTorqueSetting.Text = "Update";
            this.btnSaveTorqueSetting.UseVisualStyleBackColor = true;
            this.btnSaveTorqueSetting.Click += new System.EventHandler(this.btnSaveTorqueSetting_Click);
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblLastDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLastDate.Location = new System.Drawing.Point(292, 184);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(112, 15);
            this.lblLastDate.TabIndex = 41;
            this.lblLastDate.Text = "lastUpdatedDateTime";
            // 
            // txtLastDate
            // 
            this.txtLastDate.AutoSize = true;
            this.txtLastDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLastDate.Location = new System.Drawing.Point(210, 186);
            this.txtLastDate.Name = "txtLastDate";
            this.txtLastDate.Size = new System.Drawing.Size(71, 13);
            this.txtLastDate.TabIndex = 40;
            this.txtLastDate.Text = "Last Updated";
            this.txtLastDate.Click += new System.EventHandler(this.label7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(186, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Current Date/Time";
            // 
            // lblNewDate
            // 
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblNewDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNewDate.Location = new System.Drawing.Point(287, 349);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(88, 15);
            this.lblNewDate.TabIndex = 43;
            this.lblNewDate.Text = "currentDateTime";
            // 
            // ThresholdMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 450);
            this.Controls.Add(this.lblNewDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLastDate);
            this.Controls.Add(this.txtLastDate);
            this.Controls.Add(this.btnSaveTorqueSetting);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.lblPre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPre);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThresholdMaint";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPre;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPre;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveTorqueSetting;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.Label txtLastDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNewDate;
    }
}