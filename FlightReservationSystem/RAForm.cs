using FlightReservationSystem.UserControls;
using FlightReservationSystem.UserControls.Reservation_Agent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class RAForm : Form
    {
        public RAForm()
        {
            InitializeComponent();
        }

        private void RAForm_Load(object sender, EventArgs e)
        {
            Header header = new Header();
            header.Dock = DockStyle.Fill;  
            pnlHeader.Controls.Add(header);

            RANavigation navigation = new RANavigation();
            navigation.Dock = DockStyle.Fill;
            pnlNavigation.Controls.Add(navigation);

            RAFlights flights = new RAFlights();
            flights.Dock = DockStyle.Fill;
            pnlFuncs.Controls.Add(flights);

        }

        private void LoadPassengerForms(int passengerCount)
        {
            pnlFuncs.AutoScroll = true;
            pnlFuncs.Controls.Clear();

            for (int i = passengerCount; i >= 1; i--)
            {
                RAPassengerDetails form = new RAPassengerDetails();
                form.PassengerNumber = i;
                form.Dock = DockStyle.Top;
                pnlFuncs.Controls.Add(form);
            }
        }
    }
}
