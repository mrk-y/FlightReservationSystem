using FlightReservationSystem.Data.Reference.AircraftModel;
using FlightReservationSystem.Data.Reference.Airline;
using FlightReservationSystem.Data.Reference.Airport;
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
                        "WHERE IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_acmdl_modelID = reader.GetInt32(reader.GetOrdinal("acmdl_ModelID"));

                                if (db_acmdl_modelID == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_acmdl_modelID is 0 from AircraftModels Table DB. Populating aborted.");
                                    return;
                                }

                                string db_acmdl_model = reader.GetString(reader.GetOrdinal("acmdl_Model"));

                                if (string.IsNullOrWhiteSpace(db_acmdl_model))
                                {
                                    DebugLogger.LogWithStackTrace("db_acmdl_model is null or whitespace from AircraftModels Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_acmdl_model))
                                {
                                    DebugLogger.LogWithStackTrace("db_acmdl_model starts or ends with space from AircraftModels Table DB. Populating aborted.");
                                    return;
                                }

                                int db_acmdl_totalSeats = reader.GetInt32(reader.GetOrdinal("acmdl_TotalSeats"));

                                if (db_acmdl_totalSeats == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_acmdl_totalSeats is 0 from AircraftModels Table DB. Populating aborted.");
                                    return;
                                }

                                string db_acmdl_seatLayout = reader.GetString(reader.GetOrdinal("acmdl_SeatLayout"));
                                
                                if (string.IsNullOrWhiteSpace(db_acmdl_seatLayout))
                                {
                                    DebugLogger.LogWithStackTrace("db_acmdl_seatLayout is null or whitespace from AircraftModels Table DB. Populating aborted.");
                                    return;
                                }

                                List<SeatLayoutRecord> seatLayoutRecordList = JsonSerializer.Deserialize<List<SeatLayoutRecord>>(db_acmdl_seatLayout);

                                if (seatLayoutRecordList == null)
                                {
                                    DebugLogger.LogWithStackTrace("seatLayoutRecordList is null. Populating aborted.");
                                    return;
                                }

                                if (seatLayoutRecordList.Count == 0)
                                {
                                    DebugLogger.LogWithStackTrace("seatLayoutRecordList is empty. Populating aborted.");
                                    return;
                                }

                                for (int i = 0; i < seatLayoutRecordList.Count; i++)
                                {
                                    var seatLayoutRecord = seatLayoutRecordList[i];

                                    if (seatLayoutRecord == null)
                                    {
                                        DebugLogger.LogWithStackTrace($"seatLayoutRecord {i} is null. Populating aborted.");
                                        return;
                                    }

                                    string className = seatLayoutRecord.ClassName;

                                    if (string.IsNullOrWhiteSpace(className))
                                    {
                                        DebugLogger.LogWithStackTrace($"className {i} is null or whitespace. Populating aborted.");
                                        return;
                                    }

                                    if (ValueChecker.HasSpaceStartEnd(className))
                                    {
                                        DebugLogger.LogWithStackTrace($"className {i} starts or ends with space. Populating aborted.");
                                        return;
                                    }

                                    if (seatLayoutRecord.SeatCount == 0)
                                    {
                                        DebugLogger.LogWithStackTrace($"seatLayoutRecord.SeatCount {i} is 0. Populating aborted.");
                                        return;
                                    }

                                    string arrangement = seatLayoutRecord.Arrangement;

                                    if (string.IsNullOrWhiteSpace(arrangement))
                                    {
                                        DebugLogger.LogWithStackTrace($"arrangement {i} is null or whitespace. Populating aborted.");
                                        return;
                                    }

                                    if (ValueChecker.HasSpaceStartEnd(arrangement))
                                    {
                                        DebugLogger.LogWithStackTrace($"arrangement {i} starts or ends with space. Populating aborted.");
                                        return;
                                    }
                                }

                                AircraftModelCollection.Add(new AircraftModelRecord { ID = db_acmdl_modelID, Model = db_acmdl_model, TotalSeats = db_acmdl_totalSeats, SeatLayoutCollection = seatLayoutRecordList });
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
                        "WHERE IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_al_airlineID = reader.GetInt32(reader.GetOrdinal("al_AirlineID"));

                                if (db_al_airlineID == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_al_airlineID is 0 from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                string db_al_iata = reader.GetString(reader.GetOrdinal("al_IATA"));

                                if (string.IsNullOrWhiteSpace(db_al_iata))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_iata is null or whitespace from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_al_iata))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_iata starts or ends with space from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                string db_al_icao = reader.GetString(reader.GetOrdinal("al_ICAO"));

                                if (string.IsNullOrWhiteSpace(db_al_icao))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_icao is null or whitespace from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_al_icao))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_icao starts or ends with space from Airlines Table Db. Populating aborted.");
                                    return;
                                }

                                string db_al_callsign = reader.GetString(reader.GetOrdinal("al_Callsign"));

                                if (string.IsNullOrWhiteSpace(db_al_callsign))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_callsign is null or whitespace from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_al_callsign))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_callsign starts or ends with space from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                string db_al_airline = reader.GetString(reader.GetOrdinal("al_Airline"));

                                if (string.IsNullOrWhiteSpace(db_al_airline))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_airline is null or whitespace from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_al_airline))
                                {
                                    DebugLogger.LogWithStackTrace("db_al_airline starts or ends with space from Airlines Table DB. Populating aborted.");
                                    return;
                                }

                                AirlineCollection.Add(new AirlineRecord { ID = db_al_airlineID , IATA = db_al_iata, ICAO = db_al_icao, Callsign = db_al_callsign, AirlineName = db_al_airline });
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
                        "WHERE IsActive = 1 ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int db_ap_AirportID = reader.GetInt32(reader.GetOrdinal("ap_AirportID"));

                                if (db_ap_AirportID == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_AirportID is 0 from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_iata = reader.GetString(reader.GetOrdinal("ap_IATA"));

                                if (string.IsNullOrWhiteSpace(db_ap_iata))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_iata is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ap_iata))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_iata starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_icao = reader.GetString(reader.GetOrdinal("ap_ICAO"));

                                if (string.IsNullOrWhiteSpace(db_ap_icao))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_icao is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ap_icao))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_icao starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_airport = reader.GetString(reader.GetOrdinal("ap_Airport"));

                                if (string.IsNullOrWhiteSpace(db_ap_airport))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_airport is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ap_airport))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_airport starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_location = reader.GetString(reader.GetOrdinal("ap_Location"));

                                if (string.IsNullOrWhiteSpace(db_ap_location))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_location is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ap_location))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_location starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_displayCity = reader.GetString(reader.GetOrdinal("ap_DisplayCity"));

                                if (string.IsNullOrWhiteSpace(db_ap_displayCity))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_displayCity is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }
                                
                                if (ValueChecker.HasSpaceStartEnd(db_ap_displayCity))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_displayCity starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                double db_ap_latitude = reader.GetDouble(reader.GetOrdinal("ap_Latitude"));
                                
                                if (double.IsNaN(db_ap_latitude))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_latitude is NaN from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (db_ap_latitude == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_latitude is 0 from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                double db_ap_longitude = reader.GetDouble(reader.GetOrdinal("ap_Longitude"));

                                if (double.IsNaN(db_ap_longitude))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_longitude is NaN from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (db_ap_longitude == 0)
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_longitude is 0 from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_category = reader.GetString(reader.GetOrdinal("ap_Category"));

                                if (string.IsNullOrWhiteSpace(db_ap_category))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_category is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ap_category))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_category starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                string db_ap_criticalAircraft = reader.GetString(reader.GetOrdinal("ap_CriticalAircraft"));
                                
                                if (string.IsNullOrWhiteSpace(db_ap_criticalAircraft))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_criticalAircraft is null or whitespace from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                if (ValueChecker.HasSpaceStartEnd(db_ap_criticalAircraft))
                                {
                                    DebugLogger.LogWithStackTrace("db_ap_criticalAircraft starts or ends with space from Airports Table DB. Populating aborted.");
                                    return;
                                }

                                AirportCollection.Add(new AirportRecord { ID = db_ap_AirportID, IATA = db_ap_iata, ICAO = db_ap_icao, AirportName = db_ap_airport, Location = db_ap_location, DisplayCity = db_ap_displayCity,
                                    Latitude = db_ap_latitude, Longitude = db_ap_longitude, Category = db_ap_category, CriticalAircraft = db_ap_criticalAircraft });
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
