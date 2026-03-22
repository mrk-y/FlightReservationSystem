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

            var form = content.FindForm();

            if (form == null)
            {
                DebugLogger.LogWithStackTrace("form is null. Update aborted.");
                return;
            }

            if (!(form is MainForm))
            {
                DebugLogger.LogWithStackTrace("form is not type MainForm. Update aborted.");
                return;
            }

            var panelNavigation = MainForm._pnlNavigation;

            if (panelNavigation == null)
            {
                DebugLogger.LogWithStackTrace("panelNavigation is null. Update aborted.");
                return;
            }

            if (panelNavigation.Controls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("panelNavigation.Controls is empty. Update aborted.");
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

            if (saNavControls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("saNavControls is empty. Update aborted.");
                return;
            }

            for (int i = 0; i < saNavControls.Count; i++)
            {
                var saNavControl = saNavControls[i];

                if (saNavControl == null)
                {
                    DebugLogger.LogWithStackTrace($"saNavControl {i} is null. Update aborted.");
                    return;
                } 

                if (saNavControl is Button btn && btn.Tag is string tag)
                {
                    if (ValueChecker.HasSpaceStartEnd(tag))
                    {
                        DebugLogger.LogWithStackTrace($"tag {i} starts or ends with space. Update aborted.");
                        return;
                    }

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
