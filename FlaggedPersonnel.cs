using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPass
{
    class FlaggedPersonnel
    {
        public String NAME { get; set; }
        public String PASSPORT_NUMBER { get; set; }
        public String FLAGGED_BY { get; set; }

        public FlaggedPersonnel(string name, string passport_number, string flagged_by) {
            this.NAME = name;
            this.PASSPORT_NUMBER = passport_number;
            this.FLAGGED_BY = flagged_by;
        }
    }
}
