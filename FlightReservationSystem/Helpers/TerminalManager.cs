using FlightReservationSystem.Data.Reference.Terminal;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class TerminalManager
    {
        public static void AddTerminal(TerminalRecord terminalRecord)
        {
            if (!TerminalRecord.ID_Try(terminalRecord.ID) || !TerminalRecord.Number_Try(terminalRecord.Number) ||
                !TerminalRecord.Classification_Try(terminalRecord.Classification) || !TerminalRecord.Gates_Try(terminalRecord.Gates) || 
                !TerminalRecord.AirportID_Try(terminalRecord.AirportID) || !TerminalRecord.Status_Try(terminalRecord.Status))
            {
                DebugLogger.LogWithStackTrace("Wrong value. Adding aborted.");
                return;
            }

            TerminalCollection.Add(terminalRecord);
        }

        public static List<TerminalRecord> GetTerminalCollection => TerminalCollection.Get;
    }
}
