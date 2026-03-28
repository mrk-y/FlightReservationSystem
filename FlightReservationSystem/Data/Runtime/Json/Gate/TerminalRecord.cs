using FlightReservationSystem.Data.Runtime.Json.Gate;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Terminal
{
    internal class TerminalRecord
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Classification { get; set; }
        public List<GateRecord> Gates { get; set; } = new List<GateRecord>();
        public int AirportID { get; set; }
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

        public static bool Number_Try(int number)
        {
            if (!ValueChecker.IsIntValid(number))
            {
                DebugLogger.LogWithStackTrace("number invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Classification_Try(string classification)
        {
            if (!ValueChecker.IsStringValid(classification))
            {
                DebugLogger.LogWithStackTrace("classification invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Gates_Try(List<GateRecord> gates)
        {
            if (gates == null)
            {
                DebugLogger.LogWithStackTrace("gates is null. Try false.");
                return false;
            }

            if (gates.Count == 0)
            {
                DebugLogger.LogWithStackTrace("gates is empty. Try false.");
                return false;
            }

            for (int i = 0; i < gates.Count; i++)
            {
                var gate = gates[i];

                if (gate == null)
                {
                    DebugLogger.LogWithStackTrace($"gate {i} is null. Try false.");
                    return false;
                }

                int id = gate.ID;
                string type = gate.Type;
                int aircraftID = gate.AircraftID;
                int status = gate.Status;

                if (!GateRecord.ID_Try(id) || !GateRecord.Type_Try(type) ||
                    !GateRecord.AircraftID_Try(aircraftID) || !GateRecord.Status_Try(status))
                {
                    DebugLogger.LogWithStackTrace($"gate {i} invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }

        public static bool AirportID_Try(int airportID)
        {
            if (!ValueChecker.IsIntValid(airportID))
            {
                DebugLogger.LogWithStackTrace("airportID invalid value. Try false.");
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
