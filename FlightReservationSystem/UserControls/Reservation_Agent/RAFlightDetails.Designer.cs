namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    partial class RAFlightDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlOuter = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlAircraft = new System.Windows.Forms.Panel();
            this.lblAircraftIcon = new System.Windows.Forms.Label();
            this.lblAircraftName = new System.Windows.Forms.Label();
            this.lblAircraftModel = new System.Windows.Forms.Label();
            this.pnlRoute = new System.Windows.Forms.Panel();
            this.lblOriginCode = new System.Windows.Forms.Label();
            this.lblOriginName = new System.Windows.Forms.Label();
            this.pnlArrow = new System.Windows.Forms.Panel();
            this.lblArrow = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblDestCode = new System.Windows.Forms.Label();
            this.lblDestName = new System.Windows.Forms.Label();
            this.pnlTimes = new System.Windows.Forms.Panel();
            this.pnlDep = new System.Windows.Forms.Panel();
            this.lblDepLabel = new System.Windows.Forms.Label();
            this.lblDepTime = new System.Windows.Forms.Label();
            this.lblDepDate = new System.Windows.Forms.Label();
            this.pnlArr = new System.Windows.Forms.Panel();
            this.lblArrLabel = new System.Windows.Forms.Label();
            this.lblArrTime = new System.Windows.Forms.Label();
            this.lblArrDate = new System.Windows.Forms.Label();
            this.pnlTerminal = new System.Windows.Forms.Panel();
            this.lblTerminalIcon = new System.Windows.Forms.Label();
            this.lblTerminalGate = new System.Windows.Forms.Label();
            this.pnlDivider1 = new System.Windows.Forms.Panel();
            this.pnlPilots = new System.Windows.Forms.Panel();
            this.lblPilotsHeader = new System.Windows.Forms.Label();
            this.flpPilots = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDivider2 = new System.Windows.Forms.Panel();
            this.pnlAttendants = new System.Windows.Forms.Panel();
            this.lblAttHeader = new System.Windows.Forms.Label();
            this.flpAttendants = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOuter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlAircraft.SuspendLayout();
            this.pnlRoute.SuspendLayout();
            this.pnlArrow.SuspendLayout();
            this.pnlTimes.SuspendLayout();
            this.pnlDep.SuspendLayout();
            this.pnlArr.SuspendLayout();
            this.pnlTerminal.SuspendLayout();
            this.pnlPilots.SuspendLayout();
            this.pnlAttendants.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOuter
            // 
            this.pnlOuter.BackColor = System.Drawing.Color.White;
            this.pnlOuter.Controls.Add(this.pnlHeader);
            this.pnlOuter.Controls.Add(this.pnlAircraft);
            this.pnlOuter.Controls.Add(this.pnlRoute);
            this.pnlOuter.Controls.Add(this.pnlTimes);
            this.pnlOuter.Controls.Add(this.pnlTerminal);
            this.pnlOuter.Controls.Add(this.pnlDivider1);
            this.pnlOuter.Controls.Add(this.pnlPilots);
            this.pnlOuter.Controls.Add(this.pnlDivider2);
            this.pnlOuter.Controls.Add(this.pnlAttendants);
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.Location = new System.Drawing.Point(0, 0);
            this.pnlOuter.Name = "pnlOuter";
            this.pnlOuter.Size = new System.Drawing.Size(600, 475);
            this.pnlOuter.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 426);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 0, 12, 0);
            this.pnlHeader.Size = new System.Drawing.Size(600, 48);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Flight Details";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(140, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblStatus.Size = new System.Drawing.Size(100, 22);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "SCHEDULED";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.btnClose.Location = new System.Drawing.Point(556, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlAircraft
            // 
            this.pnlAircraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlAircraft.Controls.Add(this.lblAircraftIcon);
            this.pnlAircraft.Controls.Add(this.lblAircraftName);
            this.pnlAircraft.Controls.Add(this.lblAircraftModel);
            this.pnlAircraft.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAircraft.Location = new System.Drawing.Point(0, 370);
            this.pnlAircraft.Name = "pnlAircraft";
            this.pnlAircraft.Padding = new System.Windows.Forms.Padding(16, 10, 16, 6);
            this.pnlAircraft.Size = new System.Drawing.Size(600, 56);
            this.pnlAircraft.TabIndex = 1;
            // 
            // lblAircraftIcon
            // 
            this.lblAircraftIcon.AutoSize = true;
            this.lblAircraftIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblAircraftIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblAircraftIcon.Location = new System.Drawing.Point(16, 10);
            this.lblAircraftIcon.Name = "lblAircraftIcon";
            this.lblAircraftIcon.Size = new System.Drawing.Size(47, 32);
            this.lblAircraftIcon.TabIndex = 0;
            this.lblAircraftIcon.Text = "✈";
            // 
            // lblAircraftName
            // 
            this.lblAircraftName.AutoSize = true;
            this.lblAircraftName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblAircraftName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblAircraftName.Location = new System.Drawing.Point(79, 10);
            this.lblAircraftName.Name = "lblAircraftName";
            this.lblAircraftName.Size = new System.Drawing.Size(23, 19);
            this.lblAircraftName.TabIndex = 1;
            this.lblAircraftName.Text = "—";
            // 
            // lblAircraftModel
            // 
            this.lblAircraftModel.AutoSize = true;
            this.lblAircraftModel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAircraftModel.ForeColor = System.Drawing.Color.Gray;
            this.lblAircraftModel.Location = new System.Drawing.Point(80, 27);
            this.lblAircraftModel.Name = "lblAircraftModel";
            this.lblAircraftModel.Size = new System.Drawing.Size(19, 15);
            this.lblAircraftModel.TabIndex = 2;
            this.lblAircraftModel.Text = "—";
            // 
            // pnlRoute
            // 
            this.pnlRoute.BackColor = System.Drawing.Color.White;
            this.pnlRoute.Controls.Add(this.lblOriginCode);
            this.pnlRoute.Controls.Add(this.lblOriginName);
            this.pnlRoute.Controls.Add(this.pnlArrow);
            this.pnlRoute.Controls.Add(this.lblDestCode);
            this.pnlRoute.Controls.Add(this.lblDestName);
            this.pnlRoute.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoute.Location = new System.Drawing.Point(0, 290);
            this.pnlRoute.Name = "pnlRoute";
            this.pnlRoute.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);
            this.pnlRoute.Size = new System.Drawing.Size(600, 80);
            this.pnlRoute.TabIndex = 2;
            // 
            // lblOriginCode
            // 
            this.lblOriginCode.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblOriginCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblOriginCode.Location = new System.Drawing.Point(16, 12);
            this.lblOriginCode.Name = "lblOriginCode";
            this.lblOriginCode.Size = new System.Drawing.Size(60, 34);
            this.lblOriginCode.TabIndex = 0;
            this.lblOriginCode.Text = "—";
            // 
            // lblOriginName
            // 
            this.lblOriginName.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblOriginName.ForeColor = System.Drawing.Color.Gray;
            this.lblOriginName.Location = new System.Drawing.Point(22, 46);
            this.lblOriginName.Name = "lblOriginName";
            this.lblOriginName.Size = new System.Drawing.Size(160, 32);
            this.lblOriginName.TabIndex = 1;
            this.lblOriginName.Text = "—";
            // 
            // pnlArrow
            // 
            this.pnlArrow.BackColor = System.Drawing.Color.White;
            this.pnlArrow.Controls.Add(this.lblArrow);
            this.pnlArrow.Controls.Add(this.lblDuration);
            this.pnlArrow.Location = new System.Drawing.Point(190, 12);
            this.pnlArrow.Name = "pnlArrow";
            this.pnlArrow.Size = new System.Drawing.Size(180, 56);
            this.pnlArrow.TabIndex = 2;
            // 
            // lblArrow
            // 
            this.lblArrow.AutoSize = true;
            this.lblArrow.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblArrow.Location = new System.Drawing.Point(10, 6);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(104, 25);
            this.lblArrow.TabIndex = 0;
            this.lblArrow.Text = "————►";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDuration.ForeColor = System.Drawing.Color.Gray;
            this.lblDuration.Location = new System.Drawing.Point(34, 30);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(18, 13);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "—";
            // 
            // lblDestCode
            // 
            this.lblDestCode.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblDestCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblDestCode.Location = new System.Drawing.Point(382, 12);
            this.lblDestCode.Name = "lblDestCode";
            this.lblDestCode.Size = new System.Drawing.Size(60, 34);
            this.lblDestCode.TabIndex = 3;
            this.lblDestCode.Text = "—";
            // 
            // lblDestName
            // 
            this.lblDestName.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDestName.ForeColor = System.Drawing.Color.Gray;
            this.lblDestName.Location = new System.Drawing.Point(389, 46);
            this.lblDestName.Name = "lblDestName";
            this.lblDestName.Size = new System.Drawing.Size(160, 32);
            this.lblDestName.TabIndex = 4;
            this.lblDestName.Text = "—";
            // 
            // pnlTimes
            // 
            this.pnlTimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlTimes.Controls.Add(this.pnlDep);
            this.pnlTimes.Controls.Add(this.pnlArr);
            this.pnlTimes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimes.Location = new System.Drawing.Point(0, 218);
            this.pnlTimes.Name = "pnlTimes";
            this.pnlTimes.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlTimes.Size = new System.Drawing.Size(600, 72);
            this.pnlTimes.TabIndex = 3;
            // 
            // pnlDep
            // 
            this.pnlDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlDep.Controls.Add(this.lblDepLabel);
            this.pnlDep.Controls.Add(this.lblDepTime);
            this.pnlDep.Controls.Add(this.lblDepDate);
            this.pnlDep.Location = new System.Drawing.Point(12, 8);
            this.pnlDep.Name = "pnlDep";
            this.pnlDep.Size = new System.Drawing.Size(270, 56);
            this.pnlDep.TabIndex = 0;
            // 
            // lblDepLabel
            // 
            this.lblDepLabel.AutoSize = true;
            this.lblDepLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDepLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDepLabel.Location = new System.Drawing.Point(0, 0);
            this.lblDepLabel.Name = "lblDepLabel";
            this.lblDepLabel.Size = new System.Drawing.Size(61, 12);
            this.lblDepLabel.TabIndex = 0;
            this.lblDepLabel.Text = "DEPARTURE";
            // 
            // lblDepTime
            // 
            this.lblDepTime.AutoSize = true;
            this.lblDepTime.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblDepTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblDepTime.Location = new System.Drawing.Point(0, 14);
            this.lblDepTime.Name = "lblDepTime";
            this.lblDepTime.Size = new System.Drawing.Size(30, 25);
            this.lblDepTime.TabIndex = 1;
            this.lblDepTime.Text = "—";
            // 
            // lblDepDate
            // 
            this.lblDepDate.AutoSize = true;
            this.lblDepDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDepDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDepDate.Location = new System.Drawing.Point(0, 38);
            this.lblDepDate.Name = "lblDepDate";
            this.lblDepDate.Size = new System.Drawing.Size(18, 13);
            this.lblDepDate.TabIndex = 2;
            this.lblDepDate.Text = "—";
            // 
            // pnlArr
            // 
            this.pnlArr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlArr.Controls.Add(this.lblArrLabel);
            this.pnlArr.Controls.Add(this.lblArrTime);
            this.pnlArr.Controls.Add(this.lblArrDate);
            this.pnlArr.Location = new System.Drawing.Point(300, 8);
            this.pnlArr.Name = "pnlArr";
            this.pnlArr.Size = new System.Drawing.Size(270, 56);
            this.pnlArr.TabIndex = 1;
            // 
            // lblArrLabel
            // 
            this.lblArrLabel.AutoSize = true;
            this.lblArrLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblArrLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblArrLabel.Location = new System.Drawing.Point(0, 0);
            this.lblArrLabel.Name = "lblArrLabel";
            this.lblArrLabel.Size = new System.Drawing.Size(47, 12);
            this.lblArrLabel.TabIndex = 0;
            this.lblArrLabel.Text = "ARRIVAL";
            // 
            // lblArrTime
            // 
            this.lblArrTime.AutoSize = true;
            this.lblArrTime.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblArrTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblArrTime.Location = new System.Drawing.Point(0, 14);
            this.lblArrTime.Name = "lblArrTime";
            this.lblArrTime.Size = new System.Drawing.Size(30, 25);
            this.lblArrTime.TabIndex = 1;
            this.lblArrTime.Text = "—";
            // 
            // lblArrDate
            // 
            this.lblArrDate.AutoSize = true;
            this.lblArrDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblArrDate.ForeColor = System.Drawing.Color.Gray;
            this.lblArrDate.Location = new System.Drawing.Point(0, 38);
            this.lblArrDate.Name = "lblArrDate";
            this.lblArrDate.Size = new System.Drawing.Size(18, 13);
            this.lblArrDate.TabIndex = 2;
            this.lblArrDate.Text = "—";
            // 
            // pnlTerminal
            // 
            this.pnlTerminal.BackColor = System.Drawing.Color.White;
            this.pnlTerminal.Controls.Add(this.lblTerminalIcon);
            this.pnlTerminal.Controls.Add(this.lblTerminalGate);
            this.pnlTerminal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTerminal.Location = new System.Drawing.Point(0, 182);
            this.pnlTerminal.Name = "pnlTerminal";
            this.pnlTerminal.Padding = new System.Windows.Forms.Padding(14, 8, 14, 4);
            this.pnlTerminal.Size = new System.Drawing.Size(600, 36);
            this.pnlTerminal.TabIndex = 4;
            // 
            // lblTerminalIcon
            // 
            this.lblTerminalIcon.AutoSize = true;
            this.lblTerminalIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.lblTerminalIcon.Location = new System.Drawing.Point(14, 8);
            this.lblTerminalIcon.Name = "lblTerminalIcon";
            this.lblTerminalIcon.Size = new System.Drawing.Size(28, 19);
            this.lblTerminalIcon.TabIndex = 0;
            this.lblTerminalIcon.Text = "🚪";
            // 
            // lblTerminalGate
            // 
            this.lblTerminalGate.AutoSize = true;
            this.lblTerminalGate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTerminalGate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblTerminalGate.Location = new System.Drawing.Point(42, 10);
            this.lblTerminalGate.Name = "lblTerminalGate";
            this.lblTerminalGate.Size = new System.Drawing.Size(19, 15);
            this.lblTerminalGate.TabIndex = 1;
            this.lblTerminalGate.Text = "—";
            // 
            // pnlDivider1
            // 
            this.pnlDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.pnlDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDivider1.Location = new System.Drawing.Point(0, 181);
            this.pnlDivider1.Name = "pnlDivider1";
            this.pnlDivider1.Size = new System.Drawing.Size(600, 1);
            this.pnlDivider1.TabIndex = 5;
            // 
            // pnlPilots
            // 
            this.pnlPilots.BackColor = System.Drawing.Color.White;
            this.pnlPilots.Controls.Add(this.lblPilotsHeader);
            this.pnlPilots.Controls.Add(this.flpPilots);
            this.pnlPilots.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPilots.Location = new System.Drawing.Point(0, 101);
            this.pnlPilots.Name = "pnlPilots";
            this.pnlPilots.Padding = new System.Windows.Forms.Padding(14, 8, 14, 4);
            this.pnlPilots.Size = new System.Drawing.Size(600, 80);
            this.pnlPilots.TabIndex = 6;
            // 
            // lblPilotsHeader
            // 
            this.lblPilotsHeader.AutoSize = true;
            this.lblPilotsHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPilotsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblPilotsHeader.Location = new System.Drawing.Point(14, 8);
            this.lblPilotsHeader.Name = "lblPilotsHeader";
            this.lblPilotsHeader.Size = new System.Drawing.Size(65, 15);
            this.lblPilotsHeader.TabIndex = 0;
            this.lblPilotsHeader.Text = "👨‍✈️  PILOTS";
            // 
            // flpPilots
            // 
            this.flpPilots.BackColor = System.Drawing.Color.White;
            this.flpPilots.Location = new System.Drawing.Point(14, 28);
            this.flpPilots.Name = "flpPilots";
            this.flpPilots.Size = new System.Drawing.Size(560, 44);
            this.flpPilots.TabIndex = 1;
            // 
            // pnlDivider2
            // 
            this.pnlDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.pnlDivider2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDivider2.Location = new System.Drawing.Point(0, 100);
            this.pnlDivider2.Name = "pnlDivider2";
            this.pnlDivider2.Size = new System.Drawing.Size(600, 1);
            this.pnlDivider2.TabIndex = 7;
            // 
            // pnlAttendants
            // 
            this.pnlAttendants.BackColor = System.Drawing.Color.White;
            this.pnlAttendants.Controls.Add(this.lblAttHeader);
            this.pnlAttendants.Controls.Add(this.flpAttendants);
            this.pnlAttendants.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttendants.Location = new System.Drawing.Point(0, 0);
            this.pnlAttendants.Name = "pnlAttendants";
            this.pnlAttendants.Padding = new System.Windows.Forms.Padding(14, 8, 14, 4);
            this.pnlAttendants.Size = new System.Drawing.Size(600, 100);
            this.pnlAttendants.TabIndex = 8;
            // 
            // lblAttHeader
            // 
            this.lblAttHeader.AutoSize = true;
            this.lblAttHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAttHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblAttHeader.Location = new System.Drawing.Point(14, 8);
            this.lblAttHeader.Name = "lblAttHeader";
            this.lblAttHeader.Size = new System.Drawing.Size(145, 15);
            this.lblAttHeader.TabIndex = 0;
            this.lblAttHeader.Text = "🧑‍✈️  FLIGHT ATTENDANTS";
            // 
            // flpAttendants
            // 
            this.flpAttendants.BackColor = System.Drawing.Color.White;
            this.flpAttendants.Location = new System.Drawing.Point(14, 28);
            this.flpAttendants.Name = "flpAttendants";
            this.flpAttendants.Size = new System.Drawing.Size(560, 64);
            this.flpAttendants.TabIndex = 1;
            // 
            // RAFlightDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlOuter);
            this.Name = "RAFlightDetails";
            this.Size = new System.Drawing.Size(600, 475);
            this.pnlOuter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAircraft.ResumeLayout(false);
            this.pnlAircraft.PerformLayout();
            this.pnlRoute.ResumeLayout(false);
            this.pnlArrow.ResumeLayout(false);
            this.pnlArrow.PerformLayout();
            this.pnlTimes.ResumeLayout(false);
            this.pnlDep.ResumeLayout(false);
            this.pnlDep.PerformLayout();
            this.pnlArr.ResumeLayout(false);
            this.pnlArr.PerformLayout();
            this.pnlTerminal.ResumeLayout(false);
            this.pnlTerminal.PerformLayout();
            this.pnlPilots.ResumeLayout(false);
            this.pnlPilots.PerformLayout();
            this.pnlAttendants.ResumeLayout(false);
            this.pnlAttendants.PerformLayout();
            this.ResumeLayout(false);

        }

        // ── Control declarations ──────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlOuter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlAircraft;
        private System.Windows.Forms.Label lblAircraftIcon;
        internal System.Windows.Forms.Label lblAircraftName;
        internal System.Windows.Forms.Label lblAircraftModel;

        private System.Windows.Forms.Panel pnlRoute;
        internal System.Windows.Forms.Label lblOriginCode;
        internal System.Windows.Forms.Label lblOriginName;
        private System.Windows.Forms.Panel pnlArrow;
        private System.Windows.Forms.Label lblArrow;
        internal System.Windows.Forms.Label lblDuration;
        internal System.Windows.Forms.Label lblDestCode;
        internal System.Windows.Forms.Label lblDestName;

        private System.Windows.Forms.Panel pnlTimes;
        private System.Windows.Forms.Panel pnlDep;
        private System.Windows.Forms.Label lblDepLabel;
        internal System.Windows.Forms.Label lblDepTime;
        internal System.Windows.Forms.Label lblDepDate;
        private System.Windows.Forms.Panel pnlArr;
        private System.Windows.Forms.Label lblArrLabel;
        internal System.Windows.Forms.Label lblArrTime;
        internal System.Windows.Forms.Label lblArrDate;

        private System.Windows.Forms.Panel pnlTerminal;
        private System.Windows.Forms.Label lblTerminalIcon;
        internal System.Windows.Forms.Label lblTerminalGate;

        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Panel pnlPilots;
        private System.Windows.Forms.Label lblPilotsHeader;
        internal System.Windows.Forms.FlowLayoutPanel flpPilots;

        private System.Windows.Forms.Panel pnlDivider2;
        private System.Windows.Forms.Panel pnlAttendants;
        private System.Windows.Forms.Label lblAttHeader;
        internal System.Windows.Forms.FlowLayoutPanel flpAttendants;
    }
}