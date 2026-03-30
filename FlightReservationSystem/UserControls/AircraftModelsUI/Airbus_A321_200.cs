using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.AircraftModelsUI
{
    /// <summary>
    /// Airbus A321-200 seat map.
    ///
    /// Layout (234 seats total):
    ///   Business Class  (panel2) – 2+2 config, rows A C H K,  3 columns  =  12 seats
    ///   Comfort  Class  (panel1) – 3+2 config, rows A B C H J K, 5 columns = 30 seats
    ///   Economy  Class  (panel3) – 3+3 config, rows A B C H J K, 32 columns = 192 seats
    ///
    /// Seat labels (e.g. "A1", "K32") are derived at runtime from button geometry:
    ///   • Row letter  – taken from the Label whose MinimumSize.Width == 20 that
    ///                   shares the same Top value as the button row.
    ///   • Seat number – buttons in each row are sorted left-to-right and numbered 1, 2, 3 …
    ///
    /// This approach requires no Tags in the Designer and is resilient to future
    /// column additions (just add more buttons at the same Top value).
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
            StampAllPanels();
        }

        // ── Legend colours ────────────────────────────────────────
        private void ShowLegendColors()
        {
            // Wire legend buttons here once they are added to the Designer,
            // the same way ATR_72_600.ShowLegendColors() does it.
            // Example:
            //   btnRegPass.BackColor = AircraftManager.GetSeatTypeUICollection[0].BackColor;
            //   btnRegPass.FlatAppearance.BorderColor = AircraftManager.GetSeatTypeUICollection[0].BorderColor;
        }

        // ── Seat label stamping ───────────────────────────────────
        /// <summary>
        /// Entry point: stamp every Panel that is a direct child of this UserControl.
        /// Each cabin section (Business / Comfort / Economy) is its own Panel.
        /// </summary>
        private void StampAllPanels()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel pnl)
                    StampPanel(pnl);
            }
        }

        /// <summary>
        /// For a single cabin panel:
        ///   1. Build a Top → letter map from Labels with MinimumSize.Width == 20.
        ///   2. Group buttons by their Top value (= one seat row per Top).
        ///   3. Sort each group left-to-right and assign seat numbers 1, 2, 3 …
        ///   4. Write "letter + number" into each button's Tag and Text.
        /// </summary>
        private void StampPanel(Panel panel)
        {
            // Step 1 – row-letter labels
            var letterByTop = new Dictionary<int, string>();
            foreach (Control c in panel.Controls)
            {
                if (c is Label lbl
                    && lbl.MinimumSize.Width == 20
                    && lbl.Text.Trim().Length == 1
                    && char.IsLetter(lbl.Text.Trim()[0]))
                {
                    letterByTop[lbl.Top] = lbl.Text.Trim();
                }
            }

            // Step 2 – group buttons by Top
            var buttonsByTop = panel.Controls
                .OfType<Button>()
                .GroupBy(b => b.Top)
                .ToDictionary(g => g.Key, g => g.OrderBy(b => b.Left).ToList());

            // Step 3 & 4 – stamp
            foreach (var kvp in buttonsByTop)
            {
                if (!letterByTop.TryGetValue(kvp.Key, out string letter))
                    continue;   // row header label not found – skip

                var rowButtons = kvp.Value;
                for (int i = 0; i < rowButtons.Count; i++)
                {
                    string seatId = letter + (i + 1).ToString(); // e.g. "A1", "K32"
                    rowButtons[i].Tag = seatId;
                    rowButtons[i].Text = seatId;
                    rowButtons[i].Font = new Font("Segoe UI", 6f);
                }
            }
        }
    }
}