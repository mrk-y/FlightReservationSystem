using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class ErrorManager
    {
        public static void Add(ErrorEntry entry) 
        {
            if (entry == null)
            {
                DebugLogger.Log("[Dev] Parameter ErrorEntry is null. Add aborted.");
                return;
            }

            if (entry.Message == null)
            {
                DebugLogger.Log("[Dev] ErrorEntry.Message is null. Add aborted.");
                return;
            }

            if (entry.AssociatedControls == null)
            {
                DebugLogger.Log("[Dev] ErrorEntry.AssociatedControls is null. Add aborted.");
                return;
            }

            ErrorCollection.Add(entry);
        }

        public static void Alert(List<ErrorEntry> errorEntry = null)
        {
            MessageBoxHelper.ShowErrorMessage(ListMessageFormatter.ErrorListMessage(errorEntry));
        }

        public static void Highlight(bool individual, string errorMessage = null)
        {
            if (!individual && errorMessage == null)
            {
                DebugLogger.Log("[Dev] Parameter individual is false and errorMessage is null. Highlighting aborted.");
                return;
            }

            if (individual) ErrorUIHelper.HighlightIndividual();
            else ErrorUIHelper.HighlightGlobal(errorMessage);
        }
    }
}
