using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Windows.Forms;



namespace LoginForm
{
    class Installer
    {
        DB db = new DB();
        public void InstallMySQL()
        {
            if (!IsMySQLInstalled())
            {
                // Path to the MySQL Installer executable
                string installerFileName = "mysql-installer-web-community-8.0.35.0.msi";

                // Check if the MSI file is in the same directory as the executable (debug/release) or the startup path (published)
                string installerPathDebug = Path.Combine(Application.StartupPath, installerFileName);
                string installerPathRelease = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, installerFileName);

                string installerPath = File.Exists(installerPathDebug) ? installerPathDebug : installerPathRelease;




                // Arguments to run msiexec silently
                string installerArguments = $"/i \"{installerPath}\" INSTALLDIR=C:\\MySQL /L*v C:\\MySQLInstall.log";

                // Start the msiexec process
                Process installerProcess = new Process();
                installerProcess.StartInfo.FileName = "msiexec.exe";
                installerProcess.StartInfo.Arguments = installerArguments;
                installerProcess.StartInfo.UseShellExecute = false;
                installerProcess.StartInfo.RedirectStandardOutput = true;

                installerProcess.Exited += (sender, e) =>
                {
                    Console.WriteLine("Installer process has exited.");

                    // Check the exit code to determine if the installation was successful
                    if (installerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("MySQL installation completed successfully.");

                        // Now you can proceed with setting up the database
                    }
                    else
                    {
                        Console.WriteLine($"MySQL installation failed with exit code: {installerProcess.ExitCode}");
                    }

                    // Dispose of the process to release resources
                    installerProcess.Dispose();
                };

                // Start the installer process
                installerProcess.Start();

                // Wait for the process to exit asynchronously
                installerProcess.WaitForExit();
            }
            else
            {
                // MySQL is already installed, you can handle this case as needed
                // For example, display a message to the user
                Console.WriteLine("MySQL is already installed.");
            }
        }




        public bool IsMySQLInstalled()
        {
            // Check if MySQL Server is installed by checking the registry
            string mysqlExecutablePath = @"C:\Program Files\MySQL\MySQL Server 8.0";


            return Directory.Exists(mysqlExecutablePath);
        }



