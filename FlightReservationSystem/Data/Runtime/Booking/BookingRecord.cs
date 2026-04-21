using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Booking
{
    internal class BookingRecord
    {
        public int ID { get; set; }
        public int FlightID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BaseFare { get; set; }
        public decimal Tax {  get; set; }
        public decimal ServiceFee { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
