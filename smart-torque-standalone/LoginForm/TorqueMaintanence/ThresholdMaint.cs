using ActiproSoftware.UI.WinForms.Controls.Commands;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginForm
{
    public partial class ThresholdMaint : Form
    {
        DB db = new DB();

        public ThresholdMaint()
        {
            InitializeComponent();
            this.Load += Thresh_Form_Load;
        }

        public void Thresh_Form_Load(object sender, EventArgs e)
        {
            lblNewDate.Text = Convert.ToString(DateTime.Now);
            lblLastDate.Text = Convert.ToString(DateTime.Now);
            // Load data from the database into a DataGridView
            string precalThreshold = Convert.ToString(GetThresholds()[0]); // Call GetThresholds as a method
            string postcalThreshold = Convert.ToString(GetThresholds()[1]);
            string lastdate  = Convert.ToString(GetThresholds()[2]);

            lblPre.Text = precalThreshold;
            lblPost.Text = postcalThreshold;
            lblLastDate.Text = lastdate;

            Console.WriteLine(UserDetails.Username);
        }

        public string[] GetThresholds()
        {
            List<string> results = new List<string>();
            TorqueThreshold latestTorqueThreshold = new TorqueThreshold();

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM torq_threshold ORDER BY UserTorqId DESC LIMIT 1", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                latestTorqueThreshold = new TorqueThreshold(reader);
                            }
                        }
                        else
                        {
                            // throw new Exception(" didnt detect any entries in the torque control table");
                            results.Add("No Value");
                            return results.ToArray();
                        }
                    }
                }
            }
            results.Add(latestTorqueThreshold.precal_threshold.ToString());
            results.Add(latestTorqueThreshold.postcal_threshold.ToString());
            results.Add(latestTorqueThreshold.date.ToString());
            return results.ToArray();
        }

        private void btnSaveTorqueSetting_Click(object sender, EventArgs e)
        {
            string pre = txtPre.Text;
            string post = txtPost.Text;
            string user = UserDetails.Username;
            DateTime currentDateTime = DateTime.Now; // Replace with your actual DateTime object

            string formattedDate = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            if (double.TryParse(pre, out double preValue) && double.TryParse(post, out double postValue))
            {
                string insertQuery = $"INSERT INTO torq_threshold (PreCal, PostCal, LastUpdated, DoneBy) VALUES ('{preValue}', '{postValue}',  '{formattedDate}', '{user}')";
                db.QueryScalar(insertQuery);
                MessageBox.Show("Thresholds updated!");

                string precalThreshold = Convert.ToString(GetThresholds()[0]); // Call GetThresholds as a method
                string postcalThreshold = Convert.ToString(GetThresholds()[1]);
                string lastdate = Convert.ToString(GetThresholds()[2]);

                lblPre.Text = precalThreshold;
                lblPost.Text = postcalThreshold;
                lblLastDate.Text = lastdate;
            }
            else
            {
                // Handle the case where pre or post are not valid numbers
                MessageBox.Show("Pre or Post values are not valid numbers.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

public class TorqueThreshold
{
    public double precal_threshold { get; set; }
    public double postcal_threshold { get; set; }
    public DateTime date { get; set; }


    public TorqueThreshold()
    {
        precal_threshold = double.PositiveInfinity;
        postcal_threshold = double.PositiveInfinity;
        date = DateTime.Now;
    }

    public TorqueThreshold(MySqlDataReader data)

    {
        precal_threshold = Int32.Parse(data["PreCal"].ToString());
        postcal_threshold = Int32.Parse(data["Postcal"].ToString());
        DateTime? dateValue = data["LastUpdated"] as DateTime?;
        date = dateValue.Value;
    }
}
