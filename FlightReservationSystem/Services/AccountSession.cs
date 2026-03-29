using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Data.Runtime.User;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.AircraftModelsUI;
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

                                UserManager.AddUser(new User
                                {
                                    ID = db_UserID,
                                    Name = db_u_Name,
                                    Password = db_u_Password,
                                    TypeID = db_ut_UserTypeID,
                                    TypeName = db_ut_Type
                                });

                                if (!UserManager.VerifyPassword(password, UserManager.GetUser.Password))
                                {
                                    ErrorManager.AddError(new ErrorRecord { Message = "Incorrect password.", AssociatedControls = { LoginForm._lblPassword } });
                                    ErrorManager.ShowAlert();
                                    ErrorManager.HighlightErrors(true);
                                    ErrorManager.DefaultValueSpecificField("tbPasswordVal");
                                }
                                else
                                {
                                    MessageBoxHelper.ShowSuccessMessage("Account found. Logging in...");
                                    LoginAccount();
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

        public static void PopulateReferencesForUser()
        {
            int userTypeID = UserManager.GetUser.TypeID;

            if (userTypeID == 1)
            {
                DataSeeder.PopulateAircraftModels();
                DataSeeder.PopulateAirlines();
                DataSeeder.PopulateAirports();
                DataSeeder.PopulateSeatTypes();
                DataSeeder.PopulateTerminals();
            }
        }

        private static void LoginAccount() // TODO: Complete the RA part
        {
            ErrorManager.ClearErrorCollection();
            ErrorManager.ClearErrorUICollection();

            MainForm mainForm = new MainForm();
            int userTypeID = UserManager.GetUser.TypeID;

            PopulateReferencesForUser();

            if (userTypeID == 1)
            {
                AddAircraft addAircraft = new AddAircraft();
                SANavigation saNavigation = new SANavigation();

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
