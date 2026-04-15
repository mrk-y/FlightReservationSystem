namespace FlightReservationSystem
{
    partial class MainForm
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
            this.lblUsernameVal = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.header1 = new FlightReservationSystem.UserControls.Header();
            this.SuspendLayout();
            // 
            // lblUsernameVal
            // 
            this.lblUsernameVal.AutoSize = true;
            this.lblUsernameVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.lblUsernameVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameVal.ForeColor = System.Drawing.Color.White;
            this.lblUsernameVal.Location = new System.Drawing.Point(690, 20);
            this.lblUsernameVal.Margin = new System.Windows.Forms.Padding(0);
            this.lblUsernameVal.Name = "lblUsernameVal";
            this.lblUsernameVal.Size = new System.Drawing.Size(67, 17);
            this.lblUsernameVal.TabIndex = 2;
            this.lblUsernameVal.Text = "John Doe";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(629, 22);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(61, 15);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome,";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Location = new System.Drawing.Point(0, 52);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(1264, 33);
            this.pnlNavigation.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(32, 114);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 544);
            this.pnlContent.TabIndex = 4;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Margin = new System.Windows.Forms.Padding(0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1264, 50);
            this.header1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblUsernameVal);
            this.Controls.Add(this.header1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Header header1;
        private System.Windows.Forms.Label lblUsernameVal;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlContent;
    }
}