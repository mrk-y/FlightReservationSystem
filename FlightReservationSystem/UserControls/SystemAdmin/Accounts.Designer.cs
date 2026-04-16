namespace FlightReservationSystem.UserControls.SystemAdmin
{
    partial class Accounts
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pboPasswordPeek = new System.Windows.Forms.PictureBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbTypeVal = new System.Windows.Forms.ComboBox();
            this.tbNameVal = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbPasswordVal = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSeparator9 = new System.Windows.Forms.Label();
            this.lblSeparator7 = new System.Windows.Forms.Label();
            this.lblSeparator6 = new System.Windows.Forms.Label();
            this.lblUserTypeVal = new System.Windows.Forms.Label();
            this.lblUserIDVal = new System.Windows.Forms.Label();
            this.lblUserNameVal = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnEditName = new System.Windows.Forms.Button();
            this.cmbUserVal = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpdateName = new System.Windows.Forms.Button();
            this.tbEditNameVal = new System.Windows.Forms.TextBox();
            this.lblEditName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pboConfirmPeek = new System.Windows.Forms.PictureBox();
            this.pboNewPeek = new System.Windows.Forms.PictureBox();
            this.pboOldPeek = new System.Windows.Forms.PictureBox();
            this.tbConfirmPasswordVal = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.tbOldPasswordVal = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.tbNewPasswordVal = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboPasswordPeek)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboConfirmPeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboNewPeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboOldPeek)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pboPasswordPeek);
            this.panel2.Controls.Add(this.btnAddUser);
            this.panel2.Controls.Add(this.lblType);
            this.panel2.Controls.Add(this.cmbTypeVal);
            this.panel2.Controls.Add(this.tbNameVal);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.tbPasswordVal);
            this.panel2.Controls.Add(this.lblPassword);
            this.panel2.Location = new System.Drawing.Point(154, 258);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12);
            this.panel2.Size = new System.Drawing.Size(545, 191);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pboPasswordPeek
            // 
            this.pboPasswordPeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pboPasswordPeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboPasswordPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboPasswordPeek.Image = global::FlightReservationSystem.Properties.Resources.EyeOpen;
            this.pboPasswordPeek.Location = new System.Drawing.Point(259, 92);
            this.pboPasswordPeek.Margin = new System.Windows.Forms.Padding(0);
            this.pboPasswordPeek.Name = "pboPasswordPeek";
            this.pboPasswordPeek.Padding = new System.Windows.Forms.Padding(1);
            this.pboPasswordPeek.Size = new System.Drawing.Size(27, 27);
            this.pboPasswordPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboPasswordPeek.TabIndex = 28;
            this.pboPasswordPeek.TabStop = false;
            this.pboPasswordPeek.Click += new System.EventHandler(this.pboPasswordPeek_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.AutoSize = true;
            this.btnAddUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(12, 148);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnAddUser.Size = new System.Drawing.Size(55, 29);
            this.btnAddUser.TabIndex = 17;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblType.Location = new System.Drawing.Point(288, 15);
            this.lblType.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 15);
            this.lblType.TabIndex = 25;
            this.lblType.Text = "Type *";
            // 
            // cmbTypeVal
            // 
            this.cmbTypeVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbTypeVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbTypeVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeVal.ForeColor = System.Drawing.Color.Black;
            this.cmbTypeVal.FormattingEnabled = true;
            this.cmbTypeVal.Items.AddRange(new object[] {
            "System Admin",
            "Reservation Agent"});
            this.cmbTypeVal.Location = new System.Drawing.Point(291, 33);
            this.cmbTypeVal.Margin = new System.Windows.Forms.Padding(0);
            this.cmbTypeVal.Name = "cmbTypeVal";
            this.cmbTypeVal.Size = new System.Drawing.Size(240, 25);
            this.cmbTypeVal.TabIndex = 3;
            // 
            // tbNameVal
            // 
            this.tbNameVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbNameVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNameVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNameVal.ForeColor = System.Drawing.Color.Black;
            this.tbNameVal.Location = new System.Drawing.Point(12, 32);
            this.tbNameVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.tbNameVal.MaxLength = 50;
            this.tbNameVal.Name = "tbNameVal";
            this.tbNameVal.Size = new System.Drawing.Size(240, 25);
            this.tbNameVal.TabIndex = 21;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblName.Location = new System.Drawing.Point(9, 13);
            this.lblName.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 15);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Name *";
            // 
            // tbPasswordVal
            // 
            this.tbPasswordVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbPasswordVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPasswordVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPasswordVal.ForeColor = System.Drawing.Color.Black;
            this.tbPasswordVal.Location = new System.Drawing.Point(12, 93);
            this.tbPasswordVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.tbPasswordVal.MaxLength = 20;
            this.tbPasswordVal.Name = "tbPasswordVal";
            this.tbPasswordVal.Size = new System.Drawing.Size(240, 25);
            this.tbPasswordVal.TabIndex = 17;
            this.tbPasswordVal.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblPassword.Location = new System.Drawing.Point(10, 73);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password *";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDeleteUser);
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnEditName);
            this.panel1.Controls.Add(this.cmbUserVal);
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Location = new System.Drawing.Point(154, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(544, 154);
            this.panel1.TabIndex = 17;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.AutoSize = true;
            this.btnDeleteUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(80, 114);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnDeleteUser.Size = new System.Drawing.Size(120, 29);
            this.btnDeleteUser.TabIndex = 18;
            this.btnDeleteUser.Text = "Delete Account";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AutoSize = true;
            this.btnChangePassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(406, 72);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnChangePassword.Size = new System.Drawing.Size(129, 29);
            this.btnChangePassword.TabIndex = 17;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click_1);
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.lblSeparator9);
            this.panel4.Controls.Add(this.lblSeparator7);
            this.panel4.Controls.Add(this.lblSeparator6);
            this.panel4.Controls.Add(this.lblUserTypeVal);
            this.panel4.Controls.Add(this.lblUserIDVal);
            this.panel4.Controls.Add(this.lblUserNameVal);
            this.panel4.Controls.Add(this.lblUserType);
            this.panel4.Controls.Add(this.lblUserID);
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 92);
            this.panel4.TabIndex = 16;
            // 
            // lblSeparator9
            // 
            this.lblSeparator9.AutoSize = true;
            this.lblSeparator9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator9.Location = new System.Drawing.Point(84, 51);
            this.lblSeparator9.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblSeparator9.Name = "lblSeparator9";
            this.lblSeparator9.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator9.TabIndex = 27;
            this.lblSeparator9.Text = ":";
            // 
            // lblSeparator7
            // 
            this.lblSeparator7.AutoSize = true;
            this.lblSeparator7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator7.Location = new System.Drawing.Point(84, 27);
            this.lblSeparator7.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.lblSeparator7.Name = "lblSeparator7";
            this.lblSeparator7.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator7.TabIndex = 25;
            this.lblSeparator7.Text = ":";
            // 
            // lblSeparator6
            // 
            this.lblSeparator6.AutoSize = true;
            this.lblSeparator6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblSeparator6.Location = new System.Drawing.Point(84, 2);
            this.lblSeparator6.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.lblSeparator6.Name = "lblSeparator6";
            this.lblSeparator6.Size = new System.Drawing.Size(10, 15);
            this.lblSeparator6.TabIndex = 18;
            this.lblSeparator6.Text = ":";
            // 
            // lblUserTypeVal
            // 
            this.lblUserTypeVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserTypeVal.ForeColor = System.Drawing.Color.Black;
            this.lblUserTypeVal.Location = new System.Drawing.Point(102, 50);
            this.lblUserTypeVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblUserTypeVal.MaximumSize = new System.Drawing.Size(160, 17);
            this.lblUserTypeVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblUserTypeVal.Name = "lblUserTypeVal";
            this.lblUserTypeVal.Size = new System.Drawing.Size(160, 17);
            this.lblUserTypeVal.TabIndex = 23;
            // 
            // lblUserIDVal
            // 
            this.lblUserIDVal.AutoEllipsis = true;
            this.lblUserIDVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIDVal.ForeColor = System.Drawing.Color.Black;
            this.lblUserIDVal.Location = new System.Drawing.Point(102, 25);
            this.lblUserIDVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblUserIDVal.MaximumSize = new System.Drawing.Size(160, 17);
            this.lblUserIDVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblUserIDVal.Name = "lblUserIDVal";
            this.lblUserIDVal.Size = new System.Drawing.Size(160, 17);
            this.lblUserIDVal.TabIndex = 22;
            // 
            // lblUserNameVal
            // 
            this.lblUserNameVal.AutoEllipsis = true;
            this.lblUserNameVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameVal.ForeColor = System.Drawing.Color.Black;
            this.lblUserNameVal.Location = new System.Drawing.Point(102, 0);
            this.lblUserNameVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblUserNameVal.MaximumSize = new System.Drawing.Size(160, 17);
            this.lblUserNameVal.MinimumSize = new System.Drawing.Size(160, 17);
            this.lblUserNameVal.Name = "lblUserNameVal";
            this.lblUserNameVal.Size = new System.Drawing.Size(160, 17);
            this.lblUserNameVal.TabIndex = 18;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblUserType.Location = new System.Drawing.Point(0, 51);
            this.lblUserType.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(33, 15);
            this.lblUserType.TabIndex = 21;
            this.lblUserType.Text = "Type";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblUserID.Location = new System.Drawing.Point(0, 27);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(0, 0, 24, 8);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(49, 15);
            this.lblUserID.TabIndex = 19;
            this.lblUserID.Text = "User ID";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblUserName.Location = new System.Drawing.Point(0, 2);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(0, 0, 24, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(40, 15);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "Name";
            // 
            // btnEditName
            // 
            this.btnEditName.AutoSize = true;
            this.btnEditName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnEditName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditName.FlatAppearance.BorderSize = 0;
            this.btnEditName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditName.ForeColor = System.Drawing.Color.White;
            this.btnEditName.Location = new System.Drawing.Point(290, 72);
            this.btnEditName.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnEditName.Size = new System.Drawing.Size(90, 29);
            this.btnEditName.TabIndex = 16;
            this.btnEditName.Text = "Edit Name";
            this.btnEditName.UseVisualStyleBackColor = false;
            // 
            // cmbUserVal
            // 
            this.cmbUserVal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbUserVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbUserVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserVal.ForeColor = System.Drawing.Color.Black;
            this.cmbUserVal.FormattingEnabled = true;
            this.cmbUserVal.Location = new System.Drawing.Point(290, 31);
            this.cmbUserVal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.cmbUserVal.Name = "cmbUserVal";
            this.cmbUserVal.Size = new System.Drawing.Size(240, 25);
            this.cmbUserVal.TabIndex = 2;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblAccount.Location = new System.Drawing.Point(290, 12);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(53, 15);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "Account";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnUpdateName);
            this.panel3.Controls.Add(this.tbEditNameVal);
            this.panel3.Controls.Add(this.lblEditName);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(719, 79);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(12);
            this.panel3.Size = new System.Drawing.Size(298, 114);
            this.panel3.TabIndex = 26;
            // 
            // btnUpdateName
            // 
            this.btnUpdateName.AutoSize = true;
            this.btnUpdateName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnUpdateName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateName.FlatAppearance.BorderSize = 0;
            this.btnUpdateName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateName.ForeColor = System.Drawing.Color.White;
            this.btnUpdateName.Location = new System.Drawing.Point(12, 71);
            this.btnUpdateName.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateName.Name = "btnUpdateName";
            this.btnUpdateName.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnUpdateName.Size = new System.Drawing.Size(110, 29);
            this.btnUpdateName.TabIndex = 17;
            this.btnUpdateName.Text = "Update Name";
            this.btnUpdateName.UseVisualStyleBackColor = false;
            // 
            // tbEditNameVal
            // 
            this.tbEditNameVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbEditNameVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEditNameVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEditNameVal.ForeColor = System.Drawing.Color.Black;
            this.tbEditNameVal.Location = new System.Drawing.Point(12, 32);
            this.tbEditNameVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.tbEditNameVal.MaxLength = 50;
            this.tbEditNameVal.Name = "tbEditNameVal";
            this.tbEditNameVal.Size = new System.Drawing.Size(240, 25);
            this.tbEditNameVal.TabIndex = 21;
            // 
            // lblEditName
            // 
            this.lblEditName.AutoSize = true;
            this.lblEditName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblEditName.Location = new System.Drawing.Point(9, 12);
            this.lblEditName.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblEditName.Name = "lblEditName";
            this.lblEditName.Size = new System.Drawing.Size(48, 15);
            this.lblEditName.TabIndex = 20;
            this.lblEditName.Text = "Name *";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.pboConfirmPeek);
            this.panel5.Controls.Add(this.pboNewPeek);
            this.panel5.Controls.Add(this.pboOldPeek);
            this.panel5.Controls.Add(this.tbConfirmPasswordVal);
            this.panel5.Controls.Add(this.lblConfirmPassword);
            this.panel5.Controls.Add(this.btnUpdatePassword);
            this.panel5.Controls.Add(this.tbOldPasswordVal);
            this.panel5.Controls.Add(this.lblOldPassword);
            this.panel5.Controls.Add(this.tbNewPasswordVal);
            this.panel5.Controls.Add(this.lblNewPassword);
            this.panel5.Enabled = false;
            this.panel5.Location = new System.Drawing.Point(719, 212);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(12);
            this.panel5.Size = new System.Drawing.Size(299, 236);
            this.panel5.TabIndex = 27;
            // 
            // pboConfirmPeek
            // 
            this.pboConfirmPeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pboConfirmPeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboConfirmPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboConfirmPeek.Image = global::FlightReservationSystem.Properties.Resources.EyeOpen;
            this.pboConfirmPeek.Location = new System.Drawing.Point(258, 151);
            this.pboConfirmPeek.Margin = new System.Windows.Forms.Padding(0);
            this.pboConfirmPeek.Name = "pboConfirmPeek";
            this.pboConfirmPeek.Padding = new System.Windows.Forms.Padding(1);
            this.pboConfirmPeek.Size = new System.Drawing.Size(27, 27);
            this.pboConfirmPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboConfirmPeek.TabIndex = 30;
            this.pboConfirmPeek.TabStop = false;
            this.pboConfirmPeek.Click += new System.EventHandler(this.pboConfirmPeek_Click);
            // 
            // pboNewPeek
            // 
            this.pboNewPeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pboNewPeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboNewPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboNewPeek.Image = global::FlightReservationSystem.Properties.Resources.EyeOpen;
            this.pboNewPeek.Location = new System.Drawing.Point(258, 92);
            this.pboNewPeek.Margin = new System.Windows.Forms.Padding(0);
            this.pboNewPeek.Name = "pboNewPeek";
            this.pboNewPeek.Padding = new System.Windows.Forms.Padding(1);
            this.pboNewPeek.Size = new System.Drawing.Size(27, 27);
            this.pboNewPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboNewPeek.TabIndex = 29;
            this.pboNewPeek.TabStop = false;
            this.pboNewPeek.Click += new System.EventHandler(this.pboNewPeek_Click);
            // 
            // pboOldPeek
            // 
            this.pboOldPeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pboOldPeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboOldPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboOldPeek.Image = global::FlightReservationSystem.Properties.Resources.EyeOpen;
            this.pboOldPeek.Location = new System.Drawing.Point(258, 32);
            this.pboOldPeek.Margin = new System.Windows.Forms.Padding(0);
            this.pboOldPeek.Name = "pboOldPeek";
            this.pboOldPeek.Padding = new System.Windows.Forms.Padding(1);
            this.pboOldPeek.Size = new System.Drawing.Size(27, 27);
            this.pboOldPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboOldPeek.TabIndex = 28;
            this.pboOldPeek.TabStop = false;
            this.pboOldPeek.Click += new System.EventHandler(this.pboOldPeek_Click);
            // 
            // tbConfirmPasswordVal
            // 
            this.tbConfirmPasswordVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbConfirmPasswordVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConfirmPasswordVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPasswordVal.ForeColor = System.Drawing.Color.Black;
            this.tbConfirmPasswordVal.Location = new System.Drawing.Point(13, 152);
            this.tbConfirmPasswordVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.tbConfirmPasswordVal.MaxLength = 50;
            this.tbConfirmPasswordVal.Name = "tbConfirmPasswordVal";
            this.tbConfirmPasswordVal.Size = new System.Drawing.Size(240, 25);
            this.tbConfirmPasswordVal.TabIndex = 27;
            this.tbConfirmPasswordVal.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(11, 132);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(115, 15);
            this.lblConfirmPassword.TabIndex = 26;
            this.lblConfirmPassword.Text = "Confirm Password *";
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.AutoSize = true;
            this.btnUpdatePassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdatePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.btnUpdatePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatePassword.FlatAppearance.BorderSize = 0;
            this.btnUpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePassword.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePassword.Location = new System.Drawing.Point(12, 193);
            this.btnUpdatePassword.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnUpdatePassword.Size = new System.Drawing.Size(129, 29);
            this.btnUpdatePassword.TabIndex = 17;
            this.btnUpdatePassword.Text = "Update Password";
            this.btnUpdatePassword.UseVisualStyleBackColor = false;
            // 
            // tbOldPasswordVal
            // 
            this.tbOldPasswordVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbOldPasswordVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOldPasswordVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOldPasswordVal.ForeColor = System.Drawing.Color.Black;
            this.tbOldPasswordVal.Location = new System.Drawing.Point(13, 33);
            this.tbOldPasswordVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.tbOldPasswordVal.MaxLength = 50;
            this.tbOldPasswordVal.Name = "tbOldPasswordVal";
            this.tbOldPasswordVal.Size = new System.Drawing.Size(240, 25);
            this.tbOldPasswordVal.TabIndex = 21;
            this.tbOldPasswordVal.UseSystemPasswordChar = true;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblOldPassword.Location = new System.Drawing.Point(10, 14);
            this.lblOldPassword.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(89, 15);
            this.lblOldPassword.TabIndex = 20;
            this.lblOldPassword.Text = "Old Password *";
            // 
            // tbNewPasswordVal
            // 
            this.tbNewPasswordVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tbNewPasswordVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNewPasswordVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPasswordVal.ForeColor = System.Drawing.Color.Black;
            this.tbNewPasswordVal.Location = new System.Drawing.Point(13, 93);
            this.tbNewPasswordVal.Margin = new System.Windows.Forms.Padding(0, 0, 32, 16);
            this.tbNewPasswordVal.MaxLength = 50;
            this.tbNewPasswordVal.Name = "tbNewPasswordVal";
            this.tbNewPasswordVal.Size = new System.Drawing.Size(240, 25);
            this.tbNewPasswordVal.TabIndex = 17;
            this.tbNewPasswordVal.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblNewPassword.Location = new System.Drawing.Point(11, 74);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(0, 0, 32, 4);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(96, 15);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password *";
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Accounts";
            this.Size = new System.Drawing.Size(1200, 544);
            this.ParentChanged += new System.EventHandler(this.Accounts_ParentChanged);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboPasswordPeek)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboConfirmPeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboNewPeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboOldPeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbTypeVal;
        private System.Windows.Forms.TextBox tbNameVal;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbPasswordVal;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSeparator9;
        private System.Windows.Forms.Label lblSeparator7;
        private System.Windows.Forms.Label lblSeparator6;
        private System.Windows.Forms.Label lblUserTypeVal;
        private System.Windows.Forms.Label lblUserIDVal;
        private System.Windows.Forms.Label lblUserNameVal;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnEditName;
        private System.Windows.Forms.ComboBox cmbUserVal;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdateName;
        private System.Windows.Forms.TextBox tbEditNameVal;
        private System.Windows.Forms.Label lblEditName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.TextBox tbOldPasswordVal;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox tbNewPasswordVal;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbConfirmPasswordVal;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.PictureBox pboPasswordPeek;
        private System.Windows.Forms.PictureBox pboConfirmPeek;
        private System.Windows.Forms.PictureBox pboNewPeek;
        private System.Windows.Forms.PictureBox pboOldPeek;
    }
}
