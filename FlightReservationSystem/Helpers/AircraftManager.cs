using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class AircraftManager
    {
        public static string NewAircraftID()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT TOP 1 ac.AircraftID AS AircraftID " +
                        "FROM Aircrafts ac " +
                        "ORDER BY AircraftID DESC ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        object db_ac_AircraftID = cmd.ExecuteScalar();

                        if (db_ac_AircraftID == null)
                        {
                            DebugLogger.LogWithStackTrace("db_ac_AircraftID is null from Aircrafts Table DB. ID generation aborted.");
                            return "";
                        }
                        else return DataFormatter.AircraftIDFormat(Convert.ToInt32(db_ac_AircraftID) + 1);
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

        public static void AddAircraftModel(AircraftModelRecord aircraftModelRecord)
        {
            if (!AircraftModelRecord.ID_Try(aircraftModelRecord.ID) || !AircraftModelRecord.Model_Try(aircraftModelRecord.Model) ||
                !AircraftModelRecord.TotalSeats_Try(aircraftModelRecord.TotalSeats) || !AircraftModelRecord.SeatLayoutCollection_Try(aircraftModelRecord.SeatLayoutCollection) ||
                !AircraftModelRecord.Speed_Try(aircraftModelRecord.Speed))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            AircraftModelCollection.Add(aircraftModelRecord);
        }

        public static List<AircraftModelRecord> GetAircraftModelCollection => AircraftModelCollection.Get;

        public static List<AircraftModelUIRecord> GetAircraftModelUICollection => AircraftModelUICollection.Get;

    }
}
