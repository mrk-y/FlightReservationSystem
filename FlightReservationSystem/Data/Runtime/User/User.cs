using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.User
{
    internal class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public int UserTypeID { get; set; }
        public string UserType { get; set; }


        public static bool UserID_Try(string userID)
        {
            if (!ValueChecker.IsStringValid(userID, nameof(userID)))
            {
                DebugLogger.LogWithStackTrace("userID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Name_Try(string name)
        {
            if (!ValueChecker.IsStringValid(name, nameof(name)))
            {
                DebugLogger.LogWithStackTrace("name invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool HashedPassword_Try(string hashedPassword)
        {
            if (!ValueChecker.IsStringValid(hashedPassword, nameof(hashedPassword)))
            {
                DebugLogger.LogWithStackTrace("hashedPassword invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool UserTypeID_Try(int userTypeID)
        {
            if (!ValueChecker.IsIntValid(userTypeID, nameof(userTypeID)))
            {
                DebugLogger.LogWithStackTrace("userTypeID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool UserType_Try(string userType)
        {
            if (!ValueChecker.IsStringValid(userType, nameof(userType)))
            {
                DebugLogger.LogWithStackTrace("userType invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
