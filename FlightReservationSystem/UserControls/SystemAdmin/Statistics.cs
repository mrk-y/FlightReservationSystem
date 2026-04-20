using FlightReservationSystem.Debugging;
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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
            LoadBarChart();
        }

        private void LoadBarChart()
        {
            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Series = new ISeries[]
            {
        new ColumnSeries<double>
        {
            Name = "Revenue (₱)",
            Values = new double[] { 20000, 18000, 25000, 28000, 30000, 35000, 33000, 31000, 32000, 38000, 37000, 45000 }
        }
            };

            pnlRevenue.Controls.Add(chart);
        }

        private void Statistics_ParentChanged(object sender, EventArgs e)
        {
            // Change navigation UI based on content
            MainFormUIHelper.UpdateNavigationState(this);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }
    }
}
