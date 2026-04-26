using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using TravelPass.SqlConn;
using System.Windows.Forms;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace TravelPass
{
    
    public partial class ContinueSetupUserClass : UserControl
    {
        private static int ADMIN = 1;
        private static int SUPERVISOR = 2;
        private static int USER = 3;

        public ContinueSetupUserClass()
        {
            InitializeComponent();
        }

        private void phone_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void phone_textbox_Enter(object sender, EventArgs e)
        {
            if (phone_textbox.Text == "e.g +2348185476560")
            {
                phone_textbox.Text = "";
                phone_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void phone_textbox_Leave(object sender, EventArgs e)
        {
            if (phone_textbox.Text.Length == 0)
            {
                phone_textbox.Text = "e.g +2348185476560";
                phone_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void state_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void state_textbox_Enter(object sender, EventArgs e)
        {
            if (state_textbox.Text == "e.g Lagos")
            {
                state_textbox.Text = "";
                state_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void state_textbox_Leave(object sender, EventArgs e)
        {
            if (state_textbox.Text.Length == 0)
            {
                state_textbox.Text = "e.g Lagos";
                state_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            SetupUserClass setupUserClass = new SetupUserClass();
            this.Visible = false;
            setupUserClass.BringToFront();
        }

        private void quitSetup_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void done_Click(object sender, EventArgs e)
        {
           
            if (!isValidName(passwd_textbox.Text))
            {
                MessageBox.Show("Please enter valid password (6 chars or more)");
            }
            else if (!isValidName(confirm_passwd_textbox.Text))
            {
                MessageBox.Show("Please enter valid password (6 chars or more)");
            }
            else if (!(passwd_textbox.Text.Equals(confirm_passwd_textbox.Text)))
            {
                MessageBox.Show("Both password fields are not the same");
            }
            else if (!IsValidPhoneNumber(phone_textbox.Text) && phone_textbox.Text.Equals("e.g +2348185476560"))
            {
                MessageBox.Show("Please enter valid phone number");
            }
            else if (isValidName(state_textbox.Text) && state_textbox.Text.Equals("e.g Lagos"))
            {
                MessageBox.Show("Please enter state(location)");
            }
            else if (isValidName(user_class_combo.Text) && user_class_combo.Text.Equals("Set Role"))
            {
                MessageBox.Show("Please enter valid role");
            }
            else {
                createPersonnelAccount(this.FullName,
                    this.COO,
                    this.Dept,
                    this.Desg,
                    this.Email,
                    passwd_textbox.Text.Trim(),
                    phone_textbox.Text.Trim(),
                    state_textbox.Text.Trim(),
                    user_class_combo.Text.Trim());
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
            return System.Text.RegularExpressions.Regex.Match(mail, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$").Success;
            
        }

        public static bool IsValidPhoneNumber(string number)
        {
            return System.Text.RegularExpressions.Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text.Equals("Show"))
            {
                linkLabel1.Text = "Hide";
                passwd_textbox.PasswordChar = '\0';
            }
            else {
                linkLabel1.Text = "Show";
                passwd_textbox.PasswordChar = '*';
            }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel2.Text.Equals("Show"))
            {
                linkLabel2.Text = "Hide";
                confirm_passwd_textbox.PasswordChar = '\0';
            }
            else
            {
                linkLabel2.Text = "Show";
                confirm_passwd_textbox.PasswordChar = '*';
            }
        }

        private void user_class_combo_Enter(object sender, EventArgs e)
        {
            if (user_class_combo.Text == "Please set personnel role")
            {
                user_class_combo.Text = "";
                user_class_combo.ForeColor = SystemColors.WindowText;
            }
        }

        private void user_class_combo_Leave(object sender, EventArgs e)
        {
            if (user_class_combo.Text.Length == 0)
            {
                user_class_combo.Text = "Please set personnel role";
                user_class_combo.ForeColor = SystemColors.GrayText;
            }
        }

        private string fullname;
        public String FullName {
            get
            {
                return this.fullname;
            }
            set
            {
                this.fullname = value;
            }
        }

        private string coo;
        public String COO
        {
            get
            {
                return this.coo;
            }
            set
            {
                this.coo = value;
            }
        }

        private string dept;
        public String Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }

        private string desg;
        public String Desg
        {
            get
            {
                return this.desg;
            }
            set
            {
                this.desg = value;
            }
        }

        private string mail;
        public String Email
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        private void createPersonnelAccount(string fullname, string coo, string dept, string desg, string mail, string pwd, string phone, string state, string role) {

            //string connString = @"Data Source=ALML-TRAVELPASS\SQLEXPRESS;Initial Catalog=TravelPassDB;Integrated Security=True";
            string connString = @"Data Source=192.168.1.100\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=TravelPassDB;User ID=sa;Password=123456789";
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            try
            {
                // Insert statement.
                string sql = "INSERT INTO PERSONNEL (PERS_NAME, PERS_COO, PERS_DEPT, PERS_DESG, PERS_EMAIL, PERS_PASSWORD, PERS_PHONE, PERS_STATE_LOCATION, PERS_ROLE) "
                                                 + " VALUES (@PERS_NAME, @PERS_COO, @PERS_DEPT, @PERS_DESG, @PERS_EMAIL, @PERS_PASSWORD, @PERS_PHONE, @PERS_STATE_LOCATION, @PERS_ROLE) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                // Add parameter @highSalary (Write shorter)
                SqlParameter nameParam = cmd.Parameters.Add("@PERS_NAME", SqlDbType.VarChar);
                nameParam.Value = fullname;

                // Add parameter @lowSalary (more shorter).
                cmd.Parameters.Add("@PERS_COO", SqlDbType.VarChar).Value = coo;
                cmd.Parameters.Add("@PERS_DEPT", SqlDbType.VarChar).Value = dept;
                cmd.Parameters.Add("@PERS_DESG", SqlDbType.VarChar).Value = desg;
                cmd.Parameters.Add("@PERS_EMAIL", SqlDbType.VarChar).Value = mail;
                cmd.Parameters.Add("@PERS_PASSWORD", SqlDbType.VarChar).Value = pwd;
                cmd.Parameters.Add("@PERS_PHONE", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("@PERS_STATE_LOCATION", SqlDbType.VarChar).Value = state;
                cmd.Parameters.Add("@PERS_ROLE", SqlDbType.VarChar).Value = role;

                // Execute Command (for Delete,Insert or Update).
                int rowCount = cmd.ExecuteNonQuery();
                int insertedID = 0;

                string sql_ = "SELECT IDENT_CURRENT('PERSONNEL')";
                SqlCommand cmd_ = connection.CreateCommand();
                cmd_.CommandText = sql_;
                SqlDataReader sql_reader = cmd_.ExecuteReader();
                while(sql_reader.Read()){
                    insertedID = int.Parse(sql_reader[0].ToString()) + 1;
                }
                Console.WriteLine("Row Count affected = " + rowCount);
                DialogResult dResult = MessageBox.Show(getPersonnelID(role, insertedID.ToString()) + " was created successfully",
                                                        "Success Report",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information,
                                                        MessageBoxDefaultButton.Button1,
                                                        MessageBoxOptions.RightAlign,
                                                        false);
                if (dResult == DialogResult.OK)
                {
                    Console.WriteLine("Weldone");
                    //SetupUserClass s = new SetupUserClass();
                    //s.hide();
                    this.Parent.Hide(); 
                    CreateAnotherPersonnel createAnotherPersonnel = new CreateAnotherPersonnel();
                    createAnotherPersonnel.Show();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                DialogResult dResult = MessageBox.Show("Error while creating personnel. Issue: " + e.Message,
                                                        "Error Report",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error,
                                                        MessageBoxDefaultButton.Button1,
                                                        MessageBoxOptions.RightAlign,
                                                        false);
                
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
                Console.WriteLine("Closed connection");
            }
        }

        private string getPersonnelID(string p_role, string ID) {
            string role = "";
            string uid = "";

            if (p_role.Equals("Admin")) {
                role = "ADM";
            }
            else if (p_role.Equals("User")) {
                role = "USR";
            }
            else if (p_role.Equals("Supervisor")) {
                role = "SUP";
            }
            
            if (ID.Length == 1) {
                uid += role.ToUpper() + "00" + ID;
            }
            else if (ID.Length == 2)
            {
                uid += role.ToUpper() + "0" + ID;
            }
            else {
                uid += role.ToUpper() + ID;
            }
            return uid;
        }
    }
}
