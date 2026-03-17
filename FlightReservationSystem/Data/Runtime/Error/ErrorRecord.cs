using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorRecord
    {
        public string Message { get; set; }
        public List<Control> AssociatedControls { get; set; } = new List<Control>();
    }
}
