using FlightReservationSystem.Data.Reference.Seat;
using FlightReservationSystem.Data.Runtime.Json.SeatAssign;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class SeatManager
    {
        public static void AddSeatType(SeatTypeRecord seatTypeRecord)
        {
            if (!SeatTypeRecord.ID_Try(seatTypeRecord.ID) || !SeatTypeRecord.Code_Try(seatTypeRecord.Code) ||
                !SeatTypeRecord.SeatType_Try(seatTypeRecord.SeatType))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            SeatTypeCollection.Add(seatTypeRecord);
        }

        public static void AddSeatAssign(SeatAssignRecord seatAssignRecord)
        {
            if (!SeatAssignRecord.SeatCode_Try(seatAssignRecord.SeatCode) || !SeatAssignRecord.SeatTypes_Try(seatAssignRecord.SeatTypes)) {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            SeatAssignCollection.Add(seatAssignRecord);
        }

        public static List<SeatTypeRecord> GetSeatTypeCollection => SeatTypeCollection.Get;

        public static List<SeatTypeUIRecord> GetSeatTypeUICollection => SeatTypeUICollection.Get;

        public static List<SeatAssignRecord> GetSeatAssignCollection => SeatAssignCollection.Get;

        public static void ClearSeatAssignCollection() => SeatAssignCollection.Clear();

        public static Bitmap SeatMapToImg(UserControl userControl)
        {
            Bitmap bmp = new Bitmap(userControl.Width, userControl.Height);
            userControl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            return bmp;
        }
    }
}
