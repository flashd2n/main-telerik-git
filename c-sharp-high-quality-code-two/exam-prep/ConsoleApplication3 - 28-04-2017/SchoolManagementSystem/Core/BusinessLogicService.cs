namespace SchoolManagementSystem
{
    internal class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider padhana)
        {
            var injan = new Engine(padhana);
            injan.BrumBrum();
        }
    }
}
