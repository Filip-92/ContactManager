using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
// we need to add the mysql connector to connect our app with the mysql database
using MySql.Data.MySqlClient;

namespace ContactManager
{
    class Database
    {
        // the connection
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3307; username=root; " +
            "password=; database=contact_manager_db;");

        // return the connection
        public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        // open the connection
        public void openConnection()
        {
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
