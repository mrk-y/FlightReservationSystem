namespace FlightReservationSystem.UserControls.SystemAdmin
{
    partial class SAProgress
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
            this.components = new System.ComponentModel.Container();
            this.lblProgress = new System.Windows.Forms.Label();
            this.picQuestion1 = new System.Windows.Forms.PictureBox();
            this.lblSeparator1 = new System.Windows.Forms.Label();
            this.lblProgressVal = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblProgress.Location = new System.Drawing.Point(12, 14);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(55, 15);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Progress";
            // 
            // picQuestion1
            // 
            this.picQuestion1.Image = global::FlightReservationSystem.Properties.Resources.Question;
            this.picQuestion1.Location = new System.Drawing.Point(71, 13);
            this.picQuestion1.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.picQuestion1.Name = "picQuestion1";
            this.picQuestion1.Size = new System.Drawing.Size(16, 16);
            this.picQuestion1.TabIndex = 1;
            this.picQuestion1.TabStop = false;
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.AutoSize = true;
            this.lblSeparator1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator1.Location = new System.Drawing.Point(111, 14);
            this.lblSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator1.TabIndex = 2;
            this.lblSeparator1.Text = ":";
            // 
            // lblProgressVal
            // 
            this.lblProgressVal.AutoSize = true;
            this.lblProgressVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressVal.ForeColor = System.Drawing.Color.Black;
            this.lblProgressVal.Location = new System.Drawing.Point(129, 12);
            this.lblProgressVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblProgressVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblProgressVal.Name = "lblProgressVal";
            this.lblProgressVal.Size = new System.Drawing.Size(160, 17);
            this.lblProgressVal.TabIndex = 3;
            this.lblProgressVal.Text = "[Value]";
            // 
            // SAProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblProgressVal);
            this.Controls.Add(this.lblSeparator1);
            this.Controls.Add(this.picQuestion1);
            this.Controls.Add(this.lblProgress);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SAProgress";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(301, 41);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.PictureBox picQuestion1;
        private System.Windows.Forms.Label lblSeparator1;
        private System.Windows.Forms.Label lblProgressVal;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
