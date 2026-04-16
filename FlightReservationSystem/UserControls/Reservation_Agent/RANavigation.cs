using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
using System;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RANavigation : UserControl
    {
        public event Action<string> OnNavigate;

        // ── Step completion flags (set by RAForm) ─────────────────────────────
        public bool FlightSelected { get; set; } = false;   // a flight was picked
        public bool PassengersFilled { get; set; } = false;   // all passenger forms validated
        public bool SeatsAssigned { get; set; } = false;   // all passengers have a seat

        public RANavigation()
        {
            InitializeComponent();
        }

        private void RANavigation_Load(object sender, EventArgs e)
        {
            SetActiveButton(btnViewFlights);
        }

        // ── Flights — always allowed ──────────────────────────────────────────
        private void btnViewFlights_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnViewFlights);
            OnNavigate?.Invoke("Flights");
        }

        // ── Passenger — requires a flight to be selected ──────────────────────
        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            if (!FlightSelected)
            {
                Warn("Please select a flight first before filling in passenger details.");
                return;
            }

            SetActiveButton(btnAddPassenger);
            OnNavigate?.Invoke("Passenger");
        }

        // ── Seats — requires passenger forms to be filled ─────────────────────
        private void btnAddPassengerSeat_Click(object sender, EventArgs e)
        {
            if (!FlightSelected)
            {
                Warn("Please select a flight first.");
                return;
            }

            if (!PassengersFilled)
            {
                Warn("Please complete and submit all passenger details before choosing seats.");
                return;
            }

            SetActiveButton(btnAddPassengerSeat);
            OnNavigate?.Invoke("Seats");
        }

        // ── Payment — requires all seats to be assigned ───────────────────────
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (!FlightSelected)
            {
                Warn("Please select a flight first.");
                return;
            }

            if (!PassengersFilled)
            {
                Warn("Please complete all passenger details before proceeding to payment.");
                return;
            }

            if (!SeatsAssigned)
            {
                Warn("Please assign a seat to every passenger before proceeding to payment.");
                return;
            }

            SetActiveButton(btnPayment);
            OnNavigate?.Invoke("Payment");
        }

        // ── Active button highlight ───────────────────────────────────────────
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

        private static void Warn(string message)
            => MessageBox.Show(message, "Step Incomplete",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void btnChangeSeats_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnChangeSeats);
            OnNavigate?.Invoke("ChangeSeat");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");
            if (result == DialogResult.Yes)
            {
                ErrorManager.ClearErrorCollection();
                ErrorManager.ClearErrorUICollection();
                AircraftManager.ClearCrewCollection();
                AircraftManager.ClearAircraftCollection();

                AccountSession.LogoutRAAccount();
            }

            return;
        }
    }
}