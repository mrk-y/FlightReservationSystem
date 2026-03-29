using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Status
{
    internal class StatusRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Color> StatusColors { get; set; } = new List<Color>();
    }
}
