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
            if (string.IsNullOrWhiteSpace(userID))
            {
                DebugLogger.LogWithStackTrace("userID is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(userID))
            {
                DebugLogger.LogWithStackTrace("userID starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool Name_Try(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                DebugLogger.LogWithStackTrace("name is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(name))
            {
                DebugLogger.LogWithStackTrace("name starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool HashedPassword_Try(string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword))
            {
                DebugLogger.LogWithStackTrace("hashedPassword is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(hashedPassword))
            {
                DebugLogger.LogWithStackTrace("hashedPassword starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }

        public static bool UserTypeID_Try(int userTypeID)
        {
            if (userTypeID == 0)
            {
                DebugLogger.LogWithStackTrace("userTypeID is 0. Try false.");
                return false;
            }

            return true;
        }

        public static bool UserType_Try(string userType)
        {
            if (string.IsNullOrWhiteSpace(userType))
            {
                DebugLogger.LogWithStackTrace("userType is null or whitespace. Try false.");
                return false;
            }

            if (ValueChecker.HasStartEndSpace(userType))
            {
                DebugLogger.LogWithStackTrace("userType starts or ends with whitespace. Try false.");
                return false;
            }

            return true;
        }
    }
}
