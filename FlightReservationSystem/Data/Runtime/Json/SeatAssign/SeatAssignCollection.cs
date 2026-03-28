using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Json.SeatAssign
{
    internal class SeatAssignCollection
    {
        private static readonly List<SeatAssignRecord> _seatAssignRecordList = new List<SeatAssignRecord>();


        public static void Add(SeatAssignRecord seatAssignRecord) => _seatAssignRecordList.Add(seatAssignRecord);

        public static List<SeatAssignRecord> Get => _seatAssignRecordList;

        public static void Clear() => _seatAssignRecordList.Clear();
    }
}
