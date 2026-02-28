namespace FlightReservationSystem
{
    partial class LogIn
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlLogIn = new System.Windows.Forms.Panel();
            this.btnToggleVisibility = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.epUserID = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 49);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(8, 8);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(443, 31);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Flight Reservation System (FRS)";
            // 
            // pnlLogIn
            // 
            this.pnlLogIn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogIn.Controls.Add(this.btnToggleVisibility);
            this.pnlLogIn.Controls.Add(this.btnLogIn);
            this.pnlLogIn.Controls.Add(this.tbPassword);
            this.pnlLogIn.Controls.Add(this.lblPassword);
            this.pnlLogIn.Controls.Add(this.tbUserID);
            this.pnlLogIn.Controls.Add(this.lblUserID);
            this.pnlLogIn.Controls.Add(this.lblLoginTitle);
            this.pnlLogIn.Location = new System.Drawing.Point(604, 235);
            this.pnlLogIn.Name = "pnlLogIn";
            this.pnlLogIn.Size = new System.Drawing.Size(392, 310);
            this.pnlLogIn.TabIndex = 1;
            // 
            // btnToggleVisibility
            // 
            this.btnToggleVisibility.BackColor = System.Drawing.SystemColors.Window;
            this.btnToggleVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleVisibility.Location = new System.Drawing.Point(330, 187);
            this.btnToggleVisibility.Name = "btnToggleVisibility";
            this.btnToggleVisibility.Size = new System.Drawing.Size(26, 26);
            this.btnToggleVisibility.TabIndex = 6;
            this.btnToggleVisibility.UseVisualStyleBackColor = false;
            this.btnToggleVisibility.Click += new System.EventHandler(this.btnToggleVisibility_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.AutoSize = true;
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Location = new System.Drawing.Point(36, 235);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 32);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(36, 187);
            this.tbPassword.MaxLength = 20;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(288, 26);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(32, 164);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(88, 20);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password *";
            // 
            // tbUserID
            // 
            this.tbUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserID.Location = new System.Drawing.Point(36, 119);
            this.tbUserID.MaxLength = 7;
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(320, 26);
            this.tbUserID.TabIndex = 2;
            this.tbUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserID_KeyPress);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(32, 96);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(74, 20);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "User ID *";
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitle.Location = new System.Drawing.Point(162, 16);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(68, 24);
            this.lblLoginTitle.TabIndex = 0;
            this.lblLoginTitle.Text = "Log In";
            // 
            // epUserID
            // 
            this.epUserID.ContainerControl = this;
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // LogIn
            // 
            this.AcceptButton = this.btnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 821);
            this.Controls.Add(this.pnlLogIn);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLogIn.ResumeLayout(false);
            this.pnlLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlLogIn;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.ErrorProvider epUserID;
        private System.Windows.Forms.ErrorProvider epPassword;
        private System.Windows.Forms.Button btnToggleVisibility;
    }
}

