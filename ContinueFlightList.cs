using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class ContinueFlightList : Form
    {
        string flight_name;
        string flight_created_by_name;
        string flight_created_by_email;
        string flight_from;
        string flight_to;
        string flight_airline;
        string flight_date_created;
        string flight_date;
        string flight_type;
        string flight_number;
        string country_from;
        string flight_depart_time;
        string flight_depart_term;
        string country_to;
        string flight_arrive_time;
        string flight_arrive_term;
        string flight_length;
        string flight_class;

        string baseFolderPathString = @"z:\TravelPass\Flights";
        string baseFolderPathString2 = @"c:\TravelPass\Flights";
        string flightFolderPathString = "";

        List<VFlight> vFlights = new List<VFlight>();
        string[] read_lines;

        public static DataTable table;
        String tempStrForDateReformatting;

        public ContinueFlightList()
        {
            InitializeComponent();
        }
        

        private string pers_role_ = "";
        public String Pers_ROLE {
            get { return pers_role_; }
            set { this.pers_role_ = value; }
        }

        private string returnBaseFolderPathString(String role) {
            if (!role.ToUpper().Equals("ADMIN"))
            {
                return baseFolderPathString2;
            }
            else
            {
                return baseFolderPathString;
            }
        }

        private bool isWDReady() {
            bool b = false;
            DriveInfo[] allDevices = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDevices)
            {
                Console.WriteLine(d.Name);
                if (d.Name.Contains(@"Z:"))
                {
                    b = d.IsReady;
                }
                else {
                    b = false;
                }
            }
            return b;
        }

        private void ContinueFlightList_Load(object sender, EventArgs e)
        {
            if (!pers_role_.ToUpper().Equals("ADMIN"))
            {
                {
                    try
                    {

                        if (filter_flight_number.ToString().Length < 1)
                        {
                            string[] dirs = System.IO.Directory.GetDirectories(returnBaseFolderPathString(pers_role_));
                            foreach (string dir in dirs)
                            {
                                if (!File.Exists(dir + @"\Flight Details.travlr")) continue; //iC<>deiDesign

                                read_lines = System.IO.File.ReadAllLines(dir + @"\Flight Details.travlr");
                                foreach (string line in read_lines)
                                {
                                    string ind = line.Split('=').ElementAt(0);
                                    if (ind.Equals("Flight Folder Path "))
                                    {
                                        flightFolderPathString = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Created by_Name "))
                                    {
                                        flight_created_by_name = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Created by_Email "))
                                    {
                                        flight_created_by_email = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Date-Time Created "))
                                    {
                                        flight_date_created = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Date "))
                                    {
                                        flight_date = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Airline "))
                                    {
                                        flight_airline = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Number "))
                                    {
                                        flight_name = "Flight " + line.Split('=').ElementAt(1);
                                        flight_number = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight From "))
                                    {
                                        flight_from = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Country From "))
                                    {
                                        country_from = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Depart Time "))
                                    {
                                        flight_depart_time = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Depart Term "))
                                    {
                                        flight_depart_term = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight To "))
                                    {
                                        flight_to = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Country To "))
                                    {
                                        country_to = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Arrive Time "))
                                    {
                                        flight_arrive_time = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Arrive Term "))
                                    {
                                        flight_arrive_term = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Type "))
                                    {
                                        flight_type = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Length "))
                                    {
                                        flight_length = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Class "))
                                    {
                                        flight_class = line.Split('=').ElementAt(1);
                                    }
                                }
                                VFlight vFlight = new VFlight(flight_name, flight_created_by_name, flight_created_by_email, flight_from, flight_to, flight_airline, flight_date_created,
                                    flight_date, flight_type, flight_number, country_from, flight_depart_time, flight_depart_term, country_to,
                                    flight_arrive_time, flight_arrive_term, flight_length, flightFolderPathString, flight_class);
                                vFlights.Add(vFlight);
                                Console.WriteLine(flight_name);
                                Console.WriteLine(flight_created_by_name);
                                Console.WriteLine(flight_created_by_email);
                                Console.WriteLine(flight_from);
                                Console.WriteLine(flight_to);
                                Console.WriteLine(flight_airline);
                                Console.WriteLine(flight_date_created); 
                            }
                        }
                        else
                        {
                            if (filter_flight_number.ToLower().Trim().ToString().Contains("flight"))
                            {
                                string[] dirs = System.IO.Directory.GetDirectories(returnBaseFolderPathString(pers_role_), filter_flight_number + "*");
                                foreach (string dir in dirs)
                                {
                                    if (!File.Exists(dir + @"\Flight Details.travlr")) continue; //iC<>deiDesign
                                 
                                    read_lines = System.IO.File.ReadAllLines(dir + @"\Flight Details.travlr");
                                    foreach (string line in read_lines)
                                    {
                                        string ind = line.Split('=').ElementAt(0);
                                        if (ind.Equals("Flight Folder Path "))
                                        {
                                            flightFolderPathString = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Created by_Name "))
                                        {
                                            flight_created_by_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Created by_Email "))
                                        {
                                            flight_created_by_email = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Date-Time Created "))
                                        {
                                            flight_date_created = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Date "))
                                        {
                                            flight_date = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Airline "))
                                        {
                                            flight_airline = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Number "))
                                        {
                                            flight_name = "Flight " + line.Split('=').ElementAt(1);
                                            flight_number = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight From "))
                                        {
                                            flight_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country From "))
                                        {
                                            country_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Time "))
                                        {
                                            flight_depart_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Term "))
                                        {
                                            flight_depart_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight To "))
                                        {
                                            flight_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country To "))
                                        {
                                            country_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Time "))
                                        {
                                            flight_arrive_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Term "))
                                        {
                                            flight_arrive_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Type "))
                                        {
                                            flight_type = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Length "))
                                        {
                                            flight_length = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Class "))
                                        {
                                            flight_class = line.Split('=').ElementAt(1);
                                        }
                                    }
                                    VFlight vFlight = new VFlight(flight_name, flight_created_by_name, flight_created_by_email, flight_from, flight_to, flight_airline, flight_date_created,
                                        flight_date, flight_type, flight_number, country_from, flight_depart_time, flight_depart_term, country_to,
                                        flight_arrive_time, flight_arrive_term, flight_length, flightFolderPathString, flight_class);
                                    vFlights.Add(vFlight);
                                }
                            }
                            else
                            {
                                string[] dirs = System.IO.Directory.GetDirectories(returnBaseFolderPathString(pers_role_), "Flight" + filter_flight_number + "*");
                                foreach (string dir in dirs)
                                {
                                    if (!File.Exists(dir + @"\Flight Details.travlr")) continue; //iC<>deiDesign

                                    read_lines = System.IO.File.ReadAllLines(dir + @"\Flight Details.travlr");
                                    foreach (string line in read_lines)
                                    {
                                        string ind = line.Split('=').ElementAt(0);
                                        if (ind.Equals("Flight Folder Path "))
                                        {
                                            flightFolderPathString = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Created by_Name "))
                                        {
                                            flight_created_by_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Created by_Email "))
                                        {
                                            flight_created_by_email = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Date-Time Created "))
                                        {
                                            flight_date_created = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Date "))
                                        {
                                            flight_date = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Airline "))
                                        {
                                            flight_airline = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Number "))
                                        {
                                            flight_name = "Flight " + line.Split('=').ElementAt(1);
                                            flight_number = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight From "))
                                        {
                                            flight_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country From "))
                                        {
                                            country_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Time "))
                                        {
                                            flight_depart_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Term "))
                                        {
                                            flight_depart_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight To "))
                                        {
                                            flight_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country To "))
                                        {
                                            country_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Time "))
                                        {
                                            flight_arrive_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Term "))
                                        {
                                            flight_arrive_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Type "))
                                        {
                                            flight_type = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Length "))
                                        {
                                            flight_length = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Class "))
                                        {
                                            flight_class = line.Split('=').ElementAt(1);
                                        }
                                    }
                                    VFlight vFlight = new VFlight(flight_name, flight_created_by_name, flight_created_by_email, flight_from, flight_to, flight_airline, flight_date_created,
                                        flight_date, flight_type, flight_number, country_from, flight_depart_time, flight_depart_term, country_to,
                                        flight_arrive_time, flight_arrive_term, flight_length, flightFolderPathString, flight_class);
                                    vFlights.Add(vFlight);
                                }
                            }

                        }

                        if (vFlights.Count < 1)
                        {
                            DialogResult dResult = MessageBox.Show("No such flight exist or No flight has been created",
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
                            table = new DataTable(); 
                            table = ConvertListToDataTable<VFlight>(vFlights); 
                            ModifyTheNewDatatable(table); 
                            flightsDataGrid.DataSource = table; //iC<>deiDesign

                            //this.flightsDataGrid.DataSource = vFlights;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The process failed: {0}", ex.ToString());
                    }

                }
            }
            else {
                if (isWDReady())
                {
                    try
                    {

                        if (filter_flight_number.ToString().Length < 1)
                        {
                            string[] dirs = System.IO.Directory.GetDirectories(returnBaseFolderPathString(pers_role_));
                            foreach (string dir in dirs)
                            {
                                //Console.WriteLine("*****" + dir);
                                read_lines = System.IO.File.ReadAllLines(dir + @"\Flight Details.travlr");
                                foreach (string line in read_lines)
                                {
                                    string ind = line.Split('=').ElementAt(0);
                                    if (ind.Equals("Flight Folder Path "))
                                    {
                                        //flightFolderPathString = line.Split('=').ElementAt(1);
                                        flightFolderPathString = dir.Trim();
                                    }
                                    if (ind.Equals("Flight Created by_Name "))
                                    {
                                        flight_created_by_name = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Created by_Email "))
                                    {
                                        flight_created_by_email = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Date-Time Created "))
                                    {
                                        flight_date_created = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Date "))
                                    {
                                        flight_date = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Airline "))
                                    {
                                        flight_airline = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Number "))
                                    {
                                        flight_name = "Flight " + line.Split('=').ElementAt(1);
                                        flight_number = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight From "))
                                    {
                                        flight_from = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Country From "))
                                    {
                                        country_from = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Depart Time "))
                                    {
                                        flight_depart_time = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Depart Term "))
                                    {
                                        flight_depart_term = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight To "))
                                    {
                                        flight_to = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Country To "))
                                    {
                                        country_to = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Arrive Time "))
                                    {
                                        flight_arrive_time = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Arrive Term "))
                                    {
                                        flight_arrive_term = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Type "))
                                    {
                                        flight_type = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Length "))
                                    {
                                        flight_length = line.Split('=').ElementAt(1);
                                    }
                                    if (ind.Equals("Flight Class "))
                                    {
                                        flight_class = line.Split('=').ElementAt(1);
                                    }
                                }
                                VFlight vFlight = new VFlight(flight_name, flight_created_by_name, flight_created_by_email, flight_from, flight_to, flight_airline, flight_date_created,
                                    flight_date, flight_type, flight_number, country_from, flight_depart_time, flight_depart_term, country_to,
                                    flight_arrive_time, flight_arrive_term, flight_length, flightFolderPathString, flight_class);
                                vFlights.Add(vFlight);
                                Console.WriteLine(flight_name);
                                Console.WriteLine(flight_created_by_name);
                                Console.WriteLine(flight_created_by_email);
                                Console.WriteLine(flight_from);
                                Console.WriteLine(flight_to);
                                Console.WriteLine(flight_airline);
                                Console.WriteLine(flight_date_created);
                            }
                        }
                        else
                        {
                            if (filter_flight_number.ToLower().Trim().ToString().Contains("flight"))
                            {
                                string[] dirs = System.IO.Directory.GetDirectories(returnBaseFolderPathString(pers_role_), filter_flight_number + "*");
                                foreach (string dir in dirs)
                                {
                                    read_lines = System.IO.File.ReadAllLines(dir + @"\Flight Details.travlr");
                                    foreach (string line in read_lines)
                                    {
                                        string ind = line.Split('=').ElementAt(0);
                                        if (ind.Equals("Flight Folder Path "))
                                        {
                                            //flightFolderPathString = line.Split('=').ElementAt(1);
                                            flightFolderPathString = dir.Trim();
                                        }
                                        if (ind.Equals("Flight Created by_Name "))
                                        {
                                            flight_created_by_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Created by_Email "))
                                        {
                                            flight_created_by_email = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Date-Time Created "))
                                        {
                                            flight_date_created = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Date "))
                                        {
                                            flight_date = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Airline "))
                                        {
                                            flight_airline = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Number "))
                                        {
                                            flight_name = "Flight " + line.Split('=').ElementAt(1);
                                            flight_number = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight From "))
                                        {
                                            flight_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country From "))
                                        {
                                            country_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Time "))
                                        {
                                            flight_depart_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Term "))
                                        {
                                            flight_depart_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight To "))
                                        {
                                            flight_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country To "))
                                        {
                                            country_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Time "))
                                        {
                                            flight_arrive_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Term "))
                                        {
                                            flight_arrive_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Type "))
                                        {
                                            flight_type = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Length "))
                                        {
                                            flight_length = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Class "))
                                        {
                                            flight_class = line.Split('=').ElementAt(1);
                                        }
                                    }
                                    VFlight vFlight = new VFlight(flight_name, flight_created_by_name, flight_created_by_email, flight_from, flight_to, flight_airline, flight_date_created,
                                        flight_date, flight_type, flight_number, country_from, flight_depart_time, flight_depart_term, country_to,
                                        flight_arrive_time, flight_arrive_term, flight_length, flightFolderPathString, flight_class);
                                    vFlights.Add(vFlight);
                                }
                            }
                            else
                            {
                                string[] dirs = System.IO.Directory.GetDirectories(returnBaseFolderPathString(pers_role_), "Flight" + filter_flight_number + "*");
                                foreach (string dir in dirs)
                                {
                                    read_lines = System.IO.File.ReadAllLines(dir + @"\Flight Details.travlr");
                                    foreach (string line in read_lines)
                                    {
                                        string ind = line.Split('=').ElementAt(0);
                                        if (ind.Equals("Flight Folder Path "))
                                        {
                                            //flightFolderPathString = line.Split('=').ElementAt(1);
                                            flightFolderPathString = dir.Trim();
                                        }
                                        if (ind.Equals("Flight Created by_Name "))
                                        {
                                            flight_created_by_name = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Created by_Email "))
                                        {
                                            flight_created_by_email = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Date-Time Created "))
                                        {
                                            flight_date_created = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Date "))
                                        {
                                            flight_date = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Airline "))
                                        {
                                            flight_airline = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Number "))
                                        {
                                            flight_name = "Flight " + line.Split('=').ElementAt(1);
                                            flight_number = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight From "))
                                        {
                                            flight_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country From "))
                                        {
                                            country_from = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Time "))
                                        {
                                            flight_depart_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Depart Term "))
                                        {
                                            flight_depart_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight To "))
                                        {
                                            flight_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Country To "))
                                        {
                                            country_to = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Time "))
                                        {
                                            flight_arrive_time = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Arrive Term "))
                                        {
                                            flight_arrive_term = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Type "))
                                        {
                                            flight_type = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Length "))
                                        {
                                            flight_length = line.Split('=').ElementAt(1);
                                        }
                                        if (ind.Equals("Flight Class "))
                                        {
                                            flight_class = line.Split('=').ElementAt(1);
                                        }
                                    }
                                    VFlight vFlight = new VFlight(flight_name, flight_created_by_name, flight_created_by_email, flight_from, flight_to, flight_airline, flight_date_created,
                                        flight_date, flight_type, flight_number, country_from, flight_depart_time, flight_depart_term, country_to,
                                        flight_arrive_time, flight_arrive_term, flight_length, flightFolderPathString, flight_class);
                                    vFlights.Add(vFlight);
                                }
                            }

                        }

                        if (vFlights.Count < 1)
                        {
                            DialogResult dResult = MessageBox.Show("No such flight exist or No flight has been created",
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
                            table = new DataTable(); table = ConvertListToDataTable<VFlight>(vFlights); ModifyTheNewDatatable(table); flightsDataGrid.DataSource = table; //iC<>deiDesign

                            //this.flightsDataGrid.DataSource = vFlights;
                            
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The process failed: {0}", ex.ToString());
                    }

                }
                else
                {
                    DialogResult dResult = MessageBox.Show("Cannot connect to WD. Please make sure this PC is connected properly to the Router",
                                                                        "Error Report",
                                                                        MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Error,
                                                                        MessageBoxDefaultButton.Button1,
                                                                        MessageBoxOptions.DefaultDesktopOnly,
                                                                        false);
                    if (dResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }

        }


        private void ContinueFlightList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            };
        }

        private void flightsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                this.flight_name_box.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                this.flight_created_by_box.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                this.flight_from_box.Text = dgv.CurrentRow.Cells[3].Value.ToString();
                this.flight_to_box.Text = dgv.CurrentRow.Cells[4].Value.ToString();
                this.flight_airline_box.Text = dgv.CurrentRow.Cells[5].Value.ToString();
                this.flight_date_box.Text = dgv.CurrentRow.Cells[7].Value.ToString();

                flight_name = dgv.CurrentRow.Cells[0].Value.ToString();
                flight_created_by_name = dgv.CurrentRow.Cells[1].Value.ToString();
                flight_created_by_email = dgv.CurrentRow.Cells[2].Value.ToString();
                flight_from = dgv.CurrentRow.Cells[3].Value.ToString();
                flight_to = dgv.CurrentRow.Cells[4].Value.ToString();
                flight_airline = dgv.CurrentRow.Cells[5].Value.ToString();
                flight_date_created = dgv.CurrentRow.Cells[6].Value.ToString();
                flight_date = dgv.CurrentRow.Cells[7].Value.ToString();
                flight_type = dgv.CurrentRow.Cells[8].Value.ToString();
                flight_number = dgv.CurrentRow.Cells[9].Value.ToString();
                country_from = dgv.CurrentRow.Cells[10].Value.ToString();
                flight_depart_time = dgv.CurrentRow.Cells[11].Value.ToString();
                flight_depart_term = dgv.CurrentRow.Cells[12].Value.ToString();
                country_to = dgv.CurrentRow.Cells[13].Value.ToString();
                flight_arrive_time = dgv.CurrentRow.Cells[14].Value.ToString();
                flight_arrive_term = dgv.CurrentRow.Cells[15].Value.ToString();
                flight_length = dgv.CurrentRow.Cells[16].Value.ToString();
                flightFolderPathString = dgv.CurrentRow.Cells[17].Value.ToString();
            }
        }

        private string fullname = "";
        public String FullName
        {
            get { return fullname; }
            set { this.fullname = value; }
        }

        private string pers_id_ = "";
        public String Pers_ID
        {
            get { return pers_id_; }
            set { this.pers_id_ = value; }
        }

        private void go_to_flight_Click(object sender, EventArgs e)
        {
            if (flight_name_box.TextLength < 1 || flight_created_by_box.TextLength < 1 || flight_from_box.TextLength < 1
                || flight_to_box.TextLength < 1 || flight_date_box.TextLength < 1 || flight_airline_box.TextLength < 1)
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
                this.result = "CONTINUE FLIGHT BUTTON PRESSED";
                //show Add record Dashboard here
                RecordDashboard recordDashboard = new RecordDashboard();
                recordDashboard.FullName = fullname;
                recordDashboard.User_ID = pers_id_;
                recordDashboard.Pers_ROLE = pers_role_;
                recordDashboard.Flight_From = flight_from;
                recordDashboard.Flight_To = flight_to;
                recordDashboard.Flight_Airline = flight_airline;
                recordDashboard.Flight_Date = flight_date;
                recordDashboard.Flight_Class = flight_class;
                recordDashboard.Flight_Date_Created = flight_date_created;
                recordDashboard.Flight_ = new Flight(flightFolderPathString, flight_created_by_name, flight_created_by_email, flight_date_created, flight_date,
                    flight_airline, flight_number, flight_from, country_from, flight_depart_time, flight_depart_term, flight_to,
                    country_to, flight_arrive_time, flight_arrive_term, flight_type, flight_length, "", flight_class);
                recordDashboard.Folder_Name = flightFolderPathString;
                recordDashboard.Flight_Details = read_lines;
                this.Close();
                recordDashboard.showInfo();
                recordDashboard.Show();
            }
        }

        private string filter_flight_number;
        public String FilterFlightNumber {
            get { return filter_flight_number; }
            set { this.filter_flight_number = value; }
        }

        private string result;
        public String Result {
            get { return this.result; }
            set { this.result = value; }
        }

        private void ContinueFlightList_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        HashSet<Tuple<String, String, String, String, String>> TUPLE_SOLUTION_TO_A_DIFFERENT_BREED_OF_PROBLEM(String param) {

            String[] array_of_dirs = Directory.GetDirectories(baseFolderPathString2);
            String[] array_of_dir_2;
            String[] array_of_content_Read_from_file;
            String[] array_of_content_read_from_line;
            String supposed_file;
            String flight_from, flight_to, flight_created_by, flight_created_date, flight_class, found_param_value;

            HashSet<Tuple<String, String, String, String, String>> tempHash = new HashSet<Tuple<String, String, String, String, String>>();
            foreach (string dir_in_each in array_of_dirs) {
                if (Directory.Exists(dir_in_each + "\\" + "Records")) { 
                    array_of_dir_2 = Directory.GetDirectories(dir_in_each + "\\" + "Records");
                    if (array_of_dir_2.Length > 0) {
                        foreach (String dir_in_each_2 in array_of_dir_2) {
                            supposed_file = dir_in_each_2 + "\\Record Details.travlr";
                            if (File.Exists(supposed_file)) {

                                found_param_value = null;
                                flight_from = null;
                                flight_to = null;
                                flight_created_by = null;
                                flight_created_date = null;
                                flight_class = null;

                                array_of_content_Read_from_file = File.ReadAllLines(supposed_file);
                                for (int j = 0; j < array_of_content_Read_from_file.Length; j++) { 
                                    array_of_content_read_from_line = array_of_content_Read_from_file[j].Split('=');
                                    if (array_of_content_read_from_line[0].Trim().ToLower() == "flight from") flight_from = array_of_content_read_from_line[1].ToLower();
                                    if (array_of_content_read_from_line[0].Trim().ToLower() == "flight to") flight_to = array_of_content_read_from_line[1].ToLower();
                                    if (array_of_content_read_from_line[0].Trim().ToLower() == "recorded by_name") flight_created_by = array_of_content_read_from_line[1].ToLower();
                                    if (array_of_content_read_from_line[0].Trim().ToLower() == "date-time recorded") flight_created_date = array_of_content_read_from_line[1].ToLower();
                                    if (array_of_content_read_from_line[0].Trim().ToLower() == "class") flight_class = array_of_content_read_from_line[1].ToLower();
                                    if (array_of_content_read_from_line[0].Trim().ToLower() == param.Trim().ToLower()) found_param_value = array_of_content_read_from_line[1].ToLower();
                                };

                                if (found_param_value != null && found_param_value.Trim().IndexOf(search_box.Text, StringComparison.OrdinalIgnoreCase) > -1) {
                                    if (flight_from != null && flight_to != null && flight_created_by != null && flight_date_created != null && flight_class != null) {
                                        tempHash.Add(new Tuple<String, String, String, String, String>(flight_from, flight_to, flight_created_by, flight_created_date, flight_class));
                                    };
                                };

                            };
                                
                        };
                    };
                };

            };

            return tempHash;
        }


        private void search_btn_Click(object sender, EventArgs e)
        {

            #region A DIFFERENT BREED OF PROBLEM
            if (flight_combo.Text.Trim().ToLower() == "scanned passport number" || flight_combo.Text.Trim().ToLower() == "scanned passport name") {

                HashSet<Tuple<String, String, String, String, String>> hash_of_found_flight_locations = TUPLE_SOLUTION_TO_A_DIFFERENT_BREED_OF_PROBLEM(flight_combo.Text);
                Boolean record_matched;
                foreach (DataGridViewRow _row in flightsDataGrid.Rows) {
                    record_matched = false;
                    foreach (var _tuple in hash_of_found_flight_locations) {
                        if (_row.Cells[getItemIndex("flight from")].Value.ToString().Trim().ToLower().Contains(_tuple.Item1.Trim().ToLower()) && 
                            _row.Cells[getItemIndex("flight to")].Value.ToString().Trim().ToLower().Contains(_tuple.Item2.Trim().ToLower()) &&
                            _row.Cells[getItemIndex("Created_By Name")].Value.ToString().Trim().ToLower().Contains(_tuple.Item3.Trim().ToLower()) && 
                            //_row.Cells[getItemIndex("Flight Date Created")].Value.ToString().Trim().ToLower().Contains(_tuple.Item4.Trim().ToLower()) && 
                            _row.Cells[getItemIndex("Flight Class")].Value.ToString().Trim().ToLower().Contains(_tuple.Item5.Trim().ToLower())) {

                            record_matched = true;
                            break;
                        };
                    };

                    if (record_matched) {
                        flightsDataGrid.Rows[_row.Index].Visible = true;
                        flightsDataGrid.Rows[_row.Index].Selected = true;
                    } else {
                        flightsDataGrid.CurrentCell = null;
                        flightsDataGrid.Rows[_row.Index].Visible = false;
                    };
                }

                return;
            };
            #endregion A DIFFERENT BREED OF PROBLEM

            foreach (System.Windows.Forms.DataGridViewRow r in flightsDataGrid.Rows)
            {
                if ((r.Cells[getItemIndex(flight_combo.Text.Trim().ToString().ToLower())].Value).ToString().Trim().ToUpper().Contains(search_box.Text.Trim().ToUpper()))
                {
                    flightsDataGrid.Rows[r.Index].Visible = true;
                    flightsDataGrid.Rows[r.Index].Selected = true;
                }
                else
                {
                    flightsDataGrid.CurrentCell = null;
                    flightsDataGrid.Rows[r.Index].Visible = false;
                }
            }
        }

        public static DataTable ConvertListToDataTable<T>(List<T> items)
        { //iC<>deiDesign


            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)

            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }

        public void ModifyTheNewDatatable (DataTable myDatatable)
        {
            #region Reformatting the date directly in the new data source
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tempStrForDateReformatting = (table.Rows[i][6]).ToString().Replace("A", "").Replace("P", "").Replace("M", "").Trim();
                try
                {
                    tempStrForDateReformatting = DateTime.ParseExact(tempStrForDateReformatting, "dd MMM yyyy HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("yyyy/M/d HH:mm:ss");
                }
                catch (Exception)
                {
                    try
                    {
                        tempStrForDateReformatting = DateTime.ParseExact((table.Rows[i][6]).ToString().Trim(), "d MMM yyyy HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("yyyy/M/d HH:mm:ss");
                    }
                    catch (Exception)
                    {

                    }
                }
                table.Rows[i].SetField(6, tempStrForDateReformatting);
            };
            #endregion Reformatting the date directly in the new data source

        }

        private int getItemIndex(string item) {
            if (item.ToLower().Equals("flight name"))
            {
                return 0;
            }
            else if (item.ToLower().Equals("created_by name"))
            {
                return 1;
            }
            else if (item.ToLower().Equals("created_by email"))
            {
                return 2;
            }
            else if (item.ToLower().Equals("flight from"))
            {
                return 3;
            }
            else if (item.ToLower().Equals("flight to"))
            {
                return 4;
            }
            else if (item.ToLower().Equals("flight airline"))
            {
                return 5;
            }
            else if (item.ToLower().Equals("flight date created"))
            {
                return 6;
            }
            else if (item.ToLower().Equals("flight date"))
            {
                return 7;
            }
            else if (item.ToLower().Equals("flight type"))
            {
                return 8;
            }
            else if (item.ToLower().Equals("flight number"))
            {
                return 9;
            }
            else if (item.ToLower().Equals("country from"))
            {
                return 10;
            }
            else if (item.ToLower().Equals("flight depart time"))
            {
                return 11;
            }
            else if (item.ToLower().Equals("flight depart terminal"))
            {
                return 12;
            }
            else if (item.ToLower().Equals("country to"))
            {
                return 13;
            }
            else if (item.ToLower().Equals("flight arrive time"))
            {
                return 14;
            }
            else if (item.ToLower().Equals("flight arrive terminal"))
            {
                return 15;
            }
            else if (item.ToLower().Equals("flight length"))
            {
                return 16;
            }
            else if (item.ToLower().Equals("flight folder path"))
            {
                return 17;
            }
            else if (item.ToLower().Equals("flight class"))
            {
                return 18;
            }
            else {
                return 0;
            }
        }

        private void search_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                search_btn.PerformClick();
            };
        }

        private void btn_smart_search_Click(object sender, EventArgs e)
        {
            SmartSearchForm form = new SmartSearchForm(returnBaseFolderPathString(pers_role_));
            form.ShowDialog();
        }

        //private string filter_flight_from;
        //public String FilterFlightFrom {
        //    get { return filter_flight_from; }
        //    set { this.filter_flight_from = value; }
        //}

        //private string filter_flight_to;
        //public String FilterFlightTo {
        //    get { return filter_flight_to; }
        //    set { this.filter_flight_to = value; }
        //}
    }
}
