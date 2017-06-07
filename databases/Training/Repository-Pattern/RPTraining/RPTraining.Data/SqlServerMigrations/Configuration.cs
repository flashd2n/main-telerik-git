namespace RPTraining.Data.SqlServerMigrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RPTraining.Data.MyDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
            this.MigrationsDirectory = @"SqlServerMigrations";
        }

        protected override void Seed(MyDbContext context)
        {
        }
    }
}
