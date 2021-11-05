using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Change_Password_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        User user = new User();

        public Change_Password_Form()
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

        private void button_Change_Password_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            int userId = Globals.GlobalUserId;
            string oldPassword = textBoxOldPassword.Text;
            string salt = db.getSalt();
            string oldPasswordHashed = SecurityHelper.HashPassword(oldPassword, salt, 10101, 70);
            string newPassword = textBoxNewPassword.Text;
            string newPasswordHashed = SecurityHelper.HashPassword(newPassword, salt, 10101, 70);

            var table = user.passwordMatches(userId, oldPasswordHashed);

            if (oldPassword.Trim().Equals("") || oldPassword.Trim().Equals("")) // check empty fields
            {
                MessageBox.Show("You must insert both old password and new password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    if (user.changePassword(userId, newPasswordHashed))
                    {
                        MessageBox.Show("Your password has been changed", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Something's wrong", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This password does not match your current password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
