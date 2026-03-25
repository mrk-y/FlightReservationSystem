using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Data.Reference.Seat;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                        "acmdl.SeatLayout AS acmdl_SeatLayout " +
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
                                List<SeatLayoutRecord> db_acmdl_SeatLayout = JsonSerializer.Deserialize<List<SeatLayoutRecord>>(reader.GetString(reader.GetOrdinal("acmdl_SeatLayout")));

                                if (!AircraftModelRecord.ID_Try(db_acmdl_ModelID) || !AircraftModelRecord.Model_Try(db_acmdl_Model) ||
                                    !AircraftModelRecord.TotalSeats_Try(db_acmdl_TotalSeats) || !AircraftModelRecord.SeatLayoutCollection_Try(db_acmdl_SeatLayout))
                                {
                                    DebugLogger.LogWithStackTrace("Wrong value from AircraftModels Table DB. Populating aborted.");
                                    return;
                                }

                                AircraftModelCollection.Add(new AircraftModelRecord
                                {
                                    ID = db_acmdl_ModelID,
                                    Model = db_acmdl_Model,
                                    TotalSeats = db_acmdl_TotalSeats,
                                    SeatLayoutCollection = db_acmdl_SeatLayout
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

                                if (!AirlineRecord.ID_Try(db_al_AirlineID) || !AirlineRecord.IATA_Try(db_al_IATA) || 
                                    !AirlineRecord.ICAO_Try(db_al_ICAO) || !AirlineRecord.Callsign_Try(db_al_Callsign) ||
                                    !AirlineRecord.AirlineName_Try(db_al_Airline)) {
                                    DebugLogger.LogWithStackTrace("Wrong value from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                AirlineCollection.Add(new AirlineRecord
                                {
                                    ID = db_al_AirlineID,
                                    IATA = db_al_IATA,
                                    ICAO = db_al_ICAO,
                                    Callsign = db_al_Callsign,
                                    AirlineName = db_al_Airline
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
                                string db_ap_Category = reader.GetString(reader.GetOrdinal("ap_Category"));
                                string db_ap_CriticalAircraft = reader.GetString(reader.GetOrdinal("ap_CriticalAircraft"));

                                if (!AirportRecord.ID_Try(db_ap_AirportID) || !AirportRecord.IATA_Try(db_ap_IATA) || 
                                    !AirportRecord.ICAO_Try(db_ap_ICAO) || !AirportRecord.AirportName_Try(db_ap_Airport) || 
                                    !AirportRecord.Location_Try(db_ap_Location) || !AirportRecord.DisplayCity_Try(db_ap_DisplayCity) ||
                                    !AirportRecord.Latitude_Try(db_ap_Latitude) || !AirportRecord.Longitude_Try(db_ap_Longitude) || 
                                    !AirportRecord.Category_Try(db_ap_Category) || !AirportRecord.CriticalAircraft_Try(db_ap_CriticalAircraft))
                                {
                                    DebugLogger.LogWithStackTrace("Wrong value from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                AirportCollection.Add(new AirportRecord
                                {
                                    ID = db_ap_AirportID,
                                    IATA = db_ap_IATA,
                                    ICAO = db_ap_ICAO,
                                    AirportName = db_ap_Airport,
                                    Location = db_ap_Location,
                                    DisplayCity = db_ap_DisplayCity,
                                    Latitude = db_ap_Latitude,
                                    Longitude = db_ap_Longitude,
                                    Category = db_ap_Category,
                                    CriticalAircraft = db_ap_CriticalAircraft
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

                                if (!SeatRecord.ID_Try(db_st_SeatID) || !SeatRecord.Code_Try(db_st_Code) ||
                                    !SeatRecord.SeatType_Try(db_st_Seat))
                                {
                                    DebugLogger.LogWithStackTrace("Wrong value from SeatTypes Table DB. Populating aborted.");
                                    return;
                                }

                                SeatCollection.Add(new SeatRecord
                                {
                                    ID = db_st_SeatID,
                                    Code = db_st_Code,
                                    SeatType = db_st_Seat
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
