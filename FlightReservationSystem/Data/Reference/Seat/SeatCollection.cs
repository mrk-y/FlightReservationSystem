using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Seat
{
    internal class SeatCollection
    {
        private static readonly List<SeatRecord> _seatRecordList = new List<SeatRecord>();
        

        public static void Add(SeatRecord seatRecord) => _seatRecordList.Add(seatRecord);

        public static List<SeatRecord> Get => _seatRecordList;
        
        public static void Clear() => _seatRecordList.Clear();
    }
}
