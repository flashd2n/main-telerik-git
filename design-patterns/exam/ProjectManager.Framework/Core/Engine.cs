using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IProcessor processor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, IProcessor processor, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.processor = processor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                var executionResult = this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
