namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    partial class RAFlightCards
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.lblDepTime = new System.Windows.Forms.Label();
            this.lblDepCode = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblArrTime = new System.Windows.Forms.Label();
            this.lblArrCode = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblStops = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.pnlRight);
            this.pnlCard.Controls.Add(this.pnlMiddle);
            this.pnlCard.Controls.Add(this.pnlLeft);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(1262, 145);
            this.pnlCard.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblPrice);
            this.pnlRight.Controls.Add(this.btnSelect);
            this.pnlRight.Controls.Add(this.btnViewDetail);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1082, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(12, 12, 16, 12);
            this.pnlRight.Size = new System.Drawing.Size(180, 145);
            this.pnlRight.TabIndex = 0;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblPrice.Location = new System.Drawing.Point(12, 12);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(96, 25);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Flight Fee";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(10, 58);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(148, 38);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select  >";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.White;
            this.btnViewDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.btnViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.btnViewDetail.Location = new System.Drawing.Point(10, 102);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(148, 32);
            this.btnViewDetail.TabIndex = 3;
            this.btnViewDetail.Text = "Flight Detail";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.White;
            this.pnlMiddle.Controls.Add(this.lblDepTime);
            this.pnlMiddle.Controls.Add(this.lblDepCode);
            this.pnlMiddle.Controls.Add(this.lblLine);
            this.pnlMiddle.Controls.Add(this.lblArrTime);
            this.pnlMiddle.Controls.Add(this.lblArrCode);
            this.pnlMiddle.Controls.Add(this.lblDate);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(160, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlMiddle.Size = new System.Drawing.Size(1102, 145);
            this.pnlMiddle.TabIndex = 1;
            // 
            // lblDepTime
            // 
            this.lblDepTime.AutoSize = true;
            this.lblDepTime.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblDepTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblDepTime.Location = new System.Drawing.Point(16, 14);
            this.lblDepTime.Name = "lblDepTime";
            this.lblDepTime.Size = new System.Drawing.Size(53, 25);
            this.lblDepTime.TabIndex = 0;
            this.lblDepTime.Text = "Time";
            // 
            // lblDepCode
            // 
            this.lblDepCode.AutoSize = true;
            this.lblDepCode.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDepCode.ForeColor = System.Drawing.Color.Gray;
            this.lblDepCode.Location = new System.Drawing.Point(20, 40);
            this.lblDepCode.Name = "lblDepCode";
            this.lblDepCode.Size = new System.Drawing.Size(67, 15);
            this.lblDepCode.TabIndex = 1;
            this.lblDepCode.Text = "Destination";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblLine.Location = new System.Drawing.Point(100, 24);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(139, 13);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "————————————";
            // 
            // lblArrTime
            // 
            this.lblArrTime.AutoSize = true;
            this.lblArrTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblArrTime.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblArrTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.lblArrTime.Location = new System.Drawing.Point(310, 14);
            this.lblArrTime.Name = "lblArrTime";
            this.lblArrTime.Size = new System.Drawing.Size(53, 25);
            this.lblArrTime.TabIndex = 3;
            this.lblArrTime.Text = "Time";
            // 
            // lblArrCode
            // 
            this.lblArrCode.AutoSize = true;
            this.lblArrCode.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblArrCode.ForeColor = System.Drawing.Color.Gray;
            this.lblArrCode.Location = new System.Drawing.Point(314, 40);
            this.lblArrCode.Name = "lblArrCode";
            this.lblArrCode.Size = new System.Drawing.Size(113, 15);
            this.lblArrCode.TabIndex = 4;
            this.lblArrCode.Text = "Landing Destination";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(160)))), ((int)(((byte)(70)))));
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(20, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblDate.Size = new System.Drawing.Size(44, 19);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.lblStops);
            this.pnlLeft.Controls.Add(this.lblDuration);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(16, 16, 8, 16);
            this.pnlLeft.Size = new System.Drawing.Size(160, 145);
            this.pnlLeft.TabIndex = 2;
            // 
            // lblStops
            // 
            this.lblStops.AutoSize = true;
            this.lblStops.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStops.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblStops.Location = new System.Drawing.Point(16, 20);
            this.lblStops.Name = "lblStops";
            this.lblStops.Size = new System.Drawing.Size(91, 19);
            this.lblStops.TabIndex = 0;
            this.lblStops.Text = "Airline Name";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDuration.ForeColor = System.Drawing.Color.Gray;
            this.lblDuration.Location = new System.Drawing.Point(16, 42);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(69, 15);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "Hrs in flight";
            // 
            // RAFlightCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlCard);
            this.Name = "RAFlightCards";
            this.Size = new System.Drawing.Size(1262, 145);
            this.Load += new System.EventHandler(this.RAFlightCards_Load);
            this.pnlCard.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlCard, pnlLeft, pnlMiddle, pnlRight;
        private System.Windows.Forms.Label lblStops, lblDuration;
        private System.Windows.Forms.Label lblDepTime, lblDepCode;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblArrTime, lblArrCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnViewDetail; // NEW
    }
}