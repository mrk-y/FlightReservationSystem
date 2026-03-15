using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Data.Runtime.User;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.SystemAdmin;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Services
{
    internal class Authentication
    {
        private static Login _login = null; 


        public static void Init(Login login)
        {
            _login = login;
        }

        public static void AuthenticateCredentials(string userID, string password)
        {   
            if (userID == null || password == null)
            {
                DebugLogger.Log("[Dev] userID or password is null. Authentication aborted.");
                return;
            }

            using (SqlConnection connection = DatabaseConnection.Get())
            {
                try
                {
                    string prefix = userID.Substring(0, 2);
                    string userCode = userID.Substring(3, 4);

                    connection.Open();
                    string sql = "SELECT u.UserCode, u.Name, u.Password, ut.UserTypeID, ut.Type, ut.Prefix " +
                        "FROM Users u " +
                        "INNER JOIN UserTypes ut " +
                        "ON u.UserType = ut.UserTypeID " +
                        "WHERE u.IsActive = 1 AND ut.IsActive = 1 AND u.UserCode = @userCode AND ut.Prefix = @prefix ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@userCode", userCode);
                        cmd.Parameters.AddWithValue("@prefix", prefix);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            { 
                                User user = new User();
                                user.UserID = $"{reader.GetString(5)}-{reader.GetString(0)}";
                                user.Name = reader.GetString(1);
                                user.HashedPassword = reader.GetString(2);
                                user.UserType = reader.GetString(4);
                                user.UserTypeID = reader.GetInt32(3);

                                if (!PasswordHelper.VerifyPassword(password, user.HashedPassword))
                                {
                                    ErrorManager.Add(new ErrorEntry { Message = "Incorrect password. ", AssociatedControls = { _login._lblPassword } });
                                    ErrorManager.Alert();
                                    ErrorManager.Highlight(true);
                                }
                                else
                                {
                                    MessageBoxHelper.ShowSuccessMessage("Account found. Logging in...");
                                    LoginAccount(user);
                                }
                            }
                            else
                            {
                                ErrorManager.Add(new ErrorEntry { Message = "There is no account with the provided User ID", AssociatedControls = { _login._lblUserID } });
                                ErrorManager.Alert();
                                ErrorManager.Highlight(true);
                            }
                        }
                    }
                    
                } 
                catch (Exception ex)
                {
                    DebugLogger.Log($"[Exception] {ex.Message}.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occurred while authenticating credentials.");
                }
            }
        }

        private static void StoreUserCredentials(User user)
        {
            Session._user = new User
            {
                UserID = user.UserID,
                Name = user.Name,
                HashedPassword = user.HashedPassword,
                UserType = user.UserType,
                UserTypeID = user.UserTypeID
            };
        }

        private static void LoginAccount(User user) // TODO: Complete the RA part
        {
            if (user == null)
            {
                DebugLogger.Log("[Dev] user is null. Login aborted.");
                return;
            }

            StoreUserCredentials(user);

            ClearingHelper.ClearCurrentTextBoxFields();
            ClearingHelper.ClearCurrentProviders();
            ErrorCollection.Clear();
            ErrorUIRegistry.Clear();

            int userTypeID = user.UserTypeID;
            MainForm mainForm = new MainForm();

            if (userTypeID == 1)
            {
                AddAircraft addAircraft = new AddAircraft();
                SANavigation saNavigation = new SANavigation();

                MainForm.Init(addAircraft, saNavigation);
                mainForm.Show();
                _login.Hide();
            }
            else if (userTypeID == 2)
            {

            }
        }
    }
}
