using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Helpers
{
    internal class ToImageConverter
    {

        public static Bitmap UserControlToImg(UserControl userControl)
        {
            Bitmap bmp = new Bitmap(userControl.Width, userControl.Height);
            userControl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            return bmp;
        }
    }
}
