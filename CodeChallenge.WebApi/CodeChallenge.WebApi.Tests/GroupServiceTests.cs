using AutoFixture.Xunit2;
using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Infrastructure.Services;
using CodeChallenge.WebApi.Infrastructure.Teams;
using FakeItEasy;
using SharpTestsEx;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Tests;

public class GroupServiceTests
{
    private readonly ITeamsRepository _teamsRepository = A.Fake<ITeamsRepository>();
    private readonly IGroupService _sut;

    private const string _drawMaster = "drawMaster";

    public GroupServiceTests()
    {
        _sut = new GroupService(_teamsRepository);

        A.CallTo(() => _teamsRepository.GetAll()).Returns(StaticSeedData.SeedTeams);
    }

    [Theory]
    [AutoData]
    public async Task When_Generate_And_NumberOfGroupsIsNot4Or8_ThrowException(int numberOfGroups)
    {
        // Act / Assert
        await Assert.ThrowsAsync<ValidationException>(() => _sut.Generate(numberOfGroups, _drawMaster));
    }

    [Theory]
    [InlineData(4)]
    [InlineData(8)]
    public async Task When_Generate_For_ValidNumberOfGroups_GetValidGroups(int numberOfGroups)
    {
        // Act
        var result = await _sut.Generate(numberOfGroups, _drawMaster);

        // Assert
        AreGroupsValid(result, 32 / numberOfGroups).Should().Be(true);
    }

    private static bool AreGroupsValid(
        List<GeneratedGroup> groups,
        int numberOfTeamsAllowedPerGroup)
    {
        foreach (var group in groups)
        {
            if (group.Teams.Select(x => x.CountryCode).Distinct().Count() != numberOfTeamsAllowedPerGroup)
            {
                return false;
            }
        }

        return true;
    }
}