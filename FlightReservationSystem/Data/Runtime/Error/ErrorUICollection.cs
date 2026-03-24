using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorUICollection
    {
        private static readonly List<ErrorUIRecord> _errorUIRecordList = new List<ErrorUIRecord>();


        public static void Add(ErrorUIRecord errorUIRecord) =>_errorUIRecordList.Add(errorUIRecord);

        public static List<ErrorUIRecord> Get => _errorUIRecordList;

        public static void Clear() => _errorUIRecordList.Clear();
    }
}
