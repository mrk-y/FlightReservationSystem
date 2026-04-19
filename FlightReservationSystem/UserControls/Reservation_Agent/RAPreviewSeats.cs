using FlightReservationSystem.Data;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.AircraftModelsUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAPreviewSeats : UserControl
    {
        // ═══════════════════════════════════════════════════════════
        // State
        // ═══════════════════════════════════════════════════════════
        private PreviewFlightResult _currentFlight = null;
        private List<SeatOccupancyInfo> _occupancy = new List<SeatOccupancyInfo>();

        // ═══════════════════════════════════════════════════════════
        // Constructor
        // ═══════════════════════════════════════════════════════════
        public RAPreviewSeats()
        {
            InitializeComponent();
            WireEvents();
        }

        // ═══════════════════════════════════════════════════════════
        // EVENT WIRING
        // ═══════════════════════════════════════════════════════════
        private void WireEvents()
        {
            txtFlightSearch.GotFocus += TxtFlightSearch_GotFocus;
            txtFlightSearch.LostFocus += TxtFlightSearch_LostFocus;
            txtFlightSearch.TextChanged += TxtFlightSearch_TextChanged;
            txtFlightSearch.KeyDown += TxtFlightSearch_KeyDown;

            btnSearch.Click += (s, e) =>
            {
                string raw = txtFlightSearch.Text;
                if (raw == SearchPlaceholder) return;
                SearchFlights(raw);
            };

            btnClear.Click += BtnClear_Click;

            lstFlightDrop.SelectedIndexChanged += LstFlightDrop_SelectedIndexChanged;
            lstPassengers.DrawItem += LstPassengers_DrawItem;
            pnlLeft.Resize += (s, e) => ResizePassengerList();

            // Manual scroll bars
            hScroll.Scroll += (s, e) => ScrollMap();
            vScroll.Scroll += (s, e) => ScrollMap();
            pnlMapViewport.Resize += (s, e) => UpdateScrollBars();
        }

        // ═══════════════════════════════════════════════════════════
        // SEARCH BOX — placeholder behaviour
        // ═══════════════════════════════════════════════════════════
        private const string SearchPlaceholder = "Aircraft name, IATA code, or city…";

        private void TxtFlightSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtFlightSearch.Text == SearchPlaceholder)
            {
                txtFlightSearch.Text = "";
                txtFlightSearch.ForeColor = Color.White;
            }
        }

        private void TxtFlightSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFlightSearch.Text))
            {
                txtFlightSearch.Text = SearchPlaceholder;
                txtFlightSearch.ForeColor = Color.FromArgb(180, 210, 255);
            }
        }

        private void TxtFlightSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtFlightSearch.Text.Trim();
            if (q == SearchPlaceholder || q.Length < 2)
            {
                HideFlightDropdown();
                return;
            }
            SearchFlights(q);
        }

        private void TxtFlightSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pnlFlightDropdown.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lstFlightDrop.Items.Count > 0)
                {
                    lstFlightDrop.Focus();
                    lstFlightDrop.SelectedIndex = 0;
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideFlightDropdown();
                e.Handled = true;
            }
        }

        // ═══════════════════════════════════════════════════════════
        // FLIGHT SEARCH — only Status = 4 (Scheduled)
        // ═══════════════════════════════════════════════════════════
        private void SearchFlights(string query)
        {
            string q = (query ?? "").Trim();
            if (q == SearchPlaceholder || q.Length < 2)
            {
                HideFlightDropdown();
                return;
            }

            lstFlightDrop.Items.Clear();

            const string sql = @"
                SELECT f.FlightID,
                       ao.IATA + ' → ' + ad.IATA              AS Route,
                       ao.DisplayCity + ' → ' + ad.DisplayCity AS CityRoute,
                       f.Departure, f.Arrival, f.Gate,
                       a.Aircraft     AS AircraftName,
                       m.Model        AS AircraftModel,
                       a.Status       AS AircraftStatus
                FROM   Flights f
                LEFT JOIN Aircrafts      a  ON a.AircraftID = f.Aircraft
                LEFT JOIN AircraftModels m  ON m.ModelID    = a.Model
                LEFT JOIN Airports       ao ON ao.AirportID = f.Origin
                LEFT JOIN Airports       ad ON ad.AirportID = f.Destination
                WHERE  f.IsActive = 1
                  AND  a.Status = 4
                  AND  (  a.Aircraft       LIKE @q
                       OR ao.IATA          LIKE @q
                       OR ad.IATA          LIKE @q
                       OR ao.DisplayCity   LIKE @q
                       OR ad.DisplayCity   LIKE @q
                       OR m.Model          LIKE @q )
                ORDER  BY f.Departure DESC";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@q", $"%{q}%");
                    conn.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (rdr["FlightID"] == DBNull.Value) continue;

                            lstFlightDrop.Items.Add(new PreviewFlightResult
                            {
                                FlightID = Convert.ToInt32(rdr["FlightID"]),
                                Route = rdr["Route"].ToString(),
                                CityRoute = rdr["CityRoute"].ToString(),
                                Departure = rdr["Departure"] == DBNull.Value
                                                     ? DateTime.MinValue
                                                     : Convert.ToDateTime(rdr["Departure"]),
                                Arrival = rdr["Arrival"] == DBNull.Value
                                                     ? DateTime.MinValue
                                                     : Convert.ToDateTime(rdr["Arrival"]),
                                Gate = rdr["Gate"].ToString(),
                                AircraftName = rdr["AircraftName"].ToString(),
                                AircraftModel = rdr["AircraftModel"] == DBNull.Value
                                                     ? "Unknown"
                                                     : rdr["AircraftModel"].ToString(),
                                AircraftStatus = rdr["AircraftStatus"] == DBNull.Value
                                                     ? 4
                                                     : Convert.ToInt32(rdr["AircraftStatus"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Flight search error:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lstFlightDrop.Items.Count > 0)
            {
                int rowH = lstFlightDrop.ItemHeight > 0 ? lstFlightDrop.ItemHeight : 20;
                int panelH = Math.Min(lstFlightDrop.Items.Count * rowH + 4, rowH * 5 + 4);

                pnlFlightDropdown.Height = panelH;
                pnlFlightDropdown.Visible = true;
                pnlFlightDropdown.BringToFront();

                lstFlightDrop.Visible = true;
                lstFlightDrop.BringToFront();
                lstFlightDrop.Refresh();
            }
            else
            {
                HideFlightDropdown();
            }
        }

        private void LstFlightDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFlightDrop.SelectedItem is PreviewFlightResult flight)
            {
                txtFlightSearch.Text = $"{flight.AircraftName}  {flight.Route}";
                txtFlightSearch.ForeColor = Color.White;
                HideFlightDropdown();
                LoadFlight(flight);
            }
        }

        private void HideFlightDropdown()
        {
            lstFlightDrop.Visible = false;
            pnlFlightDropdown.Visible = false;
            pnlFlightDropdown.Height = 0;
        }

        // ═══════════════════════════════════════════════════════════
        // LOAD FLIGHT
        // ═══════════════════════════════════════════════════════════
        private void LoadFlight(PreviewFlightResult flight)
        {
            _currentFlight = flight;
            _occupancy.Clear();

            FetchOccupancy(flight.FlightID);
            RefreshSummaryCard(flight);
            RenderSeatMap(flight);
        }

        // ═══════════════════════════════════════════════════════════
        // DATABASE — fetch occupied seats
        // ═══════════════════════════════════════════════════════════
        private void FetchOccupancy(int flightID)
        {
            const string sql = @"
                SELECT bp.PassengerID, bp.PassengerNo,
                       bp.FirstName,  bp.LastName,
                       bp.SeatClass,  bp.SeatLabel,
                       b.ReferenceNo
                FROM   BookingPassengers bp
                INNER JOIN Bookings b ON b.BookingID = bp.BookingID
                WHERE  b.FlightID = @flightID
                  AND  b.IsActive = 1
                ORDER  BY bp.SeatLabel";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@flightID", flightID);
                    conn.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _occupancy.Add(new SeatOccupancyInfo
                            {
                                PassengerID = Convert.ToInt32(rdr["PassengerID"]),
                                PassengerNo = Convert.ToInt32(rdr["PassengerNo"]),
                                FirstName = rdr["FirstName"].ToString(),
                                LastName = rdr["LastName"].ToString(),
                                SeatClass = rdr["SeatClass"].ToString(),
                                SeatLabel = rdr["SeatLabel"].ToString(),
                                ReferenceNo = rdr["ReferenceNo"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load occupancy data:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        // LEFT PANEL — summary card
        // ═══════════════════════════════════════════════════════════
        private void RefreshSummaryCard(PreviewFlightResult f)
        {
            lblSummaryFlight.Text = f.AircraftName;
            lblSummaryRoute.Text = $"✈  {f.Route}  |  {f.CityRoute}";
            lblSummaryDate.Text = f.Departure == DateTime.MinValue
                                        ? ""
                                        : $"Dep:  {f.Departure:ddd MMM d  h:mm tt}";
            lblSummaryGate.Text = $"Gate:  {f.Gate}";
            lblSummaryModel.Text = f.AircraftModel;

            ApplyStatusBadge(f.AircraftStatus);

            int occupied = _occupancy.Count;
            lblTotalSeats.Text = $"Total booked:  {occupied}";
            lblOccupied.Text = $"● Occupied:    {occupied}";
            lblAvailable.Text = "";
            pnlOccupancyFill.Width = 0;

            lstPassengers.Items.Clear();
            foreach (var p in _occupancy.OrderBy(x => x.SeatLabel))
                lstPassengers.Items.Add(p);

            lblPassengerHeader.Text = $"BOOKED PASSENGERS  ({_occupancy.Count})";
            ResizePassengerList();
        }

        private void ApplyStatusBadge(int status)
        {
            string text;
            Color back;
            Color fore = Color.White;

            switch (status)
            {
                case 5: text = "BOARDING"; back = Color.FromArgb(255, 202, 7); fore = Color.Black; break;
                case 6: text = "IN FLIGHT"; back = Color.FromArgb(0, 38, 184); break;
                case 7: text = "LANDED"; back = Color.FromArgb(52, 167, 49); break;
                case 8: text = "DELAYED"; back = Color.FromArgb(255, 113, 27); break;
                case 9: text = "CANCELLED"; back = Color.FromArgb(220, 33, 49); break;
                case 4: text = "SCHEDULED"; back = Color.FromArgb(220, 235, 255); fore = Color.FromArgb(10, 40, 100); break;
                default: text = "NOT READY"; back = Color.FromArgb(102, 102, 102); break;
            }

            pnlStatusBadge.BackColor = back;
            lblStatusText.Text = text;
            lblStatusText.ForeColor = fore;
        }

        private void ResizePassengerList()
        {
            int listTop = lstPassengers.Location.Y;
            int available = pnlLeft.ClientSize.Height - listTop - 8;
            lstPassengers.Height = Math.Max(40, available);
        }

        // ═══════════════════════════════════════════════════════════
        // SCROLL HELPERS
        // ═══════════════════════════════════════════════════════════
        private void UpdateScrollBars()
        {
            int mapW = pnlMapHost.Width;
            int mapH = pnlMapHost.Height;
            int vpW = pnlMapViewport.ClientSize.Width;
            int vpH = pnlMapViewport.ClientSize.Height;

            // Horizontal
            if (mapW > vpW)
            {
                hScroll.Visible = true;
                hScroll.Minimum = 0;
                hScroll.Maximum = mapW - vpW + hScroll.LargeChange - 1;
                hScroll.Value = Math.Min(hScroll.Value, Math.Max(0, mapW - vpW));
                hScroll.SmallChange = 20;
                hScroll.LargeChange = Math.Max(1, vpW / 2);
            }
            else
            {
                hScroll.Visible = false;
                hScroll.Value = 0;
            }

            // Vertical
            if (mapH > vpH)
            {
                vScroll.Visible = true;
                vScroll.Minimum = 0;
                vScroll.Maximum = mapH - vpH + vScroll.LargeChange - 1;
                vScroll.Value = Math.Min(vScroll.Value, Math.Max(0, mapH - vpH));
                vScroll.SmallChange = 20;
                vScroll.LargeChange = Math.Max(1, vpH / 2);
            }
            else
            {
                vScroll.Visible = false;
                vScroll.Value = 0;
            }

            ScrollMap();
        }

        private void ScrollMap()
        {
            int x = hScroll.Visible ? -hScroll.Value : 0;
            int y = vScroll.Visible ? -vScroll.Value : 0;
            pnlMapHost.Location = new Point(x, y);
        }

        // ═══════════════════════════════════════════════════════════
        // RIGHT PANEL — seat map (read-only)
        // ═══════════════════════════════════════════════════════════
        private void RenderSeatMap(PreviewFlightResult flight)
        {
            pnlMapHost.Controls.Clear();
            pnlMapHost.Size = Size.Empty;
            pnlMapHost.Location = new Point(0, 0);
            hScroll.Value = 0;
            vScroll.Value = 0;
            hScroll.Visible = false;
            vScroll.Visible = false;

            UserControl map = ResolveAircraftUI(flight.AircraftModel);

            if (map == null)
            {
                lblMapHint.Text = $"No seat map is registered for \"{flight.AircraftModel}\".\n"
                                + "Seat occupancy is shown in the summary panel on the left.";
                lblLegend.Text = "";
                return;
            }

            lblMapHint.Text =
                $"Viewing:  {flight.AircraftName}   {flight.Route}   "
              + $"({flight.AircraftModel})   Gate {flight.Gate}";

            if (map is ISeatMap iMap)
            {
                var saved = BookingRepository.LoadSavedPassengers(flight.FlightID);
                if (saved.Count > 0) iMap.LoadSavedPassengers(saved);
            }

            int totalSeats = CountDescendantButtons(map);
            int occupied = _occupancy.Count;
            int available = Math.Max(0, totalSeats - occupied);

            lblTotalSeats.Text = $"Total seats:   {totalSeats}";
            lblOccupied.Text = $"● Occupied:    {occupied}";
            lblAvailable.Text = $"● Available:   {available}";

            if (totalSeats > 0)
                pnlOccupancyFill.Width = Math.Min((int)(260.0 * occupied / totalSeats), 260);

            lblLegend.Text = "   ■ Occupied   □ Available   (hover a seat to see passenger)";

            DisableSeatButtonsAndAddTooltips(map);

            map.Dock = DockStyle.None;
            map.AutoSize = false;
            map.Location = new Point(0, 0);
            pnlMapHost.Controls.Add(map);

            this.BeginInvoke((Action)(() =>
            {
                map.PerformLayout();
                map.Update();

                int mapW = map.Width > 10 ? map.Width : map.PreferredSize.Width;
                int mapH = map.Height > 10 ? map.Height : map.PreferredSize.Height;

                pnlMapHost.Size = new Size(mapW, mapH);
                UpdateScrollBars();
            }));
        }

        private void DisableSeatButtonsAndAddTooltips(Control parent)
        {
            var tip = new ToolTip { AutoPopDelay = 6000, InitialDelay = 300 };
            AttachTooltipsRecursive(parent, tip);
        }

        private void AttachTooltipsRecursive(Control parent, ToolTip tip)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    btn.Click += (s, e) => { };
                    btn.Cursor = Cursors.Default;

                    string seatLabel = btn.Tag?.ToString() ?? btn.Text;
                    var occupant = _occupancy.FirstOrDefault(o =>
                        string.Equals(o.SeatLabel, seatLabel, StringComparison.OrdinalIgnoreCase));

                    if (occupant != null)
                        tip.SetToolTip(btn,
                            $"Seat {occupant.SeatLabel}\n"
                          + $"{occupant.LastName}, {occupant.FirstName}\n"
                          + $"Ref: {occupant.ReferenceNo}  |  {occupant.SeatClass}");
                    else if (!string.IsNullOrEmpty(seatLabel))
                        tip.SetToolTip(btn, $"Seat {seatLabel}  —  Available");
                }

                AttachTooltipsRecursive(c, tip);
            }
        }

        // ═══════════════════════════════════════════════════════════
        // CLEAR
        // ═══════════════════════════════════════════════════════════
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _currentFlight = null;
            _occupancy.Clear();

            txtFlightSearch.Text = SearchPlaceholder;
            txtFlightSearch.ForeColor = Color.FromArgb(180, 210, 255);
            HideFlightDropdown();

            lblSummaryFlight.Text = "No flight selected";
            lblSummaryRoute.Text = "";
            lblSummaryDate.Text = "";
            lblSummaryGate.Text = "";
            lblSummaryModel.Text = "";
            pnlStatusBadge.BackColor = Color.FromArgb(200, 200, 200);
            lblStatusText.Text = "—";
            lblStatusText.ForeColor = Color.White;
            lblTotalSeats.Text = "";
            lblOccupied.Text = "";
            lblAvailable.Text = "";
            pnlOccupancyFill.Width = 0;
            lstPassengers.Items.Clear();
            lblPassengerHeader.Text = "BOOKED PASSENGERS";

            pnlMapHost.Controls.Clear();
            pnlMapHost.Size = Size.Empty;
            pnlMapHost.Location = new Point(0, 0);
            hScroll.Visible = false;
            vScroll.Visible = false;
            hScroll.Value = 0;
            vScroll.Value = 0;
            lblMapHint.Text = "Search for a flight above to display its seat map.";
            lblLegend.Text = "";
        }

        // ═══════════════════════════════════════════════════════════
        // OWNER-DRAW — passenger list rows
        // ═══════════════════════════════════════════════════════════
        private void LstPassengers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstPassengers.Items.Count) return;

            var p = lstPassengers.Items[e.Index] as SeatOccupancyInfo;
            if (p == null) return;

            bool selected = (e.State & DrawItemState.Selected) != 0;
            e.Graphics.FillRectangle(
                new SolidBrush(selected ? Color.FromArgb(232, 241, 255) : Color.White),
                e.Bounds);

            Color stripe = p.SeatClass == "Business" ? Color.FromArgb(210, 150, 0)
                         : p.SeatClass == "Comfort" ? Color.FromArgb(30, 100, 180)
                                                      : Color.FromArgb(40, 167, 69);

            e.Graphics.FillRectangle(new SolidBrush(stripe),
                new Rectangle(e.Bounds.X, e.Bounds.Y + 4, 4, e.Bounds.Height - 8));

            e.Graphics.DrawString(
                $"{p.LastName}, {p.FirstName}",
                new Font("Segoe UI", 8.5f, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(25, 30, 40)),
                new RectangleF(e.Bounds.X + 12, e.Bounds.Y + 4, e.Bounds.Width - 70, 18));

            e.Graphics.DrawString(
                p.SeatLabel,
                new Font("Segoe UI", 9f, FontStyle.Bold),
                new SolidBrush(stripe),
                new RectangleF(e.Bounds.Right - 60, e.Bounds.Y + 4, 54, 18));

            e.Graphics.DrawString(
                $"Ref: {p.ReferenceNo}  •  {p.SeatClass}",
                new Font("Segoe UI", 7.5f),
                new SolidBrush(Color.FromArgb(110, 120, 140)),
                new RectangleF(e.Bounds.X + 12, e.Bounds.Y + 24, e.Bounds.Width - 16, 16));

            e.Graphics.DrawLine(
                new Pen(Color.FromArgb(210, 215, 225)),
                e.Bounds.X, e.Bounds.Bottom - 1,
                e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        // ═══════════════════════════════════════════════════════════
        // AIRCRAFT UI RESOLVER
        // ═══════════════════════════════════════════════════════════
        private static UserControl ResolveAircraftUI(string model)
        {
            if (string.IsNullOrWhiteSpace(model)) return null;
            string n = model.ToLower().Replace(" ", "").Replace("-", "");

            if (n.Contains("atr") && n.Contains("72")) return new ATR_72_600();
            if (n.Contains("a319")) return new Airbus_A319_100();
            if (n.Contains("a321neo")) return new Airbus_A321neo();
            if (n.Contains("a321")) return new Airbus_A321_200();
            if (n.Contains("a320neo")) return new Airbus_A320neo();
            if (n.Contains("a320")) return new Airbus_A320_200();
            if (n.Contains("737") && n.Contains("900er")) return new Boeing_737_900ER();
            if (n.Contains("737") && n.Contains("900")) return new Boeing_737_900ER();
            if (n.Contains("737") && n.Contains("800")) return new Boeing_737_800();
            if (n.Contains("737") && n.Contains("700")) return new Boeing_737_700();
            if (n.Contains("dhc") && n.Contains("8")) return new DHC_8_400();

            return null;
        }

        // ═══════════════════════════════════════════════════════════
        // UTILITY
        // ═══════════════════════════════════════════════════════════
        private static int CountDescendantButtons(Control parent)
        {
            int count = 0;
            foreach (Control c in parent.Controls)
                count += (c is Button) ? 1 : CountDescendantButtons(c);
            return count;
        }
    }

    // ═══════════════════════════════════════════════════════════════
    // DATA CLASSES
    // ═══════════════════════════════════════════════════════════════
    internal class PreviewFlightResult
    {
        public int FlightID { get; set; }
        public string Route { get; set; }
        public string CityRoute { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Gate { get; set; }
        public string AircraftName { get; set; }
        public string AircraftModel { get; set; }
        public int AircraftStatus { get; set; }

        public override string ToString()
            => $"{AircraftName}  {Route}  —  {Departure:MMM d  h:mm tt}  ({AircraftModel})";
    }

    internal class SeatOccupancyInfo
    {
        public int PassengerID { get; set; }
        public int PassengerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SeatClass { get; set; }
        public string SeatLabel { get; set; }
        public string ReferenceNo { get; set; }
    }
}