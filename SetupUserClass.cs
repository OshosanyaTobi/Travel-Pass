//Arik Air
//Air Nigeria
//Allied Air
//IRS Airlines
//Pan African Airlines
//Air Afrique
//Air France
//KLM
//Air India
//Atlantic Express
//Alitalia
//British Airways
//Bellview Airlines
//China Southern Airlines
//Delta Airlines
//Emirates
//Egypt Air
//Ethiopian Airlines
//Ghana Airways
//Kenya Airways
//Lufthansa German Airlines
//Middle East Airlines
//Qatar Airways
//Saudi Air
//South African Airlines
//Turkish Airlines
//Virgin Atlantic
//Virgin Nigeria

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TravelPass
{
    public partial class SetupUserClass : Form
    {

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        //public static extern bool ReleaseCapture();

        public SetupUserClass()
        {

            InitializeComponent();
            continueSetupUserClass1.Hide(); //continueSetupUserClass1.Visible = false;
            continueSetupUserClass1.SendToBack();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void coo_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void coo_textbox_Leave(object sender, EventArgs e)
        {
            if (coo_textbox.Text.Length == 0)
            {
                coo_textbox.Text = "e.g Nigeria";
                coo_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void coo_textbox_Enter(object sender, EventArgs e)
        {
            if (coo_textbox.Text == "e.g Nigeria")
            {
                coo_textbox.Text = "";
                coo_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void quitSetup_MouseEnter(object sender, EventArgs e)
        {
            quitSetupLabel.Visible = true;
        }

        private void quitSetup_MouseHover(object sender, EventArgs e)
        {
            quitSetupLabel.Visible = true;
        }

        private void quitSetup_MouseLeave(object sender, EventArgs e)
        {
            quitSetupLabel.Visible = false;
        }

        private void minimizeSetup_MouseLeave(object sender, EventArgs e)
        {
            minimizeSetupLabel.Visible = false;
        }

        private void minimizeSetup_MouseHover(object sender, EventArgs e)
        {
            minimizeSetupLabel.Visible = true;
        }

        private void minimizeSetup_MouseEnter(object sender, EventArgs e)
        {
            minimizeSetupLabel.Visible = true;
        }

        private void minimizeSetup_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //private void SetupForm_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}

        //private void panel1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}

        //private void topPanelSetup_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}

        public void hide() {
            this.Hide();
        }

        private string fullname_ = "";
        public String FullName
        {
            get { return fullname_; }
            set { this.fullname_ = value; }
        }

        private string pers_id_ = "";
        public String Pers_ID
        {
            get { return pers_id_; }
            set { this.pers_id_ = value; }
        }

        private string pers_role_ = "";
        public String Pers_ROLE
        {
            get { return pers_role_; }
            set { this.pers_role_ = value; }

        }
        private void cancel_Click(object sender, EventArgs e)
        {
            if (this.fromDashboard)
            {
                this.hide();
                DashboardTravelPass dashboard = new DashboardTravelPass();
                dashboard.FullName = fullname_;
                dashboard.Pers_ID = pers_id_;
                dashboard.Pers_ROLE = pers_role_;
                dashboard.showInfo();
                dashboard.Show();
            }
            else {
                Application.Exit();
            }
        }

        private void fullname_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fullname_textbox_Leave(object sender, EventArgs e)
        {
            if (fullname_textbox.Text.Length == 0)
            {
                fullname_textbox.Text = "e.g Chibuzor Afonja";
                fullname_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void fullname_textbox_Enter(object sender, EventArgs e)
        {
            if (fullname_textbox.Text == "e.g Chibuzor Afonja")
            {
                fullname_textbox.Text = "";
                fullname_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void department_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void department_textbox_Leave(object sender, EventArgs e)
        {
            if (department_textbox.Text.Length == 0)
            {
                department_textbox.Text = "e.g Operations";
                department_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void department_textbox_Enter(object sender, EventArgs e)
        {
            if (department_textbox.Text == "e.g Operations")
            {
                department_textbox.Text = "";
                department_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void designation_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void designation_textbox_Leave(object sender, EventArgs e)
        {
            if (designation_textbox.Text.Length == 0)
            {
                designation_textbox.Text = "e.g Unit Head: Utilities";
                designation_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void designation_textbox_Enter(object sender, EventArgs e)
        {
            if (designation_textbox.Text == "e.g Unit Head: Utilities")
            {
                designation_textbox.Text = "";
                designation_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void email_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_textbox_Leave(object sender, EventArgs e)
        {
            if (email_textbox.Text.Length == 0)
            {
                email_textbox.Text = "e.g alml567";
                email_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void email_textbox_Enter(object sender, EventArgs e)
        {
            if (email_textbox.Text == "e.g alml567")
            {
                email_textbox.Text = "";
                email_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void continue__Click(object sender, EventArgs e)
        {
            if (isValidName(fullname_textbox.Text) && fullname_textbox.Text.Equals("e.g Chibuzor Afonja"))
            {
                MessageBox.Show("Please enter valid full name");
            }
            else if (isValidName(coo_textbox.Text) && coo_textbox.Text.Equals("e.g Nigeria"))
            {
                MessageBox.Show("Please enter valid country of operation");
            }
            else if (isValidName(department_textbox.Text) && department_textbox.Text.Equals("e.g Operations"))
            {
                MessageBox.Show("Please enter valid department");
            }
            else if (isValidName(designation_textbox.Text) && designation_textbox.Text.Equals("e.g Unit Head: Utilities"))
            {
                MessageBox.Show("Please enter valid Designation");
            }
            else if (!isValidEmail(email_textbox.Text) && email_textbox.Text.Equals("e.g chibuzorafonja@travelpass.com"))
            {
                MessageBox.Show("Please enter valid email address");
            }
            else if (!isValidEmail(email_textbox.Text))
            {
                MessageBox.Show("Please enter valid email address");
            }
            else {
                continueSetupUserClass1.Visible = true;
                continueSetupUserClass1.FullName = fullname_textbox.Text.Trim();
                continueSetupUserClass1.COO = coo_textbox.Text.Trim();
                continueSetupUserClass1.Dept = department_textbox.Text.Trim();
                continueSetupUserClass1.Desg = designation_textbox.Text.Trim();
                continueSetupUserClass1.Email = email_textbox.Text.Trim();
                continueSetupUserClass1.BringToFront();
            }

        }

        private bool isValidName(String fullname)
        {
            bool b = false;
            if (fullname.Length < 1)
            {
                b = false;
            }
            else
            {
                b = true;
            }
            return b;
        }

        private bool isValidEmail(String mail)
        {
            //return System.Text.RegularExpressions.Regex.Match(mail, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$").Success;
            return true; //for the sake of STAFF ID passage.
        }

        public static bool IsValidPhoneNumber(string number)
        {
            return System.Text.RegularExpressions.Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }


        private void continueSetupUserClass1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool fromDashboard = false;
        public bool FromDashBoard {
            get {
                return fromDashboard;
            }
            set {
                this.fromDashboard = value;
            }
        }
    }
}
