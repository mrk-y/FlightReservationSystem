using FlightReservationSystem.Data.Reference.ColorPallete;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.UserControls.SystemAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class MainFormUIHelper
    {
        public static void UpdateNavigationState(UserControl content) 
        {
            if (content == null)
            {
                DebugLogger.LogWithStackTrace("content is null. Update aborted.");
                return;
            }

            if (MainForm._pnlNavigation.Controls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("MainForm._pnlNavigation.Controls is empty. Update aborted.");
                return;
            }

            UserControl saNavigation = MainForm._navigation;
            
            if (saNavigation == null)
            {
                DebugLogger.LogWithStackTrace("saNavigation is null. Update aborted.");
                return;
            } 

            if (!(saNavigation is SANavigation))
            {
                DebugLogger.LogWithStackTrace("saNavigation is not type SANavigation. Update aborted.");
                return;
            }

            var saNavControls = saNavigation.Controls;

            for (int i = 0; i < saNavControls.Count; i++)
            {
                var saNavControl = saNavControls[i];

                if (saNavControl is Button btn && btn.Tag is string tag)
                {
                    if (tag == content.Name)
                    {
                        btn.BackColor = ThemeColors.Secondary;
                        btn.ForeColor = ThemeColors.Primary;
                    }
                    else
                    {
                        btn.BackColor = ThemeColors.Primary;
                        btn.ForeColor = ThemeColors.Secondary;
                    }
                }
            }
        }
    }
}
