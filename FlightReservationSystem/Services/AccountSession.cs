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

        // >> Start of LoginAccount
        public static void AuthenticateLogin(string userID, string password)
        {
            if (!ValueChecker.IsStringValid(userID, nameof(userID)))
            {
                DebugLogger.LogWithStackTrace("userID invalid value. Login authentication aborted.");
                return;
            }   

            if (!ValueChecker.IsStringValid(password, nameof(password)))
            {
                DebugLogger.LogWithStackTrace("password invalid value. Login authentication aborted.");
                return;
            }

            string prefix = userID.Substring(0, 2);
            string uCode = userID.Substring(3, 4);

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
                                string db_UserID = DataFormatter.UserIDFormat(reader.GetString(reader.GetOrdinal("ut_Prefix")), reader.GetInt32(reader.GetOrdinal("u_Code")));
                                string db_u_Name = reader.GetString(reader.GetOrdinal("u_Name"));
                                string db_u_Password = reader.GetString(reader.GetOrdinal("u_Password"));
                                int db_ut_UserTypeID = reader.GetInt32(reader.GetOrdinal("ut_UserTypeID"));
                                string db_ut_Type = reader.GetString(reader.GetOrdinal("ut_Type"));

                                if (!User.UserID_Try(db_UserID) || !User.Name_Try(db_u_Name) ||
                                    !User.HashedPassword_Try(db_u_Password) || !User.UserTypeID_Try(db_ut_UserTypeID) ||
                                    !User.UserType_Try(db_ut_Type))
                                {
                                    DebugLogger.LogWithStackTrace("Wrong value from Users or UserTypes Table DB. Authentication aborted.");
                                    return;
                                }

                                User user = new User();
                                user.UserID = db_UserID;
                                user.Name = db_u_Name;
                                user.HashedPassword = db_u_Password;
                                user.UserTypeID = db_ut_UserTypeID;
                                user.UserType = db_ut_Type;

                                if (!PasswordHelper.VerifyPassword(password, user.HashedPassword))
                                {
                                    ErrorManager.AddError(new ErrorRecord { Message = "Incorrect password.", AssociatedControls = { LoginForm._lblPassword } });
                                    ErrorManager.ShowAlert();
                                    ErrorManager.HighlightErrors(true);
                                    ErrorManager.DefaultValueSpecificField("tbPasswordVal");
                                }
                                else
                                {
                                    MessageBoxHelper.ShowSuccessMessage("Account found. Logging in...");
                                    LoginAccount(user);
                                }
                            }
                            else
                            {
                                ErrorManager.AddError(new ErrorRecord { Message = "There is no account with the provided User ID.", AssociatedControls = { LoginForm._lblUserID } });
                                ErrorManager.ShowAlert();
                                ErrorManager.HighlightErrors(true);
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
                DataSeeder.PopulateSeatTypes();
            }
        }

        private static void LoginAccount(User user) // TODO: Complete the RA part
        {
            StoreLoginCredentials(user);
            ErrorManager.ClearFields();
            ErrorManager.ClearProviders();
            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();

            MainForm mainForm = new MainForm();
            int userTypeID = user.UserTypeID;

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
        // << End of LoginAccount

    }
}
