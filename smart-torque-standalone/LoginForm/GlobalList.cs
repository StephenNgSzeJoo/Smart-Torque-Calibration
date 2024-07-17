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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CedarTorque
{
    public partial class GlobalList : Form
    {
        public event EventHandler pressSelect;


        public GlobalList()
        {
            InitializeComponent();
        }
        private void Main(object sender, EventArgs e)
        {
            LoadData();
        }

        private string connectionString = "Initial Catalog=SAPPHIRE;Server=WPNGDBA5;UID=sapp;PWD=KeysightTechnologies2023!@;";

        private void LoadData()
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
                {
                    connection.Open();
                    //string query = "SELECT * FROM dept"; // Replace with your table name
                    string query = "SELECT * FROM caldata";

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
                    }
                    else
                    {
                        // Show "No Record Found" message when no records are available
                        dataGridView2.DataSource = null;
                        dataGridView2.Rows.Clear();
                        dataGridView2.Columns.Clear();
                        //dataGridView2.Columns.Add("NoRecordColumn", "No Record Found");
                    }

                    //removeCheckBoxes();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["SelectEQ"].Index)
            {
                // Get the row clicked
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Access the data in the row and perform the desired actions
                string equipmentID = selectedRow.Cells["EquipID"].Value.ToString();
                string formID = selectedRow.Cells["FormID"].Value.ToString();
                string locationID = selectedRow.Cells["Location"].Value.ToString();

                string userChoice = AskUserForChoice();

                if (userChoice == "HIOS")
                {
                    HIOSMainForm hiosForm = new HIOSMainForm();
                    hiosForm.loadFromGlobal(formID, equipmentID, locationID, 0);
                    Home.setCurrentForm(hiosForm);
                    pressSelect?.Invoke(this, EventArgs.Empty);
                }
                else if (userChoice == "CEDAR")
                {
                    ParentForm cedarForm = new CEDARMainForm();
                    cedarForm.loadFromGlobal(formID, equipmentID, locationID, 0);
                    Home.setCurrentForm(cedarForm);
                    pressSelect?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    // User canceled or chose an invalid option
                    MessageBox.Show("Operation canceled or invalid choice.");
                }
            }
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
