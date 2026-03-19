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
                DebugLogger.Log("[Dev] Parameter UserControl (content) is null. Update aborted.");
                return;
            }

            var form = content.FindForm();

            if (form == null)
            {
                DebugLogger.Log("[Dev] Form from parameter UserControl (content) is null. Update aborted.");
                return;
            }

            if (!(form is MainForm))
            {
                DebugLogger.Log("[Dev] Form from parameter UserControl (content) is not of type MainForm. Update aborted.");
                return;
            }

            var panelNavigation = MainForm._pnlNavigation;

            if (panelNavigation == null)
            {
                DebugLogger.Log("[Dev] _pnlNavigation is null from MainForm from parameter UserControl (content). Update aborted.");
                return;
            }

            var navigationControls = panelNavigation.Controls;

            if (navigationControls == null)
            {
                DebugLogger.Log("[Dev] Controls is null from _pnlNavigation from MainForm from parameter UserControl (content). Update aborted.");
                return;
            }

            if (navigationControls.Count == 0)
            {
                DebugLogger.Log("[Dev] Controls is empty from _pnlNavigation from MainForm from parameter UserControl (content). Update aborted.");
                return;
            }

            for (int i = 0; i < navigationControls.Count; i++)
            {
                var navigationControl = navigationControls[i];

                if (navigationControl == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null Control (0) entry at index {i} of Controls from _pnlNavigation from MainForm from paramter UserControl (content). Update aborted.");
                    return;
                }

                if (navigationControl is SANavigation saNav)
                {
                    var saNavControls = saNav.Controls;

                    if (saNavControls == null)
                    {
                        DebugLogger.Log($"[Dev] Controls is empty from SANavigation ");
                    }
                } 
            }
             


            //var form = content.FindForm();

            //if (form == null)
            //{
            //    DebugLogger.Log("[Dev] Form of parameter UserControl (content) is null. Update aborted.");
            //    return;
            //}
            
            //if (!(form is MainForm))
            //{
            //    DebugLogger.Log("[Dev] Form of parameter UserControl (content) is not MainForm. Update aborted.");
            //    return;
            //}

            //var panelNavigation = MainForm._pnlNavigation;

            //if (panelNavigation == null)
            //{
            //    DebugLogger.Log("[Dev] _pnlNavigation is null from MainForm Form of parameter UserControl (content). Update aborted.");
            //    return;
            //}

            //var navigationControls = panelNavigation.Controls;
            
            //if (navigationControls == null)
            //{
            //    DebugLogger.Log("[Dev] _pnlNavigation Controls is null from Mainform Form of parameter UserControl (content). Update aborted.");
            //    return;
            //}

            //if (navigationControls.Count == 0)
            //{
            //    DebugLogger.Log("[Dev] _pnlNavigation Controls is empty from MainForm Form of parameter UserControl (content). Update aborted.");
            //    return;
            //}

            //for (int i = 0; i < navigationControls.Count; i++)
            //{
            //    var navigationControl = navigationControls[i];

            //    if (navigationControl == null)
            //    {
            //        DebugLogger.Log($"[Dev] Encountered null Control entry at index {i} of _pnlNavigation Controls from MainForm Form of parameter UserControl (content). Update aborted.");
            //        return;
            //    }

            //    if (navigationControl is SANavigation saNav)
            //    {
            //        var saNavControls = saNav.Controls;

            //        if (saNavControls == null)
            //        {
            //            DebugLogger.Log($"[Dev] SANavigation Controls is null from Control entry at index {i} of _pnlNavigation Controls from MainForm Form of parameter UserControl (content). Update aborted.");
            //            return;
            //        }

            //        if (saNavControls.Count == 0)
            //        {
            //            DebugLogger.Log($"[Dev] SANavigatiom Controls is empty from Control entry at index {i} of _pnlNavigation Controls from MainForm Form of parameter UserControl (content). Update aborted.");
            //            return;
            //        }

            //        for (int j = 0; j < saNavControls.Count; j++)
            //        {
            //            var saNavControl = saNavControls[j];

            //            if (saNavControl == null)
            //            {
            //                DebugLogger.Log($"[Dev] Encountered null Control entry at index {j} of SANavigation Controls from Control entry at index {i} of _pnlNavigation Controls from MainForm Form of parameter UserControl (content). Update aborted.");
            //                return;
            //            }

            //            if (saNavControl is Button nav)
            //            {
            //                if (nav.Tag is string tag && tag == content.Name)
            //                {
            //                    nav.BackColor = ThemeColors.Secondary;
            //                    nav.ForeColor = ThemeColors.Primary;
            //                }
            //                else
            //                {
            //                    nav.BackColor = ThemeColors.Primary;
            //                    nav.ForeColor = ThemeColors.Secondary;
            //                }
            //            }
            //        }
            //    }
            //} 
        }
    }
}
