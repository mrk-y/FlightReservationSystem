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
            if (string.IsNullOrWhiteSpace(display))
            {
                DebugLogger.LogWithStackTrace("display is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(display))
            {
                DebugLogger.LogWithStackTrace("display starts or ends with whitespace. Try false.");
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

            if (tag is int tagInt && tagInt == 0)
            {
                DebugLogger.LogWithStackTrace("tagInt is 0. Try false.");
                return false;
            }

            return true;
        }
    }
}
