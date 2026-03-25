using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorUIRecord
    {
        public ErrorProvider Provider { get; set; }
        public Control Target { get; set; }
        public Control Field { get; set; }
        public object DefaultValue { get; set; }


        public static bool Provider_Try(ErrorProvider provider)
        {
            if (provider == null) 
            {
                DebugLogger.LogWithStackTrace("provider is null. Try false.");
                return false;
            }

            return true;
        }

        public static bool Target_Try(Control target)
        {
            if (target == null)
            {
                DebugLogger.LogWithStackTrace("target is null. Try false.");
                return false;
            }

            return true;
        }

        public static bool Field_Try(Control field)
        {
            if (field == null)
            {
                DebugLogger.LogWithStackTrace("field is null. Try false.");
                return false;
            }

            return true;
        }

        public static bool DefaultValue_Try(object defaultValue, Control field)
        {
            if (defaultValue == null) 
            {
                DebugLogger.LogWithStackTrace("defaultValue is null. Try false.");
                return false;
            }

            if (field == null)
            {
                DebugLogger.LogWithStackTrace("field is null. Try false.");
                return false;
            }

            if (field.GetType() == typeof(TextBox) && defaultValue.GetType() != typeof(string))
            {
                DebugLogger.LogWithStackTrace("field and defaultValue not compatible. Try false.");
                return false;
            }
            else if (field.GetType() == typeof(ComboBox) && defaultValue.GetType() != typeof(int))
            {
                DebugLogger.LogWithStackTrace("field and defaultValue not compatible. Try false.");
                return false;
            }

            return true;
        }
    }
}
