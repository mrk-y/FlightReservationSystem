using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Services
{
    internal class PageFieldsHandler
    {

        public 

        public bool AreLoginFieldsValid(string userID, string password)
        {
            foreach (ErrorUI errorUI in ErrorCollection.GetErrorUIs())
            {
                errorUI.Provider.Clear();
            }

            if (string.IsNullOrEmpty(userID)) ErrorCollection.AddErrorMessage(new ErrorMessage { Message = "User ID field cannot be empty.", AssociatedControl = _login._lblUserID });
            else if (userID.Length < 7) ErrorCollection.AddErrorMessage(new ErrorMessage { Message = "User ID must be 7 characters long.", AssociatedControl = _login._lblUserID });
            if (string.IsNullOrEmpty(password)) ErrorCollection.AddErrorMessage(new ErrorMessage { Message = "Password field cannot be empty.", AssociatedControl = _login._lblPassword });
            else if (password.Length < 8) ErrorCollection.AddErrorMessage(new ErrorMessage { Message = "Pasword must be at least 8 characters long.", AssociatedControl = _login._lblPassword });

            if (ErrorCollection.GetErrorCount() != 0)
            {
                MessageBox.Show(Logger.ErrorLogs(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorUIHelper.ShowErrorProvidersIndividual();
                return false;
            }

            return true;
        }
    }
}
