using CodeChallenge.WebApi.Controllers.FormModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupStageController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupStageController(IGroupService groupsGeneratorService)
    {
        _groupService = groupsGeneratorService;
    }

    [HttpPost("Generate")]
    [ProducesResponseType(typeof(IEnumerable<GeneratedGroupsResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Generate([FromBody] GroupStageFormModel model)
    {
        if (model.NumberOfGroups != 4 && model.NumberOfGroups != 8)
        {
            return BadRequest("Number of groups can be only 4 or 8");
        }

        if (string.IsNullOrWhiteSpace(model.DrawMaster))
        {
            return BadRequest("DrawMaster must have a name");
        }

        var groups = await _groupService.Generate(model.NumberOfGroups, model.DrawMaster);
        var mappedResult = groups.Select(group => new GeneratedGroupResult(
            group.Name,
            group.Teams.Select(team => new GeneratedGroupTeam(team.Name))));

        return Ok(new GeneratedGroupsResult(mappedResult));
    }
}
