using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class DatabaseConnection
    {
        public static SqlConnection Get()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
    }
}
