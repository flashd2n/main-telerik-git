using RPTraining.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace RPTraining.Data.Interfaces
{
    public interface IDbContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
