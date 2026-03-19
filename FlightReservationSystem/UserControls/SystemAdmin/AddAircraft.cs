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
    public partial class AddAircraft : UserControl
    {
        public AddAircraft()
        {
            InitializeComponent();
            InitUI();
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
                DebugLogger.Log("[Dev] Form is null from UserControl (AddAircraft) Form. Changing navigation UI aborted.");
                return;
            }

            MainFormUIHelper.UpdateNavigationState(this);
        }
    }
}
