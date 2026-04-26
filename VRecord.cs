using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPass
{
    public class VRecord
    {
        public string RECORD_FOLDER_PATH { get; set; }
        public string RECORDED_BY_NAME { get; set; }
        public string RECORDED_BY_EMAIL { get; set; }
        public string SCANNED_PASSPORT_NUMBER { get; set; }
        public string SCANNED_PASSPORT_NAME { get; set; }
        public string DATE_TIME_RECORDED { get; set; }
        public string FLIGHT_FROM { get; set; }
        public string FLIGHT_TO { get; set; }
        public string FINAL_DESTINATION { get; set; }

        public VRecord(string recorded_by_name, string recorded_by_email, string scanned_passport_number,
            string scanned_passport_name, string date_time_recorded, string flight_from, string flight_to, string final_destination, string record_folder_path)
        {

            this.RECORD_FOLDER_PATH = record_folder_path;
            this.RECORDED_BY_NAME = recorded_by_name;
            this.RECORDED_BY_EMAIL = recorded_by_email;
            this.SCANNED_PASSPORT_NUMBER = scanned_passport_number;
            this.SCANNED_PASSPORT_NAME = scanned_passport_name;
            this.DATE_TIME_RECORDED = date_time_recorded;
            this.FLIGHT_FROM = flight_from;
            this.FLIGHT_TO = flight_to;
            this.FINAL_DESTINATION = final_destination;
        }
    }
}
