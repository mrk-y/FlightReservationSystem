using FlightReservationSystem.Helpers;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Data.Runtime.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightReservationSystem.UserControls.SystemAdmin;
using FlightReservationSystem.Debugging;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Text.Json;

namespace FlightReservationSystem.Services
{
    internal class CrewManagement
    {
        public static void AddSelectedCrew(AssignCrews assignCrews)
        {
            if (assignCrews._cmbCrewVal.Items.Count == 0) ErrorManager.AddError(new ErrorRecord { Message = "No crew left in the selection.", AssociatedControls = { AssignCrews._lblCrew } });
            else if (assignCrews._cmbCrewVal.SelectedIndex == -1) ErrorManager.AddError(new ErrorRecord { Message = "No crew selected in the selection.", AssociatedControls = { AssignCrews._lblCrew } });

            if (ErrorManager.GetErrorCollection.Count != 0)
            {
                ErrorManager.ShowAlert();
                ErrorManager.HighlightErrors(true);
                return;
            }

            var crewCollection = AircraftManager.GetCrewCollection;

            if (crewCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("crewCollection is empty. Adding selected crew aborted.");
                return;
            }

            var selectedCrewValue = assignCrews._cmbCrewVal.SelectedValue;

            for (int i = 0; i < crewCollection.Count; i++)
            {
                var crewRecord = crewCollection[i];

                if (selectedCrewValue is int crewVal && crewRecord.ID == crewVal)
                {
                    if (crewRecord.CrewTypeID == 1)
                    {
                        if (assignCrews.IsDGVFilledUp("dgvPilotsVal"))
                        {
                            MessageBoxHelper.ShowInformationMessage("Maximum pilot count already reached.");
                            return;
                        }
                        else assignCrews._dgvPilotsVal.Rows.Add($"{crewRecord.ID:0000}", crewRecord.LastName, crewRecord.FirstName, crewRecord.MiddleName, crewRecord.Birthdate.Date.ToString("yyyy-MM-dd"), crewRecord.Gender);
                    }
                    else if (crewRecord.CrewTypeID == 2)
                    {
                        if (assignCrews.IsDGVFilledUp("dgvFlightAttendantsVal"))
                        {
                            MessageBoxHelper.ShowInformationMessage("Maximum flight attendant count already reached.");
                            return;
                        }
                        else assignCrews._dgvFlightAttendantsVal.Rows.Add($"{crewRecord.ID:0000}", crewRecord.LastName, crewRecord.FirstName, crewRecord.MiddleName, crewRecord.Birthdate.Date.ToString("yyyy-MM-dd"), crewRecord.Gender);
                    }

                    assignCrews.ApplyCrewCMBData();
                    return;
                }
            }
        }

        public static void AddCrew(string id, string lastName, string firstName, string middleName, DateTime birthdate, string gender, int type, AssignCrews assignCrews)
        {
            string birthdateStr = birthdate.ToString("yyyy-MM-dd");

            if (type == 1)
            {
                if (assignCrews.IsDGVFilledUp("dgvPilotsVal"))
                {
                    MessageBoxHelper.ShowInformationMessage("Maximum pilot count already reached.");
                    return;
                }
                else assignCrews._dgvPilotsVal.Rows.Add(id, lastName, firstName, middleName, birthdateStr, gender);
            }
            else if (type == 2)
            {
                if (assignCrews.IsDGVFilledUp("dgvFlightAttendantsVal"))
                {
                    MessageBoxHelper.ShowInformationMessage("Maximum flight attendant count already reached.");
                    return;
                }
                else assignCrews._dgvFlightAttendantsVal.Rows.Add(id, lastName, firstName, middleName, birthdateStr, gender);
            }

            AircraftManager.AddCrew(new CrewRecord
            {
                ID = Convert.ToInt32(id),
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                Birthdate = birthdate,
                Gender = gender,
                CrewTypeID = type,
                Status = 1
            });

            assignCrews.ApplyCrewCMBData();
            assignCrews._lblCrewIDVal.Text = $"{(Convert.ToInt32(assignCrews._lblCrewIDVal.Text) + 1):0000}";
            ErrorManager.DefaultValueSpecificField("tbLastNameVal");
            ErrorManager.DefaultValueSpecificField("tbFirstNameVal");
            ErrorManager.DefaultValueSpecificField("tbMiddleNameVal");
            ErrorManager.DefaultValueSpecificField("dtpBirthdateVal");
            ErrorManager.DefaultValueSpecificField("cmbGenderVal");
            ErrorManager.DefaultValueSpecificField("cmbTypeVal");
            return;
        }

