using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Data.Models;
using Newtonsoft.Json;

namespace CodeChallenge.WebApi.Infrastructure.Services;

public class GroupDrawService : IGroupDrawService
{
    private readonly AppDbContext _context;

    public GroupDrawService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> SaveGroupDraw(List<GeneratedGroup> groups, string drawMaster)
    {
        var groupDraw = new GroupDraw { DrawMaster = drawMaster };
        _context.Attach(groupDraw);

        foreach (var group in groups)
        {
            _context.Add(new Group
            {
                Name = group.Name,
                GroupDraw = groupDraw,
                Composition = JsonConvert.SerializeObject(group.Teams)
            });
        }

        await _context.SaveChangesAsync();

        return groupDraw.Id;
    }
}
