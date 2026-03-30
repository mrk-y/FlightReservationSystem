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
        private bool _suppressCheckEvent = false;

        public event EventHandler OnProceed;

        private static readonly Dictionary<string, string> _seatClassDesc = new Dictionary<string, string>
        {
            ["Economy"] = "Standard seating with essential amenities.",
            ["Comfort"] = "Extra legroom, priority boarding, and enhanced meals.",
            ["Business"] = "Lie-flat seats, premium dining, and lounge access."
        };

        // ── Properties ────────────────────────────────────────────
        public int PassengerNumber
        {
            get => _passengerNumber;
            set
            {
                _passengerNumber = value;
                lblTitle.Text = $"Passenger {value} — Details";
            }
        }

        public string SeatClass => cmbSeatClass.SelectedItem?.ToString() ?? "Economy";
        public string FirstName => txtFirstName.Text.Trim();
        public string LastName => txtLastName.Text.Trim();
        public string MiddleName => txtMiddleName.Text.Trim();
        public string Nationality => txtNationality.Text.Trim();
        public string IDType => cmbIDType.SelectedItem?.ToString() ?? "";
        public string IDNumber => txtIDNumber.Text.Trim();
        public string PassportNo => txtPassportNumber.Text.Trim();
        public string Email => txtEmail.Text.Trim();
        public string Phone => txtPhone.Text.Trim();
        public string Gender => cmbGender.SelectedItem?.ToString() ?? "";
        public int Age => int.TryParse(txtAge.Text, out int a) ? a : 0;
        public bool HasPeanutAllergy => chkPeanutAllergy.Checked;
        public bool NeedsWheelchair => chkWheelchair.Checked;
        public bool IsUnaccompaniedMinor => chkUnaccompaniedMinor.Checked;
        public string GuardianName => txtGuardianName.Text.Trim();
        public string GuardianPhone => txtGuardianPhone.Text.Trim();
        public string GuardianRelation => txtGuardianRelation.Text.Trim();

        public RAPassengerDetails()
        {
            InitializeComponent();
        }

        private void RAPassengerDetails_Load(object sender, EventArgs e)
        {
            cmbGender.SelectedIndex = 0;
            cmbIDType.SelectedIndex = 0;
            cmbSeatClass.SelectedIndex = 0;
            dtpBirthdate.MaxDate = DateTime.Today;
            dtpBirthdate.Value = DateTime.Today.AddYears(-18);
            ComputeAge();

            cmbSeatClass.SelectedIndexChanged += CmbSeatClass_SelectedIndexChanged;
            UpdateSeatClassDesc();

            // Wire all three to the combo validator
            chkPeanutAllergy.CheckedChanged += chkSpecial_CheckedChanged;
            chkWheelchair.CheckedChanged += chkSpecial_CheckedChanged;
            chkUnaccompaniedMinor.CheckedChanged += chkSpecial_CheckedChanged;
        }

        // ── Seat Class ────────────────────────────────────────────
        private void CmbSeatClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeatClassDesc();
        }

        private void UpdateSeatClassDesc()
        {
            var selected = cmbSeatClass.SelectedItem?.ToString() ?? "";
            lblSeatClassDesc.Text = _seatClassDesc.TryGetValue(selected, out var desc) ? desc : "";
        }

        // ── Special Request Combo Validation ──────────────────────
        // Allowed combos (pick any one or two):
        //   • Wheelchair only
        //   • Peanut Allergy only
        //   • Unaccompanied Minor only
        //   • Wheelchair + Peanut Allergy
        //   • Peanut Allergy + Unaccompanied Minor
        //   • Wheelchair + Unaccompanied Minor
        // Blocked:
        //   • All three checked at the same time
        private void chkSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressCheckEvent) return;

            bool peanut = chkPeanutAllergy.Checked;
            bool wheelchair = chkWheelchair.Checked;
            bool unaccompanied = chkUnaccompaniedMinor.Checked;

            // Block only when all three are checked
            if (peanut && wheelchair && unaccompanied)
            {
                BlockCheck(sender,
                    "You may only select up to two special requests at a time.\n\n" +
                    "Please deselect one of the options before continuing.");
                return;
            }

            // Valid state — sync guardian fields
            ToggleGuardianFields(chkUnaccompaniedMinor.Checked);
        }

        private void BlockCheck(object sender, string message)
        {
            _suppressCheckEvent = true;
            ((CheckBox)sender).Checked = false;
            _suppressCheckEvent = false;

            MessageBox.Show(
                message,
                "Too Many Selections",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // ── Birthdate / Age ───────────────────────────────────────
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

        // Kept to satisfy the designer wire-up; logic lives in chkSpecial_CheckedChanged
        private void chkUnaccompaniedMinor_CheckedChanged(object sender, EventArgs e) { }

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

        // ── Validation ────────────────────────────────────────────
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

            if (cmbSeatClass.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select a seat class.",
                    "Seat Class Required",
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