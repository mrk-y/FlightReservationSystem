using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class ResourceGetter
    {
        public static Image GetAirlineImage(string resourceName)
        {
            object resc = Properties.Resources.ResourceManager.GetObject(resourceName);

            if (resc != null && resc is Image img) return img;
            else
            {
                DebugLogger.LogWithStackTrace("resc is null. Image retrieval aborted.");
                return null;
            }
        }
    }
}
