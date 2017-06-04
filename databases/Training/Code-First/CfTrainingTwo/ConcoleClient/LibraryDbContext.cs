using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleClient
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryConnection")
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnGenreCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnGenreCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                   .HasKey<int>(genre => genre.Id);

            modelBuilder.Entity<Genre>()
                    .Property(genre => genre.Name)
                    .HasMaxLength(40);

            modelBuilder.Entity<Genre>()
                    .Property(genre => genre.Name)
                    .IsRequired();

            modelBuilder.Entity<Genre>()
                    .Property(genre => genre.Name)
                    .HasColumnAnnotation("Unique Key", new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));
        }
    }
}
