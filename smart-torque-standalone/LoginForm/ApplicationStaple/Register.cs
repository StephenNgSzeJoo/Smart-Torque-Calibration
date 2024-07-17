using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;


namespace LoginForm
{
    public partial class Register : Form
    {
        DB db = new DB();
        public event EventHandler registerSuccess; // handles the event whereby the registered successfully

        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text) || string.IsNullOrWhiteSpace(this.txtUsername.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = this.txtUsername.Text;
            string[] emailParts = email.Split('@');

            string emailHeader = emailParts[0]; // Extract username part
            string company = emailParts[1]; //

            string password = this.txtPassword.Text;
            string hashedpassword = HashPassword(password);

            // Check if the username already exists in the database
            if (IsUsernameExists(emailHeader))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }


            String userNT = getUserNT(email);

            // Insert the new username and password into the database
            string insertQuery = $"INSERT INTO users (username, company, password, userNT) VALUES ('{emailHeader}', '{company}', '{hashedpassword}', '{userNT}')";
            db.QueryScalar(insertQuery);
            MessageBox.Show("User registered successfully!");
            this.Hide();
            registerSuccess?.Invoke(this, EventArgs.Empty);
            

        }

        private bool IsUsernameExists(string username)
        {
            string checkQuery = $"SELECT COUNT(*) FROM users WHERE username = '{username}'";
            int count = Convert.ToInt32(db.QueryScalar(checkQuery));
            return count > 0;
        }

        string connectionString =
      "Data Source=WPNGDBA4;" +
      "Initial Catalog=SAPPHIRE_NET;" +
      "User id=sapp;" +
      "Password=KeysightTechnologies2023!@;";



        private string getUserNT(string email)
        {
            string userNT = null;
            var query = "select * from logintb where email ='" + email + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userNT = reader["ntuser_id"].ToString();
                        }
                    }
                }
            }
            return userNT;
        }

        private void login_Click(object sender, EventArgs e)
        {
            // When the link is clicked, raise the custom event
            registerSuccess?.Invoke(this, EventArgs.Empty);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password string
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
