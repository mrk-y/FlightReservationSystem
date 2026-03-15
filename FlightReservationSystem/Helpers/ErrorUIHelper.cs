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
        public static void HighlightIndividual()
        {
            if (!ErrorCollection.Has)
            {
                DebugLogger.Log("[Dev] ErrorCollection is empty. Highlighting aborted.");
                return;
            }

            if (!ErrorUIRegistry.Has)
            {
                DebugLogger.Log("[Dev] ErrorUIRegistry is empty. Highlighting aborted.");
                return;
            }
            else if (ErrorUIRegistry.Count < ErrorCollection.Count) 
            {
                DebugLogger.Log("[Dev] Fewer ErrorUI entries than ErrorEntry items. Highlighting aborted.");
                return;
            }

            var errors = ErrorCollection.Get;
            var errorUIs = ErrorUIRegistry.Get;

            for (int i = 0; i < ErrorCollection.Count; i++)
            {
                var error = errors[i];
                var errorUI = errorUIs[i];
                
                if (error == null || errorUI == null)
                {
                    DebugLogger.Log("[Dev] Encountered null ErrorEntry or ErrorUI. Highlighting aborted.");
                    return;
                }
 
                ErrorProvider provider = errorUI.Provider;
                string errorMessage = error.Message;
                var associatedControls = error.AssociatedControls;

                if (provider == null || errorMessage == null || associatedControls == null)
                {
                    DebugLogger.Log("[Dev] provider, errorMessage or associatedControls is null. Highlighting aborted.");
                    return;
                }  

                if (associatedControls.Count == 0)
                {
                    DebugLogger.Log("[Dev] associatedControls is empty. Highlighting aborted.");
                    return;
                }

                for (int j = 0; j < associatedControls.Count; j++)
                {
                    Control control = associatedControls[j];

                    if (control == null)
                    {
                        DebugLogger.Log("[Dev] Encountered null control. Highlighting aborted.");
                        return;
                    }

                    provider.SetError(control, errorMessage);
                }
            }

            ErrorCollection.Clear();
        }

        public static void HighlightGlobal(string errorMessage)
        {
            if (errorMessage == null)
            {
                DebugLogger.Log("[Dev] errorMessage is null. Highlighting aborted.");
                return;
            }

            if (!ErrorUIRegistry.Has)
            {
                DebugLogger.Log("[Dev] ErrorUIRegistry is empty. Highlighting aborted.");
                return;
            }

            var errorUIs = ErrorUIRegistry.Get;

            for (int i = 0; i < ErrorUIRegistry.Count; i++)
            {
                var errorUI = errorUIs[i];
                
                if (errorUI == null)
                {
                    DebugLogger.Log("[Dev] Encountered null ErrorUI entry. Highlighting aborted.");
                    return;
                }

                ErrorProvider provider = errorUI.Provider;
                Control control = errorUI.Target;

                if (provider == null || control == null)
                {
                    DebugLogger.Log("[Dev] provider or control is null. Highlighting aborted.");
                    return;
                }

                provider.SetError(control, errorMessage);
            }
        }
    }
}

