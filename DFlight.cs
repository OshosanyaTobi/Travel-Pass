using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPass
{
    public class DFlight
    {
        public String AIRLINE { get; set; }
        public String FLIGHT_NUMBER { get; set; }
        public String FLIGHT_FROM { get; set; }
        public String COUNTRY_FROM { get; set; }
        public String DEPT_TIME { get; set; }
        public String DEPT_TERM { get; set; }
        public String FLIGHT_TO { get; set; }
        public String COUNTRY_TO { get; set; }
        public String ARRIVE_TIME { get; set; }
        public String ARRIVE_TERM { get; set; }
        public String AIRCRAFT_TYPE { get; set; }
        public String LENGTH_HRS { get; set; }

        public DFlight(string airline, string flight_number, string flight_from, string country_from, string dept_time, string dept_term, string flight_to, string country_to,
            string arrive_time, string arrive_term, string aircraft_type, string length_hrs)
        {
            this.AIRLINE = airline;
            this.FLIGHT_NUMBER = flight_number;
            this.FLIGHT_FROM = flight_from;
            this.COUNTRY_FROM = country_from;
            this.DEPT_TIME = dept_time;
            this.DEPT_TERM = dept_term;
            this.FLIGHT_TO = flight_to;
            this.COUNTRY_TO = country_to;
            this.ARRIVE_TIME = arrive_time;
            this.ARRIVE_TERM = arrive_term;
            this.AIRCRAFT_TYPE = aircraft_type;
            this.LENGTH_HRS = length_hrs;
        }
    }
}
