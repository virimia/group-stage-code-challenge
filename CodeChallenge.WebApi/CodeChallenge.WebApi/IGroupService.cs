namespace CodeChallenge.WebApi;

public interface IGroupService
{
    List<GeneratedGroup> Generate(int numberOfGroups, string drawMaster);
}