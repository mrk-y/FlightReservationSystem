using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.SeatType
{
    internal class SeatTypeRecord
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }


        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Code_Try(string code)
        {
            if (!ValueChecker.IsStringValid(code, nameof(code)))
            {
                DebugLogger.LogWithStackTrace("code invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Name_Try(string name)
        {
            if (!ValueChecker.IsStringValid(name, nameof(name)))
            {
                DebugLogger.LogWithStackTrace("name invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
