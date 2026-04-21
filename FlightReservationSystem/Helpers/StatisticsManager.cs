using FlightReservationSystem.Data.Runtime.Booking;
using FlightReservationSystem.Data.Runtime.BookingPassenger;
using FlightReservationSystem.Data.Runtime.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class StatisticsManager
    {
        public static void AddBooking(BookingRecord bookingRecord) => BookingCollection.Add(bookingRecord);
        public static void AddBookingPassenger(BookingPassengerRecord bookingPassengerRecord) => BookingPassengerCollection.Add(bookingPassengerRecord);
        public static void AddFlight(FlightRecord flightRecord) => FlightCollection.Add(flightRecord);

        public static List<BookingRecord> GetBookingCollection => BookingCollection.Get;
        public static Dictionary<(int Year, int Month), List<BookingRecord>> GetBookingMonthlyCollection => BookingCollection.GetMonthly;
        public static Dictionary<DateTime, List<BookingRecord>> GetBookingDailyCollection => BookingCollection.GetDaily;
        public static List<BookingPassengerRecord> GetBookingPassengerCollection => BookingPassengerCollection.Get;
        public static Dictionary<(int Year, int Month), List<BookingPassengerRecord>> GetBookingPassengerMonthlyCollection => BookingPassengerCollection.GetMonthly;
        public static Dictionary<DateTime, List<BookingPassengerRecord>> GetBookingPassengerDailyCollection => BookingPassengerCollection.GetDaily;
        public static List<FlightRecord> GetFlightCollection => FlightCollection.Get;
        public static Dictionary<(int Year, int Month), List<FlightRecord>> GetFlightMonthlyCollection => FlightCollection.GetMonthly;
        public static Dictionary<DateTime, List<FlightRecord>> GetFlightDailyCollection => FlightCollection.GetDaily;

        public static void ClearBookingCollection() => BookingCollection.Clear();
        public static void ClearBookingPassengerCollection() => BookingPassengerCollection.Clear();
        public static void ClearFlightCollection() => FlightCollection.Clear();
    }
}
