// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Data.Models;

namespace CodeByJosey.MyLibrary.Data.Managers;

public class SeasonManager
{
    private readonly Competition _competition;
    private readonly Dictionary<Club, Standing> _standings = new();

    public SeasonManager(Competition competition)
    {
        _competition = competition;
        foreach (var club in competition.Clubs)
            _standings[club] = new Standing(club);
    }

    public void SimulateMatches()
    {
        var rnd = new Random();
        foreach (var match in _competition.Matches)
        {
            match.HomeGoals = rnd.Next(0, 5);
            match.AwayGoals = rnd.Next(0, 5);

            _standings[match.Home].ApplyResult(match.HomeGoals.Value, match.AwayGoals.Value);
            _standings[match.Away].ApplyResult(match.AwayGoals.Value, match.HomeGoals.Value);
        }
    }

    public void PrintStandings()
    {
        var ordered = _standings.Values.OrderByDescending(s => s.Points);
        Console.WriteLine("Standings:");
        foreach (var s in ordered)
            Console.WriteLine(s);
    }
}
