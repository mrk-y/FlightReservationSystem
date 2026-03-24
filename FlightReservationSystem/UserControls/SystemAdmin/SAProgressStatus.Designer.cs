namespace FlightReservationSystem.UserControls.Others
{
    partial class SAProgressStatus
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
            this.lblStatusVal = new System.Windows.Forms.Label();
            this.lblSeparator2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProgressVal = new System.Windows.Forms.Label();
            this.lblSeparator1 = new System.Windows.Forms.Label();
            this.picQuestion1 = new System.Windows.Forms.PictureBox();
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
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "Progress";
            // 
            // lblStatusVal
            // 
            this.lblStatusVal.AutoEllipsis = true;
            this.lblStatusVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblStatusVal.Location = new System.Drawing.Point(293, 12);
            this.lblStatusVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatusVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblStatusVal.Name = "lblStatusVal";
            this.lblStatusVal.Size = new System.Drawing.Size(160, 17);
            this.lblStatusVal.TabIndex = 19;
            this.lblStatusVal.Text = "[Value]";
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.AutoSize = true;
            this.lblSeparator2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator2.Location = new System.Drawing.Point(275, 14);
            this.lblSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator2.TabIndex = 18;
            this.lblSeparator2.Text = ":";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblStatus.Location = new System.Drawing.Point(209, 14);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Status";
            // 
            // lblProgressVal
            // 
            this.lblProgressVal.AutoSize = true;
            this.lblProgressVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblProgressVal.Location = new System.Drawing.Point(129, 12);
            this.lblProgressVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 0);
            this.lblProgressVal.Name = "lblProgressVal";
            this.lblProgressVal.Size = new System.Drawing.Size(20, 17);
            this.lblProgressVal.TabIndex = 16;
            this.lblProgressVal.Text = "/3";
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
            this.lblSeparator1.TabIndex = 15;
            this.lblSeparator1.Text = ":";
            // 
            // picQuestion1
            // 
            this.picQuestion1.Image = global::FlightReservationSystem.Properties.Resources.Question;
            this.picQuestion1.Location = new System.Drawing.Point(71, 13);
            this.picQuestion1.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.picQuestion1.Name = "picQuestion1";
            this.picQuestion1.Size = new System.Drawing.Size(16, 16);
            this.picQuestion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picQuestion1.TabIndex = 10;
            this.picQuestion1.TabStop = false;
            // 
            // SAProgressStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblStatusVal);
            this.Controls.Add(this.lblSeparator2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblProgressVal);
            this.Controls.Add(this.lblSeparator1);
            this.Controls.Add(this.picQuestion1);
            this.Controls.Add(this.lblProgress);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SAProgressStatus";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(465, 41);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.PictureBox picQuestion1;
        private System.Windows.Forms.Label lblStatusVal;
        private System.Windows.Forms.Label lblSeparator2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProgressVal;
        private System.Windows.Forms.Label lblSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
