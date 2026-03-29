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
        public RAFlights()
        {
            InitializeComponent();
        }

        private void RAFlights_Load(object sender, EventArgs e)
        {
            pnlCards.AutoScroll = true;

            string[] flights = { "Flight 1", "Flight 2", "Flight 3", "Flight 4" };

            foreach (var flight in flights)
            {
                // Wrapper panel to add spacing between cards
                Panel wrapper = new Panel();
                wrapper.Dock = DockStyle.Top;
                wrapper.Height = 155;  // card height (145) + 10px gap
                wrapper.Padding = new Padding(0, 0, 0, 10); // 10px bottom gap
                wrapper.BackColor = Color.Transparent;

                RAFlightCards card = new RAFlightCards();
                card.Dock = DockStyle.Fill;

                wrapper.Controls.Add(card);
                pnlCards.Controls.Add(wrapper);
            }

            // Fix reverse order when using DockStyle.Top
            var wrappers = pnlCards.Controls.Cast<Control>().Reverse().ToList();
            pnlCards.Controls.Clear();
            foreach (var w in wrappers)
                pnlCards.Controls.Add(w);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Searching flight details...");
        }
    }
}
