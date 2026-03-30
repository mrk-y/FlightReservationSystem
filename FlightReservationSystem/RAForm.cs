using FlightReservationSystem.UserControls;
using FlightReservationSystem.UserControls.Reservation_Agent;
using FlightReservationSystem.UserControls.AircraftModelsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class RAForm : Form
    {
        private RANavigation _navigation;
        private RAFlightCards _selectedFlight;
        private int _passengerCount = 1;
        private string _seatClass = "Economy";

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

        // ── Navigation handler ────────────────────────────────────
        private void HandleNavigation(string page)
        {
            switch (page)
            {
                case "Flights":
                    ShowFlights();
                    break;

                case "Passenger":
                    if (_selectedFlight == null)
                    {
                        MessageBox.Show(
                            "Please select a flight first.",
                            "No Flight Selected",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        _navigation.SetActiveButton(_navigation.btnViewFlights);
                        ShowFlights();
                        return;
                    }
                    ShowPassengers();
                    break;

                case "Seats":
                    if (_selectedFlight == null)
                    {
                        MessageBox.Show(
                            "Please select a flight first.",
                            "No Flight Selected",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        _navigation.SetActiveButton(_navigation.btnViewFlights);
                        ShowFlights();
                        return;
                    }
                    ShowSeats();
                    break;

                case "Payment":
                    if (_selectedFlight == null)
                    {
                        MessageBox.Show(
                            "Please select a flight first.",
                            "No Flight Selected",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        _navigation.SetActiveButton(_navigation.btnViewFlights);
                        ShowFlights();
                        return;
                    }
                    ShowPayment();
                    break;
            }
        }

        // ── Reusable panel reset ──────────────────────────────────
        private void ResetPanel()
        {
            pnlFuncs.AutoScroll = false;
            pnlFuncs.Controls.Clear();
            pnlFuncs.Refresh();
        }

        // ── Show Flights ──────────────────────────────────────────
        private void ShowFlights()
        {
            ResetPanel();

            RAFlights flights = new RAFlights();
            flights.Dock = DockStyle.Fill;

            flights.OnFlightSelected += (card, passengerCount) =>
            {
                _selectedFlight = card;
                _seatClass = card.SeatClass;
                _passengerCount = passengerCount;

                _navigation.SetActiveButton(_navigation.btnAddPassenger);
                ShowPassengers();
            };

            pnlFuncs.Controls.Add(flights);
        }

        // ── Show Passengers ───────────────────────────────────────
        private void ShowPassengers()
        {
            ResetPanel();
            pnlFuncs.AutoScroll = true;

            for (int i = _passengerCount; i >= 1; i--)
            {
                RAPassengerDetails form = new RAPassengerDetails();
                form.PassengerNumber = i;
                form.Dock = DockStyle.Top;

                if (i == 1)
                {
                    form.OnProceed += (s, e) =>
                    {
                        _navigation.SetActiveButton(_navigation.btnAddPassengerSeat);
                        ShowSeats();
                    };
                }

                pnlFuncs.Controls.Add(form);
            }
        }

        // ── Show Seats ────────────────────────────────────────────
        private void ShowSeats()
        {
            ResetPanel();

            UserControl seatMap = ResolveAircraftUI(_selectedFlight.Model);

            if (seatMap == null)
            {
                MessageBox.Show(
                    $"No seat map available for aircraft: '{_selectedFlight.Model}'\n\nProceeding to payment.",
                    "Seat Map Unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _navigation.SetActiveButton(_navigation.btnPayment);
                ShowPayment();
                return;
            }

            seatMap.Dock = DockStyle.Fill;
            pnlFuncs.Controls.Add(seatMap);
        }

        // ── Aircraft UI resolver ──────────────────────────────────
        private UserControl ResolveAircraftUI(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                return null;

            string n = model.ToLower().Replace(" ", "").Replace("-", "");

            if (n.Contains("atr") && n.Contains("72"))
                return new ATR_72_600();

            if (n.Contains("a321"))
                return new Airbus_A321_200();

            // if (n.Contains("a320")) return new Airbus_A320_200();
            // if (n.Contains("a319")) return new Airbus_A319_100();

            return null;
        }

        // ── Show Payment ──────────────────────────────────────────
        private void ShowPayment()
        {
            ResetPanel();

            RAPayment payment = new RAPayment();
            payment.Dock = DockStyle.Fill;

            if (_selectedFlight != null)
            {
                payment.FlightNumber = _selectedFlight.Airline;
                payment.Route = $"{_selectedFlight.OriginIATA} → {_selectedFlight.DestinationIATA}";
                payment.FlightDate = _selectedFlight.Departure.ToString("ddd, MMM d, yyyy");
                payment.Passengers = $"{_passengerCount} Passenger(s)";
                payment.FlightClass = _seatClass;
                payment.BaseFare = _selectedFlight.GetFare(_seatClass) * _passengerCount;
                payment.Tax = Math.Round(payment.BaseFare * 0.12m, 2);
                payment.ServiceFee = 50.00m * _passengerCount;
            }

            payment.OnBack += (s, e) =>
            {
                _navigation.SetActiveButton(_navigation.btnAddPassenger);
                ShowPassengers();
            };

            payment.OnConfirmed += (s, e) =>
            {
                _selectedFlight = null;
                _navigation.SetActiveButton(_navigation.btnViewFlights);
                ShowFlights();
            };

            pnlFuncs.Controls.Add(payment);
        }

        // ── Legacy ────────────────────────────────────────────────
        private void LoadPassengerForms(int passengerCount)
        {
            _passengerCount = passengerCount;
            ShowPassengers();
        }
    }
}