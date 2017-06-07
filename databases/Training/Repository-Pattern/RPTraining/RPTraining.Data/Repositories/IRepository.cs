using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTraining.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();

        TEntity FindById(object id);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();
    }
}
