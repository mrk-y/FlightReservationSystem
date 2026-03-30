using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    internal class FlightManagement
    {
        public static void AddFlight(int aircraft, DateTime departure, DateTime arrival, int origin, int destination, int terminal, int gate, int distanceKM, int durationMin)
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Flights (Aircraft, Departure, Arrival, Origin, Destination, Terminal, Gate, DistanceKM, DurationMin) VALUES " +
                        "(@Aircraft, @Departure, @Arrival, @Origin, @Destination, @Terminal, @Gate, @DistanceKM, @DurationMin) ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Aircraft", aircraft);
                        cmd.Parameters.AddWithValue("@Departure", departure);
                        cmd.Parameters.AddWithValue("@Arrival", arrival);
                        cmd.Parameters.AddWithValue("@Origin", origin);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        cmd.Parameters.AddWithValue("@Terminal", terminal);
                        cmd.Parameters.AddWithValue("@Gate", gate);
                        cmd.Parameters.AddWithValue("@DistanceKM", distanceKM);
                        cmd.Parameters.AddWithValue("@DurationMin", durationMin);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Adding flight aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while adding flight.");
                    return;
                }
            }

            UpdateAircraft(aircraft);

            MessageBoxHelper.ShowSuccessMessage("Route successfully assigned to aircraft.");
            ErrorManager.DefaultValueFields();
            DataSeeder.PopulateAircraftStat2();
        }

        private static void UpdateAircraft(int aircraftID)
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Aircrafts " +
                        "SET Status = 3 " +
                        "WHERE AircraftID = @AircraftID ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@AircraftID", aircraftID);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Updating aircraft aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while updating aircraft.");
                    return;
                }
            }
        }
    }
}
