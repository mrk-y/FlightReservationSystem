using FlightReservationSystem.UserControls.Reservation_Agent;
using System.Drawing;

namespace FlightReservationSystem.Helpers
{
    /// <summary>
    /// Maps passenger special-request flags → UI seat colours and type codes.
    /// Mirrors the legend shown on the seat map.
    /// </summary>
    public static class PassengerSeatInfo
    {
        public static Color GetBackColor(RAPassengerDetails p)
        {
            if (p.IsUnaccompaniedMinor) return Color.FromArgb(255, 243, 205); // amber-ish
            if (p.NeedsWheelchair) return Color.FromArgb(209, 231, 255); // blue-ish
            if (p.HasPeanutAllergy) return Color.FromArgb(255, 218, 218); // red-ish
            return Color.FromArgb(198, 239, 206);                              // green – REG
        }

        public static Color GetBorderColor(RAPassengerDetails p)
        {
            if (p.IsUnaccompaniedMinor) return Color.FromArgb(255, 193, 7);
            if (p.NeedsWheelchair) return Color.FromArgb(13, 110, 253);
            if (p.HasPeanutAllergy) return Color.FromArgb(220, 53, 69);
            return Color.FromArgb(70, 170, 90);
        }

        public static string GetCode(RAPassengerDetails p)
        {
            if (p.IsUnaccompaniedMinor) return "UMNR";
            if (p.NeedsWheelchair) return "WCHR";
            if (p.HasPeanutAllergy) return "NUT";
            return "REG";
        }

        // ── Saved-passenger overloads (uses SavedPassengerInfo DTO) ──

        public static Color GetBackColor(UserControls.AircraftModelsUI.SavedPassengerInfo p)
        {
            if (p.IsUnaccompaniedMinor) return Color.FromArgb(255, 243, 205);
            if (p.NeedsWheelchair) return Color.FromArgb(209, 231, 255);
            if (p.HasPeanutAllergy) return Color.FromArgb(255, 218, 218);
            return Color.FromArgb(198, 239, 206);
        }

        public static Color GetBorderColor(UserControls.AircraftModelsUI.SavedPassengerInfo p)
        {
            if (p.IsUnaccompaniedMinor) return Color.FromArgb(255, 193, 7);
            if (p.NeedsWheelchair) return Color.FromArgb(13, 110, 253);
            if (p.HasPeanutAllergy) return Color.FromArgb(220, 53, 69);
            return Color.FromArgb(70, 170, 90);
        }

        public static string GetCode(UserControls.AircraftModelsUI.SavedPassengerInfo p)
        {
            if (p.IsUnaccompaniedMinor) return "UMNR";
            if (p.NeedsWheelchair) return "WCHR";
            if (p.HasPeanutAllergy) return "NUT";
            return "REG";
        }
    }
}