using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Runtime.Crew;
using FlightReservationSystem.Data.Reference.CrewType;
using FlightReservationSystem.Data.Reference.SeatType;
using FlightReservationSystem.Data.Runtime.Aircraft;
using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class AircraftManager
    {
        public static string NewAircraftID()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT TOP 1 ac.AircraftID AS AircraftID " +
                        "FROM Aircrafts ac " +
                        "ORDER BY AircraftID DESC ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        object db_ac_AircraftID = cmd.ExecuteScalar();

                        if (db_ac_AircraftID == null)
                        {
                            DebugLogger.LogWithStackTrace("db_ac_AircraftID is null from Aircrafts Table DB. ID generation aborted.");
                            return "";
                        }
                        else return DataFormatter.AircraftIDFormat(Convert.ToInt32(db_ac_AircraftID) + 1);
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Generating ID aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occurred while generating ID.");
                    return "";
                }
            }
        }

        public static string NewCrewID()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT TOP 1 c.CrewID AS c_CrewID " +
                        "FROM Crews c " +
                        "ORDER BY CrewID DESC ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        object db_c_CrewID = cmd.ExecuteScalar();

                        if (db_c_CrewID == null)
                        {
                            DebugLogger.LogWithStackTrace("db_c_CrewID is null from Crews Table DB. ID generation aborted.");
                            return "";
                        }
                        else return $"{(Convert.ToInt32(db_c_CrewID) + 1):0000}";
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Generating ID aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while generating ID.");
                    return "";
                }
            }
        }

        public static void AddSeatType(SeatTypeRecord seatTypeRecord)
        {
            if (!SeatTypeRecord.ID_Try(seatTypeRecord.ID) || !SeatTypeRecord.Code_Try(seatTypeRecord.Code) ||
                !SeatTypeRecord.Name_Try(seatTypeRecord.Name))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            SeatTypeCollection.Add(seatTypeRecord);
        }

        public static void AddAircraftModel(AircraftModelRecord aircraftModelRecord)
        {
            if (!AircraftModelRecord.ID_Try(aircraftModelRecord.ID) || !AircraftModelRecord.Name_Try(aircraftModelRecord.Name) ||
                !AircraftModelRecord.TotalSeats_Try(aircraftModelRecord.TotalSeats) || !AircraftModelRecord.Speed_Try(aircraftModelRecord.Speed))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted." +
                    "");
                return;
            }

            AircraftModelCollection.Add(aircraftModelRecord);
        }

        public static void AddAircraft(AircraftRecord aircraftRecord)
        {
            if (!AircraftRecord.ID_Try(aircraftRecord.ID) || !AircraftRecord.Name_Try(aircraftRecord.Name) ||
                !AircraftRecord.BaseName_Try(aircraftRecord.BaseName) || !AircraftRecord.ModelID_Try(aircraftRecord.ModelID) ||
                !AircraftRecord.AirlineID_Try(aircraftRecord.AirlineID) || !AircraftRecord.AirportID_Try(aircraftRecord.AirportID) || 
                !AircraftRecord.SeatAssignments_Try(aircraftRecord.SeatAssignments) || !AircraftRecord.Status_Try(aircraftRecord.Status))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Addimg aborted.");
                return;
            }

            AircraftCollection.Add(aircraftRecord);
        }

        public static void AddAircraftStat1(AircraftRecord aircraftRecord)
        {
            if (!AircraftRecord.ID_Try(aircraftRecord.ID) || !AircraftRecord.Name_Try(aircraftRecord.Name) ||
                !AircraftRecord.AirlineID_Try(aircraftRecord.AirlineID) || !AircraftRecord.AirportID_Try(aircraftRecord.AirportID) ||
                !AircraftRecord.Status_Try(aircraftRecord.Status))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            AircraftCollection.Add(aircraftRecord);
        }

        public static void AddCrew(CrewRecord crewRecord)
        {
            if (!CrewRecord.ID_Try(crewRecord.ID) || !CrewRecord.LastName_Try(crewRecord.LastName) ||
                !CrewRecord.FirstName_Try(crewRecord.FirstName) || !CrewRecord.MiddleName_Try(crewRecord.MiddleName) ||
                !CrewRecord.Birthdate_Try(crewRecord.Birthdate) || !CrewRecord.Gender_Try(crewRecord.Gender) || 
                !CrewRecord.CrewTypeID_Try(crewRecord.CrewTypeID) || !CrewRecord.Status_Try(crewRecord.Status))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            CrewCollection.Add(crewRecord);
        }

        public static List<AircraftModelRecord> GetAircraftModelCollection => AircraftModelCollection.Get;

        public static List<AircraftModelUIRecord> GetAircraftModelUICollection => AircraftModelUICollection.Get;

        public static List<SeatTypeRecord> GetSeatTypeCollection => SeatTypeCollection.Get;

        public static List<SeatTypeUIRecord> GetSeatTypeUICollection => SeatTypeUICollection.Get;

        public static List<AircraftRecord> GetAircraftCollection => AircraftCollection.Get;

        public static List<CrewTypeRecord> GetCrewTypeCollection => CrewTypeCollection.Get;

        public static List<CrewRecord> GetCrewCollection => CrewCollection.Get;

        public static void ClearAircraftCollection() => AircraftCollection.Clear();

        public static void ClearCrewCollection() => CrewCollection.Clear();

        public static Bitmap SeatMapToImg(UserControl userControl)
        {
            Bitmap bmp = new Bitmap(userControl.Width, userControl.Height);
            userControl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            return bmp;
        }
    }
}
