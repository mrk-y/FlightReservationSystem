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
            if (string.IsNullOrWhiteSpace(userID))
            {
                DebugLogger.LogWithStackTrace("userID is null or whitespace. Authentication aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                DebugLogger.LogWithStackTrace("password is null or whitespace. Authentication aborted.");
                return;
            }

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    string prefix = userID.Substring(0, 2);

                    if (string.IsNullOrWhiteSpace(prefix))
                    {
                        DebugLogger.LogWithStackTrace("prefix is null or whitespace. Authentication aborted.");
                        return;
                    }

                    string userCode = userID.Substring(3, 4);

                    if (string.IsNullOrWhiteSpace(userCode))
                    {
                        DebugLogger.LogWithStackTrace("userCode is null or whitespace. Authentication aborted.");
                        return;
                    }

                    con.Open();
                    string sql = "SELECT u.UserCode, u.Name, u.Password, ut.UserTypeID, ut.Type, ut.Prefix " +
                        "FROM Users u " +
                        "INNER JOIN UserTypes ut " +
                        "ON u.UserType = ut.UserTypeID " +
                        "WHERE u.IsActive = 1 AND ut.IsActive = 1 AND u.UserCode = @userCode AND ut.Prefix = @prefix ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userCode", userCode);
                        cmd.Parameters.AddWithValue("@prefix", prefix);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string db_u_name = reader.GetString(1);

                                if (string.IsNullOrWhiteSpace(db_u_name))
                                {
                                    DebugLogger.LogWithStackTrace("db_u_name is null or whitespace from Users Table DB. Authentication aborted.");
                                    return;
                                }

                                string db_u_password = reader.GetString(2);

                                if (string.IsNullOrWhiteSpace(db_u_password))
                                {
                                    DebugLogger.LogWithStackTrace("db_u_password is null or whitespace from Users Table DB. Authentication aborted.");
                                    return;
                                }

                                int db_ut_userTypeID = reader.GetInt32(3);

                                if (db_ut_userTypeID == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_ut_userTypeID is 0 from UserTypes Table DB. Authentication aborted.");
                                    return;
                                }

                                string db_ut_type = reader.GetString(4);

                                if (string.IsNullOrWhiteSpace(db_ut_type))
                                {
                                    DebugLogger.LogWithStackTrace("db_ut_type is null or whitespace from UserTypes Table DB. Authentication aborted.");
                                    return;
                                }

                                User user = new User();
                                user.UserID = $"{reader.GetString(5)}-{reader.GetString(0)}";
                                user.Name = db_u_name;
                                user.HashedPassword = db_u_password;
                                user.UserType = db_ut_type;
                                user.UserTypeID = db_ut_userTypeID;

                                if (!PasswordHelper.VerifyPassword(password, user.HashedPassword))
                                {
                                    ErrorManager.Add(new ErrorRecord { Message = "Incorrect password.", AssociatedControls = { _login._lblPassword } });
                                    ErrorManager.Alert();
                                    ErrorManager.Highlight(true);
                                    ControlValResetter.DefaultValueSpecificField("tbPassword");
                                }
                                else
                                {
                                    MessageBoxHelper.ShowSuccessMessage("Account found. Logging in...");
                                    LoginAccount(user);
                                }
                            }
                            else
                            {
                                ErrorManager.Add(new ErrorRecord { Message = "There is no account with the provided User ID.", AssociatedControls = { _login._lblUserID } });
                                ErrorManager.Alert();
                                ErrorManager.Highlight(true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Authentication aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while authenticating credentails.");
                    return;
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
                DebugLogger.LogWithStackTrace("user is null. Login aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(user.UserID))
            {
                DebugLogger.LogWithStackTrace("user.UserID is null or whitespace. Login aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                DebugLogger.LogWithStackTrace("user.Name is null or whitespace. Login aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(user.HashedPassword))
            {
                DebugLogger.LogWithStackTrace("user.HashedPassword is null or whitespace. Login aborted.");
                return;
            }

            int userTypeID = user.UserTypeID;

            if (userTypeID == 0)
            {
                DebugLogger.LogWithStackTrace("userTypeID is 0. Login aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(user.UserType))
            {
                DebugLogger.LogWithStackTrace("user.UserType is null or whitespace. Login aborted.");
                return;
            }

            StoreUserCredentials(user);
            ControlValResetter.ClearFields();
            ControlValResetter.ClearProviders();
            ErrorCollection.Clear();
            ErrorUICollection.Clear();

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
