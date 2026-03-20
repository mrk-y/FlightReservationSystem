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


        public static void Add(ErrorUIRecord errorUIRecord)
        {
            if (errorUIRecord == null)
            {
                DebugLogger.LogWithStackTrace("errorUIRecord is null. Adding aborted.");
                return;
            }

            if (errorUIRecord.Provider == null)
            {
                DebugLogger.LogWithStackTrace("errorUIRecord.Provider is null. Adding aborted.");
                return;
            }

            if (errorUIRecord.Target == null)
            {
                DebugLogger.LogWithStackTrace("errorUIRecord.Target is null. Adding aborted.");
                return;
            }

            if (errorUIRecord.Field == null)
            {
                DebugLogger.LogWithStackTrace("errorUIRecord.Field is null. Adding aborted.");
                return;
            }

            if (object.Equals(errorUIRecord.DefaultValue, null))
            {
                DebugLogger.LogWithStackTrace("errorUIRecord.DefaultValue is null. Adding aborted.");
                return;
            }

            _errorUIRecordList.Add(errorUIRecord);
        }

        public static List<ErrorUIRecord> Get => _errorUIRecordList;

        public static void Clear() => _errorUIRecordList.Clear();
    }
}
