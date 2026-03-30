using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Data.Reference.SeatType;
using FlightReservationSystem.Data.Runtime.Aircraft;
using FlightReservationSystem.Data.Runtime.Crew;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationSystem.Data.Reference.ControlItem;
using FlightReservationSystem.Data.Runtime.Gate;

namespace FlightReservationSystem.Helpers
{
    internal class DataSeeder
    {
        public static void PopulateAircraftModels()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT acmdl.ModelID AS acmdl_ModelID, " +
                        "acmdl.Model AS acmdl_Model, " +
                        "acmdl.TotalSeats AS acmdl_TotalSeats, " +
                        "acmdl.SeatLayout AS acmdl_SeatLayout, " +
                        "acmdl.SpeedKMH AS acmdl_SpeedKMH," +
                        "acmdl.FACount AS acmdl_FACount " +
                        "FROM AircraftModels acmdl " +
                        "WHERE acmdl.IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_acmdl_ModelID = reader.GetInt32(reader.GetOrdinal("acmdl_ModelID"));
                                string db_acmdl_Model = reader.GetString(reader.GetOrdinal("acmdl_Model"));
                                int db_acmdl_TotalSeats = reader.GetInt32(reader.GetOrdinal("acmdl_TotalSeats"));
                                int db_acmdl_SpeedKMH = reader.GetInt32(reader.GetOrdinal("acmdl_SpeedKMH"));
                                int db_acmdl_FACount = reader.GetInt32(reader.GetOrdinal("acmdl_FACount"));

                                AircraftManager.AddAircraftModel(new AircraftModelRecord
                                {
                                    ID = db_acmdl_ModelID,
                                    Name = db_acmdl_Model,
                                    TotalSeats = db_acmdl_TotalSeats,
                                    Speed = db_acmdl_SpeedKMH,
                                    FlightAttenantsCount = db_acmdl_FACount
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while populating data.");
                    return;
                }
            }
        }

        public static void PopulateAirlines()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT al.AirlineID AS al_AirlineID, " +
                        "al.IATA AS al_IATA, " +
                        "al.ICAO AS al_ICAO, " +
                        "al.Callsign AS al_Callsign, " +
                        "al.Airline AS al_Airline " +
                        "FROM Airlines al " +
                        "WHERE al.IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_al_AirlineID = reader.GetInt32(reader.GetOrdinal("al_AirlineID"));
                                string db_al_IATA = reader.GetString(reader.GetOrdinal("al_IATA"));
                                string db_al_ICAO = reader.GetString(reader.GetOrdinal("al_ICAO"));
                                string db_al_Callsign = reader.GetString(reader.GetOrdinal("al_Callsign"));
                                string db_al_Airline = reader.GetString(reader.GetOrdinal("al_Airline"));

