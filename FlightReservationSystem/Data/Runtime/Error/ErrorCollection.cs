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
                DebugLogger.Log("[Dev] Parameter ErrorRecord (errorRecord) is null. Adding aborted.");
                return;
            }

            if (string.IsNullOrWhiteSpace(errorRecord.Message))
            {
                DebugLogger.Log("[Dev] Message is null or whitespace from parameter ErrorRecord (errorRecord). Adding aborted.");
                return;
            }

            var associatedControls = errorRecord.AssociatedControls;

            if (associatedControls == null)
            {
                DebugLogger.Log("[Dev] AssociatedControls is null from parameter ErrorRecord (errorRecord). Adding aborted.");
                return;
            }

            if (associatedControls.Count == 0)
            {
                DebugLogger.Log("[Dev] AssociatedControls is empty from parameter ErrorRecord (errorRecord). Adding aborted.");
                return;
            }

            for (int i = 0; i < associatedControls.Count; i++)
            {
                if (associatedControls[i] == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null Control (0) entry at index {i} of AssociatedControls from parameter ErrorRecord (errorRecord). Adding aborted.");
                    return;
                }
            }

            _errorRecordList.Add(errorRecord);
        }

        public static List<ErrorRecord> Get => _errorRecordList;

        public static void Clear() => _errorRecordList.Clear();
    }
}
