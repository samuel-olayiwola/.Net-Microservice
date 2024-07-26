using PlatformService.Models;

namespace PlatformService.Data.Seeder
{
    public static class SeedData
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                Seed(scope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void Seed(AppDBContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("*********** seeding data ************");
                context.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Cloud Computing", Cost = "Free" },
                    new Platform() { Name = "MYSQL", Publisher = "Oracle", Cost = "Free" }

                    );
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("*********** Data already exist ************");
            }
        }
    }
}
