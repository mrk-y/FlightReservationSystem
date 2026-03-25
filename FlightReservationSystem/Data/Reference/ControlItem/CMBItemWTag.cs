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
        public object Tag { get; set; }


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

        public static bool Tag_Try(object tag)
        {
            if (tag == null)
            {
                DebugLogger.LogWithStackTrace("tag is null. Try false.");
                return false;
            }

            if (tag is int tagInt)
            {
                if (!ValueChecker.IsIntValid(tagInt, nameof(tagInt)))
                {
                    DebugLogger.LogWithStackTrace("tagInt invalid value. Try false.");
                    return false;
                }
            }

            return true;
        }
    }
}
