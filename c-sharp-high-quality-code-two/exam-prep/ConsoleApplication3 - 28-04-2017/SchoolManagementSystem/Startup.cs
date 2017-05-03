using SchoolManagementSystem.Core;

namespace SchoolManagementSystem
{
    public class Startup
    {
        public static void Main()
        {
            var padhana = new ConsoleReaderProvider();
            var printer = new ConsolePrinter();

            var service = new BusinessLogicService();
            service.Execute(padhana, printer);
        }
    }
}
