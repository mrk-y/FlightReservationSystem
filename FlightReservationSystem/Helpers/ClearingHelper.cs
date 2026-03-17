using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class ClearingHelper
    {
        public static void ClearCurrentProviders()
        {
            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0) {
                DebugLogger.Log("[Dev] ErrorUICollection is empty. Clearing aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null ErrorUIRecord entry at index {i} of ErrorUICollection. Clearing aborted.");
                    return;
                }

                ErrorProvider provider = errorUIRecord.Provider;

                if (provider == null)
                {
                    DebugLogger.Log($"[Dev] Provider is null from ErrorUIRecord entry at index {i} of ErrorUICollection. Clearing aborted.");
                    return;
                }

                provider.Clear();
            }
        }

        public static void ClearCurrentTextBoxFields()
        {
            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.Log("[Dev] ErrorUICollection is empty. Clearing aborted.");
                return;
            }
  
            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null ErrorUIRecord entry at index {i} of ErrorUICollection. Clearing aborted.");
                    return;
                }

                Control field = errorUIRecord.Field;

                if (field == null)
                {
                    DebugLogger.Log($"[Dev] Field is null from ErrorUIRecord entry at index {i} of ErrorUICollection. Clearing aborted.");
                    return;
                }

                if (field is TextBox tb) tb.Clear();
            }
        }

        public static void ClearCurrentSpecificField(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                DebugLogger.Log("[Dev] Parameter string (fieldName) is null or whitespace. Clearing aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.Log("[Dev] ErrorUICollection is empty. Clearing aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null ErrorUIRecord entry at index {i} of ErrorUICollection. Clearing aborted.");
                    return;
                }

                Control field = errorUIRecord.Field;

                if (field == null)
                {
                    DebugLogger.Log($"[Dev] Field is null from ErrorUIRecord entry at index {i} of ErrorUICollection. Clearing aborted.");
                    return;
                }

                if (field.Name == fieldName)
                {
                    if (field is TextBox tb) tb.Clear();
                    else if (field is ComboBox cb) cb.Items.Clear();
                }
            }
        }
    }
}
