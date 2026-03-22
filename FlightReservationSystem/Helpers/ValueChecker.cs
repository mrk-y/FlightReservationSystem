using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class ValueChecker
    {
        public static bool HasSpaceStartEnd(string str)
        {
            return str.StartsWith(" ") || str.EndsWith(" ");
        }
    }
}
