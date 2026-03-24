using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Data.Runtime.User;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.SystemAdmin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Services
{
    // Logging in, signing up, logging out, authentications ...

    internal class AccountSession
    {

        // Start of logging actions
        // Include: Authentication, storing info, logging in
        public static void AuthenticateLogin(string userID, string password)
        {
            if (string.IsNullOrWhiteSpace(userID))
            {
                DebugLogger.LogWithStackTrace("userID is null or whitespace. Login authentication aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(userID))
            {
                DebugLogger.LogWithStackTrace("userID starts or ends with space. Login authentication aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                DebugLogger.LogWithStackTrace("password is null or whitespace. Login authentication aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(password))
            {
                DebugLogger.LogWithStackTrace("password starts or ends with space. Login authentication aborted.");
                return;
            }

            string prefix = userID.Substring(0, 2);

            if (string.IsNullOrWhiteSpace(prefix))
            {
                DebugLogger.LogWithStackTrace("prefix is null or whitespace. Login authentication aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(prefix))
            {
                DebugLogger.LogWithStackTrace("prefix starts or ends with space. Login authentication aborted.");
                return;
            }

            string uCode = userID.Substring(3, 4);

            if (string.IsNullOrWhiteSpace(uCode))
            {
                DebugLogger.LogWithStackTrace("uCode is null or whitespace. Login authentication aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(uCode))
            {
                DebugLogger.LogWithStackTrace("uCode starts or ends with space. Login authentication aborted.");
                return;
            }

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT u.Code AS u_Code, " +
                        "u.Name AS u_Name, " +
                        "u.Password AS u_Password, " +
                        "ut.UserTypeID AS ut_UserTypeID, " +
                        "ut.Type AS ut_Type, " +
                        "ut.Prefix AS ut_Prefix " +
                        "FROM Users u " +
                        "INNER JOIN UserTypes ut " +
                        "ON u.UserType = ut.UserTypeID " +
                        "WHERE u.IsActive = 1 " +
                        "AND ut.IsActive = 1 " +
                        "AND RIGHT('0000' + CAST(u.Code AS NVARCHAR(4)), 4) = @uCode " +
                        "AND ut.Prefix = @prefix ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@uCode", uCode);
                        cmd.Parameters.AddWithValue("@prefix", prefix);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string db_u_name = reader.GetString(reader.GetOrdinal("u_Name"));

                                if (string.IsNullOrWhiteSpace(db_u_name))
                                {
                                    DebugLogger.LogWithStackTrace("db_u_name is null or whitespace from Users Table DB. Login authentication aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_u_name))
                                {
                                    DebugLogger.LogWithStackTrace("db_u_name starts or ends with space. Login authentication aborted.");
                                    return;
                                }

                                string db_u_password = reader.GetString(reader.GetOrdinal("u_Password"));

                                if (string.IsNullOrWhiteSpace(db_u_password))
                                {
                                    DebugLogger.LogWithStackTrace("db_u_password is null or whitespace from Users Table DB. Login authentication aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_u_password))
                                {
                                    DebugLogger.LogWithStackTrace("db_u_password starts or ends with space. Login authentication aborted.");
                                    return;
                                }

                                int db_ut_userTypeID = reader.GetInt32(reader.GetOrdinal("ut_UserTypeID"));

                                if (db_ut_userTypeID == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_ut_userTypeID is 0 from UserTypes Table DB. Login authentication aborted.");
                                    return;
                                }

                                string db_ut_type = reader.GetString(reader.GetOrdinal("ut_Type"));

                                if (string.IsNullOrWhiteSpace(db_ut_type))
                                {
                                    DebugLogger.LogWithStackTrace("db_ut_type is null or whitespace from UserTypes Table DB. Login authentication aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ut_type))
                                {
                                    DebugLogger.LogWithStackTrace("db_ut_type starts or ends with space. Login authentication aborted.");
                                    return;
                                }

                                User user = new User();
                                user.UserID = DataFormatter.UserIDFormat(reader.GetString(reader.GetOrdinal("ut_Prefix")), reader.GetInt32(reader.GetOrdinal("u_Code")));
                                user.Name = db_u_name;
                                user.HashedPassword = db_u_password;
                                user.UserType = db_ut_type;
                                user.UserTypeID = db_ut_userTypeID;

                                if (!PasswordHelper.VerifyPassword(password, user.HashedPassword))
                                {
                                    ErrorManager.Add(new ErrorRecord { Message = "Incorrect password.", AssociatedControls = { LoginForm._lblPassword } });
                                    ErrorManager.Alert();
                                    ErrorManager.Highlight(true);
                                    ControlValResetter.DefaultValueSpecificField("tbPasswordVal");
                                }
                                else
                                {
                                    MessageBoxHelper.ShowSuccessMessage("Account found. Logging in...");
                                    LoginAccount(user);
                                }
                            }
                            else
                            {
                                ErrorManager.Add(new ErrorRecord { Message = "There is no account with the provided User ID.", AssociatedControls = { LoginForm._lblUserID } });
                                ErrorManager.Alert();
                                ErrorManager.Highlight(true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Login authentication aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while authenticating login credentails.");
                    return;
                }
            }
        }

        private static void StoreLoginCredentials(User user)
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

        public static void PopulateReferencesForUser()
        {
            int userTypeID = Session._user.UserTypeID;

            if (userTypeID == 1)
            {
                DataSeeder.PopulateAircraftModels();
                DataSeeder.PopulateAirlines();
                DataSeeder.PopulateAirports();
            }
        }

        private static void LoginAccount(User user) // TODO: Complete the RA part
        {
            if (user == null)
            {
                DebugLogger.LogWithStackTrace("user is null. Login aborted.");
                return;
            }

            string userID = user.UserID;

            if (string.IsNullOrWhiteSpace(userID))
            {
                DebugLogger.LogWithStackTrace("userID is null or whitespace. Login aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(userID))
            {
                DebugLogger.LogWithStackTrace("userID starts or ends with space. Login aborted.");
                return;
            }

            string name = user.Name;

            if (string.IsNullOrWhiteSpace(name))
            {
                DebugLogger.LogWithStackTrace("name is null or whitespace. Login aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(name))
            {
                DebugLogger.LogWithStackTrace("name starts or ends with space. Login aborted.");
                return;
            }

            string hashedPassword = user.HashedPassword;

            if (string.IsNullOrWhiteSpace(hashedPassword))
            {
                DebugLogger.LogWithStackTrace("hashedPassword is null or whitespace. Login aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(hashedPassword))
            {
                DebugLogger.LogWithStackTrace("hashedPassword starts or ends with space. Login aborted.");
                return;
            }

            int userTypeID = user.UserTypeID;

            if (userTypeID == 0)
            {
                DebugLogger.LogWithStackTrace("userTypeID is 0. Login aborted.");
                return;
            }

            string userType = user.UserType;

            if (string.IsNullOrWhiteSpace(userType))
            {
                DebugLogger.LogWithStackTrace("userType is null or whitespace. Login aborted.");
                return;
            }

            if (ValueChecker.HasSpaceStartEnd(userType))
            {
                DebugLogger.LogWithStackTrace("userType starts or ends with space. Login aborted.");
                return;
            }

            StoreLoginCredentials(user);
            ControlValResetter.ClearFields();
            ControlValResetter.ClearProviders();
            ErrorCollection.Clear();
            ErrorUICollection.Clear();

            MainForm mainForm = new MainForm();
            PopulateReferencesForUser();

            if (userTypeID == 1)
            {
                AddAircraft addAircraft = new AddAircraft();
                SANavigation saNavigation = new SANavigation();

                addAircraft.Init(mainForm);
                MainForm.Init(addAircraft, saNavigation);
                mainForm.Show();
                LoginForm.HideForm();
            }
            else if (userTypeID == 2)
            {

            }
        }
        // End of logging actions

    }
}
