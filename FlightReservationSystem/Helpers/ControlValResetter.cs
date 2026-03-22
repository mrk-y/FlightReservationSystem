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
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorUIRecord {i} is null. Clearing aborted.");
                    return;
                }

                var provider = errorUIRecord.Provider;

                if (provider == null)
                {
                    DebugLogger.LogWithStackTrace($"provider {i} is null. Clearing aborted.");
                    return;
                }

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

                if (errorUIRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorUIRecord {i} is null. Value defaulting aborted.");
                    return;
                }

                Control field = errorUIRecord.Field;

                if (field == null)
                {
                    DebugLogger.LogWithStackTrace($"field {i} is null. Value defaulting aborted.");
                    return;
                }

                object defaultValue = errorUIRecord.DefaultValue;

                if (object.Equals(defaultValue, null))
                {
                    DebugLogger.LogWithStackTrace($"defaultValue {i} is null. Value defaulting aborted.");
                    return;
                }

                if (field is TextBox tb)
                {
                    if (defaultValue is string val) tb.Text = val;
                    else
                    {
                        DebugLogger.LogWithStackTrace($"defaultValue {i} is not type string. Value defaulting aborted.");
                        return;
                    }
                }
                else if (field is ComboBox cmb)
                {
                    if (defaultValue is int val) cmb.SelectedIndex = val;
                    else
                    {
                        DebugLogger.LogWithStackTrace($"defaultValue {i} is not type int. Value defaulting aborted.");
                        return;
                    }

                }
            }
        }

        public static void DefaultValueSpecificField(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                DebugLogger.LogWithStackTrace("fieldName is null or whitespace. Value defaulting aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(fieldName))
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

                if (errorUIRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorUIRecord {i} is null. Value defaulting aborted.");
                    return;
                }

                Control field = errorUIRecord.Field;

                if (field == null)
                {
                    DebugLogger.LogWithStackTrace($"field {i} is null. Value defaulting aborted.");
                    return;
                }

                object defaultValue = errorUIRecord.DefaultValue;

                if (object.Equals(defaultValue, null))
                {
                    DebugLogger.LogWithStackTrace($"defaultValue {i} is null. Value defaulting aborted.");
                    return;
                }

                if (field.Name == fieldName)
                {
                    if (field is TextBox tb)
                    {
                        if (defaultValue is string val) tb.Text = val;
                        else
                        {
                            DebugLogger.LogWithStackTrace($"defaultValue {i} is not type string. Value defaulting aborted.");
                            return;
                        }

                    }
                    else if (field is ComboBox cmb)
                    {
                        if (defaultValue is int val) cmb.SelectedIndex = val;
                        else
                        {
                            DebugLogger.LogWithStackTrace($"defaultValue {i} is not type int. Value defaulting aborted.");
                            return;
                        }
                    }
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
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorUIRecord {i} is null. Clearing aborted.");
                    return;
                }

                var field = errorUIRecord.Field;

                if (field == null)
                {
                    DebugLogger.LogWithStackTrace($"field {i} is null. Clearing aborted.");
                    return;
                }

                if (field is TextBox tb)
                {
                    tb.Clear();
                }
                else if (field is ComboBox cmb)
                {
                    cmb.Items.Clear();
                }
            }
        }

        public static void ClearSpecificField(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                DebugLogger.LogWithStackTrace("fieldName is null or whitespace. Clearing aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(fieldName))
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
                var errorUIRecord = errorUICollection[i];

                if (errorUIRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorUIRecord {i} is null. Clearing aborted.");
                    return;
                }

                var field = errorUIRecord.Field;

                if (field == null)
                {
                    DebugLogger.LogWithStackTrace($"field {i} is null. Clearing aborted.");
                    return;
                }

                if (field.Name == fieldName)
                {
                    if (field is TextBox tb)
                    {
                        tb.Clear();
                    }
                    else if (field is ComboBox cmb)
                    {
                        cmb.Items.Clear();
                    }
                }
            }
        }
    }
}
