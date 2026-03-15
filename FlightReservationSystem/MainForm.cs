using FlightReservationSystem.Data.Runtime.User;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class MainForm : Form
    {
        public static MainForm Current { get; set; } = null;
        public static Panel _pnlNavigation => Current.pnlNavigation;
        public static Panel _pnlContent => Current.pnlContent;


        public static UserControl _navigation = null;
        public static UserControl _content = null;

        public MainForm()
        {
            InitializeComponent();
            
            Current = this;
            
            InitData();
        }

        public static void Init(UserControl content, UserControl navigation = null)
        {
            if (content == null)
            {
                DebugLogger.Log("[Dev] content is null. Cannot add content in MainForm.");
                MessageBoxHelper.ShowDeveloperErrorMessage("Page's content does not exist, so no content can be shown.");
                return;
            }

            if (navigation != null)
            {
                _pnlNavigation.SuspendLayout();
                _pnlNavigation.Controls.Clear();
                _pnlNavigation.Controls.Add(navigation);
                _pnlNavigation.ResumeLayout();

                _navigation = navigation;
            }

            _pnlContent.SuspendLayout();
            _pnlContent.Controls.Clear();
            _pnlContent.Controls.Add(content);
            _pnlContent.ResumeLayout();

            _content = content;

            MessageBox.Show(_navigation.Name);
            MessageBox.Show(_content.Name);
        }

        private void InitData()
        {
            lblUsernameVal.Text = Session._user.Name;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to exit? Any incomplete progress you made will be lost.");

                if (result == DialogResult.No) e.Cancel = true;
            }
        }
    }
}
