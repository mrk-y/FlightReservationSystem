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
    public partial class SANavigation : UserControl
    {        
        public SANavigation()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            NavigationTags();
        }

        private void NavigationTags()
        {
            btnAddAircraft.Tag = "AddAircraft";
            btnAssignCrews.Tag = "AssignCrews";
            btnAssignRoute.Tag = "AssignRoute";
        }

        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
            if (ErrorManager.HasUncompleteProgress())
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");
                if (result == DialogResult.Yes)
                {
                    ErrorManager.ClearErrorCollection();
                    ErrorManager.ClearErrorUICollection();
                    AircraftManager.ClearCrewCollection();
                    AircraftManager.ClearAircraftCollection();

                    MainForm.Init(new AddAircraft());
                }

                return;
            }

            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();
            AircraftManager.ClearCrewCollection();
            AircraftManager.ClearAircraftCollection();

            MainForm.Init(new AddAircraft());

        }

        private void btnAssignCrews_Click(object sender, EventArgs e)
        {
            if (ErrorManager.HasUncompleteProgress())
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");
                if (result == DialogResult.Yes)
                {
                    ErrorManager.ClearErrorCollection();
                    ErrorManager.ClearErrorUICollection();
                    AircraftManager.ClearCrewCollection();
                    AircraftManager.ClearAircraftCollection();

                    MainForm.Init(new AssignCrews());
                }

                return;
            }

            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();
            AircraftManager.ClearCrewCollection();
            AircraftManager.ClearAircraftCollection();

            MainForm.Init(new AssignCrews());
        }

        private void btnAssignRoute_Click(object sender, EventArgs e)
        {
            if (ErrorManager.HasUncompleteProgress())
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");
                if (result == DialogResult.Yes)
                {
                    ErrorManager.ClearErrorCollection();
                    ErrorManager.ClearErrorUICollection();
                    AircraftManager.ClearCrewCollection();
                    AircraftManager.ClearAircraftCollection();

                    MainForm.Init(new AssignRoute());
                }

                return;
            }

            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();
            AircraftManager.ClearCrewCollection();
            AircraftManager.ClearAircraftCollection();

            MainForm.Init(new AssignRoute());
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (ErrorManager.HasUncompleteProgress())
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");
                if (result == DialogResult.Yes)
                {
                    ErrorManager.ClearErrorCollection();
                    ErrorManager.ClearErrorUICollection();
                    AircraftManager.ClearCrewCollection();
                    AircraftManager.ClearAircraftCollection();

                    MainForm.Init(new Statistics());
                }

                return;
            }

            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();
            AircraftManager.ClearCrewCollection();
            AircraftManager.ClearAircraftCollection();

            MainForm.Init(new Statistics());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (ErrorManager.HasUncompleteProgress())
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("There is incomplete progress. Do you wish to proceed?");
                if (result == DialogResult.Yes)
                {
                    ErrorManager.ClearErrorCollection();
                    ErrorManager.ClearErrorUICollection();
                    AircraftManager.ClearCrewCollection();
                    AircraftManager.ClearAircraftCollection();

                    AccountSession.LogoutSAAccount();
                }

                return;
            }

            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();
            AircraftManager.ClearCrewCollection();
            AircraftManager.ClearAircraftCollection();

            AccountSession.LogoutSAAccount();
        }
    }
}