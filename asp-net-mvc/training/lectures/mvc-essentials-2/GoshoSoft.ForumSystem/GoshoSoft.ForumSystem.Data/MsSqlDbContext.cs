using GoshoSoft.ForumSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using GoshoSoft.ForumSystem.Models.Interfaces;

namespace GoshoSoft.ForumSystem.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Post> Posts { get; set; }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfo();
            return base.SaveChanges();
        }

        private void ApplyAuditInfo()
        {
            Func<DbEntityEntry, bool> filterEntityRule = x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in this.ChangeTracker.Entries().Where(filterEntityRule))
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
