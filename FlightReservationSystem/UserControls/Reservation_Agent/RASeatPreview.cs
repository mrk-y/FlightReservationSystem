using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Data.Reference.ControlItem;
using System.Drawing;
using FlightReservationSystem.UserControls.AircraftModelsUI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RASeatPreview : UserControl
    {
        public RASeatPreview()
        {
            InitializeComponent();
            InitData();

            // Ensure seat map panel scrolls and fills available space
            try
            {
                pnlSeatMap.Dock = DockStyle.Fill;
                pnlSeatMap.AutoScroll = true;
            }
            catch { }
        }

        private void InitData()
        {
            ApplyAircraftCMBData();
        }

        private void ApplyAircraftCMBData()
        {
            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    // Select distinct aircrafts that have at least one active flight
                    // with departure date today or any date in the future.
                    string sql =
                        "SELECT ac.AircraftID AS ac_AircraftID, ac.Aircraft AS ac_Aircraft, f.FlightID AS f_FlightID, m.Model AS ac_Model " +
                        "FROM Flights f " +
                        "INNER JOIN Aircrafts ac ON f.Aircraft = ac.AircraftID " +
                        "LEFT JOIN AircraftModels m ON m.ModelID = ac.Model " +
                        "WHERE f.IsActive = 1 AND CONVERT(date, f.Departure) >= CONVERT(date, GETDATE()) " +
                        "AND f.Departure = (SELECT MIN(f2.Departure) FROM Flights f2 WHERE f2.Aircraft = ac.AircraftID AND f2.IsActive = 1 AND CONVERT(date, f2.Departure) >= CONVERT(date, GETDATE())) " +
                        "ORDER BY ac.Aircraft ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_ac_AircraftID = reader.GetInt32(reader.GetOrdinal("ac_AircraftID"));
                                string db_ac_Aircraft = reader.GetString(reader.GetOrdinal("ac_Aircraft"));
                                string db_ac_Model = reader[reader.GetOrdinal("ac_Model")] == DBNull.Value
                                    ? string.Empty
                                    : reader.GetString(reader.GetOrdinal("ac_Model"));
                                int db_f_FlightID = reader.GetInt32(reader.GetOrdinal("f_FlightID"));

                                // Store the flight ID and model so we can load saved passengers and resolve the seat map UI
                                itemList.Add(new CMBItemWTag { Display = db_ac_Aircraft, Value = Tuple.Create(db_f_FlightID, db_ac_Model) });
                                sourceList.Add(db_ac_Aircraft);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Applying aircraft cmb data aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while applying data.");
                    return;
                }
            }

            cmbAircraft.DisplayMember = "Display";
            cmbAircraft.ValueMember = "Value";
            cmbAircraft.DataSource = itemList;
            if (itemList.Count > 0) cmbAircraft.SelectedIndex = 0;
            cmbAircraft.AutoCompleteCustomSource.Clear();
            cmbAircraft.AutoCompleteCustomSource.AddRange(sourceList.ToArray());

            // When selection changes, show seat map for the aircraft's model
            cmbAircraft.SelectedIndexChanged -= CmbAircraft_SelectedIndexChanged;
            cmbAircraft.SelectedIndexChanged += CmbAircraft_SelectedIndexChanged;
            // Immediately show seat map for the first item if available
            if (itemList.Count > 0)
            {
                CmbAircraft_SelectedIndexChanged(cmbAircraft, EventArgs.Empty);
            }
        }

        private void CmbAircraft_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var val = cmbAircraft.SelectedValue;
                if (val is Tuple<int, string> t)
                {
                    int flightId = t.Item1;
                    string model = t.Item2;
                    ShowSeatMap(flightId, model);
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Failed to show seat map.");
            }
        }

        private void ShowSeatMap(int flightId, string model)
        {
            pnlSeatMap.Controls.Clear();

            if (string.IsNullOrWhiteSpace(model)) return;

            UserControl map = ResolveAircraftUI(model);
            if (map == null)
            {
                // no seat map for this model
                return;
            }

            // If the map supports ISeatMap, load saved passengers so taken seats are shown
            if (map is ISeatMap iMap)
            {
                try
                {
                    var saved = BookingRepository.LoadSavedPassengers(flightId);
                    if (saved != null && saved.Count > 0) iMap.LoadSavedPassengers(saved);
                    // Wire clicks to show detailed passenger info popup in preview
                    WireSeatButtonsRecursive(map);
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Failed to load saved passengers for preview.");
                }
            }

            map.Dock = DockStyle.None;
            map.AutoSize = true;
            map.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            map.Location = new Point(0, 0);

            pnlSeatMap.Controls.Add(map);
        }

        private void WireSeatButtonsRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    // Only attach preview handler to buttons representing saved passengers.
                    // Remove other Click handlers so the map's own popups won't fire.
                    if (btn.Tag is SavedPassengerInfo)
                    {
                        try
                        {
                            var eventsProp = typeof(Component).GetProperty("Events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            var eventList = (EventHandlerList)eventsProp.GetValue(btn, null);
                            var clickKeyField = typeof(Control).GetField("EventClick", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                            var clickKey = clickKeyField.GetValue(null);
                            var existing = eventList[clickKey];
                            if (existing != null) eventList.RemoveHandler(clickKey, existing);
                        }
                        catch { }

                        btn.Click -= SeatPreview_ShowSavedPassengerInfo;
                        btn.Click += SeatPreview_ShowSavedPassengerInfo;
                        btn.Cursor = Cursors.Hand;
                    }
                }

                // recurse into children
                if (c.HasChildren) WireSeatButtonsRecursive(c);
            }
        }

        private void SeatPreview_ShowSavedPassengerInfo(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            if (btn.Tag is SavedPassengerInfo sp)
            {
                string specials = (sp.NeedsWheelchair ? "Wheelchair" : "") +
                                  (sp.HasPeanutAllergy ? (sp.NeedsWheelchair ? ", Peanut Allergy" : "Peanut Allergy") : "") +
                                  (sp.IsUnaccompaniedMinor ? (sp.NeedsWheelchair || sp.HasPeanutAllergy ? ", UMNR" : "UMNR") : "");

                string specialsStr = string.IsNullOrEmpty(specials) ? "None" : specials;

                string text =
                    "PASSENGER\n" +
                    $"  Name:        \t{sp.LastName}, {sp.FirstName} {sp.MiddleName}\n" +
                    $"  Reference:   \t{sp.ReferenceNo}\n" +
                    $"  Seat:        \t{sp.SeatLabel}  ({sp.SeatClass})\n" +
                    $"  Specials:    \t{specialsStr}\n" +
                    $"  Email:       \t{sp.Email}\n" +
                    $"  Phone:       \t{sp.Phone}\n" +
                    $"  Nationality: \t{sp.Nationality}\n" +
                    $"  Gender:      \t{sp.Gender}\n" +
                    $"  Age:         \t{sp.Age}\n";

                MessageBox.Show(text, "Passenger Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static UserControl ResolveAircraftUI(string model)
        {
            if (string.IsNullOrWhiteSpace(model)) return null;
            string n = model.ToLower().Replace(" ", "").Replace("-", "");

            if (n.Contains("atr") && n.Contains("72")) return new UserControls.AircraftModelsUI.ATR_72_600();
            if (n.Contains("a319")) return new UserControls.AircraftModelsUI.Airbus_A319_100();
            if (n.Contains("a321neo")) return new UserControls.AircraftModelsUI.Airbus_A321neo();
            if (n.Contains("a321")) return new UserControls.AircraftModelsUI.Airbus_A321_200();
            if (n.Contains("a320neo")) return new UserControls.AircraftModelsUI.Airbus_A320neo();
            if (n.Contains("a320")) return new UserControls.AircraftModelsUI.Airbus_A320_200();
            if (n.Contains("737") && n.Contains("900er")) return new UserControls.AircraftModelsUI.Boeing_737_900ER();
            if (n.Contains("737") && n.Contains("900")) return new UserControls.AircraftModelsUI.Boeing_737_900ER();
            if (n.Contains("737") && n.Contains("800")) return new UserControls.AircraftModelsUI.Boeing_737_800();
            if (n.Contains("737") && n.Contains("700")) return new UserControls.AircraftModelsUI.Boeing_737_700();
            if (n.Contains("dhc") && n.Contains("8")) return new UserControls.AircraftModelsUI.DHC_8_400();

            return null;
        }
    }
}
