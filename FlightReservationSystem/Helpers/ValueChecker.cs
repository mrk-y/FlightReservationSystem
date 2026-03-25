using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace FlightReservationSystem.Helpers
{
    internal class ValueChecker
    {
        public static bool HasStartEndWhitespace(string _string) => _string.StartsWith(" ") || _string.EndsWith(" ");

        public static bool IsStringValid(string _string, string name = "_string")
        {
            if (string.IsNullOrWhiteSpace(_string))
            {
                DebugLogger.LogWithStackTrace($"{name} is null or whitespace. Invalid string.");
                return false;
            }

            if (HasStartEndWhitespace(_string))
            {
                DebugLogger.LogWithStackTrace($"{name} starts or ends with whitespace. Invalid string.");
                return false;
            }

            return true;
        }

        public static bool IsIntValid(int _int, string name = "_int")
        {
            if (_int < 0)
            {
                DebugLogger.LogWithStackTrace($"{name} is less than 0. Invalid int.");
                return false;
            }

            return true;
        } 

        public static bool IsDoubleValid(double _double, string name = "_double")
        {
            if (double.IsNaN(_double))
            {
                DebugLogger.LogWithStackTrace($"{name} is NaN. Invalid double");
                return false;
            }

            if (double.IsPositiveInfinity(_double))
            {
                DebugLogger.LogWithStackTrace($"{name} is positive infinity. Invalid double.");
                return false;
            }

            if (double.IsNegativeInfinity(_double))
            {
                DebugLogger.LogWithStackTrace($"{name} is negative infinity. Invalid double.");
                return false;
            }

            if (_double == 0)
            {
                DebugLogger.LogWithStackTrace($"{name} is 0. Invalid double.");
                return false;
            }

            return true;
        }
    }
}
