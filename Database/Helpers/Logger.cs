using System;

namespace Database.Helpers
{
    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}
