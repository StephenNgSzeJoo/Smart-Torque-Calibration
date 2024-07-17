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
    public partial class LoadingForm : Form
    {
        private int countdownValue; // Variable to store countdown value

        public LoadingForm(int items)
        {
            InitializeComponent();
            countdownValue = items;
            label1.Text = "Remaining uploads" + countdownValue.ToString();


            // Initialize the form or set up any controls here
        }

        // Method to update the countdown label or perform countdown logic
        public void UpdateCountdown()
        {
            countdownValue--; // Decrement the countdown value

            // Update a label or display the countdown value somewhere on the form
            label1.Text = "Remaining uploads" + countdownValue.ToString();

            if (countdownValue <= 0)
            {
                // Close the form or perform any actions when countdown reaches zero
                this.Close();
            }
        }


    }
}
