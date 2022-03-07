using System;

namespace UnluCo.FinalProject.WebApi.Common.Loggers
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"[ConsolleLogger]: {message}");
        }
    }
}
