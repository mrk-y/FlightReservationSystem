using FlightReservationSystem.Data.Runtime.Gate;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class TerminalManager
    {
        public static string NewFlightID()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT TOP 1 fl.FlightID AS fl_FlightID " +
                        "FROM Flights fl " +
                        "ORDER BY FlightID DESC ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        object db_fl_FlightID = cmd.ExecuteScalar();

                        if (db_fl_FlightID == null)
                        {
                            DebugLogger.LogWithStackTrace("db_fl_FlightID is null from Aircrafts Table DB. ID generation aborted.");
                            return "";
                        }
                        else return $"{(Convert.ToInt32(db_fl_FlightID) + 1):0000}";
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

        public static void AddTerminal(TerminalRecord terminalRecord)
        {
            if (!TerminalRecord.ID_Try(terminalRecord.ID) || !TerminalRecord.Number_Try(terminalRecord.Number) ||
                !TerminalRecord.Classification_Try(terminalRecord.Classification) || !TerminalRecord.Gates_Try(terminalRecord.Gates) || 
                !TerminalRecord.AirportID_Try(terminalRecord.AirportID) || !TerminalRecord.Status_Try(terminalRecord.Status))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            TerminalCollection.Add(terminalRecord);
        }

        public static List<TerminalRecord> GetTerminalCollection => TerminalCollection.Get;

        public static void ClearTerminalCollection() => TerminalCollection.Clear();
    }
}
