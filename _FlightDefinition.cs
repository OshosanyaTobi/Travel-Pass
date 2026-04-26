using ADODB;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TravelPass.Properties;

namespace TravelPass
{
    class _FlightDefinition
    {
        public String flight_id { get; set; }
        public String airline_name { get; set; }
        public String flight_airport_departure { get; set; }
        public String flight_airport_destination { get; set; }
        public String flight_country_departure { get; set; }
        public String flight_country_destination { get; set; }
        public String departure_terminal { get; set; }
        public String arrival_terminal { get; set; }
        public String flight_departure_time { get; set; }
        public String flight_arrival_time { get; set; }
        public String aircraft_name { get; set; }
        public Double flight_duration { get; set; }

        public _FlightDefinition(String flight_id, 
                                 String airline_name, 
                                 String flight_airport_departure,
                                 String flight_airport_destination, 
                                 String flight_country_departure, 
                                 String flight_country_destination,
                                 String departure_terminal,
                                 String arrival_terminal,
                                 String flight_departure_time,
                                 String flight_arrival_time,
                                 String aircraft_name,
                                 Double flight_duration)
        {
            this.flight_id = flight_id;
            this.airline_name = airline_name;
            this.flight_airport_departure = flight_airport_departure;
            this.flight_airport_destination = flight_airport_destination;
            this.flight_country_departure = flight_country_departure;
            this.flight_country_destination = flight_country_destination;
            this.departure_terminal = departure_terminal;
            this.arrival_terminal = arrival_terminal;
            this.flight_departure_time = flight_departure_time;
            this.flight_arrival_time = flight_arrival_time;
            this.aircraft_name = aircraft_name;
            this.flight_duration = flight_duration;
        }

    }
}
