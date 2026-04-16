namespace FlightReservationSystem.UserControls
{
    partial class Header
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.pboLogout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = global::FlightReservationSystem.Properties.Resources.Plane;
            this.picLogo.Location = new System.Drawing.Point(32, 12);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(32, 32);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Location = new System.Drawing.Point(85, 12);
            this.lblSystemName.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(424, 37);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Flight Reservation System (FRS)";
            // 
            // pboLogout
            // 
            this.pboLogout.Image = ((System.Drawing.Image)(resources.GetObject("pboLogout.Image")));
            this.pboLogout.Location = new System.Drawing.Point(1565, -8);
            this.pboLogout.Name = "pboLogout";
            this.pboLogout.Size = new System.Drawing.Size(68, 59);
            this.pboLogout.TabIndex = 2;
            this.pboLogout.TabStop = false;
            this.pboLogout.Visible = false;
            this.pboLogout.Click += new System.EventHandler(this.pboLogout_Click);
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.Controls.Add(this.pboLogout);
            this.Controls.Add(this.lblSystemName);
            this.Controls.Add(this.picLogo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(1685, 62);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.PictureBox pboLogout;
    }
}
