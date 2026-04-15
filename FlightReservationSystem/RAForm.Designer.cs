namespace FlightReservationSystem
{
    partial class RAForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.pnlFuncs = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlFuncs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1262, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Location = new System.Drawing.Point(1, 59);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(1262, 30);
            this.pnlNavigation.TabIndex = 1;
            // 
            // pnlFuncs
            // 
            this.pnlFuncs.Controls.Add(this.pnlDetails);
            this.pnlFuncs.Location = new System.Drawing.Point(1, 95);
            this.pnlFuncs.Name = "pnlFuncs";
            this.pnlFuncs.Size = new System.Drawing.Size(1262, 585);
            this.pnlFuncs.TabIndex = 2;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Location = new System.Drawing.Point(330, 50);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(600, 483);
            this.pnlDetails.TabIndex = 0;
            // 
            // RAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlFuncs);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlHeader);
            this.Name = "RAForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation Agent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RAForm_FormClosing);
            this.Load += new System.EventHandler(this.RAForm_Load);
            this.pnlFuncs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlFuncs;
        private System.Windows.Forms.Panel pnlDetails;
    }
}