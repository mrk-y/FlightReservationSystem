using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
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

        }

        private void InitUI()
        {

        }

        private void AddAircraft_ParentChanged(object sender, EventArgs e)
        {
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
