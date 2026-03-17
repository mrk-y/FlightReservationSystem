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
                DebugLogger.Log("[Dev] Parameter List<ErrorRecord> (errorRecordList) is empty. Listing aborted.");
                return "";
            }
        
            string prefix = $"{errorRecordList.Count} errors were found.\n\nPlease fix the following to proceed:\n";
            StringBuilder listMessage = new StringBuilder();

            for (int i = 0; i < errorRecordList.Count; i++)
            {
                var errorRecord = errorRecordList[i];

                if (errorRecord == null)
                {
                    DebugLogger.Log($"[Dev] Encountered null ErrorRecord entry at index {i} of parameter List<ErrorRecord> (errorRecordList). Listing aborted.");
                    return "";
                }

                string message = errorRecord.Message;

                if (string.IsNullOrWhiteSpace(message))
                {
                    DebugLogger.Log($"[Dev] Message is null or whitespace from ErrorRecord entry at index {i} of parameter List<ErrorRecord> (errorRecordList). Listing aborted");
                    return "";
                }
                
                listMessage.AppendLine($"- {message}");
            }

            if (string.IsNullOrWhiteSpace(listMessage.ToString()))
            {
                DebugLogger.Log("[Dev] listMessage is null or whitespace. Listing aborted.");
                return "";
            }

            return prefix + listMessage;
        }
    }
}
