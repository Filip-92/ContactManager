using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MySqlConnector;

namespace ContactManager
{
    class User
    {
        Database db = new Database();
        readonly MySqlConnection connection = new MySqlConnection(Database.connectionString);

        // function to check the username
        public bool usernameExists(string username, string operation, int userId = 0)
        {
            string query = "";

            if (operation == "register")
            {
                // if a new user wants to register, we will check if the username already exists
                query = "SELECT * FROM user WHERE username=@un";
            }
            else if (operation == "edit")
            {
                // check if the user enters a username that already exists (not including his username)
                query = "SELECT * FROM user WHERE username = @un AND id <> @uid";
            }

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@un", username);
            command.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userId;

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
            MySqlCommand command = new MySqlCommand("INSERT INTO `user`(`first_name`, `last_name`, `username`, `password`, `picture`) " +
                "VALUES (@fn, @ln, @un, @pass, @pic)", connection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();

            connection.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        // create a function to return the user data using his id
        public DataTable getUserById(Int32 userId)
        {
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE id=@uid", connection);

            command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;

        }

        // create a function to edit the user data
        public bool updateUser(int userId, string firstName, string lastName, string username, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand("UPDATE user SET first_name=@fn, last_name=@ln, username=@un, picture=@pic WHERE id=@uid", connection);

            command.Parameters.AddWithValue("@fn", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.AddWithValue("@ln", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.AddWithValue("@un", MySqlDbType.VarChar).Value = username;
            command.Parameters.AddWithValue("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;

            connection.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public DataTable passwordMatches(int userId, string oldPassword)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `id` = @id AND `password` = @pass", connection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Globals.GlobalUserId;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = oldPassword;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            return table;
        }

        public bool changePassword(int userId, string newPassword)
        {
            MySqlCommand command = new MySqlCommand("UPDATE user SET password=@newpass WHERE id=@uid", connection);

            command.Parameters.AddWithValue("@newpass", MySqlDbType.VarChar).Value = newPassword;
            command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;

            connection.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public bool deleteAccount(int userId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM user WHERE id=@id", connection);

            command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = userId;

            connection.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
    }
}
