// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Models;

public class Competition
{
    public readonly string? Name;
    public List<Club> Clubs { get; set; }
    public List<Match> Matches { get; set; }

    public Competition(string name, List<Club> clubs)
    {
        Name = name;
        Clubs = clubs;
        Matches = new List<Match>();
    }

    public void ScheduleMatches()
    {
        Matches.Clear();
        var rnd = new Random();
        foreach (var home in Clubs)
        {
            foreach (var away in Clubs.Where(c => c != home))
            {
                Matches.Add(new Match(home, away, DateTime.Today.AddDays(rnd.Next(1, 100))));
            }
        }
    }
}