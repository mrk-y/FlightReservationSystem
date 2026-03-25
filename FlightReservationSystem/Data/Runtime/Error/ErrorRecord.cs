using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorRecord
    {
        public string Message { get; set; }
        public List<Control> AssociatedControls { get; set; } = new List<Control>();


        public static bool Message_Try(string message)
        {
            if (!ValueChecker.IsStringValid(message, nameof(message)))
            {
                DebugLogger.LogWithStackTrace("message invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool AssociatedControls_Try(List<Control> associatedControls)
        {
            if (associatedControls == null)
            {
                DebugLogger.LogWithStackTrace("associatedControls is null. Try false.");
                return false;
            }

            if (associatedControls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("associatedControls is empty. Try false.");
                return false;
            }

            for (int i = 0; i < associatedControls.Count; i++)
            {
                var associatedControl = associatedControls[i];

                if (associatedControl == null)
                {
                    DebugLogger.LogWithStackTrace($"associatedControl {i} is null. Try false.");
                    return false;
                }
            }

            return true;
        }
    }
}
