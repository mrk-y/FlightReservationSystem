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
        public static void Add(ErrorRecord errorRecord) 
        {
            if (errorRecord == null)
            {
                DebugLogger.Log("[Dev] Parameter ErrorRecord (errorRecord) is null. Adding aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(errorRecord.Message))
            {
                DebugLogger.Log("[Dev] Message is null or whitespace from parameter ErrorRecord (errorRecord). Adding aborted.");
                return;
            }

            var associatedControls = errorRecord.AssociatedControls;

            if (associatedControls == null)
            {
                DebugLogger.Log("[Dev] AssociatedControls is null from parameter ErrorRecord (errorRecord). Adding aborted.");
                return;
            }

            if (associatedControls.Count == 0)
            {
                DebugLogger.Log("[Dev] AssociatedControls is empty from parameter ErrorRecord (errorRecord). Adding aborted.");
                return;
            }

            for (int i = 0; i < associatedControls.Count; i++)
            {   
                if (associatedControls[i] == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null Control (0) entry at index {i} of AssociatedControls from parameter ErrorRecord (errorRecord). Adding aborted.");
                    return;
                } 
            }

            ErrorCollection.Add(errorRecord);
        }

        public static void Alert(List<ErrorRecord> errorRecord = null)
        {
            MessageBoxHelper.ShowErrorMessage(ListMessageFormatter.ErrorListMessage(errorRecord));
        }

        public static void Highlight(bool individual, string errorMessage = null)
        {
            if (!individual && string.IsNullOrWhiteSpace(errorMessage))
            {
                DebugLogger.Log("[Dev] Parameter bool (individual) is false and parameter string (errorMessage) is null or whitespace. Highlighting aborted.");
                return;
            }
            else if (individual && !string.IsNullOrWhiteSpace(errorMessage))
            {
                DebugLogger.Log("[Dev] Parameter bool (individual) is true and string (errorMessage) is not null or whitespace. Highlighting aborted.");
                return;
            }

            if (individual) ErrorUIHelper.HighlightIndividual();
            else ErrorUIHelper.HighlightGlobal(errorMessage);
        }
    }
}
