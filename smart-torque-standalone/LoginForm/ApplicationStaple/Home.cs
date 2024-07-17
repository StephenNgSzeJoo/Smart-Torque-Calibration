using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z80NavBarControl.Z80NavBar.Themes;
using Z80NavBarControl.Z80NavBar;

using Z80NavBarControl;
using Microsoft.Ajax.Utilities;
using CedarTorque;
using LoginForm.TorqueMaintanence;
using LoginForm.TorqMaintanence;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Diagnostics;
using LoginForm.TorqueForms;

namespace LoginForm
{
    public partial class Home : Form
    {

        ParentForm calibrationForm = new ParentForm();
        TorqMaint torqMaint = new TorqMaint();
        TorqInsert torqInsert = new TorqInsert();
        TotalTorqueCalReport torqTotal = new TotalTorqueCalReport();
        public static ParentForm currentForm = null;
        public event EventHandler logout; // handles the event whereby the link was clicked 


        public Home()
        {
            InitializeComponent();
            Installer installer = new Installer();
            installer.SetupDatabase();

            z80_Navigation1.SelectedItem += Z80_Navigation1_SelectedItem;
            List<NavBarItem> demoItems = new List<NavBarItem>
             {
               new NavBarItem {ID = 1, Text = "Torque Calibration Measurement"},
               new NavBarItem {ID = 2,  Text = "Global List"},
               new NavBarItem {ID = 3, Text = "Torque Calibration Threshold Maintanence"},
               new NavBarItem {ID = 4,Text="Torque Equipment Maintanence",
                   Childs = new List<NavBarItem> {
                       new NavBarItem {ID = 1001, ParentID = 1, Text = "Add New Device", Height = 30},
                       new NavBarItem {ID = 1002, ParentID = 2, Text = "Edit Details", Height = 30 }
                   }
                   },
               new NavBarItem {ID = 5, Text = "Torque Sapphire List"},

             };
            z80_Navigation1.Initialize(demoItems, new ThemeSelector(Theme.Dark).CurrentTheme);
            //this.Resize += Home_Resize;
            //splitContainer1.SplitterMoved += SplitContainer1_SplitterMoved;
        }

        public static void setCurrentForm(ParentForm mainForm)
        {
            currentForm = mainForm;
        }

        private int distanceCopy;

        private void toogleButton_Click(object sender, EventArgs e)
        {
            if (splitContainer1.SplitterDistance > 35)
            {
                distanceCopy = splitContainer1.SplitterDistance;
                splitContainer1.SplitterDistance = 35;
            }
            else
                splitContainer1.SplitterDistance = distanceCopy;
        }

        public string AskUserForChoice()
        {
            // Show a dialog box to ask the user to choose HIOS or CEDAR
            string userChoice = "";
            using (var form = new ChooseForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    userChoice = form.SelectedChoice; // Assuming ChooseForm has a property to get the selected choice
                }
            }
            return userChoice;
        }

        private void Z80_Navigation1_SelectedItem(NavBarItem item)
        {
            Panel panelToFill = splitContainer1.Panel2; // Change to Panel2 if necessary
            panelToFill.Controls.Clear();


            if (item.ID == 1)
            {
                String userChoice =  AskUserForChoice();
                calibrationForm = new ParentForm();

                if (userChoice == "HIOS")
                {
                    calibrationForm = new HIOSMainForm();

                    // Set the form's properties (if needed)
                    calibrationForm.TopLevel = false;
                    calibrationForm.FormBorderStyle = FormBorderStyle.None;
                    calibrationForm.Dock = DockStyle.Fill;


                    // Add the form to the panel
                    panelToFill.Controls.Add(calibrationForm);

                    // Show the form
                    calibrationForm.Show();
                }
                else if (userChoice == "CEDAR")
                {
                    calibrationForm = new CEDARMainForm();

                    // Set the form's properties (if needed)
                    calibrationForm.TopLevel = false;
                    calibrationForm.FormBorderStyle = FormBorderStyle.None;
                    calibrationForm.Dock = DockStyle.Fill;


                    // Add the form to the panel
                    panelToFill.Controls.Add(calibrationForm);

                    // Show the form
                    calibrationForm.Show();
                }
                else
                {
                    // User canceled or chose an invalid option
                    MessageBox.Show("Operation canceled or invalid choice.");
                }

                
            }
            if (item.ID == 2)
            {
                GlobalList globalList = new GlobalList();
                // Set the form's properties (if needed)
                globalList.TopLevel = false;
                globalList.FormBorderStyle = FormBorderStyle.None;
                globalList.Dock = DockStyle.Fill;


                // Add the form to the panel
                panelToFill.Controls.Add(globalList);

                // Show the form
                globalList.Show();
                globalList.pressSelect += clickSelect;
            }
            if (item.ID == 3)
            {
                ThresholdMaint thresholdMaint = new ThresholdMaint();
                // Access the panel within the SplitContainer

                // Set the form's properties (if needed)
                thresholdMaint.TopLevel = false;
                thresholdMaint.FormBorderStyle = FormBorderStyle.None;
                thresholdMaint.Dock = DockStyle.Fill;


                // Add the form to the panel
                panelToFill.Controls.Add(thresholdMaint);

                // Show the form
                thresholdMaint.Show();
            }
            if (item.ID == 1001)
            {
                torqInsert.TopLevel = false;
                panelToFill.Controls.Add(torqInsert);
                torqInsert.Show();
                torqInsert.successfullyInserted += refreshDropdownList;
            }
            if (item.ID == 1002)
            {
                torqMaint.TopLevel = false;
                panelToFill.Controls.Add(torqMaint);
                torqMaint.Show();

            }
            if (item.ID == 5)
            {
                torqTotal  = new TotalTorqueCalReport();
                // Set the form's properties (if needed)
                torqTotal.TopLevel = false;
                torqTotal.FormBorderStyle = FormBorderStyle.None;
                torqTotal.Dock = DockStyle.Fill;


                // Add the form to the panel
                panelToFill.Controls.Add(torqTotal);

                // Show the form
                torqTotal.Show();
                torqTotal.pressSelect += clickSelect;

            }

        }

        private void clickSelect(object sender, EventArgs e) {
            Panel panelToFill = splitContainer1.Panel2; // Change to Panel2 if necessary
            panelToFill.Controls.Clear();
            // Set the form's properties (if needed)
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;


            // Add the form to the panel
            panelToFill.Controls.Add(currentForm);

            // Show the form
            currentForm.Show();
        }




        private void refreshDropdownList(object sender, EventArgs e)
        {
            torqMaint.RefreshTorqCalIDs();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                logout?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
        }
    }


}



