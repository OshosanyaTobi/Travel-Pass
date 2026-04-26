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
    public partial class ViewRecord : Form
    {
        public ViewRecord()
        {
            InitializeComponent();
            mrzScan1.BringToFront();
        }

        private SRecord sRecord;
        public SRecord SRECORD {
            get { return sRecord; }
            set { this.sRecord = value; }
        }

        private string scan_type_;
        public String ScanType {
            get { return scan_type_; }
            set { this.scan_type_ = value; }
        }

        private string record_folder_path_;
        public String RECORDFOLDERPATH {
            get { return record_folder_path_; }
            set { this.record_folder_path_ = value; }
        }

        private void mrz_scan_Click(object sender, EventArgs e)
        {
            mrzScan1.BringToFront();

        }

        private void view_images_Click(object sender, EventArgs e)
        {
            viewImages1.BringToFront();
        }

        private void rfid_scan_Click(object sender, EventArgs e)
        {
            rfidScan1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewRecord_Load(object sender, EventArgs e)
        {
            try
            {
                /*****************PROFILING DETAILS********************/
                string recordDetailsPathString = "";
                if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                {
                    recordDetailsPathString = System.IO.Path.Combine(record_folder_path_.Replace("\"", "").Trim(), "");
                }
                else
                {
                    recordDetailsPathString = System.IO.Path.Combine(record_folder_path_.Trim(), "");
                }
                string[] record_details_rlines = System.IO.File.ReadAllLines(recordDetailsPathString + @"\Record Details.travlr");
                String tLines = "";
                foreach (string line in record_details_rlines) {
                    tLines += line;
                    tLines += "\n";
                }
                profilingDetails1.richTextBox1.Text = tLines;

                /*****************SCAN TYPE*********************/
                this.scan_type.Text = scan_type_;

                if (scan_type_.Trim().ToString().ToLower().Equals("passport"))
                {
                    /*****************MRZ SCAN DETAILS*********************/
                    string mrzscanPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        mrzscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), "MRZ Scan");
                    }
                    else
                    {
                        mrzscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), "MRZ Scan");
                    }
                    string[] read_lines = System.IO.File.ReadAllLines(mrzscanPathString + @"\MRZ Codeline Details.travlr");
                    string code_lines = "";
                    foreach (string line in read_lines)
                    {
                        string ind = line.Split('=').ElementAt(0);
                        if (ind.Equals("Document Number "))
                        {
                            mrzScan1.doc_no.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Optional Data "))
                        {
                            mrzScan1.opt_data.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Family Name "))
                        {
                            mrzScan1.family_name.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Given Names "))
                        {
                            mrzScan1.given_names.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Sex "))
                        {
                            mrzScan1.sex.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Date of birth "))
                        {
                            mrzScan1.dob.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Age "))
                        {
                            mrzScan1.age.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Nationality "))
                        {
                            mrzScan1.nationality.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Date of expiry "))
                        {
                            mrzScan1.doe.Text = line.Split('=').ElementAt(1);
                            //DateTime now = new DateTime();
                            //DateTime dt = new DateTime();
                            //dt = DateTime.Parse(mrzScan1.doe.Text);
                            //now = DateTime.Now;
                            //int yr = dt.Year - now.Year;

                            //Console.WriteLine("Now Year = " + now.Year);
                            //Console.WriteLine("Dt Year = " + dt.Year);
                            //Console.WriteLine("Yr = " + yr);
                            //if (yr <= 1)
                            //{
                            //    yr = 0;
                            //}
                            //if (yr == 0)
                            //{
                            //    Console.WriteLine("Document Expires in " + dt.Month + " Months " + Math.Abs(now.Day - dt.Day) + " Days");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Document Expires in " + yr + " Years " + Math.Abs(now.Month - dt.Month) + " Months " + Math.Abs(now.Day - dt.Day) + " Days");
                            //}
                        }
                        else if (ind.Equals("Issuer "))
                        {
                            mrzScan1.issuer.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Codeline "))
                        {
                            code_lines += line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Image Location "))
                        {
                            string img_loc = line.Split('=').ElementAt(1).Trim();
                            //mrzScan1.mrzImage.ImageLocation = img_loc;

                            mrzScan1.mrzImage.ImageLocation = mrzscanPathString.Trim() + @"\MRZImage.jpeg";
                            Console.WriteLine("fjenjfenfjnejfnrjnfirnfijjrnifnriugnirngijrngiurngiurngirngirg" + mrzscanPathString + @"\MRZImage.jpeg");
                        }
                        else
                        {
                            if (!line.Contains("MRZ Codeline Details"))
                            {
                                code_lines += line;
                            }
                        }
                    }
                    mrzScan1.richTextBoxCodeline.Text = code_lines;

                    try
                    {
                        /*****************RFID SCAN DETAILS*********************/
                        string rfidscanPathString = "";
                        if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                        {
                            rfidscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), "RFID Scan");
                        }
                        else
                        {
                            rfidscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), "RFID Scan");
                        }
                        string[] rfid_read_lines = System.IO.File.ReadAllLines(rfidscanPathString + @"\RFID Scan Details.travlr");
                        for (int i = 0; i < rfid_read_lines.Length; i++)
                        {
                            Console.WriteLine(rfid_read_lines[i]);
                            if (rfid_read_lines[i].Trim().Contains("CHIP ID - "))
                            {
                                rfidScan1.chipID.Text = rfid_read_lines[i];
                            }
                            if (rfid_read_lines[i].Trim().Contains("READ SECTION"))
                            {

                                for (int j = 1; j < 17; j++)
                                {
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG1") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG2") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG3") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG4") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG5") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG6") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG7") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG8") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG9") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG10") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG11") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG12") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG13") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG14") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG15") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG16") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }

                                }
                            }

                            if (rfid_read_lines[i].Trim().Contains("VALIDATED SECTION"))
                            {

                                for (int j = 1; j < 17; j++)
                                {
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG1") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG2") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG3") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG4") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG5") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG6") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG7") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG8") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG9") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG10") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG11") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG12") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG13") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG14") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG15") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG16") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }

                                }
                            }

                            if (rfid_read_lines[i].Trim().Contains(">>> ATTRIBUTES VALIDATION"))
                            {

                                for (int j = 1; j < 8; j++)
                                {
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Signed Attributes"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_VALID"))
                                        {
                                            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_INVALID"))
                                        {
                                            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Passive Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Chip Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Signature"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_VALID"))
                                        {
                                            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_INVALID"))
                                        {
                                            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Active Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Terminal Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Doc Signer Cert"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_VALID"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_INVALID"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_NO_CSC_LOADED"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_NO_DSC_LOADED"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                        else
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }

                                }
                            }

                            if (rfid_read_lines[i].Trim().Contains("Codeline ="))
                            {
                                string cl_ = rfid_read_lines[i].Trim().Split('=').ElementAt(1).ToString();
                                cl_ += rfid_read_lines[i + 1].Trim().ToString();
                                cl_ += rfid_read_lines[i + 2].Trim().ToString();
                                rfidScan1.codelineRichTextBox.Text = cl_;
                            }
                        }
                        rfidScan1.rfImage.ImageLocation = rfidscanPathString + @"\RFIDImage.jpeg";
                    }
                    catch (Exception ex)
                    {
                        //DialogResult dResult = MessageBox.Show("No RFID Scan Found",
                        //                                    "Information",
                        //                                    MessageBoxButtons.OK,
                        //                                    MessageBoxIcon.Information,
                        //                                    MessageBoxDefaultButton.Button1,
                        //                                    MessageBoxOptions.RightAlign,
                        //                                    false);
                    }

                    /*****************PASSPORT VALIDATION DETAILS*********************/
                    string passportValidationPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        passportValidationPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim());
                    }
                    else
                    {
                        passportValidationPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim());
                    }
                    string[] read_lines_ = System.IO.File.ReadAllLines(passportValidationPathString + @"\Passport Validation Details.travlr");
                    foreach (string line in read_lines_)
                    {
                        if (line.Contains("="))
                        {
                            string ind = line.Split('=').ElementAt(0);
                            if (ind.Equals("Passed "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("True"))
                                {
                                    mrzScan1.showVerification.Text = "PASSED";
                                    mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    mrzScan1.showVerification.Text = "FAILED";
                                }
                            }

                            if (ind.Equals("Document No "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.doc_no_flag.Text = "OK";
                                    mrzScan1.doc_no_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.doc_no_flag.Text = "ERROR";
                                    mrzScan1.doc_no_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Date of birth "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.dob_flag.Text = "OK";
                                    mrzScan1.dob_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.dob_flag.Text = "ERROR";
                                    mrzScan1.dob_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }
                            


                            if (ind.Equals("Date of expiry "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.doe_flag.Text = "OK";
                                    mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.doe_flag.Text = "ERROR";
                                    mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Optional ID "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.oid_flag.Text = "OK";
                                    mrzScan1.oid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.oid_flag.Text = "ERROR";
                                    mrzScan1.oid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Valid Document "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.vd_flag.Text = "OK";
                                    mrzScan1.vd_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.vd_flag.Text = "ERROR";
                                    mrzScan1.vd_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Global CheckSum "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.checks_flag.Text = "OK";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.checks_flag.Text = "ERROR";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("P Codeline Match "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("YES"))
                                {
                                    mrzScan1.cdm_flag.Text = "YES";
                                    mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else if (line.Split('=').ElementAt(1).Trim().Equals("NO READ"))
                                {
                                    mrzScan1.cdm_flag.Text = "NO READ";
                                    mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.cdm_flag.Text = "NO";
                                    mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("RFID availability "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("YES"))
                                {
                                    mrzScan1.rfid_flag.Text = "YES";
                                    mrzScan1.rfid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.rfid_flag.Text = "NO";
                                    mrzScan1.rfid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("isFlagged "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("True"))
                                {
                                    mrzScan1.flagged_flag.Text = "YES";
                                    mrzScan1.flagged_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                                    this.is_flagged.Text = "FLAGGED : YES";
                                    this.is_flagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.flagged_flag.Text = "NO";
                                    mrzScan1.flagged_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));

                                    this.is_flagged.Text = "FLAGGED : NO";
                                    this.is_flagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                            }
                        }
                    }

                    /*****************VIEW IMAGES*********************/
                    string viewImagesPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        viewImagesPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), @"MRZ Scan\View Images");
                    }
                    else
                    {
                        viewImagesPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), @"MRZ Scan\View Images");
                    }
                    string[] files_ = System.IO.Directory.GetFiles(viewImagesPathString);
                    foreach (string file_ in files_)
                    {
                        if (file_.Contains("IRImage"))
                        {
                            viewImages1.irImage.ImageLocation = file_;
                        }
                        else if (file_.Contains("UVImage"))
                        {
                            viewImages1.uvImage.ImageLocation = file_;
                        }
                        else if (file_.Contains("VISImage"))
                        {
                            viewImages1.visImage.ImageLocation = file_;
                        }
                    }
                }
                else if (scan_type_.Trim().ToString().ToLower().Equals("visa"))
                {
                    /*****************MRZ SCAN DETAILS*********************/
                    string mrzscanPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        mrzscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), "MRZ Scan");
                    }
                    else
                    {
                        mrzscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), "MRZ Scan");
                    }
                    string[] read_lines = System.IO.File.ReadAllLines(mrzscanPathString + @"\MRZ Codeline Details.travlr");
                    string code_lines = "";
                    foreach (string line in read_lines)
                    {
                        string ind = line.Split('=').ElementAt(0);
                        if (ind.Equals("Document Number "))
                        {
                            mrzScan1.doc_no.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Optional Data "))
                        {
                            mrzScan1.opt_data.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Family Name "))
                        {
                            mrzScan1.family_name.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Given Names "))
                        {
                            mrzScan1.given_names.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Sex "))
                        {
                            mrzScan1.sex.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Date of birth "))
                        {
                            mrzScan1.dob.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Age "))
                        {
                            mrzScan1.age.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Nationality "))
                        {
                            mrzScan1.nationality.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Date of expiry "))
                        {
                            mrzScan1.doe.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Issuer "))
                        {
                            mrzScan1.issuer.Text = line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Codeline "))
                        {
                            code_lines += line.Split('=').ElementAt(1);
                        }
                        else if (ind.Equals("Image Location "))
                        {
                            string img_loc = line.Split('=').ElementAt(1).Trim();
                            mrzScan1.mrzImage.ImageLocation = img_loc;
                        }
                        else
                        {
                            if (!line.Contains("MRZ Codeline Details"))
                            {
                                code_lines += line;
                            }
                        }
                    }
                    mrzScan1.richTextBoxCodeline.Text = code_lines;

                    /*****************VISA VALIDATION DETAILS*********************/
                    string passportValidationPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        passportValidationPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim());
                    }
                    else
                    {
                        passportValidationPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim());
                    }
                    string[] read_lines_ = System.IO.File.ReadAllLines(passportValidationPathString + @"\Visa Validation Details.travlr");
                    foreach (string line in read_lines_)
                    {
                        if (line.Contains("="))
                        {
                            string ind = line.Split('=').ElementAt(0);
                            if (ind.Equals("Passed "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("True"))
                                {
                                    mrzScan1.showVerification.Text = "PASSED";
                                    mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    mrzScan1.showVerification.Text = "FAILED";
                                }
                            }

                            if (ind.Equals("Document No "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.doc_no_flag.Text = "OK";
                                    mrzScan1.doc_no_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.doc_no_flag.Text = "ERROR";
                                    mrzScan1.doc_no_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Date of birth "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.dob_flag.Text = "OK";
                                    mrzScan1.dob_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.dob_flag.Text = "ERROR";
                                    mrzScan1.dob_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }


                            if (ind.Equals("Date of expiry "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.doe_flag.Text = "OK";
                                    mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.doe_flag.Text = "ERROR";
                                    mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Optional ID "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.oid_flag.Text = "OK";
                                    mrzScan1.oid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.oid_flag.Text = "ERROR";
                                    mrzScan1.oid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Valid Document "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.vd_flag.Text = "OK";
                                    mrzScan1.vd_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.vd_flag.Text = "ERROR";
                                    mrzScan1.vd_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("Global CheckSum "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("OK"))
                                {
                                    mrzScan1.checks_flag.Text = "OK";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.checks_flag.Text = "ERROR";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("P Codeline Match "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("YES"))
                                {
                                    mrzScan1.cdm_flag.Text = "YES";
                                    mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else if (line.Split('=').ElementAt(1).Trim().Equals("NO READ"))
                                {
                                    mrzScan1.cdm_flag.Text = "NO READ";
                                    mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.cdm_flag.Text = "NO";
                                    mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("RFID availability "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("YES"))
                                {
                                    mrzScan1.rfid_flag.Text = "YES";
                                    mrzScan1.rfid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.rfid_flag.Text = "NO";
                                    mrzScan1.rfid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }

                            if (ind.Equals("isFlagged "))
                            {
                                if (line.Split('=').ElementAt(1).Trim().Equals("True"))
                                {
                                    mrzScan1.flagged_flag.Text = "YES";
                                    mrzScan1.flagged_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                                    this.is_flagged.Text = "FLAGGED : YES";
                                    this.is_flagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.flagged_flag.Text = "NO";
                                    mrzScan1.flagged_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));

                                    this.is_flagged.Text = "FLAGGED : NO";
                                    this.is_flagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                            }
                    }
                    }

                    /*****************VIEW IMAGES*********************/
                    string viewImagesPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        viewImagesPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), @"MRZ Scan\View Images");
                    }
                    else
                    {
                        viewImagesPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), @"MRZ Scan\View Images");
                    }
                    string[] files_ = System.IO.Directory.GetFiles(viewImagesPathString);
                    foreach (string file_ in files_)
                    {
                        if (file_.Contains("IRImage"))
                        {
                            viewImages1.irImage.ImageLocation = file_;
                        }
                        else if (file_.Contains("UVImage"))
                        {
                            viewImages1.uvImage.ImageLocation = file_;
                        }
                        else if (file_.Contains("VISImage"))
                        {
                            viewImages1.visImage.ImageLocation = file_;
                        }
                    }

                    try
                    {
                        /*****************RFID SCAN DETAILS*********************/
                        string rfidscanPathString = "";
                        if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                        {
                            rfidscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), "RFID Scan");
                        }
                        else
                        {
                            rfidscanPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), "RFID Scan");
                        }
                        string[] rfid_read_lines = System.IO.File.ReadAllLines(rfidscanPathString + @"\RFID Scan Details.travlr");
                        for (int i = 0; i < rfid_read_lines.Length; i++)
                        {
                            Console.WriteLine(rfid_read_lines[i]);
                            if (rfid_read_lines[i].Trim().Contains("CHIP ID - "))
                            {
                                rfidScan1.chipID.Text = rfid_read_lines[i];
                            }
                            if (rfid_read_lines[i].Trim().Contains("READ SECTION"))
                            {

                                for (int j = 1; j < 17; j++)
                                {
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG1") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG2") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG3") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG4") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG5") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG6") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG7") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG8") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG9") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG10") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG11") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG12") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG13") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG14") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG15") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG16") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }

                                }
                            }

                            if (rfid_read_lines[i].Trim().Contains("VALIDATED SECTION"))
                            {

                                for (int j = 1; j < 17; j++)
                                {
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG1") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG2") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG3") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG4") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG5") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG6") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG7") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG8") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG9") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG10") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG11") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG12") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG13") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG14") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG15") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("DG16") && rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("True"))
                                    {
                                        rfidScan1.dg_16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                    }

                                }
                            }

                            if (rfid_read_lines[i].Trim().Contains(">>> ATTRIBUTES VALIDATION"))
                            {

                                for (int j = 1; j < 8; j++)
                                {
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Signed Attributes"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_VALID"))
                                        {
                                            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_INVALID"))
                                        {
                                            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Passive Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Chip Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Signature"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_VALID"))
                                        {
                                            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_INVALID"))
                                        {
                                            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Active Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Terminal Auth"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_SUCCESS"))
                                        {
                                            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("TS_FAILURE"))
                                        {
                                            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else
                                        {
                                            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }
                                    if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(0).Trim().Equals("Doc Signer Cert"))
                                    {
                                        if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_VALID"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_INVALID"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_NO_CSC_LOADED"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                        else if (rfid_read_lines[i + j].Trim().Split('=').ElementAt(1).Trim().Equals("RFID_VC_NO_DSC_LOADED"))
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                        else
                                        {
                                            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                        }
                                    }

                                }
                            }

                            if (rfid_read_lines[i].Trim().Contains("Codeline ="))
                            {
                                string cl_ = rfid_read_lines[i].Trim().Split('=').ElementAt(1).ToString();
                                cl_ += rfid_read_lines[i + 1].Trim().ToString();
                                cl_ += rfid_read_lines[i + 2].Trim().ToString();
                                rfidScan1.codelineRichTextBox.Text = cl_;
                            }
                        }
                        rfidScan1.rfImage.ImageLocation = rfidscanPathString + @"\RFIDImage.jpeg";
                    }
                    catch (Exception ex)
                    {
                        //DialogResult dResult = MessageBox.Show("No RFID scan found",
                        //                                    "Information",
                        //                                    MessageBoxButtons.OK,
                        //                                    MessageBoxIcon.Information,
                        //                                    MessageBoxDefaultButton.Button1,
                        //                                    MessageBoxOptions.RightAlign,
                        //                                    false);
                    }

                }

                else {
                    /*****************VIEW IMAGES*********************/
                    string viewImagesPathString = "";
                    if (sRecord.SCAN_FOLDER_PATH.Contains("\""))
                    {
                        viewImagesPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Replace("\"", "").Trim(), "View Images");
                    }
                    else
                    {
                        viewImagesPathString = System.IO.Path.Combine(sRecord.SCAN_FOLDER_PATH.Trim(), "View Images");
                    }
                    string[] files_ = System.IO.Directory.GetFiles(viewImagesPathString);
                    foreach (string file_ in files_)
                    {
                        if (file_.Contains("IRImage"))
                        {
                            viewImages1.irImage.ImageLocation = file_;
                        }
                        else if (file_.Contains("UVImage"))
                        {
                            viewImages1.uvImage.ImageLocation = file_;
                        }
                        else if (file_.Contains("VISImage"))
                        {
                            viewImages1.visImage.ImageLocation = file_;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DialogResult dResult = MessageBox.Show("Error loading scan",
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
                if (dResult == DialogResult.OK) {
                    this.Close();
                }
            }
        }
        private void ViewRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            };
        }

        private void mrzScan1_Load(object sender, EventArgs e)
        {

        }

        private void profiling_details_Click(object sender, EventArgs e)
        {
            profilingDetails1.BringToFront();
        }

        
    }
}
