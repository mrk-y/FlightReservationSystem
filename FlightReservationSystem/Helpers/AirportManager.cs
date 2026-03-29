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
                !AirportRecord.ICAO_Try(airportRecord.ICAO) || !AirportRecord.Name_Try(airportRecord.Name) ||
                !AirportRecord.Location_Try(airportRecord.Location) || !AirportRecord.DisplayCity_Try(airportRecord.DisplayCity) ||
                !AirportRecord.Latitude_Try(airportRecord.Latitude) || !AirportRecord.Longitude_Try(airportRecord.Longitude))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            AirportCollection.Add(airportRecord);
        }

        public static List<AirportRecord> GetAirportCollection => AirportCollection.Get;
    }
}
