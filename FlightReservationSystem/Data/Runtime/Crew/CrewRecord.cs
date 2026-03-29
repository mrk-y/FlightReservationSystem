using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Crew
{
    internal class CrewRecord
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public int CrewTypeID { get; set; }
        public int Status { get; set; }


        public static bool ID_Try(int id)
        {
            if (!ValueChecker.IsIntValid(id, nameof(id)))
            {
                DebugLogger.LogWithStackTrace("id invalid value. Try false");
                return false;
            }

            return true;
        }

        public static bool LastName_Try(string lastName)
        {
            if (!ValueChecker.IsStringValid(lastName, nameof(lastName)))
            {
                DebugLogger.LogWithStackTrace("lastName invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool FirstName_Try(string firstName)
        {
            if (!ValueChecker.IsStringValid(firstName, nameof(firstName)))
            {
                DebugLogger.LogWithStackTrace("firstName invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool MiddleName_Try(string middleName)
        {
            if (middleName == null)
            {
                DebugLogger.LogWithStackTrace("middleName is null. Try false.");
                return false;
            }

            return true;
        }

        public static bool Birthdate_Try(DateTime birthdate)
        {
            if (birthdate == null)
            {
                DebugLogger.LogWithStackTrace("birthdate is null. Try false.");
                return false;
            }

            return true;
        }

        public static bool Gender_Try(string gender)
        {
            if (!ValueChecker.IsStringValid(gender, nameof(gender)))
            {
                DebugLogger.LogWithStackTrace("gender invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool CrewTypeID_Try(int crewTypeID)
        {
            if (!ValueChecker.IsIntValid(crewTypeID, nameof(crewTypeID)))
            {
                DebugLogger.LogWithStackTrace("crewTypeID invalid value. Try false.");
                return false;
            }

            return true;
        }

        public static bool Status_Try(int status)
        {
            if (!ValueChecker.IsIntValid(status, nameof(status)))
            {
                DebugLogger.LogWithStackTrace("status invalid value. Try false.");
                return false;
            }

            return true;
        }
    }
}
