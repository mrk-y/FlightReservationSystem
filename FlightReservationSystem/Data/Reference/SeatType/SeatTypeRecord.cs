using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.SeatType
{
    internal class SeatTypeRecord
    {
        public int ID {  get; set; }
        public string Type { get; set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
    }
}
