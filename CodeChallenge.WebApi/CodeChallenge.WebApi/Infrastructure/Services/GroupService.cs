using CodeChallenge.WebApi.Infrastructure.Teams;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly ITeamsRepository _teamsRepository;

    readonly char[] _groups = new char[8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

    public GroupService(ITeamsRepository teamsRepository)
    {
        _teamsRepository = teamsRepository;
    }

    public async Task<List<GeneratedGroup>> Generate(int numberOfGroups, string drawMaster)
    {
        if (numberOfGroups != 4 && numberOfGroups != 8)
        {
            throw new ValidationException("Number of groups can be only 4 or 8");
        }

        var teams = await _teamsRepository.GetAll();
        var result = new List<GeneratedGroup>(numberOfGroups);

        // initialize groups
        for (var i = 0; i < numberOfGroups; i++)
        {
            var newGroup = new GeneratedGroup(_groups[i]);

            result.Add(newGroup);
        }

        // each team must be placed in a group
        foreach (var team in teams)
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
