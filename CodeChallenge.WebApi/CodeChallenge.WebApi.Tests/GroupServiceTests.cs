using AutoFixture.Xunit2;
using SharpTestsEx;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Tests;

public class GroupServiceTests
{
    private readonly IGroupService _sut;
    private const string _drawMaster = "drawMaster";

    public GroupServiceTests()
    {
        _sut = new GroupService();
    }

    [Theory]
    [AutoData]
    public void When_Generate_And_NumberOfGroupsIsNot4Or8_ThrowException(int numberOfGroups)
    {
        // Act / Assert
        Assert.Throws<ValidationException>(() => _sut.Generate(numberOfGroups, _drawMaster));
    }

    [Theory]
    [InlineData(4)]
    [InlineData(8)]
    public void When_Generate_For_ValidNumberOfGroups_GetValidGroups(int numberOfGroups)
    {
        // Act
        var result = _sut.Generate(numberOfGroups, _drawMaster);

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