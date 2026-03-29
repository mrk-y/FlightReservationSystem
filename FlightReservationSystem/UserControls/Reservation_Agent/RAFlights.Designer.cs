namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    partial class RAFlights
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.lblResultsTitle = new System.Windows.Forms.Label();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.pnlSearchBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTripType = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblDepart = new System.Windows.Forms.Label();
            this.dtpDepart = new System.Windows.Forms.DateTimePicker();
            this.lblPassengers = new System.Windows.Forms.Label();
            this.nudPassengers = new System.Windows.Forms.NumericUpDown();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.pnlSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPassengers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlResults);
            this.pnlMain.Controls.Add(this.pnlSearchBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1262, 585);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlResults
            // 
            this.pnlResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlResults.Controls.Add(this.pnlCards);
            this.pnlResults.Controls.Add(this.lblResultsTitle);
            this.pnlResults.Controls.Add(this.lblSortBy);
            this.pnlResults.Controls.Add(this.cmbSortBy);
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResults.Location = new System.Drawing.Point(0, 120);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlResults.Size = new System.Drawing.Size(1262, 465);
            this.pnlResults.TabIndex = 0;
            // 
            // lblResultsTitle
            // 
            this.lblResultsTitle.AutoSize = true;
            this.lblResultsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblResultsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.lblResultsTitle.Location = new System.Drawing.Point(20, 14);
            this.lblResultsTitle.Name = "lblResultsTitle";
            this.lblResultsTitle.Size = new System.Drawing.Size(121, 20);
            this.lblResultsTitle.TabIndex = 0;
            this.lblResultsTitle.Text = "Available Flights";
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSortBy.ForeColor = System.Drawing.Color.Gray;
            this.lblSortBy.Location = new System.Drawing.Point(980, 15);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(47, 15);
            this.lblSortBy.TabIndex = 1;
            this.lblSortBy.Text = "Sort by:";
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSortBy.Items.AddRange(new object[] {
            "Cheapest",
            "Fastest",
            "Departure",
            "Arrival"});
            this.cmbSortBy.Location = new System.Drawing.Point(1030, 12);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(110, 23);
            this.cmbSortBy.TabIndex = 2;
            // 
            // pnlSearchBar
            // 
            this.pnlSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.pnlSearchBar.Controls.Add(this.label1);
            this.pnlSearchBar.Controls.Add(this.lblTripType);
            this.pnlSearchBar.Controls.Add(this.lblFrom);
            this.pnlSearchBar.Controls.Add(this.txtFrom);
            this.pnlSearchBar.Controls.Add(this.lblTo);
            this.pnlSearchBar.Controls.Add(this.txtTo);
            this.pnlSearchBar.Controls.Add(this.lblDepart);
            this.pnlSearchBar.Controls.Add(this.dtpDepart);
            this.pnlSearchBar.Controls.Add(this.lblPassengers);
            this.pnlSearchBar.Controls.Add(this.nudPassengers);
            this.pnlSearchBar.Controls.Add(this.lblClass);
            this.pnlSearchBar.Controls.Add(this.cmbClass);
            this.pnlSearchBar.Controls.Add(this.btnSearch);
            this.pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchBar.Name = "pnlSearchBar";
            this.pnlSearchBar.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.pnlSearchBar.Size = new System.Drawing.Size(1262, 120);
            this.pnlSearchBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "TRIP";
            // 
            // lblTripType
            // 
            this.lblTripType.AutoSize = true;
            this.lblTripType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTripType.ForeColor = System.Drawing.Color.White;
            this.lblTripType.Location = new System.Drawing.Point(23, 29);
            this.lblTripType.Name = "lblTripType";
            this.lblTripType.Size = new System.Drawing.Size(66, 19);
            this.lblTripType.TabIndex = 0;
            this.lblTripType.Text = "One Way";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblFrom.Location = new System.Drawing.Point(110, 14);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 12);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "FROM";
            // 
            // txtFrom
            // 
            this.txtFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
            this.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFrom.ForeColor = System.Drawing.Color.White;
            this.txtFrom.Location = new System.Drawing.Point(110, 32);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(150, 16);
            this.txtFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblTo.Location = new System.Drawing.Point(274, 14);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(18, 12);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "TO";
            // 
            // txtTo
            // 
            this.txtTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
            this.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTo.ForeColor = System.Drawing.Color.White;
            this.txtTo.Location = new System.Drawing.Point(274, 32);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(150, 16);
            this.txtTo.TabIndex = 4;
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDepart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblDepart.Location = new System.Drawing.Point(438, 14);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(82, 12);
            this.lblDepart.TabIndex = 5;
            this.lblDepart.Text = "DEPARTURE DATE";
            // 
            // dtpDepart
            // 
            this.dtpDepart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDepart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepart.Location = new System.Drawing.Point(438, 30);
            this.dtpDepart.Name = "dtpDepart";
            this.dtpDepart.Size = new System.Drawing.Size(130, 23);
            this.dtpDepart.TabIndex = 6;
            // 
            // lblPassengers
            // 
            this.lblPassengers.AutoSize = true;
            this.lblPassengers.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblPassengers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblPassengers.Location = new System.Drawing.Point(582, 14);
            this.lblPassengers.Name = "lblPassengers";
            this.lblPassengers.Size = new System.Drawing.Size(61, 12);
            this.lblPassengers.TabIndex = 7;
            this.lblPassengers.Text = "PASSENGERS";
            // 
            // nudPassengers
            // 
            this.nudPassengers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
            this.nudPassengers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudPassengers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudPassengers.ForeColor = System.Drawing.Color.White;
            this.nudPassengers.Location = new System.Drawing.Point(582, 33);
            this.nudPassengers.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudPassengers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPassengers.Name = "nudPassengers";
            this.nudPassengers.Size = new System.Drawing.Size(65, 19);
            this.nudPassengers.TabIndex = 8;
            this.nudPassengers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblClass.Location = new System.Drawing.Point(660, 14);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 12);
            this.lblClass.TabIndex = 9;
            this.lblClass.Text = "CLASS";
            // 
            // cmbClass
            // 
            this.cmbClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbClass.ForeColor = System.Drawing.Color.White;
            this.cmbClass.Items.AddRange(new object[] {
            "Economy",
            "Business",
            "First Class"});
            this.cmbClass.Location = new System.Drawing.Point(660, 30);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(120, 23);
            this.cmbClass.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(796, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 36);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search Flights";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlCards
            // 
            this.pnlCards.Location = new System.Drawing.Point(50, 65);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1155, 377);
            this.pnlCards.TabIndex = 3;
            // 
            // RAFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "RAFlights";
            this.Size = new System.Drawing.Size(1262, 585);
            this.Load += new System.EventHandler(this.RAFlights_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPassengers)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain, pnlSearchBar, pnlResults;
        private System.Windows.Forms.Label lblTripType, lblFrom, lblTo, lblDepart;
        private System.Windows.Forms.Label lblPassengers, lblClass;
        private System.Windows.Forms.Label lblResultsTitle, lblSortBy;
        private System.Windows.Forms.TextBox txtFrom, txtTo;
        private System.Windows.Forms.DateTimePicker dtpDepart;
        private System.Windows.Forms.NumericUpDown nudPassengers;
        private System.Windows.Forms.ComboBox cmbClass, cmbSortBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAirline;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStops;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewButtonColumn colBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCards;
    }
}