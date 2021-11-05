using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Add_Contact_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Add_Contact_Form()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void Add_Contact_Form_Load(object sender, EventArgs e)
        {
            getGroups();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void getGroups()
        {
            Group group = new Group();

            // populate comboBox
            comboBoxGroup.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxGroup.DisplayMember = "name";
            comboBoxGroup.ValueMember = "id";
        }

        // button to add contact
        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string email = textBoxEmail.Text;
            int userId = Globals.GlobalUserId;

            try
            {
                // get group id
                int groupId = (int) comboBoxGroup.SelectedValue;

                // get image
                MemoryStream pic = new MemoryStream();
                pictureBoxContactImage.Image.Save(pic, pictureBoxContactImage.Image.RawFormat);

                if (contact.insertContact(firstName, lastName, userId, groupId, phone, email, address, pic))
                {
                    MessageBox.Show("New contact added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // button browse image
        private void button_browse_Click(object sender, EventArgs e)
        {
            // select and display image in the picturebox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxContactImage.Image = Image.FromFile(opf.FileName);
            }
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
