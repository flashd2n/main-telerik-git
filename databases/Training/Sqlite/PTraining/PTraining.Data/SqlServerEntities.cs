using PTraining.Models.sql;
using System.Data.Entity;

namespace PTraining.Data
{
    public class SqlServerEntities : DbContext
    {
        public SqlServerEntities() : base("sqlServerDb")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
