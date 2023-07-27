using System.Diagnostics;

namespace CodeChallenge.WebApi.Data;

public static class DatabasePreparation
{
    public static void PrePopulate(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext? appDbContext)
    {
        ArgumentNullException.ThrowIfNull(appDbContext);

        if (!appDbContext.Countries.Any())
        {
            appDbContext.Countries.AddRange(StaticSeedData.SeedCountries);

            appDbContext.SaveChanges();

            Debug.WriteLine("Seeding Countries data...");
        }

        if (!appDbContext.Teams.Any())
        {
            appDbContext.Teams.AddRange(StaticSeedData.SeedTeams);

            appDbContext.SaveChanges();

            Debug.WriteLine("Seeding Teams data...");
        }
    }
}
