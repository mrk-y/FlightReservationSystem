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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void LoadHeader( UserControl nav)
        {
            pnlHeader.Controls.Clear();
            nav.Dock = DockStyle.Fill;
            pnlHeader.Controls.Add(nav);
            nav.BringToFront();
        }

        public void LoadModule(UserControl module)
        {
            pnlMain.Controls.Clear();
            module.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(module);
            module.BringToFront();
        }
    }
}
