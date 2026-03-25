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
        private static string FourDigitCodeFormat(int code) => code.ToString("D4");

        public static string UserIDFormat(string prefix, int uCode) => $"{prefix}-{FourDigitCodeFormat(uCode)}";
        
        public static string AircraftIDFormat(int acCode) => $"RP-C{FourDigitCodeFormat(acCode)}";
    }
}
