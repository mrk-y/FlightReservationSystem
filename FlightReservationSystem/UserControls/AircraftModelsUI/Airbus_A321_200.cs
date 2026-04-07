using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.AircraftModelsUI
{
    public partial class Airbus_A321_200 : UserControl
    {
        public Airbus_A321_200()
        {
            InitializeComponent();
            InitUI();
        }
        private void InitUI()
        {
            ShowLegendColors();
        }

        private void ShowLegendColors()
        {
            btnRegPass.BackColor = AircraftManager.GetSeatTypeUICollection[0].BackColor;
            btnRegPass.FlatAppearance.BorderColor = AircraftManager.GetSeatTypeUICollection[0].BorderColor;

            btnExitRow.BackColor = AircraftManager.GetSeatTypeUICollection[1].BackColor;
            btnExitRow.FlatAppearance.BorderColor = AircraftManager.GetSeatTypeUICollection[1].BorderColor;

            btnPassWNuatAller.BackColor = AircraftManager.GetSeatTypeUICollection[2].BackColor;
            btnPassWNuatAller.FlatAppearance.BorderColor = AircraftManager.GetSeatTypeUICollection[2].BorderColor;

            btnUnaccomMinor.BackColor = AircraftManager.GetSeatTypeUICollection[3].BackColor;
            btnUnaccomMinor.FlatAppearance.BorderColor = AircraftManager.GetSeatTypeUICollection[3].BorderColor;

            btnWheelPass.BackColor = AircraftManager.GetSeatTypeUICollection[4].BackColor;
            btnWheelPass.FlatAppearance.BorderColor = AircraftManager.GetSeatTypeUICollection[4].BorderColor;
        }
    }
}
