using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Airport
{
    internal class AirportRecord
    {
        public int ID { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string DisplayCity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    
    
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

        public static bool Name_Try(string name)
        {
            if (!ValueChecker.IsStringValid(name, nameof(name)))
            {
                DebugLogger.LogWithStackTrace("name invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Location_Try(string location)
        {
            if (!ValueChecker.IsStringValid(location, nameof(location)))
            {
                DebugLogger.LogWithStackTrace("location invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool DisplayCity_Try(string displayCity)
        {
            if (!ValueChecker.IsStringValid(displayCity, nameof(displayCity)))
            {
                DebugLogger.LogWithStackTrace("displayCity invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Latitude_Try(double latitude)
        {
            if (!ValueChecker.IsDoubleValid(latitude, nameof(latitude)))
            {
                DebugLogger.LogWithStackTrace("latitude invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Longitude_Try(double longitude)
        {
            if (!ValueChecker.IsDoubleValid(longitude, nameof(longitude)))
            {
                DebugLogger.LogWithStackTrace("longitude invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
