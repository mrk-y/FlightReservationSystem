using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Data.Reference.Seat;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class AddAircraft : UserControl, ControlResolver.IAcceptButton
    {
        public Button AcceptButton => btnAddAircraft;

        public AddAircraft()
        {
            InitializeComponent();
            InitData();
            InitUI();
        }

        public void Init(MainForm mainForm)
        {
            mainForm.AcceptButton = AcceptButton;
        }

        private void InitData()
        {
            ShowAircraftID();
            PopulateModelCMBData();
            PopulateAirlineCMBData();
            PopulateAirportCMBData();
            ShowToolTips();
            SAProgress.ShowProgress(0, "Adding aircraft");
        }

        private void InitUI()
        {
            ShowLegendColors();
        }

        private void ShowAircraftID()
        {
            string acID = IDGenerator.AircraftID();
            lblAircraftIDVal.Text = acID;
        }

        private void PopulateModelCMBData()
        {
            var aircraftModelCollection = AircraftModelCollection.Get;

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
                string model = aircraftModelRecord.Model;
                int id = aircraftModelRecord.ID;

                itemList.Add(new CMBItemWTag
                {
                    Display = model,
                    Tag = id
                });
                sourceList.Add(model);
            }

            if (itemList.Count == 0)
            {
                DebugLogger.LogWithStackTrace("itemList is empty. Applying data aborted.");
                return;
            }

            if (sourceList.Count == 0)
            {
                DebugLogger.LogWithStackTrace("sourceList is empty. Applying data aborted.");
                return;
            }

            cmbModelVal.Items.Clear();
            cmbModelVal.Items.AddRange(itemList.ToArray());
            cmbModelVal.SelectedIndex = 9;

            cmbModelVal.AutoCompleteCustomSource.Clear();
            cmbModelVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ShowSetMapPreview()
        {
            var aircraftModelUIColelction = AircraftModelUICollection.Get;
            
            if (aircraftModelUIColelction.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelUIColelction is empty. Showing seat map preview aborted.");
                return;
            }
            
            var itemAircraftModelSelected = cmbModelVal.SelectedItem as CMBItemWTag;
            
            for (int i = 0; i < aircraftModelUIColelction.Count; i++)
            {
                var aircraftModelUIRecord = aircraftModelUIColelction[i];

                if (itemAircraftModelSelected.Tag is int tagVal && aircraftModelUIRecord.ID == tagVal)
                {
                    var modelUI = aircraftModelUIRecord.ModelUI;
                    picSeatMapPreview.Image = ToImageConverter.UserControlToImg(modelUI);
                    break;
                }
            }
        }

        private void PopulateAirlineCMBData()
        {
            var airlineCollection = AirlineCollection.Get;

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
                int id = airlineRecord.ID;
                string displayVal = $"{airlineRecord.AirlineName} ({airlineRecord.IATA})";

                itemList.Add(new CMBItemWTag
                {
                    Display = displayVal,
                    Tag = id
                });
                sourceList.Add(displayVal);
            }

            if (itemList.Count == 0)
            {
                DebugLogger.LogWithStackTrace("itemList is empty. Applying data aborted.");
                return;
            }

            if (sourceList.Count == 0)
            {
                DebugLogger.LogWithStackTrace("sourceList is empty. Applying data aborted.");
                return;
            }

            cmbAirlineVal.Items.Clear();
            cmbAirlineVal.Items.AddRange(itemList.ToArray());
            cmbAirlineVal.SelectedIndex = 0;

            cmbAirlineVal.AutoCompleteCustomSource.Clear();
            cmbAirlineVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void PopulateAirportCMBData()
        {
            var airportCollection = AirportCollection.Get;

            if (airportCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airportCollection is empty. Applying data aborted.");
                return;
            }

            var airportRecord = airportCollection[6];

            cmbAirportVal.Items.Clear();
            cmbAirportVal.Items.Add($"{airportRecord.IATA} - {airportRecord.AirportName} ({airportRecord.DisplayCity})");
            cmbAirportVal.SelectedIndex = 0;
        }

        private void ShowToolTips()
        {
            toolTip1.SetToolTip(picQuestion1, "Display Name is a combination of the aircraft model and aircraft name.");
        }

        private void ShowLegendColors()
        {
            btnRegPass.BackColor = SeatUICollection.Get[0].BackColor;
            btnRegPass.FlatAppearance.BorderColor = SeatUICollection.Get[0].BorderColor;

            btnExitRow.BackColor = SeatUICollection.Get[1].BackColor;
            btnExitRow.FlatAppearance.BorderColor = SeatUICollection.Get[1].BorderColor;

            btnPassWNuatAller.BackColor = SeatUICollection.Get[2].BackColor;
            btnPassWNuatAller.FlatAppearance.BorderColor = SeatUICollection.Get[2].BorderColor;

            btnUnaccomMinor.BackColor = SeatUICollection.Get[3].BackColor;
            btnUnaccomMinor.FlatAppearance.BorderColor = SeatUICollection.Get[3].BorderColor;

            btnWheelPass.BackColor = SeatUICollection.Get[4].BackColor;
            btnWheelPass.FlatAppearance.BorderColor = SeatUICollection.Get[4].BorderColor;
        }

        private void cmbModelVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Automatically change totalSeats label
            var aircraftModelCollection = AircraftModelCollection.Get;

            if (aircraftModelCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Label update aborted.");
                return;
            }

            var itemModelSelected = cmbModelVal.SelectedItem as CMBItemWTag;

            for (int i = 0; i < aircraftModelCollection.Count; i++)
            {
                var aircraftModelRecord = aircraftModelCollection[i];

                if (itemModelSelected.Tag is int tagVal && aircraftModelRecord.ID == tagVal) 
                {
                    lblTotalSeatsVal.Text = aircraftModelRecord.TotalSeats.ToString();
                    break;
                }
            }

            // Show aircraft model's seat map preview
            ShowSetMapPreview();

            // Update display name based on input at start up
            if (string.IsNullOrWhiteSpace(lblDisplayNameVal.Text)) lblDisplayNameVal.Text = cmbModelVal.SelectedItem.ToString();
        }

        private void cmbModelVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbModelVal upon leave
            var cmbModelItems = cmbModelVal.Items;

            if (cmbModelItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbModelItems is empty. Selection on leave aborted.");
                return;
            }

            string itemModelSelected = cmbModelVal.Text.Trim();

            for (int i = 0; i < cmbModelVal.Items.Count; i++)
            {
                var item = cmbModelVal.Items[i] as CMBItemWTag;

                if (item.Display.IndexOf(itemModelSelected, StringComparison.OrdinalIgnoreCase) >= 0)
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
            string model = cmbModelVal.SelectedItem.ToString();
            string trimmedACName = tbAircraftNameVal.Text.Trim();

            if (trimmedACName.Length == 0) lblDisplayNameVal.Text = $"{model}";
            else lblDisplayNameVal.Text = $"{model} - {trimmedACName}";
        }

        private void cmbAirlineVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Automatically change airline image 
            var airlineCollection = AirlineCollection.Get;

            if (airlineCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airlineCollection is empty. Updating image aborted.");
                return;
            }

            var itemAirlineSelected = cmbAirlineVal.SelectedItem as CMBItemWTag;

            for (int i = 0; i < airlineCollection.Count; i++)
            {
                var airlineRecord = airlineCollection[i];

                if (itemAirlineSelected.Tag is int tagVal && airlineRecord.ID == tagVal)
                {
                    picAirlineImg.Image = ResourceGetter.GetAirlineImage(airlineRecord.ICAO);
                    break;
                }
            }
        }

        private void cmbAirlineVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbAirlineVal upon leave
            var cmbAirlineItems = cmbAirlineVal.Items;

            if (cmbAirlineItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbAirlineItems is empty. Selection on leave aborted.");
                return;
            }

            string itemAirlineSelected = cmbAirlineVal.Text.Trim();

            for (int i = 0; i < cmbAirlineVal.Items.Count; i++)
            {
                var item = cmbAirlineVal.Items[i] as CMBItemWTag;

                if (item.Display.IndexOf(itemAirlineSelected, StringComparison.OrdinalIgnoreCase) >= 0)
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
    }
}
