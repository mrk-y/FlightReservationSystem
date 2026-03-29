using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Crew
{
    internal class CrewCollection
    {
        private static readonly List<CrewRecord> _crewRecordList = new List<CrewRecord>();


        public static void Add(CrewRecord crewRecord) => _crewRecordList.Add(crewRecord);

        public static List<CrewRecord> Get => _crewRecordList;

        public static void Clear() => _crewRecordList.Clear();
    }
}
