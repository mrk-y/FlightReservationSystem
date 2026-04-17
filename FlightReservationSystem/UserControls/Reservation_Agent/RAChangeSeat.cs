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
    public partial class RAChangeSeat : UserControl
    {
        // ═══════════════════════════════════════════════════════════
        // Palette
        // ═══════════════════════════════════════════════════════════
        private static readonly Color NavyDark = Color.FromArgb(10, 40, 100);
        private static readonly Color NavyMid = Color.FromArgb(20, 55, 120);
        private static readonly Color AccentOrange = Color.FromArgb(255, 165, 0);
        private static readonly Color AccentGreen = Color.FromArgb(40, 167, 69);
        private static readonly Color AccentRed = Color.FromArgb(220, 53, 69);
        private static readonly Color PanelLight = Color.FromArgb(245, 247, 250);
        private static readonly Color CardWhite = Color.White;
        private static readonly Color BorderGray = Color.FromArgb(210, 215, 225);
        private static readonly Color TextDark = Color.FromArgb(25, 30, 40);
        private static readonly Color TextMuted = Color.FromArgb(110, 120, 140);
        private static readonly Color TextHint = Color.FromArgb(180, 210, 255);
        private static readonly Color HighlightRow = Color.FromArgb(232, 241, 255);

        private static readonly Color StatusBoarding = Color.FromArgb(255, 202, 7);
        private static readonly Color StatusInFlight = Color.FromArgb(0, 38, 184);
        private static readonly Color StatusLanded = Color.FromArgb(52, 167, 49);
        private static readonly Color StatusDelayed = Color.FromArgb(255, 113, 27);
        private static readonly Color StatusCancelled = Color.FromArgb(220, 33, 49);
        private static readonly Color StatusGray = Color.FromArgb(102, 102, 102);

        // ═══════════════════════════════════════════════════════════
        // State
        // ═══════════════════════════════════════════════════════════
        private List<PassengerSearchResult> _allPassengers = new List<PassengerSearchResult>();
        private PassengerSearchResult _selected = null;
        private string _pendingNewSeat = null;
        private Button _pendingSeatBtn = null;
        private Color _pendingSeatBtnOriginalColor;
        private Color _pendingSeatBtnOriginalBorderColor;

        // ═══════════════════════════════════════════════════════════
        // UI fields
        // ═══════════════════════════════════════════════════════════
        private Panel _pnlSearchBar;
        private TextBox _txtPassengerSearch;
        private TextBox _txtFlightSearch;
        private Button _btnSearch;
        private Button _btnClear;

        private Panel _pnlScrollOuter;
        private Panel _pnlBody;

        private Panel _pnlLeft;
        private Panel _pnlCenter;
        private Panel _pnlRight;

        private ListBox _lstPassengers;
        private Label _lblListCount;
        private Label _lblNoResults;

        private Panel _pnlMapHost;
        private Label _lblMapHint;
        private Label _lblNewSeatChosen;

        private Label _lblInfoName, _lblInfoRef, _lblInfoFlight,
                      _lblInfoAircraft, _lblInfoCurrentSeat,
                      _lblInfoClass, _lblInfoSpecial;
        private Panel _pnlClassBadge;
        private Label _lblClassBadgeText;
        private Panel _pnlStatusBadge;
        private Label _lblStatusBadgeText;

        private Panel _pnlActions;
        private Button _btnConfirm;
        private Label _lblActionHint;
        private Label _lblStatus;

        private ListBox _lstFlights;
        private Panel _lstFlightsPanel;

        // ═══════════════════════════════════════════════════════════
        // Constructor
        // ═══════════════════════════════════════════════════════════
        public RAChangeSeat()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = PanelLight;
            this.Font = new Font("Segoe UI", 9f);
            BuildUI();
            LoadAllPassengers();
        }

        // ═══════════════════════════════════════════════════════════
        // BUILD UI
        // ═══════════════════════════════════════════════════════════
        private void BuildUI()
        {
            BuildStatusBanner();
            BuildActionBar();
            BuildSearchBar();
            BuildScrollBody();
        }

        // ── Status banner ──────────────────────────────────────────
        private void BuildStatusBanner()
        {
            _lblStatus = new Label
            {
                Dock = DockStyle.Top,
                Height = 0,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = AccentGreen
            };
            this.Controls.Add(_lblStatus);
        }

        // ── Bottom action bar ──────────────────────────────────────
        private void BuildActionBar()
        {
            _pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 54,
                BackColor = Color.FromArgb(238, 240, 245),
                Padding = new Padding(20, 9, 20, 9)
            };

            _lblActionHint = new Label
            {
                Font = new Font("Segoe UI", 8.5f, FontStyle.Italic),
                ForeColor = TextMuted,
                AutoSize = false,
                Height = 36,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Search a passenger, then pick a new seat on the map."
            };

            _btnClear = new Button
            {
                Text = "✕  Clear",
                Font = new Font("Segoe UI", 9f),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                Size = new Size(110, 36),
                Cursor = Cursors.Hand
            };
            _btnClear.FlatAppearance.BorderSize = 0;
            _btnClear.Click += BtnClear_Click;

            _btnConfirm = new Button
            {
                Text = "✔  Confirm Change",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(160, 170, 180),
                ForeColor = Color.White,
                Size = new Size(160, 36),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            _btnConfirm.FlatAppearance.BorderSize = 0;
            _btnConfirm.Click += BtnConfirm_Click;

            _pnlActions.Controls.AddRange(new Control[] { _lblActionHint, _btnClear, _btnConfirm });
            _pnlActions.Resize += (s, e) => LayoutActionBar();
            _pnlActions.HandleCreated += (s, e) => LayoutActionBar();

            this.Controls.Add(_pnlActions);
        }

        private void LayoutActionBar()
        {
            if (_pnlActions.Width <= 0) return;
            _btnConfirm.Location = new Point(_pnlActions.Width - _btnConfirm.Width - 20, 9);
            _btnClear.Location = new Point(_btnConfirm.Left - _btnClear.Width - 8, 9);
            _lblActionHint.Width = _btnClear.Left - 4;
            _lblActionHint.Location = new Point(0, 9);
        }

        // ── Top navy search bar ────────────────────────────────────
        private void BuildSearchBar()
        {
            _pnlSearchBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = NavyDark,
                Padding = new Padding(0)
            };

            var lblTitle = new Label
            {
                Text = "✈  Change Seat",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(160, 66),
                Location = new Point(16, 12),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblP = new Label
            {
                Text = "PASSENGER",
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = TextHint,
                AutoSize = true,
                Location = new Point(190, 14)
            };
            _txtPassengerSearch = MakeSearchBox(new Point(190, 34), 230, "Name, reference…");
            _txtPassengerSearch.TextChanged += (s, e) =>
                FilterAndShowPassengers(_txtPassengerSearch.Text);

            var div1 = new Panel
            {
                BackColor = Color.FromArgb(60, 80, 130),
                Size = new Size(1, 44),
                Location = new Point(434, 23)
            };

            var lblF = new Label
            {
                Text = "FLIGHT / ROUTE",
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = TextHint,
                AutoSize = true,
                Location = new Point(448, 14)
            };
            _txtFlightSearch = MakeSearchBox(new Point(448, 34), 230, "Aircraft or IATA…");
            _txtFlightSearch.Enabled = false;
            _txtFlightSearch.TextChanged += FlightSearch_TextChanged;

            var div2 = new Panel
            {
                BackColor = Color.FromArgb(60, 80, 130),
                Size = new Size(1, 44),
                Location = new Point(692, 23)
            };

            _btnSearch = new Button
            {
                Text = "🔍  Search",
                Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                BackColor = AccentOrange,
                ForeColor = Color.White,
                Size = new Size(130, 36),
                Location = new Point(706, 27),
                Cursor = Cursors.Hand
            };
            _btnSearch.FlatAppearance.BorderSize = 0;
            _btnSearch.Click += (s, e) => FilterAndShowPassengers(_txtPassengerSearch.Text);

            _pnlSearchBar.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblP, _txtPassengerSearch,
                div1,
                lblF, _txtFlightSearch,
                div2,
                _btnSearch
            });

            this.Controls.Add(_pnlSearchBar);
        }

        // ── Scroll body ────────────────────────────────────────────
        private void BuildScrollBody()
        {
            _pnlScrollOuter = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = PanelLight
            };

            _pnlBody = new Panel
            {
                Dock = DockStyle.None,
                Location = new Point(0, 0),
                BackColor = PanelLight
            };

            _pnlScrollOuter.Resize += (s, e) => SizeBodyPanel();
            _pnlScrollOuter.HandleCreated += (s, e) => SizeBodyPanel();

            _pnlRight = new Panel
            {
                Dock = DockStyle.Right,
                Width = 280,
                BackColor = CardWhite,
                Padding = new Padding(14, 90, 14, 90)
            };
            BuildInfoCard(_pnlRight);

            _pnlLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 300,
                BackColor = CardWhite,
                Padding = new Padding(0, 90, 0, 0)
            };
            BuildPassengerList(_pnlLeft);

            var divL = new Panel { Dock = DockStyle.Left, Width = 1, BackColor = BorderGray };
            var divR = new Panel { Dock = DockStyle.Right, Width = 1, BackColor = BorderGray };

            _pnlCenter = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = PanelLight,
                AutoScroll = false,
                Padding = new Padding(20, 110, 20, 70)
            };
            BuildCenterArea(_pnlCenter);

            _pnlBody.Controls.Add(_pnlCenter);
            _pnlBody.Controls.Add(divR);
            _pnlBody.Controls.Add(_pnlRight);
            _pnlBody.Controls.Add(divL);
            _pnlBody.Controls.Add(_pnlLeft);

            _pnlScrollOuter.Controls.Add(_pnlBody);
            this.Controls.Add(_pnlScrollOuter);
        }

        private void SizeBodyPanel()
        {
            if (_pnlScrollOuter == null || _pnlBody == null) return;
            int w = Math.Max(1100, _pnlScrollOuter.ClientSize.Width);
            int h = Math.Max(1, _pnlScrollOuter.ClientSize.Height);
            _pnlBody.Size = new Size(w, h);
        }

        // ── Passenger list (left panel) ────────────────────────────
        private void BuildPassengerList(Panel host)
        {
            var pnlHdr = new Panel
            {
                Dock = DockStyle.Top,
                Height = 38,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(10, 0, 10, 0)
            };
            _lblListCount = new Label
            {
                Dock = DockStyle.Fill,
                Text = "PASSENGERS",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = TextMuted,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlHdr.Controls.Add(_lblListCount);

            var sep = new Panel { Dock = DockStyle.Top, Height = 1, BackColor = BorderGray };

            _lstPassengers = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9.5f),
                BackColor = CardWhite,
                ForeColor = TextDark,
                ItemHeight = 58,
                DrawMode = DrawMode.OwnerDrawFixed
            };
            _lstPassengers.DrawItem += LstPassengers_DrawItem;
            _lstPassengers.SelectedIndexChanged += (s, e) =>
            {
                if (_lstPassengers.SelectedItem is PassengerSearchResult p)
                    SelectPassenger(p);
            };

            _lblNoResults = new Label
            {
                Text = "No passengers found.",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = TextMuted,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            host.Controls.Add(_lstPassengers);
            host.Controls.Add(_lblNoResults);
            host.Controls.Add(sep);
            host.Controls.Add(pnlHdr);
        }

        // ── Center seat map area ───────────────────────────────────
        private void BuildCenterArea(Panel host)
        {
            var pnlTitleRow = new Panel
            {
                Dock = DockStyle.Top,
                Height = 38,
                BackColor = PanelLight
            };
            var lblResultsTitle = new Label
            {
                Text = "Seat Map",
                Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold),
                ForeColor = NavyDark,
                AutoSize = true,
                Location = new Point(0, 8)
            };
            pnlTitleRow.Controls.Add(lblResultsTitle);

            _lblNewSeatChosen = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = AccentGreen,
                AutoSize = false,
                Visible = false,
                Dock = DockStyle.Top,
                Height = 22,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(2, 0, 0, 0)
            };

            _lblMapHint = new Label
            {
                Text = "Select a passenger on the left, then pick a seat below.",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic),
                ForeColor = TextMuted,
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(2, 0, 0, 0)
            };

            _lstFlightsPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 0,
                BackColor = PanelLight
            };
            _lstFlights = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9f),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            _lstFlights.SelectedIndexChanged += LstFlights_SelectedIndexChanged;
            _lstFlightsPanel.Controls.Add(_lstFlights);

            _pnlMapHost = new Panel
            {
                Dock = DockStyle.None,
                Location = new Point(0, 0),
                BackColor = PanelLight,
                AutoSize = false,
                
            };

            var pnlMapScroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = PanelLight,
                Padding = new Padding(0, 0, 0, 0)
            };
            pnlMapScroll.Controls.Add(_pnlMapHost);

            host.Controls.Add(pnlMapScroll);
            host.Controls.Add(_lstFlightsPanel);
            host.Controls.Add(_lblNewSeatChosen);
            host.Controls.Add(_lblMapHint);
            host.Controls.Add(pnlTitleRow);
        }

        // ── Flight dropdown ────────────────────────────────────────
        private void LstFlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstFlights.SelectedItem is FlightSearchResult f)
            {
                _txtFlightSearch.Text = $"{f.AircraftName}  {f.Route}";
                HideFlightDropdown();
                LoadSeatMap(f);
            }
        }

        private void HideFlightDropdown()
        {
            _lstFlights.Visible = false;
            _lstFlightsPanel.Height = 0;
        }

        // ── Right info card ────────────────────────────────────────
        private void BuildInfoCard(Panel host)
        {
            var lblHdr = new Label
            {
                Text = "SELECTED PASSENGER",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = TextMuted,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            _pnlClassBadge = new Panel { Size = new Size(88, 22), Location = new Point(0, 18) };
            _lblClassBadgeText = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = TextDark
            };
            _pnlClassBadge.Controls.Add(_lblClassBadgeText);

            _pnlStatusBadge = new Panel { Size = new Size(96, 22), Location = new Point(96, 18) };
            _lblStatusBadgeText = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.White
            };
            _pnlStatusBadge.Controls.Add(_lblStatusBadgeText);

            _lblInfoName = InfoLabel("", 12f, FontStyle.Bold, TextDark, new Point(0, 46));
            _lblInfoRef = InfoLabel("", 8.5f, FontStyle.Regular, TextMuted, new Point(0, 68));
            _lblInfoFlight = InfoLabel("", 9f, FontStyle.Regular, TextDark, new Point(0, 88));
            _lblInfoAircraft = InfoLabel("", 9f, FontStyle.Regular, TextDark, new Point(0, 106));
            _lblInfoCurrentSeat = InfoLabel("", 11f, FontStyle.Bold, NavyDark, new Point(0, 126));
            _lblInfoClass = InfoLabel("", 9f, FontStyle.Regular, TextDark, new Point(0, 150));
            _lblInfoSpecial = InfoLabel("", 8.5f, FontStyle.Regular,
                Color.FromArgb(180, 80, 20), new Point(0, 170));

            var sep = new Panel
            {
                BackColor = BorderGray,
                Size = new Size(240, 1),
                Location = new Point(0, 192)
            };

            host.Controls.AddRange(new Control[]
            {
                lblHdr, _pnlClassBadge, _pnlStatusBadge,
                _lblInfoName, _lblInfoRef, _lblInfoFlight,
                _lblInfoAircraft, _lblInfoCurrentSeat,
                _lblInfoClass, _lblInfoSpecial, sep
            });

            SetInfoEmpty();
        }

        // ═══════════════════════════════════════════════════════════
        // DATA
        // ═══════════════════════════════════════════════════════════
        private void LoadAllPassengers()
        {
            _allPassengers.Clear();

            const string sql = @"
                SELECT
                bp.PassengerID, bp.PassengerNo,
                    bp.FirstName, bp.LastName,
                    bp.SeatClass, bp.SeatLabel,
                    bp.HasPeanutAllergy, bp.NeedsWheelchair, bp.IsUnaccompaniedMinor,
                    b.ReferenceNo, b.BookingID, b.FlightID,
                    f.Departure, f.Arrival, f.Gate,
                    ao.IATA AS OriginIATA, ad.IATA AS DestIATA,
                    ao.DisplayCity AS OriginCity, ad.DisplayCity AS DestCity,
                    a.Aircraft AS AircraftName,
                    m.Model    AS AircraftModel,
                    a.Status   AS AircraftStatus
                FROM  BookingPassengers bp
                INNER JOIN Bookings      b  ON b.BookingID  = bp.BookingID
                INNER JOIN Flights       f  ON f.FlightID   = b.FlightID
                LEFT  JOIN Aircrafts     a  ON a.AircraftID = f.Aircraft
                LEFT  JOIN AircraftModels m ON m.ModelID    = a.Model
                LEFT  JOIN Airports      ao ON ao.AirportID = f.Origin
                LEFT  JOIN Airports      ad ON ad.AirportID = f.Destination
                WHERE b.IsActive = 1
                  AND f.Departure > GETDATE()
                ORDER BY bp.LastName, bp.FirstName";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (rdr["PassengerID"] == DBNull.Value) continue;
                            try { _allPassengers.Add(ReadPassenger(rdr)); }
                            catch (Exception rowEx)
                            {
                                System.Diagnostics.Debug.WriteLine(
                                    $"[RAChangeSeat] Skipped row: {rowEx.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load passengers:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FilterAndShowPassengers(_txtPassengerSearch?.Text ?? "");
        }

        private static PassengerSearchResult ReadPassenger(SqlDataReader r)
        {
            string Str(string col) =>
                r[col] == DBNull.Value ? "" : r[col].ToString();
            bool Bool(string col) =>
                r[col] != DBNull.Value && Convert.ToBoolean(r[col]);
            int Int(string col, int fallback = 0) =>
                r[col] == DBNull.Value ? fallback : Convert.ToInt32(r[col]);

            return new PassengerSearchResult
            {
                BookingPassengerID = Int("PassengerID"),
                PassengerNo = Int("PassengerNo"),
                FirstName = Str("FirstName"),
                LastName = Str("LastName"),
                SeatClass = Str("SeatClass"),
                SeatLabel = Str("SeatLabel") == "" ? "(none)" : Str("SeatLabel"),
                HasPeanutAllergy = Bool("HasPeanutAllergy"),
                NeedsWheelchair = Bool("NeedsWheelchair"),
                IsUnaccompaniedMinor = Bool("IsUnaccompaniedMinor"),
                ReferenceNo = Str("ReferenceNo"),
                BookingID = Int("BookingID"),
                FlightID = Int("FlightID"),
                Departure = r["Departure"] == DBNull.Value
                                        ? DateTime.MinValue
                                        : Convert.ToDateTime(r["Departure"]),
                Arrival = r["Arrival"] == DBNull.Value
                                        ? DateTime.MinValue
                                        : Convert.ToDateTime(r["Arrival"]),
                Gate = Str("Gate"),
                OriginIATA = Str("OriginIATA"),
                DestIATA = Str("DestIATA"),
                OriginCity = Str("OriginCity"),
                DestCity = Str("DestCity"),
                AircraftName = Str("AircraftName"),
                AircraftModel = Str("AircraftModel") == "" ? "Unknown" : Str("AircraftModel"),
                AircraftStatus = Int("AircraftStatus", 4)
            };
        }

        private void FilterAndShowPassengers(string query)
        {
            string q = (query ?? "").Trim().ToLower();
            if (q == "name, reference…") q = "";

            var list = string.IsNullOrEmpty(q)
                ? _allPassengers
                : _allPassengers.Where(p =>
                      p.FullName.ToLower().Contains(q) ||
                      p.ReferenceNo.ToLower().Contains(q) ||
                      p.OriginIATA.ToLower().Contains(q) ||
                      p.DestIATA.ToLower().Contains(q) ||
                      p.AircraftName.ToLower().Contains(q))
                  .ToList();

            _lstPassengers.Items.Clear();
            foreach (var p in list) _lstPassengers.Items.Add(p);

            _lblListCount.Text = $"PASSENGERS  ({list.Count})";
            _lblNoResults.Visible = list.Count == 0;
            _lstPassengers.Visible = list.Count > 0;
        }

        // ═══════════════════════════════════════════════════════════
        // PASSENGER SELECTION
        // ═══════════════════════════════════════════════════════════
        private void SelectPassenger(PassengerSearchResult p)
        {
            _selected = p;
            _pendingNewSeat = null;
            ClearPendingSeatHighlight();
            ClearMapHost();

            UpdateInfoCard(p);

            _txtFlightSearch.Enabled = true;
            _txtFlightSearch.BackColor = NavyMid;
            _txtFlightSearch.ForeColor = TextHint;
            _txtFlightSearch.Text = "Aircraft or IATA…";

            _lblMapHint.Text =
                $"Search a flight above, then click a  [{p.SeatClass}]  seat on the map.";

            _lblNewSeatChosen.Visible = false;
            HideFlightDropdown();
            UpdateConfirmButton();
            HideStatus();
        }

        // ═══════════════════════════════════════════════════════════
        // FLIGHT SEARCH
        // ═══════════════════════════════════════════════════════════
        private void FlightSearch_TextChanged(object sender, EventArgs e)
        {
            string q = _txtFlightSearch.Text.Trim();
            if (q == "Aircraft or IATA…" || q.Length < 2)
            {
                HideFlightDropdown();
                return;
            }
            SearchFlights(q);
        }

        private void SearchFlights(string query)
        {
            _lstFlights.Items.Clear();

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
                  AND  f.Departure > GETDATE()
                  AND  (a.Aircraft LIKE @q OR ao.IATA LIKE @q OR ad.IATA LIKE @q
                        OR ao.DisplayCity LIKE @q OR ad.DisplayCity LIKE @q)
                ORDER  BY f.Departure";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@q", $"%{query}%");
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (rdr["FlightID"] == DBNull.Value) continue;
                            _lstFlights.Items.Add(new FlightSearchResult
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

            if (_lstFlights.Items.Count > 0)
            {
                _lstFlights.Visible = true;
                _lstFlightsPanel.Height = Math.Min(_lstFlights.Items.Count * 18 + 10, 120);
            }
            else HideFlightDropdown();
        }

        // ═══════════════════════════════════════════════════════════
        // SEAT MAP
        // ═══════════════════════════════════════════════════════════
        private void LoadSeatMap(FlightSearchResult flight)
        {
            ClearMapHost();
            _pendingNewSeat = null;
            ClearPendingSeatHighlight();
            _lblNewSeatChosen.Visible = false;
            UpdateConfirmButton();

            UserControl map = ResolveAircraftUI(flight.AircraftModel);
            if (map == null)
            {
                _lblMapHint.Text = $"No seat map available for \"{flight.AircraftModel}\".";
                return;
            }

            _lblMapHint.Text =
                $"Showing:  {flight.AircraftName}   {flight.Route}   ({flight.AircraftModel})   Gate {flight.Gate}";

            if (map is ISeatMap iMap)
            {
                var saved = BookingRepository.LoadSavedPassengers(flight.FlightID);
                if (saved.Count > 0) iMap.LoadSavedPassengers(saved);
                WireSeatButtonsRecursive(map, map, flight);
            }

            map.Dock = DockStyle.None;
            map.AutoSize = false;
            map.Location = new Point(10, 10);

            _pnlMapHost.Controls.Add(map);

            this.BeginInvoke((Action)(() =>
            {
                map.PerformLayout();
                map.Update();

                int mapW = map.Width > 10 ? map.Width : map.PreferredSize.Width;
                int mapH = map.Height > 10 ? map.Height : map.PreferredSize.Height;

                _pnlMapHost.Size = new Size(mapW + 20, mapH + 20);
                _pnlMapHost.MinimumSize = _pnlMapHost.Size;

                int required = _pnlLeft.Width + _pnlRight.Width + mapW + 60;
                if (required > _pnlBody.Width)
                    _pnlBody.Width = required;
            }));
        }

        // ── FIX 1: Always recurse into every child, not just non-Button ones ──
        private void WireSeatButtonsRecursive(Control parent,
            UserControl map, FlightSearchResult flight)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    Button cap = btn;
                    cap.Click += (s, e) => SeatMap_SeatClicked(cap, map, flight);
                }
                // Always recurse — buttons may be nested inside sub-panels
                WireSeatButtonsRecursive(c, map, flight);
            }
        }

        private void SeatMap_SeatClicked(Button btn,
            UserControl map, FlightSearchResult flight)
        {
            if (btn == null || _selected == null) return;
            if (btn.Tag is SavedPassengerInfo || btn.Tag is RAPassengerDetails) return;

            string seatLabel = btn.Tag?.ToString() ?? btn.Text;
            if (string.IsNullOrEmpty(seatLabel)) return;

            string seatClass = DetectSeatClass(btn, map);

            if (!string.Equals(_selected.SeatClass, seatClass,
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    $"Seat class mismatch.\n\n" +
                    $"Passenger booked in:  {_selected.SeatClass}\n" +
                    $"Selected seat class:  {seatClass}\n\n" +
                    $"Please select a {_selected.SeatClass} seat.",
                    "Seat Class Mismatch",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string specials = FlagString(_selected.HasPeanutAllergy,
                _selected.NeedsWheelchair, _selected.IsUnaccompaniedMinor);

            var result = MessageBox.Show(
                $"PASSENGER\n" +
                $"  Name:       {_selected.FullName}\n" +
                $"  Reference:  {_selected.ReferenceNo}\n" +
                $"  Specials:   {specials}\n\n" +
                $"SEAT CHANGE\n" +
                $"  Current:  {_selected.SeatLabel}  ({_selected.SeatClass})  on {_selected.AircraftName}\n" +
                $"  New:      {seatLabel}  ({seatClass})  on {flight.AircraftName}  {flight.Route}\n\n" +
                $"Confirm?",
                "Confirm Seat Change",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            ClearPendingSeatHighlight();
            _pendingSeatBtnOriginalColor = btn.BackColor;
            _pendingSeatBtnOriginalBorderColor = btn.FlatAppearance.BorderColor;
            _pendingSeatBtn = btn;

            btn.BackColor = Color.FromArgb(255, 200, 100);
            btn.FlatAppearance.BorderColor = AccentOrange;
            btn.FlatAppearance.BorderSize = 2;

            _pendingNewSeat = seatLabel;
            _lblNewSeatChosen.Text =
                $"✔  New seat selected:  {seatLabel}  ({seatClass})  on {flight.AircraftName}";
            _lblNewSeatChosen.Visible = true;

            UpdateConfirmButton();
        }

        // ═══════════════════════════════════════════════════════════
        // CONFIRM / CLEAR
        // ═══════════════════════════════════════════════════════════
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (_selected == null || string.IsNullOrEmpty(_pendingNewSeat)) return;

            string oldSeat = _selected.SeatLabel;
            string newSeat = _pendingNewSeat;

            if (MessageBox.Show(
                $"Apply seat change?\n\n" +
                $"Passenger:  {_selected.FullName}\n" +
                $"Old Seat:   {oldSeat}\n" +
                $"New Seat:   {newSeat}",
                "Apply Change",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            const string sql = @"
                UPDATE BookingPassengers
                SET    SeatLabel = @newSeat
                WHERE  PassengerID = @id";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@newSeat", newSeat);
                    cmd.Parameters.AddWithValue("@id", _selected.BookingPassengerID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ShowStatus(
                    $"✔  Seat changed — {_selected.FullName}:  {oldSeat}  →  {newSeat}",
                    success: true);

                LoadAllPassengers();
                BtnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update seat:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _selected = null;
            _pendingNewSeat = null;
            ClearPendingSeatHighlight();

            _lstPassengers.ClearSelected();
            _txtPassengerSearch.Text = "";
            _txtFlightSearch.Text = "Aircraft or IATA…";
            _txtFlightSearch.ForeColor = TextHint;
            _txtFlightSearch.Enabled = false;
            HideFlightDropdown();

            SetInfoEmpty();
            ClearMapHost();

            _lblMapHint.Text = "Select a passenger on the left, then pick a seat below.";
            _lblNewSeatChosen.Visible = false;
            _lblActionHint.Text = "Search a passenger, then pick a new seat on the map.";

            SizeBodyPanel();
            UpdateConfirmButton();
        }

        private void ClearPendingSeatHighlight()
        {
            if (_pendingSeatBtn == null) return;
            _pendingSeatBtn.BackColor = _pendingSeatBtnOriginalColor;
            _pendingSeatBtn.FlatAppearance.BorderColor = _pendingSeatBtnOriginalBorderColor;
            _pendingSeatBtn.FlatAppearance.BorderSize = 1;
            _pendingSeatBtn = null;
        }

        private void ClearMapHost()
        {
            _pnlMapHost.Controls.Clear();
            _pnlMapHost.MinimumSize = Size.Empty;
            _pnlMapHost.Size = Size.Empty;
        }

        // ═══════════════════════════════════════════════════════════
        // INFO CARD
        // ═══════════════════════════════════════════════════════════
        private void UpdateInfoCard(PassengerSearchResult p)
        {
            _lblInfoName.Text = p.FullName;
            _lblInfoRef.Text = $"Ref: {p.ReferenceNo}  •  Pax {p.PassengerNo}";
            _lblInfoFlight.Text = $"✈  {p.OriginIATA} → {p.DestIATA}";
            _lblInfoAircraft.Text = $"{p.AircraftName}  |  Gate {p.Gate}";
            _lblInfoCurrentSeat.Text = $"Seat:  {p.SeatLabel}";
            _lblInfoClass.Text = p.Departure == DateTime.MinValue
                                           ? "" : $"{p.Departure:ddd MMM d  h:mm tt}";
            _lblInfoSpecial.Text = BuildSpecialText(p);

            switch (p.SeatClass)
            {
                case "Business":
                    _pnlClassBadge.BackColor = Color.FromArgb(255, 243, 205);
                    _lblClassBadgeText.Text = "BUSINESS";
                    break;
                case "Comfort":
                    _pnlClassBadge.BackColor = Color.FromArgb(209, 231, 255);
                    _lblClassBadgeText.Text = "COMFORT";
                    break;
                default:
                    _pnlClassBadge.BackColor = Color.FromArgb(198, 239, 206);
                    _lblClassBadgeText.Text = "ECONOMY";
                    break;
            }

            ApplyStatusBadge(p.AircraftStatus);
            _lblActionHint.Text =
                $"Passenger selected. Search the target flight, then click a {p.SeatClass} seat.";
        }

        private void ApplyStatusBadge(int status)
        {
            string text; Color back; Color fore = Color.White;
            switch (status)
            {
                case 5: text = "BOARDING"; back = StatusBoarding; fore = Color.Black; break;
                case 6: text = "IN FLIGHT"; back = StatusInFlight; break;
                case 7: text = "LANDED"; back = StatusLanded; break;
                case 8: text = "DELAYED"; back = StatusDelayed; break;
                case 9: text = "CANCELLED"; back = StatusCancelled; break;
                case 4: text = "SCHEDULED"; back = Color.FromArgb(220, 235, 255); fore = NavyDark; break;
                default: text = "NOT READY"; back = StatusGray; break;
            }
            _pnlStatusBadge.BackColor = back;
            _lblStatusBadgeText.Text = text;
            _lblStatusBadgeText.ForeColor = fore;
        }

        private void SetInfoEmpty()
        {
            _lblInfoName.Text =
            _lblInfoRef.Text =
            _lblInfoFlight.Text =
            _lblInfoAircraft.Text =
            _lblInfoCurrentSeat.Text =
            _lblInfoClass.Text =
            _lblInfoSpecial.Text = "";
            _lblInfoName.Text = "No passenger selected";

            _pnlClassBadge.BackColor = Color.FromArgb(230, 230, 230);
            _lblClassBadgeText.Text = "—";
            _pnlStatusBadge.BackColor = Color.FromArgb(200, 200, 200);
            _lblStatusBadgeText.Text = "—";
            _lblStatusBadgeText.ForeColor = Color.White;
        }

        private void UpdateConfirmButton()
        {
            bool ready = _selected != null && !string.IsNullOrEmpty(_pendingNewSeat);
            _btnConfirm.Enabled = ready;
            _btnConfirm.BackColor = ready ? AccentGreen : Color.FromArgb(160, 170, 180);
        }

        private void ShowStatus(string text, bool success)
        {
            _lblStatus.Text = text;
            _lblStatus.BackColor = success ? AccentGreen : AccentRed;
            _lblStatus.Height = 34;
        }

        private void HideStatus() => _lblStatus.Height = 0;

        // ═══════════════════════════════════════════════════════════
        // OWNER-DRAW passenger rows
        // ═══════════════════════════════════════════════════════════
        private void LstPassengers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _lstPassengers.Items.Count) return;
            var p = _lstPassengers.Items[e.Index] as PassengerSearchResult;
            if (p == null) return;

            bool sel = (e.State & DrawItemState.Selected) != 0;
            e.Graphics.FillRectangle(
                new SolidBrush(sel ? HighlightRow : CardWhite), e.Bounds);

            Color stripe = p.SeatClass == "Business" ? Color.FromArgb(210, 150, 0)
                         : p.SeatClass == "Comfort" ? Color.FromArgb(30, 100, 180)
                         : AccentGreen;

            e.Graphics.FillRectangle(new SolidBrush(stripe),
                new Rectangle(e.Bounds.X, e.Bounds.Y + 4, 4, e.Bounds.Height - 8));

            e.Graphics.DrawString(p.FullName,
                new Font("Segoe UI", 9.5f, FontStyle.Bold), new SolidBrush(TextDark),
                new RectangleF(e.Bounds.X + 12, e.Bounds.Y + 4, e.Bounds.Width - 80, 20));

            e.Graphics.DrawString(p.SeatLabel,
                new Font("Segoe UI", 9f, FontStyle.Bold), new SolidBrush(stripe),
                new RectangleF(e.Bounds.Right - 70, e.Bounds.Y + 4, 64, 20));

            e.Graphics.DrawString(
                $"{p.ReferenceNo}  •  {p.SeatClass}",
                new Font("Segoe UI", 8f), new SolidBrush(TextMuted),
                new RectangleF(e.Bounds.X + 12, e.Bounds.Y + 26, e.Bounds.Width - 16, 16));

            e.Graphics.DrawString(
                $"{p.OriginIATA} → {p.DestIATA}  |  {p.Departure:MMM d  h:mm tt}",
                new Font("Segoe UI", 8f), new SolidBrush(TextMuted),
                new RectangleF(e.Bounds.X + 12, e.Bounds.Y + 42, e.Bounds.Width - 16, 14));

            Color dot = StatusDotColor(p.AircraftStatus);
            e.Graphics.FillEllipse(new SolidBrush(dot),
                new Rectangle(e.Bounds.Right - 14, e.Bounds.Y + 8, 8, 8));

            e.Graphics.DrawLine(new Pen(BorderGray),
                e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        private Color StatusDotColor(int status)
        {
            switch (status)
            {
                case 5: return StatusBoarding;
                case 6: return StatusInFlight;
                case 7: return StatusLanded;
                case 8: return StatusDelayed;
                case 9: return StatusCancelled;
                case 4: return Color.FromArgb(100, 180, 100);
                default: return StatusGray;
            }
        }

        // ═══════════════════════════════════════════════════════════
        // FIX 2: SEAT CLASS DETECTION — walk up parent chain first,
        //        then fall back to recursive descendant-button count
        // ═══════════════════════════════════════════════════════════
        private static string DetectSeatClass(Button btn, UserControl map)
        {
            // Walk up the button's own parent chain looking for a named cabin panel
            Control current = btn.Parent;
            while (current != null && current != map)
            {
                if (current is Panel p)
                {
                    switch (p.Name)
                    {
                        case "panel2": return "Business";
                        case "panel1": return "Comfort";
                        case "panel3": return "Economy";
                    }
                }
                current = current.Parent;
            }

            // Fallback: top-level panels ordered by total descendant button count
            // (fewest buttons = smallest cabin = Business, then Comfort, then Economy)
            var cabinPanels = map.Controls
                .OfType<Panel>()
                .Where(p => CountDescendantButtons(p) > 0)
                .OrderBy(p => CountDescendantButtons(p))
                .ToList();

            for (int i = 0; i < cabinPanels.Count; i++)
            {
                if (ContainsDescendant(cabinPanels[i], btn))
                {
                    if (i == 0) return "Business";
                    if (i == 1) return "Comfort";
                    return "Economy";
                }
            }

            return "Economy";
        }

        // Counts ALL buttons anywhere inside a control tree
        private static int CountDescendantButtons(Control parent)
        {
            int count = 0;
            foreach (Control c in parent.Controls)
            {
                if (c is Button) count++;
                else count += CountDescendantButtons(c);
            }
            return count;
        }

        private static bool ContainsDescendant(Control parent, Control target)
        {
            foreach (Control c in parent.Controls)
                if (c == target || ContainsDescendant(c, target)) return true;
            return false;
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
        // HELPERS
        // ═══════════════════════════════════════════════════════════
        private TextBox MakeSearchBox(Point loc, int width, string placeholder)
        {
            var tb = new TextBox
            {
                Font = new Font("Segoe UI", 10f),
                BorderStyle = BorderStyle.None,
                BackColor = NavyMid,
                ForeColor = TextHint,
                Location = loc,
                Width = width,
                Text = placeholder
            };
            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == placeholder) { tb.Text = ""; tb.ForeColor = Color.White; }
            };
            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = TextHint;
                }
            };
            return tb;
        }

        private static Label InfoLabel(string text, float size,
            FontStyle style, Color color, Point loc)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                AutoSize = true,
                Location = loc
            };
        }

        private static string FlagString(bool peanut, bool wchr, bool umnr)
        {
            var parts = new[]
            {
                peanut ? "Peanut Allergy"     : null,
                wchr   ? "Wheelchair"          : null,
                umnr   ? "Unaccompanied Minor" : null
            }.Where(f => f != null).ToArray();
            return parts.Length > 0 ? string.Join(", ", parts) : "None";
        }

        private static string BuildSpecialText(PassengerSearchResult p)
        {
            string flags = FlagString(p.HasPeanutAllergy,
                p.NeedsWheelchair, p.IsUnaccompaniedMinor);
            return flags != "None" ? $"⚠  {flags}" : "";
        }
    }

    // ═══════════════════════════════════════════════════════════════
    // DATA CLASSES
    // ═══════════════════════════════════════════════════════════════
    internal class PassengerSearchResult
    {
        public int BookingPassengerID { get; set; }
        public int PassengerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SeatClass { get; set; }
        public string SeatLabel { get; set; }
        public bool HasPeanutAllergy { get; set; }
        public bool NeedsWheelchair { get; set; }
        public bool IsUnaccompaniedMinor { get; set; }
        public string ReferenceNo { get; set; }
        public int BookingID { get; set; }
        public int FlightID { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Gate { get; set; }
        public string OriginIATA { get; set; }
        public string DestIATA { get; set; }
        public string OriginCity { get; set; }
        public string DestCity { get; set; }
        public string AircraftName { get; set; }
        public string AircraftModel { get; set; }
        public int AircraftStatus { get; set; }
        public string FullName => $"{LastName}, {FirstName}";
        public override string ToString() => FullName;
    }

    internal class FlightSearchResult
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
}