using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.Groups;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddGroups(List<Group> groups)
    {
        await _context.AddRangeAsync(groups);
    }
}
