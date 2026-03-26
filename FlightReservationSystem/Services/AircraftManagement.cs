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
    // Adding aircrafts ...

    internal class AircraftManagement
    {
        public static void AddAircraft(string aircraft, int model, int airline, int airport, string baseName)
        {
            string status = "Incomplete";

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Aircrafts (Aircraft, Model, Airline, Airport, BaseName, Status) " +
                        "VALUES (@Aircraft, @Model, @Airline, @Airport, @BaseName, @Status) ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Aircraft", aircraft);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Airline", airline);
                        cmd.Parameters.AddWithValue("@Airport", airport);
                        cmd.Parameters.AddWithValue("@BaseName", baseName);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();
                        MessageBoxHelper.ShowSuccessMessage("Aircraft successfully added.");
                        ErrorManager.DefaultValueFields();
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. An unexpected error occured while adding aircraft.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while adding aircraft.");
                    return;
                }
            }
        }
    }
}
