using ADODB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TravelPass.Properties;

namespace TravelPass
{
    class _Public
    {

        public static List<_FlaggedDocOwner> flagged_doc_owners = new List<_FlaggedDocOwner>();
        public static Dictionary<String, _FlightDefinition> predefined_flight_definitions = new Dictionary<String, _FlightDefinition>();
        
    }
}
