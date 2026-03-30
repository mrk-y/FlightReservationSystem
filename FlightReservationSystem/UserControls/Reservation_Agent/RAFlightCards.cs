using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationSystem.Helpers;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAFlightCards : UserControl
    {
        // ── Events ────────────────────────────────────────────────
        public event EventHandler OnSelect;
        public event EventHandler OnViewDetail;

        // ── Flight Data ───────────────────────────────────────────
        private string _seatClass = "Economy";

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

        // ── Fare Properties ───────────────────────────────────────
        public decimal FareEconomy => (decimal)(DistanceKM * 1.25);
        public decimal FarePremiumEconomy => (decimal)(DistanceKM * 1.25 * 1.6);
        public decimal FareBusiness => (decimal)(DistanceKM * 1.25 * 2.5);
        public decimal FareFirstClass => (decimal)(DistanceKM * 1.25 * 4.0);

        public string DurationFormatted =>
            $"{DurationMin / 60}h {DurationMin % 60}m";

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

        // ── Constructor ───────────────────────────────────────────
        public RAFlightCards()
        {
            InitializeComponent();
        }

        // ── Load ──────────────────────────────────────────────────
        private void RAFlightCards_Load(object sender, EventArgs e)
        {
            BindToUI();
        }

        // ── Bind data to UI labels ────────────────────────────────
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
        }

        // ── Static DB fetch ───────────────────────────────────────
        public static List<RAFlightCards> LoadFromDB(string seatClass = "Economy")
        {
            var cards = new List<RAFlightCards>();

            string sql = @"
                SELECT
                    f.FlightID,
                    a.Aircraft,
                    a.Model,
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
                    f.Arrival
                FROM Flights f
                LEFT JOIN Aircrafts a  ON a.AircraftID = f.Aircraft
                LEFT JOIN Airports ao  ON ao.AirportID = f.Origin
                LEFT JOIN Airports ad  ON ad.AirportID = f.Destination
                LEFT JOIN Terminals t  ON t.TerminalID = f.Terminal
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
                                _seatClass = seatClass
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
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return cards;
        }

        // ── View Detail click ─────────────────────────────────────
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Aircraft:         {Airline}\n" +
                $"Model:            {Model}\n" +
                $"Base:             {BaseName}\n" +
                $"Route:            {OriginCity} → {DestinationCity}\n" +
                $"Departure:        {Departure:ddd, MMM d — h:mm tt}\n" +
                $"Arrival:          {Arrival:ddd, MMM d — h:mm tt}\n" +
                $"Duration:         {DurationFormatted}\n" +
                $"Terminal:         {TerminalNo} ({Classification})\n" +
                $"Gate:             {Gate}\n" +
                $"Distance:         {DistanceKM:N0} km\n\n" +
                $"Economy:          PHP {FareEconomy:N2}\n" +
                $"Premium Economy:  PHP {FarePremiumEconomy:N2}\n" +
                $"Business:         PHP {FareBusiness:N2}\n" +
                $"First Class:      PHP {FareFirstClass:N2}",
                "Flight Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            OnViewDetail?.Invoke(this, EventArgs.Empty);
        }

        // ── Select click ──────────────────────────────────────────
        private void btnSelect_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, EventArgs.Empty);
        }
    }
}