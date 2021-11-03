
using System.ComponentModel;
using System.Windows.Forms;

namespace ContactManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonShowFullList = new System.Windows.Forms.Button();
            this.textBoxContactId = new System.Windows.Forms.TextBox();
            this.buttonSelectContact = new System.Windows.Forms.Button();
            this.buttonRemoveContact = new System.Windows.Forms.Button();
            this.buttonEditContact = new System.Windows.Forms.Button();
            this.buttonAddContact = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxRemoveGroup = new System.Windows.Forms.ComboBox();
            this.buttonRemoveGroup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxEditGroup = new System.Windows.Forms.ComboBox();
            this.textBoxEditGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEditGroup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAddGroupName = new System.Windows.Forms.TextBox();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRefresh = new System.Windows.Forms.Label();
            this.labelEditUserDetails = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.panel2.Controls.Add(this.buttonShowFullList);
            this.panel2.Controls.Add(this.textBoxContactId);
            this.panel2.Controls.Add(this.buttonSelectContact);
            this.panel2.Controls.Add(this.buttonRemoveContact);
            this.panel2.Controls.Add(this.buttonEditContact);
            this.panel2.Controls.Add(this.buttonAddContact);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 597);
            this.panel2.TabIndex = 0;
            // 
            // buttonShowFullList
            // 
            this.buttonShowFullList.BackColor = System.Drawing.Color.Orange;
            this.buttonShowFullList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowFullList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowFullList.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonShowFullList.ForeColor = System.Drawing.Color.White;
            this.buttonShowFullList.Location = new System.Drawing.Point(25, 440);
            this.buttonShowFullList.Name = "buttonShowFullList";
            this.buttonShowFullList.Size = new System.Drawing.Size(391, 69);
            this.buttonShowFullList.TabIndex = 11;
            this.buttonShowFullList.Text = "Show full list";
            this.buttonShowFullList.UseVisualStyleBackColor = false;
            this.buttonShowFullList.Click += new System.EventHandler(this.buttonShowFullList_Click);
            // 
            // textBoxContactId
            // 
            this.textBoxContactId.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxContactId.Location = new System.Drawing.Point(217, 357);
            this.textBoxContactId.Multiline = true;
            this.textBoxContactId.Name = "textBoxContactId";
            this.textBoxContactId.Size = new System.Drawing.Size(199, 36);
            this.textBoxContactId.TabIndex = 7;
            this.textBoxContactId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSelectContact
            // 
            this.buttonSelectContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.buttonSelectContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSelectContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectContact.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonSelectContact.ForeColor = System.Drawing.Color.White;
            this.buttonSelectContact.Location = new System.Drawing.Point(217, 306);
            this.buttonSelectContact.Name = "buttonSelectContact";
            this.buttonSelectContact.Size = new System.Drawing.Size(199, 39);
            this.buttonSelectContact.TabIndex = 10;
            this.buttonSelectContact.Text = "Select contact";
            this.buttonSelectContact.UseVisualStyleBackColor = false;
            this.buttonSelectContact.Click += new System.EventHandler(this.buttonSelectContact_Click);
            // 
            // buttonRemoveContact
            // 
            this.buttonRemoveContact.BackColor = System.Drawing.Color.Orange;
            this.buttonRemoveContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveContact.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveContact.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveContact.Location = new System.Drawing.Point(25, 306);
            this.buttonRemoveContact.Name = "buttonRemoveContact";
            this.buttonRemoveContact.Size = new System.Drawing.Size(172, 87);
            this.buttonRemoveContact.TabIndex = 9;
            this.buttonRemoveContact.Text = "Remove contact";
            this.buttonRemoveContact.UseVisualStyleBackColor = false;
            this.buttonRemoveContact.Click += new System.EventHandler(this.buttonRemoveContact_Click);
            // 
            // buttonEditContact
            // 
            this.buttonEditContact.BackColor = System.Drawing.Color.Orange;
            this.buttonEditContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditContact.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonEditContact.ForeColor = System.Drawing.Color.White;
            this.buttonEditContact.Location = new System.Drawing.Point(52, 194);
            this.buttonEditContact.Name = "buttonEditContact";
            this.buttonEditContact.Size = new System.Drawing.Size(343, 69);
            this.buttonEditContact.TabIndex = 8;
            this.buttonEditContact.Text = "Edit contact";
            this.buttonEditContact.UseVisualStyleBackColor = false;
            this.buttonEditContact.Click += new System.EventHandler(this.buttonEditContact_Click);
            // 
            // buttonAddContact
            // 
            this.buttonAddContact.BackColor = System.Drawing.Color.Orange;
            this.buttonAddContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddContact.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonAddContact.ForeColor = System.Drawing.Color.White;
            this.buttonAddContact.Location = new System.Drawing.Point(52, 97);
            this.buttonAddContact.Name = "buttonAddContact";
            this.buttonAddContact.Size = new System.Drawing.Size(343, 69);
            this.buttonAddContact.TabIndex = 4;
            this.buttonAddContact.Text = "Add contact";
            this.buttonAddContact.UseVisualStyleBackColor = false;
            this.buttonAddContact.Click += new System.EventHandler(this.buttonAddContact_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 26.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(162, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 42);
            this.label6.TabIndex = 7;
            this.label6.Text = "Contact";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(468, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 520);
            this.panel4.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxRemoveGroup);
            this.groupBox3.Controls.Add(this.buttonRemoveGroup);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(515, 436);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(427, 135);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // comboBoxRemoveGroup
            // 
            this.comboBoxRemoveGroup.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.comboBoxRemoveGroup.FormattingEnabled = true;
            this.comboBoxRemoveGroup.Location = new System.Drawing.Point(177, 26);
            this.comboBoxRemoveGroup.Name = "comboBoxRemoveGroup";
            this.comboBoxRemoveGroup.Size = new System.Drawing.Size(238, 28);
            this.comboBoxRemoveGroup.TabIndex = 7;
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(105)))), ((int)(((byte)(14)))));
            this.buttonRemoveGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveGroup.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveGroup.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveGroup.Location = new System.Drawing.Point(15, 83);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Size = new System.Drawing.Size(400, 37);
            this.buttonRemoveGroup.TabIndex = 3;
            this.buttonRemoveGroup.Text = "Remove group";
            this.buttonRemoveGroup.UseVisualStyleBackColor = false;
            this.buttonRemoveGroup.Click += new System.EventHandler(this.buttonRemoveGroup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(59, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select Group:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxEditGroup);
            this.groupBox2.Controls.Add(this.textBoxEditGroup);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonEditGroup);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(515, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 184);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // comboBoxEditGroup
            // 
            this.comboBoxEditGroup.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.comboBoxEditGroup.FormattingEnabled = true;
            this.comboBoxEditGroup.Location = new System.Drawing.Point(177, 26);
            this.comboBoxEditGroup.Name = "comboBoxEditGroup";
            this.comboBoxEditGroup.Size = new System.Drawing.Size(238, 28);
            this.comboBoxEditGroup.TabIndex = 6;
            // 
            // textBoxEditGroup
            // 
            this.textBoxEditGroup.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxEditGroup.Location = new System.Drawing.Point(177, 76);
            this.textBoxEditGroup.Name = "textBoxEditGroup";
            this.textBoxEditGroup.Size = new System.Drawing.Size(238, 26);
            this.textBoxEditGroup.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Enter new name:";
            // 
            // buttonEditGroup
            // 
            this.buttonEditGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(105)))), ((int)(((byte)(14)))));
            this.buttonEditGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditGroup.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonEditGroup.ForeColor = System.Drawing.Color.White;
            this.buttonEditGroup.Location = new System.Drawing.Point(15, 130);
            this.buttonEditGroup.Name = "buttonEditGroup";
            this.buttonEditGroup.Size = new System.Drawing.Size(400, 37);
            this.buttonEditGroup.TabIndex = 3;
            this.buttonEditGroup.Text = "Edit group";
            this.buttonEditGroup.UseVisualStyleBackColor = false;
            this.buttonEditGroup.Click += new System.EventHandler(this.buttonEditGroup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(59, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Select Group:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAddGroupName);
            this.groupBox1.Controls.Add(this.buttonAddGroup);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(515, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // textBoxAddGroupName
            // 
            this.textBoxAddGroupName.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxAddGroupName.Location = new System.Drawing.Point(177, 26);
            this.textBoxAddGroupName.Name = "textBoxAddGroupName";
            this.textBoxAddGroupName.Size = new System.Drawing.Size(238, 26);
            this.textBoxAddGroupName.TabIndex = 2;
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(105)))), ((int)(((byte)(14)))));
            this.buttonAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddGroup.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonAddGroup.ForeColor = System.Drawing.Color.White;
            this.buttonAddGroup.Location = new System.Drawing.Point(15, 83);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(400, 37);
            this.buttonAddGroup.TabIndex = 3;
            this.buttonAddGroup.Text = "Add group";
            this.buttonAddGroup.UseVisualStyleBackColor = false;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Group name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 26.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(663, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.buttonClose);
            this.panel3.Controls.Add(this.buttonMinimize);
            this.panel3.Location = new System.Drawing.Point(663, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 53);
            this.panel3.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(272, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 26);
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
            this.buttonMinimize.Location = new System.Drawing.Point(231, 12);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(32, 26);
            this.buttonMinimize.TabIndex = 21;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.labelRefresh);
            this.panel1.Controls.Add(this.labelEditUserDetails);
            this.panel1.Controls.Add(this.labelUsername);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 653);
            this.panel1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Azure;
            this.label7.Location = new System.Drawing.Point(152, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "|";
            // 
            // labelRefresh
            // 
            this.labelRefresh.AutoSize = true;
            this.labelRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRefresh.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.labelRefresh.ForeColor = System.Drawing.Color.Azure;
            this.labelRefresh.Location = new System.Drawing.Point(174, 33);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new System.Drawing.Size(54, 18);
            this.labelRefresh.TabIndex = 4;
            this.labelRefresh.Text = "Refresh";
            this.labelRefresh.Click += new System.EventHandler(this.labelRefresh_Click);
            // 
            // labelEditUserDetails
            // 
            this.labelEditUserDetails.AutoSize = true;
            this.labelEditUserDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEditUserDetails.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.labelEditUserDetails.ForeColor = System.Drawing.Color.Azure;
            this.labelEditUserDetails.Location = new System.Drawing.Point(65, 33);
            this.labelEditUserDetails.Name = "labelEditUserDetails";
            this.labelEditUserDetails.Size = new System.Drawing.Size(81, 18);
            this.labelEditUserDetails.TabIndex = 3;
            this.labelEditUserDetails.Text = "Edit my info";
            this.labelEditUserDetails.Click += new System.EventHandler(this.labelEditUserDetails_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(65, 9);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(173, 21);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Welcome (username)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(975, 653);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timer2;
        private Timer timer1;
        private Panel panel2;
        private Panel panel3;
        private Button buttonMinimize;
        private Panel panel1;
        private Label labelUsername;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private TextBox textBoxAddGroupName;
        private Button buttonAddGroup;
        private Label label2;
        private Label label1;
        private Button buttonClose;
        private Label labelEditUserDetails;
        private GroupBox groupBox2;
        private ComboBox comboBoxEditGroup;
        private TextBox textBoxEditGroup;
        private Label label4;
        private Button buttonEditGroup;
        private Label label3;
        private GroupBox groupBox3;
        private Button buttonRemoveGroup;
        private Label label5;
        private ComboBox comboBoxRemoveGroup;
        private Label label7;
        private Label labelRefresh;
        private Label label6;
        private Panel panel4;
        private Button buttonShowFullList;
        private TextBox textBoxContactId;
        private Button buttonSelectContact;
        private Button buttonRemoveContact;
        private Button buttonEditContact;
        private Button buttonAddContact;
    }
}