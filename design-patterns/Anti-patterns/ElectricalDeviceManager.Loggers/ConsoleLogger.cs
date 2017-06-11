using ElectricalDeviceManager.Interfaces;
using System;

namespace ElectricalDeviceManager.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
