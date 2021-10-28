using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Login_Register_Form : Form
    {
        public Login_Register_Form()
        {
            InitializeComponent();
        }

        private void Login_Register_Form_Load(object sender, EventArgs e)
        {
            //display image on the panel (close and minimize)
            panel3.BackgroundImage = Image.FromFile("../../images/img1.png");
        }

        // login button
        private void button_Login_Click(object sender, EventArgs e)
        {

        }

        // register button
        private void button_Register_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFName.Text;
            string lastName = textBoxLName.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            User user = new User();

            if (VerifyFields("register"))
            {
                MemoryStream picture = new MemoryStream();
                pictureBoxProfileImage.Image.Save(picture, pictureBoxProfileImage.Image.RawFormat);

                // we need to check if the username already exists
                // we need to insert the new user in the database
                // we will create that in the call User
                if(user.usernameExists(username)) // check if the username already exists
                {
                    if (user.insertUser(firstName, lastName, username, password, picture))
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
                MessageBox.Show("* Required fields - Username / Password / Image", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // create a function to check empty fields
        public bool VerifyFields(string operation)
        {
            bool check = false;

            // if the operation is register
            if (operation == "register")
            {
                if (textBoxUsernameRegister.Text.Equals("") || textBoxPasswordRegister.Text.Equals("") 
                    || pictureBoxProfileImage == null || textBoxFName.Text.Equals("") || textBoxLName.Text.Equals(""))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            else if (operation == "login")
            {
                if (textBoxUsername.Text.Equals("") || textBoxPassword.Text.Equals(""))
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
            // - 320 is where you can see the register part
            // the first 320 is where the login part is displayed
            // so the panel need to go outside the form by 320
            // and the same when we want to show the login part
            // we need to set the location (X) of the panel to 0
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


    }
}
