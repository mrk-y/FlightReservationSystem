using FlightReservationSystem.SystemAdmin;
using FlightReservationSystem.UserControls;
using Microsoft.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    internal class Global
    {
        public static string connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public MainForm mainForm = new MainForm();
        public static string userID = "";
        public static string userName = "";
        public static string userPass = "";
        public static string userType = "";
        public static Dictionary<int, Dictionary<string, object>> aircraftModels = new Dictionary<int, Dictionary<string, object>>();
        public static Dictionary<int, Dictionary<string, Dictionary<string, object>>> aircraftModelsSeatClasses = new Dictionary<int, Dictionary<string, Dictionary<string, object>>>();
        public static Dictionary<int, Dictionary<string, object>> airports = new Dictionary<int, Dictionary<string, object>>();
        public static Dictionary<int, Dictionary<string, object>> airlines = new Dictionary<int, Dictionary<string, object>>();

        public static void AddBottomBorderHeader(Control parent, string name)
        {
            Control ctr = parent.Controls[name] as Control;
            Panel bottomBorder = new Panel();

            bottomBorder.Height = 1;
            bottomBorder.Dock = DockStyle.Bottom;
            bottomBorder.BackColor = Color.Black;
            ctr.Controls.Add(bottomBorder);
        } 

        public static Bitmap ResizeImgRelativeToBtn(Image img, Button btn)
        {
            double scaleW = (double)btn.Width / img.Width;
            double scaleH = (double)btn.Height / img.Height;
            double scale = Math.Min(scaleW, scaleH);

            int newWidth = (int)(img.Width * scale);
            int newHeight = (int)(img.Height * scale);

            return new Bitmap(img, new Size(newWidth, newHeight));
        }

        public static void RestartInfoOfModule(Control parent)
        {
            foreach (Control ctr in parent.Controls)
            {
                if (ctr is TextBox tb)
                {
                    tb.Clear();
                } 
                if (ctr.HasChildren)
                {
                    RestartInfoOfModule(ctr);
                }
            }
        }

        public static void PopulateAircraftModels()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT AircraftModelID, AircraftModel, TotalSeats " +
                        "FROM AircraftModels " +
                        "WHERE IsActive = 1 ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dbAircraftModelID = reader.GetInt32(0);
                                string dbAircraftModel = reader.GetString(1);
                                int dbTotalSeats = reader.GetInt32(2);

                                Dictionary<string, object> dict = new Dictionary<string, object>();
                                dict.Add("Model", dbAircraftModel);
                                dict.Add("Total Seats", dbTotalSeats);
                                aircraftModels.Add(dbAircraftModelID, dict);
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void PopulateSeatClasses()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT AircraftModelID, SeatClasses " +
                        "FROM AircraftModels " +
                        "WHERE IsActive = 1 ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dbAircraftModelID = reader.GetInt32(0);
                                string dbSeatClasses = reader.GetString(1);

                                var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(dbSeatClasses);
                                aircraftModelsSeatClasses.Add(dbAircraftModelID, dict);
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void PopulateAirports()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT AirportID, Airport, Place, ICAOCode, IATACode, Latitude, Longitude " +
                        "FROM Airports " +
                        "WHERE IsActive = 1 ";
                    using (SqlCommand cmd = new SqlCommand (sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dbAirportID = reader.GetInt32(0);
                                string dbAirport = reader.GetString(1);
                                string dbPlace = reader.GetString(2);
                                string dbICAOCode = reader.GetString(3);
                                string dbIATACode = reader.GetString(4);
                                double dbLatitude = reader.GetDouble(5);
                                double dbLongitude = reader.GetDouble(6);

                                Dictionary<string, object> dict = new Dictionary<string, object>();
                                dict.Add("Airport", dbAirport);
                                dict.Add("Place", dbPlace);
                                dict.Add("ICAO", dbICAOCode);
                                dict.Add("IATA", dbIATACode);
                                dict.Add("Latitude", dbLatitude);
                                dict.Add("Longitude", dbLongitude);

                                airports.Add(dbAirportID, dict);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void PopulateAirlines()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT AirlineID, Airline " +
                        "FROM Airlines " +
                        "WHERE IsActive = 1 ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader =  cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dbAirlineID = reader.GetInt32(0);
                                string dbAirline = reader.GetString(1);

                                Dictionary<string, object> dict = new Dictionary<string, object>();
                                dict.Add("Airline", dbAirline);
                                airlines.Add(dbAirlineID, dict);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
