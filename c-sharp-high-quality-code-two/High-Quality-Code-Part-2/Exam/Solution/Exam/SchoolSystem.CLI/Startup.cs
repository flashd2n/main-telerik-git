﻿using SchoolSystem.Cli.Core;
using SchoolSystem.Cli.Core.Providers;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();
            var parser = new CommandParserProvider();

            var engine = new Engine(reader, writer, parser);
            engine.Start();
        }
    }
}