using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ContactManager
{
    class User
    {
        Database db = new Database();

        // function to check the username
        public bool usernameExists(string username)
        {
            string query = "SELECT * FROM 'user' WHERE 'username' =@un";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            // if the user exists, return true
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // insert a new user
        public bool insertUser(string firstName, string lastName, string username, string password, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `user`(`id`, `first_name`, `last_name`, `username`, `password`, `picture`) " +
                "VALUES (@fn, @ln, @un, @pass, @pic)", db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
