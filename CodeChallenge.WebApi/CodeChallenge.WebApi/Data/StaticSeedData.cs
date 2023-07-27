using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Data;

public static class StaticSeedData
{
    public static List<Country> SeedCountries = new()
    {
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Germany, Name = "Germany" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Turkey, Name = "Turkey" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.France, Name = "France" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Netherlands, Name = "Netherlands" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Portugal, Name = "Portugal" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Italy, Name = "Italy" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Spain, Name = "Spain" },
        new Country { Id = Guid.NewGuid(), CountryId = CountryEnum.Belgium, Name = "Belgium" }
    };

    public static List<Team> SeedTeams = new()
    {
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Germany, Name = "Adesso Berlin" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Germany, Name = "Adesso Frankfurt" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Germany, Name = "Adesso Münich" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Germany, Name = "Adesso Dortmund" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Turkey, Name = "Adesso İstanbul" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Turkey, Name = "Adesso Ankara" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Turkey, Name = "Adesso İzmir" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Turkey, Name = "Adesso Antalya" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.France, Name = "Adesso Paris" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.France, Name = "Adesso Marsilya" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.France, Name = "Adesso Nice" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.France, Name = "Adesso Lyon" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Netherlands, Name = "Adesso Amsterdam" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Netherlands, Name = "Adesso Rotterdam" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Netherlands, Name = "Adesso Lahey" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Netherlands, Name = "Adesso Eindhoven" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Portugal, Name = "Adesso Lisbon" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Portugal, Name = "Adesso Porto" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Portugal, Name = "Adesso Braga" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Portugal, Name = "Adesso Coimbra" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Italy, Name = "Adesso Roma" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Italy, Name = "Adesso Milano" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Italy, Name = "Adesso Venedik" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Italy, Name = "Adesso Napoli" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Spain, Name = "Adesso Sevilla" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Spain, Name = "Adesso Madrid" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Spain, Name = "Adesso Barselona" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Spain, Name = "Adesso Granada" },

        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Belgium, Name = "Adesso Brüksel" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Belgium, Name = "Adesso Brugge" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Belgium, Name = "Adesso Gent" },
        new Team { Id = Guid.NewGuid(), CountryCode = CountryEnum.Belgium, Name = "Adesso Anvers" }
    };
}
