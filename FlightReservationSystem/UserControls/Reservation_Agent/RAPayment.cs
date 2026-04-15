using FlightReservationSystem.Data;
using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAPayment : UserControl
    {
        public event EventHandler OnBack;
        public event EventHandler OnConfirmed;

        // ── Basic flight info (set by RAForm) ─────────────────────
        public string FlightNumber { get; set; } = "";
        public string Route { get; set; } = "";
        public string FlightDate { get; set; } = "";
        public string Passengers { get; set; } = "";
        public string FlightClass { get; set; } = "Economy";
        public decimal BaseFare { get; set; }
        public decimal Tax { get; set; }
        public decimal ServiceFee { get; set; }

        // ── Needed for DB save (set by RAForm) ────────────────────
        public int FlightID { get; set; }

        /// <summary>All passenger forms, ordered 1…N (set by RAForm).</summary>
        public List<RAPassengerDetails> PassengerForms { get; set; } = new List<RAPassengerDetails>();

        /// <summary>PassengerNumber → SeatLabel map returned by ISeatMap.LoadPassengers.</summary>
        public Dictionary<int, string> SeatAssignments { get; set; } = new Dictionary<int, string>();

        public RAPayment()
        {
            InitializeComponent();
        }

        private void RAPayment_Load(object sender, EventArgs e)
        {
            // ── Flight summary ────────────────────────────────────
            lblFlightValue.Text = FlightNumber;
            lblRouteValue.Text = Route;
            lblDateValue.Text = FlightDate;
            lblPassengersValue.Text = Passengers;
            lblClassValue.Text = FlightClass;

            // ── Class breakdown ───────────────────────────────────
            int economy = PassengerForms.Count(p => p.SeatClass == "Economy");
            int comfort = PassengerForms.Count(p => p.SeatClass == "Comfort");
            int business = PassengerForms.Count(p => p.SeatClass == "Business");

            lblEconomyCount.Text = $"Economy:  {economy} pax";
            lblComfortCount.Text = $"Comfort:  {comfort} pax";
            lblBusinessCount.Text = $"Business: {business} pax";

            // ── Seat assignment summary ───────────────────────────
            var seatLines = PassengerForms
                .OrderBy(p => p.PassengerNumber)
                .Select(p =>
                {
                    SeatAssignments.TryGetValue(p.PassengerNumber, out string seat);
                    seat = string.IsNullOrEmpty(seat) ? "—" : seat;
                    return $"  Pax {p.PassengerNumber}: {p.LastName}, {p.FirstName}  |  {p.SeatClass}  |  Seat {seat}";
                });

            lblSeatSummary.Text = string.Join(Environment.NewLine, seatLines);

            // ── Fare breakdown ────────────────────────────────────
            decimal total = BaseFare + Tax + ServiceFee;
            lblBaseFareValue.Text = $"PHP {BaseFare:N2}";
            lblTaxValue.Text = $"PHP {Tax:N2}";
            lblFeesValue.Text = $"PHP {ServiceFee:N2}";
            lblTotalValue.Text = $"PHP {total:N2}";
            lblAmountValue.Text = $"PHP {total:N2}";

            // ── Reference number ──────────────────────────────────
            txtRefNumber.Text = GenerateReference();
        }

        private string GenerateReference()
            => $"FRS-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";

        private void btnBack_Click(object sender, EventArgs e)
            => OnBack?.Invoke(this, EventArgs.Empty);

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (!chkConfirm.Checked)
            {
                MessageBox.Show(
                    "Please confirm that you understand the payment is to be made at the counter.",
                    "Confirmation Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ── Save to database ──────────────────────────────────
            int bookingId = BookingRepository.SaveBooking(
                referenceNo: txtRefNumber.Text,
                flightId: FlightID,
                baseFare: BaseFare,
                tax: Tax,
                serviceFee: ServiceFee,
                passengers: PassengerForms,
                seatAssignments: SeatAssignments);

            if (bookingId < 0)
                return;   // SaveBooking already showed the error dialog

            // ── Success ───────────────────────────────────────────
            int economy = PassengerForms.Count(p => p.SeatClass == "Economy");
            int comfort = PassengerForms.Count(p => p.SeatClass == "Comfort");
            int business = PassengerForms.Count(p => p.SeatClass == "Business");

            MessageBox.Show(
                $"Booking confirmed!\n\n" +
                $"Reference No: {txtRefNumber.Text}\n\n" +
                $"Passengers:\n" +
                $"  Economy:  {economy}\n" +
                $"  Comfort:  {comfort}\n" +
                $"  Business: {business}\n\n" +
                $"Please proceed to the counter and present this reference number to complete your payment.",
                "Booking Confirmed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            OnConfirmed?.Invoke(this, EventArgs.Empty);
        }
    }
}