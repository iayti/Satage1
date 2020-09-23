namespace Infrastructure.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Identity;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "iayti", Email = "test@test.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Matech_1850");
            }
        }

        public static async Task SeedSampleCityDataAsync(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                List<City> list = new List<City>();

                for (int i = 1; i < 201; i++)
                {
                    list.Add(new City { Name = "City_" + i });
                }

                context.Cities.AddRange(list);

                await context.SaveChangesAsync();
            }
        }
    }
}
