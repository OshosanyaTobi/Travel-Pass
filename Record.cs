using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPass
{
    public class Record
    {
        private string folder_name;
        private string recorded_by;
        private string date_recorded;

        public Record(string folder_name, string recorded_by, string date_recorded) {
            this.recorded_by = recorded_by;
            this.date_recorded = date_recorded;
        }

        public String FolderName {
            get { return folder_name; }
            set { this.folder_name = value; }
        }

        public String RecordedBy {
            get { return recorded_by; }
            set { this.recorded_by = value; }
        }

        public String DateRecorded {
            get { return date_recorded; }
            set { this.date_recorded = value; }
        }
    }
}
