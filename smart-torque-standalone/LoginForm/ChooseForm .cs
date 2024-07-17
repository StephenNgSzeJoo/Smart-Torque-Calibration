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
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            InitializeComponent();
        }
        public string SelectedChoice { get; private set; }


        private void btnHIOS_Click(object sender, EventArgs e)
        {
            SelectedChoice = "HIOS";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCEDAR_Click(object sender, EventArgs e)
        {
            SelectedChoice = "CEDAR";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
