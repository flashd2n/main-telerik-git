using StaticClassDependencyInversion.interfaces;
using System.IO;

namespace StaticClassDependencyInversion.loggers
{
    public class FileLogger : ILogger
    {
        public void WriteStuff(string text)
        {
            File.WriteAllText("path to file", text);
        }
    }
}
