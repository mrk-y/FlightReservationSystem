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
        private static readonly List<ErrorEntry> _errorEntryCollection = new List<ErrorEntry>();


        public static void Add(ErrorEntry entry)
        {
            if (entry != null && !string.IsNullOrEmpty(entry.Message)) _errorEntryCollection.Add(entry);
        }

        public static List<ErrorEntry> Get => _errorEntryCollection;

        public static int Count => _errorEntryCollection.Count;

        public static bool Has => Count != 0 ? true : false;

        public static void Clear() => _errorEntryCollection.Clear();
    }
}
