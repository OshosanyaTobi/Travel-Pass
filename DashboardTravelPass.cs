using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace TravelPass
{
    public partial class DashboardTravelPass : Form
    {
        public DashboardTravelPass()
        {
            InitializeComponent();
        }

        public void showInfo() {
            pers_name.Text = fullname.ToUpper();
            pers_id.Text = pers_id_.ToUpper();
            if (!pers_role_.ToUpper().Equals("ADMIN"))
            {
                create_user.Visible = false;
                connectFlag.Visible = false;
                syncButton.Text = "Move Flight Records to Server PC";
            }
            else {
                makeConnectFlag();
                create_user.Visible = true;
                connectFlag.Visible = true;
                syncButton.Text = "Move Flight Records to WD Machine";
            }
        }

        private void makeConnectFlag() {
            DriveInfo[] allDevices = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDevices)
            {
                Console.WriteLine(d.Name);
                if (d.Name.Contains(@"Z:") && d.IsReady)
                {
                    connectFlag.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
                    connectFlag.Text = "Connected to WD";
                }
                else {
                    connectFlag.ForeColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    connectFlag.Text = "Not Connected to WD";
                }
            }
        }

        private string fullname = "";
        public String FullName {
            get { return fullname; }
            set { this.fullname = value; }
        }

        private string pers_id_ = "";
        public String Pers_ID
        {
            get { return pers_id_; }
            set { this.pers_id_ = value; }
        }

        private string pers_role_ = "";
        public String Pers_ROLE {
            get { return pers_role_; }
            set { this.pers_role_ = value; }
        }

        private string message;
        public String Message {
            get { return message;  }
            set { this.message = value; }
        }

        private void sign_out_click(object sender, EventArgs e)
        {
            this.Hide();
            SignInTravelPass signInTravelPass = new SignInTravelPass();
            signInTravelPass.Show();
        }

        private void create_user_click(object sender, EventArgs e)
        {
            this.Hide();
            SetupUserClass setupUserClass = new SetupUserClass();
            setupUserClass.FromDashBoard = true;
            setupUserClass.FullName = fullname;
            setupUserClass.Pers_ID = pers_id_;
            setupUserClass.Pers_ROLE = pers_role_;
            setupUserClass.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void new_flight_Click(object sender, EventArgs e)
        {
            CreateNewFlight createNewFlight = new CreateNewFlight();
            createNewFlight.FullName = this.fullname;
            createNewFlight.User_ID = this.pers_id_;
            createNewFlight.Pers_ROLE = this.pers_role_;
            Console.WriteLine(createNewFlight.FullName);
            Console.WriteLine("HereHere");
            createNewFlight.ShowDialog();
            try
            {
                if (createNewFlight.Result.Equals("SUCCESS_FLIGHT"))
                {
                    this.Hide();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void DashboardTravelPass_Load(object sender, EventArgs e)
        {
            
        }

        private void cont_flight_Click(object sender, EventArgs e)
        {
            ContinueFlightForm continueFlightForm = new ContinueFlightForm();
            continueFlightForm.FullName = fullname;
            continueFlightForm.Pers_ID = pers_id_;
            continueFlightForm.Pers_ROLE = pers_role_;
            continueFlightForm.ShowDialog();
            if (continueFlightForm.Result == "CONTINUE FLIGHT BUTTON PRESSED") {
                this.Hide();
            }
        }

        private void view_flights_Click(object sender, EventArgs e)
        {
            try
            {
                ContinueFlightList continueFlightList = new ContinueFlightList();
                continueFlightList.FilterFlightNumber = "";
                continueFlightList.FullName = fullname;
                continueFlightList.Pers_ID = pers_id_;
                continueFlightList.Pers_ROLE = pers_role_;
                continueFlightList.ShowDialog();
                if (continueFlightList.Result == "CONTINUE FLIGHT BUTTON PRESSED")
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private string result;
        public String Result {
            get { return result; }
            set { this.result = value; }
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            if (pers_role_.ToUpper().Equals("ADMIN"))
            {
                DialogResult ddResult = MessageBox.Show("Are you sure you want to move folders from your local database to the WD Machine?",
                                                    "Question",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly,
                                                    false);
                if (ddResult == DialogResult.Yes)
                {
                    Console.WriteLine("BOOM!!");
                    string sourcePath = @"c:\Users\Public\TravelPass\Flights";
                    string destinationPath = @"z:\TravelPass\Flights";
                    try
                    {
                        FileSystem.MoveDirectory(sourcePath, destinationPath, UIOption.AllDialogs);
                    }
                    catch (Exception ex)
                    {
                        DialogResult dResult = MessageBox.Show("Stopped Moving Files!! Something went wrong. Issue : " + ex.Message,
                                                                                "Error Report",
                                                                                MessageBoxButtons.OK,
                                                                                MessageBoxIcon.Error,
                                                                                MessageBoxDefaultButton.Button1,
                                                                                MessageBoxOptions.DefaultDesktopOnly,
                                                                                false);
                    }
                }
            }
            else {
                DialogResult ddResult = MessageBox.Show("Are you sure you want to move folders from your local database to the Server PC?",
                                                    "Question",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly,
                                                    false);
                if (ddResult == DialogResult.Yes)
                {
                    Console.WriteLine("BOOM!!");
                    string sourcePath = @"c:\TravelPass\Flights";
                    string destinationPath = @"z:\TravelPass\Flights";
                    try
                    {
                        FileSystem.MoveDirectory(sourcePath, destinationPath, UIOption.AllDialogs);
                    }
                    catch (Exception ex)
                    {
                        DialogResult dResult = MessageBox.Show("Stopped Moving Files!! Something went wrong. Issue : " + ex.Message ,
                                                                                "Error Report",
                                                                                MessageBoxButtons.OK,
                                                                                MessageBoxIcon.Error,
                                                                                MessageBoxDefaultButton.Button1,
                                                                                MessageBoxOptions.DefaultDesktopOnly,
                                                                                false);
                    }
                }
            }
            
        }
    }
}
