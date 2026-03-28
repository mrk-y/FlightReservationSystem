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
        public static void AddError(ErrorRecord errorRecord) 
        {
            if (!ErrorRecord.Message_Try(errorRecord.Message) || !ErrorRecord.AssociatedControls_Try(errorRecord.AssociatedControls))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }  
           
            ErrorCollection.Add(errorRecord);
        }

        public static void AddErrorUI(ErrorUIRecord errorUIRecord)
        {
            if (!ErrorUIRecord.Provider_Try(errorUIRecord.Provider) || !ErrorUIRecord.Target_Try(errorUIRecord.Target) || 
                !ErrorUIRecord.Field_Try(errorUIRecord.Field) || !ErrorUIRecord.DefaultValue_Try(errorUIRecord.DefaultValue, errorUIRecord.Field))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            ErrorUICollection.Add(errorUIRecord);
        }

        public static List<ErrorRecord> GetErrorCollection => ErrorCollection.Get;

        public static List<ErrorUIRecord> GetErrorUICollection => ErrorUICollection.Get;

        public static void ClearErrorCollection() => ErrorCollection.Clear();

        public static void ClearErrorUICollection() => ErrorUICollection.Clear();

        // >> Start of ShowAlert 
        private static string ErrorListMessage()
        {
            var errorCollection = ErrorCollection.Get;

            if (errorCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorCollection is empty. Listing aborted.");
                return "";
            }

            string prefix = $"{errorCollection.Count} errors were found.\n\nPlease fix the following to proceed:\n";
            StringBuilder listMessage = new StringBuilder();

            for (int i = 0; i < errorCollection.Count; i++)
            {
                string message = errorCollection[i].Message;

                listMessage.AppendLine($"- {message}");
            }

            if (!ValueChecker.IsStringValid(listMessage.ToString(), nameof(listMessage)))
            {
                DebugLogger.LogWithStackTrace("listMessage.ToString() invalid value. Listing aborted.");
                return "";
            }

            return prefix + listMessage;
        }

        public static void ShowAlert()
        {
            MessageBoxHelper.ShowErrorMessage(ErrorListMessage());
        }
        // << End of ShowAlert

        // >> Start of HighlightError
        // Real errors
        private static void HighlightIndividual()
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
                var message = errorRecord.Message;
                var associatedControls = errorRecord.AssociatedControls;

                for (int j = 0; j < associatedControls.Count; j++)
                {
                    ErrorProvider provider = errorUICollection[k].Provider;
                    Control associatedControl = associatedControls[j];

                    k++;
                    provider.SetError(associatedControl, message);
                }
            }

            ErrorCollection.Clear();
        }

        // Self defined error
        private static void HighlightGlobal(string errorMessage)
        {
            if (!ValueChecker.IsStringValid(errorMessage, nameof(errorMessage)))
            {
                DebugLogger.LogWithStackTrace("errorMessage invalid value. Highlighting aborted.");
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
                ErrorProvider provider = errorUIRecord.Provider;
                Control target = errorUIRecord.Target;

                provider.SetError(target, errorMessage);
            }
        }

        public static void HighlightErrors(bool individual, string errorMessage = null)
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

            if (errorMessage != null && ValueChecker.HasStartEndWhitespace(errorMessage))
            {
                DebugLogger.LogWithStackTrace("errorMessage starts or ends with space. Highlighting aborted.");
                return;
            }

            if (individual) HighlightIndividual();
            else HighlightGlobal(errorMessage);
        }
        // << End of HighlightError

        public static bool HasUncompleteProgress()
        {
            var errorUICollection = GetErrorUICollection;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Uncomplete progress checker aborted.");
                return false;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];
                var field = errorUIRecord.Field;
                var defaultValue = errorUIRecord.DefaultValue;

                if (field is TextBox tb && defaultValue is string tbVal && tb.Text != tbVal) return true;
                else if (field is ComboBox cmb && defaultValue is int cmbVal && cmb.SelectedIndex != cmbVal) return true;
            }

            return false;
        }

        public static void ClearProviders()
        {
            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Clearing aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                ErrorProvider provider = errorUICollection[i].Provider;

                provider.Clear();
            }
        }

        public static void DefaultValueFields()
        {
            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Value defaulting aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];
                Control field = errorUIRecord.Field;
                object defaultValue = errorUIRecord.DefaultValue;

                if (field is TextBox tb && defaultValue is string tbVal) tb.Text = tbVal;
                else if (field is ComboBox cmb && defaultValue is int cmbVal) cmb.SelectedIndex = cmbVal;
            }
        }

        public static void DefaultValueSpecificField(string fieldName)
        {
            if (!ValueChecker.IsStringValid(fieldName, nameof(fieldName)))
            {
                DebugLogger.LogWithStackTrace("fieldName invalid value. Value defaulting aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Value defaulting aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var errorUIRecord = errorUICollection[i];
                Control field = errorUIRecord.Field;
                object defaultValue = errorUIRecord.DefaultValue;

                if (field.Name == fieldName)
                {
                    if (field is TextBox tb && defaultValue is string tbVal) tb.Text = tbVal;
                    else if (field is ComboBox cmb && defaultValue is int cmbVal) cmb.SelectedIndex = cmbVal;
                }
            }
        }

        public static void ClearFields()
        {
            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Clearing aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var field = errorUICollection[i].Field;

                if (field is TextBox tb) tb.Clear();
                else if (field is ComboBox cmb) cmb.DataSource = null;
            }
        }

        public static void ClearSpecificField(string fieldName)
        {
            if (!ValueChecker.IsStringValid(fieldName, nameof(fieldName)))
            {
                DebugLogger.LogWithStackTrace("fieldName invalid value. Clearing aborted.");
                return;
            }

            var errorUICollection = ErrorUICollection.Get;

            if (errorUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorUICollection is empty. Clearing aborted.");
                return;
            }

            for (int i = 0; i < errorUICollection.Count; i++)
            {
                var field = errorUICollection[i].Field;

                if (field.Name == fieldName)
                {
                    if (field is TextBox tb) tb.Clear();
                    else if (field is ComboBox cmb) cmb.DataSource = null;
                }
            }
        }
    }
}
