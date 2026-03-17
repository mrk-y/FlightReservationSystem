using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.User
{
    internal class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public int UserTypeID { get; set; }
        public string UserType { get; set; }
    }
}
