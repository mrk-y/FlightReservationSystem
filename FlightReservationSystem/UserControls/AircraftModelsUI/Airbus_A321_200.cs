using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.AircraftModelsUI
{
    public partial class Airbus_A321_200 : UserControl, ISeatMap
    {
        private static readonly Color ExitBackColor = Color.DarkRed;
        private static readonly Color WheelchairBorder = Color.DarkOrange;
        private static readonly Color PeanutBack = Color.GreenYellow;
        private static readonly Color PeanutBorder = Color.GreenYellow;
        private static readonly Color UMNRBack = Color.DeepSkyBlue;
        private static readonly Color UMNRBorder = Color.DeepSkyBlue;

        // ── Combination seats ────────────────────────────────────────────
        // DarkOrange border + DeepSkyBlue ForeColor  → WCHR + UMNR
        //   Accepts: wchr-only, umnr-only, or wchr+umnr together
        // DarkOrange border + GreenYellow BackColor  → WCHR + Peanut
        //   Accepts: wchr-only, pnut-only, or wchr+pnut together
        // ────────────────────────────────────────────────────────────────

        private readonly ToolTip _tip = new ToolTip();

        public event Action OnSeatAssigned;

        private List<RAPassengerDetails> _queue = new List<RAPassengerDetails>();
        private int _queueIndex = 0;
        private Dictionary<int, string> _assignments = new Dictionary<int, string>();
        private Label _statusLabel;

        private List<SavedPassengerInfo> _savedPassengers = new List<SavedPassengerInfo>();

        public Airbus_A321_200()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InitUI();
        }

        private void InitUI() => ShowLegendColors();

        private void ShowLegendColors()
        {
            btnRegPass.BackColor = Color.FromArgb(198, 239, 206);
            btnRegPass.FlatAppearance.BorderColor = Color.FromArgb(70, 170, 90);
            btnExitRow.BackColor = ExitBackColor;
            btnExitRow.FlatAppearance.BorderColor = ExitBackColor;
            btnPassWNuatAller.BackColor = PeanutBack;
            btnPassWNuatAller.FlatAppearance.BorderColor = PeanutBorder;
            btnUnaccomMinor.BackColor = UMNRBack;
            btnUnaccomMinor.FlatAppearance.BorderColor = UMNRBorder;
            btnWheelPass.BackColor = Color.FromArgb(209, 231, 255);
            btnWheelPass.FlatAppearance.BorderColor = WheelchairBorder;
        }

        // ═══════════════════════════════════════════════════════════════════
        // ISeatMap
        // ═══════════════════════════════════════════════════════════════════

        public Dictionary<int, string> LoadPassengers(List<RAPassengerDetails> passengers)
        {
            StampAllPanels();
            ApplySavedPassengersToMap();

            _queue = passengers.OrderBy(p => p.PassengerNumber).ToList();
            _queueIndex = 0;
            _assignments = new Dictionary<int, string>();

            BuildStatusBar();
            UpdateStatus();
            WireAllCabinButtons();

            return _assignments;
        }

        public void LoadSavedPassengers(List<SavedPassengerInfo> savedPassengers)
        {
            _savedPassengers = savedPassengers ?? new List<SavedPassengerInfo>();
            StampAllPanels();
            ApplySavedPassengersToMap();
        }

        // ═══════════════════════════════════════════════════════════════════
        // Saved passengers
        // ═══════════════════════════════════════════════════════════════════

        private void ApplySavedPassengersToMap()
        {
            foreach (SavedPassengerInfo p in _savedPassengers)
            {
                Panel cabin = ResolveCabinPanel(p.SeatClass);
                if (cabin == null) continue;

                Button seat = cabin.Controls
                    .OfType<Button>()
                    .FirstOrDefault(b => b.Tag is string s && s == p.SeatLabel);
                if (seat == null) continue;

                ApplySavedStyle(seat, p);
                seat.Tag = p;
                seat.Cursor = Cursors.Hand;

                _tip.SetToolTip(seat,
                    $"[{TypeCode(p)}] Pax {p.PassengerNo} — {p.LastName}, {p.FirstName}\n" +
                    $"Seat: {p.SeatLabel}  |  {p.SeatClass}\n" +
                    $"Ref: {p.ReferenceNo}\n" +
                    $"Special: {FlagString(p.HasPeanutAllergy, p.NeedsWheelchair, p.IsUnaccompaniedMinor)}");

                seat.Click -= Seat_Click;
                seat.Click += Seat_Click;
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // Status bar
        // ═══════════════════════════════════════════════════════════════════

        private void BuildStatusBar()
        {
            if (_statusLabel != null && this.Controls.Contains(_statusLabel))
                this.Controls.Remove(_statusLabel);

            _statusLabel = new Label
            {
                Dock = DockStyle.Top,
                Height = 38,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 100, 180),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(_statusLabel);
            _statusLabel.BringToFront();
        }

        private void UpdateStatus()
        {
            if (_statusLabel == null) return;

            if (_queueIndex >= _queue.Count)
            {
                _statusLabel.BackColor = Color.FromArgb(40, 140, 60);
                _statusLabel.Text = "✔  All passengers seated — proceed to Payment.";
                return;
            }

            var p = _queue[_queueIndex];
            _statusLabel.Text =
                $"Selecting seat for  Passenger {p.PassengerNumber}: " +
                $"{p.LastName}, {p.FirstName}  ·  {p.SeatClass}  ·  {SeatHint(p)}";
        }

        private static string SeatHint(RAPassengerDetails p)
        {
            bool wchr = p.NeedsWheelchair;
            bool pnut = p.HasPeanutAllergy;
            bool umnr = p.IsUnaccompaniedMinor;

            if (wchr && pnut) return "WCHR+NUT  — click an orange-bordered / GreenYellow seat";
            if (wchr && umnr) return "WCHR+UMNR — click an orange-bordered / DeepSkyBlue seat";
            if (wchr) return "WCHR — click an orange-bordered aisle seat";
            if (pnut) return "NUT  — click a GreenYellow seat";
            if (umnr) return "UMNR — click a DeepSkyBlue seat";

            return "REG — click any standard seat";
        }

        // ═══════════════════════════════════════════════════════════════════
        // Wiring
        // ═══════════════════════════════════════════════════════════════════

        private void WireAllCabinButtons()
        {
            foreach (Control c in this.Controls)
            {
                if (!(c is Panel panel)) continue;
                foreach (Button btn in panel.Controls.OfType<Button>())
                {
                    btn.Click -= Seat_Click;
                    btn.Click += Seat_Click;
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // Seat click
        // ═══════════════════════════════════════════════════════════════════

        private void Seat_Click(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;

            // ── Info popup for already-assigned seats ───────────────────
            if (btn.Tag is SavedPassengerInfo sp)
            {
                ShowPopup(
                    $"Seat:         {sp.SeatLabel}  ({sp.SeatClass})\n" +
                    $"Passenger:    {sp.LastName}, {sp.FirstName}\n" +
                    $"Reference:    {sp.ReferenceNo}\n" +
                    $"Special Req:  {FlagString(sp.HasPeanutAllergy, sp.NeedsWheelchair, sp.IsUnaccompaniedMinor)}");
                return;
            }

            if (btn.Tag is RAPassengerDetails rp)
            {
                ShowPopup(
                    $"Seat:         {btn.Text}  ({rp.SeatClass})\n" +
                    $"Passenger {rp.PassengerNumber}: {rp.LastName}, {rp.FirstName}\n" +
                    $"Email:        {rp.Email}\n" +
                    $"Phone:        {rp.Phone}\n" +
                    $"Special Req:  {FlagString(rp.HasPeanutAllergy, rp.NeedsWheelchair, rp.IsUnaccompaniedMinor)}");
                return;
            }

            if (_queue == null || _queueIndex >= _queue.Count) return;

            RAPassengerDetails current = _queue[_queueIndex];
            string seatLabel = btn.Tag?.ToString() ?? btn.Text;
            SeatKind kind = DetectSeatKind(btn);

            // ── Class check ─────────────────────────────────────────────
            string clickedClass = ResolveSeatClassFromButton(btn);
            if (!string.Equals(clickedClass, current.SeatClass, StringComparison.OrdinalIgnoreCase))
            {
                Warn($"Passenger {current.PassengerNumber} has a {current.SeatClass} ticket.\n\n" +
                     $"The selected seat belongs to the {clickedClass} cabin.\n\n" +
                     $"Please click a seat inside the {current.SeatClass} section.");
                return;
            }

            // ── Seat-rule validation ─────────────────────────────────────
            if (!ValidateSeat(current, kind, out string reason))
            {
                Warn(reason);
                return;
            }

            // ── Assign ───────────────────────────────────────────────────
            ApplyAssignedStyle(btn, kind);
            btn.Tag = current;
            btn.Cursor = Cursors.Hand;

            _tip.SetToolTip(btn,
                $"[{TypeCode(current)}] Pax {current.PassengerNumber} — " +
                $"{current.LastName}, {current.FirstName}\n" +
                $"Seat: {seatLabel}  |  {current.SeatClass}\n" +
                $"Special: {FlagString(current.HasPeanutAllergy, current.NeedsWheelchair, current.IsUnaccompaniedMinor)}");

            _assignments[current.PassengerNumber] = seatLabel;
            _queueIndex++;
            UpdateStatus();
            OnSeatAssigned?.Invoke();
        }

        // ═══════════════════════════════════════════════════════════════════
        // Cabin class resolver
        // ═══════════════════════════════════════════════════════════════════
        // Airbus A321-200: Business (panel2), Comfort (panel1), Economy (panel3)
        // ═══════════════════════════════════════════════════════════════════

        private string ResolveSeatClassFromButton(Button btn)
        {
            Control parent = btn.Parent;
            while (parent != null && !(parent is Panel))
                parent = parent.Parent;

            if (parent == null) return "Economy";
            var panel = (Panel)parent;

            switch (panel.Name)
            {
                case "pnlBusiness":
                case "panel2": return "Business";
                case "pnlComfort":
                case "panel1": return "Comfort";
                case "pnlEconomy":
                case "panel3": return "Economy";
            }

            // Last-resort: order by button count (fewest = Business, mid = Comfort, most = Economy)
            var cabinPanels = this.Controls
                .OfType<Panel>()
                .Where(p => p.Controls.OfType<Button>().Any())
                .OrderBy(p => p.Controls.OfType<Button>().Count())
                .ToList();

            int idx = cabinPanels.IndexOf(panel);
            if (idx == 0) return "Business";
            if (idx == 1) return "Comfort";
            return "Economy";
        }

        // ═══════════════════════════════════════════════════════════════════
        // Cabin panel resolver (for saved-passenger re-apply)
        // ═══════════════════════════════════════════════════════════════════

        private Panel ResolveCabinPanel(string seatClass)
        {
            foreach (Control c in this.Controls)
            {
                if (!(c is Panel p)) continue;
                switch (seatClass)
                {
                    case "Business" when p.Name == "pnlBusiness" || p.Name == "panel2": return p;
                    case "Comfort" when p.Name == "pnlComfort" || p.Name == "panel1": return p;
                    case "Economy" when p.Name == "pnlEconomy" || p.Name == "panel3": return p;
                }
            }

            // Fallback by button count
            var cabinPanels = this.Controls
                .OfType<Panel>()
                .Where(p => p.Controls.OfType<Button>().Any())
                .OrderBy(p => p.Controls.OfType<Button>().Count())
                .ToList();

            if (cabinPanels.Count == 0) return null;
            if (seatClass == "Business") return cabinPanels.First();
            if (seatClass == "Comfort" && cabinPanels.Count > 1) return cabinPanels[1];
            return cabinPanels.Last();
        }

        // ═══════════════════════════════════════════════════════════════════
        // Seat kind
        // ═══════════════════════════════════════════════════════════════════

        private enum SeatKind
        {
            Regular,
            Exit,
            Wheelchair,
            PeanutAllergy,
            UMNR,
            WheelchairUMNR,
            WheelchairPeanut
        }

        private static SeatKind DetectSeatKind(Button btn)
        {
            Color back = btn.BackColor;
            Color border = btn.FlatAppearance.BorderColor;

            if (Near(back, ExitBackColor)) return SeatKind.Exit;

            bool hasOrangeBorder = Near(border, WheelchairBorder);
            bool hasBlueBack = Near(back, UMNRBack);
            bool hasGreenBack = Near(back, PeanutBack);

            if (hasOrangeBorder && hasBlueBack) return SeatKind.WheelchairUMNR;
            if (hasOrangeBorder && hasGreenBack) return SeatKind.WheelchairPeanut;
            if (hasOrangeBorder) return SeatKind.Wheelchair;

            if (hasGreenBack || Near(border, PeanutBorder)) return SeatKind.PeanutAllergy;
            if (hasBlueBack || Near(border, UMNRBorder)) return SeatKind.UMNR;

            return SeatKind.Regular;
        }

        private static bool Near(Color a, Color b)
            => Math.Abs(a.R - b.R) < 12
            && Math.Abs(a.G - b.G) < 12
            && Math.Abs(a.B - b.B) < 12;

        // ═══════════════════════════════════════════════════════════════════
        // Validation
        // ═══════════════════════════════════════════════════════════════════

        private static bool ValidateSeat(RAPassengerDetails p, SeatKind kind, out string reason)
        {
            reason = "";
            bool wchr = p.NeedsWheelchair;
            bool pnut = p.HasPeanutAllergy;
            bool umnr = p.IsUnaccompaniedMinor;

            if (kind == SeatKind.Exit)
            {
                if (wchr) { reason = "Wheelchair passengers cannot be seated in an emergency exit row."; return false; }
                if (pnut) { reason = "Passengers with peanut allergies cannot be seated in an emergency exit row."; return false; }
                if (umnr) { reason = "Unaccompanied minors cannot be seated in an emergency exit row."; return false; }
                return true;
            }

            if (kind == SeatKind.WheelchairUMNR)
            {
                if (!wchr && !umnr)
                {
                    reason = pnut
                        ? "Passengers with peanut allergies must use a GreenYellow-designated seat."
                        : "This seat is reserved for wheelchair passengers, unaccompanied minors, or both.";
                    return false;
                }
                if (pnut && !umnr)
                {
                    reason = "This passenger has a peanut allergy. Please use an orange-bordered / GreenYellow combination seat instead.";
                    return false;
                }
                return true;
            }

            if (kind == SeatKind.WheelchairPeanut)
            {
                if (!wchr && !pnut)
                {
                    reason = umnr
                        ? "Unaccompanied minors must use a DeepSkyBlue-designated seat."
                        : "This seat is reserved for wheelchair passengers, passengers with peanut allergies, or both.";
                    return false;
                }
                if (umnr && !pnut)
                {
                    reason = "This passenger is an unaccompanied minor. Please use an orange-bordered / DeepSkyBlue combination seat instead.";
                    return false;
                }
                return true;
            }

            if (kind == SeatKind.Wheelchair)
            {
                if (!wchr) { reason = "This aisle seat is reserved for wheelchair passengers only."; return false; }
                if (pnut) { reason = "This passenger also has a peanut allergy. Please use an orange-bordered / GreenYellow combination seat."; return false; }
                if (umnr) { reason = "This passenger is also an unaccompanied minor. Please use an orange-bordered / DeepSkyBlue combination seat."; return false; }
                return true;
            }

            if (kind == SeatKind.PeanutAllergy)
            {
                if (!pnut) { reason = "This seat is reserved for passengers with peanut allergies only."; return false; }
                if (wchr) { reason = "This passenger also needs a wheelchair aisle seat. Please use an orange-bordered / GreenYellow combination seat."; return false; }
                return true;
            }

            if (kind == SeatKind.UMNR)
            {
                if (!umnr) { reason = "This seat is reserved for unaccompanied minors only."; return false; }
                if (wchr) { reason = "This passenger also needs a wheelchair aisle seat. Please use an orange-bordered / DeepSkyBlue combination seat."; return false; }
                return true;
            }

            // Regular
            if (wchr) { reason = "Wheelchair passengers must use an orange-bordered aisle seat."; return false; }
            if (pnut) { reason = "Passengers with peanut allergies must use a GreenYellow-designated seat."; return false; }
            if (umnr) { reason = "Unaccompanied minors must use a DeepSkyBlue-designated seat."; return false; }
            return true;
        }

        // ═══════════════════════════════════════════════════════════════════
        // Styling
        // ═══════════════════════════════════════════════════════════════════

        private static void ApplyAssignedStyle(Button btn, SeatKind kind)
        {
            switch (kind)
            {
                case SeatKind.Exit:
                    btn.BackColor = Color.FromArgb(198, 239, 206);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(70, 170, 90);
                    btn.FlatAppearance.BorderSize = 2;
                    break;
                case SeatKind.Wheelchair:
                    btn.BackColor = Color.FromArgb(180, 215, 255);
                    btn.FlatAppearance.BorderColor = WheelchairBorder;
                    btn.FlatAppearance.BorderSize = 3;
                    break;
                case SeatKind.PeanutAllergy:
                    btn.BackColor = PeanutBack;
                    btn.FlatAppearance.BorderColor = Color.DarkGreen;
                    btn.FlatAppearance.BorderSize = 3;
                    break;
                case SeatKind.UMNR:
                    btn.BackColor = UMNRBack;
                    btn.FlatAppearance.BorderColor = Color.DarkBlue;
                    btn.FlatAppearance.BorderSize = 3;
                    break;
                case SeatKind.WheelchairUMNR:
                    btn.BackColor = Color.FromArgb(180, 215, 255);
                    btn.ForeColor = Color.DeepSkyBlue;
                    btn.FlatAppearance.BorderColor = WheelchairBorder;
                    btn.FlatAppearance.BorderSize = 3;
                    break;
                case SeatKind.WheelchairPeanut:
                    btn.BackColor = PeanutBack;
                    btn.FlatAppearance.BorderColor = WheelchairBorder;
                    btn.FlatAppearance.BorderSize = 3;
                    break;
                default:
                    btn.BackColor = Color.FromArgb(198, 239, 206);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(70, 170, 90);
                    btn.FlatAppearance.BorderSize = 2;
                    break;
            }
        }

        private static void ApplySavedStyle(Button btn, SavedPassengerInfo p)
        {
            bool wchr = p.NeedsWheelchair;
            bool pnut = p.HasPeanutAllergy;
            bool umnr = p.IsUnaccompaniedMinor;

            if (wchr && umnr)
            {
                btn.BackColor = Color.FromArgb(180, 215, 255);
                btn.ForeColor = Color.DeepSkyBlue;
                btn.FlatAppearance.BorderColor = WheelchairBorder;
                btn.FlatAppearance.BorderSize = 3;
            }
            else if (wchr && pnut)
            {
                btn.BackColor = PeanutBack;
                btn.FlatAppearance.BorderColor = WheelchairBorder;
                btn.FlatAppearance.BorderSize = 3;
            }
            else if (wchr)
            {
                btn.BackColor = Color.FromArgb(180, 215, 255);
                btn.FlatAppearance.BorderColor = WheelchairBorder;
                btn.FlatAppearance.BorderSize = 3;
            }
            else if (pnut)
            {
                btn.BackColor = PeanutBack;
                btn.FlatAppearance.BorderColor = Color.DarkGreen;
                btn.FlatAppearance.BorderSize = 3;
            }
            else if (umnr)
            {
                btn.BackColor = UMNRBack;
                btn.FlatAppearance.BorderColor = Color.DarkBlue;
                btn.FlatAppearance.BorderSize = 3;
            }
            else
            {
                btn.BackColor = Color.FromArgb(198, 239, 206);
                btn.FlatAppearance.BorderColor = Color.FromArgb(70, 170, 90);
                btn.FlatAppearance.BorderSize = 2;
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // Seat label stamping
        // ═══════════════════════════════════════════════════════════════════

        private void StampAllPanels()
        {
            foreach (Control c in this.Controls)
                if (c is Panel pnl) StampPanel(pnl);
        }

        private void StampPanel(Panel panel)
        {
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

            var buttonsByTop = panel.Controls
                .OfType<Button>()
                .GroupBy(b => b.Top)
                .ToDictionary(g => g.Key, g => g.OrderBy(b => b.Left).ToList());

            foreach (var kvp in buttonsByTop)
            {
                if (!letterByTop.TryGetValue(kvp.Key, out string letter)) continue;
                var row = kvp.Value;
                for (int i = 0; i < row.Count; i++)
                {
                    if (row[i].Tag is string || row[i].Tag == null)
                    {
                        string id = letter + (i + 1);
                        row[i].Tag = id;
                        row[i].Text = id;
                        row[i].Font = new Font("Segoe UI", 6f);
                    }
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // Helpers
        // ═══════════════════════════════════════════════════════════════════

        private static string TypeCode(RAPassengerDetails p)
        {
            if (p.NeedsWheelchair && p.HasPeanutAllergy) return "WCHR+NUT";
            if (p.NeedsWheelchair && p.IsUnaccompaniedMinor) return "WCHR+UMNR";
            if (p.NeedsWheelchair) return "WCHR";
            if (p.HasPeanutAllergy) return "NUT";
            if (p.IsUnaccompaniedMinor) return "UMNR";
            return "REG";
        }

        private static string TypeCode(SavedPassengerInfo p)
        {
            if (p.NeedsWheelchair && p.HasPeanutAllergy) return "WCHR+NUT";
            if (p.NeedsWheelchair && p.IsUnaccompaniedMinor) return "WCHR+UMNR";
            if (p.NeedsWheelchair) return "WCHR";
            if (p.HasPeanutAllergy) return "NUT";
            if (p.IsUnaccompaniedMinor) return "UMNR";
            return "REG";
        }

        private static string FlagString(bool peanut, bool wchr, bool umnr)
        {
            var parts = new[]
            {
                peanut ? "Peanut Allergy"      : null,
                wchr   ? "Wheelchair"           : null,
                umnr   ? "Unaccompanied Minor"  : null
            }.Where(f => f != null).ToArray();
            return parts.Length > 0 ? string.Join(", ", parts) : "None";
        }

        private static void ShowPopup(string text)
            => MessageBox.Show(text, "Seat Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static void Warn(string text)
            => MessageBox.Show(text, "Invalid Seat",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}