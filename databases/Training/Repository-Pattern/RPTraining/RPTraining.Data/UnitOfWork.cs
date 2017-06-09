using RPTraining.Data.Interfaces;
using RPTraining.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPTraining.Data
{
    public class UnitOfWork
    {
        private IDbContext context;
        //private Dictionary<Type, TRepo> repositories;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
            //this.repositories = new Dictionary<Type, TRepo>();
        }
        
        public TRepo GetRepository<TRepo>()
        {

            //if (repositories.Keys.Contains(typeof(TEntity)) == true)
            //{
            //    return repositories[typeof(TEntity)];
            //}

            TRepo repo = (TRepo)Activator.CreateInstance(typeof(TRepo), this.context);

            //repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
