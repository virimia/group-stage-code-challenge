namespace CodeChallenge.WebApi.Controllers.FormModels;

public record GeneratedGroupsResult(IEnumerable<GeneratedGroupResult> Groups, Guid DrawId);
public record GeneratedGroupResult(char GroupName, IEnumerable<GeneratedGroupTeam> Teams);
public record GeneratedGroupTeam(string Name);