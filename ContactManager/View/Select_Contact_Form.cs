using System;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace ContactManager
{
    public partial class Select_Contact_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public Select_Contact_Form()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
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

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
