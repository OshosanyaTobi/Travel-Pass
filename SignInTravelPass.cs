using ADODB;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class SignInTravelPass : Form
    {
        bool foundPersonnel = false;
        string pers_id = "";
        string pers_role = "";
        string pers_name = "";
        int insertedID = 0;

        int click_tracker = 0;

        public SignInTravelPass()
        {
            InitializeComponent();
            //System.IO.Directory.SetCurrentDirectory(Application.StartupPath); //iC<>deiDesign
            _SQLite.Connect();
        }

        private string getPersonnelID(string p_role, string ID)
        {
            string role = "";
            string uid = "";

            if (p_role.Equals("Admin"))
            {
                role = "ADM";
            }
            else if (p_role.Equals("User"))
            {
                role = "USR";
            }
            else if (p_role.Equals("Supervisor"))
            {
                role = "SUP";
            }

            if (ID.Length == 1)
            {
                uid += role.ToUpper() + "00" + ID;
            }
            else if (ID.Length == 2)
            {
                uid += role.ToUpper() + "0" + ID;
            }
            else
            {
                uid += role.ToUpper() + ID;
            }
            return uid;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void SignIn()
        {
            Recordset rs = new Recordset();
            rs.Open("SELECT * FROM tblUsers " +
                    "WHERE userName = '" + signin_email_textbox.Text.Trim() + "' " +
                    "AND password = '" + _Encryption.Encrypt(signin_pwd_textbox.Text) + "'", _SQLite.connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);
            if (rs.RecordCount > 0)
            {
                this.Hide();
                DashboardTravelPass dashboard = new DashboardTravelPass();
                dashboard.FullName = rs.Fields["firstName"].Value.ToString() + " " + rs.Fields["lastName"].Value.ToString();
                dashboard.Pers_ID = rs.Fields["userName"].Value.ToString();
                dashboard.Pers_ROLE = rs.Fields["roleID"].Value.ToString();
                dashboard.showInfo();
                dashboard.Show();
            }
            else
            {
                rs.Close();
                MessageBox.Show("Unable to verify user credentials, please try again.", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rs.Close();
        }

        private void continue__Click(object sender, EventArgs e)
        {
            try
            {
                SignIn();
            }
            catch {

                MessageBox.Show("An unknown problem occured, please trky again.", "Problem Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void QueryPersonnel(SqlConnection conn, string email, string password)
        {
            string sql = "SELECT PERS_NAME, PERS_EMAIl, PERS_PASSWORD, PERS_ROLE, PERS_ID FROM PERSONNEL";

            // Create command.
            SqlCommand cmd = new SqlCommand();

            // Set connection for Command.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        int nameIndex = reader.GetOrdinal("PERS_NAME");
                        string name = reader.GetString(nameIndex);

                        int mailIndex = reader.GetOrdinal("PERS_EMAIL");
                        string mail = reader.GetString(mailIndex);

                        int pwdIndex = reader.GetOrdinal("PERS_PASSWORD");
                        string pwd = reader.GetString(pwdIndex);

                        int roleIndex = reader.GetOrdinal("PERS_ROLE");
                        string role = reader.GetString(roleIndex);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("PERS_EMAIL:" + mail);
                        Console.WriteLine("PERS_PASSWORD" + pwd);
                        Console.WriteLine("PERS_ROLE:" + role);
                        if (mail.Equals(email) && pwd.Equals(password)) {
                            foundPersonnel = true;
                            pers_role = role;
                            pers_name = name;
                            pers_id = role.ToUpper() + " - " + mail;
                            break;
                        }
                    }
                    if (!foundPersonnel) {
                        DialogResult dResult = MessageBox.Show("Your credentials are incorrect. Try again",
                                                        "Error Report",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error,
                                                        MessageBoxDefaultButton.Button1,
                                                        MessageBoxOptions.RightAlign,
                                                        false);
                    }
                }
            }
        }

        private void signin_email_textbox_Leave(object sender, EventArgs e)
        {
            if (signin_email_textbox.Text.Length == 0)
            {
                signin_email_textbox.Text = "Email or User ID";
                signin_email_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void signin_email_textbox_Enter(object sender, EventArgs e)
        {
            if (signin_email_textbox.Text == "Email or User ID")
            {
                signin_email_textbox.Text = "";
                signin_email_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void signin_pwd_textbox_Leave(object sender, EventArgs e)
        {
            if (signin_pwd_textbox.Text.Length == 0)
            {
                signin_pwd_textbox.Text = "Password";
                signin_pwd_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void signin_pwd_textbox_Enter(object sender, EventArgs e)
        {
            if (signin_pwd_textbox.Text == "Password")
            {
                signin_pwd_textbox.Text = "";
                signin_pwd_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void quitSetup_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void minimizeSetup_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SignInTravelPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                continue_.PerformClick();
            }
        }

        private void logo__setup_Click(object sender, EventArgs e)
        {
            
        }

        private void logo__setup_DoubleClick(object sender, EventArgs e)
        {
            click_tracker += 1;

            if (click_tracker >= 2) {
                click_tracker = 0;

                if (MessageBox.Show("Do you want to go ahead with the external file upload?", "External File Upload", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    return;
                };

                ContinueWithAdminUpload ContinueWithAdminUpload = new ContinueWithAdminUpload();
                ContinueWithAdminUpload.ShowDialog();


            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to go ahead with the external file upload?", "External File Upload", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            };

            ContinueWithAdminUpload ContinueWithAdminUpload = new ContinueWithAdminUpload();
            ContinueWithAdminUpload.ShowDialog();
        }

        private void SignInTravelPass_Load(object sender, EventArgs e)
        {

        }
    }
}
