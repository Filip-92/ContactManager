using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        private void button_Remove_User_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Globals.GlobalUserId;

                if (MessageBox.Show("Are you sure you want to remove your account?", "Remove account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (user.deleteAccount(userId))
                    {
                        MessageBox.Show("Account deleted", "Remove account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("User couldn't be deleted", "Remove account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // declare some variables for crop coordinates
        int cropX, cropY, rectW, rectH;
        public Pen cropPen = new Pen(Color.White);

        private void pictureBoxProfileImage_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                // set initial x, y coordinates for crop rectangle
                // this is where we firstly click on image
                cropX = e.X;
                cropY = e.Y;
            }
        }

        private void pictureBoxProfileImage_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;
        }

        private void pictureBoxProfileImage_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Default;
        }

        private void pictureBoxProfileImage_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    pictureBoxProfileImage.Refresh();
                    // set width and heigh for crop rectangle
                    rectW = e.X - cropX;
                    rectH = e.Y - cropY;
                    Graphics graphics = pictureBoxProfileImage.CreateGraphics();
                    button_Crop_Image.Enabled = true;
                    button_Crop_Image.Cursor = Cursors.Hand;
                    graphics.DrawRectangle(cropPen, cropX, cropY, rectW, rectH);
                    graphics.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Cropping out of bounds", "Cropping Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_Crop_Image_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            Bitmap bitmap2 = new Bitmap(pictureBoxProfileImage.Width, pictureBoxProfileImage.Height);
            pictureBoxProfileImage.DrawToBitmap(bitmap2, pictureBoxProfileImage.ClientRectangle);

            Bitmap croppedImage = new Bitmap(rectW, rectH);
            try
            {
                for (int x = 0; x < rectW; x++)
                {
                    for (int y = 0; y < rectH; y++)
                    {
                        Color pxlColor = bitmap2.GetPixel(cropX + x, cropY + y);
                        croppedImage.SetPixel(x, y, pxlColor);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Cropping out of bounds", "Cropping Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pictureBoxProfileImage.Image.Dispose();
            pictureBoxProfileImage.Image = (Image)croppedImage;
            pictureBoxProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Default;
        }
    }
}
