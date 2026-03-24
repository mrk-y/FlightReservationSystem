using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
using FlightReservationSystem.UserControls.SystemAdmin;
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
    public partial class LoginForm : Form
    {
        private static LoginForm Current { get; set; } = null; 

        public static Label _lblUserID => Current.lblUserID; 
        public static Label _lblPassword => Current.lblPassword;

        public LoginForm()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            Current = this;

            if (Current == null)
            {
                DebugLogger.LogWithStackTrace("Current is null. Data initialization aborted.");
                return;
            }

            tbPasswordVal.Tag = false; // false means not visible

            PopulateErrorUI();
        }

        private void PopulateErrorUI()
        {
            ErrorUICollection.Add(new ErrorUIRecord { Provider = errorProvider1, Target = lblUserID, Field = tbUserIDVal,  DefaultValue = string.Empty });
            ErrorUICollection.Add(new ErrorUIRecord { Provider = errorProvider2, Target = lblPassword, Field = tbPasswordVal, DefaultValue = string.Empty });
        }

        private bool AreLoginFieldsValid(string userID, string password)
        {
            if (string.IsNullOrWhiteSpace(userID)) ErrorManager.Add(new ErrorRecord { Message = "User ID field cannot be empty.", AssociatedControls = { lblUserID } });
            else if (userID.Length < 7) ErrorManager.Add(new ErrorRecord { Message = "User ID must be 7 characters long.", AssociatedControls = { lblUserID } });
                
            if (string.IsNullOrWhiteSpace(password)) ErrorManager.Add(new ErrorRecord { Message = "Password field cannot be empty.", AssociatedControls = { lblPassword } });
            else if (password.Length < 8) ErrorManager.Add(new ErrorRecord { Message = "Password must be at least 8 characters long.", AssociatedControls = { lblPassword } });

            if (ErrorCollection.Get.Count != 0)
            {
                ErrorManager.Alert();
                ErrorManager.Highlight(true);
                return false;
            } 

            return true;
        }

        public static void HideForm()
        {
            Current.Hide();   
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
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

                Application.Exit();
            }
        }

        private void tbUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Do not allow whitespaces and caps lock chars

            if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true;         
            else e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Do not allow whitespaces

            if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
        }

        private void picVisibility_Click(object sender, EventArgs e)
        {
            // Toggle password visibility

            if (tbPasswordVal.Tag is bool visible)
            {
                if (visible)
                {
                    tbPasswordVal.PasswordChar = '*';
                    picVisibility.Image = Properties.Resources.EyeOpen;
                }
                else
                {
                    tbPasswordVal.PasswordChar = '\0';
                    picVisibility.Image = Properties.Resources.EyeClosed;
                }

                tbPasswordVal.Tag = !visible;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Login

            ControlValResetter.ClearProviders();
            ErrorCollection.Clear();

            string userID = tbUserIDVal.Text.Trim();
            string password = tbPasswordVal.Text.Trim();

            if (!AreLoginFieldsValid(userID, password)) return;

            AccountSession.AuthenticateLogin(userID, password);
        }
    }
}
