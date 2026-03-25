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
    public partial class SAProgress : UserControl
    {
        public static SAProgress Current { get; set; } = null;
        private static Label _lblProgressVal => Current.lblProgressVal;

        public SAProgress()
        {
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            Current = this;

            if (Current == null)
            {
                DebugLogger.LogWithStackTrace("Currenti is null. Initialization aborted.");
                return;
            }

            ShowToolTips();
        }

        public static void ShowProgress(int progressNum, string progress)
        {
            if (!ValueChecker.IsStringValid(progress))
            {
                DebugLogger.LogWithStackTrace("status invalid value. Showing progress aborted.");
                return;
            }

            _lblProgressVal.Text = $"{progress} ({progressNum}/3)";
        }

        private void ShowToolTips()
        {
            toolTip1.SetToolTip(picQuestion1, "Complete all required steps to enable the aircraft for reservations.");
        }
    }
}
