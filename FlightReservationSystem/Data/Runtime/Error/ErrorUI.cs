using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorUI
    {
        public ErrorProvider Provider { get; set; }
        public Control Target { get; set; }
        public Control Field { get; set; }
    }
}
