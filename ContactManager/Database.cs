using MySqlConnector;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ContactManager
{
    class Database
    {
        // the connection
        public static string connectionString = "datasource=YOUR_DATASOURCE; port=YOUR_PORT; username=YOUR_USERNAME; " +
            "password=YOUR_PASSWORD; database=YOUR_DATABASE_NAME; CharSet=utf8;";

        private readonly string salt = "YOUR_SALT";

        public string getSalt()
        {
            return this.salt;
        }

        MySqlConnection connection = new MySqlConnection(connectionString);

        // return the connection
        public MySqlConnection getConnection
        {
            get
            {
                try
                {
                    return connection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        // open the connection
        public void openConnection()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // close the connection
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
