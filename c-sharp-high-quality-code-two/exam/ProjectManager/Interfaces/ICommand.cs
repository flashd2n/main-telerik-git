using System.Collections.Generic;

namespace ProjectManager.Commands
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
