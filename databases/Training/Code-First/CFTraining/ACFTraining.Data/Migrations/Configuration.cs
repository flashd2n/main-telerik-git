namespace ACFTraining.Data.Migrations
{
    using CFTraining.Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<CFTrainingDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ACFTraining.Data.CFTrainingDbContext";
        }

        protected override void Seed(CFTrainingDbContext context)
        {
            context.Artists.AddOrUpdate(a => a.Name ,new Artist
            {
                Name = "First Seeded Artist"
            }, new Artist
            {
                Name = "Second Seeded Artist"
            });
        }
    }
}
