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
        public int Speed { get; set; }

        
        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Model_Try(string model)
        {
            if (!ValueChecker.IsStringValid(model, nameof(model)))
            {
                DebugLogger.LogWithStackTrace("model invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool TotalSeats_Try(int totalSeats)
        {
            if (!ValueChecker.IsIntValid(totalSeats, nameof(totalSeats)))
            {
                DebugLogger.LogWithStackTrace("totalSeats invalid value. Try false.");
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
                int seatCount = seatLayoutRecord.SeatCount;
                string arrangement = seatLayoutRecord.Arrangement;

                if (!SeatLayoutRecord.ClassName_Try(className) || !SeatLayoutRecord.SeatCount_Try(seatCount) ||
                    !SeatLayoutRecord.Arrangement_Try(arrangement))
                {
                    DebugLogger.LogWithStackTrace($"seatLayoutRecord {i} invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }

        public static bool Speed_Try(int speed)
        {
            if (!ValueChecker.IsIntValid(speed))
            {
                DebugLogger.LogWithStackTrace("speed invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
