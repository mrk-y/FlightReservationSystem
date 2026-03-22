namespace FlightReservationSystem
{
    partial class LoginForm
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.picVisibility = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPasswordVal = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.tbUserIDVal = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.header1 = new FlightReservationSystem.UserControls.Header();
            this.pnlHeader = new FlightReservationSystem.UserControls.Header();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVisibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.picVisibility);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.tbPasswordVal);
            this.pnlLogin.Controls.Add(this.lblUserID);
            this.pnlLogin.Controls.Add(this.tbUserIDVal);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.Location = new System.Drawing.Point(457, 188);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(350, 304);
            this.pnlLogin.TabIndex = 1;
            // 
            // picVisibility
            // 
            this.picVisibility.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.picVisibility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVisibility.Image = global::FlightReservationSystem.Properties.Resources.EyeOpen;
            this.picVisibility.Location = new System.Drawing.Point(288, 178);
            this.picVisibility.Margin = new System.Windows.Forms.Padding(0);
            this.picVisibility.Name = "picVisibility";
            this.picVisibility.Padding = new System.Windows.Forms.Padding(1);
            this.picVisibility.Size = new System.Drawing.Size(27, 27);
            this.picVisibility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisibility.TabIndex = 7;
            this.picVisibility.TabStop = false;
            this.picVisibility.Click += new System.EventHandler(this.picVisibility_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(35, 237);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0, 32, 0, 32);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.btnLogin.Size = new System.Drawing.Size(101, 31);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblPassword.Location = new System.Drawing.Point(32, 155);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Tag = "";
            this.lblPassword.Text = "Password *";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPasswordVal
            // 
            this.tbPasswordVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbPasswordVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPasswordVal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPasswordVal.ForeColor = System.Drawing.Color.Black;
            this.tbPasswordVal.Location = new System.Drawing.Point(35, 178);
            this.tbPasswordVal.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.tbPasswordVal.MaxLength = 20;
            this.tbPasswordVal.Name = "tbPasswordVal";
            this.tbPasswordVal.PasswordChar = '*';
            this.tbPasswordVal.Size = new System.Drawing.Size(240, 27);
            this.tbPasswordVal.TabIndex = 2;
            this.tbPasswordVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblUserID.Location = new System.Drawing.Point(32, 81);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(57, 15);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Tag = "";
            this.lblUserID.Text = "User ID *";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUserIDVal
            // 
            this.tbUserIDVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbUserIDVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserIDVal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserIDVal.ForeColor = System.Drawing.Color.Black;
            this.tbUserIDVal.Location = new System.Drawing.Point(35, 104);
            this.tbUserIDVal.Margin = new System.Windows.Forms.Padding(0, 8, 35, 0);
            this.tbUserIDVal.MaxLength = 7;
            this.tbUserIDVal.Name = "tbUserIDVal";
            this.tbUserIDVal.Size = new System.Drawing.Size(280, 27);
            this.tbUserIDVal.TabIndex = 1;
            this.tbUserIDVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserID_KeyPress);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.lblLogin.Location = new System.Drawing.Point(143, 24);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(63, 25);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Margin = new System.Windows.Forms.Padding(0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1264, 50);
            this.header1.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1264, 50);
            this.pnlHeader.TabIndex = 2;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.pnlLogin);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVisibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox tbUserIDVal;
        private System.Windows.Forms.TextBox tbPasswordVal;
        private UserControls.Header pnlHeader;
        private System.Windows.Forms.Button btnLogin;
        private UserControls.Header header1;
        private System.Windows.Forms.PictureBox picVisibility;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPassword;
    }
}

