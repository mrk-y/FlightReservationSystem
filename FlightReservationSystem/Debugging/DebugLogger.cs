using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Debugging
{
    internal class DebugLogger
    {
        public static void Log(string message, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = default, [CallerMemberName] string memberName = null)
        {
            // Fornat: Why + What didn't happen + What did happen 
            Debug.WriteLine($"{filePath} ({lineNumber}) in {memberName}: {message} Returning early.");
        }
    }
}
