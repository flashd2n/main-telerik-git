using ProjectManager.Interfaces;
using System;

namespace ProjectManager.Common
{
    public class ConsoleWriterProvider : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
