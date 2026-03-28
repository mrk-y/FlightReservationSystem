using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Json.Gate
{
    internal class GateRecord
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int AircraftID { get; set; }
        public int Status { get; set; }


        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Type_Try(string type)
        {
            if (!ValueChecker.IsStringValid(type))
            {
                DebugLogger.LogWithStackTrace("type invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool AircraftID_Try(int aircraftID)
        {
            if (!ValueChecker.IsIntValid(aircraftID))
            {
                DebugLogger.LogWithStackTrace("aircraftID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Status_Try(int status)
        {
            if (!ValueChecker.IsIntValid(status))
            {
                DebugLogger.LogWithStackTrace("status invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}

