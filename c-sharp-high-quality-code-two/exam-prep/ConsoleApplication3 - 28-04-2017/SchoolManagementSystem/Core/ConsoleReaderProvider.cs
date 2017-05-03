using SchoolManagementSystem.Interfaces;
using System;

namespace SchoolManagementSystem
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
