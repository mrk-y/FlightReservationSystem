namespace FlightReservationSystem.UserControls.SystemAdmin
{
    partial class AssignRoute
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl1 = new System.Windows.Forms.Panel();
            this.picAirlineImg = new System.Windows.Forms.PictureBox();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.lblAircraftID = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblSeparator1 = new System.Windows.Forms.Label();
            this.lblSeparator2 = new System.Windows.Forms.Label();
            this.lblAircraftIDVal = new System.Windows.Forms.Label();
            this.lblDisplayNameVal = new System.Windows.Forms.Label();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.lblTotalDistance = new System.Windows.Forms.Label();
            this.lblSeparator3 = new System.Windows.Forms.Label();
            this.lblTotalDistanceVal = new System.Windows.Forms.Label();
            this.lblFlightDuration = new System.Windows.Forms.Label();
            this.lblSeparator4 = new System.Windows.Forms.Label();
            this.lblFlightDurationVal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAircraft = new System.Windows.Forms.Label();
            this.cmbAircraftVal = new System.Windows.Forms.ComboBox();
            this.lblAirline = new System.Windows.Forms.Label();
            this.cmbAirlineVal = new System.Windows.Forms.ComboBox();
            this.lblTerminal = new System.Windows.Forms.Label();
            this.cmbTerminalVal = new System.Windows.Forms.ComboBox();
            this.lblGate = new System.Windows.Forms.Label();
            this.cmbGateVal = new System.Windows.Forms.ComboBox();
            this.cmbDestinationVal = new System.Windows.Forms.ComboBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.cmbOriginVal = new System.Windows.Forms.ComboBox();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.dateArrivalVal = new System.Windows.Forms.DateTimePicker();
            this.lblArrival = new System.Windows.Forms.Label();
            this.dateDepartureVal = new System.Windows.Forms.DateTimePicker();
            this.lblDeparture = new System.Windows.Forms.Label();
            this.btnAssignAircraft = new System.Windows.Forms.Button();
            this.saProgress1 = new FlightReservationSystem.UserControls.SystemAdmin.SAProgress();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAirlineImg)).BeginInit();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.AutoSize = true;
            this.pnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl1.BackColor = System.Drawing.Color.White;
            this.pnl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl1.Controls.Add(this.pnl2);
            this.pnl1.Controls.Add(this.picAirlineImg);
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.pnl1.Name = "pnl1";
            this.pnl1.Padding = new System.Windows.Forms.Padding(12);
            this.pnl1.Size = new System.Drawing.Size(398, 106);
            this.pnl1.TabIndex = 0;
            // 
            // picAirlineImg
            // 
            this.picAirlineImg.Location = new System.Drawing.Point(12, 12);
            this.picAirlineImg.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.picAirlineImg.Name = "picAirlineImg";
            this.picAirlineImg.Size = new System.Drawing.Size(80, 80);
            this.picAirlineImg.TabIndex = 1;
            this.picAirlineImg.TabStop = false;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.lblDisplayNameVal);
            this.pnl2.Controls.Add(this.lblAircraftIDVal);
            this.pnl2.Controls.Add(this.lblSeparator2);
            this.pnl2.Controls.Add(this.lblSeparator1);
            this.pnl2.Controls.Add(this.lblDisplayName);
            this.pnl2.Controls.Add(this.lblAircraftID);
            this.pnl2.Location = new System.Drawing.Point(100, 12);
            this.pnl2.Margin = new System.Windows.Forms.Padding(0);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(284, 59);
            this.pnl2.TabIndex = 1;
            // 
            // lblAircraftID
            // 
            this.lblAircraftID.AutoSize = true;
            this.lblAircraftID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblAircraftID.Location = new System.Drawing.Point(0, 2);
            this.lblAircraftID.Margin = new System.Windows.Forms.Padding(0, 0, 24, 8);
            this.lblAircraftID.Name = "lblAircraftID";
            this.lblAircraftID.Size = new System.Drawing.Size(66, 15);
            this.lblAircraftID.TabIndex = 3;
            this.lblAircraftID.Text = "Aircraft ID";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblDisplayName.Location = new System.Drawing.Point(0, 27);
            this.lblDisplayName.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(82, 15);
            this.lblDisplayName.TabIndex = 4;
            this.lblDisplayName.Text = "Display Name";
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.AutoSize = true;
            this.lblSeparator1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator1.Location = new System.Drawing.Point(106, 2);
            this.lblSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator1.TabIndex = 5;
            this.lblSeparator1.Text = ":";
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.AutoSize = true;
            this.lblSeparator2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator2.Location = new System.Drawing.Point(106, 27);
            this.lblSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator2.TabIndex = 6;
            this.lblSeparator2.Text = ":";
            // 
            // lblAircraftIDVal
            // 
            this.lblAircraftIDVal.AutoSize = true;
            this.lblAircraftIDVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAircraftIDVal.ForeColor = System.Drawing.Color.Black;
            this.lblAircraftIDVal.Location = new System.Drawing.Point(124, 0);
            this.lblAircraftIDVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblAircraftIDVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblAircraftIDVal.Name = "lblAircraftIDVal";
            this.lblAircraftIDVal.Size = new System.Drawing.Size(160, 17);
            this.lblAircraftIDVal.TabIndex = 7;
            this.lblAircraftIDVal.Text = "[Value]";
            // 
            // lblDisplayNameVal
            // 
            this.lblDisplayNameVal.AutoEllipsis = true;
            this.lblDisplayNameVal.AutoSize = true;
            this.lblDisplayNameVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDisplayNameVal.ForeColor = System.Drawing.Color.Black;
            this.lblDisplayNameVal.Location = new System.Drawing.Point(124, 25);
            this.lblDisplayNameVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblDisplayNameVal.MaximumSize = new System.Drawing.Size(160, 34);
            this.lblDisplayNameVal.MinimumSize = new System.Drawing.Size(160, 34);
            this.lblDisplayNameVal.Name = "lblDisplayNameVal";
            this.lblDisplayNameVal.Size = new System.Drawing.Size(160, 34);
            this.lblDisplayNameVal.TabIndex = 8;
            this.lblDisplayNameVal.Text = "[Value]";
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.lblFlightDurationVal);
            this.pnl3.Controls.Add(this.lblSeparator4);
            this.pnl3.Controls.Add(this.lblFlightDuration);
            this.pnl3.Controls.Add(this.lblTotalDistanceVal);
            this.pnl3.Controls.Add(this.lblSeparator3);
            this.pnl3.Controls.Add(this.lblTotalDistance);
            this.pnl3.Location = new System.Drawing.Point(12, 12);
            this.pnl3.Margin = new System.Windows.Forms.Padding(0);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(292, 42);
            this.pnl3.TabIndex = 1;
            // 
            // lblTotalDistance
            // 
            this.lblTotalDistance.AutoSize = true;
            this.lblTotalDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblTotalDistance.Location = new System.Drawing.Point(0, 2);
            this.lblTotalDistance.Margin = new System.Windows.Forms.Padding(0, 0, 24, 8);
            this.lblTotalDistance.Name = "lblTotalDistance";
            this.lblTotalDistance.Size = new System.Drawing.Size(85, 15);
            this.lblTotalDistance.TabIndex = 9;
            this.lblTotalDistance.Text = "Total Distance";
            // 
            // lblSeparator3
            // 
            this.lblSeparator3.AutoSize = true;
            this.lblSeparator3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator3.Location = new System.Drawing.Point(114, 2);
            this.lblSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.lblSeparator3.Name = "lblSeparator3";
            this.lblSeparator3.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator3.TabIndex = 9;
            this.lblSeparator3.Text = ":";
            // 
            // lblTotalDistanceVal
            // 
            this.lblTotalDistanceVal.AutoSize = true;
            this.lblTotalDistanceVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalDistanceVal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDistanceVal.Location = new System.Drawing.Point(132, 0);
            this.lblTotalDistanceVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblTotalDistanceVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblTotalDistanceVal.Name = "lblTotalDistanceVal";
            this.lblTotalDistanceVal.Size = new System.Drawing.Size(160, 17);
            this.lblTotalDistanceVal.TabIndex = 9;
            this.lblTotalDistanceVal.Text = "[Value]";
            // 
            // lblFlightDuration
            // 
            this.lblFlightDuration.AutoSize = true;
            this.lblFlightDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblFlightDuration.Location = new System.Drawing.Point(0, 27);
            this.lblFlightDuration.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblFlightDuration.Name = "lblFlightDuration";
            this.lblFlightDuration.Size = new System.Drawing.Size(90, 15);
            this.lblFlightDuration.TabIndex = 10;
            this.lblFlightDuration.Text = "Flight Duration";
            // 
            // lblSeparator4
            // 
            this.lblSeparator4.AutoSize = true;
            this.lblSeparator4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator4.Location = new System.Drawing.Point(114, 27);
            this.lblSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblSeparator4.Name = "lblSeparator4";
            this.lblSeparator4.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator4.TabIndex = 11;
            this.lblSeparator4.Text = ":";
            // 
            // lblFlightDurationVal
            // 
            this.lblFlightDurationVal.AutoSize = true;
            this.lblFlightDurationVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFlightDurationVal.ForeColor = System.Drawing.Color.Black;
            this.lblFlightDurationVal.Location = new System.Drawing.Point(132, 25);
            this.lblFlightDurationVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblFlightDurationVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblFlightDurationVal.Name = "lblFlightDurationVal";
            this.lblFlightDurationVal.Size = new System.Drawing.Size(160, 17);
            this.lblFlightDurationVal.TabIndex = 12;
            this.lblFlightDurationVal.Text = "[Value]";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnl3);
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(318, 68);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbDestinationVal);
            this.panel2.Controls.Add(this.lblDestination);
            this.panel2.Controls.Add(this.cmbOriginVal);
            this.panel2.Controls.Add(this.lblOrigin);
            this.panel2.Controls.Add(this.dateArrivalVal);
            this.panel2.Controls.Add(this.lblArrival);
            this.panel2.Controls.Add(this.dateDepartureVal);
            this.panel2.Controls.Add(this.lblDeparture);
            this.panel2.Controls.Add(this.cmbGateVal);
            this.panel2.Controls.Add(this.lblGate);
            this.panel2.Controls.Add(this.cmbTerminalVal);
            this.panel2.Controls.Add(this.lblTerminal);
            this.panel2.Controls.Add(this.cmbAirlineVal);
            this.panel2.Controls.Add(this.lblAirline);
            this.panel2.Controls.Add(this.cmbAircraftVal);
            this.panel2.Controls.Add(this.lblAircraft);
            this.panel2.Location = new System.Drawing.Point(430, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12);
            this.panel2.Size = new System.Drawing.Size(538, 250);
            this.panel2.TabIndex = 3;
            // 
            // lblAircraft
            // 
            this.lblAircraft.AutoSize = true;
            this.lblAircraft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblAircraft.Location = new System.Drawing.Point(12, 12);
            this.lblAircraft.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblAircraft.Name = "lblAircraft";
            this.lblAircraft.Size = new System.Drawing.Size(58, 15);
            this.lblAircraft.TabIndex = 13;
            this.lblAircraft.Text = "Aircraft *";
            // 
            // cmbAircraftVal
            // 
            this.cmbAircraftVal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAircraftVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbAircraftVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbAircraftVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAircraftVal.ForeColor = System.Drawing.Color.Black;
            this.cmbAircraftVal.FormattingEnabled = true;
            this.cmbAircraftVal.Location = new System.Drawing.Point(12, 31);
            this.cmbAircraftVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.cmbAircraftVal.Name = "cmbAircraftVal";
            this.cmbAircraftVal.Size = new System.Drawing.Size(240, 25);
            this.cmbAircraftVal.TabIndex = 14;
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblAirline.Location = new System.Drawing.Point(281, 12);
            this.lblAirline.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(51, 15);
            this.lblAirline.TabIndex = 15;
            this.lblAirline.Text = "Airline *";
            // 
            // cmbAirlineVal
            // 
            this.cmbAirlineVal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAirlineVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbAirlineVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbAirlineVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAirlineVal.ForeColor = System.Drawing.Color.Black;
            this.cmbAirlineVal.FormattingEnabled = true;
            this.cmbAirlineVal.Location = new System.Drawing.Point(284, 31);
            this.cmbAirlineVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.cmbAirlineVal.Name = "cmbAirlineVal";
            this.cmbAirlineVal.Size = new System.Drawing.Size(240, 25);
            this.cmbAirlineVal.TabIndex = 16;
            // 
            // lblTerminal
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblTerminal.Location = new System.Drawing.Point(12, 72);
            this.lblTerminal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(63, 15);
            this.lblTerminal.TabIndex = 17;
            this.lblTerminal.Text = "Terminal *";
            // 
            // cmbTerminalVal
            // 
            this.cmbTerminalVal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTerminalVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbTerminalVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbTerminalVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTerminalVal.ForeColor = System.Drawing.Color.Black;
            this.cmbTerminalVal.FormattingEnabled = true;
            this.cmbTerminalVal.Location = new System.Drawing.Point(12, 91);
            this.cmbTerminalVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.cmbTerminalVal.Name = "cmbTerminalVal";
            this.cmbTerminalVal.Size = new System.Drawing.Size(240, 25);
            this.cmbTerminalVal.TabIndex = 18;
            // 
            // lblGate
            // 
            this.lblGate.AutoSize = true;
            this.lblGate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblGate.Location = new System.Drawing.Point(281, 72);
            this.lblGate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblGate.Name = "lblGate";
            this.lblGate.Size = new System.Drawing.Size(42, 15);
            this.lblGate.TabIndex = 19;
            this.lblGate.Text = "Gate *";
            // 
            // cmbGateVal
            // 
            this.cmbGateVal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGateVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbGateVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbGateVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGateVal.ForeColor = System.Drawing.Color.Black;
            this.cmbGateVal.FormattingEnabled = true;
            this.cmbGateVal.Location = new System.Drawing.Point(284, 91);
            this.cmbGateVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.cmbGateVal.Name = "cmbGateVal";
            this.cmbGateVal.Size = new System.Drawing.Size(240, 25);
            this.cmbGateVal.TabIndex = 20;
            // 
            // cmbDestinationVal
            // 
            this.cmbDestinationVal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDestinationVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbDestinationVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbDestinationVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestinationVal.ForeColor = System.Drawing.Color.Black;
            this.cmbDestinationVal.FormattingEnabled = true;
            this.cmbDestinationVal.Location = new System.Drawing.Point(284, 211);
            this.cmbDestinationVal.Margin = new System.Windows.Forms.Padding(0);
            this.cmbDestinationVal.Name = "cmbDestinationVal";
            this.cmbDestinationVal.Size = new System.Drawing.Size(240, 25);
            this.cmbDestinationVal.TabIndex = 35;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblDestination.Location = new System.Drawing.Point(281, 192);
            this.lblDestination.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(79, 15);
            this.lblDestination.TabIndex = 34;
            this.lblDestination.Text = "Destination *";
            // 
            // cmbOriginVal
            // 
            this.cmbOriginVal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOriginVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbOriginVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbOriginVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOriginVal.ForeColor = System.Drawing.Color.Black;
            this.cmbOriginVal.FormattingEnabled = true;
            this.cmbOriginVal.Location = new System.Drawing.Point(12, 211);
            this.cmbOriginVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 0);
            this.cmbOriginVal.Name = "cmbOriginVal";
            this.cmbOriginVal.Size = new System.Drawing.Size(240, 25);
            this.cmbOriginVal.TabIndex = 28;
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblOrigin.Location = new System.Drawing.Point(12, 192);
            this.lblOrigin.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(49, 15);
            this.lblOrigin.TabIndex = 33;
            this.lblOrigin.Text = "Origin *";
            // 
            // dateArrivalVal
            // 
            this.dateArrivalVal.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateArrivalVal.CalendarForeColor = System.Drawing.Color.Black;
            this.dateArrivalVal.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateArrivalVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateArrivalVal.Location = new System.Drawing.Point(284, 151);
            this.dateArrivalVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.dateArrivalVal.Name = "dateArrivalVal";
            this.dateArrivalVal.Size = new System.Drawing.Size(240, 25);
            this.dateArrivalVal.TabIndex = 32;
            // 
            // lblArrival
            // 
            this.lblArrival.AutoSize = true;
            this.lblArrival.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrival.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblArrival.Location = new System.Drawing.Point(281, 132);
            this.lblArrival.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblArrival.Name = "lblArrival";
            this.lblArrival.Size = new System.Drawing.Size(52, 15);
            this.lblArrival.TabIndex = 31;
            this.lblArrival.Text = "Arrival *";
            // 
            // dateDepartureVal
            // 
            this.dateDepartureVal.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDepartureVal.CalendarForeColor = System.Drawing.Color.Black;
            this.dateDepartureVal.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateDepartureVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDepartureVal.Location = new System.Drawing.Point(12, 151);
            this.dateDepartureVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.dateDepartureVal.Name = "dateDepartureVal";
            this.dateDepartureVal.Size = new System.Drawing.Size(240, 25);
            this.dateDepartureVal.TabIndex = 30;
            // 
            // lblDeparture
            // 
            this.lblDeparture.AutoSize = true;
            this.lblDeparture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblDeparture.Location = new System.Drawing.Point(12, 132);
            this.lblDeparture.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblDeparture.Name = "lblDeparture";
            this.lblDeparture.Size = new System.Drawing.Size(73, 15);
            this.lblDeparture.TabIndex = 29;
            this.lblDeparture.Text = "Departure *";
            // 
            // btnAssignAircraft
            // 
            this.btnAssignAircraft.AutoSize = true;
            this.btnAssignAircraft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAssignAircraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAssignAircraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignAircraft.FlatAppearance.BorderSize = 0;
            this.btnAssignAircraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignAircraft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignAircraft.ForeColor = System.Drawing.Color.White;
            this.btnAssignAircraft.Location = new System.Drawing.Point(854, 387);
            this.btnAssignAircraft.Margin = new System.Windows.Forms.Padding(0);
            this.btnAssignAircraft.Name = "btnAssignAircraft";
            this.btnAssignAircraft.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnAssignAircraft.Size = new System.Drawing.Size(114, 29);
            this.btnAssignAircraft.TabIndex = 7;
            this.btnAssignAircraft.Text = "Assign Aircraft";
            this.btnAssignAircraft.UseVisualStyleBackColor = false;
            // 
            // saProgress1
            // 
            this.saProgress1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saProgress1.BackColor = System.Drawing.Color.White;
            this.saProgress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saProgress1.Location = new System.Drawing.Point(0, 503);
            this.saProgress1.Margin = new System.Windows.Forms.Padding(0);
            this.saProgress1.Name = "saProgress1";
            this.saProgress1.Padding = new System.Windows.Forms.Padding(12);
            this.saProgress1.Size = new System.Drawing.Size(301, 41);
            this.saProgress1.TabIndex = 8;
            // 
            // AssignRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.saProgress1);
            this.Controls.Add(this.btnAssignAircraft);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AssignRoute";
            this.Size = new System.Drawing.Size(1200, 544);
            this.ParentChanged += new System.EventHandler(this.AssignRoute_ParentChanged);
            this.pnl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAirlineImg)).EndInit();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.PictureBox picAirlineImg;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Label lblAircraftID;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblSeparator1;
        private System.Windows.Forms.Label lblSeparator2;
        private System.Windows.Forms.Label lblAircraftIDVal;
        private System.Windows.Forms.Label lblDisplayNameVal;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Label lblTotalDistance;
        private System.Windows.Forms.Label lblSeparator3;
        private System.Windows.Forms.Label lblTotalDistanceVal;
        private System.Windows.Forms.Label lblFlightDuration;
        private System.Windows.Forms.Label lblSeparator4;
        private System.Windows.Forms.Label lblFlightDurationVal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAircraft;
        private System.Windows.Forms.ComboBox cmbAircraftVal;
        private System.Windows.Forms.Label lblAirline;
        private System.Windows.Forms.ComboBox cmbAirlineVal;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.ComboBox cmbTerminalVal;
        private System.Windows.Forms.Label lblGate;
        private System.Windows.Forms.ComboBox cmbGateVal;
        private System.Windows.Forms.ComboBox cmbDestinationVal;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ComboBox cmbOriginVal;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.DateTimePicker dateArrivalVal;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.DateTimePicker dateDepartureVal;
        private System.Windows.Forms.Label lblDeparture;
        private System.Windows.Forms.Button btnAssignAircraft;
        private SAProgress saProgress1;
    }
}
