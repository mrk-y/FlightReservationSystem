using FlightReservationSystem.Debugging;
using FlightReservationSystem.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorCollection
    {
        private static readonly List<ErrorRecord> _errorRecordList = new List<ErrorRecord>();


        public static void Add(ErrorRecord errorRecord) => _errorRecordList.Add(errorRecord);

        public static List<ErrorRecord> Get => _errorRecordList;

        public static void Clear() => _errorRecordList.Clear();
    }
}
