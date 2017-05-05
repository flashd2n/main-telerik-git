using ProjectManager.Interfaces;
using System;

namespace ProjectManager.Common
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
