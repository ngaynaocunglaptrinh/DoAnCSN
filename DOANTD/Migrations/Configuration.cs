namespace DOANTD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DOANTD.Database;
    using DOANTD.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<DOANTD.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DOANTD.Database.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            this.SeedUsers(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var password = HashManager.HashPassword("Password123");

            if (!context.Users.Any(i => i.Username == "user1@gmail.com"))
            {
                context.Users.Add(new Entities.User
                {
                    Username = "user1@gmail.com",
                    Password = password
                });
            }

            if (!context.Users.Any(i => i.Username == "user2@gmail.com"))
            {
                context.Users.Add(new Entities.User
                {
                    Username = "user2@gmail.com",
                    Password = password
                });
            }

            context.SaveChanges();
        }
    }
}
