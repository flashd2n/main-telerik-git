using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core
{
    public class Logger
    {
        public void LogMessage(string message)
        {
            var outputMessage = message + "\n";

            Console.Write(outputMessage);
        }
    }
}
