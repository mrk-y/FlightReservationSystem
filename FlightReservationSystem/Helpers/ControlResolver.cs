using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class ControlResolver
    {
        public interface IAcceptButton
        {
            Button AcceptButton { get; }
        }
    }
}
