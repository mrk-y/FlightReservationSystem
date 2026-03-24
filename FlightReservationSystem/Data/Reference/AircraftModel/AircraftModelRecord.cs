using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.AircraftModel
{
    internal class AircraftModelRecord
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        public List<SeatLayoutRecord> SeatLayoutCollection { get; set; } = new List<SeatLayoutRecord>();

        
        public static bool ID_Try(int id)
        {
            if (id == 0)
            {
                DebugLogger.LogWithStackTrace("id is 0. Try false.");
                return false;
            }

            return true;
        }

        public static bool Model_Try(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                DebugLogger.LogWithStackTrace("model is null or whitespace. Try false");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(model))
            {
                DebugLogger.LogWithStackTrace("model starts or ends with whitespace. Try false");
                return false;
            }

            return true;
        }

        public static bool TotalSeats_Try(int totalSeats)
        {
            if (totalSeats == 0)
            {
                DebugLogger.LogWithStackTrace("totalSeats is 0. Try false");
                return false;
            }

            return true;
        }
    
        public static bool SeatLayoutCollection_Try(List<SeatLayoutRecord> seatLayoutCollection)
        {   
            if (seatLayoutCollection == null)
            {
                DebugLogger.LogWithStackTrace("seatLayoutCollection is null. Try false");
                return false;
            }

            if (seatLayoutCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("seatLayoutCollection is empty. Try false.");
                return false;
            }

            for (int i = 0; i < seatLayoutCollection.Count; i++)
            {
                var seatLayoutRecord = seatLayoutCollection[i];

                if (seatLayoutRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"seatLayoutRecord {i} is null. Try false.");
                    return false;
                }

                string className = seatLayoutRecord.ClassName;

                if (string.IsNullOrWhiteSpace(className))
                {
                    DebugLogger.LogWithStackTrace($"className {i} is null or whitespace. Try false.");
                    return false;
                }

                if (ValueChecker.HasStartEndSpace(className))
                {
                    DebugLogger.LogWithStackTrace($"className {i} starts or ends with whitespace. Try false.");
                    return false;
                }

                if (seatLayoutRecord.SeatCount == 0)
                {
                    DebugLogger.LogWithStackTrace($"seatLayoutRecord.SeatCount {i} is 0. Try false.");
                    return false;
                }

                string arrangement = seatLayoutRecord.Arrangement;

                if (string.IsNullOrWhiteSpace(arrangement))
                {
                    DebugLogger.LogWithStackTrace($"arrangement {i} is null or whitespace. Try false");
                    return false;
                }

                if (ValueChecker.HasStartEndSpace(arrangement))
                {
                    DebugLogger.LogWithStackTrace($"arrangement {i} starts or ends with whitespace. Try false.");
                    return false;
                }
            }

            return true;
        }
    }
}
