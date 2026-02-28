namespace FlightReservationSystem.UserControls
{
    partial class SAHeader
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
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnAircraftInitalization = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(8, 8);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(443, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Flight Reservation System (FRS)";
            // 
            // btnAircraftInitalization
            // 
            this.btnAircraftInitalization.AutoSize = true;
            this.btnAircraftInitalization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAircraftInitalization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAircraftInitalization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAircraftInitalization.Location = new System.Drawing.Point(0, 48);
            this.btnAircraftInitalization.Name = "btnAircraftInitalization";
            this.btnAircraftInitalization.Size = new System.Drawing.Size(159, 32);
            this.btnAircraftInitalization.TabIndex = 1;
            this.btnAircraftInitalization.Text = "Aircraft Initialization";
            this.btnAircraftInitalization.UseVisualStyleBackColor = true;
            this.btnAircraftInitalization.Click += new System.EventHandler(this.btnAircraftInitalization_Click);
            // 
            // SAHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAircraftInitalization);
            this.Controls.Add(this.lblHeaderTitle);
            this.Name = "SAHeader";
            this.Size = new System.Drawing.Size(1580, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnAircraftInitalization;
    }
}
