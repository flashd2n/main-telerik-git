namespace PTraining.Data.SqlMigrations
{
    using System.Data.Entity.Migrations;

    internal sealed class SqlDbConfig : DbMigrationsConfiguration<SqlServerEntities>
    {
        public SqlDbConfig()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = @"SqlMigrations";
        }

        protected override void Seed(SqlServerEntities context)
        {
        }
    }
}
