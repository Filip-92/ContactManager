using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Edit_User_Data_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Edit_User_Data_Form()
        {
            InitializeComponent();
            DisplayUserData();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        User user = new User();

        private void Edit_User_Data_Form_Load(object sender, EventArgs e)
        {
            // set the close and minimize image
            panel3.BackgroundImage = Image.FromFile("../../images/img1.png");
        }

        private void DisplayUserData()
        {
            // display the userData
            DataTable table = user.getUserById(Globals.GlobalUserId);
            textBoxFirstName.Text = table.Rows[0][1].ToString();
            textBoxLastName.Text = table.Rows[0][2].ToString();
            textBoxUsername.Text = table.Rows[0][3].ToString();

            byte[] pic = (byte[])table.Rows[0]["picture"];
            MemoryStream picture = new MemoryStream(pic);
            pictureBoxProfileImage.Image = Image.FromStream(picture);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            // select and display image in the picturebox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfileImage.Image = Image.FromFile(opf.FileName);
            }
        }

        // button to submit the update of user data
        private void button_Edit_User_Click(object sender, EventArgs e)
        {
            int userId = Globals.GlobalUserId;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string username = textBoxUsername.Text;


            MemoryStream pic = new MemoryStream();
            pictureBoxProfileImage.Image.Save(pic, pictureBoxProfileImage.Image.RawFormat);

            if (username.Trim().Equals("")) // check empty fields
            {
                MessageBox.Show("Required Fields: Username", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (user.usernameExists(username,"edit", userId))
                {
                    MessageBox.Show("This username already exists. Try another one", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (user.updateUser(userId, firstName, lastName, username, pic))
                {
                    MessageBox.Show("Your Information has been updated", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something's wrong", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_Change_Password_Click(object sender, EventArgs e)
        {
            Change_Password_Form changePasswordForm = new Change_Password_Form();
            changePasswordForm.Show(this);
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
