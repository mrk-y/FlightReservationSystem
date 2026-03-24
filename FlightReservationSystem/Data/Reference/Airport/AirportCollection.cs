using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Airport
{
    internal class AirportCollection
    {
        private static readonly List<AirportRecord> _airportRecordList = new List<AirportRecord>();


        public static void Add(AirportRecord airportRecord) => _airportRecordList.Add(airportRecord);

        public static List<AirportRecord> Get => _airportRecordList;

        public static void Clear() => _airportRecordList.Clear();

    }
}
