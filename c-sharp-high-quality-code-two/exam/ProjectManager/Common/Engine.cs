using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Interfaces;
using System;

namespace ProjectManager
{
    public class Engine : IEngine
    {
        private const string TerminateCommand = "exit";
        private const string ProgramTerminatedMessage = "Program terminated.";
        private const string VeryDescriptiveError = "Opps, something happened. :(";
        private IFileLogger logger;
        private ICommandProcessor processor;
        private IReader reader;
        private IWriter writer;

        public Engine(IFileLogger logger, ICommandProcessor processor, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();

            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            
            this.logger = logger;
            this.processor = processor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            var userInput = this.reader.ReadLine();

            while (userInput.ToLower() != TerminateCommand)
            {
                try
                {
                    var executionResult = this.processor.ProcessCommand(userInput);

                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(VeryDescriptiveError);

                    this.logger.LogError(ex.Message);
                }

                userInput = this.reader.ReadLine();
            }

            this.writer.WriteLine(ProgramTerminatedMessage);
        }
    }
}
