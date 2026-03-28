using FlightReservationSystem.Data.Reference.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class StatusManager
    {
        public static List<StatusRecord> GetStatusCollection => StatusCollection.Get;
    }
}
