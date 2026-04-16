using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FlightReservationSystem.Helpers;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAPassengerDetails : UserControl
    {
        private int _passengerNumber = 1;
        private bool _suppressCheckEvent = false;
        private int _flightID;

        public event EventHandler OnProceed;

        // ── Validation Regex Patterns ────────────────────────────────────────
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        private static readonly Regex NameRegex = new Regex(@"^[a-zA-Z\s\-']+$");
        private static readonly Regex PhoneRegex = new Regex(@"^\+?[0-9]{7,15}$");

        // ── Seat class descriptions ───────────────────────────────────────────
        private static readonly Dictionary<string, string> _seatClassDesc =
            new Dictionary<string, string>
            {
                ["Economy"] = "Standard seating with essential amenities.",
                ["Comfort"] = "Extra legroom, priority boarding, and enhanced meals.",
                ["Business"] = "Lie-flat seats, premium dining, and lounge access."
            };

        // ── Seat classes per aircraft model ───────────────────────────────────
        private static readonly Dictionary<string, List<string>> _modelSeatClasses =
            new Dictionary<string, List<string>>
            {
                ["airbusa319100"] = new List<string> { "Economy", "Comfort", "Business" },
                ["airbusa320200"] = new List<string> { "Economy", "Comfort", "Business" },
                ["airbusa320neo"] = new List<string> { "Economy", "Comfort", "Business" },
                ["airbusa321200"] = new List<string> { "Economy", "Comfort", "Business" },
                ["airbusa321neo"] = new List<string> { "Economy", "Comfort", "Business" },
                ["atr72600"] = new List<string> { "Economy", "Comfort" },
                ["boeing737700"] = new List<string> { "Economy", "Comfort", "Business" },
                ["boeing737800"] = new List<string> { "Economy", "Comfort", "Business" },
                ["boeing737900er"] = new List<string> { "Economy", "Comfort", "Business" },
                ["dhc8400"] = new List<string> { "Economy", "Comfort" }
            };

        // ── Properties ────────────────────────────────────────────────────────
        public int PassengerNumber
        {
            get => _passengerNumber;
            set { _passengerNumber = value; lblTitle.Text = $"Passenger {value} — Details"; }
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
            dtpBirthdate.MaxDate = DateTime.Today;
            dtpBirthdate.Value = DateTime.Today.AddYears(-18);
            ComputeAge();

            cmbSeatClass.SelectedIndexChanged += (s, ev) => UpdateSeatClassDesc();
            chkPeanutAllergy.CheckedChanged += chkSpecial_CheckedChanged;
            chkWheelchair.CheckedChanged += chkSpecial_CheckedChanged;
            chkUnaccompaniedMinor.CheckedChanged += chkSpecial_CheckedChanged;
            dtpBirthdate.ValueChanged += dtpBirthdate_ValueChanged;

            txtPhone.KeyPress += FilterNumeric;
            txtGuardianPhone.KeyPress += FilterNumeric;
            txtFirstName.KeyPress += FilterAlpha;
            txtLastName.KeyPress += FilterAlpha;
            txtGuardianName.KeyPress += FilterAlpha;
        }

        private string CleanModelName(string name)
            => name?.ToLower().Replace(" ", "").Replace("-", "").Replace("_", "") ?? "";

        public void LoadSeatClasses(int flightID)
        {
            _flightID = flightID;
            string modelName = FetchModelName(flightID);
            List<string> classes = ResolveClasses(modelName);

            cmbSeatClass.Items.Clear();
            cmbSeatClass.Items.AddRange(classes.ToArray());
            cmbSeatClass.SelectedIndex = 0;
            UpdateSeatClassDesc();
        }

        private string FetchModelName(int flightID)
        {
            const string sql = @"
                SELECT m.Model 
                FROM Flights f
                INNER JOIN Aircrafts a ON f.Aircraft = a.AircraftID
                INNER JOIN AircraftModels m ON a.Model = m.ModelID
                WHERE f.FlightID = @fid";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightID);
                    conn.Open();
                    return cmd.ExecuteScalar()?.ToString().Trim() ?? string.Empty;
                }
            }
            catch { return string.Empty; }
        }

        private List<string> ResolveClasses(string modelName)
        {
            string cleaned = CleanModelName(modelName);
            if (_modelSeatClasses.TryGetValue(cleaned, out var classes))
                return classes;

            return new List<string> { "Economy", "Comfort", "Business" };
        }

        private void UpdateSeatClassDesc()
        {
            var selected = cmbSeatClass.SelectedItem?.ToString() ?? "";
            lblSeatClassDesc.Text = _seatClassDesc.TryGetValue(selected, out var desc) ? desc : "";
        }

        private void chkSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressCheckEvent) return;

            int count = (chkPeanutAllergy.Checked ? 1 : 0) +
                        (chkWheelchair.Checked ? 1 : 0) +
                        (chkUnaccompaniedMinor.Checked ? 1 : 0);

            if (count > 2)
            {
                _suppressCheckEvent = true;
                ((CheckBox)sender).Checked = false;
                _suppressCheckEvent = false;

                MessageBox.Show("Maximum of two special requests allowed.", "Selection Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleGuardianFields(chkUnaccompaniedMinor.Checked);
        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            ComputeAge();
            if (Age < 18)
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

        private void ToggleGuardianFields(bool show)
        {
            lblGuardianName.Visible = txtGuardianName.Visible = show;
            lblGuardianPhone.Visible = txtGuardianPhone.Visible = show;
            lblGuardianRelation.Visible = txtGuardianRelation.Visible = show;

            pnlSpecial.Height = show ? 175 : 100;
            btnProceed.Top = pnlSpecial.Bottom + 12;
            pnlMain.ScrollControlIntoView(btnProceed);
        }

        public bool ValidatePassenger()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Nationality) || string.IsNullOrWhiteSpace(IDNumber) ||
                string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone))
                return ValidationError("Please fill in all required passenger details.");

            if (!NameRegex.IsMatch(FirstName) || !NameRegex.IsMatch(LastName))
                return ValidationError("Names should only contain letters, spaces, or hyphens.");

            if (!EmailRegex.IsMatch(Email))
                return ValidationError("Please enter a valid email address.");

            if (!PhoneRegex.IsMatch(Phone))
                return ValidationError("Please enter a valid phone number (7-15 digits).");

            if (Age < 2)
                return ValidationError("Infant passengers (under 2) must be booked via special process.");

            if (chkUnaccompaniedMinor.Checked)
            {
                if (string.IsNullOrWhiteSpace(GuardianName) || string.IsNullOrWhiteSpace(GuardianPhone) || string.IsNullOrWhiteSpace(GuardianRelation))
                    return ValidationError("Guardian details are required for minors.");
            }

            return true;
        }

        private bool ValidationError(string message)
        {
            MessageBox.Show($"Passenger {PassengerNumber}: {message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void FilterNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+') e.Handled = true;
        }

        private void FilterAlpha(object sender, KeyPressEventArgs e)
        {

        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (ValidatePassenger()) OnProceed?.Invoke(this, EventArgs.Empty);
        }

        // ── RESTORED: Keep this to prevent Designer errors ────────────────────
        private void chkUnaccompaniedMinor_CheckedChanged(object sender, EventArgs e)
        {
            // Empty method satisfies the Designer wire-up
        }
    }
}