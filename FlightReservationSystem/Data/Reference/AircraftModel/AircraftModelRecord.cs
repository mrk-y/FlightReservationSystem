using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.AircraftModel
{
    internal class AircraftModelRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalSeats { get; set; }
        public int Speed { get; set; }
        public int FlightAttenantsCount { get; set; }

        
        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
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

        public static bool TotalSeats_Try(int totalSeats)
        {
            if (!ValueChecker.IsIntValid(totalSeats, nameof(totalSeats)))
            {
                DebugLogger.LogWithStackTrace("totalSeats invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Speed_Try(int speed)
        {
            if (!ValueChecker.IsIntValid(speed, nameof(speed)))
            {
                DebugLogger.LogWithStackTrace("speed invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool FlightAttenantsCount_Try(int flightAttenantsCount)
        {
            if (!ValueChecker.IsIntValid(flightAttenantsCount))
            {
                DebugLogger.LogWithStackTrace("flightAttenantsCount invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
