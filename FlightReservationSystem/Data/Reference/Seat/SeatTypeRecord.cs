using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Seat
{
    internal class SeatTypeRecord
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string SeatType { get; set; }


        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Code_Try(string code)
        {
            if (!ValueChecker.IsStringValid(code))
            {
                DebugLogger.LogWithStackTrace("code invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool SeatType_Try(string seatType)
        {
            if (!ValueChecker.IsStringValid(seatType))
            {
                DebugLogger.LogWithStackTrace("seatType invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
