namespace FlightReservationSystem.UserControls.SystemAdmin
{
    partial class Statistics
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbViewDaily = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbViewAnnually = new System.Windows.Forms.RadioButton();
            this.rbViewMonthly = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalBookingsType = new System.Windows.Forms.Label();
            this.lblTotalBookingsVal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalRevenueType = new System.Windows.Forms.Label();
            this.lblTotalRevenueVal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalPassengersType = new System.Windows.Forms.Label();
            this.lblTotalPassengersVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalFlightsType = new System.Windows.Forms.Label();
            this.lblTotalFlightsVal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.lblAvgBookingVal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAvgPaxFlightVal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMostPopularRouteVal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblTopSeatClassType = new System.Windows.Forms.Label();
            this.lblTopSeatClassVal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 24);
            this.label1.MinimumSize = new System.Drawing.Size(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "View by:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbViewDaily
            // 
            this.rbViewDaily.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbViewDaily.AutoSize = true;
            this.rbViewDaily.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.rbViewDaily.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbViewDaily.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbViewDaily.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.rbViewDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbViewDaily.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbViewDaily.ForeColor = System.Drawing.Color.White;
            this.rbViewDaily.Location = new System.Drawing.Point(0, 0);
            this.rbViewDaily.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbViewDaily.Name = "rbViewDaily";
            this.rbViewDaily.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.rbViewDaily.Size = new System.Drawing.Size(62, 27);
            this.rbViewDaily.TabIndex = 7;
            this.rbViewDaily.TabStop = true;
            this.rbViewDaily.Text = "Daily";
            this.rbViewDaily.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbViewDaily.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.rbViewAnnually);
            this.panel1.Controls.Add(this.rbViewMonthly);
            this.panel1.Controls.Add(this.rbViewDaily);
            this.panel1.Location = new System.Drawing.Point(66, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 27);
            this.panel1.TabIndex = 8;
            // 
            // rbViewAnnually
            // 
            this.rbViewAnnually.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbViewAnnually.AutoSize = true;
            this.rbViewAnnually.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.rbViewAnnually.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbViewAnnually.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbViewAnnually.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.rbViewAnnually.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbViewAnnually.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbViewAnnually.ForeColor = System.Drawing.Color.White;
            this.rbViewAnnually.Location = new System.Drawing.Point(157, 0);
            this.rbViewAnnually.Margin = new System.Windows.Forms.Padding(0);
            this.rbViewAnnually.Name = "rbViewAnnually";
            this.rbViewAnnually.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.rbViewAnnually.Size = new System.Drawing.Size(82, 27);
            this.rbViewAnnually.TabIndex = 9;
            this.rbViewAnnually.TabStop = true;
            this.rbViewAnnually.Text = "Annually";
            this.rbViewAnnually.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbViewAnnually.UseVisualStyleBackColor = false;
            // 
            // rbViewMonthly
            // 
            this.rbViewMonthly.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbViewMonthly.AutoSize = true;
            this.rbViewMonthly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.rbViewMonthly.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbViewMonthly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbViewMonthly.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.rbViewMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbViewMonthly.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbViewMonthly.ForeColor = System.Drawing.Color.White;
            this.rbViewMonthly.Location = new System.Drawing.Point(69, 0);
            this.rbViewMonthly.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbViewMonthly.Name = "rbViewMonthly";
            this.rbViewMonthly.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.rbViewMonthly.Size = new System.Drawing.Size(81, 27);
            this.rbViewMonthly.TabIndex = 8;
            this.rbViewMonthly.TabStop = true;
            this.rbViewMonthly.Text = "Monthly";
            this.rbViewMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbViewMonthly.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTotalBookingsType);
            this.panel2.Controls.Add(this.lblTotalBookingsVal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(180, 99);
            this.panel2.TabIndex = 9;
            // 
            // lblTotalBookingsType
            // 
            this.lblTotalBookingsType.AutoSize = true;
            this.lblTotalBookingsType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBookingsType.ForeColor = System.Drawing.Color.Black;
            this.lblTotalBookingsType.Location = new System.Drawing.Point(8, 62);
            this.lblTotalBookingsType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalBookingsType.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalBookingsType.Name = "lblTotalBookingsType";
            this.lblTotalBookingsType.Size = new System.Drawing.Size(38, 27);
            this.lblTotalBookingsType.TabIndex = 12;
            this.lblTotalBookingsType.Text = "Today";
            this.lblTotalBookingsType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalBookingsVal
            // 
            this.lblTotalBookingsVal.AutoSize = true;
            this.lblTotalBookingsVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBookingsVal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalBookingsVal.Location = new System.Drawing.Point(8, 35);
            this.lblTotalBookingsVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalBookingsVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalBookingsVal.Name = "lblTotalBookingsVal";
            this.lblTotalBookingsVal.Size = new System.Drawing.Size(53, 27);
            this.lblTotalBookingsVal.TabIndex = 11;
            this.lblTotalBookingsVal.Text = "1234";
            this.lblTotalBookingsVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.MinimumSize = new System.Drawing.Size(0, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "TOTAL BOOKINGS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblTotalRevenueType);
            this.panel3.Controls.Add(this.lblTotalRevenueVal);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(196, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8);
            this.panel3.Size = new System.Drawing.Size(180, 99);
            this.panel3.TabIndex = 13;
            // 
            // lblTotalRevenueType
            // 
            this.lblTotalRevenueType.AutoSize = true;
            this.lblTotalRevenueType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenueType.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRevenueType.Location = new System.Drawing.Point(8, 62);
            this.lblTotalRevenueType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalRevenueType.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalRevenueType.Name = "lblTotalRevenueType";
            this.lblTotalRevenueType.Size = new System.Drawing.Size(38, 27);
            this.lblTotalRevenueType.TabIndex = 12;
            this.lblTotalRevenueType.Text = "Today";
            this.lblTotalRevenueType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRevenueVal
            // 
            this.lblTotalRevenueVal.AutoSize = true;
            this.lblTotalRevenueVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenueVal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRevenueVal.Location = new System.Drawing.Point(8, 35);
            this.lblTotalRevenueVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalRevenueVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalRevenueVal.Name = "lblTotalRevenueVal";
            this.lblTotalRevenueVal.Size = new System.Drawing.Size(53, 27);
            this.lblTotalRevenueVal.TabIndex = 11;
            this.lblTotalRevenueVal.Text = "1234";
            this.lblTotalRevenueVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.MinimumSize = new System.Drawing.Size(0, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "TOTAL REVENUE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblTotalPassengersType);
            this.panel4.Controls.Add(this.lblTotalPassengersVal);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(392, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8);
            this.panel4.Size = new System.Drawing.Size(180, 99);
            this.panel4.TabIndex = 14;
            // 
            // lblTotalPassengersType
            // 
            this.lblTotalPassengersType.AutoSize = true;
            this.lblTotalPassengersType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPassengersType.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPassengersType.Location = new System.Drawing.Point(8, 62);
            this.lblTotalPassengersType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalPassengersType.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalPassengersType.Name = "lblTotalPassengersType";
            this.lblTotalPassengersType.Size = new System.Drawing.Size(38, 27);
            this.lblTotalPassengersType.TabIndex = 12;
            this.lblTotalPassengersType.Text = "Today";
            this.lblTotalPassengersType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalPassengersVal
            // 
            this.lblTotalPassengersVal.AutoSize = true;
            this.lblTotalPassengersVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPassengersVal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPassengersVal.Location = new System.Drawing.Point(8, 35);
            this.lblTotalPassengersVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalPassengersVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalPassengersVal.Name = "lblTotalPassengersVal";
            this.lblTotalPassengersVal.Size = new System.Drawing.Size(53, 27);
            this.lblTotalPassengersVal.TabIndex = 11;
            this.lblTotalPassengersVal.Text = "1234";
            this.lblTotalPassengersVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.MinimumSize = new System.Drawing.Size(0, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "TOTAL PASSENGERS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblTotalFlightsType);
            this.panel5.Controls.Add(this.lblTotalFlightsVal);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(588, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(8);
            this.panel5.Size = new System.Drawing.Size(180, 99);
            this.panel5.TabIndex = 15;
            // 
            // lblTotalFlightsType
            // 
            this.lblTotalFlightsType.AutoSize = true;
            this.lblTotalFlightsType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFlightsType.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFlightsType.Location = new System.Drawing.Point(8, 62);
            this.lblTotalFlightsType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalFlightsType.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalFlightsType.Name = "lblTotalFlightsType";
            this.lblTotalFlightsType.Size = new System.Drawing.Size(38, 27);
            this.lblTotalFlightsType.TabIndex = 12;
            this.lblTotalFlightsType.Text = "Today";
            this.lblTotalFlightsType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalFlightsVal
            // 
            this.lblTotalFlightsVal.AutoSize = true;
            this.lblTotalFlightsVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFlightsVal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFlightsVal.Location = new System.Drawing.Point(8, 35);
            this.lblTotalFlightsVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalFlightsVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTotalFlightsVal.Name = "lblTotalFlightsVal";
            this.lblTotalFlightsVal.Size = new System.Drawing.Size(53, 27);
            this.lblTotalFlightsVal.TabIndex = 11;
            this.lblTotalFlightsVal.Text = "1234";
            this.lblTotalFlightsVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.MinimumSize = new System.Drawing.Size(0, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 27);
            this.label7.TabIndex = 10;
            this.label7.Text = "TOTAL FLIGHTS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.lblAvgBookingVal);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(784, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(8);
            this.panel6.Size = new System.Drawing.Size(180, 99);
            this.panel6.TabIndex = 16;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(8, 62);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.MinimumSize = new System.Drawing.Size(0, 27);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 27);
            this.label22.TabIndex = 12;
            this.label22.Text = "Per booking";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgBookingVal
            // 
            this.lblAvgBookingVal.AutoSize = true;
            this.lblAvgBookingVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgBookingVal.ForeColor = System.Drawing.Color.Black;
            this.lblAvgBookingVal.Location = new System.Drawing.Point(8, 35);
            this.lblAvgBookingVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblAvgBookingVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblAvgBookingVal.Name = "lblAvgBookingVal";
            this.lblAvgBookingVal.Size = new System.Drawing.Size(53, 27);
            this.lblAvgBookingVal.TabIndex = 11;
            this.lblAvgBookingVal.Text = "1234";
            this.lblAvgBookingVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.MinimumSize = new System.Drawing.Size(0, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 27);
            this.label8.TabIndex = 10;
            this.label8.Text = "AVG BOOKING VALUE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.lblAvgPaxFlightVal);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(980, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(8);
            this.panel7.Size = new System.Drawing.Size(180, 99);
            this.panel7.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.MinimumSize = new System.Drawing.Size(0, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Per flight";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgPaxFlightVal
            // 
            this.lblAvgPaxFlightVal.AutoSize = true;
            this.lblAvgPaxFlightVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPaxFlightVal.ForeColor = System.Drawing.Color.Black;
            this.lblAvgPaxFlightVal.Location = new System.Drawing.Point(8, 35);
            this.lblAvgPaxFlightVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblAvgPaxFlightVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblAvgPaxFlightVal.Name = "lblAvgPaxFlightVal";
            this.lblAvgPaxFlightVal.Size = new System.Drawing.Size(53, 27);
            this.lblAvgPaxFlightVal.TabIndex = 11;
            this.lblAvgPaxFlightVal.Text = "1234";
            this.lblAvgPaxFlightVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.MinimumSize = new System.Drawing.Size(0, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 27);
            this.label9.TabIndex = 10;
            this.label9.Text = "AVG PAX / FLIGHT";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.lblMostPopularRouteVal);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0, 0, 16, 16);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(8);
            this.panel8.Size = new System.Drawing.Size(180, 99);
            this.panel8.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.MinimumSize = new System.Drawing.Size(0, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "By booking";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMostPopularRouteVal
            // 
            this.lblMostPopularRouteVal.AutoSize = true;
            this.lblMostPopularRouteVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostPopularRouteVal.ForeColor = System.Drawing.Color.Black;
            this.lblMostPopularRouteVal.Location = new System.Drawing.Point(8, 35);
            this.lblMostPopularRouteVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblMostPopularRouteVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblMostPopularRouteVal.Name = "lblMostPopularRouteVal";
            this.lblMostPopularRouteVal.Size = new System.Drawing.Size(110, 27);
            this.lblMostPopularRouteVal.TabIndex = 11;
            this.lblMostPopularRouteVal.Text = "MNL > CEB";
            this.lblMostPopularRouteVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label11.Location = new System.Drawing.Point(8, 8);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.MinimumSize = new System.Drawing.Size(0, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 27);
            this.label11.TabIndex = 10;
            this.label11.Text = "MOST POPULAR ROUTE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblTopSeatClassType);
            this.panel9.Controls.Add(this.lblTopSeatClassVal);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Location = new System.Drawing.Point(0, 115);
            this.panel9.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(8);
            this.panel9.Size = new System.Drawing.Size(180, 99);
            this.panel9.TabIndex = 19;
            // 
            // lblTopSeatClassType
            // 
            this.lblTopSeatClassType.AutoSize = true;
            this.lblTopSeatClassType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopSeatClassType.ForeColor = System.Drawing.Color.Black;
            this.lblTopSeatClassType.Location = new System.Drawing.Point(8, 65);
            this.lblTopSeatClassType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTopSeatClassType.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTopSeatClassType.Name = "lblTopSeatClassType";
            this.lblTopSeatClassType.Size = new System.Drawing.Size(92, 27);
            this.lblTopSeatClassType.TabIndex = 12;
            this.lblTopSeatClassType.Text = "100% of booking";
            this.lblTopSeatClassType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopSeatClassVal
            // 
            this.lblTopSeatClassVal.AutoSize = true;
            this.lblTopSeatClassVal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopSeatClassVal.ForeColor = System.Drawing.Color.Black;
            this.lblTopSeatClassVal.Location = new System.Drawing.Point(8, 35);
            this.lblTopSeatClassVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTopSeatClassVal.MinimumSize = new System.Drawing.Size(0, 27);
            this.lblTopSeatClassVal.Name = "lblTopSeatClassVal";
            this.lblTopSeatClassVal.Size = new System.Drawing.Size(84, 27);
            this.lblTopSeatClassVal.TabIndex = 11;
            this.lblTopSeatClassVal.Text = "Business";
            this.lblTopSeatClassVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label13.Location = new System.Drawing.Point(8, 8);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.MinimumSize = new System.Drawing.Size(0, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 27);
            this.label13.TabIndex = 10;
            this.label13.Text = "TOP SEAT CLASS";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel10.Controls.Add(this.panel2);
            this.panel10.Controls.Add(this.panel3);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Controls.Add(this.panel7);
            this.panel10.Controls.Add(this.panel5);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1160, 99);
            this.panel10.TabIndex = 21;
            // 
            // panel11
            // 
            this.panel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel11.Controls.Add(this.pnlRevenue);
            this.panel11.Controls.Add(this.panel8);
            this.panel11.Controls.Add(this.panel9);
            this.panel11.Location = new System.Drawing.Point(0, 115);
            this.panel11.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(922, 228);
            this.panel11.TabIndex = 22;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Controls.Add(this.panel11);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1160, 359);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.AutoSize = true;
            this.pnlRevenue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRevenue.Location = new System.Drawing.Point(199, 9);
            this.pnlRevenue.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(0, 0);
            this.pnlRevenue.TabIndex = 20;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Statistics";
            this.Size = new System.Drawing.Size(1200, 544);
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.ParentChanged += new System.EventHandler(this.Statistics_ParentChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbViewDaily;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbViewAnnually;
        private System.Windows.Forms.RadioButton rbViewMonthly;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalBookingsVal;
        private System.Windows.Forms.Label lblTotalBookingsType;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalRevenueType;
        private System.Windows.Forms.Label lblTotalRevenueVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalPassengersType;
        private System.Windows.Forms.Label lblTotalPassengersVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalFlightsType;
        private System.Windows.Forms.Label lblTotalFlightsVal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblAvgBookingVal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAvgPaxFlightVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMostPopularRouteVal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblTopSeatClassType;
        private System.Windows.Forms.Label lblTopSeatClassVal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlRevenue;
    }
}
