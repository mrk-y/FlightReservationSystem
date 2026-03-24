using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
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

        // public static Button enterBtn => btnAddAircraft;

        public AddAircraft()
        {
            InitializeComponent();
            InitData();
            InitUI();
        }

        public void Init(MainForm mainForm)
        {
            if (mainForm == null)
            {
                DebugLogger.LogWithStackTrace("mainForm is null. Initialization aborted.");
                return;
            }

            if (AcceptButton == null)
            {
                DebugLogger.LogWithStackTrace("AcceptButton is null. Initialization aborted.");
                return;
            }

            mainForm.AcceptButton = AcceptButton;
        }

        private void InitData()
        {
            ShowAircraftID();
            ModelCMBData();
            AirlineCMBData();
            AirportCMBData();
            ShowToolTips();
            saProgressStatus.Init(1);
        }

        private void InitUI()
        {

        }

        private void ShowAircraftID()
        {
            string acID = IDGenerator.AircraftID();

            if (string.IsNullOrWhiteSpace(acID))
            {
                DebugLogger.LogWithStackTrace("acID is null or whitespace. Showing ID aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(acID))
            {
                DebugLogger.LogWithStackTrace("acID starts or ends with space. Showing ID aborted.");
                return;
            }

            lblAircraftIDVal.Text = acID;
        }

        private void ModelCMBData()
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

                itemList.Add(new CMBItemWTag { Display = model, Tag = aircraftModelRecord.ID });
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
            cmbModelVal.SelectedIndex = 0;

            cmbModelVal.AutoCompleteCustomSource.Clear();
            cmbModelVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void AirlineCMBData()
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

                string iata = airlineRecord.IATA;
                string airlineName = airlineRecord.AirlineName;
                string displayVal = $"{airlineName} ({iata})"; 

                itemList.Add(new CMBItemWTag { Display = displayVal, Tag = airlineRecord.ID });
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

        private void AirportCMBData()
        {
            var airportCollection = AirportCollection.Get;

            if (airportCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airportCollection is empty. Applying data aborted.");
                return;
            }

            for (int i = 0; i < airportCollection.Count; i++)
            {
                var airportRecord = airportCollection[i];

                if (airportRecord.ID == 7)
                {
                    cmbAirportVal.Items.Clear();
                    cmbAirportVal.Items.Add($"{airportRecord.IATA} - {airportRecord.AirportName} ({airportRecord.DisplayCity})");
                    cmbAirportVal.SelectedIndex = 0;
                    return;
                }
            }
        }

        private void ShowToolTips()
        {
            toolTip1.SetToolTip(picQuestion1, "Display Name is a combination of the aircraft model and aircraft name.");
        }

        private void ShowLgendsSeatColors()
        {

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

            var form = this.FindForm();

            if (form == null)
            {
                DebugLogger.LogWithStackTrace("form is null. Navigation UI change aborted.");
                return;
            }

            MainFormUIHelper.UpdateNavigationState(this);
        }
    }
}
