using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
using GeoCoordinatePortable;
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

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class AssignRoute : UserControl
    {
        private int _distanceKM = 0;
        private int _minFlightMinutes = 0;


        public AssignRoute()
        {
            InitializeComponent();
            InitData();
            InitUI();
        }

        private void InitData()
        {
            DataSeeder.PopulateAircraftStat2();
            ApplyAircraftCMBData();
            ApplyTerminalCMBData();
            ApplyOriginCMBData();
            ApplyDestinationCMBData();
            lblFlightIDVal.Text = TerminalManager.NewFlightID();
            lblFlightIDValCopy.Text = lblFlightIDVal.Text;
            dtpDepartureVal.Value = DateTime.Now.AddDays(1);
            dtpArrivalVal.Value = DateTime.Now.AddDays(1).AddMinutes(_minFlightMinutes);
        }

        private void InitUI()
        {
            PopulateErrorUI();
            ShowProgress();
        }

        private void PopulateErrorUI()
        {
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider1, Target = lblAircraft, Field = cmbAircraftVal, DefaultValue = cmbAircraftVal.SelectedIndex });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider2, Target = lblTerminal, Field = cmbTerminalVal, DefaultValue = cmbTerminalVal.SelectedIndex });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider3, Target = lblGate, Field = cmbGateVal, DefaultValue = cmbGateVal.SelectedIndex });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider6, Target = lblOrigin, Field = cmbOriginVal, DefaultValue = cmbOriginVal.SelectedIndex });
            ErrorManager.AddErrorUI(new ErrorUIRecord { Provider = errorProvider7, Target = lblDestination, Field = cmbDestinationVal, DefaultValue = cmbDestinationVal.SelectedIndex });
        }

        private void ShowProgress()
        {
            lblProgressVal.Text = $"Assigning route (3/3)";
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

                if (aircraftRecord.Status == 2)
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

        public void ApplyTerminalCMBData()
        {
            var terminalCollection = TerminalManager.GetTerminalCollection;

            if (terminalCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("terminalCollection is empty. Appying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            for (int i = 0; i < terminalCollection.Count; i++)
            {
                var terminalRecord = terminalCollection[i];
                var gates = terminalRecord.Gates;

                for (int j = 0; j < gates.Count; j++)
                {
                    var gate = gates[j];

                    if (gate.Status == 1)
                    {
                        string display = $"Terminal {terminalRecord.Number}";
                        int id = terminalRecord.ID;

                        itemList.Add(new CMBItemWTag { Display = display, Value = id });
                        sourceList.Add(display);
                        break;
                    }
                }
            }

            cmbTerminalVal.DisplayMember = "Display";
            cmbTerminalVal.ValueMember = "Value";
            cmbTerminalVal.DataSource = itemList;
            cmbTerminalVal.SelectedIndex = 0;
            cmbTerminalVal.AutoCompleteCustomSource.Clear();
            cmbTerminalVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());

            ApplyGatesCMBData();
        }

        private void ApplyGatesCMBData()
        {
            cmbGateVal.DataSource = null;

            var terminalCollection = TerminalManager.GetTerminalCollection;

            if (terminalCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("terminalCollection is empty. Applying data aborted.");
                return;
            }

            var itemList = new List<CMBItemWTag>();
            var sourceList = new List<string>();

            int selectedTerminalValue = cmbTerminalVal.SelectedValue is int terminalVal ? terminalVal : 0;

            for (int i = 0; i < terminalCollection.Count; i++)
            {
                var terminalRecord = terminalCollection[i];
                var gates = terminalRecord.Gates;

                if (terminalRecord.ID == selectedTerminalValue)
                {
                    for (int j = 0; j < gates.Count; j++)
                    {
                        var gate = gates[j];

                        if (gate.Status == 1)
                        {
                            string display = $"Gate {gate.ID}";
                            int id = gate.ID;

                            itemList.Add(new CMBItemWTag { Display = display, Value = id });
                            sourceList.Add(display);
                        }
                    }

                    break;
                }
            }

            cmbGateVal.DisplayMember = "Display";
            cmbGateVal.ValueMember = "Value";
            cmbGateVal.DataSource = itemList;
            cmbGateVal.SelectedIndex = 0;
            cmbGateVal.AutoCompleteCustomSource.Clear();
            cmbGateVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ApplyOriginCMBData()
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
                int id = airportRecord.ID;

                itemList.Add(new CMBItemWTag { Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbOriginVal.DisplayMember = "Display";
            cmbOriginVal.ValueMember = "Value";
            cmbOriginVal.DataSource = itemList;
            cmbOriginVal.SelectedIndex = 6;
            cmbOriginVal.AutoCompleteCustomSource.Clear();
            cmbOriginVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private void ApplyDestinationCMBData()
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

                if (airportRecord.ID == 7) continue;

                string display = $"{airportRecord.IATA} - {airportRecord.Name} ({airportRecord.DisplayCity})";
                int id = airportRecord.ID;

                itemList.Add(new CMBItemWTag { Display = display, Value = id });
                sourceList.Add(display);
            }

            cmbDestinationVal.DisplayMember = "Display";
            cmbDestinationVal.ValueMember = "Value";
            cmbDestinationVal.DataSource = itemList;
            cmbDestinationVal.SelectedIndex = 0;
            cmbDestinationVal.AutoCompleteCustomSource.Clear();
            cmbDestinationVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
        }

        private bool AreAssignCrewFieldsValid()
        {
            if (cmbTerminalVal.SelectedIndex == -1) ErrorManager.AddError(new ErrorRecord { Message = "No terminal available.", AssociatedControls = { lblTerminal } });
            if (cmbGateVal.SelectedIndex == -1) ErrorManager.AddError(new ErrorRecord { Message = "No gate available.", AssociatedControls = { lblGate } });

            //DateTime tomorrow = DateTime.Today.AddDays(1);

            //if (dtpDepartureVal.Value.Date != tomorrow) ErrorManager.AddError(new ErrorRecord { Message = "Departure must start the day tomorrow.", AssociatedControls = { lblDeparture } });

            DateTime start = dtpDepartureVal.Value;
            DateTime end = dtpArrivalVal.Value;
            int durationMinutes = (int)Math.Ceiling((end - start).TotalMinutes);
            int maxFlightMinutes = (int)(_minFlightMinutes * 1.5);

            if (durationMinutes < _minFlightMinutes || durationMinutes > maxFlightMinutes) ErrorManager.AddError(new ErrorRecord { Message = "Duration must be within minimum flight duration or 1.5x of it.", AssociatedControls = { lblDeparture, lblArrival } });

            if (ErrorManager.GetErrorCollection.Count != 0)
            {
                ErrorManager.ShowAlert();
                ErrorManager.HighlightErrors(true);
                return false;
            }

            return true;
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

                    break;
                }
            }
        }

        private void cmbDestinationVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update route info
            lblFlightIDValCopy.Text = lblFlightIDVal.Text;

            var airportCollection = AirportManager.GetAirportCollection;

            if (airportCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("airportCollection is empty. Updating route info aborted.");
                return;
            }

            int selectedOriginValue = cmbOriginVal.SelectedValue is int originVal ? originVal : 0;
            int selectedDestinationValue = cmbDestinationVal.SelectedValue is int destinationVal ? destinationVal : 0;

            var origin = new GeoCoordinate(0, 0);
            var destination = new GeoCoordinate(0, 0);
            var originIATA = "";
            var destinationIATA = "";

            for (int i = 0; i < airportCollection.Count; i++)
            {
                var airportRecord = airportCollection[i];

                if (airportRecord.ID == selectedOriginValue)
                {
                    origin = new GeoCoordinate(airportRecord.Latitude, airportRecord.Longitude);
                    originIATA = airportRecord.IATA;
                }
                if (airportRecord.ID == selectedDestinationValue)
                {
                    destination = new GeoCoordinate(airportRecord.Latitude, airportRecord.Longitude);
                    destinationIATA = airportRecord.IATA;
                }
            }

            double distanceMeters = origin.GetDistanceTo(destination);
            int distanceKM = Convert.ToInt32(Math.Round(distanceMeters / 1000.0));
            _distanceKM = distanceKM;

            lblTotalDistanceVal.Text = $"{distanceKM.ToString()}KM";
            lblIterneraryVal.Text = $"{originIATA} - {destinationIATA}";
            int selectedAircraftValue = cmbAircraftVal.SelectedValue is int aircraftVal ? aircraftVal : 0;
            int modelID = 0;

            var aircraftCollection = AircraftManager.GetAircraftCollection;

            if (aircraftCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftCollection is empty. Updating route info aborted.");
                return;
            }

            for (int i = 0; i < aircraftCollection.Count; i++)
            {
                var aircraftRecord = aircraftCollection[i];

                if (aircraftRecord.ID == selectedAircraftValue)
                {
                    modelID = aircraftRecord.ModelID;
                    break;
                }
            }

            var aircraftModelCollection = AircraftManager.GetAircraftModelCollection;

            if (aircraftModelCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("aircraftModelCollection is empty. Updating route info aborted.");
                return;
            }

            int speedKMH = 0;

            for (int i = 0; i < aircraftModelCollection.Count; i++)
            {
                var aircraftModelRecord = aircraftModelCollection[i];

                if (aircraftModelRecord.ID == modelID)
                {
                    speedKMH = aircraftModelRecord.Speed;
                    break;
                }
            }

            double totalHours = (double)distanceKM / speedKMH;
            int totalMinutes = (int)Math.Ceiling(totalHours * 60);
            totalMinutes += 60;
            int roundedMinutes = ((totalMinutes + 4) / 5) * 5;
            _minFlightMinutes = roundedMinutes;
            dtpArrivalVal.Value = DateTime.Now.AddDays(1).AddMinutes(_minFlightMinutes);
            int hours = roundedMinutes / 60;
            int minutes = roundedMinutes % 60;

            lblMinFlightDurationVal.Text = $"{hours}h {minutes}m";
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

        private void cmbTerminalVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbTerminalVal upon leave
            var cmbTerminalItems = cmbTerminalVal.Items;

            if (cmbTerminalItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbTerminalItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedTerminalDisplay = cmbTerminalVal.Text;

            for (int i = 0; i < cmbTerminalItems.Count; i++)
            {
                var terminalDisplay = cmbTerminalVal.GetItemText(cmbTerminalVal.Items[i]);

                if (terminalDisplay.IndexOf(selectedTerminalDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbTerminalVal.SelectedIndex = i;
                    return;
                }
            }

            cmbTerminalVal.SelectedIndex = 0;
        }

        private void cmbGateVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbGateVal upon leave
            var cmbGateItems = cmbGateVal.Items;

            if (cmbGateItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbGateItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedGateDisplay = cmbGateVal.Text;

            for (int i = 0; i < cmbGateItems.Count; i++)
            {
                var gateDisplay = cmbGateVal.GetItemText(cmbGateVal.Items[i]);

                if (gateDisplay.IndexOf(selectedGateDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbGateVal.SelectedIndex = i;
                    return;
                }
            }

            cmbGateVal.SelectedIndex = 0;
        }

        private void cmbOriginVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbOriginVal upon leave
            var cmbOriginItems = cmbOriginVal.Items;

            if (cmbOriginItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbOriginItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedOriginDisplay = cmbOriginVal.Text;

            for (int i = 0; i < cmbOriginItems.Count; i++)
            {
                var originDisplay = cmbOriginVal.GetItemText(cmbOriginVal.Items[i]);

                if (originDisplay.IndexOf(selectedOriginDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbOriginVal.SelectedIndex = i;
                    return;
                }
            }

            cmbOriginVal.SelectedIndex = 0;
        }

        private void cmbDestinationVal_Leave(object sender, EventArgs e)
        {
            // Automatically pick an item from cmbDestinationVal upon leave
            var cmbDestinationItems = cmbDestinationVal.Items;

            if (cmbDestinationItems.Count == 0)
            {
                DebugLogger.LogWithStackTrace("cmbDestinationItems is empty. Auto selection on leave aborted.");
                return;
            }

            string selectedDestinationDisplay = cmbDestinationVal.Text;

            for (int i = 0; i < cmbDestinationItems.Count; i++)
            {
                var destinationDisplay = cmbDestinationVal.GetItemText(cmbDestinationVal.Items[i]);

                if (destinationDisplay.IndexOf(selectedDestinationDisplay, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cmbDestinationVal.SelectedIndex = i;
                    return;
                }
            }

            cmbDestinationVal.SelectedIndex = 0;
        }

        private void cmbTerminalVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update gate selections
            ApplyGatesCMBData();
        }

        private void AssignRoute_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnAssignAircraft_Click(object sender, EventArgs e)
        {
            // Assign route
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();

            if (!AreAssignCrewFieldsValid()) return;

            int aircraft = cmbAircraftVal.SelectedValue is int aircraftVal ? aircraftVal : 0;
            DateTime departure = dtpDepartureVal.Value;
            DateTime arrival = dtpArrivalVal.Value;
            int origin = cmbOriginVal.SelectedValue is int originVal ? originVal : 0;
            int destination = cmbDestinationVal.SelectedValue is int destinationVal ? destinationVal : 0;
            int terminal = cmbTerminalVal.SelectedValue is int terminalVal ? terminalVal : 0;
            int gate = cmbGateVal.SelectedValue is int gateVal ? gateVal : 0;
            int distanceKM = _distanceKM;
            int durationMin = _minFlightMinutes;

            FlightManagement.AddFlight(aircraft, departure, arrival, origin, destination, terminal, gate, distanceKM, durationMin);

            MainForm.Init(new AssignRoute());
        }
    }
}
