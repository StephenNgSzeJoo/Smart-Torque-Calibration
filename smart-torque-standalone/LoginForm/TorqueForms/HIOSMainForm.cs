using FTD2XX_NET;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace LoginForm
{
    public partial class HIOSMainForm : ParentForm
    {
        public const String torqmodel = "HIOS";

        public HIOSMainForm()
        {
            InitializeComponent();
            txtPreValue.Enabled = true;
            txtPostValue.Enabled = true;
            txtPreValue.Focus();
        }


        public override async void btnRead(Button btnRead, TextBox txtValue, DataGridView gridview, Label lblUpperSpec, Label lblLowerSpec, bool isPre, Button btnComplete)
        {
            ValidateTextBoxes();

            if (txtEqID.Enabled && comboBoxTorqCalID.Enabled && txtLocation.Enabled && txtTorqSetting.Enabled)
            {
                MessageBox.Show("Please save your details.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gridview.RowCount == 6)
            {
                MessageBox.Show("Records complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            double torque_value_double = 0.00;
            if (!string.IsNullOrEmpty(txtValue.Text)) { 
                torque_value_double = Convert.ToDouble(txtValue.Text);
            }
           
            int rowCount = gridview.RowCount;
            double deviation = 0.00;
            string status = "Pass";

            bool bPassed = true;

            string Upper = lblUpperSpec.Text;
            string Lower = lblLowerSpec.Text;
            double UpperDec = 0;
            double LowerDec = 0;

            if (double.TryParse(Upper, out double Maxresult))
            {
                UpperDec = double.Parse(Upper);
            }
            if (double.TryParse(Lower, out double Minresult))
            {
                LowerDec = double.Parse(Lower);
            }

            if (Convert.ToDecimal(txtValue.Text) > Convert.ToDecimal(UpperDec) || Convert.ToDecimal(txtValue.Text) < Convert.ToDecimal(LowerDec))
            {
                DialogResult confirmation = MessageBox.Show("Out of threshold!! Do you want to continue?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Check the user's choice
                if (confirmation == DialogResult.OK)
                {
                    bPassed = true;
                }
                else if (confirmation == DialogResult.Cancel)
                {
                    bPassed = false;
                }
                else
                {
                    bPassed = false;
                }
            }

            if (bPassed)
            {
                deviation = CalculateDeviation(Convert.ToDouble(txtTorqSetting.Text), torque_value_double);
                deviation = RoundToPrecision(deviation, 4) * 100;

                double precalThreshold = Convert.ToDouble(GetThresholds()[0]); // Call GetThresholds as a method
                double postcalThreshold = Convert.ToDouble(GetThresholds()[1]); // Call GetThresholds as a method

                string input = txtTorqSetting.Text;
                double desiredVal = 0;

                if (double.TryParse(input, out double result))
                {
                    desiredVal = double.Parse(input);
                }

                double threshold = postcalThreshold;
                if (isPre)
                {
                    threshold = precalThreshold;
                }

                double cal_lowerspec = RoundToPrecision(desiredVal * (100 - threshold) / 100, 5);
                double cal_upperspec = RoundToPrecision(desiredVal * (100 + threshold) / 100, 5);

                if (cal_lowerspec > torque_value_double || torque_value_double > cal_upperspec)
                {
                    status = "FAIL";
                }
                else
                {
                    status = "PASS";
                }

                // Create a new row
                DataGridViewRow row = new DataGridViewRow();

                // Add cells to the row
                row.Cells.Add(new DataGridViewTextBoxCell { Value = rowCount });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = torque_value_double.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = deviation.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = status.ToString() });
                // Add more cells as needed


                // Add the row to the DataGridView
                gridview.Rows.Add(row);
                btnComplete.Text = "Complete (" + rowCount + "/5) ";
                if (rowCount == 5)
                {
                    btnComplete.Enabled = true;
                }
                if (isPre)
                {
                    GetMinAndMax(lblPreMax, lblPreMin, lblPreAverage, PredataGridView, lblPreOverallStatus);
                }
                else
                {
                    GetMinAndMax(lblPostMax, lblPostMin, lblPostAverage, PostdataGridView, lblPostOverallStatus);
                }
            }

            btnRead.Text = "Read";
            txtValue.Text = "";
            txtValue.Focus();
        }


        public override void loadReadings(bool readingsExists, int isPreCal, DataGridView dataGridView, Button btnComplete, Button btnRead)
        {
            base.loadReadings(readingsExists,isPreCal, dataGridView, btnComplete, btnRead);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    // Check if a record with the specified TrackingID and complete=1 exists
                    string checkQuery = "SELECT COUNT(*) FROM caldata WHERE FormID = @FormID AND `Complete` = 1";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@FormID", formID);

                    int countComplete = Convert.ToInt32(checkCommand.ExecuteScalar());

                    // Check if a record with the specified TrackingID and complete=1 exists
                    string checkQuery2 = "SELECT COUNT(*) FROM caldata WHERE FormID = @FormID AND `Submitted` = 1";
                    MySqlCommand checkCommand2 = new MySqlCommand(checkQuery2, connection);
                    checkCommand2.Parameters.AddWithValue("@FormID", formID);

                    int countSubmit = Convert.ToInt32(checkCommand2.ExecuteScalar());

                    if (countComplete <= 0 || isPreCal == 0)
                    {
                        txtPostValue.Focus(); // to focus on the post
                    }
                    else if (countComplete > 0)
                    {
                        btnReport.Visible = true;
                        if (countSubmit <= 0)
                        {
                            btnSaphire.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
            }
        }

        public void btnSaveTorqueSetting_Click(object sender, EventArgs e)
        {
            txtPreValue.Focus();
        }

        public override void btnPreComplete_Click(object sender, EventArgs e)
        {
            base.btnPreComplete_Click (sender, e);
            txtPostValue.Focus();
        }

        public override void actualSapphireClick(object sender, EventArgs e)
        {
            uploadToSapphire("HIOS");

        }
    }
}
