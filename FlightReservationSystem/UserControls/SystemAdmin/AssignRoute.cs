using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class AssignRoute : UserControl
    {
        public AssignRoute()
        {
            InitializeComponent();
        }

        private void AssignRoute_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnAssignAircraft_Click(object sender, EventArgs e)
        {
            int aircraft = 10;
            DateTime departure = DateTime.Now;
            DateTime arrival = departure.AddHours(6);
            int origin = 7;
            int destination = 17;
            int terminal = 2;
            int gate = 5;
            int distancekm = 40;
            int durationMin = 360;

            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Flights (Aircraft, Departure, Arrival, Origin, Destination, Terminal, Gate, DistanceKM, DurationMin) VALUES " +
                        "(@Aircraft, @Departure, @Arrival, @Origin, @Destination, @Terminal, @Gate, @DistanceKM, @DurationMin) ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Aircraft", aircraft);
                        cmd.Parameters.AddWithValue("@Departure", departure);
                        cmd.Parameters.AddWithValue("@Arrival", arrival);
                        cmd.Parameters.AddWithValue("@Origin", origin);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        cmd.Parameters.AddWithValue("@Terminal", terminal);
                        cmd.Parameters.AddWithValue("@Gate", gate);
                        cmd.Parameters.AddWithValue("@DistanceKM", distancekm);
                        cmd.Parameters.AddWithValue("@DurationMin", durationMin);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Updated na rin bro.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}.");
                    return;
                }
            }
        }
    }
}
