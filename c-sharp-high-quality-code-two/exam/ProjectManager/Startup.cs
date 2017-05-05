using ProjectManager.Commands;
using ProjectManager.Common;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var modelsFactory = new ModelsFactory();
            var database = new Database();

            var commandsFactory = new CommandsFactory(database, modelsFactory);

            var commandProcessor = new CommandProcessor(commandsFactory);

            var fileLogger = new FileLogger();

            var engineReader = new ConsoleReaderProvider();

            var engineWriter = new ConsoleWriterProvider();

            var engine = new Engine(fileLogger, commandProcessor, engineReader, engineWriter);

            var provider = new EngineProvider(engine);

            provider.StartEngine();
        }
    }
}
