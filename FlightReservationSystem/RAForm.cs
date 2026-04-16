using FlightReservationSystem.Data;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls;
using FlightReservationSystem.UserControls.AircraftModelsUI;
using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class RAForm : Form
    {
        private static RAForm Current { get; set; } = null;

        private RANavigation _navigation;
        private RAFlightCards _selectedFlight;
        private int _passengerCount = 1;

        private List<RAPassengerDetails> _passengerForms = new List<RAPassengerDetails>();
        private Dictionary<int, string> _seatAssignments = new Dictionary<int, string>();

        // ── Status auto-update timer ──────────────────────────────────────────
        private Timer _statusTimer;
        private static bool IsLoggingOut = false;

        public RAForm()
        {
            InitializeComponent();

            Current = this;

            if (Current == null)
            {
                DebugLogger.LogWithStackTrace("Current is null. Data initialization aborted.");
                return;
            }

        }

        private void RAForm_Load(object sender, EventArgs e)
        {
            Header header = new Header();
            header.Dock = DockStyle.Fill;
            pnlHeader.Controls.Add(header);

            _navigation = new RANavigation();
            _navigation.Dock = DockStyle.Fill;
            _navigation.OnNavigate += HandleNavigation;
            pnlNavigation.Controls.Add(_navigation);

            StartStatusTimer();
            ShowFlights();
        }

        // ═════════════════════════════════════════════════════════════════════
        // Aircraft status auto-promotion (runs every 30 s)
        // ═════════════════════════════════════════════════════════════════════
        private void StartStatusTimer()
        {
            _statusTimer = new Timer();
            _statusTimer.Interval = 30_000;
            _statusTimer.Tick += StatusTimer_Tick;
            _statusTimer.Start();

            PromoteAircraftStatuses();
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            PromoteAircraftStatuses();
            RefreshFlightCardBadges();
        }

        private void PromoteAircraftStatuses()
        {
            const string sql = @"
                UPDATE a
                SET    a.Status =
                    CASE
                        WHEN a.Status = 4 AND GETDATE() >= DATEADD(HOUR, -1, f.Departure)
                            THEN 5
                        WHEN a.Status = 5 AND GETDATE() >= f.Departure
                            THEN 6
                        WHEN a.Status = 6 AND GETDATE() >= f.Arrival
                            THEN 7
                        ELSE a.Status
                    END
                FROM   Aircrafts a
                INNER JOIN Flights f ON f.Aircraft = a.AircraftID
                WHERE  f.IsActive = 1
                  AND  a.Status IN (4, 5, 6)";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Silent
            }
        }

        private void RefreshFlightCardBadges()
        {
            foreach (Control c in pnlFuncs.Controls)
            {
                if (!(c is RAFlights flights)) continue;
                flights.RefreshStatuses();
                break;
            }
        }

        private void HandleNavigation(string page)
        {
            switch (page)
            {
                case "Flights": ShowFlights(); break;
                case "Passenger": ShowPassengers(); break;
                case "Seats": ShowSeats(); break;
                case "Payment": ShowPayment(); break;
                case "ChangeSeat": ShowChangeSeat(); break;
            }
        }

        private void ResetPanel()
        {
            pnlFuncs.AutoScroll = false;
            pnlFuncs.Controls.Clear();
            pnlFuncs.Controls.Add(pnlDetails); // restore it
            pnlDetails.Controls.Clear();
            pnlDetails.Visible = false;
            pnlFuncs.Refresh();
        }

        // ── Show Flights ──────────────────────────────────────────────────────
        private void ShowFlights()
        {
            ResetPanel();

            _navigation.FlightSelected = false;
            _navigation.PassengersFilled = false;
            _navigation.SeatsAssigned = false;

            RAFlights flights = new RAFlights();
            flights.Dock = DockStyle.Fill;

            // ── Flight selected → go to passengers ────────────────
            flights.OnFlightSelected += (card, passengerCount) =>
            {
                if (!card.IsSelectable)
                {
                    MessageBox.Show(
                        $"This flight is no longer available for booking.\n\nStatus: {card.AircraftStatus}",
                        "Flight Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedFlight = card;
                _passengerCount = passengerCount;
                _seatAssignments = new Dictionary<int, string>();

                _navigation.FlightSelected = true;
                _navigation.PassengersFilled = false;
                _navigation.SeatsAssigned = false;

                _navigation.SetActiveButton(_navigation.btnAddPassenger);
                ShowPassengers();
            };

            // ── View detail button → show RAFlightDetails ─────────
            flights.OnViewFlightDetail += (flightID) =>
            {
                ShowFlightDetails(flightID);
            };

            pnlFuncs.Controls.Add(flights);
        }

        // ── Show Flight Details ───────────────────────────────────────────────
        private void ShowFlightDetails(int flightID)
        {
            pnlDetails.Controls.Clear();  // clear the right panel

            RAFlightDetails details = new RAFlightDetails();
            details.Dock = DockStyle.Fill;

            details.OnClose += (s, e) =>
            {
                pnlDetails.Controls.Clear();
                pnlDetails.Visible = false; // or hide pnlDetails
            };

            pnlDetails.Controls.Add(details);
            pnlDetails.Visible = true;
            details.LoadFlight(flightID);
        }

        // ── Show Passengers ───────────────────────────────────────────────────
        private void ShowPassengers()
        {
            ResetPanel();
            pnlFuncs.AutoScroll = true;
            _passengerForms.Clear();

            _navigation.PassengersFilled = false;
            _navigation.SeatsAssigned = false;

            for (int i = _passengerCount; i >= 1; i--)
            {
                RAPassengerDetails form = new RAPassengerDetails();
                form.PassengerNumber = i;
                form.Dock = DockStyle.Top;
                _passengerForms.Add(form);

                if (i == 1)
                {
                    form.OnProceed += (s, ev) =>
                    {
                        bool allValid = _passengerForms
                            .OrderBy(p => p.PassengerNumber)
                            .All(p => p.ValidatePassenger());

                        if (!allValid) return;

                        _navigation.PassengersFilled = true;
                        _navigation.SeatsAssigned = false;

                        _navigation.SetActiveButton(_navigation.btnAddPassengerSeat);
                        ShowSeats();
                    };
                }

                // ── Load seat classes for this passenger based on selected flight ──
                form.LoadSeatClasses(_selectedFlight.FlightID);

                pnlFuncs.Controls.Add(form);
            }
        }

        // ── Show Seats ────────────────────────────────────────────────────────
        private void ShowSeats()
        {
            ResetPanel();
            _navigation.SeatsAssigned = false;

            UserControl seatMap = ResolveAircraftUI(_selectedFlight.Model);

            if (seatMap == null)
            {
                MessageBox.Show(
                    $"No seat map available for aircraft: '{_selectedFlight.Model}'\n\nProceeding to payment.",
                    "Seat Map Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _navigation.SeatsAssigned = true;
                _navigation.SetActiveButton(_navigation.btnPayment);
                ShowPayment();
                return;
            }

            pnlFuncs.AutoScroll = true;
            seatMap.Dock = DockStyle.None;
            seatMap.AutoSize = true;
            seatMap.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            seatMap.Location = new System.Drawing.Point(0, 0);
            pnlFuncs.Controls.Add(seatMap);

            if (seatMap is ISeatMap iSeatMap)
            {
                var saved = BookingRepository.LoadSavedPassengers(_selectedFlight.FlightID);
                if (saved.Count > 0)
                    iSeatMap.LoadSavedPassengers(saved);

                var ordered = _passengerForms.OrderBy(p => p.PassengerNumber).ToList();
                _seatAssignments = iSeatMap.LoadPassengers(ordered);

                iSeatMap.OnSeatAssigned += () =>
                {
                    if (_seatAssignments.Count >= _passengerCount)
                        _navigation.SeatsAssigned = true;
                };
            }
        }

        // ── Show Change Seat ──────────────────────────────────────────────────
        private void ShowChangeSeat()
        {
            ResetPanel();
            pnlFuncs.AutoScroll = true;
            var changeSeat = new RAChangeSeat();
            changeSeat.Dock = DockStyle.Fill;
            changeSeat.MinimumSize = new System.Drawing.Size(1262, 585);
            pnlFuncs.Controls.Add(changeSeat);
        }

        // ── Aircraft UI resolver ──────────────────────────────────────────────
        // FIX: ordered most-specific → least-specific to prevent e.g. "a320neo"
        //      matching the "a320" branch before reaching "a320neo".
        //      Duplicate dead-code block also removed.
        private UserControl ResolveAircraftUI(string model)
        {
            if (string.IsNullOrWhiteSpace(model)) return null;
            string n = model.ToLower().Replace(" ", "").Replace("-", "");

            if (n.Contains("atr") && n.Contains("72")) return new ATR_72_600();
            if (n.Contains("737") && n.Contains("900er")) return new Boeing_737_900ER();
            if (n.Contains("737") && n.Contains("900")) return new Boeing_737_900ER();
            if (n.Contains("737") && n.Contains("800")) return new Boeing_737_800();
            if (n.Contains("737") && n.Contains("700")) return new Boeing_737_700();
            if (n.Contains("dhc") && n.Contains("8")) return new DHC_8_400();
            if (n.Contains("a319")) return new Airbus_A319_100();
            if (n.Contains("a321neo")) return new Airbus_A321neo();   // before a321
            if (n.Contains("a321")) return new Airbus_A321_200();
            if (n.Contains("a320neo")) return new Airbus_A320neo();   // before a320
            if (n.Contains("a320")) return new Airbus_A320_200();

            return null;
        }

        // ── Show Payment ──────────────────────────────────────────────────────
        private void ShowPayment()
        {
            ResetPanel();

            RAPayment payment = new RAPayment();
            payment.Dock = DockStyle.Fill;

            if (_selectedFlight != null)
            {
                string dominantClass = _passengerForms
                    .GroupBy(p => p.SeatClass)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "Economy";

                decimal baseFare = _passengerForms.Sum(p => _selectedFlight.GetFare(p.SeatClass));
                decimal tax = Math.Round(baseFare * 0.12m, 2);
                decimal serviceFee = 50.00m * _passengerCount;

                payment.FlightID = _selectedFlight.FlightID;
                payment.FlightNumber = _selectedFlight.Airline;
                payment.Route = $"{_selectedFlight.OriginIATA} → {_selectedFlight.DestinationIATA}";
                payment.FlightDate = _selectedFlight.Departure.ToString("ddd, MMM d, yyyy");
                payment.Passengers = $"{_passengerCount} Passenger(s)";
                payment.FlightClass = dominantClass;
                payment.BaseFare = baseFare;
                payment.Tax = tax;
                payment.ServiceFee = serviceFee;
                payment.PassengerForms = _passengerForms.OrderBy(p => p.PassengerNumber).ToList();
                payment.SeatAssignments = _seatAssignments;
            }

            payment.OnBack += (s, ev) =>
            {
                _navigation.SetActiveButton(_navigation.btnAddPassenger);
                ShowPassengers();
            };

            payment.OnConfirmed += (s, ev) =>
            {
                _selectedFlight = null;
                _seatAssignments = new Dictionary<int, string>();
                _passengerForms.Clear();

                _navigation.FlightSelected = false;
                _navigation.PassengersFilled = false;
                _navigation.SeatsAssigned = false;

                _navigation.SetActiveButton(_navigation.btnViewFlights);
                ShowFlights();
            };

            pnlFuncs.Controls.Add(payment);
        }

        public static void CloseForm()
        {
            IsLoggingOut = true;
            Current.Close();
        }

        // ── Form closing ──────────────────────────────────────────────────────
        private void RAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _statusTimer?.Stop();
            _statusTimer?.Dispose();

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage(
                    "Are you sure you want to exit?\nAny incomplete progress you made will be lost.");

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                if (IsLoggingOut) return;

                Application.Exit();
            }
        }
    }
}