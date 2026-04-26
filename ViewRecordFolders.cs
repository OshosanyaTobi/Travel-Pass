using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace TravelPass
{
    public partial class ViewRecordFolders : Form
    {

        public ViewRecordFolders()
        {
            InitializeComponent();
        }

        public List<SRecord> SRecords;
        public List<SRecord> SRECORDS {
            get { return SRecords; }
            set { this.SRecords = value; }
        }

        private void ViewRecordFolders_Load(object sender, EventArgs e)
        {
            if (SRecords.Count < 1)
            {
                DialogResult dResult = MessageBox.Show("No such Record exist",
                                                                "Warning",
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning,
                                                                MessageBoxDefaultButton.Button1,
                                                                MessageBoxOptions.RightAlign,
                                                                false);
                if (dResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.scansDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.scansDataGrid.DataSource = SRecords;
            }
        }

        private void ViewRecordFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                Close();
            };
        }

        private void scansDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string scan_folder_path;
        private string scan_folder_name;
        private void scansDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                try
                {
                    this.scan_type_label.Text = dgv.CurrentRow.Cells[0].Value.ToString().Split('_').ElementAt(0).ToUpper();
                    this.go_to.Text = "VIEW " + this.scan_type_label.Text.ToUpper().ToString();
                    scan_folder_name = dgv.CurrentRow.Cells[0].Value.ToString().Trim();
                    scan_folder_path = dgv.CurrentRow.Cells[1].Value.ToString().Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        private void go_to_Click(object sender, EventArgs e)
        {
            //show View Records Here
            //will be needing scan_folder_path here

            if (this.scan_type_label.Text.Trim().ToString().Length < 1)
            {
                DialogResult dResult = MessageBox.Show("Please make sure you have clicked a Cell",
                                                                    "Error Report",
                                                                    MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Error,
                                                                    MessageBoxDefaultButton.Button1,
                                                                    MessageBoxOptions.RightAlign,
                                                                    false);
            }
            else
            {
                ViewRecord viewRecord = new ViewRecord();
                viewRecord.SRECORD = new SRecord(scan_folder_name, scan_folder_path);
                viewRecord.ScanType = this.scan_type_label.Text.ToUpper().ToString();
                viewRecord.RECORDFOLDERPATH = record_folder_path_;
                viewRecord.ShowDialog();
            }
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

        private string record_folder_name;
        public String RECORD_FOLDER_NAME {
            get { return record_folder_name; }
            set { this.record_folder_name = value; }
        }

        private Flight flight;
        public Flight Flight_
        {
            get { return flight; }
            set { this.flight = value; }
        }

        private string record_folder_path_;
        public String RECORD_FOLDER_PATH
        {
            get { return record_folder_path_; }
            set { this.record_folder_path_ = value; }
        }

        private void add_new_scan_Click(object sender, EventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.HasEnabledRFID = true;
            addRecord.Flight_From = flight_from;
            addRecord.Flight_To = flight_to;
            addRecord.HAS_STORED_RECORD_NAME = true;
            addRecord.STORED_RECORD_NAME = record_folder_name;
            addRecord.Flight_ = flight;
            addRecord.Flight_Class = flight.FlightClass;
            addRecord.User_Email = user_id;
            addRecord.Fullname = fullname;
            addRecord.ShowDialog();
            if (addRecord.JUST_HIT_DONE) {
                this.Hide();
                UpdateRecordList.doSomething @do = new UpdateRecordList.doSomething(UpdateRecordList._do);
                UpdateRecordList.sen(@do);
            }
        }

        private void delete_scan_Click(object sender, EventArgs e)
        {
            if (this.scan_type_label.Text.Trim().ToString().Length < 1)
            {
                DialogResult dResult = MessageBox.Show("Please make sure you have clicked a Cell",
                                                                    "Error Report",
                                                                    MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Error,
                                                                    MessageBoxDefaultButton.Button1,
                                                                    MessageBoxOptions.RightAlign,
                                                                    false);
            }
            else {

                DialogResult dResult = MessageBox.Show("Are you sure you want to delete this scan?",
                                                                   "Warning Report",
                                                                   MessageBoxButtons.OKCancel,
                                                                   MessageBoxIcon.Question,
                                                                   MessageBoxDefaultButton.Button1,
                                                                   MessageBoxOptions.RightAlign,
                                                                   false);
                if (dResult == DialogResult.OK) {
                    try {
                        string path_to_delete = scan_folder_path.Replace("\"", "").Trim().ToString();
                        System.IO.DirectoryInfo di = new DirectoryInfo(path_to_delete);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                        di.Delete();
                        DialogResult dRes = MessageBox.Show("Done deleting scan",
                                                                  "Information Report",
                                                                  MessageBoxButtons.OK,
                                                                  MessageBoxIcon.Information,
                                                                  MessageBoxDefaultButton.Button1,
                                                                  MessageBoxOptions.RightAlign,
                                                                  false);
                        if (dRes == DialogResult.OK) {
                            this.Hide();
                            UpdateRecordList.doSomething @do = new UpdateRecordList.doSomething(UpdateRecordList._do);
                            UpdateRecordList.sen(@do);
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("There are some issues deleting this scan",
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

        private void copy_to_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog()) {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    Console.WriteLine(fbd.SelectedPath);
                    DialogResult ddResult = MessageBox.Show("Are you sure you want to copy these folders into a specified folder?",
                                                    "Question",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly,
                                                    false);
                    if (ddResult == DialogResult.Yes)
                    {
                        Console.WriteLine("BOOM!!");
                        try
                        {
                            FileSystem.CopyDirectory(record_folder_path_, fbd.SelectedPath, UIOption.AllDialogs);
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
            }
        }

    }
}
