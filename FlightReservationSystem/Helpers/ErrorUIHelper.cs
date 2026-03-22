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
                DebugLogger.LogWithStackTrace("errorCollection is empty. Highlighting aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Highlighting aborted.");
                return;
            }

            if (errorUICollection.Count < errorCollection.Sum(record => record.AssociatedControls.Count))
            {
                DebugLogger.LogWithStackTrace("errorUICollection entries is fewer than sum of all associatedControls. Highlighting aborted.");
                return;
            }

            int k = 0;

            for (int i = 0; i < errorCollection.Count; i++)
            {
                var errorRecord = errorCollection[i];

                if (errorRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorRecord {i} is null. Highlighting aborted.");
                    return;
                }

                string message = errorRecord.Message;

                if (string.IsNullOrWhiteSpace(message))
                {
                    DebugLogger.LogWithStackTrace($"message {i} is null or whitespace. Highlighting aborted.");
                    return;
                }

                if (ValueChecker.HasSpaceStartEnd(message))
                {
                    DebugLogger.LogWithStackTrace($"message {i} starts or ends with space. Highlighting aborted.");
                    return;
                }

                var associatedControls = errorRecord.AssociatedControls;

                if (associatedControls == null)
                {
                    DebugLogger.LogWithStackTrace($"associatedControls {i} is null. Highlighting aborted.");
                    return;
                }

                if (associatedControls.Count == 0)
                {
                    DebugLogger.LogWithStackTrace($"associatedControls {i} is empty. Highlighting aborted.");
                    return;
                }

                for (int j = 0; j < associatedControls.Count; j++)
                {
                    var errorUIRecord = errorUICollection[k];

                    if (errorUIRecord == null)
                    {
                        DebugLogger.LogWithStackTrace($"errorUIRecord {k} is null. Highlighting aborted.");
                        return;
                    }

                    ErrorProvider provider = errorUIRecord.Provider;

                    if (provider == null)
                    {
                        DebugLogger.LogWithStackTrace($"provider {k} is null. Highlighting aborted.");
                        return;
                    }

                    Control associatedControl = associatedControls[j];

                    if (associatedControl == null)
                    {
                        DebugLogger.LogWithStackTrace($"associatedControl {j} is null associatedControls {i}. Highlighting aborted.");
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
                DebugLogger.LogWithStackTrace("errorMessage is null or whitespace. Highlighting aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(errorMessage))
            {
                DebugLogger.LogWithStackTrace("errorMessage starts or ends with space. Highlighting aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Highlighting aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorUIRecord {i} is null. Highlighting aborted.");
                    return;
                }

                ErrorProvider provider = errorUIRecord.Provider;

                if (provider == null)
                {
                    DebugLogger.LogWithStackTrace($"provider {i} is null. Highlighting aborted.");
                    return;
                }

                Control target = errorUIRecord.Target;

                if (target == null)
                {
                    DebugLogger.LogWithStackTrace($"target {i} is null. Highlighting aborted.");
                    return;
                }

                provider.SetError(target, errorMessage);
            }
        }
    }
}

