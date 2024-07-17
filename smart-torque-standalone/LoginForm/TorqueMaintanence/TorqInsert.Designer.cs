namespace LoginForm.TorqueMaintanence
{
    partial class TorqInsert
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
            this.textBoxNewTorqCalID = new System.Windows.Forms.TextBox();
            this.textBoxTorqCalDesc = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNewTorqCalID
            // 
            this.textBoxNewTorqCalID.Location = new System.Drawing.Point(50, 96);
            this.textBoxNewTorqCalID.Name = "textBoxNewTorqCalID";
            this.textBoxNewTorqCalID.Size = new System.Drawing.Size(121, 20);
            this.textBoxNewTorqCalID.TabIndex = 7;
            // 
            // textBoxTorqCalDesc
            // 
            this.textBoxTorqCalDesc.Location = new System.Drawing.Point(50, 145);
            this.textBoxTorqCalDesc.Name = "textBoxTorqCalDesc";
            this.textBoxTorqCalDesc.Size = new System.Drawing.Size(222, 96);
            this.textBoxTorqCalDesc.TabIndex = 10;
            this.textBoxTorqCalDesc.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Torque Calibration ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Torque Calibration Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "Add a Device";
            // 
            // TorqInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 334);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNewTorqCalID);
            this.Controls.Add(this.textBoxTorqCalDesc);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TorqInsert";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNewTorqCalID;
        private System.Windows.Forms.RichTextBox textBoxTorqCalDesc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}