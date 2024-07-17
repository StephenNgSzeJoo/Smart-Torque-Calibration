using ActiproSoftware.Products.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.DirectoryServices;

namespace LoginForm
{
    public partial class Login : Form
    {
        public event EventHandler linkClicked; // handles the event whereby the link was clicked 
        DB db = new DB();
        public event EventHandler onCloseLogin;

        public Login()
        {
            InitializeComponent();
            loginFormPanel.BackColor = Color.FromArgb(100, 0, 0, 0);

            // Subscribe to the Resize event of the form
            this.Resize += login_Resize;

            // Initially center the loginFormPanel
            CenterLoginFormPanel();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected bool AuthenticateUser()
        {
            using (DirectoryEntry de = new DirectoryEntry("LDAP://ad.keysight.com/cn=Users,dc=AD,dc=KEYSIGHT,dc=COM", txtUsername.Text, txtPassword.Text, AuthenticationTypes.Secure))
            {
                try
                {
                    DirectorySearcher ds = new DirectorySearcher(de);
                    ds.FindOne();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Username and/or password is incorrect. Please put a valid username and password");
                    return false;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUsername.Text))
            {
                MessageBox.Show("Please Enter Username.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                MessageBox.Show("Please Enter Password.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassword.Focus();
                return;
            }
            string input = this.txtUsername.Text;
            bool isEmail = input.Contains('@'); // Check if the input contains '@'
            string query;

            string userId = string.Empty;
            string roles = string.Empty;
            string name = string.Empty;
            string dept = string.Empty;
            string ext = string.Empty;
            string email = string.Empty;

            // if user select Sapphire user, will go to Sapphire server verified the user
            if (SapphireUser.Checked == true)
            {
                string userNT = "KEYSIGHT:" + input;
                if (isNTExists(userNT))
                {
                    if (AuthenticateUser())
                    {

                        var query1 = "select * from logintb where ntuser_id ='" + userNT + "'";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlDataReader reader = new SqlCommand(query1, connection).ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        email = reader["email"].ToString();
                                    }
                                }
                            }
                        }

                        string[] emailParts = email.Split('@');
                        UserDetails.Username = emailParts[0];
                        this.Hide();
                        onCloseLogin?.Invoke(this, EventArgs.Empty);
                        //break;

                        //JObject userData = new JObject();

                        //using (SqlConnection connection = new SqlConnection(connectionString))
                        //{
                        //    connection.Open();
                        //    using (SqlCommand cmd = new SqlCommand("Validate_User", connection))
                        //    {
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@Username", "KEYSIGHT:" + txtUsername.Text);
                        //        using (SqlDataReader reader = cmd.ExecuteReader())
                        //        {
                        //            while (reader.Read())
                        //            {
                        //                userData["id"] = reader["UserId"].ToString();
                        //                userData["name"] = reader["Name"].ToString();
                        //                userData["ext"] = reader["Ext"].ToString();
                        //                userData["email"] = reader["Email"].ToString();
                        //                userData["empno"] = reader["EmpNo"].ToString();
                        //                userData["ntname"] = txtUsername.Text;

                        //                userId = reader["UserId"].ToString();
                        //                name = reader["name"].ToString();
                        //                ext = reader["ext"].ToString();
                        //                email = reader["email"].ToString();
                        //            }
                        //        }
                        //    }

                        //    switch (userId)
                        //    {
                        //        case "-1":
                        //            MessageBox.Show("Username and/or password is incorrect. Please put a valid username and password");
                        //            return;
                        //        default:
                        //            string[] emailParts = email.Split('@');
                        //            UserDetails.Username = emailParts[0];
                        //            this.Hide();
                        //            onCloseLogin?.Invoke(this, EventArgs.Empty);
                        //            break;
                        //    }
                        //}
                    }
                }
                else
                {
                    // Server connection failed
                    MessageBox.Show("Username and/or password is incorrect. Please put a valid username and password");
                    return;
                }
            }
            else
            {
                if (isEmail)
                {
                    string[] emailParts = input.Split('@');

                    // Logic for email-based login
                    query = $"SELECT COUNT(*) FROM users WHERE username = '{emailParts[0]}' AND password = '{Register.HashPassword(this.txtPassword.Text)}'";
                    UserDetails.Username = emailParts[0]; // Replace "the_username" with the actual username
                }
                else
                {
                    string userNT = "KEYSIGHT:" + input;
                    // Logic for username-based login
                    query = $"SELECT COUNT(*) FROM users WHERE userNT = '{userNT}' AND password = '{Register.HashPassword(this.txtPassword.Text)}'";
                    if (isNTExists(userNT))
                    {
                        UserDetails.Username = getusername(userNT);
                    }
                }

                if (Convert.ToInt16(db.QueryScalar(query)) <= 0)
                {
                    MessageBox.Show("Username and/or password is incorrect. Please put a valid username and password");
                    return;
                }
                this.Hide();
                onCloseLogin?.Invoke(this, EventArgs.Empty);
            }        
        }

        string connectionString =
            "Data Source=WPNGDBA4;" +
            "Initial Catalog=SAPPHIRE_NET;" +
            "User id=sapp;" +
            "Password=KeysightTechnologies2023!@;";

        private bool isNTExists(string NT)
        {
            bool inserted = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = @"SELECT COUNT(*) FROM [dbo].[logintb] WHERE [ntuser_id] = @NT";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@NT", NT);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        inserted = (count > 0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        // Handle exception as needed
                    }
                }
            }
            return inserted;
        }

        private string getusername(string userNT)
        {
            string username = null;
            var query = "select * from users where userNT ='" + userNT + "'";

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();
                using (MySqlDataReader reader = new MySqlCommand(query, connection).ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            username = reader["username"].ToString();
                        }
                    }
                }
            }
            return userNT;
        }

        private void login_Resize(object sender, EventArgs e)
        {
            // Call the method to re-center the loginFormPanel when the form is resized
            CenterLoginFormPanel();
        }

        private void CenterLoginFormPanel()
        {
            // Calculate the position to center the loginFormPanel within the form
            int x = (this.ClientSize.Width - loginFormPanel.Width) / 2;
            int y = (this.ClientSize.Height - loginFormPanel.Height) / 2;

            // Set the location of the loginFormPanel
            loginFormPanel.Location = new Point(x, y);
        }

        private void register_Click(object sender, EventArgs e)
        {
            // When the link is clicked, raise the custom event
            linkClicked?.Invoke(this, EventArgs.Empty);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

