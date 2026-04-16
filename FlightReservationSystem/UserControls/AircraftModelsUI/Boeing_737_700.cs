using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.AircraftModelsUI
{
    public partial class Boeing_737_700 : UserControl, ISeatMap
    {
        private static readonly Color ExitBackColor = Color.DarkRed;
        private static readonly Color WheelchairBorder = Color.DarkOrange;
        private static readonly Color PeanutBack = Color.GreenYellow;
        private static readonly Color PeanutBorder = Color.GreenYellow;
        private static readonly Color UMNRBack = Color.DeepSkyBlue;
        private static readonly Color UMNRBorder = Color.DeepSkyBlue;

        private readonly ToolTip _tip = new ToolTip();

        public event Action OnSeatAssigned;

        private List<RAPassengerDetails> _queue = new List<RAPassengerDetails>();
        private int _queueIndex = 0;
        private Dictionary<int, string> _assignments = new Dictionary<int, string>();
        private Label _statusLabel;

        private List<SavedPassengerInfo> _savedPassengers = new List<SavedPassengerInfo>();

        public Boeing_737_700()
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
            if (p.NeedsWheelchair) return "WCHR — click an orange-bordered aisle seat";
            if (p.HasPeanutAllergy) return "NUT — click a GreenYellow seat";
            if (p.IsUnaccompaniedMinor) return "UMNR — click a DeepSkyBlue seat";
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

            string clickedClass = ResolveSeatClassFromButton(btn);
            if (!string.Equals(clickedClass, current.SeatClass, StringComparison.OrdinalIgnoreCase))
            {
                Warn($"Passenger {current.PassengerNumber} has a {current.SeatClass} ticket.\n\n" +
                     $"The selected seat belongs to the {clickedClass} cabin.\n\n" +
                     $"Please click a seat inside the {current.SeatClass} section.");
                return;
            }

            if (!ValidateSeat(current, kind, out string reason))
            {
                Warn(reason);
                return;
            }

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

        private string ResolveSeatClassFromButton(Button btn)
        {
            Control parent = btn.Parent;
            while (parent != null && !(parent is Panel))
                parent = parent.Parent;

            if (parent == null) return "Economy";
            var panel = (Panel)parent;

            switch (panel.Name)
            {
                case "panel2": return "Business";
                case "panel1": return "Comfort";
                case "panel3": return "Economy";
            }

            var panels = this.Controls
                .OfType<Panel>()
                .Where(p => p.Controls.OfType<Button>().Any())
                .OrderBy(p => p.Controls.OfType<Button>().Count())
                .ToList();

            int idx = panels.IndexOf(panel);
            switch (idx)
            {
                case 0: return "Business";
                case 1: return "Comfort";
                default: return "Economy";
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // Seat kind
        // ═══════════════════════════════════════════════════════════════════

        private enum SeatKind { Regular, Exit, Wheelchair, PeanutAllergy, UMNR }

        private static SeatKind DetectSeatKind(Button btn)
        {
            Color back = btn.BackColor;
            Color border = btn.FlatAppearance.BorderColor;

            if (Near(back, ExitBackColor)) return SeatKind.Exit;
            if (Near(back, PeanutBack) || Near(border, PeanutBorder)) return SeatKind.PeanutAllergy;
            if (Near(back, UMNRBack) || Near(border, UMNRBorder)) return SeatKind.UMNR;
            if (Near(border, WheelchairBorder)) return SeatKind.Wheelchair;
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

            if (kind == SeatKind.Exit)
            {
                if (p.NeedsWheelchair)
                { reason = "Wheelchair passengers cannot be seated in an emergency exit row."; return false; }
                if (p.HasPeanutAllergy)
                { reason = "Passengers with peanut allergies cannot be seated in an emergency exit row."; return false; }
                if (p.IsUnaccompaniedMinor)
                { reason = "Unaccompanied minors cannot be seated in an emergency exit row."; return false; }
                return true;
            }

            if (p.NeedsWheelchair)
            {
                if (kind != SeatKind.Wheelchair)
                { reason = "Wheelchair passengers must use an orange-bordered aisle seat."; return false; }
                return true;
            }
            if (p.HasPeanutAllergy)
            {
                if (kind != SeatKind.PeanutAllergy)
                { reason = "Passengers with peanut allergies must use a GreenYellow-designated seat."; return false; }
                return true;
            }
            if (p.IsUnaccompaniedMinor)
            {
                if (kind != SeatKind.UMNR)
                { reason = "Unaccompanied minors must use a DeepSkyBlue-designated seat."; return false; }
                return true;
            }

            if (kind == SeatKind.Wheelchair)
            { reason = "This aisle seat is reserved for wheelchair passengers only."; return false; }
            if (kind == SeatKind.PeanutAllergy)
            { reason = "This seat is reserved for passengers with peanut allergies only."; return false; }
            if (kind == SeatKind.UMNR)
            { reason = "This seat is reserved for unaccompanied minors only."; return false; }

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
                default:
                    btn.BackColor = Color.FromArgb(198, 239, 206);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(70, 170, 90);
                    btn.FlatAppearance.BorderSize = 2;
                    break;
            }
        }

        private static void ApplySavedStyle(Button btn, SavedPassengerInfo p)
        {
            if (p.NeedsWheelchair)
            {
                btn.BackColor = Color.FromArgb(180, 215, 255);
                btn.FlatAppearance.BorderColor = WheelchairBorder;
                btn.FlatAppearance.BorderSize = 3;
            }
            else if (p.HasPeanutAllergy)
            {
                btn.BackColor = PeanutBack;
                btn.FlatAppearance.BorderColor = Color.DarkGreen;
                btn.FlatAppearance.BorderSize = 3;
            }
            else if (p.IsUnaccompaniedMinor)
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
        // Cabin panel resolver
        // ═══════════════════════════════════════════════════════════════════

        private Panel ResolveCabinPanel(string seatClass)
        {
            foreach (Control c in this.Controls)
            {
                if (!(c is Panel p)) continue;
                switch (seatClass)
                {
                    case "Business": if (p.Name == "panel2") return p; break;
                    case "Comfort": if (p.Name == "panel1") return p; break;
                    default: if (p.Name == "panel3") return p; break;
                }
            }

            var panels = this.Controls
                .OfType<Panel>()
                .Where(p => p.Controls.OfType<Button>().Any())
                .OrderBy(p => p.Controls.OfType<Button>().Count())
                .ToList();

            if (panels.Count < 3) return null;
            switch (seatClass)
            {
                case "Business": return panels[0];
                case "Comfort": return panels[1];
                default: return panels[2];
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
            if (p.NeedsWheelchair) return "WCHR";
            if (p.HasPeanutAllergy) return "NUT";
            if (p.IsUnaccompaniedMinor) return "UMNR";
            return "REG";
        }

        private static string TypeCode(SavedPassengerInfo p)
        {
            if (p.NeedsWheelchair) return "WCHR";
            if (p.HasPeanutAllergy) return "NUT";
            if (p.IsUnaccompaniedMinor) return "UMNR";
            return "REG";
        }

        private static string FlagString(bool peanut, bool wchr, bool umnr)
        {
            var parts = new[]
            {
                peanut ? "Peanut Allergy"     : null,
                wchr   ? "Wheelchair"          : null,
                umnr   ? "Unaccompanied Minor" : null
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