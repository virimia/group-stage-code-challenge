using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.Teams;

public interface ITeamsRepository
{
    Task<List<Team>> GetAll();
}