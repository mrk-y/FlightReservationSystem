using FlightReservationSystem.Data.Runtime.Aircraft;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Services
{
    // Adding aircrafts ...
    internal class AircraftManagement
    {
        // >> Start of AddAircraft
        private static List<int> GetSeatTypeIDs(Button seat)
        {
            List<int> ids = new List<int>();

            var seatTypeUICollection = AircraftManager.GetSeatTypeUICollection;

            if (seatTypeUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("seatTypeUICollection is empty. Getting seat type id aborted.");
                return null;
            }

            for (int i = 0; i < seatTypeUICollection.Count; i++)
            {
                if (seatTypeUICollection[i].BackColor.ToArgb() == seat.BackColor.ToArgb())
                {
                    ids.Add(seatTypeUICollection[i].ID);
                    break;
                }
            }

            if (seatTypeUICollection[4].BorderColor.ToArgb() == seat.FlatAppearance.BorderColor.ToArgb()) ids.Add(5);

            return ids;
        }

        private static List<SeatAssignRecord> CreateSeatAssign(int model)
        {
            var aircraftModelUICollection = AircraftManager.GetAircraftModelUICollection;

            if (aircraftModelUICollection == null)
            {
                DebugLogger.LogWithStackTrace("aircraftModelUICollection is empty. Populating aborted.");
                return null;
            }

            UserControl modelUI = null;

            for (int i = 0; i < aircraftModelUICollection.Count; i++)
            {
                var aircraftModelUIRecord = aircraftModelUICollection[i];

                if (aircraftModelUIRecord.ID == model)
                {
                    modelUI = aircraftModelUIRecord.UI;
                    break;
                }
            }

            List<SeatAssignRecord> seatAssignCollection = new List<SeatAssignRecord>();

            var modelUIControls = modelUI.Controls;

            if (modelUIControls == null)
            {
                DebugLogger.LogWithStackTrace("modelUIControls is null. Populating aborted.");
                return null;
            }

            for (int i = 0; i < modelUIControls.Count; i++)
            {
                var modelUIControl = modelUIControls[i];

                if (modelUIControl == null)
                {
                    DebugLogger.LogWithStackTrace($"modelUIControl {i} is null. Populating aborted.");
                    return null;
                }

                if (modelUIControl is Panel pnl)
                {
                    var pnlControls = pnl.Controls;

                    if (pnlControls == null)
                    {
                        DebugLogger.LogWithStackTrace($"pnlControls {i} is null. Populating aborted.");
                        return null;
                    }

                    for (int j = 0; j < pnlControls.Count; j++)
                    {
                        var pnlControl = pnlControls[j];

                        if (pnlControl == null)
                        {
                            DebugLogger.LogWithStackTrace($"pnlControl {j}, {i} is null. Populating aborted.");
                            return null;
                        }

                        if (pnlControl is Button btn)
                        {
                            if (btn == null)
                            {
                                DebugLogger.LogWithStackTrace($"btn {j}, {i} is null. Populating aborted.");
                                return null;
                            }

                            if (btn.Tag is string tagVal) seatAssignCollection.Add(new SeatAssignRecord { Code = tagVal, Types = GetSeatTypeIDs(btn) });
                        }
                    }
                }
            }


            if (seatAssignCollection == null)
            {
                DebugLogger.LogWithStackTrace("seatAssignCollection is null. Creating seat assignment aborted.");
                return null;
            }

            if (seatAssignCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("seatAssignCollection is empty. Creating seat assignment aborted.");
                return null;
            }

            return seatAssignCollection;
        }

        public static void AddAircraft(string aircraft, int model, int airline, int airport, string baseName)
        {
            int status = 1;

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Aircrafts (Aircraft, Model, Airline, Airport, BaseName, Status, SeatAssignments) " +
                        "VALUES (@Aircraft, @Model, @Airline, @Airport, @BaseName, @Status, @SeatAssignments) ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Aircraft", aircraft);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Airline", airline);
                        cmd.Parameters.AddWithValue("@Airport", airport);
                        cmd.Parameters.AddWithValue("@BaseName", baseName);
                        cmd.Parameters.AddWithValue("@Status", status);

                        List<SeatAssignRecord> seatAssignCollection = CreateSeatAssign(model);
                        string seatAssignments = JsonSerializer.Serialize(seatAssignCollection);

                        cmd.Parameters.AddWithValue("@SeatAssignments", seatAssignments);
                        cmd.ExecuteNonQuery();
                        MessageBoxHelper.ShowSuccessMessage("Aircraft successfully added.");
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
        // << End of AddAircraft
    }
}
