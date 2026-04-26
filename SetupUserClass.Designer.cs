namespace TravelPass
{
    partial class SetupUserClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logo__setup = new System.Windows.Forms.PictureBox();
            this.topPanelSetup = new System.Windows.Forms.Panel();
            this.fullname_textbox = new System.Windows.Forms.TextBox();
            this.fullname = new System.Windows.Forms.Label();
            this.coo_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.department_textbox = new System.Windows.Forms.TextBox();
            this.department = new System.Windows.Forms.Label();
            this.designation_textbox = new System.Windows.Forms.TextBox();
            this.designation = new System.Windows.Forms.Label();
            this.email_textbox = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.continue_ = new System.Windows.Forms.Button();
            this.quitSetupLabel = new System.Windows.Forms.Label();
            this.minimizeSetupLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.minimizeSetup = new System.Windows.Forms.PictureBox();
            this.quitSetup = new System.Windows.Forms.PictureBox();
            this.continueSetupUserClass1 = new TravelPass.ContinueSetupUserClass();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo__setup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitSetup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "TravelPass";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(214)))));
            this.panel1.Controls.Add(this.logo__setup);
            this.panel1.Controls.Add(this.topPanelSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 408);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // logo__setup
            // 
            this.logo__setup.Image = global::TravelPass.Properties.Resources.TravelPass_Logo_Blue_Icon_Round_2_8_18;
            this.logo__setup.Location = new System.Drawing.Point(49, 149);
            this.logo__setup.Name = "logo__setup";
            this.logo__setup.Size = new System.Drawing.Size(100, 101);
            this.logo__setup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo__setup.TabIndex = 9;
            this.logo__setup.TabStop = false;
            // 
            // topPanelSetup
            // 
            this.topPanelSetup.Location = new System.Drawing.Point(199, 0);
            this.topPanelSetup.Name = "topPanelSetup";
            this.topPanelSetup.Size = new System.Drawing.Size(294, 53);
            this.topPanelSetup.TabIndex = 7;
            // 
            // fullname_textbox
            // 
            this.fullname_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fullname_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullname_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.fullname_textbox.Location = new System.Drawing.Point(209, 98);
            this.fullname_textbox.Name = "fullname_textbox";
            this.fullname_textbox.Size = new System.Drawing.Size(259, 21);
            this.fullname_textbox.TabIndex = 2;
            this.fullname_textbox.Text = "e.g Chibuzor Afonja";
            this.fullname_textbox.TextChanged += new System.EventHandler(this.fullname_textbox_TextChanged);
            this.fullname_textbox.Enter += new System.EventHandler(this.fullname_textbox_Enter);
            this.fullname_textbox.Leave += new System.EventHandler(this.fullname_textbox_Leave);
            // 
            // fullname
            // 
            this.fullname.AutoSize = true;
            this.fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullname.Location = new System.Drawing.Point(209, 80);
            this.fullname.Name = "fullname";
            this.fullname.Size = new System.Drawing.Size(59, 15);
            this.fullname.TabIndex = 3;
            this.fullname.Text = "Fullname";
            // 
            // coo_textbox
            // 
            this.coo_textbox.AutoCompleteCustomSource.AddRange(new string[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Anguilla",
            "Antigua & Barbuda",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia & Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei Darussalam",
            "Bulgaria",
            "Burkina Faso",
            "Myanmar/Burma",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Cayman Islands",
            "Central African Republic",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Democratic Republic of the Congo",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "French Guiana",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Great Britain",
            "Greece",
            "Grenada",
            "Guadeloupe",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Israel and the Occupied Territories",
            "Italy",
            "Ivory Coast (Cote d\'Ivoire)",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kosovo",
            "Kuwait",
            "Kyrgyz Republic (Kyrgyzstan)",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Republic of Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Martinique",
            "Mauritania",
            "Mauritius",
            "Mayotte",
            "Mexico",
            "Moldova, Republic of",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Montserrat",
            "Morocco",
            "Mozambique",
            "Namibia",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Korea, Democratic Republic of (North Korea)",
            "Norway",
            "Oman",
            "Pacific Islands",
            "Pakistan",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Puerto Rico",
            "Qatar",
            "Reunion",
            "Romania",
            "Russian Federation",
            "Rwanda",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Vincent\'s & Grenadines",
            "Samoa",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovak Republic (Slovakia)",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "Korea, Republic of (South Korea)",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syria",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Timor Leste",
            "Togo",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Turks & Caicos Islands",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United States of America (USA)",
            "Uruguay",
            "Uzbekistan",
            "Venezuela",
            "Vietnam",
            "Virgin Islands (UK)",
            "Virgin Islands (US)",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.coo_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.coo_textbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.coo_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coo_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.coo_textbox.Location = new System.Drawing.Point(208, 151);
            this.coo_textbox.Name = "coo_textbox";
            this.coo_textbox.Size = new System.Drawing.Size(259, 21);
            this.coo_textbox.TabIndex = 2;
            this.coo_textbox.Text = "e.g Nigeria";
            this.coo_textbox.TextChanged += new System.EventHandler(this.coo_textbox_TextChanged);
            this.coo_textbox.Enter += new System.EventHandler(this.coo_textbox_Enter);
            this.coo_textbox.Leave += new System.EventHandler(this.coo_textbox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Country of operation";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // department_textbox
            // 
            this.department_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.department_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.department_textbox.Location = new System.Drawing.Point(209, 201);
            this.department_textbox.Name = "department_textbox";
            this.department_textbox.Size = new System.Drawing.Size(259, 20);
            this.department_textbox.TabIndex = 2;
            this.department_textbox.Text = "e.g Operations";
            this.department_textbox.TextChanged += new System.EventHandler(this.department_textbox_TextChanged);
            this.department_textbox.Enter += new System.EventHandler(this.department_textbox_Enter);
            this.department_textbox.Leave += new System.EventHandler(this.department_textbox_Leave);
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department.Location = new System.Drawing.Point(209, 181);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(72, 15);
            this.department.TabIndex = 3;
            this.department.Text = "Department";
            // 
            // designation_textbox
            // 
            this.designation_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.designation_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.designation_textbox.Location = new System.Drawing.Point(210, 253);
            this.designation_textbox.Name = "designation_textbox";
            this.designation_textbox.Size = new System.Drawing.Size(259, 20);
            this.designation_textbox.TabIndex = 2;
            this.designation_textbox.Text = "e.g Unit Head: Utilities";
            this.designation_textbox.TextChanged += new System.EventHandler(this.designation_textbox_TextChanged);
            this.designation_textbox.Enter += new System.EventHandler(this.designation_textbox_Enter);
            this.designation_textbox.Leave += new System.EventHandler(this.designation_textbox_Leave);
            // 
            // designation
            // 
            this.designation.AutoSize = true;
            this.designation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designation.Location = new System.Drawing.Point(209, 235);
            this.designation.Name = "designation";
            this.designation.Size = new System.Drawing.Size(73, 15);
            this.designation.TabIndex = 3;
            this.designation.Text = "Designation";
            // 
            // email_textbox
            // 
            this.email_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.email_textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.email_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.email_textbox.Location = new System.Drawing.Point(210, 307);
            this.email_textbox.Name = "email_textbox";
            this.email_textbox.Size = new System.Drawing.Size(259, 20);
            this.email_textbox.TabIndex = 2;
            this.email_textbox.Text = "e.g alml567";
            this.email_textbox.TextChanged += new System.EventHandler(this.email_textbox_TextChanged);
            this.email_textbox.Enter += new System.EventHandler(this.email_textbox_Enter);
            this.email_textbox.Leave += new System.EventHandler(this.email_textbox_Leave);
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(209, 287);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(87, 15);
            this.email.TabIndex = 3;
            this.email.Text = "Email | Staff ID";
            this.email.Click += new System.EventHandler(this.label6_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(206, 368);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(103, 28);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // continue_
            // 
            this.continue_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(214)))));
            this.continue_.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continue_.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.continue_.Location = new System.Drawing.Point(362, 369);
            this.continue_.Name = "continue_";
            this.continue_.Size = new System.Drawing.Size(103, 28);
            this.continue_.TabIndex = 4;
            this.continue_.Text = "Continue";
            this.continue_.UseVisualStyleBackColor = false;
            this.continue_.Click += new System.EventHandler(this.continue__Click);
            // 
            // quitSetupLabel
            // 
            this.quitSetupLabel.AutoSize = true;
            this.quitSetupLabel.Location = new System.Drawing.Point(462, 30);
            this.quitSetupLabel.Name = "quitSetupLabel";
            this.quitSetupLabel.Size = new System.Drawing.Size(26, 13);
            this.quitSetupLabel.TabIndex = 6;
            this.quitSetupLabel.Text = "Quit";
            this.quitSetupLabel.Visible = false;
            // 
            // minimizeSetupLabel
            // 
            this.minimizeSetupLabel.AutoSize = true;
            this.minimizeSetupLabel.Location = new System.Drawing.Point(405, 30);
            this.minimizeSetupLabel.Name = "minimizeSetupLabel";
            this.minimizeSetupLabel.Size = new System.Drawing.Size(47, 13);
            this.minimizeSetupLabel.TabIndex = 6;
            this.minimizeSetupLabel.Text = "Minimize";
            this.minimizeSetupLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Setup User Class";
            // 
            // minimizeSetup
            // 
            this.minimizeSetup.Image = global::TravelPass.Properties.Resources.Minimize_Window_96px;
            this.minimizeSetup.Location = new System.Drawing.Point(431, 0);
            this.minimizeSetup.Name = "minimizeSetup";
            this.minimizeSetup.Size = new System.Drawing.Size(28, 27);
            this.minimizeSetup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizeSetup.TabIndex = 5;
            this.minimizeSetup.TabStop = false;
            this.minimizeSetup.Click += new System.EventHandler(this.minimizeSetup_Click);
            this.minimizeSetup.MouseEnter += new System.EventHandler(this.minimizeSetup_MouseEnter);
            this.minimizeSetup.MouseLeave += new System.EventHandler(this.minimizeSetup_MouseLeave);
            this.minimizeSetup.MouseHover += new System.EventHandler(this.minimizeSetup_MouseHover);
            // 
            // quitSetup
            // 
            this.quitSetup.Image = global::TravelPass.Properties.Resources.Delete_96px;
            this.quitSetup.Location = new System.Drawing.Point(465, 0);
            this.quitSetup.Name = "quitSetup";
            this.quitSetup.Size = new System.Drawing.Size(28, 27);
            this.quitSetup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.quitSetup.TabIndex = 5;
            this.quitSetup.TabStop = false;
            this.quitSetup.Click += new System.EventHandler(this.pictureBox1_Click);
            this.quitSetup.MouseEnter += new System.EventHandler(this.quitSetup_MouseEnter);
            this.quitSetup.MouseLeave += new System.EventHandler(this.quitSetup_MouseLeave);
            this.quitSetup.MouseHover += new System.EventHandler(this.quitSetup_MouseHover);
            // 
            // continueSetupUserClass1
            // 
            this.continueSetupUserClass1.BackColor = System.Drawing.Color.White;
            this.continueSetupUserClass1.COO = null;
            this.continueSetupUserClass1.Dept = null;
            this.continueSetupUserClass1.Desg = null;
            this.continueSetupUserClass1.Email = null;
            this.continueSetupUserClass1.FullName = null;
            this.continueSetupUserClass1.Location = new System.Drawing.Point(203, -3);
            this.continueSetupUserClass1.Name = "continueSetupUserClass1";
            this.continueSetupUserClass1.Size = new System.Drawing.Size(290, 406);
            this.continueSetupUserClass1.TabIndex = 8;
            this.continueSetupUserClass1.Load += new System.EventHandler(this.continueSetupUserClass1_Load);
            // 
            // SetupUserClass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.minimizeSetupLabel);
            this.Controls.Add(this.quitSetupLabel);
            this.Controls.Add(this.minimizeSetup);
            this.Controls.Add(this.quitSetup);
            this.Controls.Add(this.continue_);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.email);
            this.Controls.Add(this.designation);
            this.Controls.Add(this.department);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fullname);
            this.Controls.Add(this.email_textbox);
            this.Controls.Add(this.designation_textbox);
            this.Controls.Add(this.department_textbox);
            this.Controls.Add(this.coo_textbox);
            this.Controls.Add(this.fullname_textbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.continueSetupUserClass1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupUserClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelPass";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo__setup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox fullname_textbox;
        private System.Windows.Forms.Label fullname;
        public System.Windows.Forms.TextBox coo_textbox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox department_textbox;
        private System.Windows.Forms.Label department;
        public System.Windows.Forms.TextBox designation_textbox;
        private System.Windows.Forms.Label designation;
        public System.Windows.Forms.TextBox email_textbox;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button continue_;
        private System.Windows.Forms.PictureBox quitSetup;
        private System.Windows.Forms.PictureBox minimizeSetup;
        private System.Windows.Forms.Label quitSetupLabel;
        private System.Windows.Forms.Label minimizeSetupLabel;
        private System.Windows.Forms.Panel topPanelSetup;
        private System.Windows.Forms.Label label7;
        private ContinueSetupUserClass continueSetupUserClass1;
        private System.Windows.Forms.PictureBox logo__setup;

    }
}

