using ACFTraining.Data;
using ACFTraining.Data.Migrations;
using CFTraining.Models;
using System.Data.Entity;
using System.Linq;

namespace CFTraining.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFTrainingDbContext, Configuration>());
            var db = new CFTrainingDbContext();

            var artist = new Artist
            {
                Name = "Some random artist",
                Gender = GenderType.Female
            };

            db.Artists.Add(artist);

            db.SaveChanges();

        }
    }
}
