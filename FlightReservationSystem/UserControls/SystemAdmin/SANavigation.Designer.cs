namespace FlightReservationSystem.UserControls.SystemAdmin
{
    partial class SANavigation
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
            this.btnAddAircraft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddAircraft
            // 
            this.btnAddAircraft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddAircraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAddAircraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAircraft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAddAircraft.FlatAppearance.BorderSize = 0;
            this.btnAddAircraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAircraft.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAircraft.ForeColor = System.Drawing.Color.White;
            this.btnAddAircraft.Location = new System.Drawing.Point(0, 0);
            this.btnAddAircraft.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAddAircraft.Name = "btnAddAircraft";
            this.btnAddAircraft.Padding = new System.Windows.Forms.Padding(3);
            this.btnAddAircraft.Size = new System.Drawing.Size(87, 33);
            this.btnAddAircraft.TabIndex = 0;
            this.btnAddAircraft.Tag = "";
            this.btnAddAircraft.Text = "Add Aircraft";
            this.btnAddAircraft.UseVisualStyleBackColor = false;
            // 
            // SANavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAddAircraft);
            this.Name = "SANavigation";
            this.Size = new System.Drawing.Size(1264, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAircraft;
    }
}
