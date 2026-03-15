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
        private static SANavigation _saNavigation = null;
        private static Button _btnAddAircraft => _saNavigation.btnAddAircraft;

        public SANavigation()
        {
            InitializeComponent();
            _saNavigation = this;
            InitData();
        }

        private static void InitData()
        {
            NavigationTags();
        }

        private static void NavigationTags()
        {
            _btnAddAircraft.Tag = "AddAircraft";
        }

    }
}
