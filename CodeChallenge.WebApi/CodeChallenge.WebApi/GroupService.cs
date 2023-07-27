using CodeChallenge.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi;

public class GroupService : IGroupService
{
    readonly List<Team> _teams = new List<Team>(32)
    {
        new(Guid.NewGuid(), CountryEnum.Germany, "Adesso Berlin"),
        new(Guid.NewGuid(), CountryEnum.Germany, "Adesso Frankfurt"),
        new(Guid.NewGuid(), CountryEnum.Germany, "Adesso Münih"),
        new(Guid.NewGuid(), CountryEnum.Germany, "Adesso Dortmund"),

        new(Guid.NewGuid(), CountryEnum.Turkey, "Adesso İstanbul"),
        new(Guid.NewGuid(), CountryEnum.Turkey, "Adesso Ankara"),
        new(Guid.NewGuid(), CountryEnum.Turkey, "Adesso İzmir"),
        new(Guid.NewGuid(), CountryEnum.Turkey, "Adesso Antalya"),

        new(Guid.NewGuid(), CountryEnum.France, "Adesso Paris"),
        new(Guid.NewGuid(), CountryEnum.France, "Adesso Marsilya"),
        new(Guid.NewGuid(), CountryEnum.France, "Adesso Nice"),
        new(Guid.NewGuid(), CountryEnum.France, "Adesso Lyon"),

        new(Guid.NewGuid(), CountryEnum.Netherlands, "Adesso Amsterdam"),
        new(Guid.NewGuid(), CountryEnum.Netherlands, "Adesso Rotterdam"),
        new(Guid.NewGuid(), CountryEnum.Netherlands, "Adesso Lahey"),
        new(Guid.NewGuid(), CountryEnum.Netherlands, "Adesso Eindhoven"),

        new(Guid.NewGuid(), CountryEnum.Portugal, "Adesso Lisbon"),
        new(Guid.NewGuid(), CountryEnum.Portugal, "Adesso Porto"),
        new(Guid.NewGuid(), CountryEnum.Portugal, "Adesso Braga"),
        new(Guid.NewGuid(), CountryEnum.Portugal, "Adesso Coimbra"),

        new(Guid.NewGuid(), CountryEnum.Italy, "Adesso Roma"),
        new(Guid.NewGuid(), CountryEnum.Italy, "Adesso Milano"),
        new(Guid.NewGuid(), CountryEnum.Italy, "Adesso Venedik"),
        new(Guid.NewGuid(), CountryEnum.Italy, "Adesso Napoli"),

        new(Guid.NewGuid(), CountryEnum.Spain, "Adesso Sevilla"),
        new(Guid.NewGuid(), CountryEnum.Spain, "Adesso Madrid"),
        new(Guid.NewGuid(), CountryEnum.Spain, "Adesso Barselona"),
        new(Guid.NewGuid(), CountryEnum.Spain, "Adesso Granada"),

        new(Guid.NewGuid(), CountryEnum.Belgium, "Adesso Brüksel"),
        new(Guid.NewGuid(), CountryEnum.Belgium, "Adesso Brugge"),
        new(Guid.NewGuid(), CountryEnum.Belgium, "Adesso Gent"),
        new(Guid.NewGuid(), CountryEnum.Belgium, "Adesso Anvers")
    };
    readonly char[] _groups = new char[8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

    public List<GeneratedGroup> Generate(int numberOfGroups, string drawMaster)
    {
        if (numberOfGroups != 4 && numberOfGroups != 8)
        {
            throw new ValidationException("Number of groups can be only 4 or 8");
        }

        var result = new List<GeneratedGroup>(numberOfGroups);
        var teamsPerCountry = _teams.ToLookup(k => k.CountryCode, v => v.Name);

        var selectedTeams = new List<KeyValuePair<char, Guid>>();

        // initialize groups
        for (var i = 0; i < numberOfGroups; i++)
        {
            var newGroup = new GeneratedGroup(_groups[i]);

            result.Add(newGroup);
        }

        // each team must be placed in a group
        foreach (var team in _teams)
        {
            foreach (var group in result)
            {
                if (group.TryToAddTeam(team, 32 / numberOfGroups))
                {
                    break;
                }
            }
        }

        return result;
    }
}
