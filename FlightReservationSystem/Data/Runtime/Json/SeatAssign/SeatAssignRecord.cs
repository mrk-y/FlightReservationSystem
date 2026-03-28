using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Json.SeatAssign
{
    internal class SeatAssignRecord
    {
        public string SeatCode { get; set; }
        public List<int> SeatTypes { get; set; }  = new List<int>();


        public static bool SeatCode_Try(string seatCode)
        {
            if (!ValueChecker.IsStringValid(seatCode))
            {
                DebugLogger.LogWithStackTrace("seatCode invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool SeatTypes_Try(List<int> seatTypes)
        {
            if (seatTypes == null)
            {
                DebugLogger.LogWithStackTrace("seatTypes is null. Try false.");
                return false;
            }

            if (seatTypes.Count == 0)
            {
                DebugLogger.LogWithStackTrace("seatTypes is empty. Try false.");
                return false;
            }

            for (int i = 0; i< seatTypes.Count; i++)
            {
                int seatType = seatTypes[i];

                if (!ValueChecker.IsIntValid(seatType))
                {
                    DebugLogger.LogWithStackTrace($"seatType {i} invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }
    }
}
