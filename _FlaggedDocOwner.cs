using ADODB;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TravelPass.Properties;

namespace TravelPass
{
    class _FlaggedDocOwner
    {
        public _DocOwner document_owner { get; set; }
        public int entry_year { get; set; }
        public String reason_for_flag { get; set; }

        public _FlaggedDocOwner(_DocOwner document_owner, int entry_year, String reason_for_flag)
        {
            this.document_owner = document_owner;
            this.entry_year = entry_year;
            this.reason_for_flag = reason_for_flag;
        }


    }
}
