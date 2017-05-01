using StaticClassDependencyInversion.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassDependencyInversion.loggers
{
    public class ConsoleLogger : ILogger
    {

        public void WriteStuff(string text)
        {
            Console.WriteLine(text);
        }

    }
}
