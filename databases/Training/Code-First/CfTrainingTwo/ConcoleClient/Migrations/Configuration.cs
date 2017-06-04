namespace ConcoleClient.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(LibraryDbContext context)
        {
            context.Genres.AddOrUpdate(g => g.Name,
                new Genre
                {
                    Name = "Init Genre One"
                });            
        }
    }
}
