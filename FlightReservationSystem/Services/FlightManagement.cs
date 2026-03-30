using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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
            UpdateGate(aircraft, gate, terminal);

            MessageBoxHelper.ShowSuccessMessage("Route successfully assigned to aircraft.");
            ErrorManager.DefaultValueFields();
            DataSeeder.PopulateAircraftStat2();
            DataSeeder.PopulateTerminals();
        }

        private static void UpdateAircraft(int aircraftID)
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Aircrafts " +
                        "SET Status = 4 " +
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

        private static void UpdateGate(int aircraftID, int gateID, int terminalID)
        {
            var terminalCollection = TerminalManager.GetTerminalCollection;

            if (terminalCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("terminalCollection is empty. Updating gate aborted.");
                return;
            }

            for (int i = 0; i < terminalCollection.Count; i++)
            {
                var terminalRecord = terminalCollection[i];

                if (terminalRecord.ID == terminalID)
                {
                    var gates = terminalRecord.Gates;

                    if (gates.Count == 0)
                    {
                        DebugLogger.LogWithStackTrace($"gates {i} is empty. Updaing gate aborted.");
                        return;
                    }

                    for (int j = 0; j < gates.Count; j++)
                    {
                        var gate = gates[j];

                        if (gate.ID == gateID)
                        {
                            gate.AircraftID = aircraftID;
                            gate.Status = 2;
                            break;
                        }
                    }
                }
            }

            using (SqlConnection con = DatabaseConnection.Get())
            {
                con.Open();

                for (int i = 0; i < terminalCollection.Count;i++)
                {
                    var terminalRecord = terminalCollection[i];
                    var gatesJson = JsonSerializer.Serialize(terminalRecord.Gates);

                    try
                    {
                        string sql = "UPDATE Terminals " +
                            "Set Gates = @Gates " +
                            "WHERE TerminalID = @TerminalID ";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@Gates", gatesJson);
                            cmd.Parameters.AddWithValue("@TerminalID", terminalRecord.ID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        DebugLogger.LogWithStackTrace($"{ex.Message}. Updating gate aborted.");
                        return;
                    }
                }
            }
        }
    }
}
