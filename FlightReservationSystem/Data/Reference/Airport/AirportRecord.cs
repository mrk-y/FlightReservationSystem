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
        public string AirportName { get; set; }
        public string Location { get; set; }
        public string DisplayCity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Category { get; set; }
        public string CriticalAircraft { get; set; } 
    
    
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

        public static bool AirportName_Try(string airportName)
        {
            if (string.IsNullOrWhiteSpace(airportName))
            {
                DebugLogger.LogWithStackTrace("airportName is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(airportName))
            {
                DebugLogger.LogWithStackTrace("airportName starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool Location_Try(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                DebugLogger.LogWithStackTrace("location is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(location))
            {
                DebugLogger.LogWithStackTrace("location starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool DisplayCity_Try(string displayCity)
        {
            if (string.IsNullOrWhiteSpace(displayCity))
            {
                DebugLogger.LogWithStackTrace("displayCity is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(displayCity))
            {
                DebugLogger.LogWithStackTrace("displayCity starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool Latitude_Try(double latitude)
        {
            if (double.IsNaN(latitude))
            {
                DebugLogger.LogWithStackTrace("latitude is NaN. Try false.");
                return false;
            }

            if (latitude == 0)
            {
                DebugLogger.LogWithStackTrace("latitude is 0. Try false.");
                return false;
            }

            return true;
        }

        public static bool Longitude_Try(double longitude)
        {
            if (double.IsNaN(longitude))
            {
                DebugLogger.LogWithStackTrace("longitude is NaN. Try false.");
                return false;
            }

            if (longitude == 0)
            {
                DebugLogger.LogWithStackTrace("longitude is 0. Try false.");
                return false;
            }

            return true;
        }

        public static bool Category_Try(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                DebugLogger.LogWithStackTrace("category is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(category))
            {
                DebugLogger.LogWithStackTrace("category starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool CriticalAircraft_Try(string criticalAircraft)
        {
            if (string.IsNullOrWhiteSpace(criticalAircraft))
            {
                DebugLogger.LogWithStackTrace("criticalAircraft is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(criticalAircraft))
            {
                DebugLogger.LogWithStackTrace("criticalAircraft starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }
    }
}
