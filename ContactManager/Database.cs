using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
// we need to add the mysql connector to connect our app with the mysql database
using MySqlConnector;
using System.Windows.Forms;

namespace ContactManager
{
    class Database
    {
        // the connection
        public static string connectionString = "datasource=localhost; port=3307; username=root; " +
            "password=; database=csharp_contact_manager_db; CharSet=utf8;";

        MySqlConnection con = new MySqlConnection(connectionString);

        // return the connection
        public MySqlConnection getConnection
        {
            get
            {
                try
                {
                    return con;
                }
                catch(Exception ex)
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

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // close the connection
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
