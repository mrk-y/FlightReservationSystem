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
                    string sql = "SELECT TOP 1 AircraftID " +
                        "FROM Aircrafts " +
                        "ORDER BY AircraftID DESC ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        object db_ac_aircraftID = cmd.ExecuteScalar();

                        if (db_ac_aircraftID == null || db_ac_aircraftID == DBNull.Value)
                        {
                            DebugLogger.LogWithStackTrace("db_ac_aircraftID is null. Generating ID aborted.");
                            return "";
                        }
                        else return DataFormatter.AircraftIDFormat(Convert.ToInt32(db_ac_aircraftID) + 1);
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Generating ID aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occurred while generating ID.");
                    return "";
                }
            }
        }
    }
}
