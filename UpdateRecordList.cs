using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class UpdateRecordList : Form
    {
        public delegate void doSomething(bool t);

        public static void _do(bool t)
        {
            if (t)
            {
                view_record_.PerformClick();
            }
        }
        public static void sen(doSomething ds)
        {
            ds(true);
        }

        static string qq_q;
        static string record_folder_path;
        static string recorded_by_name;
        static string recorded_by_email;
        static string scanned_passport_number;
        static string scanned_passport_name;
        static string date_time_recorded;
        static string flight_from;
        static string flight_to;
        static string final_destination;

        string baseFolderPathString;
        static List<VRecord> vRecords = new List<VRecord>();
        static List<SRecord> sRecords = new List<SRecord>();
        string[] read_lines;

        public UpdateRecordList()
        {
            InitializeComponent();
        }

        public String BaseFolderPathString
        {
            get { return baseFolderPathString; }
            set { this.baseFolderPathString = value; }
        }

        private string keyword;
        public String Keyword
        {
            get { return keyword; }
            set { this.keyword = value; }
        }

        private string result;
        public String Result
        {
            get { return result; }
            set { this.result = value; }
        }

        private static void view_record_Click(object sender, EventArgs e)
        {
            //sRecords.Clear();
            //if (flight_to_box_.TextLength < 1 || flight_from_box_.TextLength < 1 || datetime_recorded_box_.TextLength < 1 || recordedby_name_box_.TextLength < 1 || recordedby_email_box_.TextLength < 1)
            //{
            //    DialogResult dResult = MessageBox.Show("Please make sure you have clicked a Cell",
            //                                                        "Error Report",
            //                                                        MessageBoxButtons.OK,
            //                                                        MessageBoxIcon.Error,
            //                                                        MessageBoxDefaultButton.Button1,
            //                                                        MessageBoxOptions.RightAlign,
            //                                                        false);
            //}
            //else
            //{
            //    //this.result = "VIEW RECORD BUTTON PRESSED";
            //    string recordFolderPathString_ = "";
            //    string eachRecordFolderName = "";
            //    string eachRecordFolderPathString = "";
            //    if (record_folder_path.Contains("\""))
            //    {
            //        recordFolderPathString_ = System.IO.Path.Combine(record_folder_path.Replace("\"", "").Trim().ToString() /**folder path**/, "Scans");
            //        System.IO.Directory.CreateDirectory(recordFolderPathString_);
            //    }
            //    else
            //    {
            //        recordFolderPathString_ = System.IO.Path.Combine(record_folder_path.Trim().ToString() /**folder path**/, "Scans");
            //        System.IO.Directory.CreateDirectory(recordFolderPathString_);
            //    }
            //    string[] dirs = System.IO.Directory.GetDirectories(recordFolderPathString_);
            //    string record_folder_name = "";
            //    foreach (string dir in dirs)
            //    {
            //        Console.WriteLine(dir);
            //        int it = dir.LastIndexOf(@"\");
            //        Console.WriteLine(it);
            //        Console.WriteLine(dir.Length);
            //        Console.WriteLine(dir.Substring(it, dir.Length - it).Replace(@"\", ""));

            //        string qq = dir.Remove(dir.LastIndexOf(@"\"));
            //        string qqq = qq.Remove(qq.LastIndexOf(@"\"));
            //        Console.WriteLine(qqq);
            //        int it_ = qqq.LastIndexOf(@"\");
            //        record_folder_name = qqq.Substring(it_, qqq.Length - it_).Replace(@"\", "");
            //        Console.WriteLine("Record FOlder Name = " + record_folder_name);

            //        eachRecordFolderPathString = dir;
            //        eachRecordFolderName = dir.Substring(it, dir.Length - it).Replace(@"\", "");
            //        SRecord sRecord = new SRecord(eachRecordFolderName, eachRecordFolderPathString);
            //        sRecords.Add(sRecord);
            //    }
            //    //show View record Folders here
            //    ViewRecordFolders viewRecordFolders = new ViewRecordFolders();
            //    viewRecordFolders.SRECORDS = sRecords;
            //    viewRecordFolders.Flight_From = flight_from;
            //    viewRecordFolders.Flight_To = flight_to;
            //    viewRecordFolders.Flight_ = flight;
            //    viewRecordFolders.User_ID = user_id;
            //    viewRecordFolders.FullName = fullname;
            //    viewRecordFolders.RECORD_FOLDER_NAME = record_folder_name;
            //    viewRecordFolders.ShowDialog();

            //}
        }

        private string pers_role_ = "";
        public String Pers_ROLE
        {
            get { return pers_role_; }
            set { this.pers_role_ = value; }
        }

        private void UpdateRecordList_Load(object sender, EventArgs e)
        {
            if (!pers_role_.ToUpper().Equals("ADMIN"))
            {
                try
                {
                    vRecords.Clear();
                    if (keyword.ToString().Length < 1)
                    {
                        string[] dirs;
                        if (baseFolderPathString.Contains("\""))
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Replace("\"", "").Trim().ToString() + @"\Records");
                        }
                        else
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Trim().ToString() + @"\Records");
                        }
                        foreach (string dir in dirs)
                        {
                            read_lines = System.IO.File.ReadAllLines(dir + @"\Record Details.travlr");
                            foreach (string line in read_lines)
                            {
                                string ind = line.Split('=').ElementAt(0);
                                if (ind.Equals("Record Folder Path "))
                                {
                                    record_folder_path = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Recorded by_Name "))
                                {
                                    recorded_by_name = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Recorded by_Email "))
                                {
                                    recorded_by_email = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Scanned Passport Number "))
                                {
                                    Console.WriteLine("ccccc" + line);
                                    scanned_passport_number = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Scanned Passport Name "))
                                {
                                    Console.WriteLine("ddddd" + line);
                                    scanned_passport_name = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Date-Time Recorded "))
                                {
                                    date_time_recorded = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Flight From "))
                                {
                                    flight_from = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Flight To "))
                                {
                                    flight_to = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Final Destination "))
                                {
                                    final_destination = line.Split('=').ElementAt(1);
                                }
                            }
                            VRecord vRecord = new VRecord(recorded_by_name, recorded_by_email, scanned_passport_number,
                                scanned_passport_name, date_time_recorded, flight_from, flight_to, final_destination, record_folder_path);
                            vRecords.Add(vRecord);
                        }
                    }
                    else
                    {

                        //Still get in here
                        string[] dirs;
                        if (baseFolderPathString.Contains("\""))
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Replace("\"", "").Trim().ToString() + @"\Records");
                        }
                        else
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Trim().ToString() + @"\Records");
                        }
                        foreach (string dir in dirs)
                        {
                            read_lines = System.IO.File.ReadAllLines(dir + @"\Record Details.travlr");
                            foreach (string line_ in read_lines)
                            {
                                if (line_.ToLower().Contains(keyword.ToLower()))
                                {
                                    foreach (string line in read_lines)
                                    {
                                        string ind = line.Split('=').ElementAt(0);
                                        if (ind.Equals("Record Folder Path "))
                                        {
                                            record_folder_path = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Recorded by_Name "))
                                        {
                                            recorded_by_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Recorded by_Email "))
                                        {
                                            recorded_by_email = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Scanned Passport Number "))
                                        {
                                            Console.WriteLine("aaaaa" + line);
                                            scanned_passport_number = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Scanned Passport Name "))
                                        {
                                            Console.WriteLine("bbbbb" + line);
                                            scanned_passport_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Date-Time Recorded "))
                                        {
                                            date_time_recorded = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight From "))
                                        {
                                            flight_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight To "))
                                        {
                                            flight_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Final Destination "))
                                        {
                                            final_destination = line.Split('=').ElementAt(1);
                                        }
                                    }

                                }
                            }
                            VRecord vRecord = new VRecord(recorded_by_name, recorded_by_email, scanned_passport_number, scanned_passport_name, date_time_recorded, flight_from, flight_to, final_destination, record_folder_path);
                            vRecords.Add(vRecord);
                        }

                    }
                    Console.WriteLine("jebgjrgnigbirig " + vRecords.Count);
                    if (vRecords.Count < 1 || vRecords.ElementAt(0).RECORD_FOLDER_PATH == null)
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
                        ContinueFlightList.table = new System.Data.DataTable(); ContinueFlightList.table = ContinueFlightList.ConvertListToDataTable<VRecord>(vRecords); recordsDataGrid.DataSource = ContinueFlightList.table; //iC<>deiDesign
                        //this.recordsDataGrid.DataSource = vRecords;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString());
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
            }
            else
            {
                try
                {
                    vRecords.Clear();
                    if (keyword.ToString().Length < 1)
                    {
                        string[] dirs;
                        if (baseFolderPathString.Contains("\""))
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Replace("\"", "").Trim().ToString() + @"\Records");
                        }
                        else
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Trim().ToString() + @"\Records");
                        }
                        foreach (string dir in dirs)
                        {
                            read_lines = System.IO.File.ReadAllLines(dir + @"\Record Details.travlr");
                            foreach (string line in read_lines)
                            {
                                string ind = line.Split('=').ElementAt(0);
                                if (ind.Equals("Record Folder Path "))
                                {
                                    //record_folder_path = line.Split('=').ElementAt(1);
                                    record_folder_path = dir.Trim();
                                }
                                if (ind.Equals("Recorded by_Name "))
                                {
                                    recorded_by_name = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Recorded by_Email "))
                                {
                                    recorded_by_email = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Scanned Passport Number "))
                                {
                                    Console.WriteLine("ccccc" + line);
                                    scanned_passport_number = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Scanned Passport Name "))
                                {
                                    Console.WriteLine("ddddd" + line);
                                    scanned_passport_name = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Date-Time Recorded "))
                                {
                                    date_time_recorded = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Flight From "))
                                {
                                    flight_from = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Flight To "))
                                {
                                    flight_to = line.Split('=').ElementAt(1);
                                }
                                if (ind.Equals("Final Destination "))
                                {
                                    final_destination = line.Split('=').ElementAt(1);
                                }
                            }
                            VRecord vRecord = new VRecord(recorded_by_name, recorded_by_email, scanned_passport_number,
                                scanned_passport_name, date_time_recorded, flight_from, flight_to, final_destination, record_folder_path);
                            vRecords.Add(vRecord);
                        }
                    }
                    else
                    {

                        //Still get in here
                        string[] dirs;
                        if (baseFolderPathString.Contains("\""))
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Replace("\"", "").Trim().ToString() + @"\Records");
                        }
                        else
                        {
                            dirs = System.IO.Directory.GetDirectories(baseFolderPathString.Trim().ToString() + @"\Records");
                        }
                        foreach (string dir in dirs)
                        {
                            read_lines = System.IO.File.ReadAllLines(dir + @"\Record Details.travlr");
                            foreach (string line_ in read_lines)
                            {
                                if (line_.ToLower().Contains(keyword.ToLower()))
                                {
                                    foreach (string line in read_lines)
                                    {
                                        string ind = line.Split('=').ElementAt(0);
                                        if (ind.Equals("Record Folder Path "))
                                        {
                                            //record_folder_path = line.Split('=').ElementAt(1);
                                            record_folder_path = dir.Trim();
                                        }
                                        if (ind.Equals("Recorded by_Name "))
                                        {
                                            recorded_by_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Recorded by_Email "))
                                        {
                                            recorded_by_email = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Scanned Passport Number "))
                                        {
                                            Console.WriteLine("aaaaa" + line);
                                            scanned_passport_number = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Scanned Passport Name "))
                                        {
                                            Console.WriteLine("bbbbb" + line);
                                            scanned_passport_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Date-Time Recorded "))
                                        {
                                            date_time_recorded = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight From "))
                                        {
                                            flight_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight To "))
                                        {
                                            flight_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Final Destination "))
                                        {
                                            final_destination = line.Split('=').ElementAt(1);
                                        }
                                    }

                                }
                            }
                            VRecord vRecord = new VRecord(recorded_by_name, recorded_by_email, scanned_passport_number, scanned_passport_name, date_time_recorded, flight_from, flight_to, final_destination, record_folder_path);
                            vRecords.Add(vRecord);
                        }

                    }
                    Console.WriteLine("jebgjrgnigbirig " + vRecords.Count);
                    if (vRecords.Count < 1 || vRecords.ElementAt(0).RECORD_FOLDER_PATH == null)
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
                        ContinueFlightList.table = new System.Data.DataTable(); 
                        ContinueFlightList.table = ContinueFlightList.ConvertListToDataTable<VRecord>(vRecords); 
                        recordsDataGrid.DataSource = ContinueFlightList.table; //iC<>deiDesign
                        //this.recordsDataGrid.DataSource = vRecords;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString());
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
            }

        }

        private void UpdateRecordList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            };
        }
        private void recordsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                try
                {
                    recordedby_name_box_.Text = dgv.CurrentRow.Cells[1].Value.ToString().Trim();
                    recordedby_email_box_.Text = dgv.CurrentRow.Cells[2].Value.ToString().Trim();
                    datetime_recorded_box_.Text = dgv.CurrentRow.Cells[5].Value.ToString().Trim();
                    flight_from_box_.Text = dgv.CurrentRow.Cells[6].Value.ToString().Trim();
                    flight_to_box_.Text = dgv.CurrentRow.Cells[7].Value.ToString().Trim();
                    final_dest_box_.Text = dgv.CurrentRow.Cells[8].Value.ToString().Trim();

                    record_folder_path = dgv.CurrentRow.Cells[0].Value.ToString().Trim();
                    recorded_by_name = dgv.CurrentRow.Cells[1].Value.ToString().Trim();
                    recorded_by_email = dgv.CurrentRow.Cells[2].Value.ToString().Trim();
                    scanned_passport_number = dgv.CurrentRow.Cells[3].Value.ToString().Trim();
                    scanned_passport_name = dgv.CurrentRow.Cells[4].Value.ToString().Trim();
                    date_time_recorded = dgv.CurrentRow.Cells[5].Value.ToString().Trim();
                    flight_from = dgv.CurrentRow.Cells[6].Value.ToString().Trim();
                    flight_to = dgv.CurrentRow.Cells[7].Value.ToString().Trim();
                    final_destination = dgv.CurrentRow.Cells[8].Value.ToString().Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        private static string fullname;
        public String FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        private static string user_id;
        public String User_ID
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private static string flight_from_;
        private static string flight_to_;
        public String Flight_From
        {
            get { return flight_from_; }
            set { flight_from_ = value; }
        }

        public String Flight_To
        {
            get { return flight_to_; }
            set { flight_to_ = value; }
        }

        private static string final_dest;
        public String Flight_Final_Dest
        {
            get { return final_dest; }
            set { final_dest = value; }
        }


        private static Flight flight;
        public Flight Flight_
        {
            get { return flight; }
            set { flight = value; }
        }

        private bool just_hit_done = false;
        public bool JUST_HIT_DONE
        {
            get { return just_hit_done; }
            set { this.just_hit_done = value; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void view_record__Click(object sender, EventArgs e)
        {
            sRecords.Clear();
            if (flight_to_box_.TextLength < 1 || flight_from_box_.TextLength < 1 || datetime_recorded_box_.TextLength < 1 || recordedby_name_box_.TextLength < 1 || recordedby_email_box_.TextLength < 1)
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
                //this.result = "VIEW RECORD BUTTON PRESSED";
                string recordFolderPathString_ = "";
                string eachRecordFolderName = "";
                string eachRecordFolderPathString = "";
                if (record_folder_path.Contains("\""))
                {
                    recordFolderPathString_ = System.IO.Path.Combine(record_folder_path.Replace("\"", "").Trim().ToString() /**folder path**/, "Scans");
                    System.IO.Directory.CreateDirectory(recordFolderPathString_);
                }
                else
                {
                    recordFolderPathString_ = System.IO.Path.Combine(record_folder_path.Trim().ToString() /**folder path**/, "Scans");
                    System.IO.Directory.CreateDirectory(recordFolderPathString_);
                }
                string[] dirs = System.IO.Directory.GetDirectories(recordFolderPathString_);
                string record_folder_name = "";
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    int it = dir.LastIndexOf(@"\");
                    Console.WriteLine(it);
                    Console.WriteLine(dir.Length);
                    Console.WriteLine(dir.Substring(it, dir.Length - it).Replace(@"\", ""));

                    string qq = dir.Remove(dir.LastIndexOf(@"\"));
                    string qqq = qq.Remove(qq.LastIndexOf(@"\"));
                    Console.WriteLine(qqq);
                    qq_q = qqq;
                    int it_ = qqq.LastIndexOf(@"\");
                    record_folder_name = qqq.Substring(it_, qqq.Length - it_).Replace(@"\", "");
                    Console.WriteLine("Record Folder Name = " + record_folder_name);

                    eachRecordFolderPathString = dir;
                    eachRecordFolderName = dir.Substring(it, dir.Length - it).Replace(@"\", "");
                    SRecord sRecord = new SRecord(eachRecordFolderName, eachRecordFolderPathString);
                    sRecords.Add(sRecord);
                }
                //show View record Folders here
                ViewRecordFolders viewRecordFolders = new ViewRecordFolders();
                viewRecordFolders.SRECORDS = sRecords;
                viewRecordFolders.Flight_From = flight_from;
                viewRecordFolders.Flight_To = flight_to;
                viewRecordFolders.Flight_ = flight;
                viewRecordFolders.User_ID = user_id;
                viewRecordFolders.FullName = fullname;
                viewRecordFolders.RECORD_FOLDER_PATH = qq_q;
                Console.WriteLine(qq_q);
                viewRecordFolders.RECORD_FOLDER_NAME = record_folder_name;
                viewRecordFolders.ShowDialog();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void search_btn_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.DataGridViewRow r in recordsDataGrid.Rows)
            {
                var x = r.Cells[getItemIndex(record_combo.Text.Trim().ToString().ToLower())].Value;

                if (x != null && x.ToString().Trim().ToUpper().Contains(search_box.Text.Trim().ToUpper()))
                {
                    recordsDataGrid.Rows[r.Index].Visible = true;
                    recordsDataGrid.Rows[r.Index].Selected = true;
                }
                else
                {
                    recordsDataGrid.CurrentCell = null;
                    try
                    {
                        recordsDataGrid.Rows[r.Index].Visible = false;

                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
        }


        //        Record Folder Path
        //Recorded_by Name
        //Recorded_by Email
        //Scanned Passport Number
        //Scanned Passport Name
        //Date Time Recorded
        //Flight From
        //Flight To
        //Final Destination
        private int getItemIndex(string item)
        {
            if (item.ToLower().Equals("record folder path"))
            {
                return 0;
            }
            else if (item.ToLower().Equals("recorded_by name"))
            {
                return 1;
            }
            else if (item.ToLower().Equals("recorded_by email"))
            {
                return 2;
            }
            else if (item.ToLower().Equals("scanned passport number"))
            {
                return 3;
            }
            else if (item.ToLower().Equals("scanned passport name"))
            {
                return 4;
            }
            else if (item.ToLower().Equals("date time recorded"))
            {
                return 5;
            }
            else if (item.ToLower().Equals("flight from"))
            {
                return 6;
            }
            else if (item.ToLower().Equals("flight to"))
            {
                return 7;
            }
            else if (item.ToLower().Equals("final destination"))
            {
                return 8;
            }
            else
            {
                return 0;
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = ("E:");
            saveFileDialog1.Title = "Save as Excel File";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Microsoft Excel Files(2007 - " + DateTime.Today.Year.ToString() + ")|*.xlsx";

            int[] cols_to_skip = new int[] { 0, 1, 2, 6 };
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                Worksheet sheet = ExcelApp.ActiveSheet;

                int inline_index = 1;
                for (int i = 0; i < recordsDataGrid.Columns.Count; i++)
                {

                    if (cols_to_skip.Contains(i)) continue;
                    
                    sheet.Cells[1, inline_index++] = recordsDataGrid.Columns[i].HeaderText.Replace("_", " ");
                }

                for (int i = 0; i < recordsDataGrid.Rows.Count - 1; i++)
                {
                    inline_index = 1;
                    for (int j = 0; j < recordsDataGrid.Columns.Count; j++)
                    {
                        if (cols_to_skip.Contains(j)) continue;
                        sheet.Cells[i + 2, inline_index++] = recordsDataGrid.Rows[i].Cells[j].Value.ToString();
                    }
                }

                ExcelApp.Columns.AutoFit();

                MessageBox.Show("Data Exported Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sheet.SaveAs(saveFileDialog1.FileName);
                //ExcelApp.Visible = true;
                ExcelApp.Quit();
            }
        }

        private void recordsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void search_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                search_btn.PerformClick();
            };
        }
    }
}
