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
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
    public IActionResult Generate([FromBody] GroupStageFormModel model)
    {
        if (model.NumberOfGroups != 4 && model.NumberOfGroups != 8)
        {
            return BadRequest("Number of groups can be only 4 or 8");
        }

        if (string.IsNullOrWhiteSpace(model.DrawMaster))
        {
            return BadRequest("DrawMaster must have a name");
        }

        var result = _groupService.Generate(model.NumberOfGroups, model.DrawMaster);

        return Ok(result);
    }
}
