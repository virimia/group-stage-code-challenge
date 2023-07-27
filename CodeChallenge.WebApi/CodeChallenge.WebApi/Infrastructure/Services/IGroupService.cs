namespace CodeChallenge.WebApi.Infrastructure.Services;

public interface IGroupService
{
    Task<List<GeneratedGroup>> Generate(int numberOfGroups, string drawMaster);
}