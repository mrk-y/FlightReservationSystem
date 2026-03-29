using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Aircraft
{
    internal class SeatAssignRecord
    {
        public string Code { get; set; }
        public List<int> Types { get; set; } = new List<int>();

        
        public static bool Code_Try(string code)
        {
            if (!ValueChecker.IsStringValid(code, nameof(code)))
            {
                DebugLogger.LogWithStackTrace("code invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Types_Try(List<int> types)
        {
            if (types == null)
            {
                DebugLogger.LogWithStackTrace("types is null. Try false.");
                return false;
            }

            if (types.Count == 0)
            {
                DebugLogger.LogWithStackTrace("types is empty. Try false.");
                return false;
            }

            for (int i = 0; i< types.Count; i++)
            {
                int type = types[i];

                if (!ValueChecker.IsIntValid(type, nameof(type)))
                {
                    DebugLogger.LogWithStackTrace($"type {i} invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }
    }
}
