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
    internal class ErrorUIHelper
    {
        // Real errors
        public static void HighlightIndividual()
        {
            var errorCollection = ErrorCollection.Get;

            if (errorCollection.Count == 0)
            {
                DebugLogger.Log("[Dev] ErrorCollection is empty. Highlighting aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;
            
            if (errorUICollection.Count == 0)
            {
                DebugLogger.Log("[Dev] ErrorUICollection is empty. Highlighting aborted.");
                return;
            }
            else if (errorUICollection.Count < errorCollection.Count) 
            {
                DebugLogger.Log("[Dev] Fewer ErrorUIRecord entries of ErrorUICollection than ErrorRecord entries of ErrorCollection. Highlighting aborted.");
                return;
            }

            int k = 0; // Counter for each error provider

            for (int i = 0; i < errorCollection.Count; i++)
            {
                var errorRecord = errorCollection[i];
                
                if (errorRecord == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null ErrorRecord entry at index {i} of ErrorCollection. Highlighting aborted.");
                    return;
                }
 
                string message = errorRecord.Message;

                if (string.IsNullOrWhiteSpace(message))
                {
                    DebugLogger.Log($"[Dev] Message is null or whitespace from ErrorRecord entry at index {i} of ErrorCollection. Highlighting aborted.");
                    return;
                }

                var associatedControls = errorRecord.AssociatedControls;

                if (associatedControls == null)
                {
                    DebugLogger.Log($"[Dev] AssociatedControls is null from ErrorRecord entry at index {i} of ErrorCollection. Highlighting aborted.");
                    return;
                }  

                if (associatedControls.Count == 0)
                {
                    DebugLogger.Log($"[Dev] AssociatedControls is empty from ErrorRecord entry at index {i} of ErrorCollection. Highlighting aborted.");
                    return;
                }

                for (int j = 0; j < associatedControls.Count; j++)
                {
                    var errorUIRecord = errorUICollection[k];

                    if (errorUIRecord == null)
                    {
                        DebugLogger.Log($"[Dev] Encountered null ErrorUIRecord entry at index {k} of ErrorUICollection. Highlighting aborted.");
                        return;
                    }

                    ErrorProvider provider = errorUIRecord.Provider;

                    if (provider == null)
                    {
                        DebugLogger.Log($"[Dev] Provider is null from ErrorUIRecord entry at index {k} of ErrorUICollection. Highlighting aborted.");
                        return;
                    }

                    Control associatedControl = associatedControls[j];

                    if (associatedControl == null)
                    { 
                        DebugLogger.Log($"[Dev] Encountered null Control (0) entry at index {j} of AssociatedControls from ErrorRecord entry at index {i} of ErrorCollection. Highlighting aborted.");
                        return;
                    }

                    k++;
                    provider.SetError(associatedControl, message);
                }
            }

            ErrorCollection.Clear();
        }

        // Self defined error
        public static void HighlightGlobal(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                DebugLogger.Log("[Dev] Parameter string (errorMessage) is null or whitespace. Highlighting aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.Log("[Dev] ErrorUICollection is empty. Highlighting aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];
                
                if (errorUIRecord == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null ErrorUIRecord entry at index {i} of ErrorUICollection. Highlighting aborted.");
                    return;
                }

                ErrorProvider provider = errorUIRecord.Provider;

                if (provider == null)
                {
                    DebugLogger.Log($"[Dev] Provider is null from ErrorUIRecord entry at index {i} of ErrorUICollection. Highlighting aborted.");
                    return;
                }

                Control target = errorUIRecord.Target;

                if (target == null)
                {
                    DebugLogger.Log($"[Dev] Target is null from ErrorUIRecord entry at index {i} of ErrorUICollection. Highlighting aborted.");
                    return;
                }

                provider.SetError(target, errorMessage);
            }
        }
    }
}

