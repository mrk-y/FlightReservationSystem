using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Seat
{
    internal class SeatTypeCollection
    {
        private static readonly List<SeatTypeRecord> _seatRecordList = new List<SeatTypeRecord>();
        

        public static void Add(SeatTypeRecord seatRecord) => _seatRecordList.Add(seatRecord);

        public static List<SeatTypeRecord> Get => _seatRecordList;
        
        public static void Clear() => _seatRecordList.Clear();
    }
}
