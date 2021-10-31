using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace ContactManager
{
    class Group
    {
        Database db = new Database();
        readonly MySqlConnection connection = new MySqlConnection(Database.connectionString);

        // function to add a group to a the logged in user
        public bool insertGroup(string groupName, int userId)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `mygroups`(`name`, `userId`) VALUES (@gn, @uid)", connection);

            command.Parameters.AddWithValue("@gn", MySqlDbType.VarChar).Value = groupName;
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

        // check if the group name already exists
        public bool groupExists(string groupName, string operation, int userId = 0, int groupId = 0)
        {
            string query = "";

            var command = new MySqlCommand();

            if (operation == "add")
            {
                // if a new group name already exists
                query = "SELECT * FROM mygroups WHERE name=@gn AND userId=@uid";              

                command.Parameters.AddWithValue("@gn", MySqlDbType.VarChar).Value = groupName;
                command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;
            }
            else if (operation == "edit")
            {
                // check if the user enters a group name that already exists (not including the current group name)
                query = "SELECT * FROM mygroups WHERE name=@gn AND userId=@uid AND id <> @gid";

                command.Parameters.AddWithValue("@gn", MySqlDbType.VarChar).Value = groupName;
                command.Parameters.AddWithValue("@uid", MySqlDbType.UInt32).Value = userId;
                command.Parameters.AddWithValue("@gid", MySqlDbType.Int32).Value = groupId;
            }

            command.Connection = connection;
            command.CommandText = query;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            // if the group name exists, return true
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // create a function to get all user groups
        public DataTable getGroups(int userId)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM mygroups WHERE userId=@uid", connection);

            command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        // create a function to edit a group name
        public bool updateGroup(int groupId, string groupName)
        {
            MySqlCommand command = new MySqlCommand("UPDATE mygroups SET name=@name WHERE id=@id", connection);

            command.Parameters.AddWithValue("@name", MySqlDbType.VarChar).Value = groupName;
            command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = groupId;

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

        // function to remove the group
        public bool deleteGroup(int groupId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM mygroups WHERE id=@id", connection);

            command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = groupId;

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
