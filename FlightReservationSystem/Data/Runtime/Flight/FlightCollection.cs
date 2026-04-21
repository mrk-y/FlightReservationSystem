using FlightReservationSystem.Data.Runtime.Booking;
using FlightReservationSystem.Data.Runtime.BookingPassenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Flight
{
    internal class FlightCollection
    {
        private static readonly List<FlightRecord> _flightRecordList = new List<FlightRecord>();
        private static readonly Dictionary<DateTime, List<FlightRecord>> _flightDailyDict = new Dictionary<DateTime, List<FlightRecord>>();
        private static readonly Dictionary<(int Year, int Month), List<FlightRecord>> _flightMonthlyDict = new Dictionary<(int Year, int Month), List<FlightRecord>>();

        public static void Add(FlightRecord flightRecord)
        {
            _flightRecordList.Add(flightRecord);

            var monthKey = (flightRecord.AddedAt.Year, flightRecord.AddedAt.Month);
            if (!_flightMonthlyDict.ContainsKey(monthKey))
                _flightMonthlyDict[monthKey] = new List<FlightRecord>();
            _flightMonthlyDict[monthKey].Add(flightRecord);

            var dayKey = flightRecord.AddedAt.Date;
            if (!_flightDailyDict.ContainsKey(dayKey))
                _flightDailyDict[dayKey] = new List<FlightRecord>();
            _flightDailyDict[dayKey].Add(flightRecord);
        }

        public static List<FlightRecord> Get => _flightRecordList;
        public static Dictionary<(int Year, int Month), List<FlightRecord>> GetMonthly => _flightMonthlyDict;
        public static Dictionary<DateTime, List<FlightRecord>> GetDaily => _flightDailyDict;

        public static void Clear()
        {
            _flightRecordList.Clear();
            _flightMonthlyDict.Clear();
            _flightDailyDict.Clear();
        }
    }
}