using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.SystemAdmin
{
    public partial class SANavigation : UserControl
    {        
        public SANavigation()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            NavigationTags();
        }

        private void NavigationTags()
        {
            btnAddAircraft.Tag = "AddAircraft";
        }
    }
}
