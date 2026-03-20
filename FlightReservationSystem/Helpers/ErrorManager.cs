using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class ErrorManager
    {
        public static void Add(ErrorRecord errorRecord) 
        {
            if (errorRecord == null)
            {
                DebugLogger.LogWithStackTrace("errorRecord is null. Adding aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(errorRecord.Message))
            {
                DebugLogger.LogWithStackTrace("errorRecord.Message is null or whitespace. Adding aborted.");
                return;
            }

            var associatedControls = errorRecord.AssociatedControls;

            if (associatedControls == null)
            {
                DebugLogger.LogWithStackTrace("associatedControls is null. Adding aborted.");
                return;
            }

            if (associatedControls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("associatedControls is empty. Adding aborted.");
                return;
            }

            for (int i = 0; i < associatedControls.Count; i++)
            {
                if (associatedControls[i] == null)
                {
                    DebugLogger.LogWithStackTrace($"associatedControls[{i}] is null. Adding aborted.");
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
                DebugLogger.LogWithStackTrace("individual is false and errorMessage is null or whitespace. Highlighting aborted.");
                return;
            }
            else if (individual && !string.IsNullOrWhiteSpace(errorMessage))
            {
                DebugLogger.LogWithStackTrace("individual is true and errorMessage is not null or whitespace. Highlighting aborted.");
                return;
            }

            if (individual) ErrorUIHelper.HighlightIndividual();
            else ErrorUIHelper.HighlightGlobal(errorMessage);
        }
    }
}
