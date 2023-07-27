namespace CodeChallenge.WebApi;

public interface IGroupService
{
    Task<List<GeneratedGroup>> Generate(int numberOfGroups, string drawMaster);
}