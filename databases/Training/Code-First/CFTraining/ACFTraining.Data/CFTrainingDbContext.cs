using ACFTraining.Data.Migrations;
using CFTraining.Models;
using System.Data.Entity;

namespace ACFTraining.Data
{
    public class CFTrainingDbContext : DbContext
    {
        public CFTrainingDbContext() :base("ArtistsDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFTrainingDbContext, Configuration>());
        }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .Property(i => i.FileExtension)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
