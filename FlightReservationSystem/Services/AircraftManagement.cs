using FlightReservationSystem.Data.Runtime.Json.SeatAssign;
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
        private static List<int> GetSeatTypeIDs(Button seat)
        {
            List<int> ids = new List<int>();

            var seatTypeUICollection = SeatManager.GetSeatTypeUICollection;

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

        private static void PopulateSeatAssign(int model)
        {
            var aircraftModelUICollection = AircraftManager.GetAircraftModelUICollection;

            if (aircraftModelUICollection == null)
            {
                DebugLogger.LogWithStackTrace("aircraftModelUICollection is empty. Populating aborted.");
                return;
            }

            UserControl modelUI = null;

            for (int i = 0; i <  aircraftModelUICollection.Count; i++)
            {
                var aircraftModelUIRecord = aircraftModelUICollection[i];

                if (aircraftModelUIRecord.ID == model) 
                {
                    modelUI = aircraftModelUIRecord.ModelUI;
                    break;
                }
            }

            SeatManager.ClearSeatAssignCollection();

            var modelUIControls = modelUI.Controls;

            if (modelUIControls == null)
            {
                DebugLogger.LogWithStackTrace("modelUIControls is null. Populating aborted.");
                return;
            }

            for (int i = 0; i <  modelUIControls.Count; i++)
            {
                var modelUIControl = modelUIControls[i];

                if (modelUIControl == null)
                {
                    DebugLogger.LogWithStackTrace($"modelUIControl {i} is null. Populating aborted.");
                    return;
                }

                if (modelUIControl is Panel pnl)
                {
                    var pnlControls = pnl.Controls;

                    if (pnlControls == null)
                    {
                        DebugLogger.LogWithStackTrace($"pnlControls {i} is null. Populating aborted.");
                        return;
                    }

                    for (int j = 0; j < pnlControls.Count; j++)
                    {
                        var pnlControl = pnlControls[j];

                        if (pnlControl == null)
                        {
                            DebugLogger.LogWithStackTrace($"pnlControl {j}, {i} is null. Populating aborted.");
                            return;
                        }

                        if (pnlControl is Button btn)
                        {
                            if (btn == null)
                            {
                                DebugLogger.LogWithStackTrace($"btn {j}, {i} is null. Populating aborted.");
                                return;
                            }

                            if (btn.Tag is string tagVal) SeatManager.AddSeatAssign(new SeatAssignRecord { SeatCode = tagVal, SeatTypes = GetSeatTypeIDs(btn) });
                        }
                    }
                }
            }
        }

        public static void AddAircraft(string aircraft, int model, int airline, int airport, string baseName)
        {
            string status = "Incomplete";
           
            PopulateSeatAssign(model);

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Aircrafts (Aircraft, Model, Airline, Airport, BaseName, Status, SeatLayout) " +
                        "VALUES (@Aircraft, @Model, @Airline, @Airport, @BaseName, @Status, @SeatLayout) ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Aircraft", aircraft);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Airline", airline);
                        cmd.Parameters.AddWithValue("@Airport", airport);
                        cmd.Parameters.AddWithValue("@BaseName", baseName);
                        cmd.Parameters.AddWithValue("@Status", status);

                        List<SeatAssignRecord> seatAssignCollection = SeatManager.GetSeatAssignCollection;
                        string seatLayout = JsonSerializer.Serialize(seatAssignCollection);

                        cmd.Parameters.AddWithValue("@SeatLayout", seatLayout);

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
