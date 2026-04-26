using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    
    public class VFlight
    {
        public string FLIGHT_NAME { get; set; }
        public string CREATED_BY_NAME { get; set; }
        public string CREATED_BY_EMAIL { get; set; }
        public string FROM { get; set; }
        public string TO { get; set; }
        public string AIRLINE { get; set; }
        public string DATE_CREATED { get; set; }
        public string FLIGHT_DATE { get; set; }
        public string FLIGHT_TYPE { get; set; }
        public string FLIGHT_NUMBER { get; set; }
        public string COUNTRY_FROM { get; set; }
        public string FLIGHT_DEPART_TIME { get; set; }
        public string FLIGHT_DEPART_TERM { get; set; }
        public string COUNTRY_TO { get; set; }
        public string FLIGHT_ARRIVE_TIME { get; set; }
        public string FLIGHT_ARRIVE_TERM { get; set; }
        public string FLIGHT_LENGTH { get; set; }
        public string FLIGHT_FOLDER_PATH { get; set; }
        public string FLIGHT_CLASS { get; set; }

        public VFlight(string flight_name, string created_by_name, string created_by_email, string from, string to, string airline, string date_created, string flight_date, string flight_type,
            string flight_number, string country_from, string flight_depart_time, string flight_depart_term, string country_to, string flight_arrive_time,
            string flight_arrive_term, string flight_length, string flight_folder_path, string flight_class) {

            this.FLIGHT_NAME = flight_name;
            this.CREATED_BY_NAME = created_by_name;
            this.CREATED_BY_EMAIL = created_by_email;
            this.FROM = from;
            this.TO = to;
            this.AIRLINE = airline;
            this.DATE_CREATED = date_created;
            this.FLIGHT_DATE = flight_date;
            this.FLIGHT_TYPE = flight_type;
            this.FLIGHT_NUMBER = flight_number;
            this.COUNTRY_FROM = country_from;
            this.FLIGHT_DEPART_TIME = flight_depart_time;
            this.FLIGHT_DEPART_TERM = flight_depart_term;
            this.COUNTRY_TO = country_to;
            this.FLIGHT_ARRIVE_TIME = flight_arrive_time;
            this.FLIGHT_ARRIVE_TERM = flight_arrive_term;
            this.FLIGHT_LENGTH = flight_length;
            this.FLIGHT_FOLDER_PATH = flight_folder_path;
            this.FLIGHT_CLASS = flight_class;
        }


    }
}
