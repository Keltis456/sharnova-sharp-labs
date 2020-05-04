using System;
using System.Diagnostics;

namespace LabsDotNet
{
    internal static class Logger
    {
        public static void LogTaskInfo()
        {
            Console.WriteLine(
                $"\n{new StackTrace().GetFrame(1).GetMethod().DeclaringType?.Name}" +
                $".{new StackTrace().GetFrame(1).GetMethod().Name}");
        }
    }
}