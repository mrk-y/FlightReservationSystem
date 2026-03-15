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
                DebugLogger.Log("[Dev] content is null. Update aborted.");
                return;
            }

            if (content.FindForm() == null)
            {
                DebugLogger.Log("[Dev] content.FindForm returned null. Update aborted.");
                return;
            }

            Form form = content.FindForm();
            
            if (!(form is MainForm))
            {
                DebugLogger.Log("[Dev] content form is not MainForm. Update aborted.");
                return;
            }

            var navigationControls = MainForm._pnlNavigation.Controls;
            
            if (navigationControls == null)
            {
                DebugLogger.Log("[Dev] Navigation panel contains no controls. Update aborted.");
                return;
            }

            for (int i = 0; i < navigationControls.Count; i++)
            {
                var control = navigationControls[i];

                if (control == null)
                {
                    DebugLogger.Log("[Dev] Encountered null control in navigation panel. Update aborted.");
                    return;
                }

                if (control is SANavigation saNav)
                {
                    var saNavControls = saNav.Controls;

                    if (saNavControls == null)
                    {
                        DebugLogger.Log("[Dev] SANavigation contains no child controls. Update aborted.");
                        return;
                    }

                    for (int j = 0; j < saNavControls.Count; j++)
                    {
                        var control2 = saNavControls[j];

                        if (control2 == null)
                        {
                            DebugLogger.Log("[Dev] Encountered null child control. Skipping.");
                            continue;
                        }

                        if (control2 is Button nav)
                        {
                            if (nav.Tag is string tag && tag == content.Name)
                            {
                                nav.BackColor = ThemeColors.Secondary;
                                nav.ForeColor = ThemeColors.Primary;
                            }
                            else
                            {
                                nav.BackColor = ThemeColors.Primary;
                                nav.ForeColor = ThemeColors.Secondary;
                            }
                        }
                    }
                }
            } 
        }
    }
}
