using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using LiveChartsCore;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
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
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DataSeeder.PopulateAircraftStatAny();
            LoadSummaryCards();
            LoadSeatClassChart();
            LoadRevenuePerDayChart();
        }

        private void LoadSummaryCards()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();

                    lblTotalBookingsVal.Text = new SqlCommand(
                        "SELECT COUNT(*) FROM Bookings", con)
                        .ExecuteScalar().ToString();

                    lblTotalRevenueVal.Text = "₱" + string.Format("{0:N2}",
                        new SqlCommand(
                        "SELECT ISNULL(SUM(TotalAmount), 0) FROM Bookings WHERE IsActive = 1", con)
                        .ExecuteScalar());

                    lblTotalPassengersVal.Text = new SqlCommand(
                        "SELECT COUNT(*) FROM BookingPassengers", con)
                        .ExecuteScalar().ToString();

                    lblTotalFlightsVal.Text = new SqlCommand(
                        "SELECT COUNT(*) FROM Flights WHERE IsActive = 1", con)
                        .ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Loading summary cards aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while loading summary cards.");
                    return;
                }
            }
        }

        private void LoadSeatClassChart()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();

                    var slices = new List<PieSlice>();

                    var cmd = new SqlCommand(
                        "SELECT SeatClass, COUNT(*) FROM BookingPassengers GROUP BY SeatClass", con);
                    var reader = cmd.ExecuteReader();

                    var colors = new[]
                    {
                        OxyColors.SteelBlue,
                        OxyColors.Coral,
                        OxyColors.MediumSeaGreen,
                        OxyColors.Goldenrod,
                        OxyColors.MediumPurple
                    };
                    int colorIndex = 0;

                    while (reader.Read())
                    {
                        slices.Add(new PieSlice(reader.GetString(0), reader.GetInt32(1))
                        {
                            Fill = colors[colorIndex % colors.Length]
                        });
                        colorIndex++;
                    }

                    var model = new PlotModel { Title = "Seat Class Distribution" };
                    var series = new PieSeries
                    {
                        StrokeThickness = 2.0,
                        InsideLabelPosition = 0.8,
                        AngleSpan = 360,
                        StartAngle = 0
                    };

                    foreach (var slice in slices)
                        series.Slices.Add(slice);

                    model.Series.Add(series);

                    pvSeatClassChart.Model = model;
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Loading seat class chart aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while loading seat class chart.");
                    return;
                }
            }
        }

        private void LoadRevenuePerDayChart()
        {
            using (SqlConnection con = DatabaseConnection.Get())
            {
                try
                {
                    con.Open();
                    var items = new List<double>();
                    var categoryLabels = new List<string>();
                    var cmd = new SqlCommand(@"
                        SELECT TOP 5
                            CAST(CreatedAt AS DATE), ISNULL(SUM(TotalAmount), 0)
                        FROM Bookings
                        GROUP BY CAST(CreatedAt AS DATE)
                        ORDER BY CAST(CreatedAt AS DATE) DESC", con);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categoryLabels.Add(reader.GetDateTime(0).ToString("MM/dd"));
                        items.Add((double)reader.GetDecimal(1));
                    }
                    categoryLabels.Reverse();
                    items.Reverse();

                    var model = new PlotModel { Title = "Revenue Per Day" };

                    var rectSeries = new RectangleBarSeries
                    {
                        FillColor = OxyColors.SteelBlue,
                        StrokeColor = OxyColors.Black,
                        StrokeThickness = 1,
                        TrackerFormatString = "Date: {3}\nAmount (₱): {6:#,##0.00}"
                    };

                    for (int i = 0; i < items.Count; i++)
                    {
                        rectSeries.Items.Add(new RectangleBarItem(i - 0.4, 0, i + 0.4, items[i]));
                    }
                    model.Series.Add(rectSeries);

                    var categoryAxis = new CategoryAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Date"
                    };
                    foreach (var label in categoryLabels)
                        categoryAxis.Labels.Add(label);

                    var valueAxis = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Amount (₱)",
                        MinimumPadding = 0,
                        AbsoluteMinimum = 0
                    };

                    model.Axes.Add(categoryAxis);
                    model.Axes.Add(valueAxis);
                    pvRevenuePerDayChart.Model = model;
                }
                catch (Exception ex)
                {
                    DebugLogger.LogWithStackTrace($"{ex.Message}. Loading revenue chart aborted.");
                    MessageBoxHelper.ShowDeveloperErrorMessage("An unexpected error occured while loading revenue chart.");
                    return;
                }
            }
        }

        private void Statistics_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }
    }
}
