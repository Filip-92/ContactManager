using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MySqlConnector;

namespace ContactManager
{
    class Contact
    {
        readonly MySqlConnection connection = new MySqlConnection(Database.connectionString);

        public bool contactExists(string firstName, string lastName, string operation, int userId = 0, int contactId = 0)
        {
            string query = "";

            var command = new MySqlCommand();

            if (operation == "add")
            {
                // if a new contact already exists
                query = "SELECT * FROM mycontacts WHERE first_name=@fname AND last_name=@lname AND userId=@uid";

                command.Parameters.AddWithValue("@fname", MySqlDbType.VarChar).Value = firstName;
                command.Parameters.AddWithValue("@lname", MySqlDbType.VarChar).Value = lastName;
                command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;
            }
            else if (operation == "edit")
            {
                // check if the user enters a contact that already exists (not including the current contact)
                query = "SELECT * FROM mycontacts WHERE first_name=@fname AND last_name=@lname AND userId=@uid AND id <> @cid";

                command.Parameters.AddWithValue("@fname", MySqlDbType.VarChar).Value = firstName;
                command.Parameters.AddWithValue("@lname", MySqlDbType.VarChar).Value = lastName;
                command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = userId;
                command.Parameters.AddWithValue("@cid", MySqlDbType.Int32).Value = contactId;
            }

            command.Connection = connection;
            command.CommandText = query;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            // if the contact exists, return true
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool insertContact(string firstName, string lastName, int userId, int groupId, string phone, string email, string address, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `mycontacts`(`first_name`, `last_name`, `group_id`, `phone`, `email`, `address`, `picture`, `userId`) VALUES (@fn, @ln, @gid, @phone, @email, @address, @pic, @uid)", connection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@gid", MySqlDbType.Int32).Value = groupId;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

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

        public bool updateContact(int id, string firstName, string lastName, int groupId, string phone, string email, string address, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `mycontacts` SET `first_name`=@fn,`last_name`=@ln,`group_id`=@gid,`phone`=@phone,`email`=@email,`address`=@ads,`picture`=@pic WHERE `id`=@id", connection);

            command.Parameters.AddWithValue("@fn", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.AddWithValue("@ln", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.AddWithValue("@gid", MySqlDbType.Int32).Value = groupId;
            command.Parameters.AddWithValue("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.AddWithValue("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.AddWithValue("@ads", MySqlDbType.VarChar).Value = address;
            command.Parameters.AddWithValue("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = id;

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

        // function returning a list of contacts depending on the given commad
        public DataTable selectContactList(MySqlCommand command)
        {
            command.Connection = connection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // function to get contact by id
        public DataTable getContactById(int contactId)
        {
            MySqlCommand command = new MySqlCommand("SELECT `id`, `first_name`, `last_name`, `group_id`, `phone`, `email`, `address`, `picture`, `userId` FROM `mycontacts` WHERE `id`=@id", connection);

            command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = contactId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // function to delete contact by id
        public bool deleteContact(int contactId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM mycontacts WHERE id=@id", connection);

            command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = contactId;

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
