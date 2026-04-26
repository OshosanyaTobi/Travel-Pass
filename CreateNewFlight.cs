using ADODB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class CreateNewFlight : Form
    {
        public delegate void delPassData(TextBox text);

        Hashtable hashtable = new Hashtable();
        Dictionary<String, _FlightDefinition> predefined_flight_definitions = _Public.predefined_flight_definitions;
        
        public CreateNewFlight()
        {
            InitializeComponent();

            foreach (var fd in _Public.predefined_flight_definitions) {
                flight_number.Items.Add(fd.Key);
            };

        }

        private void CreateNewFlight_Load(object sender, EventArgs e)
        {
            //fullname = "Victor Shoaga";
            //user_id = "victorshoaga@gmail.com"; //or user email

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            Console.WriteLine(appPath);

            ////flight_details data setup
            //var fcollection_of_objects =
            //    (from line in File.ReadAllLines("flight_details.csv").Skip(1)
            //     let parts = line.Split(',')
            //     select new
            //     {
            //         airline_ = parts[1],
            //         flight_number = parts[2],
            //         flight_from = parts[3],
            //         country_from = parts[4],
            //         dept_time = parts[5],
            //         dept_term = parts[6],
            //         flight_to = parts[7],
            //         country_to = parts[8],
            //         arrive_time = parts[9],
            //         arrive_term = parts[10],
            //         aircraft_type = parts[11],
            //         length_hrs = parts[12],
            //     }
            //    ).ToList();
            //Console.WriteLine("first flight detail is = " + fcollection_of_objects[0].flight_number);
            //string[] flight_number_data = new string[fcollection_of_objects.Count];
            //Console.WriteLine(fcollection_of_objects.Count + " fffff");
            //for (int i = 0; i < fcollection_of_objects.Count; i++)
            //{
            //    flight_number_data[i] = fcollection_of_objects[i].flight_number.Replace("\"", "").Trim();
            //    flight_number.Items.Add(flight_number_data[i]);
            //    try
            //    {
            //        //hashtable_ = new Dictionary<string, DFlight>
            //        //{
            //        //    { flight_number_data[i].ToString().Trim(), new DFlight(fcollection_of_objects[i].airline_.Replace("\"", ""), fcollection_of_objects[i].flight_number.Replace("\"", ""),
            //        //    fcollection_of_objects[i].flight_from.Replace("\"", ""), fcollection_of_objects[i].country_from.Replace("\"", ""), fcollection_of_objects[i].dept_time.Replace("\"", ""),
            //        //    fcollection_of_objects[i].dept_term.Replace("\"", ""), fcollection_of_objects[i].flight_to.Replace("\"", ""), fcollection_of_objects[i].country_to.Replace("\"", ""),
            //        //    fcollection_of_objects[i].arrive_time.Replace("\"", ""), fcollection_of_objects[i].arrive_term.Replace("\"", ""), fcollection_of_objects[i].aircraft_type.Replace("\"", ""),
            //        //    fcollection_of_objects[i].length_hrs.Replace("\"", "")) }
            //        //};
            //        hashtable_.Add(flight_number_data[i].ToString().Trim(), new DFlight(fcollection_of_objects[i].airline_.Replace("\"", ""), fcollection_of_objects[i].flight_number.Replace("\"", ""),
            //            fcollection_of_objects[i].flight_from.Replace("\"", ""), fcollection_of_objects[i].country_from.Replace("\"", ""), fcollection_of_objects[i].dept_time.Replace("\"", ""),
            //            fcollection_of_objects[i].dept_term.Replace("\"", ""), fcollection_of_objects[i].flight_to.Replace("\"", ""), fcollection_of_objects[i].country_to.Replace("\"", ""),
            //            fcollection_of_objects[i].arrive_time.Replace("\"", ""), fcollection_of_objects[i].arrive_term.Replace("\"", ""), fcollection_of_objects[i].aircraft_type.Replace("\"", ""),
            //            fcollection_of_objects[i].length_hrs.Replace("\"", "")));
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //    Console.WriteLine("fefeefef" + flight_number_data[i]);
            //}
            //Console.WriteLine("length of flight details data is = " + flight_number_data.Length);
            //Console.WriteLine(hashtable_.Keys.Count);
            //flight_number.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //flight_number.AutoCompleteCustomSource.AddRange(flight_number_data);
            

            //flight_airports data setup
            var collection_of_objects =
                (from line in File.ReadAllLines("airports.dat").Skip(1)
                 let parts = line.Split(',')
                 select new
                 {
                     airport_name = parts[1],
                     airport_country = parts[3],
                     airport_code = parts[4],
                 }
                ).ToList();
            Console.WriteLine("first airport name is = " + collection_of_objects[0].airport_name);
            string[] airport_data = new string[collection_of_objects.Count];
            
            for (int i = 0; i < collection_of_objects.Count; i++) {
                airport_data[i] = collection_of_objects[i].airport_code.Trim(new Char[] {'"'}) + "-" + collection_of_objects[i].airport_name.Trim(new Char[] { '"' });
                try {
                    hashtable.Add(airport_data[i].ToString().Trim(), collection_of_objects[i].airport_country.ToString().Trim());
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("length of airport data is = " + airport_data.Length);
            flight_from.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            flight_from.AutoCompleteCustomSource.AddRange(airport_data);
            flight_to.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            flight_to.AutoCompleteCustomSource.AddRange(airport_data);
            
            //flight_airline data setup
            var collection_of_objects_ =
                (from line in File.ReadAllLines("airlines.dat").Skip(1)
                 let parts = line.Split(',')
                 select new
                 {
                     airline_name = parts[1],
                     airline_code = parts[3],
                 }
                ).ToList();
            Console.WriteLine("first airline name is = " + collection_of_objects_[0].airline_name);
            string[] airline_data = new string[collection_of_objects_.Count];
            for (int i = 0; i < collection_of_objects_.Count; i++)
            {
                airline_data[i] = collection_of_objects_[i].airline_name.Trim(new Char[] { '"' }) + "-" + collection_of_objects_[i].airline_code.Trim(new Char[] { '"' });
            }
            Console.WriteLine("length of airline data is = " + airline_data.Length);
            flight_airline.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            flight_airline.AutoCompleteCustomSource.AddRange(airline_data);



            flight_date.Format = DateTimePickerFormat.Short;
            flight_date.Value = DateTime.Today;
        }

        private void CreateNewFlight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_create_flight_Click(object sender, EventArgs e)
        {
            if (this.flight_date.Text.Length < 1 || this.flight_airline.Text.Length < 1 || this.flight_number.Text.Length < 1 ||
                this.flight_from.Text.Length < 1 || this.flight_depart_time.Text.Length < 1 || this.flight_depart_term.Text.Length < 1 ||
                this.flight_to.Text.Length < 1 || this.flight_arrive_time.Text.Length < 1 || this.flight_arrive_term.Text.Length < 1 ||
                this.flight_type.Text.Length < 1 || this.flight_length.Text.Length < 1 || this.country_from.Text.Length < 1 ||
                this.country_to.Text.Length < 1 || this.flight_class_combo.Text.Length < 1)
            {
                MessageBox.Show("Please enter complete details.",
                                "Error Report",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign,
                                false);
            }
            else {
                string baseFolderName = @"c:\TravelPass\Flights";
                string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
                string now_dateTime = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
                string flight_folder_name = "Flight" + this.flight_number.Text.Trim() + "_" + this.flight_date.Text.ToString().Replace("/", "~") + "_" + now_time.Replace(":", "#");
                string flight_details_name = "Flight Details.travlr";
                createFlightDirectory(baseFolderName, flight_folder_name, flight_details_name, user_id,
                    now_dateTime, this.flight_date.Value.ToString().Substring(0, 10), this.flight_airline.Text.Trim(),
                    this.flight_number.Text.Trim(), this.flight_from.Text.Trim(),
                    this.flight_depart_time.Text.Trim(), this.flight_depart_term.Text.Trim(),
                    this.flight_to.Text.Trim(), this.flight_arrive_time.Text.Trim(),
                    this.flight_arrive_term.Text.Trim(), this.flight_type.Text.Trim(),
                    this.flight_length.Text.Trim(), this.country_from.Text.Trim(),
                    this.country_to.Text.Trim(), this.flight_class_combo.Text.Trim());
            }
            
        }

        private string pers_role_ = "";
        public String Pers_ROLE
        {
            get { return pers_role_; }
            set { this.pers_role_ = value; }

        }
        private void createFlightDirectory(string base_folder_name,
            string flight_folder_name, string flight_details_file_name, string user_email,
            string date_created, string flight_date, string flight_airline, string flight_number,
            string flight_from, string flight_depart_time, string flight_depart_term,
            string flight_to, string flight_arrive_time, string flight_arrive_term,
            string flight_type, string flight_length, string country_from, string country_to, string flight_class)
        {
            try {

                #region SQLITE CODE HERE
                String entry_id = "x";
                Recordset rs = new Recordset();
                rs.Open("INSERT INTO tblFlights (" +
                        "entryID, " +
                        "createdBy, " +
                        "date_time_created, " +
                        "flight_date, " +
                        "flight_airline, " +
                        "flight_number, " +
                        "flight_from, " +
                        "country_from, " +
                        "flight_depart_time, " +
                        "flight_depart_term, " +
                        "flight_to, " +
                        "country_to, " +
                        "flight_arrive_time, " +
                        "flight_arrive_term, " +
                        "flight_type, " +
                        "flight_length, " +
                        "flight_final_dest, " +
                        "flight_class) VALUES (" +
                        "'" + entry_id + "', " +
                        "'" + user_id + "', " +
                        "'" + _DateTime.NowString + "', " +
                        "'" + _DateTime.GivenDateString(this.flight_date.Value) + "', " +
                        "'" + this.flight_airline.Text.Trim() + "', " +
                        "'" + this.flight_number.Text.Trim() + "', " +
                        "'" + this.flight_from.Text.Trim() + "', " +
                        "'" + this.country_from.Text.Trim() + "', " +
                        "'" + this.flight_depart_time.Text.Trim() + "', " +
                        "'" + this.flight_depart_term.Text.Trim() + "', " +
                        "'" + this.flight_to.Text.Trim() + "', " +
                        "'" + this.country_to.Text.Trim() + "', " +
                        "'" + this.flight_arrive_time.Text.Trim() + "', " +
                        "'" + this.flight_arrive_term.Text.Trim() + "', " +
                        "'" + this.flight_type.Text.Trim() + "', " +
                        "'" + this.flight_length.Text.Trim() + "', " +
                        "'" + "nil" + "', " +
                        "'" + this.flight_class_combo.Text.Trim() + "')", _SQLite.connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);
                #endregion SQLITE CODE HERE

                string flightFolderPathString = System.IO.Path.Combine(base_folder_name, flight_folder_name);
                Console.WriteLine("Flight Folder Path String = " + flightFolderPathString);
                System.IO.Directory.CreateDirectory(flightFolderPathString);
                string flightDetailsPathString = System.IO.Path.Combine(flightFolderPathString, flight_details_file_name);
                if (!System.IO.File.Exists(flightDetailsPathString))
                {
                    string[] lines = {"***Flight Details***",
                        "Flight Folder Path = " + @"" + "\"" + flightFolderPathString + "\"",
                        "Flight Created by_Name = " + fullname,
                        "Flight Created by_Email = " + user_email,
                        "Date-Time Created = " + date_created,
                        "Flight Date = " + flight_date, "Flight Airline = " + flight_airline,
                        "Flight Number = " + flight_number, "Flight From = " + flight_from, "Country From = " + country_from,
                        "Flight Depart Time = " + flight_depart_time, "Flight Depart Term = " + flight_depart_term,
                        "Flight To = " + flight_to, "Country To = " + country_to, "Flight Arrive Time = " + flight_arrive_time,
                        "Flight Arrive Term = " + flight_arrive_term, "Flight Type = " + flight_type,
                        "Flight Length = " + flight_length,
                        "Flight Class = " + flight_class
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(flightDetailsPathString))
                    {
                        foreach (string line in lines)
                        {
                            file.WriteLine(line);
                        }
                    }

                    DialogResult dResult = MessageBox.Show("Flight has been created successfully",
                                                            "Success Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
                    if (dResult == DialogResult.OK)
                    {
                        Flight flight = new Flight(flightFolderPathString, fullname, user_email, date_created, flight_date, flight_airline,
                            flight_number, flight_from, country_from, flight_depart_time, flight_depart_term, flight_to, country_to,
                            flight_arrive_time, flight_arrive_term, flight_type, flight_length, flight_to, flight_class);
                        Console.WriteLine("Flight - Weldone");
                        this.Result = "SUCCESS_FLIGHT";
                        //show Add record Dashboard here
                        RecordDashboard recordDashboard = new RecordDashboard();
                        recordDashboard.FullName = fullname;
                        recordDashboard.User_ID = user_id;
                        recordDashboard.Pers_ROLE = pers_role_;
                        recordDashboard.Flight_From = flight_from;
                        recordDashboard.Flight_To = flight_to;
                        recordDashboard.Flight_Airline = flight_airline;
                        recordDashboard.Flight_Date = flight_date;
                        recordDashboard.Flight_Date_Created = date_created;
                        recordDashboard.Flight_ = flight;
                        recordDashboard.Flight_Class = flight_class;
                        recordDashboard.Folder_Name = flightFolderPathString;
                        recordDashboard.Flight_Details = lines;
                        this.Hide();
                        Console.WriteLine(fullname);
                        Console.WriteLine(user_id);
                        recordDashboard.showInfo();
                        recordDashboard.Show();
                    }
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists.", flight_details_file_name);
                    DialogResult dResult = MessageBox.Show("File system already exists. Please try again!",
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.DefaultDesktopOnly,
                                                            false);
                    return;
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                DialogResult dResult = MessageBox.Show("Error while creating flight. Issue: " + ex.Message,
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
            }
            

        }

        //private void createFlight(string flight_date, string flight_airline, string flight_number, 
        //    string flight_from, string flight_depart_time, string flight_depart_term,
        //    string flight_to, string flight_arrive_time, string flight_arrive_term,
        //    string flight_type, string flight_length, string country_from, string country_to)
        //{

        //    string connString = @"Data Source=ALML-TRAVELPASS\SQLEXPRESS;Initial Catalog=TravelPassDB;Integrated Security=True";
        //    SqlConnection connection = new SqlConnection(connString);
        //    connection.Open();
        //    try
        //    {
        //        // Insert statement.
        //        string sql = "INSERT INTO FLIGHT (FLIGHT_DATE, FLIGHT_AIRLINE, FLIGHT_NUMBER, FLIGHT_FROM, FLIGHT_DEPART_TIME, FLIGHT_DEPART_TERM, FLIGHT_TO, FLIGHT_ARRIVE_TIME, FLIGHT_ARRIVE_TERM, FLIGHT_TYPE, FLIGHT_LENGTH, COUNTRY_FROM, COUNTRY_TO) "
        //                                         + " VALUES (@FLIGHT_DATE, @FLIGHT_AIRLINE, @FLIGHT_NUMBER, @FLIGHT_FROM, @FLIGHT_DEPART_TIME, @FLIGHT_DEPART_TERM, @FLIGHT_TO, @FLIGHT_ARRIVE_TIME, @FLIGHT_ARRIVE_TERM, @FLIGHT_TYPE, @FLIGHT_LENGTH, @COUNTRY_FROM, @COUNTRY_TO) ";

        //        SqlCommand cmd = connection.CreateCommand();
        //        cmd.CommandText = sql;

        //        cmd.Parameters.Add("@FLIGHT_DATE", SqlDbType.VarChar).Value = flight_date;
        //        cmd.Parameters.Add("@FLIGHT_AIRLINE", SqlDbType.VarChar).Value = flight_airline;
        //        cmd.Parameters.Add("@FLIGHT_NUMBER", SqlDbType.VarChar).Value = flight_number;
        //        cmd.Parameters.Add("@FLIGHT_FROM", SqlDbType.VarChar).Value = flight_from;
        //        cmd.Parameters.Add("@FLIGHT_DEPART_TIME", SqlDbType.VarChar).Value = flight_depart_time;
        //        cmd.Parameters.Add("@FLIGHT_DEPART_TERM", SqlDbType.VarChar).Value = flight_depart_term;
        //        cmd.Parameters.Add("@FLIGHT_TO", SqlDbType.VarChar).Value = flight_to;
        //        cmd.Parameters.Add("@FLIGHT_ARRIVE_TIME", SqlDbType.VarChar).Value = flight_arrive_time;
        //        cmd.Parameters.Add("@FLIGHT_ARRIVE_TERM", SqlDbType.VarChar).Value = flight_arrive_term;
        //        cmd.Parameters.Add("@FLIGHT_TYPE", SqlDbType.VarChar).Value = flight_type;
        //        cmd.Parameters.Add("@FLIGHT_LENGTH", SqlDbType.VarChar).Value = flight_length;
        //        cmd.Parameters.Add("@COUNTRY_FROM", SqlDbType.VarChar).Value = country_from;
        //        cmd.Parameters.Add("@COUNTRY_TO", SqlDbType.VarChar).Value = country_to;

        //        // Execute Command (for Delete,Insert or Update).
        //        int rowCount = cmd.ExecuteNonQuery();
        //        Console.WriteLine("Row Count affected = " + rowCount);
        //        DialogResult dResult = MessageBox.Show("Flight has been created successfully",
        //                                                "Success Report",
        //                                                MessageBoxButtons.OK,
        //                                                MessageBoxIcon.Information,
        //                                                MessageBoxDefaultButton.Button1,
        //                                                MessageBoxOptions.RightAlign,
        //                                                false);
        //        if (dResult == DialogResult.OK)
        //        {
        //            Console.WriteLine("Flight - Weldone");
        //            this.Result = "SUCCESS_FLIGHT";
        //            this.Close();

        //            //show Add record here
        //            Console.WriteLine("THereTHere");
        //            RecordDashboard recordDashboard = new RecordDashboard();
        //            recordDashboard.FullName = fullname;
        //            recordDashboard.User_ID = user_id;
        //            recordDashboard.Flight_From = flight_from;
        //            recordDashboard.Flight_To = flight_to;
        //            recordDashboard.showInfo();
        //            this.Hide();
        //            recordDashboard.Show();
        //            Console.WriteLine("Shown RecordDashboard");
                    

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: " + e);
        //        Console.WriteLine(e.StackTrace);
        //        DialogResult dResult = MessageBox.Show("Error while creating flight",
        //                                                "Error Report",
        //                                                MessageBoxButtons.OK,
        //                                                MessageBoxIcon.Error,
        //                                                MessageBoxDefaultButton.Button1,
        //                                                MessageBoxOptions.RightAlign,
        //                                                false);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        connection.Dispose();
        //        connection = null;
        //        Console.WriteLine("Closed connection");
        //    }
        //}

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private string fullname;
        public String FullName {
            get { return fullname; }
            set { this.fullname = value;  }
        }

        private string user_id;
        public String User_ID {
            get { return user_id; }
            set { this.user_id = value; }
        }

        private string result;
        public String Result {
            get { return result; }
            set { this.result = value; }
        }

        private void flight_from_Leave(object sender, EventArgs e)
        {
            try {
                if (flight_from.Text.ToString().Length > 1)
                {
                    country_from.Text = hashtable[flight_from.Text.Trim()].ToString().Trim(new Char[] { '"' });
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void flight_to_Leave(object sender, EventArgs e)
        {
            try {
                if (flight_to.Text.ToString().Length > 1)
                {
                    country_to.Text = hashtable[flight_to.Text.Trim()].ToString().Trim(new Char[] { '"' });
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void flight_from_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_create_flight_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_cancel_flight_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flight_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FlightDefinition fd = predefined_flight_definitions[flight_number.Text];
            flight_airline.Text = fd.airline_name;
            flight_from.Text = fd.flight_airport_departure;
            country_from.Text = fd.flight_country_departure;
            flight_depart_time.Text = fd.flight_departure_time;
            flight_depart_term.Text = fd.departure_terminal;
            flight_to.Text = fd.flight_airport_destination;
            country_to.Text = fd.flight_country_destination;
            flight_arrive_time.Text = fd.flight_arrival_time;
            flight_arrive_term.Text = fd.arrival_terminal;
            flight_type.Text = fd.aircraft_name;
            flight_length.Text = fd.flight_duration.ToString();
        }
    }
}
