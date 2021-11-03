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
    public partial class Select_Contact_Form : Form
    {
        readonly MySqlConnection connection = new MySqlConnection(Database.connectionString);

        public Select_Contact_Form()
        {
            InitializeComponent();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Select_Contact_Form_Load(object sender, EventArgs e)
        {
            // display the logged user contacts list
            MySqlCommand command = new MySqlCommand("SELECT `id`, `first_name`, `last_name`, `group_id` AS 'group id' FROM `mycontacts` WHERE `userId`=@uid");

            command.Parameters.AddWithValue("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;

            Contact contact = new Contact();

            dataGridView1.DataSource = contact.selectContactList(command);

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
