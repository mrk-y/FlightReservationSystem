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
    public partial class RANavigation : UserControl
    {
        public event Action<string> OnNavigate;

        public RANavigation()
        {
            InitializeComponent();
        }

        private void RANavigation_Load(object sender, EventArgs e)
        {
            SetActiveButton(btnViewFlights);
        }

        private void btnViewFlights_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnViewFlights);
            OnNavigate?.Invoke("Flights");
        }

        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAddPassenger);
            OnNavigate?.Invoke("Passenger");
        }

        private void btnAddPassengerSeat_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAddPassengerSeat);
            OnNavigate?.Invoke("Seats");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnPayment);
            OnNavigate?.Invoke("Payment");
        }

        public void SetActiveButton(Button active)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(10, 40, 100);
                    btn.ForeColor = System.Drawing.Color.White;
                }
            }
            active.BackColor = System.Drawing.Color.FromArgb(255, 165, 0);
            active.ForeColor = System.Drawing.Color.White;
        }
    }
}