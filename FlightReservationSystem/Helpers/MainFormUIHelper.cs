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
                DebugLogger.LogWithStackTrace("form is not MainForm. Update aborted.");
                return;
            }

            var panelNavigation = MainForm._pnlNavigation;

            if (panelNavigation == null)
            {
                DebugLogger.LogWithStackTrace("panelNavigation is null. Update aborted.");
                return;
            }

            var navigationControls = panelNavigation.Controls;

            if (navigationControls == null)
            {
                DebugLogger.LogWithStackTrace("navigationControls is null. Update aborted.");
                return;
            }

            if (navigationControls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("navigationControls is empty. Update aborted.");
                return;
            }

            for (int i = 0; i < navigationControls.Count; i++)
            {
                var navigationControl = navigationControls[i];

                if (navigationControl == null)
                {
                    DebugLogger.LogWithStackTrace($"navigationControl {i} is null. Update aborted.");
                    return;
                }

                if (navigationControl is SANavigation saNav)
                {
                    var saNavControls = saNav.Controls;

                    if (saNavControls == null)
                    {
                        DebugLogger.LogWithStackTrace($"saNavControls {i} is null. Update aborted.");
                        return;
                    }

                    if (saNavControls.Count == 0)
                    {
                        DebugLogger.LogWithStackTrace($"saNavControls {i} is empty. Update aborted.");
                        return;
                    }

                    for (int j = 0; j < saNavControls.Count; j++)
                    {
                        var saNavControl = saNavControls[j];

                        if (saNavControl == null)
                        {
                            DebugLogger.LogWithStackTrace($"saNavControl {j} is null saNavControls {i}. Update aborted.");
                            return;
                        }

                        if (saNavControl is Button btn)
                        {
                            if (btn.Tag is string tag && tag == content.Name)
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
    }
}
