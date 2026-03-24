using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.AircraftModel
{
    internal class AircraftModelCollection
    {
        private static readonly List<AircraftModelRecord> _aircraftModelRecordList = new List<AircraftModelRecord>();
        

        public static void Add(AircraftModelRecord aircraftModelRecord) => _aircraftModelRecordList.Add(aircraftModelRecord);

        public static List<AircraftModelRecord> Get => _aircraftModelRecordList;

        public static void Clear() => _aircraftModelRecordList.Clear();
    }
}
