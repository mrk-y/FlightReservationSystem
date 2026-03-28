using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class AirportManager
    {
        public static void AddAirport(AirportRecord airportRecord)
        {
            if (!AirportRecord.ID_Try(airportRecord.ID) || !AirportRecord.IATA_Try(airportRecord.IATA) ||
                !AirportRecord.ICAO_Try(airportRecord.ICAO) || !AirportRecord.AirportName_Try(airportRecord.AirportName) ||
                !AirportRecord.Location_Try(airportRecord.Location) || !AirportRecord.DisplayCity_Try(airportRecord.DisplayCity) ||
                !AirportRecord.Latitude_Try(airportRecord.Latitude) || !AirportRecord.Longitude_Try(airportRecord.Longitude) ||
                !AirportRecord.Category_Try(airportRecord.Category) || !AirportRecord.CriticalAircraft_Try(airportRecord.CriticalAircraft))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            AirportCollection.Add(airportRecord);
        }

        public static List<AirportRecord> GetAirportCollection => AirportCollection.Get;
    }
}
