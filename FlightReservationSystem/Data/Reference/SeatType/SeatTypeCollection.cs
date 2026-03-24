using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.SeatType
{
    internal class SeatTypeCollection
    {
        private static readonly List<SeatTypeRecord> _setTypeRecordList = new List<SeatTypeRecord>
        {
            new SeatTypeRecord { ID = 1, Type = "Regular Passenger"}
        };
    }
}
