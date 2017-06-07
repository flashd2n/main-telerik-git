using RPTraining.Data.Interfaces;
using RPTraining.Models;
using System.Data.Entity;
using System;

namespace RPTraining.Data
{
    public class MyDbContext : DbContext, IDbContext
    {
        public MyDbContext() :base("MyDbConnection")
        {

        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
