using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
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


        public static bool ClassName_Try(string className)
        {
            if (!ValueChecker.IsStringValid(className, nameof(className)))
            {
                DebugLogger.LogWithStackTrace("className invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool SeatCount_Try(int seatCount)
        {
            if (!ValueChecker.IsIntValid(seatCount, nameof(seatCount)))
            {
                DebugLogger.LogWithStackTrace("seatCount invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Arrangement_Try(string arrangement)
        {
            if (!ValueChecker.IsStringValid(arrangement, nameof(arrangement)))
            {
                DebugLogger.LogWithStackTrace("arrangement invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
