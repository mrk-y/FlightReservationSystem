namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    partial class RAPreviewSeats
    {
        // ═══════════════════════════════════════════════════════════
        // Designer infrastructure
        // ═══════════════════════════════════════════════════════════
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // ── Top search bar ──────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.TextBox txtFlightSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;

        // ── Flight autocomplete dropdown ────────────────────────────
        private System.Windows.Forms.Panel pnlFlightDropdown;
        private System.Windows.Forms.ListBox lstFlightDrop;

        // ── Layout splitter ─────────────────────────────────────────
        private System.Windows.Forms.SplitContainer splitMain;

        // ── LEFT panel ──────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblSummaryFlight;
        private System.Windows.Forms.Label lblSummaryRoute;
        private System.Windows.Forms.Label lblSummaryDate;
        private System.Windows.Forms.Label lblSummaryGate;
        private System.Windows.Forms.Label lblSummaryModel;

        private System.Windows.Forms.Panel pnlStatusBadge;
        private System.Windows.Forms.Label lblStatusText;

        private System.Windows.Forms.Label lblTotalSeats;
        private System.Windows.Forms.Label lblOccupied;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Panel pnlOccupancyBar;
        private System.Windows.Forms.Panel pnlOccupancyFill;

        private System.Windows.Forms.Label lblPassengerHeader;
        private System.Windows.Forms.ListBox lstPassengers;

        // ── RIGHT panel ─────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblMapHint;
        private System.Windows.Forms.Label lblLegend;

        // Scroll infrastructure (manual — replaces broken AutoScroll)
        private System.Windows.Forms.Panel pnlMapViewport;  // clips the map
        private System.Windows.Forms.Panel pnlMapHost;      // moves inside viewport
        private System.Windows.Forms.HScrollBar hScroll;
        private System.Windows.Forms.VScrollBar vScroll;

        // ═══════════════════════════════════════════════════════════
        // InitializeComponent
        // ═══════════════════════════════════════════════════════════
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlSearchBar = new System.Windows.Forms.Panel();
            this.txtFlightSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.pnlFlightDropdown = new System.Windows.Forms.Panel();
            this.lstFlightDrop = new System.Windows.Forms.ListBox();

            this.splitMain = new System.Windows.Forms.SplitContainer();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblSummaryFlight = new System.Windows.Forms.Label();
            this.lblSummaryRoute = new System.Windows.Forms.Label();
            this.lblSummaryDate = new System.Windows.Forms.Label();
            this.lblSummaryGate = new System.Windows.Forms.Label();
            this.lblSummaryModel = new System.Windows.Forms.Label();

            this.pnlStatusBadge = new System.Windows.Forms.Panel();
            this.lblStatusText = new System.Windows.Forms.Label();

            this.lblTotalSeats = new System.Windows.Forms.Label();
            this.lblOccupied = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.pnlOccupancyBar = new System.Windows.Forms.Panel();
            this.pnlOccupancyFill = new System.Windows.Forms.Panel();

            this.lblPassengerHeader = new System.Windows.Forms.Label();
            this.lstPassengers = new System.Windows.Forms.ListBox();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblMapHint = new System.Windows.Forms.Label();
            this.lblLegend = new System.Windows.Forms.Label();

            this.pnlMapViewport = new System.Windows.Forms.Panel();
            this.pnlMapHost = new System.Windows.Forms.Panel();
            this.hScroll = new System.Windows.Forms.HScrollBar();
            this.vScroll = new System.Windows.Forms.VScrollBar();

            // Suspend layout
            this.pnlSearchBar.SuspendLayout();
            this.pnlFlightDropdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitMain).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlStatusBadge.SuspendLayout();
            this.pnlOccupancyBar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlMapViewport.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════
            // pnlSearchBar
            // ════════════════════════════════════════════════════════
            this.pnlSearchBar.BackColor = System.Drawing.Color.FromArgb(15, 40, 90);
            this.pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBar.Height = 52;
            this.pnlSearchBar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlSearchBar.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.txtFlightSearch, this.btnSearch, this.btnClear
            });

            // txtFlightSearch
            this.txtFlightSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
                                             | System.Windows.Forms.AnchorStyles.Left
                                             | System.Windows.Forms.AnchorStyles.Right;
            this.txtFlightSearch.BackColor = System.Drawing.Color.FromArgb(25, 55, 115);
            this.txtFlightSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFlightSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtFlightSearch.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.txtFlightSearch.Location = new System.Drawing.Point(10, 12);
            this.txtFlightSearch.Size = new System.Drawing.Size(500, 28);
            this.txtFlightSearch.Text = "Aircraft name, IATA code, or city…";

            // btnSearch
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
                                                     | System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(518, 12);
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.Text = "Search";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnClear
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top
                                                    | System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(606, 12);
            this.btnClear.Size = new System.Drawing.Size(60, 28);
            this.btnClear.Text = "Clear";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════════════════════
            // pnlFlightDropdown
            // ════════════════════════════════════════════════════════
            this.pnlFlightDropdown.BackColor = System.Drawing.Color.FromArgb(20, 50, 110);
            this.pnlFlightDropdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFlightDropdown.Location = new System.Drawing.Point(10, 52);
            this.pnlFlightDropdown.Size = new System.Drawing.Size(514, 0);
            this.pnlFlightDropdown.Visible = false;
            this.pnlFlightDropdown.Controls.Add(this.lstFlightDrop);

            // lstFlightDrop
            this.lstFlightDrop.BackColor = System.Drawing.Color.FromArgb(20, 50, 110);
            this.lstFlightDrop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFlightDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFlightDrop.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lstFlightDrop.ForeColor = System.Drawing.Color.White;
            this.lstFlightDrop.ItemHeight = 18;
            this.lstFlightDrop.IntegralHeight = false;
            this.lstFlightDrop.Visible = true;

            // ════════════════════════════════════════════════════════
            // splitMain
            // ════════════════════════════════════════════════════════
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.SplitterDistance = 280;
            this.splitMain.SplitterWidth = 4;
            this.splitMain.BackColor = System.Drawing.Color.FromArgb(30, 60, 120);

            this.splitMain.Panel1.Controls.Add(this.pnlLeft);
            this.splitMain.Panel2.Controls.Add(this.pnlRight);

            // ════════════════════════════════════════════════════════
            // pnlLeft
            // ════════════════════════════════════════════════════════
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(18, 44, 96);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(12, 12, 12, 8);
            this.pnlLeft.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblSummaryFlight,
                this.pnlStatusBadge,
                this.lblSummaryRoute,
                this.lblSummaryDate,
                this.lblSummaryGate,
                this.lblSummaryModel,
                this.lblTotalSeats,
                this.lblOccupied,
                this.lblAvailable,
                this.pnlOccupancyBar,
                this.lblPassengerHeader,
                this.lstPassengers
            });

            this.lblSummaryFlight.AutoSize = false;
            this.lblSummaryFlight.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblSummaryFlight.ForeColor = System.Drawing.Color.White;
            this.lblSummaryFlight.Location = new System.Drawing.Point(12, 12);
            this.lblSummaryFlight.Size = new System.Drawing.Size(230, 26);
            this.lblSummaryFlight.Text = "No flight selected";

            this.pnlStatusBadge.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.pnlStatusBadge.Location = new System.Drawing.Point(12, 42);
            this.pnlStatusBadge.Size = new System.Drawing.Size(100, 22);
            this.pnlStatusBadge.Controls.Add(this.lblStatusText);

            this.lblStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblStatusText.ForeColor = System.Drawing.Color.White;
            this.lblStatusText.Text = "—";
            this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSummaryRoute.AutoSize = false;
            this.lblSummaryRoute.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSummaryRoute.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSummaryRoute.Location = new System.Drawing.Point(12, 70);
            this.lblSummaryRoute.Size = new System.Drawing.Size(248, 18);

            this.lblSummaryDate.AutoSize = false;
            this.lblSummaryDate.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblSummaryDate.ForeColor = System.Drawing.Color.FromArgb(160, 195, 255);
            this.lblSummaryDate.Location = new System.Drawing.Point(12, 92);
            this.lblSummaryDate.Size = new System.Drawing.Size(248, 18);

            this.lblSummaryGate.AutoSize = false;
            this.lblSummaryGate.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblSummaryGate.ForeColor = System.Drawing.Color.FromArgb(160, 195, 255);
            this.lblSummaryGate.Location = new System.Drawing.Point(12, 112);
            this.lblSummaryGate.Size = new System.Drawing.Size(248, 18);

            this.lblSummaryModel.AutoSize = false;
            this.lblSummaryModel.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Italic);
            this.lblSummaryModel.ForeColor = System.Drawing.Color.FromArgb(130, 170, 230);
            this.lblSummaryModel.Location = new System.Drawing.Point(12, 132);
            this.lblSummaryModel.Size = new System.Drawing.Size(248, 18);

            this.lblTotalSeats.AutoSize = false;
            this.lblTotalSeats.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.lblTotalSeats.ForeColor = System.Drawing.Color.White;
            this.lblTotalSeats.Location = new System.Drawing.Point(12, 158);
            this.lblTotalSeats.Size = new System.Drawing.Size(248, 18);

            this.pnlOccupancyBar.BackColor = System.Drawing.Color.FromArgb(50, 70, 110);
            this.pnlOccupancyBar.Location = new System.Drawing.Point(12, 178);
            this.pnlOccupancyBar.Size = new System.Drawing.Size(260, 8);
            this.pnlOccupancyBar.Controls.Add(this.pnlOccupancyFill);

            this.pnlOccupancyFill.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.pnlOccupancyFill.Location = new System.Drawing.Point(0, 0);
            this.pnlOccupancyFill.Size = new System.Drawing.Size(0, 8);

            this.lblOccupied.AutoSize = false;
            this.lblOccupied.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.lblOccupied.ForeColor = System.Drawing.Color.FromArgb(160, 195, 255);
            this.lblOccupied.Location = new System.Drawing.Point(12, 190);
            this.lblOccupied.Size = new System.Drawing.Size(248, 16);

            this.lblAvailable.AutoSize = false;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.lblAvailable.ForeColor = System.Drawing.Color.FromArgb(100, 200, 130);
            this.lblAvailable.Location = new System.Drawing.Point(12, 208);
            this.lblAvailable.Size = new System.Drawing.Size(248, 16);

            this.lblPassengerHeader.AutoSize = false;
            this.lblPassengerHeader.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblPassengerHeader.ForeColor = System.Drawing.Color.FromArgb(130, 170, 230);
            this.lblPassengerHeader.Location = new System.Drawing.Point(12, 232);
            this.lblPassengerHeader.Size = new System.Drawing.Size(248, 16);
            this.lblPassengerHeader.Text = "BOOKED PASSENGERS";

            this.lstPassengers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPassengers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstPassengers.ItemHeight = 44;
            this.lstPassengers.BackColor = System.Drawing.Color.White;
            this.lstPassengers.Location = new System.Drawing.Point(12, 252);
            this.lstPassengers.Size = new System.Drawing.Size(248, 300);
            this.lstPassengers.IntegralHeight = false;

            // ════════════════════════════════════════════════════════
            // pnlRight  (outer container for the map area)
            // ════════════════════════════════════════════════════════
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(12, 32, 72);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlRight.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblMapHint,
                this.lblLegend,
                this.hScroll,
                this.vScroll,
                this.pnlMapViewport
            });

            // lblMapHint — docked top
            this.lblMapHint.AutoSize = false;
            this.lblMapHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMapHint.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblMapHint.ForeColor = System.Drawing.Color.FromArgb(160, 195, 255);
            this.lblMapHint.Height = 36;
            this.lblMapHint.Text = "Search for a flight above to display its seat map.";

            // lblLegend — docked bottom
            this.lblLegend.AutoSize = false;
            this.lblLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLegend.ForeColor = System.Drawing.Color.FromArgb(130, 170, 230);
            this.lblLegend.Height = 24;
            this.lblLegend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // hScroll — docked bottom, above lblLegend
            this.hScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScroll.Height = 17;
            this.hScroll.Visible = false;
            this.hScroll.Minimum = 0;
            this.hScroll.Maximum = 100;
            this.hScroll.SmallChange = 20;
            this.hScroll.LargeChange = 100;

            // vScroll — docked right
            this.vScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScroll.Width = 17;
            this.vScroll.Visible = false;
            this.vScroll.Minimum = 0;
            this.vScroll.Maximum = 100;
            this.vScroll.SmallChange = 20;
            this.vScroll.LargeChange = 100;

            // pnlMapViewport — clipping panel (Fill, no AutoScroll)
            this.pnlMapViewport.BackColor = System.Drawing.Color.FromArgb(12, 32, 72);
            this.pnlMapViewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapViewport.AutoScroll = false;
            this.pnlMapViewport.Controls.Add(this.pnlMapHost);

            // pnlMapHost — the panel that actually moves when scrolling
            this.pnlMapHost.AutoSize = false;
            this.pnlMapHost.BackColor = System.Drawing.Color.Transparent;
            this.pnlMapHost.Location = new System.Drawing.Point(0, 0);
            this.pnlMapHost.Size = new System.Drawing.Size(0, 0);

            // ════════════════════════════════════════════════════════
            // RAPreviewSeats root
            // ════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(12, 32, 72);
            this.Size = new System.Drawing.Size(1100, 700);

            // z-order: splitMain (bottom) → pnlSearchBar → pnlFlightDropdown (top)
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlSearchBar);
            this.Controls.Add(this.pnlFlightDropdown);
            this.pnlFlightDropdown.BringToFront();

            // Resume layout
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlFlightDropdown.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.splitMain.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlStatusBadge.ResumeLayout(false);
            this.pnlOccupancyBar.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlMapViewport.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}