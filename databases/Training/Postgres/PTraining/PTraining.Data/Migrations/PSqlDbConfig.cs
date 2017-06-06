namespace PTraining.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class PSqlDbConfig : DbMigrationsConfiguration<BloggingEntities>
    {
        public PSqlDbConfig()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BloggingEntities context)
        {
        }
    }
}
