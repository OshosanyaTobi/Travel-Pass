using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace TravelPass
{
    public partial class SignInTravelPass_Copy : Form
    {
        bool foundPersonnel = false;
        string pers_id = "";
        string pers_role = "";
        string pers_name = "";
        int insertedID = 0;

        public SignInTravelPass_Copy()
        {
            InitializeComponent();
            //System.IO.Directory.SetCurrentDirectory(Application.StartupPath); //iC<>deiDesign
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

        private void continue__Click(object sender, EventArgs e)
        {
            
            //// Get connection.
            ////string connString = @"Data Source=ALML-TRAVELPASS\SQLEXPRESS;Initial Catalog=TravelPassDB;Integrated Security=True";
            //string connString = @"Data Source=192.168.1.100\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=TravelPassDB;User ID=sa;Password=123456789";
            //SqlConnection connection = new SqlConnection(connString);
            //try
            //{
            //    connection.Open();
            //    QueryPersonnel(connection, signin_email_textbox.Text.Trim(), signin_pwd_textbox.Text.Trim());
            //    if (foundPersonnel) {
            //        Console.WriteLine("Found Personnel");
            //        string sql_ = "SELECT IDENT_CURRENT('PERSONNEL')";
            //        SqlCommand cmd_ = connection.CreateCommand();
            //        cmd_.CommandText = sql_;
            //        SqlDataReader sql_reader = cmd_.ExecuteReader();
            //        while (sql_reader.Read())
            //        {
            //            insertedID = int.Parse(sql_reader[0].ToString()) + 1;
            //            Console.WriteLine("ID = " + insertedID);
            //        }
            //        //pers_id = getPersonnelID(pers_role, insertedID.ToString());

            //        Console.WriteLine("Another Weldone");
            //        CreateAnotherPersonnel createAnotherPersonnel = new CreateAnotherPersonnel();
            //        createAnotherPersonnel.Hide();
            //        this.Hide();
            //        DashboardTravelPass dashboard = new DashboardTravelPass();

            //        dashboard.FullName = pers_name;
            //        dashboard.Pers_ID = pers_id;
            //        dashboard.Pers_ROLE = pers_role;
            //        dashboard.showInfo();
            //        dashboard.Show();

            //        //DialogResult dResult = MessageBox.Show("Welcome " + pers_id,
            //        //                                    "Success Report",
            //        //                                    MessageBoxButtons.OK,
            //        //                                    MessageBoxIcon.Information,
            //        //                                    MessageBoxDefaultButton.Button1,
            //        //                                    MessageBoxOptions.RightAlign,
            //        //                                    false);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex);
            //    Console.WriteLine(ex.StackTrace);
            //    DialogResult dResult = MessageBox.Show("Error while logging you in. Issue: " + ex.Message,
            //                                            "Error Report",
            //                                            MessageBoxButtons.OK,
            //                                            MessageBoxIcon.Error,
            //                                            MessageBoxDefaultButton.Button1,
            //                                            MessageBoxOptions.RightAlign,
            //                                            false);
            //}
            //finally
            //{
            //    // Close connection.
            //    connection.Close();
            //    // Dispose object, freeing Resources.
            //    connection.Dispose();
            //}       
            var collection_of_objects =
               (from line in File.ReadAllLines("C:/TravelPass Files/csv files/personnel.csv")
                let parts = line.Split(',')
                select new
                {
                    name = parts[0],
                    id = parts[1],
                    pass = parts[2],
                    role = parts[3],
                }
               ).ToList();
            string[] user_name_data = new string[collection_of_objects.Count];
            string[] user_id_data = new string[collection_of_objects.Count];
            string[] user_pass_data = new string[collection_of_objects.Count];
            string[] user_role_data = new string[collection_of_objects.Count];
            string[] user_signin_data = new string[collection_of_objects.Count];
            for (int i = 0; i < collection_of_objects.Count; i++)
            {
                user_name_data[i] = collection_of_objects[i].name.Trim();
                user_id_data[i] = collection_of_objects[i].id.Trim();
                user_pass_data[i] = collection_of_objects[i].pass.Trim();
                user_role_data[i] = collection_of_objects[i].role.Trim();
                user_signin_data[i] = collection_of_objects[i].id.Trim() +"=="+ collection_of_objects[i].pass.Trim();
                
            }
            //Console.WriteLine("length of user data is = " + user_name_data.Length);
            //foreach (string signin in user_signin_data) {
            //    Console.WriteLine(signin);
            //}
            bool found = false;
            int user_index = 0;
            for (int i = 0; i < collection_of_objects.Count; i++) {
                if (user_signin_data[i] == signin_email_textbox.Text.Trim() + "==" + signin_pwd_textbox.Text.Trim()) {
                    Console.WriteLine(user_name_data[i]);
                    user_index = i;
                    found = true;
                }
            }
            if (!found)
            {
                DialogResult dResult = MessageBox.Show("Error: Cannot find user. Please try again!!",
                                                        "Error Report",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error,
                                                        MessageBoxDefaultButton.Button1,
                                                        MessageBoxOptions.RightAlign,
                                                        false);
            }
            else {
                this.Hide();
                DashboardTravelPass dashboard = new DashboardTravelPass();
                dashboard.FullName = user_name_data[user_index];
                dashboard.Pers_ID = user_id_data[user_index];
                dashboard.Pers_ROLE = user_role_data[user_index];
                dashboard.showInfo();
                dashboard.Show();
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
    }
}
