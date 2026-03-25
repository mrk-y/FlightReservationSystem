using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Seat
{
    internal class SeatUICollection
    {
        private static readonly List<SeatUIRecord> _seatUIRecordList = new List<SeatUIRecord>
        {
            new SeatUIRecord
            {
                ID = 1,
                BackColor = Color.FromKnownColor(KnownColor.LightGray),
                BorderColor = Color.FromKnownColor(KnownColor.LightGray)
            },
            new SeatUIRecord
            {
                ID = 2,
                BackColor = Color.FromKnownColor(KnownColor.DarkRed),
                BorderColor = Color.FromKnownColor(KnownColor.DarkRed)
            },
            new SeatUIRecord
            {
                ID = 3,
                BackColor = Color.FromKnownColor(KnownColor.GreenYellow),
                BorderColor = Color.FromKnownColor(KnownColor.GreenYellow)
            },
            new SeatUIRecord
            {
                ID = 4,
                BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue),
                BorderColor = Color.FromKnownColor(KnownColor.DeepSkyBlue)
            },
            new SeatUIRecord
            {
                ID = 5,
                BackColor = Color.Empty,
                BorderColor = Color.FromKnownColor(KnownColor.DarkOrange)
            }
        };


        public static List<SeatUIRecord> Get => _seatUIRecordList;
    }
}
