using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Edit_Contact_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Edit_Contact_Form()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void Edit_Contact_Form_Load(object sender, EventArgs e)
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

        private void buttonSelectContact_Click(object sender, EventArgs e)
        {
            // show a form to select the contact we want to edit
            Select_Contact_Form selectContactForm = new Select_Contact_Form();
            selectContactForm.ShowDialog();

            try
            {
                // get the contact id
                int contactId = Convert.ToInt32(selectContactForm.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                Contact contact = new Contact();

                DataTable table = contact.getContactById(contactId);

                textBoxContactId.Text = table.Rows[0]["id"].ToString();
                textBoxFirstName.Text = table.Rows[0]["first_name"].ToString();
                textBoxLastName.Text = table.Rows[0]["last_name"].ToString();
                comboBoxGroup.SelectedValue = table.Rows[0]["group_id"].ToString();
                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxEmail.Text = table.Rows[0]["email"].ToString();
                textBoxAddress.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxContactImage.Image = Image.FromStream(picture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        // button edit contact
        private void buttonEditContact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string email = textBoxEmail.Text;

            try
            {
                int contactId = Convert.ToInt32(textBoxContactId.Text);
                // get group id
                int groupId = (int)comboBoxGroup.SelectedValue;

                // get image
                MemoryStream pic = new MemoryStream();
                pictureBoxContactImage.Image.Save(pic, pictureBoxContactImage.Image.RawFormat);

                if (!contact.contactExists(firstName, lastName, "edit", Globals.GlobalUserId, contactId))
                {
                    if (contact.updateContact(contactId, firstName, lastName, groupId, phone, email, address, pic))
                    {
                        MessageBox.Show("Contact data updated", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something's wrong", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Contact with such First name and Last name already exists, try another", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
