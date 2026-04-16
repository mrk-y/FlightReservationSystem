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
        private static MainForm Current { get; set; } = null;
        public static Panel _pnlNavigation => Current.pnlNavigation;
        public static Panel _pnlContent => Current.pnlContent;


        public static UserControl _navigation = null;
        public static UserControl _content = null;
        private static bool IsLoggingOut = false;

        public MainForm()
        {
            InitializeComponent();
            InitData();
        }

        public static void Init(UserControl content, UserControl navigation = null)
        {
            if (content == null)
            {
                DebugLogger.LogWithStackTrace("content is null. Initialization aborted.");
                MessageBoxHelper.ShowDeveloperErrorMessage("Page content does not exist.");
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
        }

        private void InitData()
        {
            Current = this;

            if (Current == null)
            {
                DebugLogger.LogWithStackTrace("Current is null. Data initialization aborted.");
                return;
            }

            ShowUserIDName();
        }

        private void ShowUserIDName()
        {
            string userName = UserManager.GetUser.Name;
            string userID = UserManager.GetUser.ID;

            lblUsernameVal.Text = $"{userName} ({userID})";
        }

        public static void CloseForm()
        {
            IsLoggingOut = true;
            Current.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Application exit verification
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to exit?\nAny incomplete progress you made will be lost.");
                
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                if (IsLoggingOut) return;

                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
