using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace ContactManager
{
    public partial class Contacts_Full_List_Form : Form
    {
        public Contacts_Full_List_Form()
        {
            InitializeComponent();
        }

        private void Contacts_Full_List_Load(object sender, EventArgs e)
        {
            // populate dataGridView with contacts
            DataGridViewImageColumn pictureColumn = new DataGridViewImageColumn();

            dataGridView1.RowTemplate.Height = 80;

            Contact contact = new Contact();
            MySqlCommand command = new MySqlCommand("SELECT `first_name` as 'first name', `last_name` as 'last name', mygroups.name as 'group', `phone`, `email`, `address`, `picture` " +
                "FROM `mycontacts` INNER JOIN mygroups on mycontacts.group_id = mygroups.id WHERE mycontacts.userId = @userId");
            command.Parameters.AddWithValue("@userId", MySqlDbType.Int32).Value = Globals.GlobalUserId;
            dataGridView1.DataSource = contact.selectContactList(command);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (isOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            pictureColumn = (DataGridViewImageColumn) dataGridView1.Columns[6];
            pictureColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            // populate listbox with groups' names
            Group group = new Group();
            listBox1.DataSource = group.getGroups(Globals.GlobalUserId);
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";

            listBox1.SelectedItem = null;
            dataGridView1.ClearSelection();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            // display contacts in the selected group
            try
            {
                Contact contact = new Contact();
                int groupId = (Int32) listBox1.SelectedValue;
                MySqlCommand command = new MySqlCommand("SELECT `first_name` as 'first name', `last_name` as 'last name', mygroups.name as 'group', `phone`, `email`, `address`, `picture` " +
                    "FROM `mycontacts` INNER JOIN mygroups on mycontacts.group_id = mygroups.id WHERE mycontacts.userId = @userId AND mycontacts.group_id = @groupId");
                command.Parameters.AddWithValue("@userId", MySqlDbType.Int32).Value = Globals.GlobalUserId;
                command.Parameters.AddWithValue("@groupId", MySqlDbType.Int32).Value = groupId;
                dataGridView1.DataSource = contact.selectContactList(command);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (isOdd(i))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }

                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {

            }
        }

        // show all contacts
        private void labelShowAll_Click(object sender, EventArgs e)
        {
            // call the form load
            Contacts_Full_List_Load(null, null);
        }

        // alternate the dataGridView rows background color
        public bool isOdd(int value)
        {
            // return true if the value = 2, 4, 6, etc.
            return value % 2 != 0;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (isOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            // display the address in the textBox
            textBoxAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}

// when tou delete a group, all contacts asigned to this group will be deleted
// add foreign keys to the db

/*
 * 
ALTER TABLE mycontacts
    ADD CONSTRAINT fk_group_id
    FOREIGN KEY (group_id)
    REFERENCES mygroups(id)
    ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE mycontacts
    ADD CONSTRAINT fk_user_id
    FOREIGN KEY (user_id)
    REFERENCES user(id)
    ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE mygroups
    ADD CONSTRAINT fk_user_id
    FOREIGN KEY (userId)
    REFERENCES user(id)
    ON DELETE CASCADE ON UPDATE CASCADE;

*/
