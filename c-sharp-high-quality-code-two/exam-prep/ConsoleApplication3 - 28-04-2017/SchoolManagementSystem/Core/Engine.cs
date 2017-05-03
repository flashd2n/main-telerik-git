using SchoolManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SchoolManagementSystem
{
    public class Engine
    {
        private static StringBuilder currentMessages;
        private IReader reader;
        private IPrinter printer;
        
        public Engine(IReader reader, IPrinter printer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("The passed reader object is null");
            }

            if (printer == null)
            {
                throw new ArgumentNullException("The passed printer object is null");
            }

            this.reader = reader;
            this.printer = printer;
            currentMessages = new StringBuilder();
        }

        internal static Dictionary<int, Teacher> Teachers { get; set; } = new Dictionary<int, Teacher>();

        internal static Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();

        public void Start()
        {
            var input = this.reader.ReadLine();

            while (input != "End")
            {
                try
                {
                    var commandName = input.Split(' ')[0];

                    var currentAssembly = GetType().GetTypeInfo().Assembly;
                    var targetType = currentAssembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();

                    if (targetType == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var command = Activator.CreateInstance(targetType) as ICommand;

                    var parameters = input.Split(' ').ToList();
                    parameters.RemoveAt(0);

                    this.LogMessage(command.Execute(parameters));

                    input = this.reader.ReadLine();
                }
                catch (Exception ex)
                {
                    this.LogMessage(ex.Message);

                    input = this.reader.ReadLine();
                }
            }

            var outputMessage = currentMessages.ToString().Trim();

            this.printer.PrintOutput(outputMessage);
        }

        private void LogMessage(string message)
        {
            currentMessages.Append(message + "\n");
        }
    }
}