                                AirlineManager.AddAirline(new AirlineRecord
                                {
                                    ID = db_al_AirlineID,
                                    IATA = db_al_IATA,
                                    ICAO = db_al_ICAO,
                                    Callsign = db_al_Callsign,
                                    Name = db_al_Airline
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occurred while populating data.");
                    return;
                }
            }
        }

        public static void PopulateAirports()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT ap.AirportID AS ap_AirportID, " +
                        "ap.IATA AS ap_IATA, " +
                        "ap.ICAO AS ap_ICAO, " +
                        "ap.Airport AS ap_Airport, " +
                        "ap.Location AS ap_Location, " +
                        "ap.DisplayCity AS ap_DisplayCity, " +
                        "ap.Latitude AS ap_Latitude, " +
                        "ap.Longitude AS ap_Longitude, " +
                        "ap.Category AS ap_Category, " +
                        "ap.CriticalAircraft AS ap_CriticalAircraft " +
                        "FROM Airports ap " +
                        "WHERE ap.IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_ap_AirportID = reader.GetInt32(reader.GetOrdinal("ap_AirportID"));
                                string db_ap_IATA = reader.GetString(reader.GetOrdinal("ap_IATA"));
                                string db_ap_ICAO = reader.GetString(reader.GetOrdinal("ap_ICAO"));
                                string db_ap_Airport = reader.GetString(reader.GetOrdinal("ap_Airport"));
                                string db_ap_Location = reader.GetString(reader.GetOrdinal("ap_Location"));
                                string db_ap_DisplayCity = reader.GetString(reader.GetOrdinal("ap_DisplayCity"));
                                double db_ap_Latitude = reader.GetDouble(reader.GetOrdinal("ap_Latitude"));
                                double db_ap_Longitude = reader.GetDouble(reader.GetOrdinal("ap_Longitude"));

                                AirportManager.AddAirport(new AirportRecord
                                {
                                    ID = db_ap_AirportID,
                                    IATA = db_ap_IATA,
                                    ICAO = db_ap_ICAO,
                                    Name = db_ap_Airport,
                                    Location = db_ap_Location,
                                    DisplayCity = db_ap_DisplayCity,
                                    Latitude = db_ap_Latitude,
                                    Longitude = db_ap_Longitude
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while populating data.");
                    return;
                }
            }
        }

        public static void PopulateSeatTypes()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT st.SeatID AS st_SeatID, " +
                        "st.Code AS st_Code, " +
                        "st.Seat AS st_Seat " +
                        "FROM SeatTypes st " +
                        "WHERE st.IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_st_SeatID = reader.GetInt32(reader.GetOrdinal("st_SeatID"));
                                string db_st_Code = reader.GetString(reader.GetOrdinal("st_Code"));
                                string db_st_Seat = reader.GetString(reader.GetOrdinal("st_Seat"));

                                AircraftManager.AddSeatType(new SeatTypeRecord
                                {
                                    ID = db_st_SeatID,
                                    Code = db_st_Code,
                                    Name = db_st_Seat
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while populating data.");
                    return;
                }
            }
        }

        public static void PopulateTerminals()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT tm.TerminalID AS tm_TerminalID, " +
                        "tm.TerminalNo AS tm_TerminalNo, " +
                        "tm.Classification AS tm_Classification, " +
                        "tm.Gates AS tm_Gates, " +
                        "tm.Airport AS tm_Airport, " +
                        "tm.Status AS tm_Status " +
                        "FROM Terminals tm " +
                        "WHERE tm.IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_tm_TerminalID = reader.GetInt32(reader.GetOrdinal("tm_TerminalID"));
                                int db_tm_TerminalNo = reader.GetInt32(reader.GetOrdinal("tm_TerminalNo"));
                                string db_tm_Classification = reader.GetString(reader.GetOrdinal("tm_Classification"));
                                List<GateRecord> db_tm_Gates = JsonSerializer.Deserialize<List<GateRecord>>(reader.GetString(reader.GetOrdinal("tm_Gates")));
                                int db_tm_Airport = reader.GetInt32(reader.GetOrdinal("tm_Airport"));
                                int db_tm_Status = reader.GetInt32(reader.GetOrdinal("tm_Status"));
                                
                                TerminalManager.AddTerminal(new TerminalRecord
                                {
                                    ID = db_tm_TerminalID,
                                    Number = db_tm_TerminalNo,
                                    Classification = db_tm_Classification,
                                    Gates = db_tm_Gates,
                                    AirportID = db_tm_Airport,
                                    Status = db_tm_Status,
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while populating data.");
                    return;
                }
            }
        }

        public static void PopulateAircraftStat1()
        {
            AircraftManager.ClearAircraftCollection();

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT ac.AircraftID AS ac_AircraftID, " +
                        "ac.Aircraft AS ac_Aircraft," +
                        "ac.Model AS ac_Model, " +
                        "ac.Airline AS ac_Airline, " +
                        "ac.Airport AS ac_Airport, " +
                        "ac.Status AS ac_Status " +
                        "FROM Aircrafts ac " +
                        "WHERE ac.IsActive = 1 AND " +
                        "ac.Status = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader =  cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_ac_AircraftID = reader.GetInt32(reader.GetOrdinal("ac_AircraftID"));
                                string db_ac_Aircraft = reader.GetString(reader.GetOrdinal("ac_Aircraft"));
                                int db_ac_Model = reader.GetInt32(reader.GetOrdinal("ac_Model"));
                                int db_ac_Airline = reader.GetInt32(reader.GetOrdinal("ac_Airline"));
                                int db_ac_Airport = reader.GetInt32(reader.GetOrdinal("ac_Airport"));
                                int db_ac_Status = reader.GetInt32(reader.GetOrdinal("ac_Status"));

                                AircraftManager.AddAircraftStat1(new AircraftRecord
                                {
                                    ID = db_ac_AircraftID,
                                    Name = db_ac_Aircraft,
                                    ModelID = db_ac_Model,
                                    AirlineID = db_ac_Airline,
                                    AirportID = db_ac_Airport,
                                    Status = db_ac_Status
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpedted error occured while populating data.");
                    return;
                }
            }
        }

        public static void PopulateAircraftStat2()
        {
            AircraftManager.ClearAircraftCollection();

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT ac.AircraftID AS ac_AircraftID, " +
                        "ac.Aircraft AS ac_Aircraft," +
                        "ac.Model AS ac_Model, " +
                        "ac.Airline AS ac_Airline, " +
                        "ac.Airport AS ac_Airport, " +
                        "ac.Status AS ac_Status " +
                        "FROM Aircrafts ac " +
                        "WHERE ac.IsActive = 1 AND " +
                        "ac.Status = 2 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_ac_AircraftID = reader.GetInt32(reader.GetOrdinal("ac_AircraftID"));
                                string db_ac_Aircraft = reader.GetString(reader.GetOrdinal("ac_Aircraft"));
                                int db_ac_Model = reader.GetInt32(reader.GetOrdinal("ac_Model"));
                                int db_ac_Airline = reader.GetInt32(reader.GetOrdinal("ac_Airline"));
                                int db_ac_Airport = reader.GetInt32(reader.GetOrdinal("ac_Airport"));
                                int db_ac_Status = reader.GetInt32(reader.GetOrdinal("ac_Status"));

                                AircraftManager.AddAircraftStat2(new AircraftRecord
                                {
                                    ID = db_ac_AircraftID,
                                    Name = db_ac_Aircraft,
                                    ModelID = db_ac_Model,
                                    AirlineID = db_ac_Airline,
                                    AirportID = db_ac_Airport,
                                    Status = db_ac_Status
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpedted error occured while populating data.");
                    return;
                }
            }
        }

        public static void PopulateCrewStat1()
        {
            AircraftManager.ClearCrewCollection();

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT c.CrewID AS c_CrewID, " +
                        "c.LastName AS c_LastName, " +
                        "c.FirstName AS c_FirstName, " +
                        "c.MiddleName AS c_MiddleName, " +
                        "c.Birthdate AS c_Birthdate, " +
                        "c.Gender AS c_Gender, " +
                        "c.CrewType AS c_CrewType, " +
                        "c.Status AS c_Status " +
                        "FROM Crews c " +
                        "WHERE IsActive = 1 AND " +
                        "Status = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_c_CrewID = reader.GetInt32(reader.GetOrdinal("c_CrewID"));
                                string db_c_LastName = reader.GetString(reader.GetOrdinal("c_LastName"));
                                string db_c_FirstName = reader.GetString(reader.GetOrdinal("c_FirstName"));
                                string db_c_MiddleName = reader.GetString(reader.GetOrdinal("c_MiddleName"));
                                DateTime db_c_Birthdate = reader.GetDateTime(reader.GetOrdinal("c_Birthdate"));
                                string db_c_Gender = reader.GetString(reader.GetOrdinal("c_Gender"));
                                int db_c_CrewType = reader.GetInt32(reader.GetOrdinal("c_CrewType"));
                                int db_c_Status = reader.GetInt32(reader.GetOrdinal("c_Status"));

                                AircraftManager.AddCrew(new CrewRecord
                                {
                                    ID = db_c_CrewID,
                                    LastName = db_c_LastName,
                                    FirstName = db_c_FirstName,
                                    MiddleName = db_c_MiddleName,
                                    Birthdate = db_c_Birthdate,
                                    Gender = db_c_Gender,
                                    CrewTypeID = db_c_CrewType,
                                    Status = db_c_Status
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Populating aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while populating data.");
                    return;
                }
            }
        }
    }
}
