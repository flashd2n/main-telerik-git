using System.Linq;
using GoshoSoft.ForumSystem.Models;

namespace GoshoSoft.ForumSystem.Services
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();
    }
}