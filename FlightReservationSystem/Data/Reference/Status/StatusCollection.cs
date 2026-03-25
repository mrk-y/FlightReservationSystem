using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Reference.Status
{
    internal class StatusCollection
    {
        private static readonly List<StatusRecord> _statusRecordList = new List<StatusRecord>
        {
            new StatusRecord 
            { 
                ID = 1, 
                StatusName = "Scheduled", 
                StatusColors = new List<Color> 
                { 
                    Color.FromArgb(255, 255, 255) 
                } 
            },
            new StatusRecord 
            { 
                ID = 2, 
                StatusName = "Boarding", 
                StatusColors = new List<Color> 
                { 
                    Color.FromArgb(255, 202, 7) 
                } 
            },
            new StatusRecord 
            { 
                ID = 3, 
                StatusName = "In Flight", 
                StatusColors = new List<Color> 
                { 
                    Color.FromArgb(0, 38, 184) 
                }  
            },
            new StatusRecord 
            { 
                ID = 4, 
                StatusName = "Landed", 
                StatusColors = new List < Color > 
                { 
                    Color.FromArgb(52, 167, 49) 
                } 
            },
            new StatusRecord 
            { 
                ID = 5, 
                StatusName = "Delayed", 
                StatusColors = new List < Color > 
                { 
                    Color.FromArgb(255, 113, 27) 
                } 
            },
            new StatusRecord 
            { 
                ID = 6, 
                StatusName = "Cancelled", 
                StatusColors = new List < Color > 
                { 
                    Color.FromArgb(220, 33, 49) 
                } 
            },
            new StatusRecord 
            { 
                ID = 7, 
                StatusName = "Gate closed", 
                StatusColors = new List < Color > 
                { 
                    Color.FromArgb(102, 102, 102) 
                } 
            },
            new StatusRecord 
            { 
                ID = 8, 
                StatusName = "Final Call", 
                StatusColors = new List<Color> 
                { 
                    Color.FromArgb(255, 202, 7), 
                    Color.FromArgb(0, 38, 184) 
                } 
            }
        };

        public static List<StatusRecord> Get => _statusRecordList;
    }
}
