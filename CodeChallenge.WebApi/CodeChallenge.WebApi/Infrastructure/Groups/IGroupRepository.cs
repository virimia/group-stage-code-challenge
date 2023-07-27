using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.Groups;

public interface IGroupRepository
{
    Task AddGroups(List<Group> groups);
}
