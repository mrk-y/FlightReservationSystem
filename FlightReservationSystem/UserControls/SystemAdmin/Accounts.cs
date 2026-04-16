using FlightReservationSystem.Helpers;
using System.Data.SqlClient;
using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class Accounts : UserControl
    {
        private const string SelectAccountText = "Select an Account";
        private ErrorProvider editNameErrorProvider;
        private ErrorProvider addUserErrorProvider;
        // realtime highest Code values per user type
        private int MaxCodeUserType1 => GetMaxUserCode(1);
        private int MaxCodeUserType2 => GetMaxUserCode(2);

        public Accounts()
        {
            InitializeComponent();
            this.Load += Accounts_Load;
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                // confirm termination
                var confirm = MessageBoxHelper.ShowQuestionMessage("Are you sure you would like to terminate the account?");
                if (confirm != DialogResult.Yes) return;
                var selectedValue = cmbUserVal.SelectedValue;
                if (!(selectedValue is Tuple<int, int> selectedTuple) || selectedTuple.Item1 <= 0)
                {
                    // nothing selected
                    return;
                }

                int selectedCode = selectedTuple.Item1;
                int selectedUserType = selectedTuple.Item2;

                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    string sql = "UPDATE Users SET IsActive = 0 WHERE Code = @code AND UserType = @usertype";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@code", selectedCode);
                        cmd.Parameters.AddWithValue("@usertype", selectedUserType);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBoxHelper.ShowSuccessMessage("User deactivated successfully.");
                            // refresh UI
                            PopulateUserCMB();
                            try { panel3.Enabled = false; } catch { }
                            try { panel4.Enabled = false; } catch { }
                            try { panel5.Enabled = false; } catch { }
                            lblUserNameVal.Text = string.Empty;
                            lblUserIDVal.Text = string.Empty;
                            lblUserTypeVal.Text = string.Empty;
                        }
                        else
                        {
                            MessageBoxHelper.ShowDeveloperErrorMessage("Failed to deactivate user.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Deleting user aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while deactivating the user.");
            }
        }

        private void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                // clear previous errors
                addUserErrorProvider.SetError(tbOldPasswordVal, string.Empty);
                addUserErrorProvider.SetError(tbNewPasswordVal, string.Empty);
                addUserErrorProvider.SetError(tbConfirmPasswordVal, string.Empty);

                var selectedValue = cmbUserVal.SelectedValue;
                if (!(selectedValue is Tuple<int, int> selectedTuple) || selectedTuple.Item1 <= 0)
                {
                    addUserErrorProvider.SetError(cmbUserVal, "Select a valid account");
                    return;
                }

                int selectedCode = selectedTuple.Item1;
                int selectedUserType = selectedTuple.Item2;

                string oldPass = tbOldPasswordVal.Text ?? string.Empty;
                string newPass = tbNewPasswordVal.Text ?? string.Empty;
                string confirmPass = tbConfirmPasswordVal.Text ?? string.Empty;

                bool hasError = false;

                if (string.IsNullOrEmpty(oldPass))
                {
                    addUserErrorProvider.SetError(tbOldPasswordVal, "Old password cannot be empty");
                    if (!hasError) tbOldPasswordVal.Focus();
                    hasError = true;
                }

                if (string.IsNullOrEmpty(newPass))
                {
                    addUserErrorProvider.SetError(tbNewPasswordVal, "New password cannot be empty");
                    if (!hasError) tbNewPasswordVal.Focus();
                    hasError = true;
                }

                if (string.IsNullOrEmpty(confirmPass))
                {
                    addUserErrorProvider.SetError(tbConfirmPasswordVal, "Confirm password cannot be empty");
                    if (!hasError) tbConfirmPasswordVal.Focus();
                    hasError = true;
                }

                if (hasError) return;

                // fetch stored hash
                string storedHash = null;
                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE Code = @code AND UserType = @usertype", con))
                    {
                        cmd.Parameters.AddWithValue("@code", selectedCode);
                        cmd.Parameters.AddWithValue("@usertype", selectedUserType);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) storedHash = result.ToString();
                    }
                }

                if (string.IsNullOrEmpty(storedHash))
                {
                    addUserErrorProvider.SetError(tbOldPasswordVal, "Unable to verify old password");
                    return;
                }

                // verify old password matches
                if (!UserManager.VerifyPassword(oldPass, storedHash))
                {
                    addUserErrorProvider.SetError(tbOldPasswordVal, "Old password does not match");
                    return;
                }

                // confirm new passwords match
                if (!string.Equals(newPass, confirmPass, StringComparison.Ordinal))
                {
                    addUserErrorProvider.SetError(tbConfirmPasswordVal, "Passwords do not match");
                    return;
                }

                // hash and update
                string newHashed = UserManager.HashPassword(confirmPass);
                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Password = @password WHERE Code = @code AND UserType = @usertype", con))
                    {
                        cmd.Parameters.AddWithValue("@password", newHashed);
                        cmd.Parameters.AddWithValue("@code", selectedCode);
                        cmd.Parameters.AddWithValue("@usertype", selectedUserType);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            // clear fields and disable panel
                            try { tbOldPasswordVal.Text = string.Empty; } catch { }
                            try { tbNewPasswordVal.Text = string.Empty; } catch { }
                            try { tbConfirmPasswordVal.Text = string.Empty; } catch { }
                            try { panel4.Enabled = false; } catch { }
                            MessageBoxHelper.ShowSuccessMessage("Password updated successfully.");
                            panel5.Enabled = false;
                            cmbUserVal.SelectedIndex = 0; 
                            lblUserNameVal.Text = string.Empty;
                            lblUserIDVal.Text = string.Empty;
                            lblUserTypeVal.Text = string.Empty; 
                        }
                        else
                        {
                            addUserErrorProvider.SetError(tbOldPasswordVal, "Failed to update password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Updating password aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while updating the password.");
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                panel4.Enabled = true;
                // clear and focus old password field
                try { tbOldPasswordVal.Text = string.Empty; } catch { }
                try { tbNewPasswordVal.Text = string.Empty; } catch { }
                try { tbConfirmPasswordVal.Text = string.Empty; } catch { }
                try { tbOldPasswordVal.Focus(); } catch { }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Enabling change password panel aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while enabling change password panel.");
            }
        }

        private void BtnUpdateName_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = cmbUserVal.SelectedValue;

                if (!(selectedValue is Tuple<int, int> selectedTuple) || selectedTuple.Item1 <= 0)
                {
                    return;
                }

                int selectedCode = selectedTuple.Item1;
                int selectedUserType = selectedTuple.Item2;

                string newName = tbEditNameVal.Text ?? string.Empty;
                string originalName = lblUserNameVal.Text ?? string.Empty;

                // clear previous error
                editNameErrorProvider.SetError(tbEditNameVal, string.Empty);

                // check unchanged
                if (string.Equals(newName, originalName, StringComparison.Ordinal))
                {
                    editNameErrorProvider.SetError(tbEditNameVal, "Name has not been changed");
                    return;
                }

                // basic validations: not empty, not start with whitespace, only letters and spaces
                if (string.IsNullOrWhiteSpace(newName))
                {
                    editNameErrorProvider.SetError(tbEditNameVal, "Name cannot be empty");
                    return;
                }

                if (char.IsWhiteSpace(newName[0]))
                {
                    editNameErrorProvider.SetError(tbEditNameVal, "Name cannot start with a whitespace");
                    return;
                }

                foreach (char ch in newName)
                {
                    if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                    {
                        editNameErrorProvider.SetError(tbEditNameVal, "Name can only contain letters and spaces");
                        return;
                    }
                }

                // perform update
                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    string sql = "UPDATE Users SET Name = @name WHERE Code = @code AND UserType = @usertype";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", newName);
                        cmd.Parameters.AddWithValue("@code", selectedCode);
                        cmd.Parameters.AddWithValue("@usertype", selectedUserType);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            // update UI
                            lblUserNameVal.Text = newName;

                            // update combobox display for the item
                            var list = cmbUserVal.DataSource as List<CMBItemWTag>;
                            if (list != null)
                            {
                                var item = list.FirstOrDefault(i => i.Value is Tuple<int, int> t && t.Item1 == selectedCode && t.Item2 == selectedUserType);
                                if (item != null)
                                {
                                    // use existing lblUserIDVal for formatted id
                                    item.Display = $"{lblUserIDVal.Text} - {newName}";
                                }

                                // rebind to refresh display
                                cmbUserVal.DataSource = null;
                                cmbUserVal.DisplayMember = "Display";
                                cmbUserVal.ValueMember = "Value";
                                cmbUserVal.DataSource = list;
                                cmbUserVal.SelectedValue = selectedCode;

                                // refresh autocomplete
                                var ac = list.Where(i => i.Value is Tuple<int, int> t && t.Item1 > 0).Select(i => i.Display).ToArray();
                                cmbUserVal.AutoCompleteCustomSource.Clear();
                                cmbUserVal.AutoCompleteCustomSource.AddRange(ac);
                            }

                            panel3.Enabled = false;
                            tbEditNameVal.Text = string.Empty;
                            MessageBoxHelper.ShowSuccessMessage("Name updated successfully.");
                            editNameErrorProvider.SetError(tbEditNameVal, string.Empty);
                        }
                        else
                        {
                            MessageBoxHelper.ShowDeveloperErrorMessage("No rows were updated. The user may not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Updating name aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while updating the name.");
            }
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            PopulateUserCMB();
            cmbUserVal.SelectedIndexChanged += CmbUserVal_SelectedIndexChanged;
            btnAddUser.Click += BtnAddUser_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnUpdatePassword.Click += BtnUpdatePassword_Click;
            btnEditName.Click += BtnEditName_Click;
            btnUpdateName.Click += BtnUpdateName_Click;
            tbEditNameVal.KeyPress += TbEditNameVal_KeyPress;
            tbEditNameVal.TextChanged += TbEditNameVal_TextChanged;
            tbNameVal.KeyPress += TbNameVal_KeyPress;
            tbNameVal.TextChanged += TbNameVal_TextChanged;

            // Ensure type combo shows placeholder and types on load
            try
            {
                cmbTypeVal.Items.Clear();
                cmbTypeVal.Items.Add("Select Type");
                cmbTypeVal.Items.Add("System Admin");
                cmbTypeVal.Items.Add("Reservation Agent");
                cmbTypeVal.SelectedIndex = 0;
            }
            catch { }

            // initialize error provider for the edit name textbox
            editNameErrorProvider = new ErrorProvider();
            editNameErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            editNameErrorProvider.SetIconAlignment(tbEditNameVal, ErrorIconAlignment.MiddleRight);

            // initialize error provider for add user
            addUserErrorProvider = new ErrorProvider();
            addUserErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            addUserErrorProvider.SetIconAlignment(tbNameVal, ErrorIconAlignment.MiddleRight);
            addUserErrorProvider.SetIconAlignment(tbPasswordVal, ErrorIconAlignment.MiddleRight);
            addUserErrorProvider.SetIconAlignment(cmbTypeVal, ErrorIconAlignment.MiddleRight);
        }

        private void TbNameVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            // Prevent leading whitespace
            if (e.KeyChar == ' ' && tbNameVal.SelectionStart == 0)
            {
                e.Handled = true;
                addUserErrorProvider.SetError(tbNameVal, "Name cannot start with a whitespace");
                return;
            }

            // Allow letters and spaces only
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ')
            {
                // clear any previous error
                addUserErrorProvider.SetError(tbNameVal, string.Empty);
                return;
            }

            // Disallow other characters
            e.Handled = true;
            addUserErrorProvider.SetError(tbNameVal, "Name can only contain letters and spaces");
        }

        private void TbNameVal_TextChanged(object sender, EventArgs e)
        {
            var text = tbNameVal.Text ?? string.Empty;

            if (string.IsNullOrEmpty(text))
            {
                addUserErrorProvider.SetError(tbNameVal, string.Empty);
                return;
            }

            // Leading whitespace check
            if (text.Length > 0 && char.IsWhiteSpace(text[0]))
            {
                addUserErrorProvider.SetError(tbNameVal, "Name cannot start with a whitespace");
                return;
            }

            // Validate all characters are letters or spaces
            foreach (char ch in text)
            {
                if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                {
                    addUserErrorProvider.SetError(tbNameVal, "Name can only contain letters and spaces");
                    return;
                }
            }

            addUserErrorProvider.SetError(tbNameVal, string.Empty);
        }

        private void TbEditNameVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Prevent leading whitespace
            if (e.KeyChar == ' ' && tbEditNameVal.SelectionStart == 0)
            {
                e.Handled = true;
                editNameErrorProvider.SetError(tbEditNameVal, "Name cannot start with a whitespace");
                return;
            }

            // Allow letters and spaces only
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ')
            {
                // clear any previous error
                editNameErrorProvider.SetError(tbEditNameVal, string.Empty);
                return;
            }

            // Disallow other characters
            e.Handled = true;
            editNameErrorProvider.SetError(tbEditNameVal, "Name can only contain letters and spaces");
        }

        private void TbEditNameVal_TextChanged(object sender, EventArgs e)
        {
            var text = tbEditNameVal.Text ?? string.Empty;

            if (string.IsNullOrEmpty(text))
            {
                editNameErrorProvider.SetError(tbEditNameVal, string.Empty);
                return;
            }
            // Leading whitespace check
            if (text.Length > 0 && char.IsWhiteSpace(text[0]))
            {
                editNameErrorProvider.SetError(tbEditNameVal, "Name cannot start with a whitespace");
                return;
            }

            // Validate all characters are letters or spaces
            foreach (char ch in text)
            {
                if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                {
                    editNameErrorProvider.SetError(tbEditNameVal, "Name can only contain letters and spaces");
                    return;
                }
            }

            editNameErrorProvider.SetError(tbEditNameVal, string.Empty);
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                // clear previous errors
                addUserErrorProvider.SetError(tbNameVal, string.Empty);
                addUserErrorProvider.SetError(tbPasswordVal, string.Empty);
                addUserErrorProvider.SetError(cmbTypeVal, string.Empty);

                bool hasError = false;

                if (string.IsNullOrWhiteSpace(tbNameVal.Text))
                {
                    addUserErrorProvider.SetError(tbNameVal, "Name cannot be empty");
                    if (!hasError) tbNameVal.Focus();
                    hasError = true;
                }

                if (string.IsNullOrWhiteSpace(tbPasswordVal.Text))
                {
                    addUserErrorProvider.SetError(tbPasswordVal, "Password cannot be empty");
                    if (!hasError) tbPasswordVal.Focus();
                    hasError = true;
                }

                // password minimum length
                if (!string.IsNullOrEmpty(tbPasswordVal.Text) && tbPasswordVal.Text.Length < 8)
                {
                    addUserErrorProvider.SetError(tbPasswordVal, "Password must be at least 8 characters");
                    if (!hasError) tbPasswordVal.Focus();
                    hasError = true;
                }

                var typeText = cmbTypeVal.SelectedItem as string ?? string.Empty;
                int userTypeId = 0;
                if (typeText.Equals("System Admin", StringComparison.OrdinalIgnoreCase)) userTypeId = 1;
                else if (typeText.Equals("Reservation Agent", StringComparison.OrdinalIgnoreCase)) userTypeId = 2;

                if (userTypeId == 0)
                {
                    addUserErrorProvider.SetError(cmbTypeVal, "Choose an account type");
                    if (!hasError) cmbTypeVal.Focus();
                    hasError = true;
                }

                if (hasError) return;

                int newCode = (userTypeId == 1 ? MaxCodeUserType1 : MaxCodeUserType2) + 1;
                string hashed = UserManager.HashPassword(tbPasswordVal.Text);

                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    string sql = "INSERT INTO Users (Code, Name, Password, UserType, IsActive) VALUES (@code, @name, @password, @usertype, 1)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@code", newCode);
                        cmd.Parameters.AddWithValue("@name", tbNameVal.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", hashed);
                        cmd.Parameters.AddWithValue("@usertype", userTypeId);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBoxHelper.ShowSuccessMessage("Account added successfully.");
                            PopulateUserCMB();
                            tbNameVal.Text = string.Empty;
                            tbPasswordVal.Text = string.Empty;
                            cmbTypeVal.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBoxHelper.ShowDeveloperErrorMessage("Failed to add account.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Add account aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while adding the account.");
            }
        }

        private void BtnEditName_Click(object sender, EventArgs e)
        {
            try
            {
                // Only allow editing when a real account is selected
                var selectedValue = cmbUserVal.SelectedValue;

                if (!(selectedValue is Tuple<int, int> selectedTuple) || selectedTuple.Item1 <= 0)
                {
                    // No valid account selected - do nothing
                    return;
                }

                int selectedCode = selectedTuple.Item1;
                int selectedUserType = selectedTuple.Item2;

                // Enable the edit panel and populate the textbox with the current name
                panel3.Enabled = true;
                tbEditNameVal.Text = lblUserNameVal.Text ?? string.Empty;
                tbEditNameVal.Focus();
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Enabling edit name panel aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while enabling edit name panel.");
            }
        }

        private void CmbUserVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // disable edit panel whenever selection changes
            try { panel3.Enabled = false;
                tbEditNameVal.Clear();
            } catch { }
            // clear any previous edit errors
            try { editNameErrorProvider.SetError(tbEditNameVal, string.Empty); } catch { }

            ApplySelectedUserDetails();
        }

        private void ApplySelectedUserDetails()
        {
            try
            {
                var selectedValue = cmbUserVal.SelectedValue;

                if (!(selectedValue is Tuple<int, int> selectedTuple) || selectedTuple.Item1 <= 0)
                {
                    lblUserNameVal.Text = string.Empty;
                    lblUserIDVal.Text = string.Empty;
                    lblUserTypeVal.Text = string.Empty;
                    return;
                }

                int selectedCode = selectedTuple.Item1;
                int selectedUserType = selectedTuple.Item2;

                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    string sql = "SELECT u.Code AS u_Code, u.Name AS u_Name, ut.Type AS ut_Type, ut.Prefix AS ut_Prefix " +
                                 "FROM Users u INNER JOIN UserTypes ut ON u.UserType = ut.UserTypeID " +
                                 "WHERE u.IsActive = 1 AND ut.IsActive = 1 AND u.Code = @code AND u.UserType = @usertype";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // pass both code and usertype to ensure correct row
                        cmd.Parameters.AddWithValue("@code", selectedCode);
                        cmd.Parameters.AddWithValue("@usertype", selectedUserType);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int db_u_Code = reader.GetInt32(reader.GetOrdinal("u_Code"));
                                string db_u_Name = reader.GetString(reader.GetOrdinal("u_Name"));
                                string db_ut_Prefix = reader.GetString(reader.GetOrdinal("ut_Prefix"));
                                string db_ut_Type = reader.GetString(reader.GetOrdinal("ut_Type"));

                                lblUserNameVal.Text = db_u_Name;
                                lblUserIDVal.Text = DataFormatter.UserIDFormat(db_ut_Prefix, db_u_Code);
                                lblUserTypeVal.Text = db_ut_Type;
                            }
                            else
                            {
                                lblUserNameVal.Text = string.Empty;
                                lblUserIDVal.Text = string.Empty;
                                lblUserTypeVal.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Applying selected user details aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while loading user details.");
            }
        }

        private int GetMaxUserCode(int userType)
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Code), 0) FROM Users WHERE UserType = @ut", con))
                    {
                        cmd.Parameters.AddWithValue("@ut", userType);
                        object result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. GetMaxUserCode aborted.");
                return 0;
            }
        }

        private void PopulateUserCMB()
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.Get())
                {
                    con.Open();
                    string sql = "SELECT u.Code AS u_Code, u.Name AS u_Name, ut.Prefix AS ut_Prefix, ut.UserTypeID AS ut_UserTypeID " +
                                 "FROM Users u INNER JOIN UserTypes ut ON u.UserType = ut.UserTypeID " +
                                 "WHERE u.IsActive = 1 AND ut.IsActive = 1 ORDER BY ut.Prefix, u.Code";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var itemList = new List<CMBItemWTag>();
                            var sourceList = new List<string>();

                            while (reader.Read())
                            {
                                int dbCode = reader.GetInt32(reader.GetOrdinal("u_Code"));
                                string dbName = reader.GetString(reader.GetOrdinal("u_Name"));
                                string dbPrefix = reader.GetString(reader.GetOrdinal("ut_Prefix"));

                                int dbUserTypeID = reader.GetInt32(reader.GetOrdinal("ut_UserTypeID"));
                                string display = $"{DataFormatter.UserIDFormat(dbPrefix, dbCode)} - {dbName}";

                                itemList.Add(new CMBItemWTag { Display = display, Value = Tuple.Create(dbCode, dbUserTypeID) });
                                sourceList.Add(display);
                            }

                            // Insert placeholder at the top so the user must explicitly choose an account
                            itemList.Insert(0, new CMBItemWTag { Display = SelectAccountText, Value = Tuple.Create(0, 0) });

                            cmbUserVal.DisplayMember = "Display";
                            cmbUserVal.ValueMember = "Value";
                            cmbUserVal.DataSource = itemList;
                            cmbUserVal.SelectedIndex = 0;

                            // Auto-complete should not include the placeholder
                            cmbUserVal.AutoCompleteCustomSource.Clear();
                            cmbUserVal.AutoCompleteCustomSource.AddRange(sourceList.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.LogWithStackTrace($"{ex.Message}. Populating users aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while populating user list.");
            }
        }

        private void Accounts_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            panel5.Enabled = true;
        }
    }
}
