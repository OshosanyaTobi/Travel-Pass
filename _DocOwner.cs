using ADODB;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TravelPass.Properties;

namespace TravelPass
{
    class _DocOwner
    {
        public String family_name { get; set; }
        public String given_names { get; set; }
        public String gender { get; set; }
        public DateTime dob { get; set; }
        public DateTime nationality { get; set; }
        public String document_type { get; set; }
        public String document_number { get; set; }

        public _DocOwner(String family_name, String given_names, String gender, DateTime dob, String document_type, String document_number)
        {
            this.family_name = family_name;
            this.given_names = given_names;
            this.gender = gender;
            this.dob = dob;
            this.document_type = document_type;
            this.document_number = document_number;
        }


    }
}
