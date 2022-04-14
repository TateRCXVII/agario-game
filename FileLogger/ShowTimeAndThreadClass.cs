using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Copyright: Tate Reynolds and Thatcher Geary, CS3500, March 30 2022
/// </summary>
namespace FileLogger
{
    /// <summary>
    /// Extension class for String to append time and thread
    /// </summary>
    public static class ShowTimeAndThreadClass
    {
        /// <summary>
        /// Appends time, date, and thread ID to an input string
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>the input string with time and date appended</returns>
        public static string ShowTimeAndThread(this string str)
        {
            return $"{DateTime.UtcNow} ({Thread.CurrentThread.ManagedThreadId}) {str}";
        }
    }
}
