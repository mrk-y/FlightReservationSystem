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
            this.btnAssignRoute = new System.Windows.Forms.Button();
            this.btnAssignCrews = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddAircraft
            // 
            this.btnAddAircraft.AutoSize = true;
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
            this.btnAddAircraft.Padding = new System.Windows.Forms.Padding(4);
            this.btnAddAircraft.Size = new System.Drawing.Size(89, 33);
            this.btnAddAircraft.TabIndex = 0;
            this.btnAddAircraft.Tag = "";
            this.btnAddAircraft.Text = "Add Aircraft";
            this.btnAddAircraft.UseVisualStyleBackColor = false;
            this.btnAddAircraft.Click += new System.EventHandler(this.btnAddAircraft_Click);
            // 
            // btnAssignRoute
            // 
            this.btnAssignRoute.AutoSize = true;
            this.btnAssignRoute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAssignRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAssignRoute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignRoute.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAssignRoute.FlatAppearance.BorderSize = 0;
            this.btnAssignRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignRoute.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignRoute.ForeColor = System.Drawing.Color.White;
            this.btnAssignRoute.Location = new System.Drawing.Point(199, 0);
            this.btnAssignRoute.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAssignRoute.Name = "btnAssignRoute";
            this.btnAssignRoute.Padding = new System.Windows.Forms.Padding(4);
            this.btnAssignRoute.Size = new System.Drawing.Size(94, 33);
            this.btnAssignRoute.TabIndex = 1;
            this.btnAssignRoute.Tag = "";
            this.btnAssignRoute.Text = "Assign Route";
            this.btnAssignRoute.UseVisualStyleBackColor = false;
            this.btnAssignRoute.Click += new System.EventHandler(this.btnAssignRoute_Click);
            // 
            // btnAssignCrews
            // 
            this.btnAssignCrews.AutoSize = true;
            this.btnAssignCrews.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAssignCrews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAssignCrews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignCrews.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAssignCrews.FlatAppearance.BorderSize = 0;
            this.btnAssignCrews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignCrews.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignCrews.ForeColor = System.Drawing.Color.White;
            this.btnAssignCrews.Location = new System.Drawing.Point(97, 0);
            this.btnAssignCrews.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAssignCrews.Name = "btnAssignCrews";
            this.btnAssignCrews.Padding = new System.Windows.Forms.Padding(4);
            this.btnAssignCrews.Size = new System.Drawing.Size(94, 33);
            this.btnAssignCrews.TabIndex = 2;
            this.btnAssignCrews.Tag = "";
            this.btnAssignCrews.Text = "Assign Crews";
            this.btnAssignCrews.UseVisualStyleBackColor = false;
            this.btnAssignCrews.Click += new System.EventHandler(this.btnAssignCrews_Click);
            // 
            // SANavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAssignCrews);
            this.Controls.Add(this.btnAssignRoute);
            this.Controls.Add(this.btnAddAircraft);
            this.Name = "SANavigation";
            this.Size = new System.Drawing.Size(1281, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAircraft;
        private System.Windows.Forms.Button btnAssignRoute;
        private System.Windows.Forms.Button btnAssignCrews;
    }
}
