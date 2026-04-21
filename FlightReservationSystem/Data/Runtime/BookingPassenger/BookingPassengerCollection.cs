using FlightReservationSystem.Data.Runtime.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.BookingPassenger
{
    internal class BookingPassengerCollection
    {
        private static readonly List<BookingPassengerRecord> _bookingPassengerRecordList = new List<BookingPassengerRecord>();
        private static readonly Dictionary<DateTime, List<BookingPassengerRecord>> _bookingPassengerDailyDict = new Dictionary<DateTime, List<BookingPassengerRecord>>();
        private static readonly Dictionary<(int Year, int Month), List<BookingPassengerRecord>> _bookingPassengerMonthlyDict = new Dictionary<(int Year, int Month), List<BookingPassengerRecord>>();

        public static void Add(BookingPassengerRecord bookingPassengerRecord)
        {
            _bookingPassengerRecordList.Add(bookingPassengerRecord);

            var monthKey = (bookingPassengerRecord.AddedAt.Year, bookingPassengerRecord.AddedAt.Month);
            if (!_bookingPassengerMonthlyDict.ContainsKey(monthKey))
                _bookingPassengerMonthlyDict[monthKey] = new List<BookingPassengerRecord>();
            _bookingPassengerMonthlyDict[monthKey].Add(bookingPassengerRecord);

            var dayKey = bookingPassengerRecord.AddedAt.Date;
            if (!_bookingPassengerDailyDict.ContainsKey(dayKey))
                _bookingPassengerDailyDict[dayKey] = new List<BookingPassengerRecord>();
            _bookingPassengerDailyDict[dayKey].Add(bookingPassengerRecord);
        }

        public static List<BookingPassengerRecord> Get => _bookingPassengerRecordList;
        public static Dictionary<(int Year, int Month), List<BookingPassengerRecord>> GetMonthly => _bookingPassengerMonthlyDict;
        public static Dictionary<DateTime, List<BookingPassengerRecord>> GetDaily => _bookingPassengerDailyDict;

        public static void Clear()
        {
            _bookingPassengerRecordList.Clear();
            _bookingPassengerMonthlyDict.Clear();
            _bookingPassengerDailyDict.Clear();
        }
    }
}