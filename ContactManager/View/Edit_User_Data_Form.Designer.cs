
namespace ContactManager
{
    partial class Edit_User_Data_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_User_Data_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Crop_Image = new System.Windows.Forms.Button();
            this.button_Edit_User = new System.Windows.Forms.Button();
            this.button_Change_Password = new System.Windows.Forms.Button();
            this.button_Remove_User = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_browse = new System.Windows.Forms.Button();
            this.pictureBoxProfileImage = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 376);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.buttonClose);
            this.panel3.Controls.Add(this.buttonMinimize);
            this.panel3.Location = new System.Drawing.Point(356, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 39);
            this.panel3.TabIndex = 2;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(272, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 29);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMinimize.ForeColor = System.Drawing.Color.White;
            this.buttonMinimize.Location = new System.Drawing.Point(231, 5);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(32, 29);
            this.buttonMinimize.TabIndex = 21;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.button_Crop_Image);
            this.panel2.Controls.Add(this.button_Edit_User);
            this.panel2.Controls.Add(this.button_Change_Password);
            this.panel2.Controls.Add(this.button_Remove_User);
            this.panel2.Controls.Add(this.textBoxUsername);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxLastName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxFirstName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_browse);
            this.panel2.Controls.Add(this.pictureBoxProfileImage);
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 334);
            this.panel2.TabIndex = 0;
            // 
            // button_Crop_Image
            // 
            this.button_Crop_Image.BackColor = System.Drawing.Color.Black;
            this.button_Crop_Image.Enabled = false;
            this.button_Crop_Image.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.button_Crop_Image.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Crop_Image.Location = new System.Drawing.Point(91, 293);
            this.button_Crop_Image.Name = "button_Crop_Image";
            this.button_Crop_Image.Size = new System.Drawing.Size(122, 38);
            this.button_Crop_Image.TabIndex = 13;
            this.button_Crop_Image.Text = "Crop image";
            this.button_Crop_Image.UseVisualStyleBackColor = false;
            this.button_Crop_Image.Click += new System.EventHandler(this.button_Crop_Image_Click);
            // 
            // button_Edit_User
            // 
            this.button_Edit_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.button_Edit_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Edit_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_User.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.button_Edit_User.ForeColor = System.Drawing.Color.White;
            this.button_Edit_User.Location = new System.Drawing.Point(310, 270);
            this.button_Edit_User.Name = "button_Edit_User";
            this.button_Edit_User.Size = new System.Drawing.Size(326, 41);
            this.button_Edit_User.TabIndex = 12;
            this.button_Edit_User.Text = "Edit";
            this.button_Edit_User.UseVisualStyleBackColor = false;
            this.button_Edit_User.Click += new System.EventHandler(this.button_Edit_User_Click);
            // 
            // button_Change_Password
            // 
            this.button_Change_Password.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Change_Password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Change_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Change_Password.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.button_Change_Password.ForeColor = System.Drawing.Color.White;
            this.button_Change_Password.Location = new System.Drawing.Point(310, 223);
            this.button_Change_Password.Name = "button_Change_Password";
            this.button_Change_Password.Size = new System.Drawing.Size(161, 41);
            this.button_Change_Password.TabIndex = 11;
            this.button_Change_Password.Text = "Change Password";
            this.button_Change_Password.UseVisualStyleBackColor = false;
            this.button_Change_Password.Click += new System.EventHandler(this.button_Change_Password_Click);
            // 
            // button_Remove_User
            // 
            this.button_Remove_User.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_Remove_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Remove_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remove_User.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.button_Remove_User.ForeColor = System.Drawing.Color.Black;
            this.button_Remove_User.Location = new System.Drawing.Point(477, 223);
            this.button_Remove_User.Name = "button_Remove_User";
            this.button_Remove_User.Size = new System.Drawing.Size(159, 41);
            this.button_Remove_User.TabIndex = 10;
            this.button_Remove_User.Text = "Remove account";
            this.button_Remove_User.UseVisualStyleBackColor = false;
            this.button_Remove_User.Click += new System.EventHandler(this.button_Remove_User_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxUsername.Location = new System.Drawing.Point(415, 154);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(221, 26);
            this.textBoxUsername.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(316, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxLastName.Location = new System.Drawing.Point(415, 103);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(221, 26);
            this.textBoxLastName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(312, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxFirstName.Location = new System.Drawing.Point(415, 53);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(221, 26);
            this.textBoxFirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(310, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name:";
            // 
            // button_browse
            // 
            this.button_browse.BackColor = System.Drawing.Color.Transparent;
            this.button_browse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_browse.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.button_browse.ForeColor = System.Drawing.Color.White;
            this.button_browse.Location = new System.Drawing.Point(33, 257);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(242, 30);
            this.button_browse.TabIndex = 1;
            this.button_browse.Text = "Change Profile Image";
            this.button_browse.UseVisualStyleBackColor = false;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // pictureBoxProfileImage
            // 
            this.pictureBoxProfileImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureBoxProfileImage.Location = new System.Drawing.Point(33, 38);
            this.pictureBoxProfileImage.Name = "pictureBoxProfileImage";
            this.pictureBoxProfileImage.Size = new System.Drawing.Size(242, 213);
            this.pictureBoxProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfileImage.TabIndex = 0;
            this.pictureBoxProfileImage.TabStop = false;
            this.pictureBoxProfileImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxProfileImage_MouseDown);
            this.pictureBoxProfileImage.MouseEnter += new System.EventHandler(this.pictureBoxProfileImage_MouseEnter);
            this.pictureBoxProfileImage.MouseLeave += new System.EventHandler(this.pictureBoxProfileImage_MouseLeave);
            this.pictureBoxProfileImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxProfileImage_MouseMove);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(359, 39);
            this.panel4.TabIndex = 22;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // Edit_User_Data_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 376);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Edit_User_Data_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit_User_Data_Form";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfileImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.PictureBox pictureBoxProfileImage;
        private System.Windows.Forms.Button button_Remove_User;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Button button_Change_Password;
        private System.Windows.Forms.Button button_Edit_User;
        private System.Windows.Forms.Button button_Crop_Image;
        private System.Windows.Forms.Panel panel4;
    }
}