using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;

namespace ContactManager
{
    public partial class Login_Register_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public Login_Register_Form()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        readonly MySqlConnection connection = new MySqlConnection(Database.connectionString);

        private void Login_Register_Form_Load(object sender, EventArgs e)
        {
            //display image on the panel (close and minimize)
            panel3.BackgroundImage = Image.FromFile("../../images/img1.png");
        }

        // login button
        private void button_Login_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `username` = @un AND `password` = @pass", connection);

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = textBoxUsername.Text;

            string password = textBoxPassword.Text;
            string salt = db.getSalt();
            string passwordHashed = SecurityHelper.HashPassword(password, salt, 10101, 70);

            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passwordHashed;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(VerifyFields("login")) // check for empty fields
            {
                if (table.Rows.Count > 0) // check if this user exists
                {
                    // we want to display the user's username and image in the main form
                    // to do that we need to get the user id and make it global so other form can use it
                    int userId = Convert.ToInt32(table.Rows[0][0].ToString());
                    Globals.setGlobalUserId(userId);

                    // show the main app form
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Username or Password", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // register button
        private void button_Register_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            string firstName = textBoxFName.Text;
            string lastName = textBoxLName.Text;
            string username = textBoxUsernameRegister.Text;

            string password = textBoxPasswordRegister.Text;
            string salt = db.getSalt();
            string passwordHashed = SecurityHelper.HashPassword(password, salt, 10101, 70);

            User user = new User();

            if (VerifyFields("register"))
            {
                MemoryStream picture = new MemoryStream();

                var avatarImage = pictureBoxProfileImage.Image;

                try
                {
                    avatarImage.Save(picture, avatarImage.RawFormat);
                }
                catch (System.ArgumentNullException)
                {
                    avatarImage.Save(picture, ImageFormat.Png);
                }

                // we need to check if the username already exists
                // we need to insert the new user in the database
                // we will create that in the call User
                if (!user.usernameExists(username, "register")) // check if the username already exists
                {
                    if (user.insertUser(firstName, lastName, username, passwordHashed, picture))
                    {
                        MessageBox.Show("Registration completed successfully", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("This Username already exists, try another one", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("* Required fields: \n \n - Username \n - Password \n - Image", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // create a function to check empty fields
        public bool VerifyFields(string operation)
        {
            bool check = false;

            // if the operation is register
            if (operation == "register")
            {
                if (textBoxUsernameRegister.Text.Trim().Equals("") || textBoxPasswordRegister.Text.Trim().Equals("") 
                    || pictureBoxProfileImage.Image == null)
                {
                    //  || textBoxFName.Text.Equals("") || textBoxLName.Text.Equals("")
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            else if (operation == "login")
            {
                if (textBoxUsername.Text.Trim().Equals("") || textBoxPassword.Text.Trim().Equals(""))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }

            return check;
        }

        // browse button
        private void button_browse_Click(object sender, EventArgs e)
        {
            // select and display image in the picturebox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfileImage.Image = Image.FromFile(opf.FileName);
            }
        }

        // label go to the register section
        private void labelGoToRegister_Click(object sender, EventArgs e)
        {
            timer1.Start();
            labelGoToRegister.Enabled = false;
            labelGoToLogin.Enabled = false;
        }

        // label go to the login section
        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            timer2.Start();
            labelGoToRegister.Enabled = false;
            labelGoToLogin.Enabled = false;
        }

        // button close
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // button minimize
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // when this timer will start we will show only the register part
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X > -320)
            {
                panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
            }
            else
            {
                timer1.Stop();
                labelGoToLogin.Enabled = true;
                labelGoToRegister.Enabled = true;
            }
        }

        // when this timer will start we will show only the login part
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X < 0)
            {
                panel2.Location = new Point(panel2.Location.X + 10, panel2.Location.Y);
            }
            else
            {
                timer2.Stop();
                labelGoToLogin.Enabled = true;
                labelGoToRegister.Enabled = true;
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

        private void button_Select_Cropped_Area_Click(object sender, EventArgs e)
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
                    button_Select_Cropped_Area.Enabled = true;
                    button_Select_Cropped_Area.Cursor = Cursors.Hand;
                    graphics.DrawRectangle(cropPen, cropX, cropY, rectW, rectH);
                    graphics.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cropping out of bounds", "Cropping Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Default;
        }
    }
}
