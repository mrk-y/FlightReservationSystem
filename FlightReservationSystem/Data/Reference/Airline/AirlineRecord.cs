using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Airline
{
    internal class AirlineRecord
    {
        public int ID {  get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public string Callsign { get; set; }
        public string Name {  get; set; }


        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool IATA_Try(string iata)
        {
            if (!ValueChecker.IsStringValid(iata, nameof(iata)))
            {
                DebugLogger.LogWithStackTrace("iata invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool ICAO_Try(string icao)
        {
            if (!ValueChecker.IsStringValid(icao, nameof(icao)))
            {
                DebugLogger.LogWithStackTrace("icao invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Callsign_Try(string callsign)
        {
            if (!ValueChecker.IsStringValid(callsign, nameof(callsign)))
            {
                DebugLogger.LogWithStackTrace("callsign invalid value. Try false.");
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
