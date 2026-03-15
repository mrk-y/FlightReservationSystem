using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using FlightReservationSystem.Services;
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
    public partial class Login : Form
    {
        public static Login Current { get; set; } = null; 

        public Label _lblUserID => lblUserID;
        public Label _lblPassword => lblPassword;

        public Login()
        {
            InitializeComponent();
            
            Current = this;
            
            InitData();
            
        }

        private void InitData()
        {
            // false means not visible
            tbPassword.Tag = false;

            ErrorCollection.Clear();
            PopulateErrorUIs();
        }

        private void TogglePasswordVisibility()
        {
            if (tbPassword.Tag is bool visible)
            {
                if (visible)
                {
                    tbPassword.PasswordChar = '*';
                    picVisibility.Image = Properties.Resources.eyeOpen;
                }
                else
                {
                    tbPassword.PasswordChar = '\0';
                    picVisibility.Image = Properties.Resources.eyeClosed;
                }

                tbPassword.Tag = !visible;
            }
        }

        private void PopulateErrorUIs()
        {
            ErrorUIRegistry.Add(new ErrorUI { Provider = errorProvider1, Target = lblUserID, Field = tbUserID });
            ErrorUIRegistry.Add(new ErrorUI { Provider = errorProvider2, Target = lblPassword, Field = tbPassword });
        }

        private bool AreLoginFieldsValid(string userID, string password)
        {
            if (string.IsNullOrEmpty(userID)) ErrorManager.Add(new ErrorEntry { Message = "User ID field cannot be empty.", AssociatedControls = { lblUserID } });
            else if (userID.Length < 7) ErrorManager.Add(new ErrorEntry { Message = "User ID must be 7 characters long.", AssociatedControls = { lblUserID } });
                
            if (string.IsNullOrEmpty(password)) ErrorManager.Add(new ErrorEntry { Message = "Password field cannot be empty.", AssociatedControls = { lblPassword } });
            else if (password.Length < 8) ErrorManager.Add(new ErrorEntry { Message = "Password must be at least 8 characters long.", AssociatedControls = { lblPassword } });

            if (ErrorCollection.Has)
            {
                ErrorManager.Alert();
                ErrorManager.Highlight(true);
                return false;
            } 

            return true;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBoxHelper.ShowQuestionMessage("Are you sure you want to exit?\nAny incomplete progress you made will be lost.");

                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        private void tbUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
            else e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
        }

        private void picVisibility_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = tbUserID.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (!AreLoginFieldsValid(userID, password)) return;

            Authentication.Init(Current);
            Authentication.AuthenticateCredentials(userID, password);
        }
    }
}
