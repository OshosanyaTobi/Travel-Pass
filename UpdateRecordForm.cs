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
    public partial class UpdateRecordForm : Form
    {
        public UpdateRecordForm()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            UpdateRecordList updateRecordList = new UpdateRecordList();
            updateRecordList.Keyword = this.record_keyword.Text.Trim().ToString();
            updateRecordList.BaseFolderPathString = baseFolderPathString;
            updateRecordList.Flight_From = flight_from;
            updateRecordList.Flight_To = flight_to;
            updateRecordList.Flight_Final_Dest = final_dest;
            updateRecordList.Flight_ = flight;
            updateRecordList.User_ID = user_id;
            updateRecordList.FullName = fullname;
            updateRecordList.Pers_ROLE = pers_role_;
            this.Hide();
            updateRecordList.ShowDialog();
            //if (updateRecordList.Result == "VIEW RECORD BUTTON PRESSED")
            //{
            //    result = "VIEW RECORD BUTTON PRESSED";
            //    this.Close();
            //}
        }

        private string result;
        public String Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

        private string fullname;
        public String FullName
        {
            get { return this.fullname; }
            set { this.fullname = value; }
        }

        private string user_id;
        public String User_ID
        {
            get { return user_id; }
            set { this.user_id = value; }
        }

        private string pers_role_ = "";
        public String Pers_ROLE
        {
            get { return pers_role_; }
            set { this.pers_role_ = value; }
        }


        private string flight_from;
        private string flight_to;
        public String Flight_From
        {
            get { return flight_from; }
            set { this.flight_from = value; }
        }

        public String Flight_To
        {
            get { return flight_to; }
            set { this.flight_to = value; }
        }

        private string final_dest;
        public String Flight_Final_Dest
        {
            get { return final_dest; }
            set { this.final_dest = value; }
        }


        private Flight flight;
        public Flight Flight_
        {
            get { return flight; }
            set { this.flight = value; }
        }

        private string baseFolderPathString;
        public String BaseFolderPathString
        {
            get { return baseFolderPathString; }
            set { this.baseFolderPathString = value; }
        }
    }
}
