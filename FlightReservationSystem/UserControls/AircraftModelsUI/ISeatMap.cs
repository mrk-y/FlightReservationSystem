using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;

namespace FlightReservationSystem.UserControls.AircraftModelsUI
{
    /// <summary>
    /// Implemented by every aircraft seat-map UserControl.
    /// </summary>
    public interface ISeatMap
    {
        /// <summary>
        /// Fired every time a passenger is successfully assigned to a seat.
        /// RAForm subscribes to this to know when all seats are filled so it
        /// can unlock the Payment navigation button.
        /// </summary>
        event Action OnSeatAssigned;

        /// <summary>
        /// Called for a NEW reservation. Enters interactive click-to-assign mode.
        /// Returns the live assignment dictionary (PassengerNumber → SeatLabel)
        /// that fills progressively as the agent clicks seats.
        /// </summary>
        Dictionary<int, string> LoadPassengers(List<RAPassengerDetails> passengers);

        /// <summary>
        /// Called when a flight already has saved bookings in the DB.
        /// Pre-colours those seats and wires click popups (read-only).
        /// </summary>
        void LoadSavedPassengers(List<SavedPassengerInfo> savedPassengers);
    }

    /// <summary>
    /// Lightweight DTO carrying DB-loaded passenger data to the seat map.
    /// </summary>
    public class SavedPassengerInfo
    {
        public int PassengerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SeatClass { get; set; }
        public string SeatLabel { get; set; }
        public bool HasPeanutAllergy { get; set; }
        public bool NeedsWheelchair { get; set; }
        public bool IsUnaccompaniedMinor { get; set; }
        public string ReferenceNo { get; set; }
        public string MiddleName { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}