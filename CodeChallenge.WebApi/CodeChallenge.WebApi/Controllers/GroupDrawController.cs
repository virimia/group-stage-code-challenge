using CodeChallenge.WebApi.Controllers.FormModels;
using CodeChallenge.WebApi.Data.Models;
using CodeChallenge.WebApi.Infrastructure.GroupDraws;
using CodeChallenge.WebApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupDrawController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly IGroupDrawService _groupDrawService;
    private readonly IGroupDrawRepository _groupDrawRepository;

    public GroupDrawController(
        IGroupService groupsGeneratorService,
        IGroupDrawService groupDrawService,
        IGroupDrawRepository groupDrawRepository)
    {
        _groupService = groupsGeneratorService;
        _groupDrawService = groupDrawService;
        _groupDrawRepository = groupDrawRepository;
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
        var groupDrawId = await _groupDrawService.SaveGroupDraw(groups, model.DrawMaster);

        var mappedResult = groups.Select(group => new GeneratedGroupResult(
            group.Name,
            group.Teams.Select(team => new GeneratedGroupTeam(team.Name))));

        return Ok(new GeneratedGroupsResult(mappedResult, groupDrawId));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GroupDraw), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
        var groupDraw = await _groupDrawRepository.Get(id);

        if (groupDraw is null)
        {
            return NotFound();
        }

        return Ok(groupDraw);
    }
}
