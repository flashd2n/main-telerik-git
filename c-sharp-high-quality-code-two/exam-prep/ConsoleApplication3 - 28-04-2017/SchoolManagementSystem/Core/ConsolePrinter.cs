using SchoolManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}
