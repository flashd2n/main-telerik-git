using SchoolManagementSystem.Core;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem
{
    internal class BusinessLogicService
    {
        public void Execute(IReader reader, IPrinter printer)
        {
            var engine = new Engine(reader, printer);
            engine.Start();
        }
    }
}
