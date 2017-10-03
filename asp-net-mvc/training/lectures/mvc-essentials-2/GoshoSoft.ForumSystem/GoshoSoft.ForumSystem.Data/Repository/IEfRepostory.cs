using GoshoSoft.ForumSystem.Models.Interfaces;
using System.Linq;

namespace GoshoSoft.ForumSystem.Data.Repository
{
    public interface IEfRepostory<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}