using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAFlights : UserControl
    {
        // ── Updated event — carries card + passenger count ────────
        public event Action<RAFlightCards, int> OnFlightSelected;

        public RAFlights()
        {
            InitializeComponent();
        }

        private void RAFlights_Load(object sender, EventArgs e)
        {
            cmbClass.SelectedIndex = 0;
            cmbSortBy.SelectedIndex = 0;
            dtpDepart.MinDate = DateTime.Today;
            dtpDepart.Value = DateTime.Today;
            cmbSortBy.SelectedIndexChanged += (s, ev) => SortCards();
            LoadFlights();
        }

        private void LoadFlights()
        {
            pnlCards.AutoScroll = true;
            pnlCards.Controls.Clear();

            string seatClass = cmbClass.SelectedItem?.ToString() ?? "Economy";
            var cards = RAFlightCards.LoadFromDB(seatClass);

            if (!string.IsNullOrWhiteSpace(txtFrom.Text))
            {
                string from = txtFrom.Text.Trim().ToLower();
                cards = cards.Where(c =>
                    c.OriginIATA.ToLower().Contains(from) ||
                    c.OriginCity.ToLower().Contains(from) ||
                    c.OriginAirport.ToLower().Contains(from)
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(txtTo.Text))
            {
                string to = txtTo.Text.Trim().ToLower();
                cards = cards.Where(c =>
                    c.DestinationIATA.ToLower().Contains(to) ||
                    c.DestinationCity.ToLower().Contains(to) ||
                    c.DestinationAirport.ToLower().Contains(to)
                ).ToList();
            }

            cards = cards.Where(c =>
                c.Departure.Date == dtpDepart.Value.Date
            ).ToList();

            lblResultsTitle.Text = cards.Count > 0
                ? $"Available Flights ({cards.Count} found)"
                : "No flights found for your search.";

            if (cards.Count == 0) return;

            cards = SortList(cards, seatClass);
            cards = cards.AsEnumerable().Reverse().ToList();

            foreach (var card in cards)
            {
                Panel wrapper = new Panel();
                wrapper.Dock = DockStyle.Top;
                wrapper.Height = 155;
                wrapper.Padding = new Padding(0, 0, 0, 10);
                wrapper.BackColor = Color.Transparent;

                card.Dock = DockStyle.Fill;

                // ── Grab passenger count from nudPassengers ────────
                card.OnSelect += (s, e) =>
                {
                    int passengerCount = (int)nudPassengers.Value;
                    OnFlightSelected?.Invoke(card, passengerCount);
                };

                wrapper.Controls.Add(card);
                pnlCards.Controls.Add(wrapper);
            }
        }

        private List<RAFlightCards> SortList(List<RAFlightCards> cards, string seatClass)
        {
            switch (cmbSortBy.SelectedItem?.ToString())
            {
                case "Cheapest": return cards.OrderBy(c => c.GetFare(seatClass)).ToList();
                case "Fastest": return cards.OrderBy(c => c.DurationMin).ToList();
                case "Arrival": return cards.OrderBy(c => c.Arrival).ToList();
                case "Departure":
                default: return cards.OrderBy(c => c.Departure).ToList();
            }
        }

        private void SortCards() => LoadFlights();

        private void btnSearch_Click(object sender, EventArgs e) => LoadFlights();
    }
}