using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Data;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAFlightDetails : UserControl
    {
        // ── Public event so the host (RAForm) can hide/close this panel ───────
        public event EventHandler OnClose;

        // ── Backing data ──────────────────────────────────────────────────────
        private int _flightID;

        public RAFlightDetails()
        {
            InitializeComponent();
        }

        // ═════════════════════════════════════════════════════════════════════
        // Public entry-point: call this with the selected card's FlightID
        // ═════════════════════════════════════════════════════════════════════
        public void LoadFlight(int flightID)
        {
            _flightID = flightID;
            ClearUI();
            FetchAndPopulate();
        }

        // ── Wipe previous content ─────────────────────────────────────────────
        private void ClearUI()
        {
            lblAircraftName.Text = "—";
            lblAircraftModel.Text = "—";
            lblOriginCode.Text = "—";
            lblOriginName.Text = "—";
            lblDestCode.Text = "—";
            lblDestName.Text = "—";
            lblDepTime.Text = "—";
            lblDepDate.Text = "—";
            lblArrTime.Text = "—";
            lblArrDate.Text = "—";
            lblDuration.Text = "—";
            lblTerminalGate.Text = "—";
            lblStatus.Text = "—";
            lblStatus.BackColor = Color.FromArgb(102, 102, 102);
            flpPilots.Controls.Clear();
            flpAttendants.Controls.Clear();
        }

        // ── Main DB fetch ─────────────────────────────────────────────────────
        private void FetchAndPopulate()
        {
            try
            {
                using (var conn = DatabaseConnection.Get())
                {
                    conn.Open();
                    FetchFlightCore(conn);
                    FetchCrew(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load flight details:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Core flight info ──────────────────────────────────────────────────
        private void FetchFlightCore(SqlConnection conn)
        {
            const string sql = @"
                SELECT
                    a.Aircraft                  AS AircraftName,
                    m.Model                     AS AircraftModel,
                    ao.IATA                     AS OriginIATA,
                    ao.Airport                  AS OriginAirport,
                    ao.DisplayCity              AS OriginCity,
                    ad.IATA                     AS DestIATA,
                    ad.Airport                  AS DestAirport,
                    ad.DisplayCity              AS DestCity,
                    f.Departure,
                    f.Arrival,
                    f.DurationMin,
                    f.Gate,
                    t.TerminalNo,
                    t.Classification,
                    a.Status                    AS AircraftStatus
                FROM Flights f
                LEFT JOIN Aircrafts      a  ON a.AircraftID = f.Aircraft
                LEFT JOIN AircraftModels m  ON m.ModelID    = a.Model
                LEFT JOIN Airports       ao ON ao.AirportID = f.Origin
                LEFT JOIN Airports       ad ON ad.AirportID = f.Destination
                LEFT JOIN Terminals      t  ON t.TerminalID = f.Terminal
                WHERE f.FlightID = @fid";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@fid", _flightID);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return;

                    lblAircraftName.Text = rdr["AircraftName"].ToString();
                    lblAircraftModel.Text = rdr["AircraftModel"].ToString();

                    lblOriginCode.Text = rdr["OriginIATA"].ToString();
                    lblOriginName.Text = $"{rdr["OriginAirport"]}\n{rdr["OriginCity"]}";

                    lblDestCode.Text = rdr["DestIATA"].ToString();
                    lblDestName.Text = $"{rdr["DestAirport"]}\n{rdr["DestCity"]}";

                    var dep = Convert.ToDateTime(rdr["Departure"]);
                    var arr = Convert.ToDateTime(rdr["Arrival"]);
                    int dur = Convert.ToInt32(rdr["DurationMin"]);

                    lblDepTime.Text = dep.ToString("h:mm tt");
                    lblDepDate.Text = dep.ToString("ddd, MMM d, yyyy");
                    lblArrTime.Text = arr.ToString("h:mm tt");
                    lblArrDate.Text = arr.ToString("ddd, MMM d, yyyy");
                    lblDuration.Text = $"{dur / 60}h {dur % 60}m";

                    string terminal = rdr["TerminalNo"].ToString();
                    string gate = rdr["Gate"].ToString();
                    lblTerminalGate.Text = $"Terminal {terminal}  ·  Gate {gate}";

                    ApplyStatusBadge(rdr["AircraftStatus"] == DBNull.Value
                        ? 4 : Convert.ToInt32(rdr["AircraftStatus"]));
                }
            }
        }

        // ── Crew fetch ────────────────────────────────────────────────────────
        // Expects a Crew table with columns: Name, Role, FlightID
        // Role values: 'Pilot', 'Co-Pilot', 'Flight Attendant' (adjust to your schema)
        private void FetchCrew(SqlConnection conn)
        {
            const string sql = @"
        SELECT
            c.FirstName,
            c.MiddleName,
            c.LastName,
            ct.Type             AS CrewTypeLabel
        FROM   Flights f
        INNER JOIN Aircrafts a  ON a.AircraftID  = f.Aircraft
        CROSS APPLY OPENJSON(a.AssignedCrews) WITH (CrewID INT '$') AS ac
        INNER JOIN Crews      c  ON c.CrewID      = ac.CrewID
        INNER JOIN CrewTypes  ct ON ct.CrewTypeID  = c.CrewType
        WHERE  f.FlightID = @fid
        ORDER  BY ct.Type, c.LastName, c.FirstName";

            var pilots = new List<string>();
            var attendants = new List<string>();

            try
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", _flightID);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string firstName = rdr["FirstName"].ToString();
                            string middleName = rdr["MiddleName"].ToString();
                            string lastName = rdr["LastName"].ToString();
                            string crewType = rdr["CrewTypeLabel"].ToString();

                            string fullName = string.IsNullOrWhiteSpace(middleName)
                                ? $"{firstName} {lastName}"
                                : $"{firstName} {middleName[0]}. {lastName}";

                            if (crewType.IndexOf("Pilot", StringComparison.OrdinalIgnoreCase) >= 0)
                                pilots.Add($"{crewType}: {fullName}");
                            else
                                attendants.Add(fullName);
                        }
                    }
                }
            }
            catch (Exception)
            {
                pilots.Add("No crew data available.");
                // Uncomment to debug:
                // MessageBox.Show(ex.Message);
            }

            PopulateCrewList(flpPilots, pilots, "No pilots assigned.");
            PopulateCrewList(flpAttendants, attendants, "No attendants assigned.");
        }

        // ── Build crew label chips ────────────────────────────────────────────
        private void PopulateCrewList(FlowLayoutPanel panel, List<string> names, string emptyMsg)
        {
            panel.Controls.Clear();

            if (names.Count == 0)
            {
                panel.Controls.Add(MakeChip(emptyMsg, Color.FromArgb(240, 240, 245), Color.Gray));
                return;
            }

            foreach (string name in names)
                panel.Controls.Add(MakeChip(name, Color.FromArgb(235, 240, 255), Color.FromArgb(20, 20, 50)));
        }

        private Label MakeChip(string text, Color back, Color fore)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = fore,
                BackColor = back,
                Padding = new Padding(8, 4, 8, 4),
                Margin = new Padding(0, 0, 6, 6),
                Cursor = Cursors.Default
            };
        }

        // ── Status badge colours (mirrors RAFlightCards) ──────────────────────
        private void ApplyStatusBadge(int status)
        {
            string text;
            Color back;
            Color fore = Color.White;

            switch (status)
            {
                case 5: text = "BOARDING"; back = Color.FromArgb(255, 202, 7); fore = Color.Black; break;
                case 6: text = "IN FLIGHT"; back = Color.FromArgb(0, 38, 184); break;
                case 7: text = "LANDED"; back = Color.FromArgb(52, 167, 49); break;
                case 8: text = "DELAYED"; back = Color.FromArgb(255, 113, 27); break;
                case 9: text = "CANCELLED"; back = Color.FromArgb(220, 33, 49); break;
                case 0:
                case 1:
                case 2:
                case 3: text = "NOT READY"; back = Color.FromArgb(102, 102, 102); break;
                default: text = "SCHEDULED"; back = Color.White; fore = Color.FromArgb(30, 30, 60); break;
            }

            lblStatus.Text = text;
            lblStatus.BackColor = back;
            lblStatus.ForeColor = fore;
        }

        // ── Close button ──────────────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke(this, EventArgs.Empty);
        }
    }
}