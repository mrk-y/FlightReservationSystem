namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    partial class RASeatPreview
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
            this.pnlSearchBar = new System.Windows.Forms.Panel();
            this.lblAircraft = new System.Windows.Forms.Label();
            this.cmbAircraft = new System.Windows.Forms.ComboBox();
            this.pnlSeatMap = new System.Windows.Forms.Panel();
            this.pnlSearchBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearchBar
            // 
            this.pnlSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.pnlSearchBar.Controls.Add(this.lblAircraft);
            this.pnlSearchBar.Controls.Add(this.cmbAircraft);
            this.pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSearchBar.Name = "pnlSearchBar";
            this.pnlSearchBar.Padding = new System.Windows.Forms.Padding(27, 17, 27, 17);
            this.pnlSearchBar.Size = new System.Drawing.Size(1683, 82);
            this.pnlSearchBar.TabIndex = 2;
            // 
            // lblAircraft
            // 
            this.lblAircraft.AutoSize = true;
            this.lblAircraft.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblAircraft.Location = new System.Drawing.Point(21, 13);
            this.lblAircraft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAircraft.Name = "lblAircraft";
            this.lblAircraft.Size = new System.Drawing.Size(50, 17);
            this.lblAircraft.TabIndex = 9;
            this.lblAircraft.Text = "Aircraft";
            // 
            // cmbAircraft
            // 
            this.cmbAircraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
            this.cmbAircraft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAircraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAircraft.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAircraft.ForeColor = System.Drawing.Color.White;
            this.cmbAircraft.Items.AddRange(new object[] {
            "Economy",
            "Business",
            "First Class"});
            this.cmbAircraft.Location = new System.Drawing.Point(21, 33);
            this.cmbAircraft.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAircraft.Name = "cmbAircraft";
            this.cmbAircraft.Size = new System.Drawing.Size(341, 28);
            this.cmbAircraft.TabIndex = 10;
            // 
            // pnlSeatMap
            // 
            this.pnlSeatMap.Location = new System.Drawing.Point(3, 83);
            this.pnlSeatMap.Name = "pnlSeatMap";
            this.pnlSeatMap.Size = new System.Drawing.Size(1677, 634);
            this.pnlSeatMap.TabIndex = 3;
            // 
            // RASeatPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSeatMap);
            this.Controls.Add(this.pnlSearchBar);
            this.Name = "RASeatPreview";
            this.Size = new System.Drawing.Size(1683, 720);
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlSearchBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.Label lblAircraft;
        private System.Windows.Forms.ComboBox cmbAircraft;
        private System.Windows.Forms.Panel pnlSeatMap;
    }
}
