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
            if (!ErrorUIRegistry.Has) {
                DebugLogger.Log("[Dev] ErrorUIRegistry is empty. Nothing to clear.");
            }

            var errorUIs = ErrorUIRegistry.Get;

            for (int i = 0; i < ErrorUIRegistry.Count; i++)
            {
                var errorUI = errorUIs[i];

                if (errorUI == null)
                {
                    DebugLogger.Log("[Dev] Encountered null ErrorUI entry. Clearing aborted.");
                    return;
                }

                ErrorProvider provider = errorUI.Provider;

                if (provider == null)
                {
                    DebugLogger.Log("[Dev] ErrorProvider is null. Clearing aborted.");
                    return;
                }

                provider.Clear();
            }
        }

        public static void ClearCurrentTextBoxFields()
        {
            if (!ErrorUIRegistry.Has)
            {
                DebugLogger.Log("[Dev] ErrorUIRegistry is empty. Nothing to clear.");
                return;
            }

            var errorUIs = ErrorUIRegistry.Get;
  
            for (int i = 0; i < ErrorUIRegistry.Count; i++)
            {
                var errorUI = errorUIs[i];

                if (errorUI == null)
                {
                    DebugLogger.Log("[Dev] Encountered null ErrorUI entry. Clearing aborted.");
                    return;
                }

                Control field = errorUI.Field;

                if (field == null)
                {
                    DebugLogger.Log("[Dev] ErrorUI field control is null. Clearing aborted.");
                    return;
                }

                if (field is TextBox tb)
                {
                    tb.Clear();
                }
            }
        }

        public static void ClearCurrentSpecificField(string fieldName)
        {
            if (fieldName == null)
            {
                DebugLogger.Log("[Dev] Parameter fieldName is null. Operation aborted.");
                return;
            }

            if (!ErrorUIRegistry.Has)
            {
                DebugLogger.Log("[Dev] ErrorUIRegistry is empty. Nothing to clear.");
                return;
            }
            
            var errorUIs = ErrorUIRegistry.Get;

            for (int i = 0; i < ErrorUIRegistry.Count; i++)
            {
                var errorUI = errorUIs[i];

                if (errorUI == null)
                {
                    DebugLogger.Log("[Dev] Encountered null ErrorUI entry. Clearing aborted.");
                    return;
                }

                Control field = errorUI.Field;

                if (field == null)
                {
                    DebugLogger.Log("[Dev] ErrorUI field control is null. Clearing aborted.");
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
