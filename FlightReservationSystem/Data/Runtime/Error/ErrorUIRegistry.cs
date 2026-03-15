using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data.Runtime.Error
{
    internal class ErrorUIRegistry
    {
        private static readonly List<ErrorUI> _errorUICollection = new List<ErrorUI>();


        public static void Add(ErrorUI ui)
        {
            if (ui != null) _errorUICollection.Add(ui);
        }

        public static List<ErrorUI> Get => _errorUICollection;

        public static int Count => _errorUICollection.Count;

        public static bool Has => Count != 0 ? true : false;

        public static void Clear() => _errorUICollection.Clear();
    }
}
