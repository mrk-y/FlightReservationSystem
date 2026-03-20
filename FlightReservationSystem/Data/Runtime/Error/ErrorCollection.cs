using FlightReservationSystem.Debugging;
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


        public static void Add(ErrorRecord errorRecord)
        {
            if (errorRecord == null)
            {
                DebugLogger.LogWithStackTrace("errorRecord is null. Adding aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(errorRecord.Message))
            {
                DebugLogger.LogWithStackTrace("errorRecord.Message is null or whitespace. Addding aborted.");
                return;
            }

            var associatedControls = errorRecord.AssociatedControls;

            if (associatedControls == null)
            {
                DebugLogger.LogWithStackTrace("associatedControls is null. Adding aborted.");
                return;
            }

            if (associatedControls.Count == 0)
            {
                DebugLogger.LogWithStackTrace("associatedControls is empty. Adding aborted.");
                return;
            }

            for (int i = 0; i < associatedControls.Count; i++)
            {
                if (associatedControls[i] == null)
                {
                    DebugLogger.LogWithStackTrace($"associatedControls[{i}] is null. Adding aborted.");
                    return;
                }
            }

            _errorRecordList.Add(errorRecord);
        }

        public static List<ErrorRecord> Get => _errorRecordList;

        public static void Clear() => _errorRecordList.Clear();
    }
}
