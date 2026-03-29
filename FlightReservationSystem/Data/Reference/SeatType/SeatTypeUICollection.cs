using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.SeatType
{
    internal class SeatTypeUICollection
    {
        private static readonly List<SeatTypeUIRecord> _seatUIRecordList = new List<SeatTypeUIRecord>
        {
            new SeatTypeUIRecord
            {
                ID = 1,
                BackColor = Color.FromKnownColor(KnownColor.LightGray),
                BorderColor = Color.FromKnownColor(KnownColor.LightGray)
            },
            new SeatTypeUIRecord
            {
                ID = 2,
                BackColor = Color.FromKnownColor(KnownColor.DarkRed),
                BorderColor = Color.FromKnownColor(KnownColor.DarkRed)
            },
            new SeatTypeUIRecord
            {
                ID = 3,
                BackColor = Color.FromKnownColor(KnownColor.GreenYellow),
                BorderColor = Color.FromKnownColor(KnownColor.GreenYellow)
            },
            new SeatTypeUIRecord
            {
                ID = 4,
                BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue),
                BorderColor = Color.FromKnownColor(KnownColor.DeepSkyBlue)
            },
            new SeatTypeUIRecord
            {
                ID = 5,
                BackColor = Color.Empty,
                BorderColor = Color.FromKnownColor(KnownColor.DarkOrange)
            }
        };


        public static List<SeatTypeUIRecord> Get => _seatUIRecordList;
    }
}
