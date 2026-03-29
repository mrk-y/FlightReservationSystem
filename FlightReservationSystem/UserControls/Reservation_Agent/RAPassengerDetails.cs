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
    public partial class RAPassengerDetails : UserControl
    {
        private int _passengerNumber = 1;

        public event EventHandler OnProceed;

        public int PassengerNumber
        {
            get => _passengerNumber;
            set
            {
                _passengerNumber = value;
                lblTitle.Text = $"Passenger {value} — Details";
            }
        }

        public RAPassengerDetails()
        {
            InitializeComponent();
        }

        private void RAPassengerDetails_Load(object sender, EventArgs e)
        {
            cmbGender.SelectedIndex = 0;
            cmbIDType.SelectedIndex = 0;
            dtpBirthdate.MaxDate = DateTime.Today;
            dtpBirthdate.Value = DateTime.Today.AddYears(-18);
            ComputeAge();
        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            ComputeAge();

            int age = int.Parse(txtAge.Text);
            if (age < 18)
                chkUnaccompaniedMinor.Checked = true;
            else
            {
                chkUnaccompaniedMinor.Checked = false;
                ToggleGuardianFields(false);
            }
        }

        private void ComputeAge()
        {
            var today = DateTime.Today;
            var dob = dtpBirthdate.Value;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            txtAge.Text = age.ToString();
        }

        private void chkUnaccompaniedMinor_CheckedChanged(object sender, EventArgs e)
        {
            ToggleGuardianFields(chkUnaccompaniedMinor.Checked);
        }

        // ── PUT IT HERE ───────────────────────────────────────────
        private void ToggleGuardianFields(bool show)
        {
            lblGuardianName.Visible = show;
            txtGuardianName.Visible = show;
            lblGuardianPhone.Visible = show;
            txtGuardianPhone.Visible = show;
            lblGuardianRelation.Visible = show;
            txtGuardianRelation.Visible = show;

            pnlSpecial.Height = show ? 175 : 100;
            btnProceed.Top = pnlSpecial.Bottom + 12;
            pnlMain.ScrollControlIntoView(btnProceed);
        }
        // ─────────────────────────────────────────────────────────

        public bool ValidatePassenger()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtNationality.Text) ||
                string.IsNullOrWhiteSpace(txtIDNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show(
                    $"Please fill in all required fields for Passenger {_passengerNumber}.",
                    "Incomplete Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (int.Parse(txtAge.Text) < 2)
            {
                MessageBox.Show(
                    "Infant passengers (below 2) must be booked separately.",
                    "Age Restriction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (chkUnaccompaniedMinor.Checked &&
               (string.IsNullOrWhiteSpace(txtGuardianName.Text) ||
                string.IsNullOrWhiteSpace(txtGuardianPhone.Text) ||
                string.IsNullOrWhiteSpace(txtGuardianRelation.Text)))
            {
                MessageBox.Show(
                    "Please fill in all guardian details for the unaccompanied minor.",
                    "Guardian Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (ValidatePassenger())
                OnProceed?.Invoke(this, EventArgs.Empty);
        }
    }
}