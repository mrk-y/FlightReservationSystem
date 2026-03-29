using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class AirlineManager
    {
        public static void AddAirline(AirlineRecord airlineRecord)
        {
            if (!AirlineRecord.ID_Try(airlineRecord.ID) || !AirlineRecord.IATA_Try(airlineRecord.IATA) ||
                !AirlineRecord.ICAO_Try(airlineRecord.ICAO) || !AirlineRecord.Callsign_Try(airlineRecord.Callsign) ||
                !AirlineRecord.Name_Try(airlineRecord.Name))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            AirlineCollection.Add(airlineRecord);
        }

        public static List<AirlineRecord> GetAirlineCollection => AirlineCollection.Get;

        public static Image AirlineToImage(string resourceName)
        {
            object resc = Properties.Resources.ResourceManager.GetObject(resourceName);

            if (resc != null && resc is Image img) return img;
            else
            {
                DebugLogger.LogWithStackTrace("resc is null. Image retrieval aborted.");
                return null;
            }
        }
    }
}
