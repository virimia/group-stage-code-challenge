namespace CodeChallenge.WebApi.Infrastructure.Services;

public interface IGroupDrawService
{
    Task<Guid> SaveGroupDraw(List<GeneratedGroup> groups, string drawMaster);
}