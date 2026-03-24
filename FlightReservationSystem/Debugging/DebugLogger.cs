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
        //public static void Log(string message, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = default, [CallerMemberName] string memberName = null)
        //{
        //    // Fornat: Why + What didn't happen + What did happen 
        //    Debug.WriteLine($"{filePath} ({lineNumber}) in {memberName}: {message} Returning early.");
        //}

        public static void LogWithStackTrace(string message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            string summary = $"[Dev] {message} (called from {memberName} in {filePath}:line {lineNumber})";
            StackTrace st = new StackTrace(true);

            Debug.WriteLine($"{summary}\n{st}");
        }
    }
}
