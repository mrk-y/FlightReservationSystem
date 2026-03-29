using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.CrewType
{
    internal class CrewTypeCollection
    {
        private static readonly List<CrewTypeRecord> _crewTypeRecordList = new List<CrewTypeRecord>
        {
            new CrewTypeRecord
            {
                ID = 1,
                Name = "Pilot"
            },
            new CrewTypeRecord
            {
                ID = 2,
                Name = "Flight Attendant"
            }
        };


        public static List<CrewTypeRecord> Get => _crewTypeRecordList; 
    }
}
