using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class AssignCrews : UserControl
    {
        private static AssignCrews Current { get; set; } = null;
        public static Label _lblBirthdate => Current.lblBirthdate;
        public static Label _lblCrew => Current.lblCrew;
        public ComboBox _cmbAircraftVal => Current.cmbAircraftVal;
        public ComboBox _cmbCrewVal => Current.cmbCrewVal;
        public DataGridView _dgvPilotsVal => Current.dgvPilotsVal;
        public DataGridView _dgvFlightAttendantsVal => Current.dgvFlightAttendantsVal;
        public Label _lblCrewIDVal => Current.lblCrewIDVal;
        public Label _lblPilotFilled => Current.lblPilotFilled;
        public Label _lblFlightAttendantsFilled => Current.lblFlightAttendantsFilled;


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
            ApplyGenderCMBData();
            ApplyTypeCMBData();
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
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider3, Target = lblLastName, Field = tbLastNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider4, Target = lblFirstName, Field = tbFirstNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider5, Target = lblMiddleName, Field = tbMiddleNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider7, Target = lblGender, Field = cmbGenderVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider8, Target = lblType, Field = cmbTypeVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider9, Target = lblPilotsCount, Field = dgvPilotsVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider10, Target = lblFlightAttendantsCount, Field = dgvFlightAttendantsVal, DefaultValue = 0 });
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

        private void UpdateFilledStat()
        {
            if (dgvPilotsVal.Rows.Count == 2) lblPilotFilled.Visible = true;
            else lblPilotFilled.Visible = false;

            var aircraftCollection = AircraftManager.GetAircraftCollection;

            if (aircraftCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftCollection is empty. Updating aborted.");
                return;
            }

            var aircraftModelCollection = AircraftManager.GetAircraftModelCollection;

            if (aircraftModelCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Checking aborted.");
                return;
            }

            int selectedAircraftValue = cmbAircraftVal.SelectedValue is int aircraftVal ? aircraftVal : 0;

            for (int i = 0; i < aircraftCollection.Count; i++)
            {
                var aircraftRecord = aircraftCollection[i];

                if (aircraftRecord.ID == selectedAircraftValue)
                {
                    for (int j = 0; j < aircraftModelCollection.Count; j++)
                    {
                        var aircraftModelRecord = aircraftModelCollection[j];

                        if (aircraftRecord.ModelID == aircraftModelRecord.ID && dgvFlightAttendantsVal.Rows.Count == aircraftModelRecord.FlightAttenantsCount)
                        {
                            lblFlightAttendantsFilled.Visible = true;
                            return;
                        }
                        else lblFlightAttendantsFilled.Visible = false;
                    }
                }
            }
        }

        public void ApplyCrewCMBData()
        {
            UpdateFilledStat();

            var crewCollection = AircraftManager.GetCrewCollection;

            if ((_dgvPilotsVal.Rows.Count + dgvFlightAttendantsVal.Rows.Count) - crewCollection.Count == 0)
            {
                lblCrewNameVal.Text = string.Empty;
                lblCrewBirthdateVal.Text = string.Empty;
                lblCrewGenderVal.Text = string.Empty;
                lblCrewTypeVal.Text = string.Empty;
                cmbCrewVal.DataSource = null;
                return;
            }

            var assignedIDs = new HashSet<int>();

            for (int i = 0; i < dgvPilotsVal.Rows.Count; i++)
            {
                assignedIDs.Add(Convert.ToInt32(dgvPilotsVal.Rows[i].Cells[0].Value));
            }

            for (int i = 0; i < dgvFlightAttendantsVal.Rows.Count; i++)
            {
                assignedIDs.Add(Convert.ToInt32(dgvFlightAttendantsVal.Rows[i].Cells[0].Value));
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();
            var seenIDs = new HashSet<int>();
            for (int i = 0; i < crewCollection.Count; i++)
            {
                var crewRecord = crewCollection[i];

                if (crewRecord.Status != 1) continue;
                if (assignedIDs.Contains(crewRecord.ID)) continue;
                if (!seenIDs.Add(crewRecord.ID)) continue;

                string display = $"{crewRecord.ID:0000} - {crewRecord.LastName}, {crewRecord.FirstName} {crewRecord.MiddleName}";
                int id = crewRecord.ID;

                itemList.Add(new CMBItemWTag { Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbCrewVal.DisplayMember = "Display";
            cmbCrewVal.ValueMember = "Value";
            cmbCrewVal.DataSource = itemList;
            cmbCrewVal.AutoCompleteCustomSource.Clear();
            cmbCrewVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());

            if (itemList.Count == 0)
            {
                lblCrewNameVal.Text = string.Empty;
                lblCrewBirthdateVal.Text = string.Empty;
                lblCrewGenderVal.Text = string.Empty;
                lblCrewTypeVal.Text = string.Empty;
                cmbCrewVal.Text = string.Empty;
            }
        }

        private void ApplyGenderCMBData()
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

        public void ApplyTypeCMBData()
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
            if (!(birthdate <= today.AddYears(-18))) ErrorManager.AddError(new ErrorRecord { Message = "Age must be 18 years or older.", AssociatedControls = { lblBirthdate } });

            if (ErrorManager.GetErrorCollection.Count != 0)
            {
                ErrorManager.ShowAlert();
                ErrorManager.HighlightErrors(true);
                return false;
            }

            return true;
        }

        private bool DoesSelectedRowsExist()
        {
            if (dgvPilotsVal.SelectedRows.Count == 0 && dgvFlightAttendantsVal.SelectedRows.Count == 0) ErrorManager.AddError(new ErrorRecord { Message = "No rows selected for clearing.", AssociatedControls = { lblPilotsCount, lblFlightAttendantsCount } });

            if (ErrorManager.GetErrorCollection.Count != 0)
            {
                ErrorManager.ShowAlert();
                ErrorManager.HighlightErrors(true);
                return false;
            }

            return true;
        }

        public bool IsDGVFilledUp(string dgv)
        {
            if (dgvPilotsVal.Name == dgv && dgvPilotsVal.Rows.Count == 2) return true;

            if (dgvFlightAttendantsVal.Name != dgv) return false;

            var aircraftCollection = AircraftManager.GetAircraftCollection;

            if (aircraftCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftCollection is empty. Checking aborted.");
                return false;
            }

            var aircraftModelCollection = AircraftManager.GetAircraftModelCollection;

            if (aircraftModelCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Checking aborted.");
                return false;
            }

            int selectedAircraftValue = cmbAircraftVal.SelectedValue is int aircraftVal ? aircraftVal : 0;

            for (int i = 0; i < aircraftCollection.Count; i++)
            {
                var aircraftRecord = aircraftCollection[i];

                if (aircraftRecord.ID == selectedAircraftValue)
                {
                    for (int j = 0; j < aircraftModelCollection.Count; j++)
                    {
                        var aircraftModelRecord = aircraftModelCollection[j];

                        if (aircraftRecord.ModelID == aircraftModelRecord.ID && dgvFlightAttendantsVal.Rows.Count == aircraftModelRecord.FlightAttenantsCount) return true;
                    }
                }
            }

            return false;
        }

        private bool IsAssignmentFinished()
        {
            if (!IsDGVFilledUp("dgvPilotsVal")) ErrorManager.AddError(new ErrorRecord { Message = "Pilot crews not filled up.", AssociatedControls = { lblPilotsCount } });
            if (!IsDGVFilledUp("dgvFlightAttendantsVal")) ErrorManager.AddError(new ErrorRecord { Message = "Flight attendants not filled up.", AssociatedControls = { lblFlightAttendantsCount } });

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

        private void lblAirportVal_MouseHover(object sender, EventArgs e)
        {
            var lbl = (Label)sender;

            Size textSize = TextRenderer.MeasureText(
                lbl.Text,
                lbl.Font
            );

            if (textSize.Width > lbl.ClientSize.Width) toolTip2.SetToolTip(lbl, lbl.Text);
            else toolTip2.SetToolTip(lbl, null);
        }

        private void cmbAircraftVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update aircraft info
            if (dgvPilotsVal.Rows.Count != 0 || dgvFlightAttendantsVal.Rows.Count != 0)
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");

                if (result == DialogResult.No) return;
                else
                {
                    ErrorManager.DefaultValueFields();
                    DataSeeder.PopulateAircraftStat1();
                    ApplyCrewCMBData();
                }
            }

            var aircraftCollection = AircraftManager.GetAircraftCollection;

            if (aircraftCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftCollection is empty. Updating aircraft info aborted.");
                return;
            }

            int selectedAircraftValue = cmbAircraftVal.SelectedValue is int aircraftVal ? aircraftVal : 0;

            for (int i = 0; i < aircraftCollection.Count; i++)
            {
                var aircraftRecord = aircraftCollection[i];

                if (aircraftRecord.ID == selectedAircraftValue)
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
                            lblAirportVal.Text = $"{airportRecord.IATA} - {airportRecord.Name} ({airportRecord.DisplayCity})";
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

            if (textSize.Width > lbl.ClientSize.Width) toolTip3.SetToolTip(lbl, lbl.Text); 
            else toolTip3.SetToolTip(lbl, null); 
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

            int selectedCrewValue = cmbCrewVal.SelectedValue is int crewVal ? crewVal : 0;

            for (int i = 0; i < crewCollection.Count; i++)
            {
                var crewRecord = crewCollection[i];
                bool valid = true;

                if (dgvPilotsVal.Rows.Count != 0)
                {
                    for (int j = 0; j < dgvPilotsVal.Rows.Count; j++)
                    {
                        int crewID = Convert.ToInt32(dgvPilotsVal.Rows[j].Cells[0].Value);

                        if (crewID == crewRecord.ID)
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                if (dgvFlightAttendantsVal.Rows.Count != 0)
                {
                    for (int j = 0; j < dgvFlightAttendantsVal.Rows.Count; j++)
                    {
                        int crewID = Convert.ToInt32(dgvFlightAttendantsVal.Rows[j].Cells[0].Value);

                        if (crewID == crewRecord.ID)
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                if (valid && crewRecord.ID == selectedCrewValue)
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

        private void AssignCrews_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnAddCrewSel_Click(object sender, EventArgs e)
        {
            // Add crew to dgv from selection
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();
            CrewManagement.AddSelectedCrew(this);
        }

        private void btnAddCrew_Click(object sender, EventArgs e)
        {
            // Add crew to dgv and collection
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();

            string id = lblCrewIDVal.Text;
            string lastName = tbLastNameVal.Text.Trim();
            string firstName = tbFirstNameVal.Text.Trim();
            string middleName = tbMiddleNameVal.Text.Trim();
            DateTime birthdate = dtpBirthdateVal.Value.Date;
            string gender = cmbGenderVal.Text;
            int type = cmbTypeVal.SelectedValue is int typeVal ? typeVal : 0;

            if (!AreManualAddFieldsValid(lastName, firstName, birthdate)) return;
            CrewManagement.AddCrew(id, lastName, firstName, middleName, birthdate, gender, type, this);
            dtpBirthdateVal.Value = DateTime.Today;
        }

        private void btnAssignCrews_Click(object sender, EventArgs e)
        {
            // Assign crews
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();

            if (!IsAssignmentFinished()) return;

            DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to assign the crews to the aircraft?");

            if (result == DialogResult.No) return;

            CrewManagement.AssignCrewsToAircraft(this);
            MainForm.Init(new AssignCrews());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Remove selected rows
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();

            if (!DoesSelectedRowsExist()) return;

            DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to remove the selected rows?");
            
            if (result == DialogResult.No) return;  

            CrewManagement.RemoveSelectedRows(this);   
        }
    }
}
