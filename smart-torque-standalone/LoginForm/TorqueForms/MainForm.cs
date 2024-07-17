using FTD2XX_NET;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LoginForm;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using TextBox = System.Windows.Forms.TextBox;


namespace CedarTorque
{
    public partial class MainForm : Form
    {
        DB db = new DB();
        string formID = null;
        string equipID = null;
        string torqCalID = null;
        double? torqSet = null;
        DateTime? startCalDate = null;
        string location = null;
        string doneBy = null;
        string trackingIdForm = null;
        private const int timeoutInSeconds = 15;
        private int remainingTime = timeoutInSeconds;
        private Timer countdownTimer;


        public MainForm()
        {
            InitializeComponent();
            // Attach the TextChanged event handler
            txtTorqSetting.TextChanged += txtTorqSetting_TextChanged;
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            // Load data from the database into a DataGridView
            lblFormID.Visible = true;
            lblCalDate.Visible = true;
            lblDoneBy.Text = "anonymous";
            lblCalDate.Text = DateTime.Now.ToString("dd MMM yyyy");
            double precalThreshold = Convert.ToDouble(GetThresholds()[0]); // Call GetThresholds as a method
            double postcalThreshold = Convert.ToDouble(GetThresholds()[1]); // Call GetThresholds as a method
            groupBox1.Text = "Precal Stage (±" + precalThreshold + "%)";
            groupBox2.Text = "Postcal Stage (±" + postcalThreshold + "%)";

            if (!UserDetails.Username.ToString().IsNullOrWhiteSpace())
            {
                lblDoneBy.Text = UserDetails.Username;
            }
            RefreshTorqCalIDs();
            getFormID();
            loadFromLocalVar();
        }

