using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Airline
{
    internal class AirlineCollection
    {
        private static readonly List<AirlineRecord> _airlineRecordList = new List<AirlineRecord>();


        public static void Add(AirlineRecord airlineRecord) => _airlineRecordList.Add(airlineRecord);

        public static List<AirlineRecord> Get => _airlineRecordList;

        public static void Clear() => _airlineRecordList.Clear();
    }
}