        public static void RemoveSelectedRows(AssignCrews assignCrews)
        {
            for (int i = assignCrews._dgvPilotsVal.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = assignCrews._dgvPilotsVal.SelectedRows[i];
                assignCrews._dgvPilotsVal.Rows.Remove(row);
            }

            for (int i = assignCrews._dgvFlightAttendantsVal.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = assignCrews._dgvFlightAttendantsVal.SelectedRows[i];
                assignCrews._dgvFlightAttendantsVal.Rows.Remove(row);
            }

            assignCrews.ApplyCrewCMBData();
        }

        public static void AssignCrewsToAircraft(AssignCrews assignCrews)
        {
            var crewCollection = AircraftManager.GetCrewCollection;

            if (crewCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("crewCollection is empty. Assigning crews aborted.");
                return;
            }

            using (SqlConnection con = DatabaseConnection.Get())
            {
                con.Open();

                for (int i = 0; i < crewCollection.Count; i++)
                {
                    var crewRecord = crewCollection[i];

                    try
                    {
                        string sql = "IF NOT EXISTS (SELECT 1 FROM Crews WHERE CrewID = @CrewID) " +
                                    "BEGIN " +
                                    "INSERT INTO Crews (CrewID, LastName, FirstName, MiddleName, Birthdate, Gender, CrewType, Status) " +
                                    "VALUES (@CrewID, @LastName, @FirstName, @MiddleName, @Birthdate, @Gender, @CrewType, @Status) " +
                                    "END ";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@CrewID", crewRecord.ID);
                            cmd.Parameters.AddWithValue("@LastName", crewRecord.LastName);
                            cmd.Parameters.AddWithValue("@FirstName", crewRecord.FirstName);
                            cmd.Parameters.AddWithValue("@MiddleName", crewRecord.MiddleName);
                            cmd.Parameters.AddWithValue("@Birthdate", crewRecord.Birthdate);
                            cmd.Parameters.AddWithValue("@Gender", crewRecord.Gender);
                            cmd.Parameters.AddWithValue("@CrewType", crewRecord.CrewTypeID);
                            cmd.Parameters.AddWithValue("@Status", 2);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        DebugLogger.LogWithStackTrace($"{ex.Message}. Assigning crews aborted.");
                        return;
                    }
                }
            }

            List<int> crewIDs = new List<int>();

            for (int i = 0; i < assignCrews._dgvPilotsVal.Rows.Count; i++)
            {
                DataGridViewRow row = assignCrews._dgvPilotsVal.Rows[i];
                int crewID = Convert.ToInt32(row.Cells[0].Value);
                crewIDs.Add(crewID);
            }

            for (int i = 0; i < assignCrews._dgvFlightAttendantsVal.Rows.Count; i++)
            {
                DataGridViewRow row = assignCrews._dgvFlightAttendantsVal.Rows[i];
                int crewID = Convert.ToInt32(row.Cells[0].Value);
                crewIDs.Add(crewID);
            }

            string crewsIDString = JsonSerializer.Serialize(crewIDs);
            int selectedAircraftValue = assignCrews._cmbAircraftVal.SelectedValue is int aircraftVal ? aircraftVal : 0;

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Aircrafts " +
                        "SET AssignedCrews = @AssignedCrews, " +
                        "Status = 2 " +
                        "WHERE IsActive = 1 AND " +
                        "Status = 1 AND " +
                        "AircraftID = @AircraftID ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@AssignedCrews", crewsIDString);
                        cmd.Parameters.AddWithValue("@AircraftID", selectedAircraftValue);

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Assigning crews aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while assigning crews.");
                    return;
                }
            }

            MessageBoxHelper.ShowSuccessMessage("Crews assigned successfully.");
            ErrorManager.DefaultValueFields();
            DataSeeder.PopulateAircraftStat1();
            assignCrews.ApplyCrewCMBData();
        }
    }
}
