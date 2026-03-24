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
        public string AirlineName {  get; set; }


        public static bool ID_Try(int id)
        {
            if (id == 0)
            {
                DebugLogger.LogWithStackTrace("id is 0. Try false.");
                return false;
            }

            return true;
        }

        public static bool IATA_Try(string iata)
        {
            if (string.IsNullOrWhiteSpace(iata))
            {
                DebugLogger.LogWithStackTrace("iata is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(iata))
            {
                DebugLogger.LogWithStackTrace("iata starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool ICAO_Try(string icao)
        {
            if (string.IsNullOrWhiteSpace(icao))
            {
                DebugLogger.LogWithStackTrace("icao is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(icao))
            {
                DebugLogger.LogWithStackTrace("icao starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool Callsign_Try(string callsign)
        {
            if (string.IsNullOrEmpty(callsign))
            {
                DebugLogger.LogWithStackTrace("callsign is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(callsign))
            {
                DebugLogger.LogWithStackTrace("callsign starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        } 

        public static bool AirlineName_Try(string airlineName)
        {
            if (string.IsNullOrWhiteSpace(airlineName))
            {
                DebugLogger.LogWithStackTrace("airlineName is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(airlineName))
            {
                DebugLogger.LogWithStackTrace("airlineName starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }
    }
}
