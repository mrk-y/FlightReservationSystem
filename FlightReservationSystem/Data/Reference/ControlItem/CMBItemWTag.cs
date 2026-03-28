using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.ControlItem
{
    internal class CMBItemWTag
    {
        public string Display { get; set; }
        public object Value { get; set; }


        public override string ToString() => Display;

        public static bool Display_Try(string display)
        {
            if (!ValueChecker.IsStringValid(display, nameof(display)))
            {
                DebugLogger.LogWithStackTrace("display invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Value_Try(object value)
        {
            if (value == null)
            {
                DebugLogger.LogWithStackTrace("value is null. Try false.");
                return false;
            }

            if (value is int valueInt)
            {
                if (!ValueChecker.IsIntValid(valueInt, nameof(valueInt)))
                {
                    DebugLogger.LogWithStackTrace("valueInt invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }
    }
}
