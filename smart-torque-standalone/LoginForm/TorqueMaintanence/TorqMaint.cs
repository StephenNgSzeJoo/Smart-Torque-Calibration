using LoginForm.TorqueMaintanence;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.TorqMaintanence
{
    public partial class TorqMaint : Form
    {
        public TorqMaint()
        {
            InitializeComponent();
            this.Load += TorqMaintForm_Load;
        }

        private void TorqMaintForm_Load(object sender, EventArgs e)
        {
            comboBoxTorqCalID.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                // Load TorqCalID into the ComboBox
                string query = "SELECT TorqCalID FROM torqequip";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
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

        private void comboBoxTorqCalID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a TorqCalID is selected, display its description in the TextBox
            string selectedTorqCalID = comboBoxTorqCalID.SelectedItem.ToString();
            string query = $"SELECT TorqCalDesc FROM torqequip WHERE TorqCalID = '{selectedTorqCalID}'";

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxTorqCalDesc.Text = reader["TorqCalDesc"].ToString();
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Get the selected TorqCalID
            string selectedTorqCalID = comboBoxTorqCalID.SelectedItem.ToString();

            // Get the new description from the TextBox
            string newDescription = textBoxTorqCalDesc.Text;

            // Update the description in the torqequip table
            string updateQuery = $"UPDATE torqequip SET TorqCalDesc = '{newDescription}' WHERE TorqCalID = '{selectedTorqCalID}'";

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Description updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update description.");
                    }
                }
            }
        }

        
        // Helper method to refresh the TorqCalIDs in the ComboBox after insertion
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



    }
}
