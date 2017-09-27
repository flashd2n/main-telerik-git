using System.Data.Entity;

namespace ExploreCalifornia.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("ExploreCalifornia")
        {
            
        }

        public DbSet<Tour> Tours { get; set; }
    }
}