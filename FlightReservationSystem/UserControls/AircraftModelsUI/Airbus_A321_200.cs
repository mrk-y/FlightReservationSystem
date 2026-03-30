using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.AircraftModelsUI
{
    /// <summary>
    /// Airbus A321-200 seat map.
    ///
    /// On load:
    ///  - Applies legend colours (same helper used by ATR_72_600).
    ///  - Stamps every seat button with its full "Letter + Row" label
    ///    (e.g. "A1", "C3", "K12") so the reservation system can track
    ///    exactly which seat was picked.
    ///
    /// How the label is built
    /// ──────────────────────
    ///  The Designer places a Label (MinimumSize.Width == 20, Text = letter)
    ///  to the left of each seat row.  The buttons in that row share the
    ///  same Top value as the label.  We pair them up at runtime:
    ///
    ///      label.Top == button.Top  →  letter = label.Text
    ///      button.Tag               →  row number string ("1", "2", …)
    ///      result stored in Tag     →  "A1", "A2", … "K32", etc.
    ///
    ///  The text shown on the button is then set to the combined label so
    ///  both the UI and any downstream code read the same value.
    /// </summary>
    public partial class Airbus_A321_200 : UserControl
    {
        public Airbus_A321_200()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            ShowLegendColors();
            StampSeatLabels();
        }

        // ── Legend colours (mirrors ATR_72_600) ───────────────────
        private void ShowLegendColors()
        {
            // Guard: AircraftManager may not be available in design mode.
            try
            {
                // The A321 Designer does not expose named legend buttons,
                // so we skip the legend panel here; it can be added to the
                // designer later the same way as ATR_72_600.
                // If your A321 designer gains btnRegPass / btnExitRow etc.,
                // wire them here exactly like ATR_72_600.ShowLegendColors().
            }
            catch { /* design-time safety */ }
        }

        // ── Seat label stamping ───────────────────────────────────
        /// <summary>
        /// Walk every panel in the control, build a "row Top → letter"
        /// map from the Labels, then write "letter + tag" into each
        /// Button's Tag and Text.
        /// </summary>
        private void StampSeatLabels()
        {
            StampPanel(this);
        }

        private void StampPanel(Control container)
        {
            // 1. Collect row-letter labels inside this container
            //    The Designer gives them MinimumSize = (20, 36) and they
            //    hold a single capital letter ("A", "C", "D", …).
            var rowLetterByTop = new System.Collections.Generic.Dictionary<int, string>();

            foreach (Control c in container.Controls)
            {
                if (c is Label lbl &&
                    lbl.MinimumSize.Width == 20 &&
                    lbl.Text.Trim().Length == 1 &&
                    char.IsLetter(lbl.Text.Trim()[0]))
                {
                    rowLetterByTop[c.Top] = lbl.Text.Trim();
                }
            }

            // 2. Stamp each Button whose Tag is a bare row number
            foreach (Control c in container.Controls)
            {
                if (c is Button btn)
                {
                    string tag = btn.Tag as string;
                    if (string.IsNullOrWhiteSpace(tag)) continue;

                    // Already stamped?
                    if (tag.Length > 1 && !int.TryParse(tag, out _)) continue;

                    // Find the letter for this button's row
                    if (rowLetterByTop.TryGetValue(btn.Top, out string letter))
                    {
                        string seatLabel = letter + tag;   // e.g. "A1", "K32"
                        btn.Tag = seatLabel;
                        btn.Font = new Font("Segoe UI", 6f);
                        btn.Text = seatLabel;
                    }
                }
                else if (c is Panel pnl)
                {
                    // Recurse — each cabin section is its own Panel
                    StampPanel(pnl);
                }
            }
        }
    }
}
