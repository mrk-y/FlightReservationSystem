using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Aircraft
{
    internal class AircraftRecord
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string BaseName { get; set; }
        public int ModelID { get; set; }
        public int AirlineID { get; set; }
        public int AirportID { get; set; }
        public List<SeatAssignRecord> SeatAssignments { get; set; } = new List<SeatAssignRecord>();
        public int Status { get; set; }


        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try ffalse.");
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

        public static bool BaseName_Try(string baseName)
        {
            if (!ValueChecker.IsStringValid(baseName, nameof(baseName)))
            {
                DebugLogger.LogWithStackTrace("baseName invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool ModelID_Try(int modelID)
        {
            if (!ValueChecker.IsIntValid(modelID, nameof(modelID)))
            {
                DebugLogger.LogWithStackTrace("modelID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool AirlineID_Try(int airlineID)
        {
            if (!ValueChecker.IsIntValid(airlineID, nameof(airlineID)))
            {
                DebugLogger.LogWithStackTrace("airlineID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool AirportID_Try(int airportID)
        {
            if (!ValueChecker.IsIntValid(airportID, nameof(airportID)))
            {
                DebugLogger.LogWithStackTrace("airportID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool SeatAssignments_Try(List<SeatAssignRecord> seatAssignments)
        {
            if (seatAssignments == null)
            {
                DebugLogger.LogWithStackTrace("seatAssignments is null. Try false.");
                return false;
            }

            if (seatAssignments.Count == 0)
            {
                DebugLogger.LogWithStackTrace("seatAssignments is empty. Try false.");
                return false;
            }

            for (int i = 0; i < seatAssignments.Count; i++)
            {
                var seatAssignment = seatAssignments[i];

                if (seatAssignment == null)
                {
                    DebugLogger.LogWithStackTrace($"seatAssignment {i} is null. Try false.");
                    return false;
                }

                string code = seatAssignment.Code;
                List<int> types = seatAssignment.Types;

                if (!SeatAssignRecord.Code_Try(code) || !SeatAssignRecord.Types_Try(types))
                {
                    DebugLogger.LogWithStackTrace($"seatAssignment {i} invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }

        public static bool Status_Try (int status)
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
