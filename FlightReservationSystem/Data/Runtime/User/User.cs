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
        public string ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
       

        public static bool ID_Try(string id)
        {
            if (!ValueChecker.IsStringValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false.");
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

        public static bool Password_Try(string password)
        {
            if (!ValueChecker.IsStringValid(password, nameof(password)))
            {
                DebugLogger.LogWithStackTrace("password invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool TypeID_Try(int typeID)
        {
            if (!ValueChecker.IsIntValid(typeID, nameof(typeID)))
            {
                DebugLogger.LogWithStackTrace("typeID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool TypeName_Try(string typeName)
        {
            if (!ValueChecker.IsStringValid(typeName, nameof(typeName)))
            {
                DebugLogger.LogWithStackTrace("typeName invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
