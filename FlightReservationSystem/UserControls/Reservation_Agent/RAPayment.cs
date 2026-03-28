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
    public partial class RAPayment : UserControl
    {
        public event EventHandler OnBack;
        public event EventHandler OnConfirmed;

        // Set these from the parent before loading
        public string FlightNumber { get; set; } = "PR 502";
        public string Route { get; set; } = "NRT → MNL";
        public string FlightDate { get; set; } = "Fri, Apr 3, 2026";
        public string Passengers { get; set; } = "1 Adult";
        public string FlightClass { get; set; } = "Economy";
        public decimal BaseFare { get; set; } = 1200.00m;
        public decimal Tax { get; set; } = 180.00m;
        public decimal ServiceFee { get; set; } = 50.00m;

        public RAPayment()
        {
            InitializeComponent();
        }

        private void RAPayment_Load(object sender, EventArgs e)
        {
            // Populate summary
            lblFlightValue.Text = FlightNumber;
            lblRouteValue.Text = Route;
            lblDateValue.Text = FlightDate;
            lblPassengersValue.Text = Passengers;
            lblClassValue.Text = FlightClass;

            // Fare breakdown
            decimal total = BaseFare + Tax + ServiceFee;
            lblBaseFareValue.Text = $"PHP {BaseFare:N2}";
            lblTaxValue.Text = $"PHP {Tax:N2}";
            lblFeesValue.Text = $"PHP {ServiceFee:N2}";
            lblTotalValue.Text = $"PHP {total:N2}";
            lblAmountValue.Text = $"PHP {total:N2}";

            // Generate reference number
            txtRefNumber.Text = GenerateReference();
        }

        private string GenerateReference()
        {
            // Format: FRS-YYYYMMDD-XXXX
            return $"FRS-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke(this, EventArgs.Empty);
        }

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

            MessageBox.Show(
                $"Booking confirmed!\n\nReference No: {txtRefNumber.Text}\n\nPlease proceed to the counter and present this reference number to complete your payment.",
                "Booking Confirmed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            OnConfirmed?.Invoke(this, EventArgs.Empty);
        }
    }
}
