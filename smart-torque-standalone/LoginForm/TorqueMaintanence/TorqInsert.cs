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

namespace LoginForm.TorqueMaintanence
{
    public partial class TorqInsert : Form
    {
        public event EventHandler successfullyInserted; // Define an event

        public TorqInsert()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            // Get the new TorqCalID and its description from the TextBoxes
            string newTorqCalID = textBoxNewTorqCalID.Text;
            string newTorqCalDesc = textBoxTorqCalDesc.Text;

            // Insert the new TorqCalID and its description into the torqequip table
            string insertQuery = $"INSERT INTO torqequip (TorqCalID, TorqCalDesc) VALUES ('{newTorqCalID}', '{newTorqCalDesc}')";

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New TorqCalID inserted successfully!");
                        onInsert();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert new TorqCalID.");
                    }
                }
            }
        }

        private void onInsert()
        {
            // Check if the event has subscribers
            successfullyInserted?.Invoke(this, EventArgs.Empty);
        }

    }
}
