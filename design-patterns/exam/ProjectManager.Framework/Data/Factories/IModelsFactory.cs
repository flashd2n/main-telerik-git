using ProjectManager.Framework.Data.Models;

namespace ProjectManager.Framework.Data.Factories
{
    public interface IModelsFactory
    {
        Project GetProject(string name, string startingDate, string endingDate, string state);

        Task GetTask(User owner, string name, string state);

        User GetUser(string username, string email);
    }
}
