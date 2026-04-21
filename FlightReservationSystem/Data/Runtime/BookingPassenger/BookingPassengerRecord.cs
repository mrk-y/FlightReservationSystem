using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.BookingPassenger
{
    internal class BookingPassengerRecord
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SeatClass { get; set; }
        public string SeatLabel { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
