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
                DebugLogger.Log("[Dev] Parameter ErrorUIRecord (errorUIRecord) is null. Adding aborted.");
                return;
            }

            if (errorUIRecord.Provider == null)
            {
                DebugLogger.Log("[Dev] Provider is null from parameter ErrorUIRecord (errorUIRecord). Addimg aborted.");
                return;
            }

            if (errorUIRecord.Target == null)
            {
                DebugLogger.Log("[Dev] Target is null from parameter ErrorUIRecord (errorUIRecord). Adding aborted.");
                return;
            }

            if (errorUIRecord.Field == null)
            {
                DebugLogger.Log("[Dev] Field is null from parameter ErrorUIRecord (errorUIRecord). Adding aborted.");
                return;
            }

            if (object.Equals(errorUIRecord.DefaultValue, null))
            {
                DebugLogger.Log("[Dev] DefaultValue is null from parameter ErrorUIRecord (errorUIRecord). Adding aborted.");
                return;
            }

            _errorUIRecordList.Add(errorUIRecord);
        }

        public static List<ErrorUIRecord> Get => _errorUIRecordList;

        public static void Clear() => _errorUIRecordList.Clear();
    }
}
