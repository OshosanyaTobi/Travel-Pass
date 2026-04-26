using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPass
{
    public class Flight
    {
        private string folder_name;
        private string created_by_name;
        private string created_by_email;
        private string date_time_created;
        private string flight_date;
        private string flight_airline;
        private string flight_number;
        private string flight_from;
        private string country_from;
        private string flight_depart_time;
        private string flight_depart_term;
        private string flight_to;
        private string country_to;
        private string flight_arrive_time;
        private string flight_arrive_term;
        private string flight_type;
        private string flight_length;
        private string flight_final_dest;
        private string flight_class;

        public Flight(string folder_name, string created_by_name, string created_by_email, string date_time_created, string flight_date, string flight_airline, string flight_number,
        string flight_from, string country_from, string flight_depart_time, string flight_depart_term, string flight_to,
        string country_to, string flight_arrive_time, string flight_arrive_term, string flight_type, string flight_length, string flight_final_dest, string flight_class) {
            this.folder_name = folder_name;
            this.created_by_name = created_by_name;
            this.created_by_email = created_by_email;
            this.date_time_created = date_time_created;
            this.flight_date = flight_date;
            this.flight_airline = flight_airline;
            this.flight_number = flight_number;
            this.flight_from = flight_from;
            this.country_from = country_from;
            this.flight_depart_time = flight_depart_time;
            this.flight_depart_term = flight_depart_term;
            this.flight_to = flight_to;
            this.country_to = country_to;
            this.flight_arrive_time = flight_arrive_time;
            this.flight_arrive_term = flight_arrive_term;
            this.flight_type = flight_type;
            this.flight_length = flight_length;
            this.flight_final_dest = flight_final_dest;
            this.flight_class = flight_class;
        }

        public String FlightFinalDest {
            get { return flight_final_dest; }
            set { this.flight_final_dest = value; }
        }

        public string CreatedBy_Name {
            get { return created_by_name; }
            set { this.created_by_name = value; }
        }

        public string CreatedBy_Email {
            get { return created_by_email; }
            set { this.created_by_email = value; }
        }

        public string DateTimeCreated {
            get { return date_time_created; }
            set { this.date_time_created = value; }
        }

        public string FlightDate {
            get { return flight_date; }
            set { this.flight_date = value; }
        }

        public string FlightAirline {
            get { return flight_airline; }
            set { this.flight_airline = value; }
        }

        public string FolderName {
            get { return folder_name; }
            set { this.folder_name = value; }
        }

        public string FlightNumber
        {
            get { return flight_number; }
            set { this.flight_number = value; }
        }

        public string FlightFrom
        {
            get { return flight_from; }
            set { this.flight_from = value; }
        }

        public string CountryFrom
        {
            get { return country_from; }
            set { this.country_from = value; }
        }

        public string FlightDepartTime
        {
            get { return flight_depart_time; }
            set { this.flight_depart_time = value; }
        }

        public string FlightDepartTerm
        {
            get { return flight_depart_term; }
            set { this.flight_depart_term = value; }
        }


        public string FlightTo
        {
            get { return flight_to; }
            set { this.flight_to = value; }
        }

        public string CountryTo
        {
            get { return country_to; }
            set { this.country_to = value; }
        }

        public string FlightArriveTime
        {
            get { return flight_arrive_time; }
            set { this.flight_arrive_time = value; }
        }

        public string FlightArriveTerm
        {
            get { return flight_arrive_term; }
            set { this.flight_arrive_term = value; }
        }

        public string FlightType
        {
            get { return flight_type; }
            set { this.flight_type = value; }
        }

        public string FlightLength
        {
            get { return flight_length; }
            set { this.flight_length = value; }
        }

        public string FlightClass
        {
            get { return flight_class; }
            set { this.flight_class = value; }
        }

    }
}
