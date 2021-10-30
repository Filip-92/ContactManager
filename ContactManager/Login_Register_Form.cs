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
using MySqlConnector;

namespace ContactManager
{
    public partial class Login_Register_Form : Form
    {
        public Login_Register_Form()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3307; username=root; " +
            "password=; database=csharp_contact_manager_db; CharSet=utf8;");

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

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `username` = @un AND `password` = @pass", db.getConnection);

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(VerifyFields("login")) // check for empty fields
            {
                if (table.Rows.Count > 0) // check if this user exists
                {
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
            string firstName = textBoxFName.Text;
            string lastName = textBoxLName.Text;
            string username = textBoxUsernameRegister.Text;
            string password = textBoxPasswordRegister.Text;

            User user = new User();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (VerifyFields("register"))
            {
                MemoryStream picture = new MemoryStream();
                pictureBoxProfileImage.Image.Save(picture, pictureBoxProfileImage.Image.RawFormat);

                // we need to check if the username already exists
                // we need to insert the new user in the database
                // we will create that in the call User
                if(!user.usernameExists(username)) // check if the username already exists
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxProfileImage_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPasswordRegister_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsernameRegister_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
