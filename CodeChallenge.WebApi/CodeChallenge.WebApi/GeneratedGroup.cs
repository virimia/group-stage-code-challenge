﻿using CodeChallenge.WebApi.Models;
using System.Diagnostics;

namespace CodeChallenge.WebApi;

public class GeneratedGroup
{
    public char Name { get; }
    public List<Team> Teams { get; }
    public List<CountryEnum> CountryCodes { get; }

    public GeneratedGroup(char name)
    {
        Name = name;
        Teams = new List<Team>();
        CountryCodes = new List<CountryEnum>();
    }

    public bool TryToAddTeam(Team team, int numberOfTeamsAllowed)
    {
        if (Teams.Count >= numberOfTeamsAllowed)
        {
            return false;
        }

        if (Teams.Contains(team))
        {
            return false;
        }

        if (Teams.Select(x => x.CountryCode).Contains(team.CountryCode))
        {
            return false;
        }

        Debug.WriteLine("Adding in Group: {0} , Team: {1}", Name, team.Name);
        //Console.WriteLine("Adding in Group: {0} , Team: {1}", Name, team.Name);

        Teams.Add(team);
        CountryCodes.Add(team.CountryCode);

        return true;
    }
}
