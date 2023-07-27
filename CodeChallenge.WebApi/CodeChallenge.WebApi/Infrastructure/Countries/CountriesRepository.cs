using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.Countries;

public class CountriesRepository : ICountriesRepository
{
    private readonly AppDbContext _context;

    public CountriesRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Country> GetAll()
    {
        return _context.Countries;
    }
}
