using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.GroupDraws;

public class GroupDrawRepository : IGroupDrawRepository
{
    private readonly AppDbContext _context;

    public GroupDrawRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(GroupDraw groupDraw)
    {
        if (groupDraw is null)
        {
            throw new ArgumentNullException(nameof(groupDraw));
        }

        await _context.GroupDraws.AddAsync(groupDraw);

        throw new NotImplementedException();
    }
}
