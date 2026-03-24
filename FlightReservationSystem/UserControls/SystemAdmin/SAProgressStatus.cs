using FlightReservationSystem.Data.Reference.Status;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Others
{
    public partial class SAProgressStatus : UserControl
    {

        public SAProgressStatus()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            ShowToolTips();
        }

        public void Init(int statusID)
        {
            var statusCollection = StatusCollection.Get;

            if (statusCollection.Count == 0)
            {
                DebugLogger.LogWithStackTrace("statusCollection is empty. Initialization aborted.");
                return;
            }

            for (int i = 0; i < statusCollection.Count; i++)
            {
                var statusRecord = statusCollection[i];

                if (statusRecord.ID == statusID)
                {
                    lblProgressVal.Text = $"{statusRecord.ProgressCount.ToString()}{lblProgressVal.Text}";
                    lblStatusVal.Text = statusRecord.StatusName;
                }
            }
        }


        private void ShowToolTips()
        {
            toolTip1.SetToolTip(picQuestion1, "All progress must be completed to enable this aircraft for reservation use.");
        }
    }
}
