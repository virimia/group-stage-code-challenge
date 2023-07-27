using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.GroupDraws;

public interface IGroupDrawRepository
{
    Task Add(GroupDraw groupDraw);
    Task<GroupDraw> Get(Guid id);
}