using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class RecordDashboard_copy1 : Form
    {
        public RecordDashboard_copy1()
        {
            InitializeComponent();
        }

        private void RecordDashboard_Load(object sender, EventArgs e)
        {
            this.rfidCheck.Checked = true;
            this.flight_from_box.Text = flight_from;
            this.flight_to_box.Text = flight_to;
            this.flight_airline_box.Text = flight_airline;
            this.flight_date_box.Text = flight_date;
            this.flight_date_created_box.Text = flight_date_created;
        }

        private void go_to_dashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardTravelPass dashboardTravelPass = new DashboardTravelPass();
            dashboardTravelPass.FullName = fullname;
            dashboardTravelPass.Pers_ID = user_id;
            dashboardTravelPass.Pers_ROLE = pers_role_;
            dashboardTravelPass.showInfo();
            dashboardTravelPass.Show();
        }

        private string fullname;
        public String FullName {
            get { return this.fullname; }
            set { this.fullname = value; }
        }

        private string user_id;
        public String User_ID {
            get { return user_id; }
            set { this.user_id = value; }
        }

        private string pers_role_;
        public String Pers_ROLE {
            get { return pers_role_; }
            set { this.pers_role_ = value; }
        }

        private string flight_from;
        private string flight_to;
        public String Flight_From {
            get { return flight_from; }
            set { this.flight_from = value; }
        }

        public String Flight_To {
            get { return flight_to; }
            set { this.flight_to = value; }
        }

        private string[] flight_details;
        public String[] Flight_Details {
            get { return flight_details; }
            set { this.flight_details = value; }
        }

        private string flight_airline;
        public String Flight_Airline {
            get { return flight_airline; }
            set { this.flight_airline = value; }
        }

        private string flight_date;
        public string Flight_Date
        {
            get { return flight_date; }
            set { this.flight_date = value; }
        }

        private string flight_class;
        public String Flight_Class
        {
            get { return flight_class; }
            set { this.flight_class = value; }
        }

        private string flight_date_created;
        public string Flight_Date_Created
        {
            get { return flight_date_created; }
            set { this.flight_date_created = value; }
        }

        private string folder_name;
        public string Folder_Name {
            get { return folder_name; }
            set { this.folder_name = value; }
        }
        
        private Flight flight;
        public Flight Flight_ {
            get { return flight; }
            set { this.flight = value; }
        }

        public void showInfo()
        {
            Console.WriteLine(fullname);
            Console.WriteLine(user_id);
            pers_name.Text = fullname.ToUpper();
            pers_id.Text = user_id.ToUpper();
        }

        private void add_record_Click(object sender, EventArgs e)
        {
            string now_dateTime = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
            CreateRecordsDirectory(flight, "Records", "Record Details.travlr", user_id, now_dateTime);
        }

        private void CreateRecordsDirectory(Flight flight, string records_folder_name, string records_details_file_name, string user_email, string date_time_recorded) {
            try
            { 
                Console.WriteLine("Folder Name = " + flight.FolderName);
                Console.WriteLine("Records Folder Name = " + records_folder_name);
                string ffn = flight.FolderName;
                if (ffn.Contains("\""))
                {
                    string recordsFolderPathString = System.IO.Path.Combine(ffn.Replace("\"", "") /**folder path**/, records_folder_name);
                    System.IO.Directory.CreateDirectory(recordsFolderPathString);
                }
                else {
                    string recordsFolderPathString = System.IO.Path.Combine(flight.FolderName /**folder path**/, records_folder_name);
                    System.IO.Directory.CreateDirectory(recordsFolderPathString);
                }

                AddRecord addRecord = new AddRecord();
                addRecord.HasEnabledRFID = rfidCheck.Checked;
                addRecord.Flight_From = flight_from;
                addRecord.Flight_To = flight_to;
                addRecord.Flight_ = flight;
                addRecord.User_Email = user_id;
                addRecord.Fullname = fullname;
                addRecord.Flight_Class = flight_class;
                Console.WriteLine(flight_class);
                addRecord.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DialogResult dResult = MessageBox.Show("Error while creating record directory.",
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
            }
        }

        private void bunifuCards4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void view_flight_details_Click(object sender, EventArgs e)
        {
            FlightDetails flightDetails = new FlightDetails();
            flightDetails.FlightDetails_ = flight;
            flightDetails.ShowDialog();
        }

        private void update_record_Click(object sender, EventArgs e)
        {
            UpdateRecordForm updateRecordForm = new UpdateRecordForm();
            updateRecordForm.BaseFolderPathString = flight.FolderName;
            updateRecordForm.Flight_From = flight_from;
            updateRecordForm.Flight_To = flight_to;
            updateRecordForm.Flight_Final_Dest = flight.FlightFinalDest;
            updateRecordForm.Flight_ = flight;
            updateRecordForm.User_ID = user_id;
            updateRecordForm.FullName = fullname;
            updateRecordForm.Pers_ROLE = pers_role_;
            updateRecordForm.ShowDialog();
            //if (updateRecordForm.Result == "VIEW RECORD BUTTON PRESSED")
            //{
            //    this.Hide();
            //}
        }

        private void rfidSettings_Click(object sender, EventArgs e)
        {
            DataToSend dataToSend = new DataToSend();
            dataToSend.ShowDialog();
        }

        private void view_record_Click(object sender, EventArgs e)
        {
            UpdateRecordList updateRecordList = new UpdateRecordList();
            updateRecordList.Keyword = "";
            updateRecordList.BaseFolderPathString = flight.FolderName;
            updateRecordList.Flight_From = flight_from;
            updateRecordList.Flight_To = flight_to;
            updateRecordList.Flight_Final_Dest = flight.FlightFinalDest;
            updateRecordList.Flight_ = flight;
            updateRecordList.User_ID = user_id;
            updateRecordList.FullName = fullname;
            updateRecordList.Pers_ROLE = pers_role_;
            updateRecordList.ShowDialog();
            
        }
        private void rfidCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCards3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCards2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
