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
        public static string ErrorListMessage(List<ErrorEntry> errorEntry = null)
        {
            // For standard values
            if (errorEntry == null) errorEntry = ErrorCollection.Get;

            int errorCount = errorEntry.Count;

            if (errorCount == 0)
            {
                DebugLogger.Log("[Dev] No errors to format. Returning empty message.");
                return "";
            }
        
            string prefix = $"{errorCount} errors were found.\n\nPlease fix the following to proceed:\n";
            StringBuilder listMessage = new StringBuilder();

            for (int i = 0; i < errorCount; i++)
            {
                var message = errorEntry[i].Message;

                if (message == null)
                {
                    DebugLogger.Log("[Dev] Encountered null ErrorEntry. Formatting aborted.");
                    return "";
                }
                
                listMessage.AppendLine($"- {message}");
            }

            return prefix + listMessage;
        }
    }
}
