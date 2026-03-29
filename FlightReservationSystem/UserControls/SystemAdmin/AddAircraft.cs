using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class AddAircraft : UserControl
    {
        public AddAircraft()
        {
            InitializeComponent();
            InitData();
            InitUI();
        }

        private void InitData()
        {
            ShowAircraftID();
            ApplyModelCMBData();
            ApplyAirlineCMBData();
            ApplyAirportCMBData();
            ShowToolTips();
        }

        private void InitUI()
        {
            PopulateErrorUI();
            ShowProgress();
        }

        private void PopulateErrorUI()
        {
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider1, Target = lblModel, Field = cmbModelVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider2, Target = lblAircraftName, Field = tbAircraftNameVal, DefaultValue = String.Empty });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider3, Target = lblAirline, Field = cmbAirlineVal, DefaultValue = 0 });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider4, Target = lblAirport, Field = cmbAirportVal, DefaultValue = 6 });
        }

        private void ShowAircraftID()
        {
            string acID = AircraftManager.NewAircraftID();
            lblAircraftIDVal.Text = acID;
        }

        public void ShowProgress()
        {
            lblProgressVal.Text = $"Adding aircraft (1/3)";
        } 

        private void ApplyModelCMBData()
        {
            var aircraftModelCollection = AircraftManager.GetAircraftModelCollection;

            if (aircraftModelCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < aircraftModelCollection.Count; i++)
            {
                var aircraftModelRecord = aircraftModelCollection[i];
                string display = aircraftModelRecord.Name;
                int id = aircraftModelRecord.ID;

                itemList.Add(new CMBItemWTag { Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbModelVal.DisplayMember = "Display";
            cmbModelVal.ValueMember = "Value";
            cmbModelVal.DataSource = itemList;
            cmbModelVal.SelectedIndex = 0;
            cmbModelVal.AutoCompleteCustomSource.Clear();
            cmbModelVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ShowSetMapPreview()
        {
            var aircraftModelUICollection = AircraftManager.GetAircraftModelUICollection;

            if (aircraftModelUICollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelUICollection is empty. Showing seat map preview aborted.");
                return;
            }

            var selectedModelValue = cmbModelVal.SelectedValue;

            for (int i = 0; i < aircraftModelUICollection.Count; i++)
            {
                var aircraftModelUIRecord = aircraftModelUICollection[i];

                if (selectedModelValue is int modelVal && aircraftModelUIRecord.ID == modelVal)
                {
                    var modelUI = aircraftModelUIRecord.UI;
                    picSeatMapPreview.Image = AircraftManager.SeatMapToImg(modelUI);
                    return;
                }
            }
        }

        private void ApplyAirlineCMBData()
        {
            var airlineCollection = AirlineManager.GetAirlineCollection;

            if (airlineCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airlineCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < airlineCollection.Count; i++)
            {
                var airlineRecord = airlineCollection[i];
                var display = $"{airlineRecord.Name} {airlineRecord.IATA}";
                var id = airlineRecord.ID;

                itemList.Add(new CMBItemWTag { Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbAirlineVal.DisplayMember = "Display";
            cmbAirlineVal.ValueMember = "Value";
            cmbAirlineVal.DataSource = itemList;
            cmbAirlineVal.SelectedIndex = 0;
            cmbAirlineVal.AutoCompleteCustomSource.Clear();
            cmbAirlineVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ApplyAirportCMBData()
        {
            var airportCollection = AirportManager.GetAirportCollection;

            if (airportCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airportCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < airportCollection.Count; i++)
            {
                var airportRecord = airportCollection[i];
                string display = $"{airportRecord.IATA} - {airportRecord.Name} ({airportRecord.DisplayCity})";
                var id = airportRecord.ID;

                itemList.Add(new CMBItemWTag{ Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbAirportVal.DisplayMember = "Display";
            cmbAirportVal.ValueMember = "Value";
            cmbAirportVal.DataSource = itemList;
            cmbAirportVal.SelectedIndex = 6;
            cmbAirportVal.AutoCompleteCustomSource.Clear();
            cmbAirportVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ShowToolTips()
        {
            toolTip1.SetToolTip(picQuestion1, "A combination of the aircraft model and aircraft name.");
            toolTip3.SetToolTip(picQuestion2, "Complete all progress to enable aircraft for reservation.");
        }

        private bool AreAddAircraftFieldsValid(string aircraft, int model, int airline, int airport)
        {
            if (!ValueChecker.IsStringValid(aircraft, nameof(aircraft)) || !ValueChecker.IsIntValid(model, nameof(model)) ||
                model == 0 || !ValueChecker.IsIntValid(airline, nameof(airline)) ||
                airline == 0 || !ValueChecker.IsIntValid(airport, nameof(airport)) ||
                airport == 0)
            {
                DebugLogger.LogWithStackTrace("Wrong value from AddAircraft. Adding aircraft aborted.");
                MessageBoxHelper.ShowErrorMessage("Incorrect value.");
                return false;
            }

            return true;
        }

        private void UpdateDisplayName()
        {
            string selectedModelDisplay = cmbModelVal.Text;
            string trimmedAircraftname = tbAircraftNameVal.Text.Trim();

            if (trimmedAircraftname.Length == 0) lblDisplayNameVal.Text = $"{selectedModelDisplay}";
            else lblDisplayNameVal.Text = $"{selectedModelDisplay} - {trimmedAircraftname}";
        }

        private void lblDisplayNameVal_MouseHover(object sender, EventArgs e)
        {
            var lbl = (Label)sender;

            Size textSize = TextRenderer.MeasureText(lbl.Text, lbl.Font);

            if (textSize.Width > lbl.ClientSize.Width) toolTip2.SetToolTip(lbl, lbl.Text); 
            else toolTip2.SetToolTip(lbl, null);
        }

        private void cmbModelVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Automatically change totalSeats label
            var aircraftModelCollection = AircraftManager.GetAircraftModelCollection;

            if (aircraftModelCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Label update aborted.");
                return;
            }

            var selectedModelValue = cmbModelVal.SelectedValue;

            for (int i = 0; i < aircraftModelCollection.Count; i++)
            {
                var aircraftModelRecord = aircraftModelCollection[i];

                if (selectedModelValue is int modelVal && aircraftModelRecord.ID == modelVal)
                {
                    lblTotalSeatsVal.Text = aircraftModelRecord.TotalSeats.ToString();
                    break;
                }
            }

            // Show airport model's seat map preview
            ShowSetMapPreview();

            // Update display name based on input
            UpdateDisplayName();
        }

        private void cmbModelVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbModelVal upon leave
            var cmbModelItems = cmbModelVal.Items;

            if (cmbModelItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbModelItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedModelDisplay = cmbModelVal.Text;

            for (int i = 0; i < cmbModelItems.Count; i++)
            {
                var modelDisplay = cmbModelVal.GetItemText(cmbModelVal.Items[i]);

                if (modelDisplay.IndexOf(selectedModelDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbModelVal.SelectedIndex = i;
                    return;
                }
            }

            cmbModelVal.SelectedIndex = 0;
        }

        private void tbAircraftNameVal_TextChanged(object sender, EventArgs e)
        {
            // Update display name based on input
            UpdateDisplayName();
        }

        private void cmbAirlineVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Automatically change airline image
            var airlineCollection = AirlineManager.GetAirlineCollection;

            if (airlineCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airlineCollection is empty. Updating image aborted.");
                return;
            }

            var selectedAirlineValue = cmbAirlineVal.SelectedValue;

            for (int i = 0; i <  airlineCollection.Count; i++)
            {
                var airlineRecord = airlineCollection[i];

                if (selectedAirlineValue is int airlineVal && airlineRecord.ID == airlineVal)
                {
                    picAirlineImg.Image = AirlineManager.AirlineToImage(airlineRecord.ICAO);
                    return;
                }
            }
        }

        private void cmbAirlineVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbAirlineVal upon leave
            var cmbAirlineItems = cmbAirlineVal.Items;

            if (cmbAirlineItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbAirlineItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedAirlineDisplay = cmbAirlineVal.Text;

            for (int i = 0; i < cmbAirlineItems.Count; i++)
            {
                var airlineDisplay = cmbAirlineVal.GetItemText(cmbAirlineVal.Items[i]);

                if (airlineDisplay.IndexOf(selectedAirlineDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbAirlineVal.SelectedIndex = i;
                    return;
                } 
            }

            cmbAirlineVal.SelectedIndex = 0;
        }

        private void AddAircraft_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
            // Add aircraft
            DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to add this aircraft?");
            if (result == DialogResult.No) return;

            string aircraft = lblDisplayNameVal.Text;
            int model = cmbModelVal.SelectedValue is int modelVal ? modelVal : 0;
            int airline = cmbAirlineVal.SelectedValue is int airlineVal ? airlineVal : 0;
            int airport = cmbAirportVal.SelectedValue is int airportVal ? airportVal : 0;
            string baseName = tbAircraftNameVal.Text.Trim();

            if (!AreAddAircraftFieldsValid(aircraft, model, airline, airport)) return;
            AircraftManagement.AddAircraft(aircraft, model, airline, airport, baseName);
        }
    }
}
