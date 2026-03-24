using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.AircraftModel
{
    internal class SeatLayoutRecord
    {
        public string ClassName { get; set; }
        [JsonPropertyName("Count")]
        public int SeatCount { get; set; }
        public string Arrangement { get; set; }
    }
}
