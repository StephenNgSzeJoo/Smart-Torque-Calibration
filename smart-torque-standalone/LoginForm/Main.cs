using CedarTorque;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Main : Form 
    {
        private Login loginForm;
        private Register registerform;
        private Home home;
        public String username;

        public Main()
        {
            InitializeComponent();
            displayLoginForm();
            this.WindowState = FormWindowState.Normal; // Set the window state to Norma
        }

        private void displayLoginForm()
        {
            loginForm = new Login();
            loginForm.Dock = DockStyle.Fill; // Set the Dock property to Fill
            loginForm.TopLevel = false; // Set TopLevel to false to add it to another form

            // Add the loginForm to the Controls collection of the main form
            this.Controls.Add(loginForm);

            // Subscribe to the SizeChanged event of the main form
            this.SizeChanged += MainForm_SizeChanged;


            // Subscribe to the event in login form
            loginForm.linkClicked += linkClickedInLoginForm;
            loginForm.onCloseLogin += loginSuccess;

            // Show the loginForm
            loginForm.Show();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // Adjust the size of mainLogin whenever the main form size changes
            loginForm.Size = this.ClientSize;
        }

        private void linkClickedInLoginForm(object sender, EventArgs e)
        {
            // Handle the event raised in login form (when the link is clicked)
            loginForm.Close();
            displayRegister();
        }

        private void displayRegister()
        {
            // Show the Register form to display
            registerform = new Register();
            registerform.Dock = DockStyle.Fill;
            registerform.TopLevel = false;

            // Subscribe to the event in register form
            registerform.registerSuccess += registrationSuccess;

            this.Controls.Add(registerform);
            registerform.Show();
        }

        private void displayHome()
        {
            // Show the Home form to display
            home = new Home();
            home.Dock = DockStyle.Fill;
            home.TopLevel = false;

            home.logout += logout;

            this.Controls.Add(home);
            home.Show();
        }

        private void registrationSuccess(object sender, EventArgs e)
        {
            registerform.Close();
            displayLoginForm();
        }

        private void loginSuccess(object sender, EventArgs e)
        {
            displayHome();
        }

        private void logout(object sender, EventArgs e)
        {
            home.Close();
            displayLoginForm();
        }

    }
}
