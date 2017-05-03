using System.Collections.Generic;

namespace SchoolManagementSystem
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
