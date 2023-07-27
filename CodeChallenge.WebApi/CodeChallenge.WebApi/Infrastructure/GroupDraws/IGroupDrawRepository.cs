using CodeChallenge.WebApi.Data.Models;

namespace CodeChallenge.WebApi.Infrastructure.GroupDraws;

public interface IGroupDrawRepository
{
    //bool SaveChanges();
    Task Add(GroupDraw groupDraw);
}