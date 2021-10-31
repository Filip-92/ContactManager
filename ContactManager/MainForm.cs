using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;

namespace ContactManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            getImageAndUsername();
            getGroups();
        }

        readonly MySqlConnection connection = new MySqlConnection(Database.connectionString);
        Database db = new Database();
        Group group = new Group();

        private void MainForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // create a function to display the logged in image and username
        public void getImageAndUsername()
        {
            var command = new MySqlCommand("SELECT * FROM user WHERE id=@uid", connection);

            command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();
            
            //adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                // display the user image
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);

                // display the user username
                labelUsername.Text = "Welcome Back ( " + table.Rows[0]["username"] + " )";
            }
        }

        // label edit user data
        private void labelEditUserDetails_Click(object sender, EventArgs e)
        {
            Edit_User_Data_Form editUserForm = new Edit_User_Data_Form();
            editUserForm.Show(this);
        }

        // button add new group
        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            string groupName = textBoxAddGroupName.Text;

            if (!groupName.Trim().Equals(""))
            {
                // check if the group name already exists for the logged in user
                if (!group.groupExists(groupName, "add", Globals.GlobalUserId))
                {
                    if (group.insertGroup(groupName, Globals.GlobalUserId))
                    {
                        MessageBox.Show("New group added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Group could not be added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    getGroups(); // populate the comboBox again to display the new data
                }
                else
                {
                    MessageBox.Show("Group name already exists", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter a name of the group", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // populate the comboBox
        public void getGroups()
        {
            // populate edit comboBox
            comboBoxEditGroup.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxEditGroup.DisplayMember = "name";
            comboBoxEditGroup.ValueMember = "id";

            // populate remove comboBox
            comboBoxRemoveGroup.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxRemoveGroup.DisplayMember = "name";
            comboBoxRemoveGroup.ValueMember = "id";
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string newGroupName = textBoxEditGroup.Text;
                int groupId = Convert.ToInt32(comboBoxEditGroup.SelectedValue.ToString());

                if (!newGroupName.Trim().Equals(""))
                {
                    if (!group.groupExists(newGroupName, "edit", Globals.GlobalUserId, groupId))
                    {
                        if (group.updateGroup(groupId, newGroupName))
                        {
                            MessageBox.Show("Group name updated", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Group name couldn't be updated", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        getGroups();
                    }
                    else
                    {
                        MessageBox.Show("This group name already exists. Try another", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Enter a name of the group before editing", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Select a group before editing", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRemoveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int groupId = Convert.ToInt32(comboBoxRemoveGroup.SelectedValue.ToString());

                if (MessageBox.Show("Are you sure you want to delete this group?", "Remove group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (group.deleteGroup(groupId))
                    {
                        MessageBox.Show("Group deleted", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Group couldn't be deleted", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    getGroups();
                }
            }
            catch
            {
                MessageBox.Show("Select a group before deleting", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }
    }
}
