using LoginForm;
using LoginForm.TorqueForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace CedarTorque
{
    public partial class TotalTorqueCalReport : Form
    {
        public event EventHandler pressSelect; 

        public TotalTorqueCalReport()
        {
            InitializeComponent();
        }
        private void Load_TotalTorqReport(object sender, EventArgs e)
        {
            LoadData();
            loadData2();
        }

        private string connectionString = "Initial Catalog=SAPPHIRE;Server=WPNGDBA5;UID=sapp;PWD=KeysightTechnologies2023!@;";
        private void LoadData()
        {
            bool isConnected = CheckInternetConnection();

            if (isConnected)
            {
                // Fetch data from SQL Server
                DataTable sqlServerData = new DataTable();
                try
                {
                    // Fetch data from SQL Server
                    string sqlServerQuery = @"SELECT equip_id as 'Equipment ID', model_id as 'Model ID', serial_no as 'Serial Number', service_id as 'Service ID', s_dept as 'PL', s_dept as 'Dept', due_cal as 'Due Date', AE_progress as 'Tracking ID' 
                                    FROM tracking 
                                    WHERE status IN ('Pending', 'Calibrating') 
                                    AND (serial_no LIKE 'T%' OR equip_id LIKE 'T%') 
                                    AND model_id IN (SELECT distinct model_id FROM mplink WHERE status NOT IN ('0','2') AND procedure_id = 'TORQUEONSITE.CAL.N1098') 
                                    ORDER BY due_cal, service_id, serial_no";

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlServerQuery, sqlConnection);
                        sqlAdapter.Fill(sqlServerData);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data from SQL Server: " + ex.Message);
                    return;
                }

                foreach (DataRow row in sqlServerData.Rows)
                {
                    // Example: Concatenate 'ID' and 'Name' columns into 'CustomColumn'.
                    row[4] = MapLegacyDeptCodeToPLCode(row[4].ToString());
                }

                // Fetch Tracking IDs from your local MySQL database
                List<string> localTrackingIds = new List<string>();
                try
                {
                    // Fetch Tracking IDs from MySQL
                    // Example: Connect to MySQL and fetch the Tracking IDs
                    // Replace this section with your actual code to fetch Tracking IDs from MySQL
                    using (MySqlConnection localConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        localConnection.Open();
                        string mySqlQuery = "SELECT TrackingID FROM tracking_source";
                        MySqlCommand mySqlCommand = new MySqlCommand(mySqlQuery, localConnection);
                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                localTrackingIds.Add(reader["TrackingID"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data from MySQL: " + ex.Message);
                    return;
                }

                // Filter data based on the existence of Tracking IDs in local MySQL
                DataTable filteredData = sqlServerData.Clone(); // Clone structure of the SQL Server data
                foreach (DataRow row in sqlServerData.Rows)
                {
                    string trackingId = row["Tracking ID"].ToString();
                    if (!localTrackingIds.Contains(trackingId))
                    {
                        filteredData.ImportRow(row);
                    }
                }

                // Display filtered data in your DataGridView
                if (filteredData.Rows.Count > 0)
                {
                    dataGridView1.DataSource = filteredData;

                    if (!dataGridView1.Columns.Contains("CheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.HeaderText = "Select"; // Set the header text
                        checkBoxColumn.Name = "CheckBoxColumn"; // Set a name for the column
                        dataGridView1.Columns.Insert(0, checkBoxColumn); // Insert the checkbox column at index 0
                    }
                }
                else
                {
                    // Show "No Record Found" message when no records are available
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    //dataGridView1.Columns.Add("NoRecordColumn", "No Record Found");
                }
            }
            else
            {
                MessageBox.Show("No internet connection. Please try again later.");
                // Handle no internet connection scenario
            }

        }

        private void loadData2()
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();
                    //string query = "SELECT * FROM dept"; // Replace with your table name
                    string query = "SELECT * FROM tracking_source";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (!dataGridView2.Columns.Contains("SelectEQ"))
                    {
                        var buttonColumn = new DataGridViewButtonColumn
                        {
                            HeaderText = "Action",
                            Text = "SELECT",
                            UseColumnTextForButtonValue = true,
                            Name = "SelectEQ",
                            DisplayIndex = 0
                        };

                        dataGridView2.Columns.Add(buttonColumn);
                    }

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dataTable;

                        if (!dataGridView2.Columns.Contains("CheckBoxColumn"))
                        {
                            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                            checkBoxColumn.HeaderText = "Upload"; // Set the header text
                            checkBoxColumn.Name = "CheckBoxColumn"; // Set a name for the column
                            dataGridView2.Columns.Insert(0, checkBoxColumn); // Insert the checkbox column at index 0
                        }

                    }
                    else
                    {
                        // Show "No Record Found" message when no records are available
                        dataGridView2.DataSource = null;
                        dataGridView2.Rows.Clear();
                        dataGridView2.Columns.Clear();
                        //dataGridView2.Columns.Add("NoRecordColumn", "No Record Found");
                    }

                    removeCheckBoxes();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void removeCheckBoxes()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
               
            }
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

        private void TransferButton_Click(object sender, EventArgs e)
        {
            TransferSelectedRows();
            LoadData();
            loadData2();
        }

        private void TransferSelectedRows()
        {
            try
            {
                DataTable selectedRows = ((DataTable)dataGridView1.DataSource).Clone(); // Clone the structure of the DataTable

                // Iterate through DataGridView rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null && checkBoxCell.OwningColumn is DataGridViewCheckBoxColumn)
                    {
                        // This cell belongs to a DataGridViewCheckBoxColumn
                        bool isChecked = Convert.ToBoolean(checkBoxCell.Value);

                        // Check if the cell is a checkbox and is checked
                        if (isChecked)
                        {
                            // Clone the DataRow and add it to the new DataTable
                            selectedRows.ImportRow(((DataRowView)row.DataBoundItem).Row);
                        }
                    }
                }



                // Check if any rows are selected for transfer
                if (selectedRows.Rows.Count > 0)
                {
                    decimal pound = 0;
                    using (MySqlConnection localconnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                    {
                        localconnection.Open();

                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            cmd.Connection = localconnection;
                            cmd.CommandType = CommandType.Text;

                            // Loop through each row in the DataTable and insert into MySQL
                            foreach (DataRow row in selectedRows.Rows)
                            {




                                var query = "select * from calibrationtb where equip_id ='" + row["Equipment ID"] + "' and status = 'Approved'";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    using (SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                if (reader["poundage"] != DBNull.Value)
                                                {
                                                    if (decimal.TryParse(reader["poundage"].ToString(), out decimal poundDecimal))
                                                    {
                                                        pound = poundDecimal;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }


                                string[] dateParts = row["Due Date"].ToString().Split('/');

                                if (dateParts.Length == 3 && int.TryParse(dateParts[0], out int month) && int.TryParse(dateParts[1], out int day) && int.TryParse(dateParts[2], out int year))
                                {
                                    DateTime dueDate = new DateTime(year, month, day);
                                    string formattedDueDate = dueDate.ToString("yyyy-MM-dd");
                                    cmd.Parameters.AddWithValue("@DueDate", formattedDueDate);

                                }
                                cmd.CommandText = "INSERT INTO tracking_source (EquipmentID, ModelID, SerialNumber, ServiceID, PL, Dept, DueDate, TrackingID, TorqueSet) VALUES (@EquipmentID, @ModelID, @SerialNumber, @ServiceID, @PL, @Dept, @DueDate, @TrackingID, @TorqueSet)";

                                // Add parameters and assign values from the retrieved DataTable row
                                cmd.Parameters.AddWithValue("@EquipmentID", row["Equipment ID"]);
                                cmd.Parameters.AddWithValue("@ModelID", row["Model ID"]);
                                cmd.Parameters.AddWithValue("@SerialNumber", row["Serial Number"]);
                                cmd.Parameters.AddWithValue("@ServiceID", row["Service ID"]);
                                cmd.Parameters.AddWithValue("@PL", row["PL"]);
                                cmd.Parameters.AddWithValue("@Dept", row["Dept"]);
                                //cmd.Parameters.AddWithValue("@DueDate", row["Due Date"]);
                                cmd.Parameters.AddWithValue("@TrackingID", row["Tracking ID"]);
                                cmd.Parameters.AddWithValue("@TorqueSet", pound);

                                // Execute the query
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }
                    }

                    MessageBox.Show("Selected rows transferred to the local database.");
                }
                else
                {
                    MessageBox.Show("No rows selected for transfer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error transferring rows: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["SelectEQ"].Index)
            {
                // Get the row clicked
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                double torqSet = 0;
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();

                    string query1 = "SELECT * FROM tracking_source WHERE TrackingID = @trackingID";
                    MySqlCommand command = new MySqlCommand(query1, connection);
                    command.Parameters.AddWithValue("@trackingID", selectedRow.Cells["TrackingID"].Value.ToString());

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["TorqueSet"] != DBNull.Value)
                                {
                                    if (double.TryParse(reader["TorqueSet"].ToString(), out double poundDecimal))
                                    {
                                        torqSet = poundDecimal;
                                    }
                                }
                            }
                        }
                    }
                }

                // Access the data in the row and perform the desired actions
                string equipmentID = selectedRow.Cells["EquipmentID"].Value.ToString();
                string trackingID = selectedRow.Cells["TrackingID"].Value.ToString();
                string locationID = selectedRow.Cells["Dept"].Value.ToString();
                Console.WriteLine(equipmentID + trackingID + locationID);


                string userChoice = AskUserForChoice();

                if (userChoice == "HIOS")
                {
                    HIOSMainForm hiosForm = new HIOSMainForm();
                    hiosForm.loadFromSapphire(trackingID, equipmentID, locationID, torqSet);
                    Home.setCurrentForm(hiosForm);
                    pressSelect?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show($"Selected Equipment ID: {equipmentID}, Tracking ID: {trackingID}, HIOS Form chosen");
                }
                else if (userChoice == "CEDAR")
                {
                    ParentForm cedarForm = new CEDARMainForm();
                    cedarForm.loadFromSapphire(trackingID, equipmentID, locationID, torqSet);
                    Home.setCurrentForm(cedarForm);
                    pressSelect?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show($"Selected Equipment ID: {equipmentID}, Tracking ID: {trackingID}, CEDAR Form chosen");
                }
                else
                {
                    // User canceled or chose an invalid option
                    MessageBox.Show("Operation canceled or invalid choice.");
                }
;
            }
        }

        private void bulkSapphireUploads(object sender, EventArgs e)
        {
            try
            {
                DataTable selectedRows = ((DataTable)dataGridView2.DataSource).Clone(); // Clone the structure of the DataTable

                // Iterate through DataGridView rows
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null && checkBoxCell.OwningColumn is DataGridViewCheckBoxColumn)
                    {
                        // This cell belongs to a DataGridViewCheckBoxColumn
                        bool isChecked = Convert.ToBoolean(checkBoxCell.Value);

                        // Check if the cell is a checkbox and is checked
                        if (isChecked)
                        {
                            // Clone the DataRow and add it to the new DataTable
                            selectedRows.ImportRow(((DataRowView)row.DataBoundItem).Row);
                        }
                    }
                }

                int failUploads = 0;
                LoadingForm loadingForm = new LoadingForm(selectedRows.Rows.Count - 1);
                loadingForm.Show();

                // Check if any rows are selected for transfer
                if (selectedRows.Rows.Count > 0)
                {
                    // Loop through each row in the DataTable and insert into MySQL
                    foreach (DataRow row in selectedRows.Rows)
                    {
                        if (row["Status"].ToString() == "COMPLETE")
                        {
                            MainForm mainForm = new MainForm();

                            mainForm.loadFromSapphire(row["TrackingID"].ToString(), row["EquipmentID"].ToString(), row["Dept"].ToString(), 0.0);
                            mainForm.MainForm_Load(this, EventArgs.Empty);
                            mainForm.sapphireBulkUpload(this, EventArgs.Empty);
                        }
                        else
                        {
                            failUploads++;
                        }

                        loadingForm.UpdateCountdown();

                    }

                    if (failUploads > 0)
                    {
                        MessageBox.Show("Incomplete forms failed to upload: " + failUploads);
                    }
                }
                else
                {
                    MessageBox.Show("No rows selected for transfer.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error transferring rows: " + ex.Message);
            }

            LoadData();
            loadData2();
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

    }
}
