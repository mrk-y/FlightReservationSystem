using FlightReservationSystem.UserControls.AircraftModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem.Data.Reference.AircraftModel
{
    internal class AircraftModelUICollection
    {
        private static readonly List<AircraftModelUIRecord> _aircraftModelUIList = new List<AircraftModelUIRecord>
        {
            new AircraftModelUIRecord
            {
                ID = 1,
                UI = new Airbus_A321_200()
            },
            new AircraftModelUIRecord
            {
                ID = 2,
                UI = new Airbus_A321neo()
            },
            new AircraftModelUIRecord
            {
                ID = 3,
                UI = new Airbus_A320_200()
            },
            new AircraftModelUIRecord
            {
                ID = 4,
                UI = new Airbus_A320neo()
            },
            new AircraftModelUIRecord
            {
                ID = 5,
                UI = new Airbus_A319_100()
            },
            new AircraftModelUIRecord
            {
                ID = 10,
                UI = new ATR_72_600()
            }
        };


        public static List<AircraftModelUIRecord> Get => _aircraftModelUIList; 
    }
}
