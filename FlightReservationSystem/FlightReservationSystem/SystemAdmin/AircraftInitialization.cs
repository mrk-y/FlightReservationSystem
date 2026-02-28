using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FlightReservationSystem.SystemAdmin
{
    public partial class AircraftInitialization : UserControl
    {

        private string connection;

        public AircraftInitialization()
        {
            InitializeComponent();
            InitDate();
        }

        private void InitDate()
        {
            connection = Global.connection;
            PopulateAircraftModelSelection();
            PopulateAirportSelection();
            PopulateAirlineSelection();
            ShowNewAircraftID();
            UpdateAircraftName();
            UpdateTotalSeats();
        }

        private void PopulateAircraftModelSelection()
        {
            List<string> models = new List<string>();
            foreach (var model in Global.aircraftModels)
            {
                models.Add(model.Value["Model"].ToString());
            }
            cbModelVal.Items.AddRange(models.ToArray());

            cbModelVal.SelectedIndex = 0;
        }

        private void PopulateAirportSelection()
        {
            List<string> airports = new List<string>();
            foreach (var airport in Global.airports)
            {
                airports.Add(airport.Value["Airport"].ToString());
            }
            cbAirportVal.Items.AddRange(airports.ToArray());

            cbAirportVal.SelectedIndex = 0;
        }

        private void PopulateAirlineSelection()
        {
            List<string> airlines = new List<string>();
            foreach (var airline in Global.airlines)
            {
                airlines.Add(airline.Value["Airline"].ToString());
            }
            cbAirlineVal.Items.AddRange(airlines.ToArray());

            cbAirlineVal.SelectedIndex = 0;
        }

        private void ShowNewAircraftID()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT MAX(AircraftID) " +
                        "FROM Aircrafts ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        var result = cmd.ExecuteScalar();
                        int dbAircraftID = Convert.ToInt32(result);

                        lblIDVal.Text = $"RP-C{++dbAircraftID:0000}";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateAircraftName()
        {
            lblNameDisplayVal.Text = tbNameVal.Text;
        }

        private void UpdateTotalSeats()
        {
            if (cbModelVal.SelectedIndex != -1)
            {
                lblTotalSeatsVal.Text = $"{TotalSeatBasedOnAircraftModel()}";
            } else
            {
                lblTotalSeatsVal.Text = $"{0}";
            }
        }

        private int TotalSeatBasedOnAircraftModel()
        {
            int totalSeat = 0;
            foreach (var aircraftModel in Global.aircraftModels)
            {
                string aircraft = aircraftModel.Value["Model"].ToString();
                if (aircraft == cbModelVal.Text)
                {
                    totalSeat = Convert.ToInt32(aircraftModel.Value["Total Seats"]);
                }
            }

            return totalSeat;
        }

        private void cbModelVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalSeats();
        }

        private void tbNameVal_TextChanged(object sender, EventArgs e)
        {
            UpdateAircraftName();
        }
    }
}
