namespace LoginForm
{
    partial class Login
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
            this.loginFormPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SapphireUser = new System.Windows.Forms.RadioButton();
            this.nonSapphireUser = new System.Windows.Forms.RadioButton();
            this.loginFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginFormPanel
            // 
            this.loginFormPanel.BackColor = System.Drawing.Color.White;
            this.loginFormPanel.Controls.Add(this.nonSapphireUser);
            this.loginFormPanel.Controls.Add(this.SapphireUser);
            this.loginFormPanel.Controls.Add(this.button2);
            this.loginFormPanel.Controls.Add(this.label7);
            this.loginFormPanel.Controls.Add(this.txtPassword);
            this.loginFormPanel.Controls.Add(this.label8);
            this.loginFormPanel.Controls.Add(this.label18);
            this.loginFormPanel.Controls.Add(this.label9);
            this.loginFormPanel.Controls.Add(this.label16);
            this.loginFormPanel.Controls.Add(this.linkLabel1);
            this.loginFormPanel.Controls.Add(this.label12);
            this.loginFormPanel.Controls.Add(this.txtUsername);
            this.loginFormPanel.Controls.Add(this.panel1);
            this.loginFormPanel.Location = new System.Drawing.Point(316, 188);
            this.loginFormPanel.Name = "loginFormPanel";
            this.loginFormPanel.Size = new System.Drawing.Size(422, 316);
            this.loginFormPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(65, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.label7.Location = new System.Drawing.Point(62, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 70;
            this.label7.Text = "Email / UserNT";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(63, 161);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(304, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(132, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 77;
            this.label8.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.label18.Location = new System.Drawing.Point(62, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 15);
            this.label18.TabIndex = 72;
            this.label18.Text = "Password ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(62, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Do not have an account? Click";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(158, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 15);
            this.label16.TabIndex = 76;
            this.label16.Text = "*";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(214, 282);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(28, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "here";
            this.linkLabel1.Click += new System.EventHandler(this.register_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(239, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "to register.";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(63, 85);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(304, 29);
            this.txtUsername.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(63, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 42);
            this.panel1.TabIndex = 80;
            // 
            // SapphireUser
            // 
            this.SapphireUser.AutoSize = true;
            this.SapphireUser.BackColor = System.Drawing.Color.Transparent;
            this.SapphireUser.Checked = true;
            this.SapphireUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SapphireUser.Location = new System.Drawing.Point(68, 22);
            this.SapphireUser.Name = "SapphireUser";
            this.SapphireUser.Size = new System.Drawing.Size(125, 20);
            this.SapphireUser.TabIndex = 78;
            this.SapphireUser.TabStop = true;
            this.SapphireUser.Text = "Sapphire User";
            this.SapphireUser.UseVisualStyleBackColor = false;
            // 
            // nonSapphireUser
            // 
            this.nonSapphireUser.AutoSize = true;
            this.nonSapphireUser.BackColor = System.Drawing.Color.Transparent;
            this.nonSapphireUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonSapphireUser.Location = new System.Drawing.Point(208, 22);
            this.nonSapphireUser.Name = "nonSapphireUser";
            this.nonSapphireUser.Size = new System.Drawing.Size(157, 20);
            this.nonSapphireUser.TabIndex = 79;
            this.nonSapphireUser.Text = "Non Sapphire User";
            this.nonSapphireUser.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoginForm.Properties.Resources.bg_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1010, 894);
            this.Controls.Add(this.loginFormPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7";
            this.loginFormPanel.ResumeLayout(false);
            this.loginFormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginFormPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.RadioButton nonSapphireUser;
        private System.Windows.Forms.RadioButton SapphireUser;
        private System.Windows.Forms.Panel panel1;
    }
}