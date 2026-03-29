using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Data.Runtime.Aircraft
{
    internal class AircraftCollection
    {
        private static readonly List<AircraftRecord> _aircraftRecordList = new List<AircraftRecord>();


        public static void Add(AircraftRecord aircraftRecord) => _aircraftRecordList.Add(aircraftRecord);

        public static List<AircraftRecord> Get => _aircraftRecordList;

        public static void Clear() => _aircraftRecordList.Clear();
    }
}
