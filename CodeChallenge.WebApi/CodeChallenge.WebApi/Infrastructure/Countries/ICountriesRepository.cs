using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.Countries;

public interface ICountriesRepository
{
    IEnumerable<Country> GetAll();
}