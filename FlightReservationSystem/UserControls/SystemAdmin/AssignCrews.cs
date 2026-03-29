using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class AssignCrews : UserControl
    {
        private static AssignCrews Current { get; set; } = null;
        public static Label _lblBirthdate => Current.lblBirthdate;
        public static DataGridView _dgvPilotsVal => Current.dgvPilotsVal;
        public static DataGridView _dgvFlightAttendantsVal => Current.dgvFlightAttendantsVal;

        public AssignCrews()
        {
            InitializeComponent();
            InitData(); 
            InitUI();
        }
        private void InitData()
        {
            Current = this;

            if (Current == null)
            {
                DebugLogger.LogWithStackTrace("Current is null. Data initialization aborted.");
                return;
            }

            DataSeeder.PopulateAircraftStat1();
            DataSeeder.PopulateCrewStat1();
            ApplyAircraftCMBData();
            ApplyCrewCMBData();
            ApplyGenderData();
            ApplyTypeData();
            lblPilotsCount.Text = $"{2}";
            lblCrewIDVal.Text = $"{AircraftManager.NewCrewID()}";
        }

        private void InitUI()
        {
            PopulateErrorUI();
            ShowProgress();
        }

        private void PopulateErrorUI()
        {
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider1, Target = lblAircraft, Field = cmbAircraftVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider2, Target = lblCrew, Field = cmbCrewVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider3, Target = lblLastName, Field = tbLastNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider4, Target = lblFirstName, Field = tbFirstNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider5, Target = lblMiddleName, Field = tbMiddleNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider6, Target = lblBirthdate, Field = dtpBirthdateVal, DefaultValue = DateTime.Today });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider7, Target = lblGender, Field = cmbGenderVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider8, Target = lblType, Field = cmbTypeVal, DefaultValue = 0 });
        }

        private void ShowProgress()
        {
            lblProgressVal.Text = $"Assigning crews (2/3)";
        }

        private void ApplyAircraftCMBData()
        {
            var aircraftCollection = AircraftManager.GetAircraftCollection;

            if (aircraftCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < aircraftCollection.Count; i++)
            {
                var aircraftRecord = aircraftCollection[i];
             
                if (aircraftRecord.Status == 1)
                {
                    string display = $"RP-C{aircraftRecord.ID:0000} - {aircraftRecord.Name}";
                    int id = aircraftRecord.ID;

                    itemList.Add(new CMBItemWTag { Display = display, Value = id });
                    sourceList.Add(display);
                } 
            }

            cmbAircraftVal.DisplayMember = "Display";
            cmbAircraftVal.ValueMember = "Value";
            cmbAircraftVal.DataSource = itemList;
            cmbAircraftVal.SelectedIndex = 0;
            cmbAircraftVal.AutoCompleteCustomSource.Clear();
            cmbAircraftVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ApplyCrewCMBData()
        {
            var crewCollection = AircraftManager.GetCrewCollection;

            if (crewCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("crewCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < crewCollection.Count; i++)
            {
                var crewRecord = crewCollection[i];
             
                if (crewRecord.Status == 1)
                {
                    string display = $"{crewRecord.ID:0000} - {crewRecord.LastName}, {crewRecord.FirstName} {crewRecord.MiddleName}";
                    int id = crewRecord.ID;

                    itemList.Add(new CMBItemWTag { Display = display, Value = id });
                    sourceList.Add(display);
                }
            }

            cmbCrewVal.DisplayMember = "Display";
            cmbCrewVal.ValueMember = "Value";
            cmbCrewVal.DataSource = itemList;
            cmbCrewVal.SelectedIndex = 0;
            cmbCrewVal.AutoCompleteCustomSource.Clear();
            cmbCrewVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ApplyGenderData()
        {
            List<string> genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            genders.Add("N/A");
            cmbGenderVal.DataSource = genders;
            cmbGenderVal.SelectedIndex = 0;
            cmbGenderVal.AutoCompleteCustomSource.Clear();
            cmbGenderVal.AutoCompleteCustomSource.AddRange(genders.ToArray());
        }

        public void ApplyTypeData()
        {
            var crewTypeCollection = AircraftManager.GetCrewTypeCollection;

            if (crewTypeCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("crewTypeCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < crewTypeCollection.Count; i++)
            {
                var crewTypeRecord = crewTypeCollection[i];
                string display = $"{crewTypeRecord.Name}";
                int id = crewTypeRecord.ID;

                itemList.Add(new CMBItemWTag { Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbTypeVal.DisplayMember = "Display";
            cmbTypeVal.ValueMember = "Value";
            cmbTypeVal.DataSource = itemList;
            cmbTypeVal.SelectedIndex = 0;
            cmbTypeVal.AutoCompleteCustomSource.Clear();
            cmbTypeVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private bool AreManualAddFieldsValid(string lastName, string firstName, DateTime birthdate)
        {
            DateTime today = DateTime.Today;

            if (string.IsNullOrWhiteSpace(lastName)) ErrorManager.AddError(new ErrorRecord { Message = "Last name cannot be empty.", AssociatedControls = { lblLastName } });
            if (string.IsNullOrWhiteSpace(firstName)) ErrorManager.AddError(new ErrorRecord { Message = "First name cannot be empty.", AssociatedControls = { lblFirstName } });
            if (birthdate <= today.AddYears(-18)) ErrorManager.AddError(new ErrorRecord { Message = "Age must be 18 years or older.", AssociatedControls = { AssignCrews._lblBirthdate } });

            if (ErrorManager.GetErrorCollection.Count != 0)
            {
                ErrorManager.ShowAlert();
                ErrorManager.HighlightErrors(true);
                return false;
            }

            return true;
        }

        private void lblDisplayNameVal_MouseHover(object sender, EventArgs e)
        {
            var lbl = (Label)sender;

            Size textSize = TextRenderer.MeasureText(
                lbl.Text,
                lbl.Font
            );

            if (textSize.Width > lbl.ClientSize.Width) toolTip1.SetToolTip(lbl, lbl.Text);
            else toolTip1.SetToolTip(lbl, null);
        }

        private void cmbAircraftVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update aircraft info
            var aircraftCollection = AircraftManager.GetAircraftCollection;

            if (aircraftCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftCollection is empty. Updating aircraft info aborted.");
                return;
            }

            var selectedAircraftValue = cmbAircraftVal.SelectedValue;

            for (int i = 0; i < aircraftCollection.Count; i++)
            {
                var aircraftRecord = aircraftCollection[i];

                if (selectedAircraftValue is int aircraftVal && aircraftRecord.ID == aircraftVal)
                {
                    lblAircraftIDVal.Text = $"RP-C{aircraftRecord.ID:0000}";
                    lblDisplayNameVal.Text = $"{aircraftRecord.Name}";

                    var airlineCollection = AirlineManager.GetAirlineCollection;

                    if (airlineCollection.Count == 0)
                    {
                        DebugLogger.LogWithStackTrace("airlineCollection is empty. Updating aircraft info aborted.");
                        return;
                    }

                    for (int j = 0; j < airlineCollection.Count; j++)
                    {
                        var airlineRecord = airlineCollection[j];

                        if (airlineRecord.ID == aircraftRecord.AirlineID)
                        {
                            picAirlineImg.Image = AirlineManager.AirlineToImage(airlineRecord.ICAO);
                            lblAirlinesVal.Text = $"{airlineRecord.Name}";
                            break;
                        } 
                    }

                    var airportCollection = AirportManager.GetAirportCollection;

                    if (airportCollection.Count == 0)
                    {
                        DebugLogger.LogWithStackTrace("airportCollection is empty. Updating aircraft info aborted.");
                        return;
                    }

                    for (int j = 0; j < airportCollection.Count; j++)
                    {
                        var airportRecord = airportCollection[j];

                        if (airportRecord.ID == aircraftRecord.AirportID)
                        {
                            lblAirportVal.Text = $"{airportRecord.Name}";
                            break;
                        }
                    }

                    var aircraftModelCollection = AircraftManager.GetAircraftModelCollection;

                    if (aircraftModelCollection.Count == 0)
                    {
                        DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Updating aircraft info aborted.");
                        return;
                    }

                    for (int j = 0; j < aircraftModelCollection.Count; j++)
                    {
                        var aircraftModelRecord = aircraftModelCollection[j];

                        if (aircraftModelRecord.ID == aircraftRecord.ModelID)
                        {
                            lblFlightAttendantsCount.Text = $"{aircraftModelRecord.FlightAttenantsCount}";
                            break;
                        }
                    }

                    break;
                }
            }
        }

        private void cmbAircraftVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbAircraftVal upon leave
            var cmbAircraftItems = cmbAircraftVal.Items;

            if (cmbAircraftItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbAircraftItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedAircraftDisplay = cmbAircraftVal.Text;

            for (int i = 0; i < cmbAircraftItems.Count; i++)
            {
                var aircraftDisplay = cmbAircraftVal.GetItemText(cmbAircraftVal.Items[i]);

                if (aircraftDisplay.IndexOf(selectedAircraftDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbAircraftVal.SelectedIndex = i;
                    return;
                }
            }

            cmbAircraftVal.SelectedIndex = 0;
        }

        private void lblCrewNameVal_MouseHover(object sender, EventArgs e)
        {
            var lbl = (Label)sender;

            Size textSize = TextRenderer.MeasureText(
                lbl.Text,
                lbl.Font
            );

            if (textSize.Width > lbl.ClientSize.Width) toolTip2.SetToolTip(lbl, lbl.Text); 
            else toolTip2.SetToolTip(lbl, null); 
        }

        private void cmbCrewVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update crew info
            var crewCollection = AircraftManager.GetCrewCollection;

            if (crewCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("crewCollection is empty. Updating crew info aborted.");
                return;
            }

            var selectedCrewValue = cmbCrewVal.SelectedValue;

            for (int i = 0; i < crewCollection.Count; i++)
            {
                var crewRecord = crewCollection[i];

                if (selectedCrewValue is int crewVal && crewRecord.ID == crewVal)
                {
                    lblCrewNameVal.Text = $"{crewRecord.LastName}, {crewRecord.FirstName} {crewRecord.MiddleName}";
                    lblCrewBirthdateVal.Text = crewRecord.Birthdate.Date.ToString("yyyy-MM-dd");
                    lblCrewGenderVal.Text = $"{crewRecord.Gender}";

                    var crewTypeCollection = AircraftManager.GetCrewTypeCollection;

                    if (crewTypeCollection.Count == 0)
                    {
                        DebugLogger.LogWithStackTrace("crewTypeCollection is empty. Updating crew info aborted.");
                        return;
                    }

                    for (int j = 0; j < crewTypeCollection.Count; j++)
                    {
                        var crewTypeRecord = crewTypeCollection[j];

                        if (crewRecord.CrewTypeID == crewTypeRecord.ID)
                        {
                            lblCrewTypeVal.Text = $"{crewTypeRecord.Name}";
                            break;
                        }
                    }

                    break;
                }
            }
        }

        private void cmbCrewVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbCrewVal upon leave
            var cmbCrewItems = cmbCrewVal.Items;

            if (cmbCrewItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbCrewItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedCrewDisplay = cmbCrewVal.Text;

            for (int i = 0; i < cmbCrewItems.Count; i++)
            {
                var crewDisplay = cmbCrewVal.GetItemText(cmbCrewVal.Items[i]);

                if (crewDisplay.IndexOf(selectedCrewDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbCrewVal.SelectedIndex = i;
                    return;
                }
            }

            cmbCrewVal.SelectedIndex = 0;
        }

        private void cmbGenderVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbGenderVal upon leave
            var cmbGenderItems = cmbGenderVal.Items;

            if (cmbGenderItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbGenderItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedGenderDisplay = cmbGenderVal.Text;

            for (int i = 0; i < cmbGenderItems.Count; i++)
            {
                var genderDisplay = cmbGenderVal.GetItemText(cmbGenderVal.Items[i]);

                if (genderDisplay.IndexOf(selectedGenderDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbGenderVal.SelectedIndex = i;
                    return;
                }
            }

            cmbGenderVal.SelectedIndex = 0;
        }

        private void cmbTypeVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbTypeVal upon leave
            var cmbTypeItems = cmbTypeVal.Items;

            if (cmbTypeItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbTypeItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedTypeDisplay = cmbTypeVal.Text;

            for (int i = 0; i < cmbTypeItems.Count; i++)
            {
                var typeDisplay = cmbTypeVal.GetItemText(cmbTypeVal.Items[i]);

                if (typeDisplay.IndexOf(selectedTypeDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbTypeVal.SelectedIndex = i;
                    return;
                }
            }

            cmbTypeVal.SelectedIndex = 0;
        }

        private void btnAddCrew_Click(object sender, EventArgs e)
        {
            // Add crew to dgv and collection
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();

            int id = Convert.ToInt32(lblCrewIDVal.Text.Trim());
            string lastName = tbLastNameVal.Text.Trim();
            string firstName = tbFirstNameVal.Text.Trim();
            string middleName = tbMiddleNameVal.Text.Trim();
            DateTime birthdate = dtpBirthdateVal.Value.Date;
            string gender = cmbGenderVal.Text;
            string type = "";
            var selectdTypeValue = cmbTypeVal.SelectedValue;
            if (selectdTypeValue is int typeValue) type = cmbTypeVal.Text;

            if (!AreManualAddFieldsValid(lastName, firstName, birthdate)) return;

        }

        private void AssignCrews_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Aircrafts " +
                        "SET AssignedCrews = @AssignedCrews " +
                        "WHERE AircraftID = @AircraftID ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@AssignedCrews", "[1, 2]");
                        cmd.Parameters.AddWithValue("@AircraftID", 10);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated na bro.");
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}.");
                    return;
                }
            }
        }
    }
}
