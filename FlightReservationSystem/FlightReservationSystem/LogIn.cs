using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationSystem.Properties;
using FlightReservationSystem.UserControls;
using FlightReservationSystem.SystemAdmin;

namespace FlightReservationSystem
{
    public partial class LogIn : Form
    {
        private string connection;

        private (string userID, string password) GetLogInInfo()
        {
            return (
                tbUserID.Text.Trim(),
                tbPassword.Text.Trim()
            );
        }
        private bool IsPassVisible = false; 

        public LogIn()
        {
            InitializeComponent();
            InitUI();
            InitData();
        }

        private void InitUI()
        {
            Global.AddBottomBorderHeader(this, "pnlHeader");
            ToggleImgVisibilityButton(IsPassVisible);
        }

        private void ToggleImgVisibilityButton(bool visible)
        {
            if (visible)
            {
                btnToggleVisibility.Image = Global.ResizeImgRelativeToBtn(Properties.Resources.EyeOpen, btnToggleVisibility);
                tbPassword.PasswordChar = '\0';
            } else
            {
                btnToggleVisibility.Image = Global.ResizeImgRelativeToBtn(Properties.Resources.EyeClosed, btnToggleVisibility);
                tbPassword.PasswordChar = '*';
            }
        }

        private void InitData()
        {
            connection = Global.connection;
            Global.PopulateAircraftModels();
            Global.PopulateAirports();
            Global.PopulateAirlines();
        }

        private void ValidateCredentials()
        {
            var errors = CheckForError();
            int errCount = errors.Count;

            if (errCount > 0)
            {
                string msgNotice = $"{errCount} error found.\nPlease correct the following:\n";
                string allErrorMsg = msgNotice + "";
                foreach (var error in errors)
                {
                    allErrorMsg += $"\n- {error.Value}";
                }
                MessageBox.Show(allErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowErrorEffects(errors);
                return;
            }

            LogInUser();
        }

        private Dictionary<int, string> CheckForError()
        {
            var errors = new Dictionary<int, string>();
            var (userID, password) = GetLogInInfo();

            if (string.IsNullOrEmpty(userID))
            {
                errors.Add(1, "User ID field cannot be empty.");
            }
            else if (userID.Length < 7)
            {
                errors.Add(2, "User ID must be 7 characters long.");
            }

            if (string.IsNullOrEmpty(password))
            {
                errors.Add(3, "Password field cannot be empty.");
            } 
            else if  (password.Length < 6)
            {
                errors.Add(4, "Password must be at least 6 characters long.");
            }

            if (errors.Count == 0)
            {
                if (!DoesUserExists())
                {
                    errors.Add(5, "Incorrect User ID or Password.");
                }
            }
            return errors;
        }

        private bool DoesUserExists()
        {
            var (userID, password) = GetLogInInfo();

            using (SqlConnection con = new SqlConnection(connection)) { 
                try
                {
                    con.Open();
                    string sql = "SELECT UserID, Password, Prefix, IsActive " +
                        "FROM Users ";
                    using (SqlCommand cmd = new SqlCommand(sql, con)) 
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dbUserID = reader.GetInt32(0);
                                string dbPassword = reader.GetString(1);
                                string dbPrefix = reader.GetString(2);
                                bool dbIsActive = reader.GetBoolean(3);

                                string fullDBUserID = $"{dbPrefix}-{dbUserID:0000}";
                                if (dbIsActive && fullDBUserID == userID && dbPassword == password) return true; 
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private void ShowErrorEffects(Dictionary<int, string> errors) 
        {
            epUserID.Clear();
            epPassword.Clear();

            foreach (var error in errors)
            {
                if (error.Key == 1) epUserID.SetError(lblUserID, "User ID field cannot be empty.");
                if (error.Key == 2) epUserID.SetError(lblUserID, "User ID must be 7 characters long.");
                if (error.Key == 3) epPassword.SetError(lblPassword, "Password field cannot be empty.");
                if (error.Key == 4) epPassword.SetError(lblPassword, "Password must be at least 6 characters long.");
                if (error.Key == 5)
                {
                    ClearLogInInputs();
                    epUserID.SetError(lblUserID, "Incorrect User ID or Password.");
                    epPassword.SetError(lblPassword, "Incorrect User ID or Password.");
                }
            }

            ToggleImgVisibilityButton(false);
        }

        private void ClearLogInInputs()
        {
            tbUserID.Clear();
            tbPassword.Clear();
        }

        private void LogInUser()
        {
            var logInInfo = GetLogInInfo();
            string userID = logInInfo.userID;

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT UserID, Name, Password, UserType, Prefix " +
                        "FROM Users ";
                    using (SqlCommand cmd = new SqlCommand(sql, con)) 
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader()) { 
                            while (reader.Read())
                            {
                                int dbUserID = reader.GetInt32(0);
                                string dbName = reader.GetString(1);
                                string dbPassword = reader.GetString(2);
                                int dbUserType = reader.GetInt32(3);
                                string dbPrefix = reader.GetString(4);
                                string fullDBUserID = $"{dbPrefix}-{dbUserID:0000}";

                                if (fullDBUserID == userID)
                                {
                                    Global.userID = fullDBUserID;
                                    Global.userName = dbName;
                                    Global.userPass = dbPassword;

                                    if (dbUserType == 0) Global.userType = "System Admin";
                                    else if (dbUserType == 1) Global.userType = "Reservation Agent";
                                }
                                return;
                            }   
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangePageBasedOnUserType(string userType) 
        {
            MainForm mainForm = new MainForm();

            if (userType == "System Admin")
            {
                mainForm.LoadHeader(new SAHeader());
                mainForm.LoadModule(new AircraftInitialization());
            } else if (userType == "Reservation Agent")
            {
               
            }

            mainForm.Show();
            this.Hide();
        }
      
        private void tbUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void btnToggleVisibility_Click(object sender, EventArgs e)
        {
            IsPassVisible = !IsPassVisible;
            ToggleImgVisibilityButton(IsPassVisible);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            ValidateCredentials();
            ToggleImgVisibilityButton(false);
            MessageBox.Show($"User ID: {Global.userID}\nUser Name: {Global.userName}\nUser Password: {Global.userPass}\nUser Type: {Global.userType}");
            Global.RestartInfoOfModule(this);
            ChangePageBasedOnUserType(Global.userType);
        }
    }
}
