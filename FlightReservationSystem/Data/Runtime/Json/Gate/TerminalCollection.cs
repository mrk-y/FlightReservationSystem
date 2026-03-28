using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Terminal
{
    internal class TerminalCollection
    {
        private static readonly List<TerminalRecord> _terminalRecordList = new List<TerminalRecord>();


        public static void Add(TerminalRecord terminalRecord) => _terminalRecordList.Add(terminalRecord);

        public static List<TerminalRecord> Get => _terminalRecordList;

        public static void Clear() => _terminalRecordList.Clear();
    }
}
