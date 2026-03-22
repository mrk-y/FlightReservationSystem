using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    // Generating ids

    internal class IDGenerator
    {
        public static string AircraftID()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "";
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Generating ID aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occurred while generating AircraftID.");
                    return "";
                }
            }

                return "";
        }
    }
}