        private string MapLegacyDeptCodeToPLCode(string dept)
        {
            string PLCode = "";
            var query = "select * from dept where dept ='" + dept + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PLCode = reader["product_line"].ToString();
                        }
                    }
                }
            }
            return PLCode;
        }

        private string MapTrackingIDToServiceID(string trackingID)
        {
            string serviceID = "";
            var query = "select * from tracking where tracking_id ='" + trackingID + "'";


            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();

                string query1 = "SELECT * FROM tracking_source WHERE TrackingID = @trackingID";
                MySqlCommand command = new MySqlCommand(query1, connection);
                command.Parameters.AddWithValue("@trackingID", trackingIdForm);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            serviceID = reader["ServiceID"].ToString();
                        }
                    }
                }
            }
            return serviceID;
        }

        private string MapTrackingIDToModelID(string trackingID)
        {
            string modelID = "";
            var query = "select * from tracking where tracking_id ='" + trackingID + "'";


            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();

                string query1 = "SELECT * FROM tracking_source WHERE TrackingID = @trackingID";
                MySqlCommand command = new MySqlCommand(query1, connection);
                command.Parameters.AddWithValue("@trackingID", trackingIdForm);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            modelID = reader["ModelID"].ToString();
                        }
                    }
                }
            }
            return modelID;
        }

        private string MapTrackingIDToSerialNumber(string trackingID)
        {
            string serialno = "";
            var query = "select * from tracking where tracking_id ='" + trackingID + "'";


            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();

                string query1 = "SELECT * FROM tracking_source WHERE TrackingID = @trackingID";
                MySqlCommand command = new MySqlCommand(query1, connection);
                command.Parameters.AddWithValue("@trackingID", trackingIdForm);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            serialno = reader["SerialNumber"].ToString();
                        }
                    }
                }
            }
            return serialno;
        }

        // load form pre-filled details.
        public void loadFromSapphire(string trackingid, String equipmentid, String locationParam, double torqSetting)
        {
            if (CheckTrackingIDExists(trackingid, "caldata"))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        string query = "SELECT * FROM caldata WHERE TrackingID = @TrackingID";
                        MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TrackingID", trackingid);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve values from the record
                                formID = reader["FormID"].ToString();
                                equipID = reader["EquipID"].ToString();
                                torqCalID = reader["TorqCalID"].ToString();
                                torqSet = Convert.ToDouble(reader["TorqSet"]);
                                startCalDate = Convert.ToDateTime(reader["StartCalDate"]);
                                location = reader["Location"].ToString();
                                doneBy = reader["DoneBy"].ToString();
                                trackingIdForm = trackingid;


                                Console.WriteLine(formID + equipID + torqCalID + torqSet + startCalDate + location + doneBy);

                            }
                            else
                            {
                                MessageBox.Show("TrackingID not found in caldata table.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g., show an error message
                    MessageBox.Show("Error retrieving record: " + ex.Message);
                }
            }
            else
            {
                txtEqID.Text = equipmentid;
                txtLocation.Text = locationParam;
                trackingIdForm = trackingid;
                txtTorqSetting.Text = torqSetting.ToString();
                Console.WriteLine(equipmentid + locationParam + trackingid);
            }
        }

        public void loadFromLocal(string formIDLocal, String equipmentid, String locationParam)
        {
            if (CheckFormIDExists(formIDLocal, "caldata"))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        string query = "SELECT * FROM caldata WHERE formID = @formIDLocal";
                        MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@formIDLocal", formIDLocal);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve values from the record
                                formID = reader["FormID"].ToString();
                                equipID = reader["EquipID"].ToString();
                                torqCalID = reader["TorqCalID"].ToString();
                                torqSet = Convert.ToDouble(reader["TorqSet"]);
                                startCalDate = Convert.ToDateTime(reader["StartCalDate"]);
                                location = reader["Location"].ToString();
                                doneBy = reader["DoneBy"].ToString();
                                trackingIdForm = null;


                                Console.WriteLine(formID + equipID + torqCalID + torqSet + startCalDate + location + doneBy);

                            }
                            else
                            {
                                MessageBox.Show("TrackingID not found in caldata table.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g., show an error message
                    MessageBox.Show("Error retrieving record: " + ex.Message);
                }
            }
        }

        private async Task<bool> CheckInternetConnectionWithTimeout()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Timer ticks every second
            countdownTimer.Tick += CountdownTimer_Tick;

            Task<bool> checkConnectionTask = Task.Run(() => CheckInternetConnection());

            countdownTimer.Start();

            bool isConnected = await CheckInternetConnectionWithTimeout();

            countdownTimer.Stop();

            return isConnected;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            Console.WriteLine($"Time left: {remainingTime} seconds");

            if (remainingTime <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("Operation timed out. Please try again.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string connectionString =
          "Data Source=WPNGDBA4;" +
          "Initial Catalog=SAPPHIRE_NET;" +
          "User id=sapp;" +
          "Password=KeysightTechnologies2023!@;";

        public void actualSapphireClick(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    // Update the complete column to 1 where TrackingID matches a specific value
                    string updateQuery = "UPDATE caldata SET `submitted` = 1 WHERE FormID = @FormID";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@FormID", formID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Updated {rowsAffected} record(s) for TrackingID: {trackingIdForm}");
                        // Refresh or update your DataGridView or perform other actions if needed
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                string updateQuery = "UPDATE tracking_source SET Status = 'SUBMITTED' WHERE TrackingID = @TrackingID";

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check the number of rows affected if needed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors here
            }

            // Check for internet connectivity
            bool isConnected = CheckInternetConnection();
            Console.WriteLine("iNTERNET :" + isConnected);

            if (isConnected)
            {
                String formStatus = "Pending";
                String torqModel = "CEDAR";
                String dbFormID = GetLatestFormID();
                String dept = MapLegacyDeptCodeToPLCode(location);
                String serviceID = MapTrackingIDToServiceID(trackingIdForm);
                String modelID = MapTrackingIDToModelID(trackingIdForm);
                String serialNo = MapTrackingIDToSerialNumber(trackingIdForm);
                DateTime StartDate = DateTime.Now;
                String formattedDateTime = StartDate.ToString("yyyy-MM-dd HH:mm:ss");

                Console.WriteLine(dept + serviceID + modelID);

                // insert form header
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"INSERT INTO [dbo].[torq_measure]
                                   ([form_id], [equip_id], [ae_id], [calibrator_id],
                                    [start_cal_date], [location], [form_status],
                                    [torq_model], [tracking_id])
                                   VALUES
                                   (@form_id, @equip_id, @ae_id, @calibrator_id,
                                    @start_cal_date, @location, @form_status,
                                    @torq_model, @tracking_id)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@form_id", dbFormID);
                        command.Parameters.AddWithValue("@equip_id", equipID);
                        command.Parameters.AddWithValue("@ae_id", doneBy);
                        command.Parameters.AddWithValue("@calibrator_id", torqCalID);
                        command.Parameters.AddWithValue("@start_cal_date", startCalDate);
                        command.Parameters.AddWithValue("@location", location);
                        command.Parameters.AddWithValue("@form_status", formStatus);
                        command.Parameters.AddWithValue("@torq_model", torqModel);
                        command.Parameters.AddWithValue("@tracking_id", trackingIdForm);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Console.WriteLine("Insertion successful!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            // Handle exception as needed
                        }
                    }


                    try
                    {
                        using (MySqlConnection localcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                        {
                            connection.Open();

                            // Update the complete column to 1 where TrackingID matches a specific value
                            string updateQuery = "UPDATE tracking_source SET `SapphireFormID` = @FormID WHERE TrackingID = @TrackingID";
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, localcon);
                            updateCommand.Parameters.AddWithValue("@FormID", dbFormID);
                            updateCommand.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {                                
                                // Refresh or update your DataGridView or perform other actions if needed
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery2 = @"INSERT INTO [dbo].[torq_target]
                                   ([form_id], [equip_id], [target_val], [user_id],
                                    [created_at])
                                   VALUES
                                   (@form_id, @equip_id, @target, @user_id,
                                    @created_time)";

                    using (SqlCommand command = new SqlCommand(sqlQuery2, connection))
                    {
                        command.Parameters.AddWithValue("@form_id", dbFormID);
                        command.Parameters.AddWithValue("@equip_id", equipID);
                        command.Parameters.AddWithValue("@target", torqSet);
                        command.Parameters.AddWithValue("@user_id", doneBy);
                        command.Parameters.AddWithValue("@created_time", formattedDateTime);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Console.WriteLine("Insertion successful!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            // Handle exception as needed
                        }
                    }
                }

                insertRecordsToSapphire(PredataGridView, "precal", dbFormID, formStatus);

                if (PostdataGridView.Enabled == true)
                {
                    insertRecordsToSapphire(PostdataGridView, "postcal", dbFormID, formStatus);
                }


                string encodedEquipID = HttpUtility.UrlEncode(equipID);
                string encodedSerialNo = HttpUtility.UrlEncode(serialNo);
                string encodedModelID = HttpUtility.UrlEncode(modelID);
                string encodedServiceID = HttpUtility.UrlEncode(serviceID);
                string encodedDept = HttpUtility.UrlEncode(dept);
                string encodedLocation = HttpUtility.UrlEncode(location);
                string encodedTorqModel = HttpUtility.UrlEncode(torqModel);

                string linkToOpen = $"http://localhost:52207/Testing/StephenNg/caltest_HIOS.aspx?number=1" +
                    $"&equip_id={encodedEquipID}" +
                    $"&model_id={encodedModelID}" +
                    $"&serial_no={encodedSerialNo}" +
                    $"&service_id={encodedServiceID}" +
                    $"&pl={encodedDept}" +
                    $"&dept={encodedDept}{encodedLocation}" +
                    $"&due_date=&torq_model={encodedTorqModel}"; OpenLinkInBrowser(linkToOpen);

                btnSaphire.Visible = false;
            }
            else
            {
                MessageBox.Show("No internet connection. Please try again later.");
                // Handle no internet connection scenario
            }

        }

        public void sapphireBulkUpload(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    // Update the complete column to 1 where TrackingID matches a specific value
                    string updateQuery = "UPDATE caldata SET `submitted` = 1 WHERE FormID = @FormID";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@FormID", formID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Updated {rowsAffected} record(s) for TrackingID: {trackingIdForm}");
                        // Refresh or update your DataGridView or perform other actions if needed
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                string updateQuery = "UPDATE tracking_source SET Status = 'SUBMITTED' WHERE TrackingID = @TrackingID";

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check the number of rows affected if needed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors here
            }

            // Check for internet connectivity
            bool isConnected = CheckInternetConnection();
            Console.WriteLine("iNTERNET :" + isConnected);

            if (isConnected)
            {
                String formStatus = "Pending";
                String torqModel = "CEDAR";
                String dbFormID = GetLatestFormID();
                String dept = MapLegacyDeptCodeToPLCode(location);
                String serviceID = MapTrackingIDToServiceID(trackingIdForm);
                String modelID = MapTrackingIDToModelID(trackingIdForm);
                String serialNo = MapTrackingIDToSerialNumber(trackingIdForm);
                DateTime StartDate = DateTime.Now;
                String formattedDateTime = StartDate.ToString("yyyy-MM-dd HH:mm:ss");

                Console.WriteLine(dept + serviceID + modelID);

                // insert form header
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"INSERT INTO [dbo].[torq_measure]
                                   ([form_id], [equip_id], [ae_id], [calibrator_id],
                                    [start_cal_date], [location], [form_status],
                                    [torq_model], [tracking_id])
                                   VALUES
                                   (@form_id, @equip_id, @ae_id, @calibrator_id,
                                    @start_cal_date, @location, @form_status,
                                    @torq_model, @tracking_id)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@form_id", dbFormID);
                        command.Parameters.AddWithValue("@equip_id", equipID);
                        command.Parameters.AddWithValue("@ae_id", doneBy);
                        command.Parameters.AddWithValue("@calibrator_id", torqCalID);
                        command.Parameters.AddWithValue("@start_cal_date", startCalDate);
                        command.Parameters.AddWithValue("@location", location);
                        command.Parameters.AddWithValue("@form_status", formStatus);
                        command.Parameters.AddWithValue("@torq_model", torqModel);
                        command.Parameters.AddWithValue("@tracking_id", trackingIdForm);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Console.WriteLine("Insertion successful!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            // Handle exception as needed
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery2 = @"INSERT INTO [dbo].[torq_target]
                                   ([form_id], [equip_id], [target_val], [user_id],
                                    [created_at])
                                   VALUES
                                   (@form_id, @equip_id, @target, @user_id,
                                    @created_time)";

                    using (SqlCommand command = new SqlCommand(sqlQuery2, connection))
                    {
                        command.Parameters.AddWithValue("@form_id", dbFormID);
                        command.Parameters.AddWithValue("@equip_id", equipID);
                        command.Parameters.AddWithValue("@target", torqSet);
                        command.Parameters.AddWithValue("@user_id", doneBy);
                        command.Parameters.AddWithValue("@created_time", formattedDateTime);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Console.WriteLine("Insertion successful!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            // Handle exception as needed
                        }
                    }
                }

                insertRecordsToSapphire(PredataGridView, "precal", dbFormID, formStatus);

                if (PostdataGridView.Enabled == true)
                {
                    insertRecordsToSapphire(PostdataGridView, "postcal", dbFormID, formStatus);
                }

                using (MySqlConnection localcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    localcon.Open();

                    // Update the complete column to 1 where TrackingID matches a specific value
                    string updateQuery = "UPDATE tracking_source SET `SapphireFormID` = @FormID WHERE TrackingID = @TrackingID";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, localcon);
                    updateCommand.Parameters.AddWithValue("@FormID", dbFormID);
                    updateCommand.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Refresh or update your DataGridView or perform other actions if needed
                    }
                }


                btnSaphire.Visible = false;
            }
            else
            {
                MessageBox.Show("No internet connection. Please try again later.");
                // Handle no internet connection scenario
            }

        }

        public bool CheckInternetConnection()
        {
            try
            {
                // Ping a well-known server, like Google's DNS server, to check connectivity
                Ping ping = new Ping();
                PingReply reply = ping.Send("8.8.8.8"); // Google DNS server IP address

                if (reply != null && reply.Status == IPStatus.Success)
                {
                    // Internet connection is available
                    return true;
                }
                else
                {
                    // No internet connection
                    return false;
                }
            }
            catch (PingException)
            {
                // Exception occurred, possibly due to no internet connection
                return false;
            }
        }

        public void insertRecordsToSapphire(DataGridView dataGridView, String stage, String dbFormID, String formStatus)
        {
            //insert records pre-cal
            // iterate thro8ugh rows and insert them into the sql
            foreach (DataGridViewRow row in dataGridView.Rows)
            {

                if (row.Index < 5)
                {

                    double torqueReadingVal = Convert.ToDouble(row.Cells[1].Value);
                    double deviation = Convert.ToDouble(row.Cells[2].Value);
                    String status = Convert.ToString(row.Cells[3].Value);
                    DateTime submitTime = DateTime.Now;
                    DateTime measureDT = DateTime.Now;
                    String calStage = stage;



                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string sqlQuery = @"INSERT INTO [dbo].[torq_measure_details]
                                   ([form_id], [torque_reading], [submit_cal_date], [measure_dt], [status],
                                    [cal_stage])
                                   VALUES
                                   (@form_id, @torque_reading, @submit_cal_date, @measure_dt
                                   , @status, @cal_stage)";

                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            command.Parameters.AddWithValue("@form_id", dbFormID);
                            command.Parameters.AddWithValue("@torque_reading", torqueReadingVal);
                            command.Parameters.AddWithValue("@submit_cal_date", submitTime);
                            command.Parameters.AddWithValue("@measure_dt", measureDT);
                            command.Parameters.AddWithValue("@status", status);
                            command.Parameters.AddWithValue("@cal_stage", calStage);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                Console.WriteLine("Insertion successful!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                                // Handle exception as needed
                            }
                        }
                    }


                }
            }
        }

        public String GetLatestFormID()
        {
            String latestFormID = "TOQ000001"; // Default value if no FormID is found

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MAX(form_id) AS LatestFormID FROM torq_measure";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                latestFormID = Convert.ToString(result);

                if (result != null && result != DBNull.Value)
                {
                    int maxFormID;
                    if (int.TryParse(latestFormID.Substring(3), out maxFormID))
                    {
                        // Increment the maximum form_id by 1 for the next form
                        int nextID = maxFormID + 1;
                        latestFormID = "TOQ" + nextID.ToString("D6");
                    }
                }
            }
            return latestFormID;
        }

        private void OpenLinkInBrowser(string url)
        {
            DialogResult result = MessageBox.Show("Do you want to open this link in a browser?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening link: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void loadFromLocalVar()
        {
            if (!string.IsNullOrEmpty(formID))
            {
                lblFormID.Text = formID;

                // Search for the item in the ComboBox
                int index = comboBoxTorqCalID.FindString(torqCalID.ToString());
                comboBoxTorqCalID.SelectedIndex = index;

                txtEqID.Text = equipID.ToString();
                txtTorqSetting.Text = torqSet.ToString();

                lblDoneBy.Text = doneBy.ToString();
                lblCalDate.Text = startCalDate.ToString();
                txtLocation.Text = location.ToString();

                if (ValidateTextBoxes() && comboBoxTorqCalID.SelectedItem != null)
                {
                    var textBoxList = new List<System.Windows.Forms.TextBox> { txtEqID, txtLocation, txtTorqSetting };
                    DisableTextBoxes(textBoxList);
                    comboBoxTorqCalID.Enabled = false;
                    btnSaveTorqueSetting.Enabled = false;
                }
            }
            bool preExists = false;
            bool postExists = false;

            if (CheckTrackingIDExists(trackingIdForm, "readdata"))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        string query = "SELECT COUNT(*) FROM readdata WHERE TrackingID = @TrackingID AND IsPreCal = 1";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine(count.ToString());

                        preExists = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        string query = "SELECT COUNT(*) FROM readdata WHERE TrackingID = @TrackingID AND IsPreCal = 0";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        postExists = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                }

            }

            if (CheckFormIDExists(formID, "readdata"))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        string query = "SELECT COUNT(*) FROM readdata WHERE formID = @formID AND IsPreCal = 1";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@formID", formID);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine(count.ToString());

                        preExists = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        string query = "SELECT COUNT(*) FROM readdata WHERE formID = @formID AND IsPreCal = 0";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@formID", formID);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        postExists = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                }

            }

            loadReadings(preExists, 1, PredataGridView, btnPreComplete, btnPreRead);
            loadReadings(postExists, 0, PostdataGridView, btnPostComplete, btnPostRead);
        }


        private void loadReadings(bool readingsExists, int isPreCal, DataGridView dataGridView, Button btnComplete, Button btnRead)
        {
            if (readingsExists)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();
                        string query = "SELECT * FROM readdata WHERE TrackingID = @TrackingID AND IsPreCal = " + isPreCal + " ORDER BY ReadIndex ASC";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm); // Pass your trackingID here
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            int index = 1;
                            while (reader.Read())
                            {
                                // Retrieve values from the record
                                string readIndex = Convert.ToString(index);
                                decimal readVal = Convert.ToDecimal(reader["ReadVal"]);
                                decimal deviation = Convert.ToDecimal(reader["Deviation"]);
                                string status = reader["Status"].ToString();

                                // Create a new row
                                DataGridViewRow row = new DataGridViewRow();

                                // Add cells to the row
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = readIndex.ToString() });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = readVal.ToString() });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = deviation.ToString() });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = status });

                                dataGridView.Rows.Add(row);
                                index++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }



                btnComplete.Text = "Complete (" + 5 + "/5) ";
                btnComplete.Enabled = false;
                btnRead.Enabled = false;


                // check if complete already
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
                            groupBox2.Visible = true;
                            btnPostRead.Visible = true;
                            btnPostRead.Enabled = true;
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

                if (isPreCal != 1)
                {
                    groupBox2.Visible = true;
                    btnPostRead.Visible = false;
                }
            }

        }

        private bool CheckTrackingIDExists(string trackingID, String db)
        {
            bool exists = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM " + db + " WHERE TrackingID = @TrackingID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TrackingID", trackingID);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    exists = (count > 0);
                }
            }
            catch (Exception ex)
            {
            }

            return exists;
        }

        private bool CheckFormIDExists(string formID, String db)
        {
            bool exists = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM " + db + " WHERE formID = @formID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@formID", formID);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    exists = (count > 0);
                }
            }
            catch (Exception ex)
            {
            }

            return exists;
        }


        private void getFormID()
        {
            string nextFormID = "LOC000001";

            using (MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                mySqlConnection.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT IFNULL(MAX(FormID), 0) AS max_form_id FROM caldata", mySqlConnection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            string maxFormIDString = reader["max_form_id"].ToString();
                            if (!string.IsNullOrEmpty(maxFormIDString) && maxFormIDString.Length >= 3)
                            {
                                int maxFormID;
                                if (int.TryParse(maxFormIDString.Substring(3), out maxFormID))
                                {
                                    // Increment the maximum form_id by 1 for the next form
                                    int nextID = maxFormID + 1;
                                    nextFormID = "LOC" + nextID.ToString("D6");
                                }

                            }
                        }
                    }
                }
            }

            // Use nextFormID in your application logic or assign it to a label, textbox, etc.
            lblFormID.Text = nextFormID;
        }

        public void RefreshTorqCalIDs()
        {
            // Clear existing items in the ComboBox
            comboBoxTorqCalID.Items.Clear();

            // Fetch and load the updated list of TorqCalIDs into the ComboBox
            string selectQuery = "SELECT TorqCalID FROM torqequip";

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxTorqCalID.Items.Add(reader["TorqCalID"].ToString());
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void btnPreRead_Click(object sender, EventArgs e)
        {
            btnRead(btnPreRead, txtPreValue, PredataGridView, lblPreUpperSpec, lblPreLowerSpec, true, btnPreComplete);
        }

        private void btnPostRead_Click(object sender, EventArgs e)
        {
            btnRead(btnPostRead, txtPostValue, PostdataGridView, lblPostUpperSpec, lblPostLowerSpec, false, btnPostComplete);
        }

        private async void btnRead(Button btnRead, TextBox txtValue, DataGridView gridview, Label lblUpperSpec, Label lblLowerSpec, bool isPre, Button btnComplete)
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

            btnRead.Text = "Waiting..."; // Change the button's text in your ASP.NET code-behind
            double torque_value_double = 0.00;
            txtValue.Text = torque_value_double.ToString();
            await Task.Run(() =>
            {
                string serialNumber = "";
                string torque_value = "";

                byte[] dataBuffer;
                uint numBytesToRead = 0;
                uint numBytesRead = 0;

                FTDI myFtdiDevice = new FTDI();
                FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
                UInt32 ftdiDeviceCount = 1;
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

                ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    if (ftdiDeviceCount == 1)
                    {
                        // Get serial number from device list
                        ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

                        if (ftStatus == FTDI.FT_STATUS.FT_OK)
                        {
                            serialNumber = ftdiDeviceList[0].SerialNumber.ToString();
                            //for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                            //{
                            //    serialNumber = ftdiDeviceList[i].SerialNumber.ToString();
                            //}
                        }
                    }
                }

                // Open the device by serial number
                ftStatus = myFtdiDevice.OpenBySerialNumber(serialNumber);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    // Set device parameters
                    ftStatus = myFtdiDevice.SetBaudRate(19200);
                    ftStatus = myFtdiDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_2, FTDI.FT_PARITY.FT_PARITY_NONE);
                    ftStatus = myFtdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_NONE, 0X00, 0X00);
                    //counting = true;
                }

                bool showAlert = true; string error_msg = "";
                do
                {
                    ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesToRead);
                    error_msg = ftStatus.ToString();

                    if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    {
                        dataBuffer = new byte[numBytesToRead];

                        ftStatus = myFtdiDevice.Read(dataBuffer, numBytesToRead, ref numBytesRead);

                        if (ftStatus == FTDI.FT_STATUS.FT_OK)
                        {
                            // FT_Read OK
                            byte[] receivedData = new byte[numBytesRead];
                            Array.Copy(dataBuffer, receivedData, numBytesRead);

                            // Convert bytes to string using the appropriate encoding
                            string receivedText = System.Text.Encoding.ASCII.GetString(receivedData);

                            // To extract the symbol and torque value
                            string plusminus_symbol = "";
                            string pattern = @"(?:\+|\-)\s+(\d+(?:\.\d+)?)";

                            Match match = Regex.Match(receivedText, pattern);
                            if (match.Success)
                            {
                                plusminus_symbol = match.Value.Substring(0, 1);
                                torque_value = match.Groups[1].Value;
                                torque_value_double = Convert.ToDouble(torque_value);
                            }
                            showAlert = false;
                        }
                        else
                        {
                            showAlert = true;
                            break;
                        }
                    }
                    else
                    {
                        showAlert = true;
                        break;
                    }
                    //await Task.Delay(1000);
                } while (torque_value == "" && ftStatus == FTDI.FT_STATUS.FT_OK);

                if (showAlert)
                {
                    if (txtValue.InvokeRequired)
                    {
                        // If this code is running on a different thread, marshal the call to the UI thread.
                        txtValue.Invoke(new Action(() => txtValue.Text = error_msg.ToString()));
                    }
                    else
                    {
                        // If this code is already on the UI thread, you can directly update the control.
                        txtValue.Text = error_msg.ToString();
                    }
                }

                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    serialNumber = "";
                }

                ftStatus = myFtdiDevice.Close();
            });

            int rowCount = gridview.RowCount;
            txtValue.Text = torque_value_double.ToString();
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
        }

        private string previousText = string.Empty;

        private bool IsAnyTextBoxEmpty(params System.Windows.Forms.TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show($"Please enter all textboxes.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        private bool ValidateTextBoxes()
        {
            if (IsAnyTextBoxEmpty(txtEqID, txtLocation, txtTorqSetting) && comboBoxTorqCalID.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private void txtTorqSetting_TextChanged(object sender, EventArgs e)
        {
            string currentText = txtTorqSetting.Text;
            if (currentText != previousText)
            {
                double precalThreshold = Convert.ToDouble(GetThresholds()[0]); // Call GetThresholds as a method
                double postcalThreshold = Convert.ToDouble(GetThresholds()[1]); // Call GetThresholds as a method

                string input = txtTorqSetting.Text;
                double desiredVal = 0;

                if (double.TryParse(input, out double result))
                {
                    desiredVal = double.Parse(input);
                }

                double precal_lowerspec = RoundToPrecision(desiredVal * (100 - precalThreshold) / 100, 5);
                double precal_upperspec = RoundToPrecision(desiredVal * (100 + precalThreshold) / 100, 5);
                double postcal_lowerspec = RoundToPrecision(desiredVal * (100 - postcalThreshold) / 100, 5);
                double postcal_upperspec = RoundToPrecision(desiredVal * (100 + postcalThreshold) / 100, 5);


                if (txtTorqSetting.Text == "0.00" || txtTorqSetting.Text == "0")
                {
                    lblPreLowerSpec.Text = "0.00";
                    lblPreUpperSpec.Text = "0.00";
                    lblPostUpperSpec.Text = "0.00";
                    lblPostLowerSpec.Text = "0.00";

                }
                else
                {
                    lblPreLowerSpec.Text = precal_lowerspec.ToString();
                    lblPreUpperSpec.Text = precal_upperspec.ToString();
                    lblPostLowerSpec.Text = postcal_lowerspec.ToString();
                    lblPostUpperSpec.Text = postcal_upperspec.ToString();
                }
            }
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
            return results.ToArray();
        }

        // precision is 5 throughout the code, XXe+5
        // decimal moves to right follow the precision value 
        // and then Math.round rounds number to the nearest integer
        // the decimal of nearest integer moves to left follow the precision value 
        // + in front return result in 'number' instead of "string"
        // at the end, return a number with "precision1" decimal place
        // precision determine the number of decimal place
        public double RoundToPrecision(double num, int precision)
        {
            return Math.Round(num, precision);
        }

        public double CalculateDeviation(double targetVal, double reading)
        {
            return (reading - targetVal) / targetVal;
        }

        public bool CheckValidReading(double thresholdPercent, double targetVal, double reading, bool debugFlag, int precision)
        {
            try
            {
                double absDeviation = Math.Abs(CalculateDeviation(targetVal, reading));
                absDeviation = RoundToPrecision(absDeviation, precision);
                bool flag = (absDeviation * 100) <= thresholdPercent; // lesser or equals to threshold means valid

                if (debugFlag)
                {
                    Console.WriteLine($"Detected a {(flag ? "valid" : "invalid")} reading!");
                }

                return flag;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error caught");
            }
        }

        public void GetMinAndMax(Label lblMax, Label lblMin, Label lblAverage, DataGridView dataGrid, Label lblOverallStatus)
        {
            decimal max = 0; // Initialize with a very small value
            decimal min = 0; // Initialize with a very small value
            decimal total = 0;
            bool overallStatusIsFail = false;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (max == 0)
                {
                    max = Convert.ToDecimal(row.Cells[1].Value);
                }

                if (row.Cells[1].Value != null && row.Cells[1].Value != DBNull.Value)
                {
                    decimal cellValue = Convert.ToDecimal(row.Cells[1].Value);
                    if (cellValue > max)
                    {
                        max = cellValue;
                    }
                    total += cellValue;
                }
                Console.WriteLine(total);
            }

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (min == 0)
                {
                    min = Convert.ToDecimal(row.Cells[1].Value);
                }

                if (row.Cells[1].Value != null && row.Cells[1].Value != DBNull.Value)
                {
                    decimal cellValue = Convert.ToDecimal(row.Cells[1].Value);
                    if (cellValue < min)
                    {
                        min = cellValue;
                    }
                }
            }

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                Console.WriteLine(row.Cells[3].Value);
                if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "" && row.Cells[3].Value.ToString() == "FAIL")
                {
                    overallStatusIsFail = true;
                    break;
                }
            }

            lblMax.Text = max.ToString();
            lblMin.Text = min.ToString();
            lblAverage.Text = (total / 5).ToString();

            if (overallStatusIsFail)
            {
                lblOverallStatus.Text = "Fail";
            }
            else
            {
                lblOverallStatus.Text = "Pass";
            }
        }


        private void btnSaveTorqueSetting_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes() && comboBoxTorqCalID.SelectedItem != null)
            {
                var textBoxList = new List<System.Windows.Forms.TextBox> { txtEqID, txtLocation, txtTorqSetting };
                DisableTextBoxes(textBoxList);
                comboBoxTorqCalID.Enabled = false;
            }


            formID = lblFormID.Text;
            equipID = txtEqID.Text;
            torqCalID = comboBoxTorqCalID.SelectedItem.ToString();
            location = txtLocation.Text;
            torqSet = Convert.ToDouble(txtTorqSetting.Text);
            DateTime StartDate = DateTime.Now;
            String formattedDateTime = StartDate.ToString("yyyy-MM-dd HH:mm:ss");
            startCalDate = DateTime.Now;
            doneBy = UserDetails.Username;

            string insertQuery = $"INSERT INTO caldata (FormID, EquipID, TorqCalID, TorqSet, StartCalDate, Location, DoneBy, TrackingID) " +
                     $"VALUES (@FormID, @EquipID, @TorqCalID, @TorqSet, @StartCalDate, @Location, @DoneBy, @TrackingID) " +
                     $"ON DUPLICATE KEY UPDATE " +
                     $"EquipID = VALUES(EquipID), " +
                     $"TorqCalID = VALUES(TorqCalID), " +
                     $"TorqSet = VALUES(TorqSet), " +
                     $"StartCalDate = VALUES(StartCalDate), " +
                     $"Location = VALUES(Location), " +
                     $"DoneBy = VALUES(DoneBy), " +
                     $"TrackingID = VALUES(TrackingID)";

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    // Set parameters with appropriate values
                    command.Parameters.AddWithValue("@FormID", formID);
                    command.Parameters.AddWithValue("@EquipID", equipID);
                    command.Parameters.AddWithValue("@TorqCalID", torqCalID);
                    command.Parameters.AddWithValue("@TorqSet", torqSet);
                    command.Parameters.AddWithValue("@StartCalDate", startCalDate);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@DoneBy", doneBy);
                    command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                    command.ExecuteNonQuery();
                }
            }
            btnSaveTorqueSetting.Enabled = false;

            try
            {
                string updateQuery = "UPDATE tracking_source SET Status = 'STARTED' WHERE TrackingID = @TrackingID";

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        Console.WriteLine(command.ExecuteNonQuery());
                        // Check the number of rows affected if needed
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void DisableTextBoxes(List<System.Windows.Forms.TextBox> textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Enabled = false;
            }
        }


        private void btnPreReset_Click(object sender, EventArgs e)
        {
            txtTorqSetting.Enabled = false;
            btnPreComplete.Enabled = false;
            // Clear the DataGridView
            PredataGridView.DataSource = null;
            PredataGridView.Rows.Clear();

            lblPreMax.Text = "0";
            lblPreMin.Text = "0";
            lblPreAverage.Text = "0";
            lblPreOverallStatus.Text = "";
            btnPreComplete.Text = "Complete (" + 0 + "/5) ";

            btnPostComplete.Enabled = false;

            // Clear the DataGridView

            PostdataGridView.DataSource = null;
            PostdataGridView.Rows.Clear();

            lblPostMax.Text = "0";
            lblPostMin.Text = "0";
            lblPostAverage.Text = "0";
            lblPostOverallStatus.Text = "";
            btnPostComplete.Text = "Complete (" + 0 + "/5) ";
            groupBox2.Visible = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM readdata WHERE TrackingID = @TrackingID";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Deleted {rowsAffected} record(s) for TrackingID: {trackingIdForm}");
                        // Refresh or update your DataGridView or perform other actions if needed
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                string updateQuery = "UPDATE tracking_source SET Status = 'STARTED' WHERE TrackingID = @TrackingID";

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check the number of rows affected if needed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors here
            }

            lblFormID.Enabled = true;
            comboBoxTorqCalID.Enabled = true;
            txtEqID.Enabled = true;
            txtTorqSetting.Enabled = true;
            lblDoneBy.Enabled = true;
            lblCalDate.Enabled = true;
            txtLocation.Enabled = true;

            lblFormID.Text = formID;
            int index = comboBoxTorqCalID.FindString(torqCalID.ToString());
            comboBoxTorqCalID.SelectedIndex = index;

            txtEqID.Text = equipID.ToString();
            txtTorqSetting.Text = torqSet.ToString();

            lblDoneBy.Text = doneBy.ToString();
            lblCalDate.Text = startCalDate.ToString();
            txtLocation.Text = location.ToString();

            btnSaveTorqueSetting.Enabled = true;

        }

        private void btnPreComplete_Click(object sender, EventArgs e)
        {
            double postcalThreshold = Convert.ToDouble(GetThresholds()[1]); // Call GetThresholds as a method

            string input = txtTorqSetting.Text;
            double desiredVal = 0;

            if (double.TryParse(input, out double result))
            {
                desiredVal = double.Parse(input);
            }

            bool requirePostCal = false;
            List<List<object>> rowsToInsert = new List<List<object>>();
            foreach (DataGridViewRow row in PredataGridView.Rows)
            {
                if (row.Index < 5)
                {

                    double torqueReadingVal = Convert.ToDouble(row.Cells[1].Value);
                    double deviation = Convert.ToDouble(row.Cells[2].Value);
                    String status = Convert.ToString(row.Cells[3].Value);


                    Console.WriteLine(torqueReadingVal);
                    // Insert data and direct go to Post Calq
                    List<object> aRow = new List<object>();

                    // Adding values to the list
                    aRow.Add(torqueReadingVal);
                    aRow.Add(deviation);
                    aRow.Add(status);

                    rowsToInsert.Add(aRow);

                    if (CheckWithinPostcal(torqueReadingVal, desiredVal, postcalThreshold) == false)
                    {
                        requirePostCal = true;
                        //break;
                    }
                }
            }

            InsertData(rowsToInsert, desiredVal, 1);

            // groupBox2 is Post Cal
            if (requirePostCal)
            {
                groupBox2.Visible = true;
                btnReport.Visible = false;
            }
            else
            {
                // Can Proceed to Submit already
                btnReport.Visible = true;
                btnSaphire.Visible = true;
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        connection.Open();

                        // Update the complete column to 1 where TrackingID matches a specific value
                        string updateQuery = "UPDATE caldata SET `complete` = 1 WHERE FormID = @FormID";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@FormID", formID);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    string updateQuery = "UPDATE tracking_source SET Status = 'COMPLETE' WHERE TrackingID = @TrackingID";

                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            // Check the number of rows affected if needed
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions or errors here
                }

            }

            btnPreComplete.Enabled = false;
        }

        private void btnPostComplete_Click(object sender, EventArgs e)
        {
            double postcalThreshold = Convert.ToDouble(GetThresholds()[1]); // Call GetThresholds as a method

            string input = txtTorqSetting.Text;
            double desiredVal = 0;

            if (double.TryParse(input, out double result))
            {
                desiredVal = double.Parse(input);
            }

            List<List<object>> rowsToInsert = new List<List<object>>();
            foreach (DataGridViewRow row in PostdataGridView.Rows)
            {

                double torqueReadingVal = Convert.ToDouble(row.Cells[1].Value);
                double deviation = Convert.ToDouble(row.Cells[2].Value);
                String status = Convert.ToString(row.Cells[3].Value);


                Console.WriteLine(torqueReadingVal);
                // Insert data and direct go to Post Cal
                List<object> aRow = new List<object>();

                // Adding values to the list
                aRow.Add(torqueReadingVal);
                aRow.Add(deviation);
                aRow.Add(status);

                rowsToInsert.Add(aRow);
            }

            InsertData(rowsToInsert, desiredVal, 0);

            btnReport.Visible = true;
            btnSaphire.Visible = true;

            btnPostComplete.Enabled = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    // Update the complete column to 1 where TrackingID matches a specific value
                    string updateQuery = "UPDATE caldata SET `complete` = 1 WHERE FormID = @FormID";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@FormID", formID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Updated {rowsAffected} record(s) for TrackingID: {trackingIdForm}");
                        // Refresh or update your DataGridView or perform other actions if needed
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                string updateQuery = "UPDATE tracking_source SET Status = 'COMPLETE' WHERE TrackingID = @TrackingID";

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackingID", trackingIdForm);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check the number of rows affected if needed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors here
            }
            
        }

        private bool CheckWithinPostcal(double torqueReadingVal, double desiredVal, double calThreshold)
        {
            double calLowerSpec = RoundToPrecision((desiredVal * (100 - calThreshold) / 100), 5);
            double calUpperSpec = RoundToPrecision((desiredVal * (100 + calThreshold) / 100), 5);

            bool withinPostcal = (torqueReadingVal <= calUpperSpec && torqueReadingVal >= calLowerSpec);

            return withinPostcal;
        }

        private void InsertData(List<List<object>> torqueReadingValues, double desiredVal, decimal isPre)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                mySqlConnection.Open();

                foreach (List<object> rowValues in torqueReadingValues)
                {
                    string status = Convert.ToString(rowValues[2]);
                    if (!string.IsNullOrEmpty(status))
                    {
                        String formId = lblFormID.Text;
                        double torqueReadingVal = Convert.ToDouble(rowValues[0]);
                        double deviation = Convert.ToDouble(rowValues[1]);


                        // Prepare your SQL INSERT statement
                        string insertQuery = $"INSERT INTO readdata (FormID, ReadVal, Deviation, Status, DesVal, IsPreCal, TrackingID) VALUES ('{formId}','{torqueReadingVal}', '{deviation}', '{status}', '{desiredVal}', '{isPre}', '{trackingIdForm}')"; ;

                        db.QueryScalar(insertQuery);
                    }
                }
            }
        }

        private void generateReport(object sender, EventArgs e)
        {
            string defaultFileName = "Report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save PDF Report";
            saveFileDialog.FileName = defaultFileName; 

            iTextSharp.text.Font headCalibri = FontFactory.GetFont("Calibri", 14);
            iTextSharp.text.Font bodyCalibri = FontFactory.GetFont("Calibri", 8);

            String equipID = txtEqID.Text.ToString();
            String torqCalID = comboBoxTorqCalID.Text.ToString();
            String torqSetting = txtTorqSetting.Text.ToString();
            String doneby = lblDoneBy.Text.ToString();
            String date = lblCalDate.Text.ToString();
            String location = txtLocation.Text.ToString();

            String lowPreSpec = lblPreLowerSpec.Text.ToString();
            String highPreSpec = lblPreUpperSpec.Text.ToString();
            String overallStatusPre = lblPreOverallStatus.Text.ToString();
            String minPre = lblPreMin.Text.ToString();
            String maxPre = lblPreMax.Text.ToString();
            String averagePre = lblPreAverage.Text.ToString();

            // Show save dialog and if user clicks 'Save'
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                // Generate the PDF and save it to the selected path
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();


                // Load image from disk
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("KeysightLogo.png");
                jpg.ScaleToFit(140f, 120f);
                //Give space before imagE
                jpg.SpacingBefore = 10f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_LEFT;
                doc.Add(jpg);
                // Adding the title "Calibration Report" at the top center
                Paragraph title = new Paragraph("Calibration Report", headCalibri);
                title.SpacingAfter = 10f;
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                // Creating a table with 4 columns
                PdfPTable table = new PdfPTable(4);
                table.AddCell(new PdfPCell(new Phrase("Equipment ID", bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase(equipID, bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase("Done By", bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase(doneby, bodyCalibri)));

                table.AddCell(new PdfPCell(new Phrase("Torque Calibrator ID", bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase(torqCalID, bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase("Start Calibration Date", bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase(date, bodyCalibri)));

                table.AddCell(new PdfPCell(new Phrase("Torque Setting (ibf.in)", bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase(torqSetting, bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase("Location", bodyCalibri)));
                table.AddCell(new PdfPCell(new Phrase(location, bodyCalibri)));

                table.SpacingAfter = 10f;
                table.TotalWidth = 40f;
                // Adding the details table to the document
                doc.Add(table);

                double percentagePre = Convert.ToDouble(GetThresholds()[0]);
                Paragraph title2 = new Paragraph($"Precal Stage (±{percentagePre}%)");
                title2.SpacingAfter = 10f;
                title2.Alignment = Element.ALIGN_CENTER;
                doc.Add(title2);


                // create precal table
                PdfPTable precalTable = new PdfPTable(1);
                precalTable.TotalWidth = 40f;


                //create big top cell
                PdfPCell bigCell = new PdfPCell();

                Phrase phrase1 = new Phrase();
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(new Chunk("Lower Spec: " + lowPreSpec, bodyCalibri));
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(new Chunk("Upper Spec: " + highPreSpec, bodyCalibri));
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(Chunk.TABBING);
                phrase1.Add(new Chunk("Overall Status: " + overallStatusPre, bodyCalibri));
                phrase1.Add(Chunk.NEWLINE);
                bigCell.AddElement(phrase1);

                Phrase phrase2 = new Phrase();
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(new Chunk("Min: " + minPre, bodyCalibri));
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(new Chunk("Max: " + maxPre, bodyCalibri));
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(Chunk.TABBING);
                phrase2.Add(new Chunk("Avg: " + averagePre, bodyCalibri));
                phrase2.Add(Chunk.NEWLINE);
                phrase2.Add(Chunk.NEWLINE);
                bigCell.AddElement(phrase2);


                bigCell.Colspan = 4; // Span across all columns
                bigCell.HorizontalAlignment = Element.ALIGN_CENTER;
                precalTable.AddCell(bigCell);

                // Add second table: "Reading Index Rea"
                PdfPTable readingIndexTable = new PdfPTable(4);
                readingIndexTable.TotalWidth = 40f;
                readingIndexTable.SpacingAfter = 10f;

                foreach (DataGridViewRow row in PredataGridView.Rows)
                {
                    if (row.Index < 5)
                    {
                        String rowno = Convert.ToString(row.Index + 1);
                        String torqueReadingVal = Convert.ToString(row.Cells[1].Value);
                        String deviation = Convert.ToString(row.Cells[2].Value);
                        String status = Convert.ToString(row.Cells[3].Value);


                        // Add four smaller cells below the large cell
                        readingIndexTable.AddCell(new PdfPCell(new Phrase(rowno, bodyCalibri)));
                        readingIndexTable.AddCell(new PdfPCell(new Phrase(torqueReadingVal, bodyCalibri)));
                        readingIndexTable.AddCell(new PdfPCell(new Phrase(deviation, bodyCalibri)));
                        readingIndexTable.AddCell(new PdfPCell(new Phrase(status, bodyCalibri)));
                    }
                }


                // Add the two tables to the document
                doc.Add(precalTable);
                doc.Add(readingIndexTable);


                if (PostdataGridView.Visible == true)
                {

                    String lowPostSpec = lblPostLowerSpec.Text.ToString();
                    String highPostSpec = lblPostUpperSpec.Text.ToString();
                    String overallStatusPost = lblPostOverallStatus.Text.ToString();
                    String minPost = lblPostMin.Text.ToString();
                    String maxPost = lblPostMax.Text.ToString();
                    String averagePost = lblPostAverage.Text.ToString();

                    double percentagePost = Convert.ToDouble(GetThresholds()[1]);
                    Paragraph title3 = new Paragraph($"PostCal Stage (±{percentagePost}%)");
                    title3.SpacingAfter = 10f;
                    title3.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title3);


                    // create precal table
                    PdfPTable postcalTable = new PdfPTable(1);
                    postcalTable.TotalWidth = 40f;


                    //create big top cell
                    PdfPCell bigCell2 = new PdfPCell();

                    Phrase phrase3 = new Phrase();
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(new Chunk("Lower Spec: " + lowPostSpec, bodyCalibri));
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(new Chunk("Upper Spec: " + highPostSpec, bodyCalibri));
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(Chunk.TABBING);
                    phrase3.Add(new Chunk("Overall Status: " + overallStatusPost, bodyCalibri));
                    phrase3.Add(Chunk.NEWLINE);
                    bigCell2.AddElement(phrase3);

                    Phrase phrase4 = new Phrase();
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(new Chunk("Min: " + minPost, bodyCalibri));
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(new Chunk("Max: " + maxPost, bodyCalibri));
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(Chunk.TABBING);
                    phrase4.Add(new Chunk("Avg: " + averagePost, bodyCalibri));
                    phrase4.Add(Chunk.NEWLINE);
                    phrase4.Add(Chunk.NEWLINE);
                    bigCell2.AddElement(phrase4);


                    bigCell2.Colspan = 4; // Span across all columns
                    bigCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    postcalTable.AddCell(bigCell2);

                    // Add second table: "Reading Index Rea"
                    PdfPTable readingIndexTable2 = new PdfPTable(4);
                    readingIndexTable2.TotalWidth = 40f;

                    foreach (DataGridViewRow row in PostdataGridView.Rows)
                    {
                        if (row.Index < 5)
                        {
                            String rowno = Convert.ToString(row.Index + 1);
                            String torqueReadingVal = Convert.ToString(row.Cells[1].Value);
                            String deviation = Convert.ToString(row.Cells[2].Value);
                            String status = Convert.ToString(row.Cells[3].Value);


                            // Add four smaller cells below the large cell
                            readingIndexTable2.AddCell(new PdfPCell(new Phrase(rowno, bodyCalibri)));
                            readingIndexTable2.AddCell(new PdfPCell(new Phrase(torqueReadingVal, bodyCalibri)));
                            readingIndexTable2.AddCell(new PdfPCell(new Phrase(deviation, bodyCalibri)));
                            readingIndexTable2.AddCell(new PdfPCell(new Phrase(status, bodyCalibri)));
                        }
                    }

                    // Add the two tables to the document
                    doc.Add(postcalTable);
                    doc.Add(readingIndexTable2);

                    doc.Close();

                    // Optionally, show a message to indicate successful saving
                    MessageBox.Show("PDF Report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }

    public class TorqueThreshold
    {
        public double precal_threshold { get; set; }
        public double postcal_threshold { get; set; }

        public TorqueThreshold()
        {
            precal_threshold = double.PositiveInfinity;
            postcal_threshold = double.PositiveInfinity;
        }

        public TorqueThreshold(MySqlDataReader data)
        {
            precal_threshold = Int32.Parse(data["PreCal"].ToString());
            postcal_threshold = Int32.Parse(data["Postcal"].ToString());
        }
    }
}
