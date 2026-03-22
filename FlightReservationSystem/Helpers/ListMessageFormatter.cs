using FlightReservationSystem.Data.Runtime.Error;
using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class ListMessageFormatter
    {
        public static string ErrorListMessage(List<ErrorRecord> errorRecordList = null)
        {
            // For default values
            if (errorRecordList == null) errorRecordList = ErrorCollection.Get;

            if (errorRecordList.Count == 0)
            {
                DebugLogger.LogWithStackTrace("errorRecordList is empty. Listing aborted.");
                return "";
            }

            string prefix = $"{errorRecordList.Count} errors were found.\n\nPlease fix the following to proceed:\n";
            StringBuilder listMessage = new StringBuilder();

            for (int i = 0; i < errorRecordList.Count; i++)
            {
                var errorRecord = errorRecordList[i];

                if (errorRecord == null)
                {
                    DebugLogger.LogWithStackTrace($"errorRecord {i} is null. Listing aborted.");
                    return "";
                }

                string message = errorRecord.Message;

                if (string.IsNullOrWhiteSpace(message))
                {
                    DebugLogger.LogWithStackTrace($"message {i} is null or whitespace. Listing aborted.");
                    return "";
                }

                if (ValueChecker.HasSpaceStartEnd(message))
                {
                    DebugLogger.LogWithStackTrace($"message {i} starts or ends with space. Listing aborted.");
                    return "";
                }

                listMessage.AppendLine($"- {message}");
            }

            if (string.IsNullOrWhiteSpace(listMessage.ToString()))
            {
                DebugLogger.LogWithStackTrace("listMessage is null or whitespace. Listing aborted.");
                return "";
            }

            if (ValueChecker.HasSpaceStartEnd(listMessage.ToString()))
            {
                DebugLogger.LogWithStackTrace("listMessage starts or ends with space. Listing aborted.");
                return "";
            }

            return prefix + listMessage;
        }
    }
}
