using System;

namespace SimpleMethodTracer.Logging
{
    class ConsoleLogger: ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine($"{message}");
        }

        public void Error(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }
    }
}
