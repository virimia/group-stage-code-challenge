using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.WebApi.Infrastructure.Teams;

public class TeamsRepository : ITeamsRepository
{
    private readonly AppDbContext _context;

    public TeamsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetAll()
    {
        return await _context.Teams.ToListAsync();
    }
}
