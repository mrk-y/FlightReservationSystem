using FlightReservationSystem.Data.Reference.Seat;
using FlightReservationSystem.Debugging;
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
    public partial class ATR_72_600 : UserControl
    {
        public ATR_72_600()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            ShowLegendColors();
            ShowTags();
        }

        private void ShowLegendColors()
        {
            btnRegPass.BackColor = SeatTypeUICollection.Get[0].BackColor;
            btnRegPass.FlatAppearance.BorderColor = SeatTypeUICollection.Get[0].BorderColor;

            btnExitRow.BackColor = SeatTypeUICollection.Get[1].BackColor;
            btnExitRow.FlatAppearance.BorderColor = SeatTypeUICollection.Get[1].BorderColor;

            btnPassWNuatAller.BackColor = SeatTypeUICollection.Get[2].BackColor;
            btnPassWNuatAller.FlatAppearance.BorderColor = SeatTypeUICollection.Get[2].BorderColor;

            btnUnaccomMinor.BackColor = SeatTypeUICollection.Get[3].BackColor;
            btnUnaccomMinor.FlatAppearance.BorderColor = SeatTypeUICollection.Get[3].BorderColor;

            btnWheelPass.BackColor = SeatTypeUICollection.Get[4].BackColor;
            btnWheelPass.FlatAppearance.BorderColor = SeatTypeUICollection.Get[4].BorderColor;
        }

        private void ShowTags()
        {
            int mainCont = this.Controls.Count;

            for (int i = 0; i < mainCont; i++)
            {
                if (this.Controls[i] is Panel pnl)
                {
                    int pnlCont = pnl.Controls.Count;

                    for (int j = 0; j < pnlCont; j++)
                    {
                        if (pnl.Controls[j] is Button btn)
                        {
                            string tags = btn.Tag as string;
                            btn.Font = new Font("Segoe UI", 6);
                            btn.Text = tags;
                        }
                    }
                }
            }
        }
    }
}
