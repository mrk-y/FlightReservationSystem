using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FlightReservationSystem.Helpers;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAFlightCards : UserControl
    {
        // ── Events ────────────────────────────────────────────────────────────
        public event EventHandler OnSelect;
        public event EventHandler OnViewDetail;

        // ── Aircraft status constants ─────────────────────────────────────────
        public const int STATUS_INACTIVE = 0;
        public const int STATUS_ADDED = 1;
        public const int STATUS_CREWS = 2;
        public const int STATUS_ROUTE = 3;
        public const int STATUS_SCHEDULED = 4;
        public const int STATUS_BOARDING = 5;
        public const int STATUS_INFLIGHT = 6;
        public const int STATUS_LANDED = 7;
        public const int STATUS_DELAYED = 8;
        public const int STATUS_CANCELLED = 9;

        // ── Status colors ─────────────────────────────────────────────────────
        private static readonly Color ColorScheduled = Color.White;
        private static readonly Color ColorBoarding = Color.FromArgb(255, 202, 7);
        private static readonly Color ColorInFlight = Color.FromArgb(0, 38, 184);
        private static readonly Color ColorLanded = Color.FromArgb(52, 167, 49);
        private static readonly Color ColorDelayed = Color.FromArgb(255, 113, 27);
        private static readonly Color ColorCancelled = Color.FromArgb(220, 33, 49);
        private static readonly Color ColorGateClosed = Color.FromArgb(102, 102, 102);

        // ── Flight data ───────────────────────────────────────────────────────
        private string _seatClass = "Economy";
        private int _aircraftStatus = STATUS_SCHEDULED;
        private Timer _flashTimer;

        public int FlightID { get; set; }
        public string Airline { get; set; }
        public string Model { get; set; }
        public string BaseName { get; set; }
        public int DurationMin { get; set; }
        public double DistanceKM { get; set; }
        public string OriginAirport { get; set; }
        public string OriginIATA { get; set; }
        public string OriginCity { get; set; }
        public string DestinationAirport { get; set; }
        public string DestinationIATA { get; set; }
        public string DestinationCity { get; set; }
        public string TerminalNo { get; set; }
        public string Classification { get; set; }
        public string Gate { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        /// <summary>Aircraft status code (0–9).</summary>
        public int AircraftStatus
        {
            get => _aircraftStatus;
            set
            {
                _aircraftStatus = value;
                ApplyStatusBadge();
                ApplySelectability();
            }
        }

        /// <summary>True only when the flight is still open for booking.</summary>
        public bool IsSelectable =>
            _aircraftStatus == STATUS_SCHEDULED ||
            _aircraftStatus == STATUS_DELAYED;

        // ── Fare properties ───────────────────────────────────────────────────
        public decimal FareEconomy => (decimal)(DistanceKM * 1.25);
        public decimal FarePremiumEconomy => (decimal)(DistanceKM * 1.25 * 1.6);
        public decimal FareBusiness => (decimal)(DistanceKM * 1.25 * 2.5);
        public decimal FareFirstClass => (decimal)(DistanceKM * 1.25 * 4.0);
        public string DurationFormatted => $"{DurationMin / 60}h {DurationMin % 60}m";

        public string SeatClass
        {
            get => _seatClass;
            set
            {
                _seatClass = value;
                lblPrice.Text = $"PHP {GetFare(value):N2}";
            }
        }

        public decimal GetFare(string seatClass)
        {
            switch (seatClass)
            {
                case "Premium Economy": return FarePremiumEconomy;
                case "Business": return FareBusiness;
                case "First Class": return FareFirstClass;
                default: return FareEconomy;
            }
        }

        // ── Constructor ───────────────────────────────────────────────────────
        public RAFlightCards()
        {
            InitializeComponent();
        }

        private void RAFlightCards_Load(object sender, EventArgs e)
        {
            BindToUI();
        }

        // ── Bind data to UI ───────────────────────────────────────────────────
        public void BindToUI()
        {
            lblStops.Text = Airline ?? "—";
            lblDuration.Text = DurationFormatted;
            lblDepTime.Text = Departure.ToString("h:mm tt");
            lblDepCode.Text = $"{OriginIATA} — {OriginCity}";
            lblArrTime.Text = Arrival.ToString("h:mm tt");
            lblArrCode.Text = $"{DestinationIATA} — {DestinationCity}";
            lblDate.Text = Departure.ToString("ddd, MMM d");
            lblPrice.Text = $"PHP {GetFare(_seatClass):N2}";

            ApplyStatusBadge();
            ApplySelectability();
        }

        // ── Status badge ──────────────────────────────────────────────────────
        private void ApplyStatusBadge()
        {
            if (lblStatus == null) return;

            string text;
            Color back;
            Color fore = Color.White;
            bool flash = false;

            switch (_aircraftStatus)
            {
                case STATUS_BOARDING:
                    if (DateTime.Now >= Departure.AddMinutes(-10) && DateTime.Now < Departure)
                    {
                        text = "FINAL CALL";
                        back = ColorBoarding;
                        flash = true;
                    }
                    else
                    {
                        text = "BOARDING";
                        back = ColorBoarding;
                        fore = Color.Black;
                    }
                    break;
                case STATUS_INFLIGHT:
                    text = "IN FLIGHT"; back = ColorInFlight; break;
                case STATUS_LANDED:
                    text = "LANDED"; back = ColorLanded; break;
                case STATUS_DELAYED:
                    text = "DELAYED"; back = ColorDelayed; break;
                case STATUS_CANCELLED:
                    text = "CANCELLED"; back = ColorCancelled; break;
                case STATUS_INACTIVE:
                case STATUS_ADDED:
                case STATUS_CREWS:
                case STATUS_ROUTE:
                    text = "NOT READY"; back = ColorGateClosed; break;
                default: // STATUS_SCHEDULED
                    text = "SCHEDULED";
                    back = ColorScheduled;
                    fore = Color.FromArgb(30, 30, 60);
                    break;
            }

            lblStatus.Text = text;
            lblStatus.BackColor = back;
            lblStatus.ForeColor = fore;

            if (_flashTimer != null)
            {
                _flashTimer.Stop();
                _flashTimer.Dispose();
                _flashTimer = null;
            }

            if (flash)
            {
                _flashTimer = new Timer { Interval = 600 };
                bool visible = true;
                _flashTimer.Tick += (s, e) =>
                {
                    visible = !visible;
                    lblStatus.BackColor = visible ? ColorBoarding : Color.FromArgb(200, 160, 0);
                };
                _flashTimer.Start();
            }
        }

        // ── Select button state ───────────────────────────────────────────────
        private void ApplySelectability()
        {
            if (btnSelect == null) return;

            btnSelect.Enabled = IsSelectable;
            btnSelect.BackColor = IsSelectable
                ? Color.FromArgb(20, 20, 50)
                : Color.FromArgb(160, 160, 170);
            btnSelect.Text = IsSelectable ? "Select  >" : StatusBlockReason();

            pnlCard.BackColor = IsSelectable
                ? Color.White
                : Color.FromArgb(248, 248, 250);
        }

        private string StatusBlockReason()
        {
            switch (_aircraftStatus)
            {
                case STATUS_BOARDING: return "Boarding";
                case STATUS_INFLIGHT: return "In Flight";
                case STATUS_LANDED: return "Landed";
                case STATUS_CANCELLED: return "Cancelled";
                default: return "Unavailable";
            }
        }

        // ── Static DB fetch ───────────────────────────────────────────────────
        public static List<RAFlightCards> LoadFromDB(string seatClass = "Economy")
        {
            var cards = new List<RAFlightCards>();

            const string sql = @"
                SELECT
                    f.FlightID,
                    a.Aircraft,
                    m.Model,
                    a.BaseName,
                    f.DurationMin,
                    f.DistanceKM,
                    ao.Airport      AS OriginAirport,
                    ao.IATA         AS OriginIATA,
                    ao.DisplayCity  AS OriginCity,
                    ad.Airport      AS DestinationAirport,
                    ad.IATA         AS DestinationIATA,
                    ad.DisplayCity  AS DestinationCity,
                    t.TerminalNo,
                    t.Classification,
                    f.Gate,
                    f.Departure,
                    f.Arrival,
                    a.Status        AS AircraftStatus
                FROM Flights f
                LEFT JOIN Aircrafts      a  ON a.AircraftID = f.Aircraft
                LEFT JOIN AircraftModels m  ON m.ModelID    = a.Model
                LEFT JOIN Airports       ao ON ao.AirportID = f.Origin
                LEFT JOIN Airports       ad ON ad.AirportID = f.Destination
                LEFT JOIN Terminals      t  ON t.TerminalID = f.Terminal
                WHERE f.IsActive = 1
                ORDER BY f.Departure ASC";

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
                            var card = new RAFlightCards
                            {
                                FlightID = (int)rdr["FlightID"],
                                Airline = rdr["Aircraft"].ToString(),
                                Model = rdr["Model"].ToString(),
                                BaseName = rdr["BaseName"].ToString(),
                                DurationMin = (int)rdr["DurationMin"],
                                DistanceKM = Convert.ToDouble(rdr["DistanceKM"]),
                                OriginAirport = rdr["OriginAirport"].ToString(),
                                OriginIATA = rdr["OriginIATA"].ToString(),
                                OriginCity = rdr["OriginCity"].ToString(),
                                DestinationAirport = rdr["DestinationAirport"].ToString(),
                                DestinationIATA = rdr["DestinationIATA"].ToString(),
                                DestinationCity = rdr["DestinationCity"].ToString(),
                                TerminalNo = rdr["TerminalNo"].ToString(),
                                Classification = rdr["Classification"].ToString(),
                                Gate = rdr["Gate"].ToString(),
                                Departure = Convert.ToDateTime(rdr["Departure"]),
                                Arrival = Convert.ToDateTime(rdr["Arrival"]),
                                _seatClass = seatClass,
                                _aircraftStatus = rdr["AircraftStatus"] == DBNull.Value
                                                        ? STATUS_SCHEDULED
                                                        : Convert.ToInt32(rdr["AircraftStatus"])
                            };
                            cards.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load flights:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return cards;
        }

        // ── Button clicks ─────────────────────────────────────────────────────
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            // Fire the event — RAFlights catches it and bubbles FlightID up to RAForm
            OnViewDetail?.Invoke(this, EventArgs.Empty);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!IsSelectable)
            {
                MessageBox.Show(
                    $"This flight cannot be selected.\n\nStatus: {lblStatus?.Text}\n\n" +
                    "Only Scheduled or Delayed flights are open for booking.",
                    "Flight Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OnSelect?.Invoke(this, EventArgs.Empty);
        }
    }
}