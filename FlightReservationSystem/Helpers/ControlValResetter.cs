using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class ControlValResetter
    {
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
                errorUICollection[i].Provider.Clear();
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
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                DebugLogger.LogWithStackTrace("fieldName is null or whitespace. Value defaulting aborted.");
                return;
            }

            if (ValueChecker.HasStartEndSpace(fieldName))
            {
                DebugLogger.LogWithStackTrace("fieldName starts or ends with space. Value defaulting aborted.");
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

                if (field is TextBox tb)  tb.Clear();
                else if (field is ComboBox cmb) cmb.Items.Clear();
            }
        }

        public static void ClearSpecificField(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                DebugLogger.LogWithStackTrace("fieldName is null or whitespace. Clearing aborted.");
                return;
            }

            if (ValueChecker.HasStartEndSpace(fieldName))
            {
                DebugLogger.LogWithStackTrace("fieldName starts or ends with space. Clearing aborted.");
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
                    else if (field is ComboBox cmb) cmb.Items.Clear();
                }
            }
        }
    }
}
