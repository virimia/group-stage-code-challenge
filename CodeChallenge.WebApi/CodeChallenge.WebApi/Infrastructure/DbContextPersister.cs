using CodeChallenge.WebApi.Data;

namespace CodeChallenge.WebApi.Infrastructure;

public class DbContextPersister : IDbContextPersister
{
    private readonly AppDbContext _context;

    public DbContextPersister(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}
