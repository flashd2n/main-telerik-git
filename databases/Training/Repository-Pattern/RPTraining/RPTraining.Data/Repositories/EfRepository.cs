using RPTraining.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTraining.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IDbContext data;
        private readonly IDbSet<TEntity> set;

        public EfRepository(IDbContext data)
        {
            this.data = data;
            this.set = data.Set<TEntity>();
        }
        
        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        /// <summary>
        /// Returns the entire set as IQueryable. The result is equivalent to 'db.mySet'.
        /// </summary>
        public IQueryable<TEntity> All()
        {
            return this.set;
        }

        public TEntity FindById(object id)
        {
            return this.set.Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }
        
        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void SaveChanges()
        {
            this.data.SaveChanges();
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var dbEntry = this.data.Entry(entity);
            dbEntry.State = state;
        }
    }
}
