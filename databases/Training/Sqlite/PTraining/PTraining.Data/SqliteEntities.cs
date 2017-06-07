using PTraining.Data.SqliteMigrations;
using PTraining.Models.sqlite;
using System.Data.Entity;

namespace PTraining.Data
{
    public class SqliteEntities : DbContext
    {
        public SqliteEntities() : base("SqliteDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqliteEntities, Sqliteconfig>(true));
        }

        public DbSet<Log> Logs { get; set; }

    }
}
