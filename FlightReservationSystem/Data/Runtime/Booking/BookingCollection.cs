using FlightReservationSystem.Data.Runtime.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Booking
{
    internal class BookingCollection
    {
        private static readonly List<BookingRecord> _bookingRecordList = new List<BookingRecord>();
        private static readonly Dictionary<DateTime, List<BookingRecord>> _bookingRecordDailyDict = new Dictionary<DateTime, List<BookingRecord>>();
        private static readonly Dictionary<(int Year, int Month), List<BookingRecord>> _bookingRecordMonthlyDict = new Dictionary<(int Year, int Month), List<BookingRecord>>();

        public static void Add(BookingRecord bookingRecord)
        {
            _bookingRecordList.Add(bookingRecord);

            var monthKey = (bookingRecord.AddedAt.Year, bookingRecord.AddedAt.Month);
            if (!_bookingRecordMonthlyDict.ContainsKey(monthKey))
                _bookingRecordMonthlyDict[monthKey] = new List<BookingRecord>();
            _bookingRecordMonthlyDict[monthKey].Add(bookingRecord);

            var dayKey = bookingRecord.AddedAt.Date;
            if (!_bookingRecordDailyDict.ContainsKey(dayKey))
                _bookingRecordDailyDict[dayKey] = new List<BookingRecord>();
            _bookingRecordDailyDict[dayKey].Add(bookingRecord);
        }

        public static List<BookingRecord> Get => _bookingRecordList;
        public static Dictionary<(int Year, int Month), List<BookingRecord>> GetMonthly => _bookingRecordMonthlyDict;
        public static Dictionary<DateTime, List<BookingRecord>> GetDaily => _bookingRecordDailyDict;

        public static void Clear()
        {
            _bookingRecordList.Clear();
            _bookingRecordMonthlyDict.Clear();
            _bookingRecordDailyDict.Clear();
        }
    }
}