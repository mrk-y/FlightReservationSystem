using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class DataFormatter
    {
        private static string userCodeFormat(int userCode)
        {
            return userCode.ToString("D4");
        }

        public static string UserIDFormat(string prefix, int userCode)
        {
            return $"{prefix}-{userCodeFormat(userCode)}";
        }
    }
}
