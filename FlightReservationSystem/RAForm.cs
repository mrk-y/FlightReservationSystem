using FlightReservationSystem.Data;
using FlightReservationSystem.UserControls;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.Reservation_Agent;
using FlightReservationSystem.UserControls.AircraftModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class RAForm : Form
    {
        private RANavigation _navigation;
        private RAFlightCards _selectedFlight;
        private int _passengerCount = 1;

        private List<RAPassengerDetails> _passengerForms = new List<RAPassengerDetails>();
        private Dictionary<int, string> _seatAssignments = new Dictionary<int, string>();

        public RAForm()
        {
            InitializeComponent();
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

            ShowFlights();
        }

        // ── Navigation ────────────────────────────────────────────────────────
        // Guards now live in RANavigation itself; RAForm only reacts to valid
        // navigation events that already passed the guard.
        private void HandleNavigation(string page)
        {
            switch (page)
            {
                case "Flights": ShowFlights(); break;
                case "Passenger": ShowPassengers(); break;
                case "Seats": ShowSeats(); break;
                case "Payment": ShowPayment(); break;
            }
        }

        // ── Panel reset ───────────────────────────────────────────────────────
        private void ResetPanel()
        {
            pnlFuncs.AutoScroll = false;
            pnlFuncs.Controls.Clear();
            pnlFuncs.Refresh();
        }

        // ── Show Flights ──────────────────────────────────────────────────────
        private void ShowFlights()
        {
            ResetPanel();

            // Reset all step flags when going back to flight selection
            _navigation.FlightSelected = false;
            _navigation.PassengersFilled = false;
            _navigation.SeatsAssigned = false;

            RAFlights flights = new RAFlights();
            flights.Dock = DockStyle.Fill;

            flights.OnFlightSelected += (card, passengerCount) =>
            {
                _selectedFlight = card;
                _passengerCount = passengerCount;
                _seatAssignments = new Dictionary<int, string>();

                // ✔ Step 1 complete
                _navigation.FlightSelected = true;
                _navigation.PassengersFilled = false;
                _navigation.SeatsAssigned = false;

                _navigation.SetActiveButton(_navigation.btnAddPassenger);
                ShowPassengers();
            };

            pnlFuncs.Controls.Add(flights);
        }

        // ── Show Passengers ───────────────────────────────────────────────────
        private void ShowPassengers()
        {
            ResetPanel();
            pnlFuncs.AutoScroll = true;
            _passengerForms.Clear();

            // Navigating back to passengers resets the later steps
            _navigation.PassengersFilled = false;
            _navigation.SeatsAssigned = false;

            for (int i = _passengerCount; i >= 1; i--)
            {
                RAPassengerDetails form = new RAPassengerDetails();
                form.PassengerNumber = i;
                form.Dock = DockStyle.Top;
                _passengerForms.Add(form);

                // Only Passenger 1's Proceed button advances the workflow.
                // It validates ALL passenger forms before allowing through.
                if (i == 1)
                {
                    form.OnProceed += (s, ev) =>
                    {
                        // Validate every passenger form, not just #1
                        bool allValid = _passengerForms
                            .OrderBy(p => p.PassengerNumber)
                            .All(p => p.ValidatePassenger());

                        if (!allValid) return;   // ValidatePassenger shows its own error

                        // ✔ Step 2 complete
                        _navigation.PassengersFilled = true;
                        _navigation.SeatsAssigned = false;

                        _navigation.SetActiveButton(_navigation.btnAddPassengerSeat);
                        ShowSeats();
                    };
                }

                pnlFuncs.Controls.Add(form);
            }
        }

        // ── Show Seats ────────────────────────────────────────────────────────
        private void ShowSeats()
        {
            ResetPanel();

            // Navigating back to seats resets the payment step
            _navigation.SeatsAssigned = false;

            UserControl seatMap = ResolveAircraftUI(_selectedFlight.Model);

            if (seatMap == null)
            {
                MessageBox.Show(
                    $"No seat map available for aircraft: '{_selectedFlight.Model}'\n\nProceeding to payment.",
                    "Seat Map Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // No seat map = treat as all seated
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
                // Pre-colour any already-booked seats for this specific flight
                var saved = BookingRepository.LoadSavedPassengers(_selectedFlight.FlightID);
                if (saved.Count > 0)
                    iSeatMap.LoadSavedPassengers(saved);

                // Enter interactive selection; _seatAssignments fills as agent clicks
                var ordered = _passengerForms.OrderBy(p => p.PassengerNumber).ToList();
                _seatAssignments = iSeatMap.LoadPassengers(ordered);

                // ── Watch for all passengers being seated ─────────────────────
                // The seat map calls back into this lambda each time a seat is
                // assigned. When the count matches we unlock the Payment button.
                iSeatMap.OnSeatAssigned += () =>
                {
                    if (_seatAssignments.Count >= _passengerCount)
                    {
                        // ✔ Step 3 complete
                        _navigation.SeatsAssigned = true;
                    }
                };
            }
        }

        // ── Aircraft UI resolver ──────────────────────────────────────────────
        private UserControl ResolveAircraftUI(string model)
        {
            if (string.IsNullOrWhiteSpace(model)) return null;

            string n = model.ToLower().Replace(" ", "").Replace("-", "");

            if (n.Contains("atr") && n.Contains("72"))
                return new ATR_72_600();

            if(n.Contains("a319"))
                return new Airbus_A319_100();

            if (n.Contains("a320"))
                return new Airbus_A320_200();

            if (n.Contains("a320neo"))
                return new Airbus_A320neo();

            if (n.Contains("a321"))
                return new Airbus_A321_200();

            if (n.Contains("a321neo"))
                return new Airbus_A321neo();


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
                // Full reset after a completed booking
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

        private void RAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to exit?\nAny incomplete progress you made will be lost.");

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                Application.Exit();
            }
        }
    }
}