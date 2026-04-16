using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationSystem;
using FlightReservationSystem.Helpers;

namespace FlightReservationSystem.UserControls
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public bool LogoutVisible
        {
            get => pboLogout.Visible;
            set => pboLogout.Visible = value;
        }

        private void pboLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you would like to log out?");

            if (result == DialogResult.Yes)
            {
                // Show login form
                LoginForm login = new LoginForm();
                login.Show();

                // Hide the parent form that contains this control (e.g., MainForm)
                Form parent = this.FindForm();
                if (parent != null)
                {
                    parent.Hide();
                }
            }
        }

        private void Header_Load(object sender, EventArgs e)
        {

        }
    }
}
