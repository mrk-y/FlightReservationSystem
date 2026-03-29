using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    public partial class RAFlightCards : UserControl
    {
        public RAFlightCards()
        {
            InitializeComponent();
        }

        private void RAFlightCards_Load(object sender, EventArgs e)
        {
            // Initialization logic here if needed
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            // Open a detail form/panel here
            MessageBox.Show("Viewing flight details..."); // placeholder
        }
    }
}