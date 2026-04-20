using FlightReservationSystem.Data;
using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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
        public DateTime CreatedAt { get; private set; }

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
            CreatedAt = DateTime.Now;
            txtRefNumber.Text = GenerateReference();

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
                $"Booked At:    {CreatedAt:MMM d, yyyy  h:mm tt}\n\n" +
                $"Passengers:\n" +
                $"  Economy:  {economy}\n" +
                $"  Comfort:  {comfort}\n" +
                $"  Business: {business}\n\n" +
                $"Please proceed to the counter and present this reference number to complete your payment.",
                "Booking Confirmed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // ── Offer to print receipt ────────────────────────────
            var ask = MessageBox.Show(
                "Would you like to print a booking receipt?",
                "Print Receipt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ask == DialogResult.Yes)
                PrintReceipt();

            OnConfirmed?.Invoke(this, EventArgs.Empty);
        }

        // ════════════════════════════════════════════════════════════
        // PRINT RECEIPT
        // ════════════════════════════════════════════════════════════

        private void btnPrintReceipt_Click(object sender, EventArgs e)
            => PrintReceipt();

        private void PrintReceipt()
        {
            var doc = new PrintDocument();
            doc.DocumentName = $"Booking Receipt - {txtRefNumber.Text}";
            doc.PrintPage += PrintPage;

            using (var preview = new PrintPreviewDialog())
            {
                preview.Document = doc;
                preview.Width = 850;
                preview.Height = 1100;
                preview.Text = "Print Booking Receipt";
                preview.ShowDialog();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float pageWidth = e.MarginBounds.Width;
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // ── Color palette ─────────────────────────────────────
            Color navy = Color.FromArgb(20, 20, 50);
            Color orange = Color.FromArgb(220, 80, 0);
            Color gray = Color.FromArgb(120, 120, 130);
            Color lightGray = Color.FromArgb(230, 230, 235);

            // ── Fonts ─────────────────────────────────────────────
            var fontTitle = new Font("Segoe UI", 18f, FontStyle.Bold);
            var fontSubtitle = new Font("Segoe UI", 9f, FontStyle.Regular);
            var fontSectionHead = new Font("Segoe UI", 10f, FontStyle.Bold);
            var fontLabel = new Font("Segoe UI", 9f, FontStyle.Regular);
            var fontValue = new Font("Segoe UI", 9f, FontStyle.Bold);
            var fontRef = new Font("Segoe UI", 13f, FontStyle.Bold);
            var fontTotal = new Font("Segoe UI", 12f, FontStyle.Bold);
            var fontSmall = new Font("Segoe UI", 8f, FontStyle.Regular);

            // ── Header bar ────────────────────────────────────────
            g.FillRectangle(new SolidBrush(navy), x, y, pageWidth, 56);
            g.DrawString("✈  Flight Reservation System", fontTitle, Brushes.White, x + 12, y + 10);
            y += 64;

            // ── "BOOKING RECEIPT" subtitle ────────────────────────
            g.DrawString("BOOKING RECEIPT", fontSectionHead, new SolidBrush(orange), x, y);
            g.DrawString($"Printed: {DateTime.Now:ddd, MMM d, yyyy  h:mm tt}", fontSmall, new SolidBrush(gray), x + pageWidth - 220, y + 2);
            y += 22;
            DrawDivider(g, x, y, pageWidth, lightGray);
            y += 10;

            // ── Reference box ─────────────────────────────────────
            RectangleF refBox = new RectangleF(x, y, pageWidth, 36);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 235)), refBox);
            g.DrawRectangle(new Pen(orange, 1), refBox.X, refBox.Y, refBox.Width, refBox.Height);
            g.DrawString("Reference No:", fontLabel, new SolidBrush(gray), x + 10, y + 10);
            g.DrawString(txtRefNumber.Text, fontRef, new SolidBrush(orange), x + 110, y + 7);
            y += 46;

            // ── Flight Info section ───────────────────────────────
            y = DrawSectionHeader(g, "FLIGHT INFORMATION", x, y, pageWidth, navy, fontSectionHead);

            var flightRows = new (string label, string value)[]
            {
                ("Flight",      FlightNumber),
                ("Route",       Route),
                ("Date",        FlightDate),
                ("Passengers",  Passengers),
                ("Class",       FlightClass),
            };

            foreach (var row in flightRows)
                y = DrawRow(g, row.label, row.value, x, y, pageWidth, fontLabel, fontValue, navy, gray, lightGray);

            y += 6;

            // ── Passenger Details section ─────────────────────────
            y = DrawSectionHeader(g, "PASSENGER DETAILS", x, y, pageWidth, navy, fontSectionHead);

            foreach (var p in PassengerForms.OrderBy(p => p.PassengerNumber))
            {
                SeatAssignments.TryGetValue(p.PassengerNumber, out string seat);
                seat = string.IsNullOrEmpty(seat) ? "—" : seat;

                string passengerLine = $"Pax {p.PassengerNumber}:  {p.LastName}, {p.FirstName}";
                string detailLine = $"  Class: {p.SeatClass}   |   Seat: {seat}   |   Age: {p.Age}";

                g.DrawString(passengerLine, fontValue, new SolidBrush(navy), x + 8, y);
                y += 16;
                g.DrawString(detailLine, fontLabel, new SolidBrush(gray), x + 8, y);
                y += 18;

                DrawDivider(g, x + 8, y, pageWidth - 8, lightGray);
                y += 6;
            }

            y += 4;

            // ── Fare Breakdown section ────────────────────────────
            y = DrawSectionHeader(g, "FARE BREAKDOWN", x, y, pageWidth, navy, fontSectionHead);

            var fareRows = new (string label, string value)[]
            {
                ("Base Fare",       $"PHP {BaseFare:N2}"),
                ("Tax & Surcharges",$"PHP {Tax:N2}"),
                ("Service Fee",     $"PHP {ServiceFee:N2}"),
            };

            foreach (var row in fareRows)
                y = DrawRow(g, row.label, row.value, x, y, pageWidth, fontLabel, fontValue, navy, gray, lightGray);

            // ── Total ─────────────────────────────────────────────
            decimal total = BaseFare + Tax + ServiceFee;
            y += 4;
            g.FillRectangle(new SolidBrush(navy), x, y, pageWidth, 30);
            g.DrawString("TOTAL AMOUNT DUE", fontSectionHead, Brushes.White, x + 10, y + 7);
            g.DrawString($"PHP {total:N2}", fontTotal, new SolidBrush(Color.FromArgb(255, 180, 80)), x + pageWidth - 130, y + 6);
            y += 40;

            // ── Class counts ──────────────────────────────────────
            int eco = PassengerForms.Count(p => p.SeatClass == "Economy");
            int com = PassengerForms.Count(p => p.SeatClass == "Comfort");
            int bus = PassengerForms.Count(p => p.SeatClass == "Business");

            g.DrawString($"Economy: {eco} pax   |   Comfort: {com} pax   |   Business: {bus} pax",
                fontSmall, new SolidBrush(gray), x, y);
            y += 20;

            // ── Footer ────────────────────────────────────────────
            DrawDivider(g, x, y, pageWidth, lightGray);
            y += 8;
            string footer = "Please proceed to the reservation counter and present this reference number to complete your payment.";
            g.DrawString(footer, fontSmall, new SolidBrush(gray), new RectangleF(x, y, pageWidth, 30));

            // ── Cleanup ───────────────────────────────────────────
            fontTitle.Dispose(); fontSubtitle.Dispose(); fontSectionHead.Dispose();
            fontLabel.Dispose(); fontValue.Dispose(); fontRef.Dispose();
            fontTotal.Dispose(); fontSmall.Dispose();
        }

        // ── Drawing helpers ───────────────────────────────────────

        private float DrawSectionHeader(Graphics g, string title, float x, float y,
            float pageWidth, Color bg, Font font)
        {
            g.FillRectangle(new SolidBrush(bg), x, y, pageWidth, 20);
            g.DrawString(title, font, Brushes.White, x + 6, y + 3);
            return y + 26;
        }

        private float DrawRow(Graphics g, string label, string value,
            float x, float y, float pageWidth,
            Font fontLabel, Font fontValue,
            Color navy, Color gray, Color divider)
        {
            g.DrawString(label, fontLabel, new SolidBrush(gray), x + 8, y + 2);
            g.DrawString(value, fontValue, new SolidBrush(navy), x + pageWidth - 200, y + 2);
            y += 18;
            DrawDivider(g, x + 8, y, pageWidth - 8, divider);
            return y + 6;
        }

        private void DrawDivider(Graphics g, float x, float y, float width, Color color)
            => g.DrawLine(new Pen(color, 0.5f), x, y, x + width, y);
    }
}