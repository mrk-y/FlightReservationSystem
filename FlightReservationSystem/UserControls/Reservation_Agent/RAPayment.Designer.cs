namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    partial class RAPayment
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
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblPaymentSubtitle = new System.Windows.Forms.Label();
            this.pnlCashOption = new System.Windows.Forms.Panel();
            this.lblCashIcon = new System.Windows.Forms.Label();
            this.lblCashTitle = new System.Windows.Forms.Label();
            this.lblCashDesc = new System.Windows.Forms.Label();
            this.lblCashInstruction = new System.Windows.Forms.Label();
            this.lblRefLabel = new System.Windows.Forms.Label();
            this.txtRefNumber = new System.Windows.Forms.TextBox();
            this.lblAmountLabel = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.chkConfirm = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.lblFlightLabel = new System.Windows.Forms.Label();
            this.lblFlightValue = new System.Windows.Forms.Label();
            this.lblRouteLabel = new System.Windows.Forms.Label();
            this.lblRouteValue = new System.Windows.Forms.Label();
            this.lblDateLabel = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblPassengersLabel = new System.Windows.Forms.Label();
            this.lblPassengersValue = new System.Windows.Forms.Label();
            this.lblClassLabel = new System.Windows.Forms.Label();
            this.lblClassValue = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblBaseFareLabel = new System.Windows.Forms.Label();
            this.lblBaseFareValue = new System.Windows.Forms.Label();
            this.lblTaxLabel = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblFeesLabel = new System.Windows.Forms.Label();
            this.lblFeesValue = new System.Windows.Forms.Label();
            this.pnlTotalDivider = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblEconomyCount = new System.Windows.Forms.Label();
            this.lblComfortCount = new System.Windows.Forms.Label();
            this.lblBusinessCount = new System.Windows.Forms.Label();
            this.lblSeatSummary = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.pnlCashOption.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.pnlMain.Controls.Add(this.pnlPayment);
            this.pnlMain.Controls.Add(this.pnlSummary);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlMain.Size = new System.Drawing.Size(1200, 544);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.Color.White;
            this.pnlPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPayment.Controls.Add(this.lblPaymentTitle);
            this.pnlPayment.Controls.Add(this.lblPaymentSubtitle);
            this.pnlPayment.Controls.Add(this.pnlCashOption);
            this.pnlPayment.Controls.Add(this.lblAmountLabel);
            this.pnlPayment.Controls.Add(this.lblAmountValue);
            this.pnlPayment.Controls.Add(this.chkConfirm);
            this.pnlPayment.Controls.Add(this.btnBack);
            this.pnlPayment.Controls.Add(this.btnPrintReceipt);
            this.pnlPayment.Controls.Add(this.btnConfirmPayment);
            this.pnlPayment.Location = new System.Drawing.Point(504, 20);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(668, 504);
            this.pnlPayment.TabIndex = 0;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblPaymentTitle.Location = new System.Drawing.Point(20, 18);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(136, 21);
            this.lblPaymentTitle.TabIndex = 0;
            this.lblPaymentTitle.Text = "Payment Method";
            // 
            // lblPaymentSubtitle
            // 
            this.lblPaymentSubtitle.AutoSize = true;
            this.lblPaymentSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPaymentSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPaymentSubtitle.Location = new System.Drawing.Point(22, 42);
            this.lblPaymentSubtitle.Name = "lblPaymentSubtitle";
            this.lblPaymentSubtitle.Size = new System.Drawing.Size(311, 15);
            this.lblPaymentSubtitle.TabIndex = 1;
            this.lblPaymentSubtitle.Text = "Please proceed to the counter to complete your payment.";
            // 
            // pnlCashOption
            // 
            this.pnlCashOption.BackColor = System.Drawing.Color.FromArgb(245, 250, 245);
            this.pnlCashOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCashOption.Controls.Add(this.lblCashIcon);
            this.pnlCashOption.Controls.Add(this.lblCashTitle);
            this.pnlCashOption.Controls.Add(this.lblCashDesc);
            this.pnlCashOption.Controls.Add(this.lblCashInstruction);
            this.pnlCashOption.Controls.Add(this.lblRefLabel);
            this.pnlCashOption.Controls.Add(this.txtRefNumber);
            this.pnlCashOption.Location = new System.Drawing.Point(20, 72);
            this.pnlCashOption.Name = "pnlCashOption";
            this.pnlCashOption.Size = new System.Drawing.Size(624, 220);
            this.pnlCashOption.TabIndex = 2;
            // 
            // lblCashIcon
            // 
            this.lblCashIcon.AutoSize = true;
            this.lblCashIcon.Font = new System.Drawing.Font("Segoe UI", 28F);
            this.lblCashIcon.Location = new System.Drawing.Point(20, 20);
            this.lblCashIcon.Name = "lblCashIcon";
            this.lblCashIcon.Size = new System.Drawing.Size(74, 51);
            this.lblCashIcon.TabIndex = 0;
            this.lblCashIcon.Text = "💵";
            // 
            // lblCashTitle
            // 
            this.lblCashTitle.AutoSize = true;
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblCashTitle.Location = new System.Drawing.Point(96, 26);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(150, 25);
            this.lblCashTitle.TabIndex = 1;
            this.lblCashTitle.Text = "Cash on Counter";
            // 
            // lblCashDesc
            // 
            this.lblCashDesc.AutoSize = true;
            this.lblCashDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCashDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblCashDesc.Location = new System.Drawing.Point(96, 52);
            this.lblCashDesc.Name = "lblCashDesc";
            this.lblCashDesc.Size = new System.Drawing.Size(318, 15);
            this.lblCashDesc.TabIndex = 2;
            this.lblCashDesc.Text = "Pay in full at the reservation counter before your departure.";
            // 
            // lblCashInstruction
            // 
            this.lblCashInstruction.AutoSize = true;
            this.lblCashInstruction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCashInstruction.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblCashInstruction.Location = new System.Drawing.Point(20, 100);
            this.lblCashInstruction.Name = "lblCashInstruction";
            this.lblCashInstruction.Size = new System.Drawing.Size(263, 30);
            this.lblCashInstruction.TabIndex = 3;
            this.lblCashInstruction.Text = "A reference number will be generated below.\r\nPresent this to the counter agent upon payment.";
            // 
            // lblRefLabel
            // 
            this.lblRefLabel.AutoSize = true;
            this.lblRefLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblRefLabel.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblRefLabel.Location = new System.Drawing.Point(20, 148);
            this.lblRefLabel.Name = "lblRefLabel";
            this.lblRefLabel.Size = new System.Drawing.Size(106, 15);
            this.lblRefLabel.TabIndex = 4;
            this.lblRefLabel.Text = "Reference Number";
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.txtRefNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.txtRefNumber.ForeColor = System.Drawing.Color.FromArgb(220, 80, 0);
            this.txtRefNumber.Location = new System.Drawing.Point(20, 166);
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.ReadOnly = true;
            this.txtRefNumber.Size = new System.Drawing.Size(300, 27);
            this.txtRefNumber.TabIndex = 5;
            // 
            // lblAmountLabel
            // 
            this.lblAmountLabel.AutoSize = true;
            this.lblAmountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblAmountLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblAmountLabel.Location = new System.Drawing.Point(20, 308);
            this.lblAmountLabel.Name = "lblAmountLabel";
            this.lblAmountLabel.Size = new System.Drawing.Size(145, 15);
            this.lblAmountLabel.TabIndex = 3;
            this.lblAmountLabel.Text = "Amount to Pay at Counter";
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.AutoSize = true;
            this.lblAmountValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblAmountValue.ForeColor = System.Drawing.Color.FromArgb(220, 80, 0);
            this.lblAmountValue.Location = new System.Drawing.Point(18, 326);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(155, 32);
            this.lblAmountValue.TabIndex = 4;
            this.lblAmountValue.Text = "PHP 1,430.00";
            // 
            // chkConfirm
            // 
            this.chkConfirm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkConfirm.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.chkConfirm.Location = new System.Drawing.Point(20, 378);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Size = new System.Drawing.Size(620, 36);
            this.chkConfirm.TabIndex = 5;
            this.chkConfirm.Text = "I understand that my booking is pending until payment is made at the counter.";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 0);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(220, 80, 0);
            this.btnBack.Location = new System.Drawing.Point(20, 450);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 40);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // btnPrintReceipt  ── NEW
            //
            this.btnPrintReceipt.BackColor = System.Drawing.Color.White;
            this.btnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintReceipt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.btnPrintReceipt.Location = new System.Drawing.Point(156, 450);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(150, 40);
            this.btnPrintReceipt.TabIndex = 8;
            this.btnPrintReceipt.Text = "🖨  Print Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BackColor = System.Drawing.Color.FromArgb(220, 80, 0);
            this.btnConfirmPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPayment.FlatAppearance.BorderSize = 0;
            this.btnConfirmPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.Location = new System.Drawing.Point(494, 450);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(160, 40);
            this.btnConfirmPayment.TabIndex = 7;
            this.btnConfirmPayment.Text = "Confirm Booking  >";
            this.btnConfirmPayment.UseVisualStyleBackColor = false;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.lblFlightLabel);
            this.pnlSummary.Controls.Add(this.lblFlightValue);
            this.pnlSummary.Controls.Add(this.lblRouteLabel);
            this.pnlSummary.Controls.Add(this.lblRouteValue);
            this.pnlSummary.Controls.Add(this.lblDateLabel);
            this.pnlSummary.Controls.Add(this.lblDateValue);
            this.pnlSummary.Controls.Add(this.lblPassengersLabel);
            this.pnlSummary.Controls.Add(this.lblPassengersValue);
            this.pnlSummary.Controls.Add(this.lblClassLabel);
            this.pnlSummary.Controls.Add(this.lblClassValue);
            this.pnlSummary.Controls.Add(this.pnlDivider);
            this.pnlSummary.Controls.Add(this.lblBaseFareLabel);
            this.pnlSummary.Controls.Add(this.lblBaseFareValue);
            this.pnlSummary.Controls.Add(this.lblTaxLabel);
            this.pnlSummary.Controls.Add(this.lblTaxValue);
            this.pnlSummary.Controls.Add(this.lblFeesLabel);
            this.pnlSummary.Controls.Add(this.lblFeesValue);
            this.pnlSummary.Controls.Add(this.pnlTotalDivider);
            this.pnlSummary.Controls.Add(this.lblTotalLabel);
            this.pnlSummary.Controls.Add(this.lblTotalValue);
            this.pnlSummary.Controls.Add(this.lblEconomyCount);
            this.pnlSummary.Controls.Add(this.lblComfortCount);
            this.pnlSummary.Controls.Add(this.lblBusinessCount);
            this.pnlSummary.Controls.Add(this.lblSeatSummary);
            this.pnlSummary.Location = new System.Drawing.Point(24, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(460, 504);
            this.pnlSummary.TabIndex = 1;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 18);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(126, 21);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Order Summary";
            // 
            // lblFlightLabel
            // 
            this.lblFlightLabel.AutoSize = true;
            this.lblFlightLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFlightLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblFlightLabel.Location = new System.Drawing.Point(20, 58);
            this.lblFlightLabel.Name = "lblFlightLabel";
            this.lblFlightLabel.Size = new System.Drawing.Size(37, 15);
            this.lblFlightLabel.TabIndex = 1;
            this.lblFlightLabel.Text = "Flight";
            // 
            // lblFlightValue
            // 
            this.lblFlightValue.AutoSize = true;
            this.lblFlightValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblFlightValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblFlightValue.Location = new System.Drawing.Point(280, 58);
            this.lblFlightValue.Name = "lblFlightValue";
            this.lblFlightValue.Size = new System.Drawing.Size(72, 15);
            this.lblFlightValue.TabIndex = 2;
            this.lblFlightValue.Text = "Flight Name";
            // 
            // lblRouteLabel
            // 
            this.lblRouteLabel.AutoSize = true;
            this.lblRouteLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRouteLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblRouteLabel.Location = new System.Drawing.Point(20, 82);
            this.lblRouteLabel.Name = "lblRouteLabel";
            this.lblRouteLabel.Size = new System.Drawing.Size(38, 15);
            this.lblRouteLabel.TabIndex = 3;
            this.lblRouteLabel.Text = "Route";
            // 
            // lblRouteValue
            // 
            this.lblRouteValue.AutoSize = true;
            this.lblRouteValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblRouteValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblRouteValue.Location = new System.Drawing.Point(280, 82);
            this.lblRouteValue.Name = "lblRouteValue";
            this.lblRouteValue.Size = new System.Drawing.Size(118, 15);
            this.lblRouteValue.TabIndex = 4;
            this.lblRouteValue.Text = "Destination → Arrival";
            // 
            // lblDateLabel
            // 
            this.lblDateLabel.AutoSize = true;
            this.lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDateLabel.Location = new System.Drawing.Point(20, 106);
            this.lblDateLabel.Name = "lblDateLabel";
            this.lblDateLabel.Size = new System.Drawing.Size(31, 15);
            this.lblDateLabel.TabIndex = 5;
            this.lblDateLabel.Text = "Date";
            // 
            // lblDateValue
            // 
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDateValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblDateValue.Location = new System.Drawing.Point(280, 106);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(79, 15);
            this.lblDateValue.TabIndex = 6;
            this.lblDateValue.Text = "Date of Flight";
            // 
            // lblPassengersLabel
            // 
            this.lblPassengersLabel.AutoSize = true;
            this.lblPassengersLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassengersLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblPassengersLabel.Location = new System.Drawing.Point(20, 130);
            this.lblPassengersLabel.Name = "lblPassengersLabel";
            this.lblPassengersLabel.Size = new System.Drawing.Size(65, 15);
            this.lblPassengersLabel.TabIndex = 7;
            this.lblPassengersLabel.Text = "Passengers";
            // 
            // lblPassengersValue
            // 
            this.lblPassengersValue.AutoSize = true;
            this.lblPassengersValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblPassengersValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblPassengersValue.Location = new System.Drawing.Point(280, 130);
            this.lblPassengersValue.Name = "lblPassengersValue";
            this.lblPassengersValue.Size = new System.Drawing.Size(121, 15);
            this.lblPassengersValue.TabIndex = 8;
            this.lblPassengersValue.Text = "How many Passenger";
            // 
            // lblClassLabel
            // 
            this.lblClassLabel.AutoSize = true;
            this.lblClassLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClassLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblClassLabel.Location = new System.Drawing.Point(20, 154);
            this.lblClassLabel.Name = "lblClassLabel";
            this.lblClassLabel.Size = new System.Drawing.Size(34, 15);
            this.lblClassLabel.TabIndex = 9;
            this.lblClassLabel.Text = "Class";
            // 
            // lblClassValue
            // 
            this.lblClassValue.AutoSize = true;
            this.lblClassValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblClassValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblClassValue.Location = new System.Drawing.Point(280, 154);
            this.lblClassValue.Name = "lblClassValue";
            this.lblClassValue.Size = new System.Drawing.Size(129, 15);
            this.lblClassValue.TabIndex = 10;
            this.lblClassValue.Text = "What kind of Economy";
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.pnlDivider.Location = new System.Drawing.Point(20, 182);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(418, 1);
            this.pnlDivider.TabIndex = 11;
            // 
            // lblBaseFareLabel
            // 
            this.lblBaseFareLabel.AutoSize = true;
            this.lblBaseFareLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBaseFareLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblBaseFareLabel.Location = new System.Drawing.Point(20, 198);
            this.lblBaseFareLabel.Name = "lblBaseFareLabel";
            this.lblBaseFareLabel.Size = new System.Drawing.Size(56, 15);
            this.lblBaseFareLabel.TabIndex = 12;
            this.lblBaseFareLabel.Text = "Base Fare";
            // 
            // lblBaseFareValue
            // 
            this.lblBaseFareValue.AutoSize = true;
            this.lblBaseFareValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblBaseFareValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblBaseFareValue.Location = new System.Drawing.Point(280, 198);
            this.lblBaseFareValue.Name = "lblBaseFareValue";
            this.lblBaseFareValue.Size = new System.Drawing.Size(79, 15);
            this.lblBaseFareValue.TabIndex = 13;
            this.lblBaseFareValue.Text = "PHP 1,200.00";
            // 
            // lblTaxLabel
            // 
            this.lblTaxLabel.AutoSize = true;
            this.lblTaxLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTaxLabel.Location = new System.Drawing.Point(20, 222);
            this.lblTaxLabel.Name = "lblTaxLabel";
            this.lblTaxLabel.Size = new System.Drawing.Size(88, 15);
            this.lblTaxLabel.TabIndex = 14;
            this.lblTaxLabel.Text = "Tax & Surcharges";
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.AutoSize = true;
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblTaxValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblTaxValue.Location = new System.Drawing.Point(280, 222);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.Size = new System.Drawing.Size(69, 15);
            this.lblTaxValue.TabIndex = 15;
            this.lblTaxValue.Text = "PHP 180.00";
            // 
            // lblFeesLabel
            // 
            this.lblFeesLabel.AutoSize = true;
            this.lblFeesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFeesLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblFeesLabel.Location = new System.Drawing.Point(20, 246);
            this.lblFeesLabel.Name = "lblFeesLabel";
            this.lblFeesLabel.Size = new System.Drawing.Size(65, 15);
            this.lblFeesLabel.TabIndex = 16;
            this.lblFeesLabel.Text = "Service Fee";
            // 
            // lblFeesValue
            // 
            this.lblFeesValue.AutoSize = true;
            this.lblFeesValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblFeesValue.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblFeesValue.Location = new System.Drawing.Point(280, 246);
            this.lblFeesValue.Name = "lblFeesValue";
            this.lblFeesValue.Size = new System.Drawing.Size(64, 15);
            this.lblFeesValue.TabIndex = 17;
            this.lblFeesValue.Text = "PHP 50.00";
            // 
            // pnlTotalDivider
            // 
            this.pnlTotalDivider.BackColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.pnlTotalDivider.Location = new System.Drawing.Point(20, 274);
            this.pnlTotalDivider.Name = "pnlTotalDivider";
            this.pnlTotalDivider.Size = new System.Drawing.Size(418, 1);
            this.pnlTotalDivider.TabIndex = 18;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblTotalLabel.Location = new System.Drawing.Point(20, 288);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(133, 20);
            this.lblTotalLabel.TabIndex = 19;
            this.lblTotalLabel.Text = "Total Amount Due";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(220, 80, 0);
            this.lblTotalValue.Location = new System.Drawing.Point(240, 286);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(117, 25);
            this.lblTotalValue.TabIndex = 20;
            this.lblTotalValue.Text = "PHP 1,430.00";
            // 
            // lblEconomyCount
            // 
            this.lblEconomyCount.AutoSize = true;
            this.lblEconomyCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEconomyCount.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblEconomyCount.Location = new System.Drawing.Point(20, 326);
            this.lblEconomyCount.Name = "lblEconomyCount";
            this.lblEconomyCount.Size = new System.Drawing.Size(100, 15);
            this.lblEconomyCount.TabIndex = 21;
            this.lblEconomyCount.Text = "Economy:  0 pax";
            // 
            // lblComfortCount
            // 
            this.lblComfortCount.AutoSize = true;
            this.lblComfortCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComfortCount.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblComfortCount.Location = new System.Drawing.Point(20, 346);
            this.lblComfortCount.Name = "lblComfortCount";
            this.lblComfortCount.Size = new System.Drawing.Size(100, 15);
            this.lblComfortCount.TabIndex = 22;
            this.lblComfortCount.Text = "Comfort:  0 pax";
            // 
            // lblBusinessCount
            // 
            this.lblBusinessCount.AutoSize = true;
            this.lblBusinessCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBusinessCount.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblBusinessCount.Location = new System.Drawing.Point(20, 366);
            this.lblBusinessCount.Name = "lblBusinessCount";
            this.lblBusinessCount.Size = new System.Drawing.Size(100, 15);
            this.lblBusinessCount.TabIndex = 23;
            this.lblBusinessCount.Text = "Business: 0 pax";
            // 
            // lblSeatSummary
            // 
            this.lblSeatSummary.AutoSize = false;
            this.lblSeatSummary.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSeatSummary.ForeColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.lblSeatSummary.Location = new System.Drawing.Point(20, 396);
            this.lblSeatSummary.Name = "lblSeatSummary";
            this.lblSeatSummary.Size = new System.Drawing.Size(418, 90);
            this.lblSeatSummary.TabIndex = 24;
            this.lblSeatSummary.Text = "";
            // 
            // RAPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.Controls.Add(this.pnlMain);
            this.Name = "RAPayment";
            this.Size = new System.Drawing.Size(1200, 544);
            this.Load += new System.EventHandler(this.RAPayment_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            this.pnlCashOption.ResumeLayout(false);
            this.pnlCashOption.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
        }

        // ── Fields ────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblFlightLabel, lblFlightValue;
        private System.Windows.Forms.Label lblRouteLabel, lblRouteValue;
        private System.Windows.Forms.Label lblDateLabel, lblDateValue;
        private System.Windows.Forms.Label lblPassengersLabel, lblPassengersValue;
        private System.Windows.Forms.Label lblClassLabel, lblClassValue;
        private System.Windows.Forms.Panel pnlDivider, pnlTotalDivider;
        private System.Windows.Forms.Label lblBaseFareLabel, lblBaseFareValue;
        private System.Windows.Forms.Label lblTaxLabel, lblTaxValue;
        private System.Windows.Forms.Label lblFeesLabel, lblFeesValue;
        private System.Windows.Forms.Label lblTotalLabel, lblTotalValue;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Label lblPaymentTitle, lblPaymentSubtitle;
        private System.Windows.Forms.Panel pnlCashOption;
        private System.Windows.Forms.Label lblCashIcon, lblCashTitle, lblCashDesc, lblCashInstruction;
        private System.Windows.Forms.Label lblRefLabel;
        private System.Windows.Forms.TextBox txtRefNumber;
        private System.Windows.Forms.Label lblAmountLabel, lblAmountValue;
        private System.Windows.Forms.CheckBox chkConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Label lblEconomyCount;
        private System.Windows.Forms.Label lblComfortCount;
        private System.Windows.Forms.Label lblBusinessCount;
        private System.Windows.Forms.Label lblSeatSummary;
    }
}