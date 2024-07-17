namespace LoginForm
{
    partial class HIOSMainForm
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
            this.SuspendLayout();
            // 
            // HIOSMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 921);
            this.Name = "HIOSMainForm";
            this.Text = "HIOSMainForm";
            this.ResumeLayout(false);

            // btnPreRead
            // 
            this.btnPreRead.Location = new System.Drawing.Point(43, 19);
            this.btnPreRead.Name = "btnPreRead";
            this.btnPreRead.Size = new System.Drawing.Size(150, 23);
            this.btnPreRead.TabIndex = 0;
            this.btnPreRead.Text = "Read";
            this.btnPreRead.UseVisualStyleBackColor = true;

            // btnPostRead
            // 
            this.btnPostRead.Location = new System.Drawing.Point(43, 19);
            this.btnPostRead.Name = "btnPostRead";
            this.btnPostRead.Size = new System.Drawing.Size(150, 23);
            this.btnPostRead.TabIndex = 0;
            this.btnPostRead.Text = "Read";
            this.btnPostRead.UseVisualStyleBackColor = true;

            // btnSaveTorqueSetting
            // 
            this.btnSaveTorqueSetting.Location = new System.Drawing.Point(538, 174);
            this.btnSaveTorqueSetting.Name = "btnSaveTorqueSetting";
            this.btnSaveTorqueSetting.Size = new System.Drawing.Size(67, 28);
            this.btnSaveTorqueSetting.TabIndex = 31;
            this.btnSaveTorqueSetting.Text = "Save";
            this.btnSaveTorqueSetting.UseVisualStyleBackColor = true;
            this.btnSaveTorqueSetting.Click += new System.EventHandler(this.btnSaveTorqueSetting_Click);



        }

        #endregion
    }
}