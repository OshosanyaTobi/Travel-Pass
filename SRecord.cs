using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPass
{
    public class SRecord
    {
        public string SCAN_FOLDER_NAME { get; set; }
        public string SCAN_FOLDER_PATH { get; set; }

        public SRecord(string scan_folder_name, string scan_folder_path) {
            this.SCAN_FOLDER_NAME = scan_folder_name;
            this.SCAN_FOLDER_PATH = scan_folder_path;
        }

    }
}
