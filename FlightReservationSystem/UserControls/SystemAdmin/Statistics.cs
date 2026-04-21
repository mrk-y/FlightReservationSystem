using FlightReservationSystem.Data.Reference.Airport;
using FlightReservationSystem.Data.Runtime.Booking;
using FlightReservationSystem.Data.Runtime.BookingPassenger;
using FlightReservationSystem.Data.Runtime.Flight;
using FlightReservationSystem.Data.Runtime.User;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Data.Reference.ColorPallete;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
            InitUI();
            InitData();
            LoadSeatClassChartUI();
        }

        private void InitUI()
        {
            MovePnlPrint();
            LoadRevenueChartUI();
            LoadSeatClassChartUI();
            LoadBookingsChartUI();
            LoadPassengersChartUI();
            LoadRoutesChartUI();
        }

        private void InitData()
        {
            rbViewDaily.Checked = true;
            cbRevenue.Checked = true;
            rbPeriodDaily.Checked = true;
        }

        private void MovePnlPrint()
        {
            var ctrl = flowLayoutPanel1.Controls["pnlPrint"];
            if (ctrl != null) flowLayoutPanel1.Controls.Remove(ctrl);

            this.Controls.Add(ctrl);
        }

        private void LoadRevenueChartUI()
        {
            chRevenue.Series.Clear();
            chRevenue.Titles.Clear();
            chRevenue.ChartAreas[0].BackColor = Color.White;
            chRevenue.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chRevenue.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chRevenue.ChartAreas[0].AxisX.LineColor = Color.FromArgb(200, 200, 200);
            chRevenue.ChartAreas[0].AxisY.LineColor = Color.FromArgb(220, 220, 220);
            chRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chRevenue.ChartAreas[0].AxisX.Interval = 1;
            chRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(245, 245, 245);
            chRevenue.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chRevenue.ChartAreas[0].AxisX.IsMarginVisible = false;

            chRevenue.Titles.Add(new Title("Revenue per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            var series = new Series("Revenue (₱)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };

            series["PointWidth"] = "0.8";
            series.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            series.LabelForeColor = Color.FromArgb(50, 50, 80);

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            double[] values = { 20000, 18000, 25000, 28000, 30000, 35000, 33000, 31000, 32000, 38000, 37000, 45000 };

            for (int i = 0; i < months.Length; i++)
                series.Points.AddXY(months[i], values[i]);

            chRevenue.Series.Add(series);

            if (chRevenue.Legends.Count > 0)
            {
                chRevenue.Legends[0].BackColor = Color.White;
                chRevenue.Legends[0].ForeColor = Color.FromArgb(80, 80, 100);
                chRevenue.Legends[0].BorderColor = Color.FromArgb(230, 230, 230);
                chRevenue.Legends[0].Docking = Docking.Top;
                chRevenue.Legends[0].Alignment = StringAlignment.Near;
            }
        }

        private void LoadSeatClassChartUI()
        {
            chSeatClass.Series.Clear();
            chSeatClass.Titles.Clear();
            chSeatClass.ChartAreas[0].BackColor = Color.White;
            chSeatClass.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chSeatClass.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chSeatClass.ChartAreas[0].AxisX.LineWidth = 0;
            chSeatClass.ChartAreas[0].AxisY.LineWidth = 0;
            chSeatClass.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chSeatClass.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);

            chSeatClass.Titles.Add(new Title("Seat class distribution")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            var series = new Series("Seat class")
            {
                ChartType = SeriesChartType.Doughnut
            };

            series.Points.AddXY("Business", 60);
            series.Points.AddXY("Economy", 30);
            series.Points.AddXY("First", 10);

            series["DoughnutRadius"] = "60";
            series["PieLabelStyle"] = "Disabled";

            if (series.Points.Count >= 3)
            {
                series.Points[0].Color = Color.FromArgb(10, 40, 100);
                series.Points[1].Color = Color.FromArgb(150, 150, 180);
                series.Points[2].Color = Color.Orange;
            }

            chSeatClass.Series.Add(series);

            if (chSeatClass.Legends.Count > 0)
            {
                chSeatClass.Legends[0].BackColor = Color.White;
                chSeatClass.Legends[0].ForeColor = Color.FromArgb(80, 80, 100);
                chSeatClass.Legends[0].BorderColor = Color.FromArgb(230, 230, 230);
                chSeatClass.Legends[0].Docking = Docking.Top;
                chSeatClass.Legends[0].Alignment = StringAlignment.Near;
            }
        }

        private void LoadBookingsChartUI()
        {
            chBookings.Series.Clear();
            chBookings.Titles.Clear();
            chBookings.ChartAreas[0].BackColor = Color.White;

            chBookings.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chBookings.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chBookings.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chBookings.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(245, 245, 245);
            chBookings.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chBookings.ChartAreas[0].AxisX.Interval = 1;
            chBookings.ChartAreas[0].AxisX.IsMarginVisible = false;

            chBookings.Titles.Add(new Title("Bookings per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            var series = new Series("Bookings")
            {
                ChartType = SeriesChartType.Spline,
                Color = Color.FromArgb(10, 40, 100),
                BorderWidth = 2
            };

            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;
            series.MarkerColor = Color.FromArgb(255, 165, 0);
            series.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            series.LabelForeColor = Color.FromArgb(50, 50, 80);

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            double[] values = { 12, 15, 17, 20, 22, 19, 24, 21, 27, 30, 28, 32 };

            for (int i = 0; i < months.Length; i++)
                series.Points.AddXY(months[i], values[i]);

            chBookings.Series.Add(series);

            if (chBookings.Legends.Count > 0)
            {
                chBookings.Legends[0].BackColor = Color.White;
                chBookings.Legends[0].ForeColor = Color.FromArgb(80, 80, 100);
                chBookings.Legends[0].BorderColor = Color.FromArgb(230, 230, 230);
                chBookings.Legends[0].Docking = Docking.Top;
                chBookings.Legends[0].Alignment = StringAlignment.Near;
            }
        }

        private void LoadPassengersChartUI()
        {
            chPassengers.Series.Clear();
            chPassengers.Titles.Clear();
            chPassengers.ChartAreas[0].BackColor = Color.White;

            chPassengers.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chPassengers.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chPassengers.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chPassengers.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(245, 245, 245);
            chPassengers.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chPassengers.ChartAreas[0].AxisX.Interval = 1;
            chPassengers.ChartAreas[0].AxisX.IsMarginVisible = false;

            chPassengers.Titles.Add(new Title("Passengers per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            var series = new Series("Passengers")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };

            series["PointWidth"] = "0.7";
            series.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            series.LabelForeColor = Color.FromArgb(50, 50, 80);

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            double[] values = { 18, 22, 25, 29, 30, 34, 33, 35, 30, 36, 40, 42 };

            for (int i = 0; i < months.Length; i++)
                series.Points.AddXY(months[i], values[i]);

            chPassengers.Series.Add(series);

            if (chPassengers.Legends.Count > 0)
            {
                chPassengers.Legends[0].BackColor = Color.White;
                chPassengers.Legends[0].ForeColor = Color.FromArgb(80, 80, 100);
                chPassengers.Legends[0].BorderColor = Color.FromArgb(230, 230, 230);
                chPassengers.Legends[0].Docking = Docking.Top;
                chPassengers.Legends[0].Alignment = StringAlignment.Near;
            }
        }

        private void LoadRoutesChartUI()
        {
            chRoutes.Series.Clear();
            chRoutes.Titles.Clear();
            chRoutes.ChartAreas[0].BackColor = Color.White;
            chRoutes.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chRoutes.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(50, 50, 80);
            chRoutes.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chRoutes.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chRoutes.ChartAreas[0].AxisX.LineColor = Color.FromArgb(220, 220, 220);
            chRoutes.ChartAreas[0].AxisX.IsMarginVisible = false;

            chRoutes.Titles.Add(new Title("Top routes")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            var series = new Series("Bookings")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(10, 40, 100)
            };

            series["PointWidth"] = "0.6";
            series.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            series.LabelForeColor = Color.FromArgb(50, 50, 80);

            var routes = new[]
            {
                new { Route = "MNL→CEB", Value = 28 },
                new { Route = "CEB→MNL", Value = 22 },
                new { Route = "MNL→DVO", Value = 18 },
                new { Route = "DVO→MNL", Value = 15 },
                new { Route = "CEB→DVO", Value = 11 }
            }
            .OrderBy(r => r.Value)
            .ToArray();

            for (int i = 0; i < routes.Length; i++)
            {
                series.Points.AddXY(routes[i].Route, routes[i].Value);
            }

            chRoutes.Series.Add(series);

            if (chRoutes.Legends.Count > 0)
            {
                chRoutes.Legends[0].BackColor = Color.White;
                chRoutes.Legends[0].ForeColor = Color.FromArgb(80, 80, 100);
                chRoutes.Legends[0].BorderColor = Color.FromArgb(230, 230, 230);
                chRoutes.Legends[0].Docking = Docking.Top;
                chRoutes.Legends[0].Alignment = StringAlignment.Near;
            }
        }

        private void ShowPrintPanel()
        {
            int left = (this.ClientSize.Width - pnlPrint.Width) / 2;
            int top = (this.ClientSize.Height - pnlPrint.Height) / 2;

            if (left < 0) left = 0;
            if (top < 0) top = 0;

            pnlPrint.Location = new Point(left, top);
            pnlPrint.Visible = true;
            pnlPrint.BringToFront();

            btnPrintReport.Enabled = false;
        }

        public void HidePrintPanel()
        {
            pnlPrint.Visible = false;
            btnPrintReport.Enabled = true;
        }

        private void UpdateValuesDaily()
        {
            lblTotalBookingsType.Text = "Today";
            lblTotalRevenueType.Text = "Today";
            lblTotalPassengersType.Text = "Today";
            lblTotalFlightsType.Text = "Today";
            int totalBookings = 0;
            decimal totalRevenue = 0m;
            int totalPassengers = 0;
            int totalFlights = 0;
            decimal avgBookingValue = 0m;
            decimal avgPaxPerFlight = 0m;
            string mostPopularRoute = "—";
            string topSeatClass = "—";
            int topSeatClassPercent = 0;

            DateTime today = DateTime.Now.Date;

            List<BookingRecord> bookingDailyCollection;
            if (!StatisticsManager.GetBookingDailyCollection.TryGetValue(today, out bookingDailyCollection))
                bookingDailyCollection = new List<BookingRecord>();

            totalBookings = bookingDailyCollection.Count;
            totalRevenue = bookingDailyCollection.Sum(b => b.TotalAmount);

            List<BookingPassengerRecord> bookingPassengerDailyCollection;
            if (!StatisticsManager.GetBookingPassengerDailyCollection.TryGetValue(today, out bookingPassengerDailyCollection))
                bookingPassengerDailyCollection = new List<BookingPassengerRecord>();
            totalPassengers = bookingPassengerDailyCollection.Count;

            List<FlightRecord> flightDailyCollection;
            if (!StatisticsManager.GetFlightDailyCollection.TryGetValue(today, out flightDailyCollection))
                flightDailyCollection = new List<FlightRecord>();
            totalFlights = flightDailyCollection.Count;

            avgBookingValue = totalBookings > 0 ? totalRevenue / totalBookings : 0m;
            avgPaxPerFlight = totalFlights > 0 ? (decimal)totalPassengers / totalFlights : 0m;

            var routeGroup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var flight in flightDailyCollection)
            {
                var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == flight.OriginID);
                var destination = AirportCollection.Get.FirstOrDefault(a => a.ID == flight.DestinationID);

                if (origin == null || destination == null) continue;

                var route = $"{origin.IATA}→{destination.IATA}";
                if (!routeGroup.ContainsKey(route))
                    routeGroup[route] = 0;
                routeGroup[route]++;
            }

            if (routeGroup.Count > 0)
            {
                var most = routeGroup.OrderByDescending(kvp => kvp.Value).First();
                mostPopularRoute = most.Key;
            }

            if (bookingPassengerDailyCollection.Count > 0)
            {
                var seatClassGroup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                foreach (var bp in bookingPassengerDailyCollection)
                {
                    var seatClass = string.IsNullOrWhiteSpace(bp.SeatClass) ? "Unknown" : bp.SeatClass;
                    if (!seatClassGroup.ContainsKey(seatClass))
                        seatClassGroup[seatClass] = 0;
                    seatClassGroup[seatClass]++;
                }

                if (seatClassGroup.Count > 0)
                {
                    var top = seatClassGroup.OrderByDescending(kvp => kvp.Value).First();
                    topSeatClass = top.Key;
                    int maxSeatCount = top.Value;
                    topSeatClassPercent = totalPassengers > 0 ? (int)Math.Round((decimal)maxSeatCount / totalPassengers * 100, 0) : 0;
                }
            }

            lblTotalBookingsVal.Text = totalBookings.ToString();
            lblTotalRevenueVal.Text = $"₱{totalRevenue:N2}";
            lblTotalPassengersVal.Text = totalPassengers.ToString();
            lblTotalFlightsVal.Text = totalFlights.ToString();
            lblAvgBookingVal.Text = $"₱{avgBookingValue:N2}";
            lblAvgPaxFlightVal.Text = avgPaxPerFlight.ToString("N2");
            lblMostPopularRouteVal.Text = mostPopularRoute;
            lblTopSeatClassVal.Text = topSeatClass;
            lblTopSeatClassType.Text = topSeatClassPercent > 0 ? $"{topSeatClassPercent}% of bookings" : "— of bookings";
        }

        private void UpdateValuesMonthly(int year, int month)
        {
            lblTotalBookingsType.Text = "This month";
            lblTotalRevenueType.Text = "This month";
            lblTotalPassengersType.Text = "This month";
            lblTotalFlightsType.Text = "This month";
            int totalBookings = 0;
            decimal totalRevenue = 0m;
            int totalPassengers = 0;
            int totalFlights = 0;
            decimal avgBookingValue = 0m;
            decimal avgPaxPerFlight = 0m;
            string mostPopularRoute = "—";
            string topSeatClass = "—";
            int topSeatClassPercent = 0;

            var key = (Year: year, Month: month);

            List<BookingRecord> bookingMonthlyCollection;
            if (!StatisticsManager.GetBookingMonthlyCollection.TryGetValue(key, out bookingMonthlyCollection))
                bookingMonthlyCollection = new List<BookingRecord>();
            totalBookings = bookingMonthlyCollection.Count;
            totalRevenue = bookingMonthlyCollection.Sum(b => b.TotalAmount);

            List<BookingPassengerRecord> bookingPassengerMonthlyCollection;
            if (!StatisticsManager.GetBookingPassengerMonthlyCollection.TryGetValue(key, out bookingPassengerMonthlyCollection))
                bookingPassengerMonthlyCollection = new List<BookingPassengerRecord>();
            totalPassengers = bookingPassengerMonthlyCollection.Count;

            List<FlightRecord> flightMonthlyCollection;
            if (!StatisticsManager.GetFlightMonthlyCollection.TryGetValue(key, out flightMonthlyCollection))
                flightMonthlyCollection = new List<FlightRecord>();
            totalFlights = flightMonthlyCollection.Count;

            avgBookingValue = totalBookings > 0 ? totalRevenue / totalBookings : 0m;
            avgPaxPerFlight = totalFlights > 0 ? (decimal)totalPassengers / totalFlights : 0m;

            var routeGroup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var flight in flightMonthlyCollection)
            {
                var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == flight.OriginID);
                var destination = AirportCollection.Get.FirstOrDefault(a => a.ID == flight.DestinationID);
                if (origin == null || destination == null) continue;

                var route = $"{origin.IATA}→{destination.IATA}";
                if (!routeGroup.ContainsKey(route))
                    routeGroup[route] = 0;
                routeGroup[route]++;
            }

            if (routeGroup.Count > 0)
            {
                var most = routeGroup.OrderByDescending(kvp => kvp.Value).First();
                mostPopularRoute = most.Key;
            }

            if (bookingPassengerMonthlyCollection.Count > 0)
            {
                var seatClassGroup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                foreach (var bp in bookingPassengerMonthlyCollection)
                {
                    var seatClass = string.IsNullOrWhiteSpace(bp.SeatClass) ? "Unknown" : bp.SeatClass;
                    if (!seatClassGroup.ContainsKey(seatClass))
                        seatClassGroup[seatClass] = 0;
                    seatClassGroup[seatClass]++;
                }

                if (seatClassGroup.Count > 0)
                {
                    var top = seatClassGroup.OrderByDescending(kvp => kvp.Value).First();
                    topSeatClass = top.Key;
                    int maxSeatCount = top.Value;
                    topSeatClassPercent = totalPassengers > 0 ? (int)Math.Round((decimal)maxSeatCount / totalPassengers * 100, 0) : 0;
                }
            }

            lblTotalBookingsVal.Text = totalBookings.ToString();
            lblTotalRevenueVal.Text = $"₱{totalRevenue:N2}";
            lblTotalPassengersVal.Text = totalPassengers.ToString();
            lblTotalFlightsVal.Text = totalFlights.ToString();
            lblAvgBookingVal.Text = $"₱{avgBookingValue:N2}";
            lblAvgPaxFlightVal.Text = avgPaxPerFlight.ToString("N2");
            lblMostPopularRouteVal.Text = mostPopularRoute;
            lblTopSeatClassVal.Text = topSeatClass;
            lblTopSeatClassType.Text = topSeatClassPercent > 0 ? $"{topSeatClassPercent}% of bookings" : "— of bookings";
        }

        private void UpdateValuesYearly(int year)
        {
            lblTotalBookingsType.Text = "This year";
            lblTotalRevenueType.Text = "This year";
            lblTotalPassengersType.Text = "This year";
            lblTotalFlightsType.Text = "This year";
            int totalBookings = 0;
            decimal totalRevenue = 0m;
            int totalPassengers = 0;
            int totalFlights = 0;
            decimal avgBookingValue = 0m;
            decimal avgPaxPerFlight = 0m;
            string mostPopularRoute = "—";
            string topSeatClass = "—";
            int topSeatClassPercent = 0;

            var bookingsYear = StatisticsManager.GetBookingMonthlyCollection
                                .Where(kvp => kvp.Key.Year == year)
                                .SelectMany(kvp => kvp.Value)
                                .ToList();
            totalBookings = bookingsYear.Count;
            totalRevenue = bookingsYear.Sum(b => b.TotalAmount);

            var bookingPassengersYear = StatisticsManager.GetBookingPassengerMonthlyCollection
                                        .Where(kvp => kvp.Key.Year == year)
                                        .SelectMany(kvp => kvp.Value)
                                        .ToList();
            totalPassengers = bookingPassengersYear.Count;

            var flightsYear = StatisticsManager.GetFlightMonthlyCollection
                             .Where(kvp => kvp.Key.Year == year)
                             .SelectMany(kvp => kvp.Value)
                             .ToList();
            totalFlights = flightsYear.Count;

            avgBookingValue = totalBookings > 0 ? totalRevenue / totalBookings : 0m;
            avgPaxPerFlight = totalFlights > 0 ? (decimal)totalPassengers / totalFlights : 0m;

            var routeGroup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var flight in flightsYear)
            {
                var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == flight.OriginID);
                var destination = AirportCollection.Get.FirstOrDefault(a => a.ID == flight.DestinationID);
                if (origin == null || destination == null) continue;

                var route = $"{origin.IATA}→{destination.IATA}";
                if (!routeGroup.ContainsKey(route))
                    routeGroup[route] = 0;
                routeGroup[route]++;
            }

            if (routeGroup.Count > 0)
            {
                var most = routeGroup.OrderByDescending(kvp => kvp.Value).First();
                mostPopularRoute = most.Key;
            }

            if (bookingPassengersYear.Count > 0)
            {
                var seatClassGroup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                foreach (var bp in bookingPassengersYear)
                {
                    var seatClass = string.IsNullOrWhiteSpace(bp.SeatClass) ? "Unknown" : bp.SeatClass;
                    if (!seatClassGroup.ContainsKey(seatClass))
                        seatClassGroup[seatClass] = 0;
                    seatClassGroup[seatClass]++;
                }

                if (seatClassGroup.Count > 0)
                {
                    var top = seatClassGroup.OrderByDescending(kvp => kvp.Value).First();
                    topSeatClass = top.Key;
                    int maxSeatCount = top.Value;
                    topSeatClassPercent = totalPassengers > 0 ? (int)Math.Round((decimal)maxSeatCount / totalPassengers * 100, 0) : 0;
                }
            }

            lblTotalBookingsVal.Text = totalBookings.ToString();
            lblTotalRevenueVal.Text = $"₱{totalRevenue:N2}";
            lblTotalPassengersVal.Text = totalPassengers.ToString();
            lblTotalFlightsVal.Text = totalFlights.ToString();
            lblAvgBookingVal.Text = $"₱{avgBookingValue:N2}";
            lblAvgPaxFlightVal.Text = avgPaxPerFlight.ToString("N2");
            lblMostPopularRouteVal.Text = mostPopularRoute;
            lblTopSeatClassVal.Text = topSeatClass;
            lblTopSeatClassType.Text = topSeatClassPercent > 0 ? $"{topSeatClassPercent}% of bookings" : "— of bookings";
        }

        private void UpdateValuesMonthly()
        {
            var now = DateTime.Now;
            UpdateValuesMonthly(now.Year, now.Month);
        }

        private void UpdateValuesYearly()
        {
            UpdateValuesYearly(DateTime.Now.Year);
        }

        private void UpdateChartsDaily()
        {
            chRevenue.Titles.Clear();
            chRevenue.Titles.Add(new Title("Revenue per day")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chSeatClass.Titles.Clear();
            chSeatClass.Titles.Add(new Title("Seat class distribution per day")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chBookings.Titles.Clear();
            chBookings.Titles.Add(new Title("Bookings per day")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chPassengers.Titles.Clear();
            chPassengers.Titles.Add(new Title("Passengers per day")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chRoutes.Titles.Clear();
            chRoutes.Titles.Add(new Title("Top routes per day")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            DateTime today = DateTime.Now.Date;

            // Revenue
            chRevenue.Series.Clear();
            var revSeries = new Series("Revenue (₱)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100),
                ToolTip = "₱#VALY{N2}"
            };
            List<BookingRecord> bookingDailyCollection;
            if (!StatisticsManager.GetBookingDailyCollection.TryGetValue(today, out bookingDailyCollection))
                bookingDailyCollection = new List<BookingRecord>();
            decimal totalRevenue = bookingDailyCollection.Sum(b => b.TotalAmount);
            revSeries.Points.AddXY("Today", (double)totalRevenue);
            chRevenue.Series.Add(revSeries);

            // Bookings
            chBookings.Series.Clear();
            var bookingSeries = new Series("Bookings")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            int totalBookings = bookingDailyCollection.Count;
            bookingSeries.Points.AddXY("Today", totalBookings);
            chBookings.Series.Add(bookingSeries);

            // Passengers
            chPassengers.Series.Clear();
            var paxSeries = new Series("Passengers")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            List<BookingPassengerRecord> bookingPassengerDailyCollection;
            if (!StatisticsManager.GetBookingPassengerDailyCollection.TryGetValue(today, out bookingPassengerDailyCollection))
                bookingPassengerDailyCollection = new List<BookingPassengerRecord>();
            int totalPassengers = bookingPassengerDailyCollection.Count;
            paxSeries.Points.AddXY("Today", totalPassengers);
            chPassengers.Series.Add(paxSeries);

            // Seat class doughnut
            chSeatClass.Series.Clear();
            var seatSeries = new Series("Seat class")
            {
                ChartType = SeriesChartType.Doughnut
            };
            var seatClassGroup = bookingPassengerDailyCollection
                                 .GroupBy(bp => string.IsNullOrWhiteSpace(bp.SeatClass) ? "Unknown" : bp.SeatClass)
                                 .Select(g => new { Class = g.Key, Count = g.Count() })
                                 .OrderByDescending(x => x.Count)
                                 .ToList();
            if (seatClassGroup.Count == 0)
            {
                seatSeries.Points.AddXY("None", 1);
            }
            else
            {
                foreach (var sc in seatClassGroup)
                    seatSeries.Points.AddXY(sc.Class, sc.Count);
            }
            seatSeries["DoughnutRadius"] = "60";
            seatSeries["PieLabelStyle"] = "Disabled";
            chSeatClass.Series.Add(seatSeries);

            // Routes (top)
            chRoutes.Series.Clear();
            var routeSeries = new Series("Bookings")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(10, 40, 100)
            };
            List<FlightRecord> flightDailyCollection;
            if (!StatisticsManager.GetFlightDailyCollection.TryGetValue(today, out flightDailyCollection))
                flightDailyCollection = new List<FlightRecord>();
            var routeGroups = flightDailyCollection
                              .Select(f =>
                              {
                                  var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == f.OriginID);
                                  var destination = AirportCollection.Get.FirstOrDefault(a => a.ID == f.DestinationID);
                                  if (origin == null || destination == null) return null;
                                  return $"{origin.IATA}→{destination.IATA}";
                              })
                              .Where(r => r != null)
                              .GroupBy(r => r)
                              .Select(g => new { Route = g.Key, Count = g.Count() })
                              .OrderByDescending(x => x.Count)
                              .ToList();
            if (routeGroups.Count == 0)
            {
                routeSeries.Points.AddXY("None", 0);
            }
            else
            {
                foreach (var r in routeGroups)
                    routeSeries.Points.AddXY(r.Route, r.Count);
            }
            chRoutes.Series.Add(routeSeries);
        }

        private void UpdateChartsMonthly(int year, int month)
        {
            chRevenue.Titles.Clear();
            chRevenue.Titles.Add(new Title("Revenue per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chSeatClass.Titles.Clear();
            chSeatClass.Titles.Add(new Title("Seat class distribution per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chBookings.Titles.Clear();
            chBookings.Titles.Add(new Title("Bookings per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chPassengers.Titles.Clear();
            chPassengers.Titles.Add(new Title("Passengers per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chRoutes.Titles.Clear();
            chRoutes.Titles.Add(new Title("Top routes per month")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            string[] monthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            double[] revenueValues = new double[12];
            int[] bookingValues = new int[12];
            int[] passengerValues = new int[12];
            int[] flightValues = new int[12];

            for (int m = 1; m <= 12; m++)
            {
                var key = (Year: year, Month: m);
                List<BookingRecord> bookings;
                if (!StatisticsManager.GetBookingMonthlyCollection.TryGetValue(key, out bookings))
                    bookings = new List<BookingRecord>();
                revenueValues[m - 1] = (double)bookings.Sum(b => b.TotalAmount);
                bookingValues[m - 1] = bookings.Count;

                List<BookingPassengerRecord> passengers;
                if (!StatisticsManager.GetBookingPassengerMonthlyCollection.TryGetValue(key, out passengers))
                    passengers = new List<BookingPassengerRecord>();
                passengerValues[m - 1] = passengers.Count;

                List<FlightRecord> flights;
                if (!StatisticsManager.GetFlightMonthlyCollection.TryGetValue(key, out flights))
                    flights = new List<FlightRecord>();
                flightValues[m - 1] = flights.Count;
            }

            // Revenue chart
            chRevenue.Series.Clear();
            var revSeries = new Series("Revenue (₱)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            for (int i = 0; i < 12; i++)
                revSeries.Points.AddXY(monthNames[i], revenueValues[i]);
            chRevenue.Series.Add(revSeries);

            // Bookings chart (monthly)
            chBookings.Series.Clear();
            var bookingSeries = new Series("Bookings")
            {
                ChartType = SeriesChartType.Spline,
                Color = Color.FromArgb(10, 40, 100),
                BorderWidth = 2
            };
            bookingSeries.MarkerStyle = MarkerStyle.Circle;
            bookingSeries.MarkerSize = 6;
            bookingSeries.MarkerColor = Color.FromArgb(255, 165, 0);
            for (int i = 0; i < 12; i++)
                bookingSeries.Points.AddXY(monthNames[i], bookingValues[i]);
            chBookings.Series.Add(bookingSeries);

            // Passengers chart
            chPassengers.Series.Clear();
            var paxSeries = new Series("Passengers")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            for (int i = 0; i < 12; i++)
                paxSeries.Points.AddXY(monthNames[i], passengerValues[i]);
            chPassengers.Series.Add(paxSeries);

            // Seat class distribution for the given month
            chSeatClass.Series.Clear();
            var seatSeries = new Series("Seat class")
            {
                ChartType = SeriesChartType.Doughnut
            };
            var monthKey = (Year: year, Month: month);
            List<BookingPassengerRecord> passengersForMonth;
            if (!StatisticsManager.GetBookingPassengerMonthlyCollection.TryGetValue(monthKey, out passengersForMonth))
                passengersForMonth = new List<BookingPassengerRecord>();
            var seatClassGroup = passengersForMonth
                                 .GroupBy(bp => string.IsNullOrWhiteSpace(bp.SeatClass) ? "Unknown" : bp.SeatClass)
                                 .Select(g => new { Class = g.Key, Count = g.Count() })
                                 .OrderByDescending(x => x.Count)
                                 .ToList();
            if (seatClassGroup.Count == 0)
                seatSeries.Points.AddXY("None", 1);
            else
                foreach (var sc in seatClassGroup)
                    seatSeries.Points.AddXY(sc.Class, sc.Count);
            seatSeries["DoughnutRadius"] = "60";
            seatSeries["PieLabelStyle"] = "Disabled";
            chSeatClass.Series.Add(seatSeries);

            // Top routes for the month
            chRoutes.Series.Clear();
            var routeSeries = new Series("Bookings")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(10, 40, 100)
            };
            List<FlightRecord> flightsForMonth;
            if (!StatisticsManager.GetFlightMonthlyCollection.TryGetValue(monthKey, out flightsForMonth))
                flightsForMonth = new List<FlightRecord>();
            var routeGroups = flightsForMonth
                              .Select(f =>
                              {
                                  var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == f.OriginID);
                                  var destination = AirportCollection.Get.FirstOrDefault(a => a.ID == f.DestinationID);
                                  if (origin == null || destination == null) return null;
                                  return $"{origin.IATA}→{destination.IATA}";
                              })
                              .Where(r => r != null)
                              .GroupBy(r => r)
                              .Select(g => new { Route = g.Key, Count = g.Count() })
                              .OrderByDescending(x => x.Count)
                              .ToList();
            if (routeGroups.Count == 0)
                routeSeries.Points.AddXY("None", 0);
            else
                foreach (var r in routeGroups)
                    routeSeries.Points.AddXY(r.Route, r.Count);
            chRoutes.Series.Add(routeSeries);
        }

        private void UpdateChartsYearly(int year)
        {
            chRevenue.Titles.Clear();
            chRevenue.Titles.Add(new Title("Revenue per year")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chSeatClass.Titles.Clear();
            chSeatClass.Titles.Add(new Title("Seat class distribution per year")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chBookings.Titles.Clear();
            chBookings.Titles.Add(new Title("Bookings per year")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chPassengers.Titles.Clear();
            chPassengers.Titles.Add(new Title("Passengers per year")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });
            chRoutes.Titles.Clear();
            chRoutes.Titles.Add(new Title("Top routes per year")
            {
                ForeColor = Color.FromArgb(50, 50, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft
            });

            var bookingMonthly = StatisticsManager.GetBookingMonthlyCollection;
            var passengerMonthly = StatisticsManager.GetBookingPassengerMonthlyCollection;
            var flightMonthly = StatisticsManager.GetFlightMonthlyCollection;

            // Build totals for the requested year (single-year view)
            var bookingsYear = bookingMonthly
                                .Where(kvp => kvp.Key.Year == year)
                                .SelectMany(kvp => kvp.Value)
                                .ToList();
            var passengersYear = passengerMonthly
                                  .Where(kvp => kvp.Key.Year == year)
                                  .SelectMany(kvp => kvp.Value)
                                  .ToList();
            var flightsYear = flightMonthly
                              .Where(kvp => kvp.Key.Year == year)
                              .SelectMany(kvp => kvp.Value)
                              .ToList();

            // Revenue per year (single bar)
            chRevenue.Series.Clear();
            var revSeries = new Series("Revenue (₱)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            decimal totalRevenue = bookingsYear.Sum(b => b.TotalAmount);
            revSeries.Points.AddXY(year.ToString(), (double)totalRevenue);
            chRevenue.Series.Add(revSeries);

            // Bookings per year
            chBookings.Series.Clear();
            var bookingSeries = new Series("Bookings")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            bookingSeries.Points.AddXY(year.ToString(), bookingsYear.Count);
            chBookings.Series.Add(bookingSeries);

            // Passengers per year
            chPassengers.Series.Clear();
            var paxSeries = new Series("Passengers")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(10, 40, 100)
            };
            paxSeries.Points.AddXY(year.ToString(), passengersYear.Count);
            chPassengers.Series.Add(paxSeries);

            // Seat class distribution for the year
            chSeatClass.Series.Clear();
            var seatSeries = new Series("Seat class")
            {
                ChartType = SeriesChartType.Doughnut
            };
            var seatClassGroup = passengersYear
                                 .GroupBy(bp => string.IsNullOrWhiteSpace(bp.SeatClass) ? "Unknown" : bp.SeatClass)
                                 .Select(g => new { Class = g.Key, Count = g.Count() })
                                 .OrderByDescending(x => x.Count)
                                 .ToList();
            if (seatClassGroup.Count == 0)
                seatSeries.Points.AddXY("None", 1);
            else
                foreach (var sc in seatClassGroup)
                    seatSeries.Points.AddXY(sc.Class, sc.Count);
            seatSeries["DoughnutRadius"] = "60";
            seatSeries["PieLabelStyle"] = "Disabled";
            chSeatClass.Series.Add(seatSeries);

            // Top routes for the year
            chRoutes.Series.Clear();
            var routeSeries = new Series("Bookings")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(10, 40, 100)
            };
            var routeGroups = flightsYear
                              .Select(f =>
                              {
                                  var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == f.OriginID);
                                  var destination = AirportCollection.Get.FirstOrDefault(a => a.ID == f.DestinationID);
                                  if (origin == null || destination == null) return null;
                                  return $"{origin.IATA}→{destination.IATA}";
                              })
                              .Where(r => r != null)
                              .GroupBy(r => r)
                              .Select(g => new { Route = g.Key, Count = g.Count() })
                              .OrderByDescending(x => x.Count)
                              .ToList();
            if (routeGroups.Count == 0)
                routeSeries.Points.AddXY("None", 0);
            else
                foreach (var r in routeGroups)
                    routeSeries.Points.AddXY(r.Route, r.Count);
            chRoutes.Series.Add(routeSeries);
        }

        private void UpdateChartsMonthly()
        {
            var now = DateTime.Now;
            UpdateChartsMonthly(now.Year, now.Month);
        }

        private void UpdateChartsYearly()
        {
            UpdateChartsYearly(DateTime.Now.Year);
        }

        // RefreshView centralizes view updates and forces chart redraw
        private void RefreshView()
        {
            if (rbViewDaily.Checked) { UpdateValuesDaily(); UpdateChartsDaily(); }
            else if (rbViewMonthly.Checked) { UpdateValuesMonthly(); UpdateChartsMonthly(); }
            else if (rbViewAnnually.Checked) { UpdateValuesYearly(); UpdateChartsYearly(); }

            chRevenue.Invalidate();
            chBookings.Invalidate();
            chPassengers.Invalidate();
            chSeatClass.Invalidate();
            chRoutes.Invalidate();
        }

        // Wire updated handlers so UI updates both labels and charts
        private void rbViewDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViewDaily.Checked) RefreshView();
        }

        private void rbViewMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViewMonthly.Checked) RefreshView();
        }

        private void rbViewAnnually_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViewAnnually.Checked) RefreshView();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            ShowPrintPanel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HidePrintPanel();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string reportType;
            if (cbRevenue.Checked) reportType = "Revenue";
            else if (cbBookings.Checked) reportType = "Bookings";
            else if (cbPassengers.Checked) reportType = "Passengers";
            else if (cbFlights.Checked) reportType = "Flights";
            else
            {
                MessageBox.Show("Please select a report type.", "Print report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool periodDaily = rbPeriodDaily.Checked;
            bool periodMonthly = rbPeriodMonthly.Checked;
            bool periodAnnually = rbPeriodAnnually.Checked;
            string periodLabel = periodDaily ? "Daily" : periodMonthly ? "Monthly" : "Annually";

            DataTable dt = BuildReportDataTable(reportType, periodDaily, periodMonthly, periodAnnually);

            if (dt == null || dt.Rows.Count == 0)
            {
                var msg = $"No data available for {reportType} - {periodLabel}.";
                MessageBox.Show(msg, "Print report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblResult.Text = msg;
                return;
            }

            try
            {
                PrintStyledReport(dt, reportType, periodLabel);
                lblResult.Text = "Opened print preview.";
                HidePrintPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open print preview: " + ex.Message, "Print report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResult.Text = "Error: " + ex.Message;
            }
        }

        private void PrintStyledReport(DataTable dt, string reportType, string periodLabel)
        {
            var doc = new PrintDocument();
            doc.DocumentName = $"FRS Report - {reportType} ({periodLabel})";

            int currentRow = 0;
            bool headerDrawn = false;

            doc.PrintPage += (sender, e) =>
            {
                Graphics g = e.Graphics;
                float pageWidth = e.MarginBounds.Width;
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;
                float pageBottom = e.MarginBounds.Bottom;

                // ── Color palette ─────────────────────────────────────
                Color navy = Color.FromArgb(20, 20, 50);
                Color orange = Color.FromArgb(220, 80, 0);
                Color gray = Color.FromArgb(120, 120, 130);
                Color lightGray = Color.FromArgb(230, 230, 235);

                // ── Fonts ─────────────────────────────────────────────
                var fontTitle = new Font("Segoe UI", 18f, FontStyle.Bold);
                var fontSectionHead = new Font("Segoe UI", 10f, FontStyle.Bold);
                var fontLabel = new Font("Segoe UI", 9f, FontStyle.Regular);
                var fontValue = new Font("Segoe UI", 9f, FontStyle.Bold);
                var fontSmall = new Font("Segoe UI", 8f, FontStyle.Regular);
                var fontColHeader = new Font("Segoe UI", 8.5f, FontStyle.Bold);

                // ── Auto-calculate column widths based on content ─────
                float[] colWidths = new float[dt.Columns.Count];
                float minColWidth = 40f;
                float cellPadding = 8f;

                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    // Start with header width
                    float maxW = g.MeasureString(dt.Columns[c].ColumnName, fontColHeader).Width + cellPadding * 2;

                    // Check each row's cell width (sample up to 100 rows for performance)
                    int sampleLimit = Math.Min(dt.Rows.Count, 100);
                    for (int r = 0; r < sampleLimit; r++)
                    {
                        string cell = dt.Rows[r][c]?.ToString() ?? string.Empty;
                        float cellW = g.MeasureString(cell, fontLabel).Width + cellPadding * 2;
                        if (cellW > maxW) maxW = cellW;
                    }

                    colWidths[c] = Math.Max(maxW, minColWidth);
                }

                // Scale columns proportionally if total exceeds page width
                float totalColWidth = colWidths.Sum();
                if (totalColWidth > pageWidth)
                {
                    float scale = pageWidth / totalColWidth;
                    for (int c = 0; c < colWidths.Length; c++)
                        colWidths[c] = Math.Max(colWidths[c] * scale, minColWidth);
                }

                // ── Auto-calculate row height based on font + padding ─
                float cellHeight = g.MeasureString("Ag", fontLabel).Height;
                float rowPaddingTop = 4f;
                float rowPaddingBottom = 4f;
                float rowH = cellHeight + rowPaddingTop + rowPaddingBottom;

                // ── Estimate how many rows fit per page ───────────────
                float headerReserve = headerDrawn ? 0f : 160f; // approx header block height
                float colHeaderH = rowH + 4f;
                float footerReserve = 30f;
                float usableHeight = pageBottom - y - headerReserve - colHeaderH - footerReserve;
                int rowsPerPage = Math.Max(1, (int)(usableHeight / rowH));

                // ── Draw page header (first page only) ────────────────
                if (!headerDrawn)
                {
                    g.FillRectangle(new SolidBrush(navy), x, y, pageWidth, 56);
                    g.DrawString("✈  Flight Reservation System", fontTitle, Brushes.White, x + 12, y + 10);
                    y += 64;

                    g.DrawString($"{reportType.ToUpper()} REPORT  —  {periodLabel.ToUpper()}", fontSectionHead, new SolidBrush(orange), x, y);
                    g.DrawString($"Printed: {DateTime.Now:ddd, MMM d, yyyy  h:mm tt}", fontSmall, new SolidBrush(gray), x + pageWidth - 220, y + 2);
                    y += 22;
                    DrawReportDivider(g, x, y, pageWidth, lightGray);
                    y += 10;

                    RectangleF metaBox = new RectangleF(x, y, pageWidth, 32);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 252)), metaBox);
                    g.DrawRectangle(new Pen(lightGray, 1), metaBox.X, metaBox.Y, metaBox.Width, metaBox.Height);
                    g.DrawString("Printed by:", fontLabel, new SolidBrush(gray), x + 8, y + 8);
                    g.DrawString(Session._user?.Name ?? Environment.UserName, fontValue, new SolidBrush(navy), x + 75, y + 8);
                    y += 42;

                    headerDrawn = true;
                }

                // ── Column header row ──────────────────────────────────
                g.FillRectangle(new SolidBrush(navy), x, y, pageWidth, rowH + 4);
                float colX = x;
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    var headerRect = new RectangleF(colX + cellPadding, y + rowPaddingTop, colWidths[c] - cellPadding, rowH);
                    g.DrawString(dt.Columns[c].ColumnName, fontColHeader, Brushes.White, headerRect);
                    colX += colWidths[c];
                }
                y += rowH + 4;

                // ── Data rows ──────────────────────────────────────────
                bool alternate = false;
                while (currentRow < dt.Rows.Count)
                {
                    if (y + rowH > pageBottom - footerReserve)
                    {
                        e.HasMorePages = true;
                        goto Cleanup;
                    }

                    if (alternate)
                        g.FillRectangle(new SolidBrush(Color.FromArgb(248, 248, 252)), x, y, pageWidth, rowH);

                    DataRow row = dt.Rows[currentRow];
                    colX = x;
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        string cell = row[c]?.ToString() ?? string.Empty;
                        var cellRect = new RectangleF(colX + cellPadding, y + rowPaddingTop, colWidths[c] - cellPadding, rowH);
                        g.DrawString(cell, fontLabel, new SolidBrush(navy), cellRect);
                        colX += colWidths[c];
                    }

                    DrawReportDivider(g, x, y + rowH, pageWidth, lightGray);

                    y += rowH;
                    currentRow++;
                    alternate = !alternate;
                }

                // ── Footer (last page) ─────────────────────────────────
                y += 10;
                DrawReportDivider(g, x, y, pageWidth, lightGray);
                y += 6;
                g.DrawString(
                    $"Flight Reservation System  |  {reportType} Report  |  Total records: {dt.Rows.Count}",
                    fontSmall, new SolidBrush(gray), x, y);

                e.HasMorePages = false;

            Cleanup:
                fontTitle.Dispose();
                fontSectionHead.Dispose();
                fontLabel.Dispose();
                fontValue.Dispose();
                fontSmall.Dispose();
                fontColHeader.Dispose();
            };

            using (var preview = new PrintPreviewDialog())
            {
                preview.Document = doc;
                preview.Width = 1050;
                preview.Height = 780;
                preview.Text = $"Print Preview — {reportType} Report ({periodLabel})";
                preview.ShowDialog();
            }
        }

        // Shared divider helper (mirrors DrawDivider in RAPayment)
        private void DrawReportDivider(Graphics g, float x, float y, float width, Color color)
            => g.DrawLine(new Pen(color, 0.5f), x, y, x + width, y);

        private void ShowBrowserPrintPreview(DataTable dt, string reportType, string periodLabel)
        {
            // Basic HTML + CSS printable template. Adjust styles as needed.
            var sb = new StringBuilder();
            sb.AppendLine("<!doctype html>");
            sb.AppendLine("<html lang=\"en\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\"/>");
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/>");
            sb.AppendLine("<title>Flight Reservation System - " + WebUtility.HtmlEncode(reportType) + "</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("  body { font-family: Segoe UI, Arial, sans-serif; color: #222; margin: 20px; }");
            sb.AppendLine("  header { display:flex; justify-content:space-between; align-items:flex-start; margin-bottom:12px; }");
            sb.AppendLine("  h1 { font-size:16px; margin:0; }");
            sb.AppendLine("  .meta { font-size:12px; color:#666; }");
            sb.AppendLine("  table { width:100%; border-collapse:collapse; font-size:12px; }");
            sb.AppendLine("  th, td { border:1px solid #ddd; padding:6px 8px; text-align:left; vertical-align:top; }");
            sb.AppendLine("  th { background:#f5f5f5; font-weight:600; }");
            sb.AppendLine("  tr { page-break-inside: avoid; }");
            sb.AppendLine("  @media print {");
            sb.AppendLine("    body { margin: 12mm; }");
            sb.AppendLine("    header { margin-bottom:8px; }");
            sb.AppendLine("    footer { position: fixed; bottom: 0; width: 100%; font-size:11px; color:#666; }");
            sb.AppendLine("  }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<header>");
            sb.AppendLine("<div>");
            sb.AppendLine("<h1>Flight Reservation System</h1>");
            sb.AppendLine("<div class=\"meta\">");
            sb.AppendLine(WebUtility.HtmlEncode(reportType) + " — " + WebUtility.HtmlEncode(periodLabel));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div style=\"text-align:right;\">");
            sb.AppendLine("<div class=\"meta\">Printed by: " + WebUtility.HtmlEncode(Session._user?.Name ?? Environment.UserName) + "</div>");
            sb.AppendLine("<div class=\"meta\">Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</header>");

            // Table
            sb.AppendLine("<table>");
            sb.AppendLine("<thead><tr>");
            foreach (DataColumn col in dt.Columns)
                sb.Append("<th>" + WebUtility.HtmlEncode(col.ColumnName) + "</th>");
            sb.AppendLine("</tr></thead>");
            sb.AppendLine("<tbody>");
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("<tr>");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    var cell = row[c]?.ToString() ?? string.Empty;
                    sb.Append("<td>" + WebUtility.HtmlEncode(cell) + "</td>");
                }
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            // Footer with page numbering hint (browsers handle actual page numbers)
            sb.AppendLine("<footer>");
            sb.AppendLine("<div style=\"text-align:right; margin-top:8px;\">Page <span class=\"pageno\"></span></div>");
            sb.AppendLine("</footer>");

            // Auto-open print dialog and optionally close the tab after printing.
            sb.AppendLine("<script>");
            sb.AppendLine("  window.onload = function() {");
            sb.AppendLine("    // Defer slightly to ensure rendering complete in some browsers");
            sb.AppendLine("    setTimeout(function(){ window.print(); }, 150);");
            sb.AppendLine("  };");
            // Some browsers block window.close() on non-scripted windows; avoid forced close to not be intrusive.
            sb.AppendLine("</script>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            // Write to temp HTML file
            string fileName = $"FRS_Report_{reportType}_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string tempPath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllText(tempPath, sb.ToString(), Encoding.UTF8);

            // Open in default browser (UseShellExecute = true will use default application)
            var psi = new ProcessStartInfo
            {
                FileName = tempPath,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        /// <summary>
        /// Build a simple DataTable for the requested report and period.
        /// Period semantics:
        /// - daily: every record (no grouping)
        /// - monthly: grouped by Year+Month
        /// - annually: grouped by Year
        /// Aggregations implemented per latest spec:
        /// - Revenue: per-record for daily; aggregated for monthly/yearly
        /// - Bookings: per-record for daily; distinct-aircraft per airline for monthly; per-year+airline for annually
        /// - Passengers: per-record for daily; grouped by BookingID+SeatClass for monthly; grouped by Year+BookingID+SeatClass for annually
        /// - Flights: per-record for daily; route aggregation with Year+Month for monthly; Year for annually
        /// </summary>
        private DataTable BuildReportDataTable(string reportType, bool periodDaily, bool periodMonthly, bool periodAnnually)
        {
            DataTable dt = new DataTable();

            // fetch flattened lists once (these return the appropriate set of records based on period)
            var bookings = GetBookingsForPeriod(periodDaily, periodMonthly, periodAnnually);
            var passengers = GetPassengersForPeriod(periodDaily, periodMonthly, periodAnnually);
            var flights = GetFlightsForPeriod(periodDaily, periodMonthly, periodAnnually);

            if (reportType == "Revenue")
            {
                if (periodDaily)
                {
                    // per-record
                    dt.Columns.Add("BookingID");
                    dt.Columns.Add("TotalAmount");
                    dt.Columns.Add("BaseFare");
                    dt.Columns.Add("Tax");
                    dt.Columns.Add("ServiceFee");
                    dt.Columns.Add("AddedAt");

                    foreach (var b in bookings.OrderBy(b => b.AddedAt))
                        dt.Rows.Add(b.ID, $"₱{b.TotalAmount:N2}", $"₱{b.BaseFare:N2}", $"₱{b.Tax:N2}", $"₱{b.ServiceFee:N2}", b.AddedAt.ToString("yyyy-MM-dd"));

                    return dt;
                }

                if (periodMonthly)
                {
                    dt.Columns.Add("Year");
                    dt.Columns.Add("Month");
                    dt.Columns.Add("TotalAmount");
                    dt.Columns.Add("BaseFare");
                    dt.Columns.Add("Tax");
                    dt.Columns.Add("ServiceFee");

                    var groups = bookings
                                 .GroupBy(b => new { b.AddedAt.Year, b.AddedAt.Month })
                                 .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month);

                    foreach (var g in groups)
                    {
                        decimal total = g.Sum(x => x.TotalAmount);
                        decimal baseFare = g.Sum(x => x.BaseFare);
                        decimal tax = g.Sum(x => x.Tax);
                        decimal service = g.Sum(x => x.ServiceFee);
                        dt.Rows.Add(g.Key.Year, g.Key.Month, $"₱{total:N2}", $"₱{baseFare:N2}", $"₱{tax:N2}", $"₱{service:N2}");
                    }

                    return dt;
                }

                // annually
                dt.Columns.Add("Year");
                dt.Columns.Add("TotalAmount");
                dt.Columns.Add("BaseFare");
                dt.Columns.Add("Tax");
                dt.Columns.Add("ServiceFee");

                var groupsYear = bookings
                                 .GroupBy(b => b.AddedAt.Year)
                                 .OrderBy(g => g.Key);

                foreach (var g in groupsYear)
                {
                    decimal total = g.Sum(x => x.TotalAmount);
                    decimal baseFare = g.Sum(x => x.BaseFare);
                    decimal tax = g.Sum(x => x.Tax);
                    decimal service = g.Sum(x => x.ServiceFee);
                    dt.Rows.Add(g.Key, $"₱{total:N2}", $"₱{baseFare:N2}", $"₱{tax:N2}", $"₱{service:N2}");
                }

                return dt;
            }

            if (reportType == "Bookings")
            {
                if (periodDaily)
                {
                    // per-record
                    dt.Columns.Add("BookingID");
                    dt.Columns.Add("Aircraft");
                    dt.Columns.Add("Airline");
                    dt.Columns.Add("AddedAt");

                    var flightLookup = StatisticsManager.GetFlightCollection.ToDictionary(f => f.ID, f => f);
                    foreach (var b in bookings.OrderBy(b => b.AddedAt))
                    {
                        FlightRecord f;
                        if (flightLookup.TryGetValue(b.FlightID, out f))
                            dt.Rows.Add(b.ID, f.Aircraft ?? "Unknown", f.Airline ?? "Unknown", b.AddedAt.ToString("yyyy-MM-dd"));
                        else
                            dt.Rows.Add(b.ID, "Unknown", "Unknown", b.AddedAt.ToString("yyyy-MM-dd"));
                    }

                    return dt;
                }

                if (periodMonthly)
                {
                    // aggregated per month: Year, Month, Airline, DistinctAircraftCount
                    dt.Columns.Add("Year");
                    dt.Columns.Add("Month");
                    dt.Columns.Add("Airline");
                    dt.Columns.Add("DistinctAircraftCount");

                    var flightLookup = StatisticsManager.GetFlightCollection.ToDictionary(f => f.ID, f => f);

                    var grouped = bookings
                                  .GroupBy(b => new { b.AddedAt.Year, b.AddedAt.Month })
                                  .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month);

                    foreach (var gm in grouped)
                    {
                        var perAirline = gm
                            .Select(b =>
                            {
                                FlightRecord f;
                                if (flightLookup.TryGetValue(b.FlightID, out f))
                                    return new { Airline = f.Airline ?? "Unknown", Aircraft = f.Aircraft ?? "Unknown" };
                                return new { Airline = "Unknown", Aircraft = "Unknown" };
                            })
                            .GroupBy(x => x.Airline, StringComparer.OrdinalIgnoreCase)
                            .OrderBy(g => g.Key);

                        foreach (var g in perAirline)
                        {
                            int distinctAircraft = g.Select(x => x.Aircraft).Distinct(StringComparer.OrdinalIgnoreCase).Count();
                            dt.Rows.Add(gm.Key.Year, gm.Key.Month, g.Key, distinctAircraft);
                        }
                    }

                    return dt;
                }

                // annually: Year, Airline, DistinctAircraftCount
                dt.Columns.Add("Year");
                dt.Columns.Add("Airline");
                dt.Columns.Add("DistinctAircraftCount");

                var flightLookupAll = StatisticsManager.GetFlightCollection.ToDictionary(f => f.ID, f => f);

                var groupedYear = bookings
                                  .GroupBy(b => b.AddedAt.Year)
                                  .OrderBy(g => g.Key);

                foreach (var gy in groupedYear)
                {
                    var perAirline = gy
                        .Select(b =>
                        {
                            FlightRecord f;
                            if (flightLookupAll.TryGetValue(b.FlightID, out f))
                                return new { Airline = f.Airline ?? "Unknown", Aircraft = f.Aircraft ?? "Unknown" };
                            return new { Airline = "Unknown", Aircraft = "Unknown" };
                        })
                        .GroupBy(x => x.Airline, StringComparer.OrdinalIgnoreCase)
                        .OrderBy(g => g.Key);

                    foreach (var g in perAirline)
                    {
                        int distinctAircraft = g.Select(x => x.Aircraft).Distinct(StringComparer.OrdinalIgnoreCase).Count();
                        dt.Rows.Add(gy.Key, g.Key, distinctAircraft);
                    }
                }

                return dt;
            }

            if (reportType == "Passengers")
            {
                if (periodDaily)
                {
                    // per-record
                    dt.Columns.Add("BookingPassengerID");
                    dt.Columns.Add("BookingID");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Nationality");
                    dt.Columns.Add("Gender");
                    dt.Columns.Add("Age");
                    dt.Columns.Add("SeatClass");
                    dt.Columns.Add("SeatLabel");
                    dt.Columns.Add("AddedAt");

                    foreach (var p in passengers.OrderBy(p => p.AddedAt))
                        dt.Rows.Add(p.ID, p.BookingID, p.Name, p.Nationality, p.Gender, p.Age, p.SeatClass ?? "Unknown", p.SeatLabel ?? "", p.AddedAt.ToString("yyyy-MM-dd"));

                    return dt;
                }

                if (periodMonthly)
                {
                    // Year, Month, BookingID, SeatClass, PassengerCount
                    dt.Columns.Add("Year");
                    dt.Columns.Add("Month");
                    dt.Columns.Add("BookingID");
                    dt.Columns.Add("SeatClass");
                    dt.Columns.Add("PassengerCount");

                    var groups = passengers
                                 .GroupBy(p => new { Year = p.AddedAt.Year, Month = p.AddedAt.Month, p.BookingID, SeatClass = string.IsNullOrWhiteSpace(p.SeatClass) ? "Unknown" : p.SeatClass })
                                 .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month).ThenBy(g => g.Key.BookingID);

                    foreach (var g in groups)
                        dt.Rows.Add(g.Key.Year, g.Key.Month, g.Key.BookingID, g.Key.SeatClass, g.Count());

                    return dt;
                }

                // annually: Year, BookingID, SeatClass, PassengerCount
                dt.Columns.Add("Year");
                dt.Columns.Add("BookingID");
                dt.Columns.Add("SeatClass");
                dt.Columns.Add("PassengerCount");

                var groupsYear = passengers
                                 .GroupBy(p => new { Year = p.AddedAt.Year, p.BookingID, SeatClass = string.IsNullOrWhiteSpace(p.SeatClass) ? "Unknown" : p.SeatClass })
                                 .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.BookingID);

                foreach (var g in groupsYear)
                    dt.Rows.Add(g.Key.Year, g.Key.BookingID, g.Key.SeatClass, g.Count());

                return dt;
            }

            if (reportType == "Flights")
            {
                if (periodDaily)
                {
                    // per-record
                    dt.Columns.Add("FlightID");
                    dt.Columns.Add("Aircraft");
                    dt.Columns.Add("Airline");
                    dt.Columns.Add("Departure");
                    dt.Columns.Add("Arrival");
                    dt.Columns.Add("Origin");
                    dt.Columns.Add("Destination");
                    dt.Columns.Add("DistanceKM");
                    dt.Columns.Add("DurationMin");
                    dt.Columns.Add("AddedAt");

                    foreach (var f in flights.OrderBy(f => f.Departure))
                    {
                        var origin = AirportCollection.Get.FirstOrDefault(a => a.ID == f.OriginID)?.IATA ?? f.Origin ?? "Unknown";
                        var dest = AirportCollection.Get.FirstOrDefault(a => a.ID == f.DestinationID)?.IATA ?? f.Destination ?? "Unknown";
                        dt.Rows.Add(f.ID, f.Aircraft ?? "Unknown", f.Airline ?? "Unknown", f.Departure.ToString("yyyy-MM-dd HH:mm"), f.Arrival.ToString("yyyy-MM-dd HH:mm"), origin, dest, f.DistanceKM.ToString(), f.DurationMin.ToString(), f.AddedAt.ToString("yyyy-MM-dd"));
                    }

                    return dt;
                }

                if (periodMonthly)
                {
                    // Year, Month, OriginIATA, DestinationIATA, FlightCount
                    dt.Columns.Add("Year");
                    dt.Columns.Add("Month");
                    dt.Columns.Add("OriginIATA");
                    dt.Columns.Add("DestinationIATA");
                    dt.Columns.Add("FlightCount");

                    var groups = flights
                                 .GroupBy(f => new { f.Departure.Year, f.Departure.Month, Origin = AirportCollection.Get.FirstOrDefault(a => a.ID == f.OriginID)?.IATA ?? f.Origin ?? "Unknown", Dest = AirportCollection.Get.FirstOrDefault(a => a.ID == f.DestinationID)?.IATA ?? f.Destination ?? "Unknown" })
                                 .Select(g => new { g.Key.Year, g.Key.Month, g.Key.Origin, g.Key.Dest, Count = g.Count() })
                                 .OrderBy(g => g.Year).ThenBy(g => g.Month).ThenByDescending(g => g.Count);

                    foreach (var r in groups)
                        dt.Rows.Add(r.Year, r.Month, r.Origin, r.Dest, r.Count);

                    return dt;
                }

                // annually: Year, OriginIATA, DestinationIATA, FlightCount
                dt.Columns.Add("Year");
                dt.Columns.Add("OriginIATA");
                dt.Columns.Add("DestinationIATA");
                dt.Columns.Add("FlightCount");

                var groupsYear = flights
                                 .GroupBy(f => new { Year = f.Departure.Year, Origin = AirportCollection.Get.FirstOrDefault(a => a.ID == f.OriginID)?.IATA ?? f.Origin ?? "Unknown", Dest = AirportCollection.Get.FirstOrDefault(a => a.ID == f.DestinationID)?.IATA ?? f.Destination ?? "Unknown" })
                                 .Select(g => new { g.Key.Year, g.Key.Origin, g.Key.Dest, Count = g.Count() })
                                 .OrderBy(g => g.Year).ThenByDescending(g => g.Count);

                foreach (var r in groupsYear)
                    dt.Rows.Add(r.Year, r.Origin, r.Dest, r.Count);

                return dt;
            }

            return dt;
        }

        private List<BookingRecord> GetBookingsForPeriod(bool daily, bool monthly, bool annually)
        {
            if (daily)
            {
                // flatten every day (returns every record)
                return StatisticsManager.GetBookingDailyCollection
                            .SelectMany(kvp => kvp.Value)
                            .ToList();
            }
            if (monthly)
            {
                // flatten every month (returns every record)
                return StatisticsManager.GetBookingMonthlyCollection
                            .SelectMany(kvp => kvp.Value)
                            .ToList();
            }
            // annually -> aggregate all data (flatten monthly as source of truth for all records)
            return StatisticsManager.GetBookingMonthlyCollection
                        .SelectMany(kvp => kvp.Value)
                        .ToList();
        }

        private List<BookingPassengerRecord> GetPassengersForPeriod(bool daily, bool monthly, bool annually)
        {
            if (daily)
            {
                return StatisticsManager.GetBookingPassengerDailyCollection
                            .SelectMany(kvp => kvp.Value)
                            .ToList();
            }
            if (monthly)
            {
                return StatisticsManager.GetBookingPassengerMonthlyCollection
                            .SelectMany(kvp => kvp.Value)
                            .ToList();
            }
            return StatisticsManager.GetBookingPassengerMonthlyCollection
                        .SelectMany(kvp => kvp.Value)
                        .ToList();
        }

        private List<FlightRecord> GetFlightsForPeriod(bool daily, bool monthly, bool annually)
        {
            if (daily)
            {
                return StatisticsManager.GetFlightDailyCollection
                            .SelectMany(kvp => kvp.Value)
                            .ToList();
            }
            if (monthly)
            {
                return StatisticsManager.GetFlightMonthlyCollection
                            .SelectMany(kvp => kvp.Value)
                            .ToList();
            }
            return StatisticsManager.GetFlightMonthlyCollection
                        .SelectMany(kvp => kvp.Value)
                        .ToList();
        }

        private void Statistics_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HidePrintPanel();
            cbRevenue.Checked = true;
            rbPeriodDaily.Checked = true;
        }
    }
}