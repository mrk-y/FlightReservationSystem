using FlightReservationSystem.Data.Reference.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Flight
{
    internal class FlightRecord
    {
        public int ID { get; set; }
        public string Aircraft { get; set; }
        public string Airline { get; set; }
        public DateTime Departure {  get; set; }
        public DateTime Arrival { get; set; }
        public int DistanceKM { get; set; }
        public int DurationMin { get; set; }
        public int OriginID { get; set; }
        public int DestinationID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