        public void SetupDatabase()
        {
            // Database user and password
            string mysqlUser = "root";
            string mysqlPassword = "basd2Dqe#1te";

            // Connection string with the specified user and password
            string connectionString = $"Server=localhost;User ID={mysqlUser};Password={mysqlPassword};";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create the database
                connection.Open();
                ExecuteNonQuery(connection, "CREATE SCHEMA IF NOT EXISTS `cal`;");

                // Use the new database
                ExecuteNonQuery(connection, "USE `cal`;");

                // Perform additional setup tasks, such as creating tables

                ExecuteNonQuery(connection, @"
                                            CREATE TABLE IF NOT EXISTS `users` (
                                              `UserID` int NOT NULL AUTO_INCREMENT,
                                              `Username` varchar(140) DEFAULT NULL,
                                              `Company` varchar(140) DEFAULT NULL,
                                              `Password` varchar(140) DEFAULT NULL,
                                              `UserNT` varchar(140) DEFAULT NULL,
                                              PRIMARY KEY (`UserID`),
                                              KEY `UserNameIndex` (`Username`)
                                            );
                                        ");

                ExecuteNonQuery(connection, @"
                                            CREATE TABLE IF NOT EXISTS `caldata` (
                                              `FormID` varchar(255) NOT NULL,
                                              `EquipID` varchar(255) DEFAULT NULL,
                                              `TorqCalID` varchar(255) DEFAULT NULL,
                                              `TorqSet` decimal(10,0) DEFAULT NULL,
                                              `StartCalDate` datetime DEFAULT NULL,
                                              `Location` varchar(255) DEFAULT NULL,
                                              `DoneBy` varchar(140) DEFAULT NULL,
                                              `TrackingID` VARCHAR(255) DEFAULT NULL,
                                              `Complete` int DEFAULT 0,
                                              `Submitted` int DEFAULT 0,
                                              `SubmitDateTime` datetime DEFAULT NULL,
                                              PRIMARY KEY (`FormID`),
                                              KEY `DoneBy` (`DoneBy`)                                            );
                                        ");


                ExecuteNonQuery(connection, @"
                                            CREATE TABLE IF NOT EXISTS `readdata` (
                                              `ReadIndex` int NOT NULL AUTO_INCREMENT,
                                              `FormID` varchar(50) DEFAULT NULL,
                                              `ReadVal` decimal(10,2) DEFAULT NULL,
                                              `Deviation` decimal(10,2) DEFAULT NULL,
                                              `Status` varchar(50) DEFAULT NULL,
                                              `DesVal` decimal(10,2) DEFAULT NULL,
                                              `IsPreCal` int DEFAULT NULL,
                                              `TrackingID` VARCHAR(255) DEFAULT NULL,
                                              PRIMARY KEY (`ReadIndex`),
                                              KEY `FormID` (`FormID`),
                                              CONSTRAINT `readdata_ibfk_1` FOREIGN KEY (`FormID`) REFERENCES `caldata` (`FormID`)
                                            );
                                        ");
                ExecuteNonQuery(connection, @"
                                            CREATE TABLE IF NOT EXISTS `torq_threshold` (
                                              `UserTorqId` int NOT NULL AUTO_INCREMENT,
                                              `PreCal` double DEFAULT NULL,
                                              `Postcal` double DEFAULT NULL,
                                              `LastUpdated` datetime DEFAULT NULL,
                                              `DoneBy` varchar(140) DEFAULT NULL,
                                              `TrackingID` VARCHAR(255) DEFAULT NULL,
                                              PRIMARY KEY (`UserTorqId`),
                                              KEY `DoneBy` (`DoneBy`)
                                            );
                                        ");

                ExecuteNonQuery(connection, @"
                                        CREATE TABLE IF NOT EXISTS `torqequip` (
                                          `Index` int NOT NULL AUTO_INCREMENT,
                                          `TorqCalID` varchar(255) DEFAULT NULL,
                                          `TorqCalDesc` varchar(255) DEFAULT NULL,
                                          `TrackingID` VARCHAR(255) DEFAULT NULL,
                                          PRIMARY KEY (`Index`)
                                        );
                                    ");

                ExecuteNonQuery(connection, @"
                                        CREATE TABLE IF NOT EXISTS `tracking_source` (
                                          `EquipmentID` VARCHAR(255),
                                          `ModelID` VARCHAR(255),
                                          `SerialNumber` VARCHAR(255),
                                          `ServiceID` VARCHAR(255),
                                          `PL` VARCHAR(255),
                                          `Dept` VARCHAR(255),
                                          `DueDate` DATE,
                                          `TrackingID` VARCHAR(255),
                                          `TorqueSet` decimal(10,0) DEFAULT NULL,
                                          `Status` VARCHAR(255) DEFAULT 'NOT STARTED',
                                          `SapphireFormID` VARCHAR(255) DEFAULT NULL
                                        );
                                    ");

                insertinitaltorquethresh();

                // Check if the `SubmitDateTime` column exists
                bool submitDateTimeColumnExists = CheckIfColumnExists(connection, "caldata", "SubmitDateTime");

                // If the column does not exist, add it
                if (!submitDateTimeColumnExists)
                {
                    ExecuteNonQuery(connection, "ALTER TABLE `caldata` ADD COLUMN `SubmitDateTime` datetime DEFAULT NULL;");
                }


                // Close the connection
                connection.Close();
            }
        }

        private void ExecuteNonQuery(MySqlConnection connection, string query)
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void insertinitaltorquethresh()
        {
            if (IsDatabaseEmpty()) { 

                string pre = "0";
                string post = "0";
                string user = "eng-chin.goh";
                DateTime currentDateTime = DateTime.Now; // Replace with your actual DateTime object

                string formattedDate = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                if (double.TryParse(pre, out double preValue) && double.TryParse(post, out double postValue))
                {
                    string insertQuery = $"INSERT INTO torq_threshold (PreCal, PostCal, LastUpdated, DoneBy) VALUES ('{preValue}', '{postValue}',  '{formattedDate}', '{user}')";
                    db.QueryScalar(insertQuery);
                }
            }
        }

        public bool IsDatabaseEmpty()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM torq_threshold", connection))
                {
                    int tableCount = Convert.ToInt32(command.ExecuteScalar());

                    return tableCount == 0;
                }
            }
        }

        private bool CheckIfColumnExists(MySqlConnection connection, string tableName, string columnName)
        {
            using (MySqlCommand command = new MySqlCommand($"SHOW COLUMNS FROM `{tableName}` LIKE '{columnName}';", connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
