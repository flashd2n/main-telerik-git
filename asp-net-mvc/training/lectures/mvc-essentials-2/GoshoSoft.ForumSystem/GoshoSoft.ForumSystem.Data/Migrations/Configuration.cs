namespace GoshoSoft.ForumSystem.Data.Migrations
{
    using GoshoSoft.ForumSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        const string AdminUserName = "gosho@gosho.com";
        const string AdminPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedSimpleDate(context);
        }

        private void SeedSimpleDate(MsSqlDbContext context)
        {
            if (!context.Posts.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var post = new Post
                    {
                        Title = "Post " + i,
                        Content = "very many awesome wow content " + i,
                        Author = context.Users.First(x => x.UserName == AdminUserName),
                        CreatedOn = DateTime.Now
                    };

                    context.Posts.Add(post);
                }
            }
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdminUserName, Email = AdminUserName };
                userManager.Create(user, AdminPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
