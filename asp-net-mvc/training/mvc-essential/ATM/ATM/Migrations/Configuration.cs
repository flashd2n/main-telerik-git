namespace ATM.Migrations
{
    using ATM.Models;
    using ATM.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(x => x.UserName == "admin@test.com"))
            {
                var user = new ApplicationUser { UserName = "admin@test.com", Email = "admin@test.com" };
                userManager.Create(user, "passW0rd!");

                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("Admin", "Pesho", user.Id, 1500m);

                var role = new IdentityRole { Name = "Admin" };

                context.Roles.AddOrUpdate(x => x.Name, role);
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
