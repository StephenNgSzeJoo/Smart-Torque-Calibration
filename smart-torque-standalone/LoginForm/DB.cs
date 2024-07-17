using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
public class DB
{
    DataSet ds;
    public DB()
    {
        ds = new DataSet();
    }
    /// <summary>
    /// this method returns only one row and one column
    /// </summary>
    /// <param name="Query"></param>
    /// <returns></returns>
    public string QueryScalar(string Query)
    {
        string str = "";
        using (MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
        {
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);

            try
            {
                mySqlConnection.Open();
                var result = mySqlCommand.ExecuteScalar();

                // Check if the result is not null before calling ToString()
                if (result != null)
                {
                    str = result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return str;
    }
}