// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Models;

public class Match
{
    public Club Home { get; set; }
    public Club Away { get; set; }
    public int? HomeGoals { get; set; }
    public int? AwayGoals { get; set; }
    public DateTime MatchDate { get; set; }

    public Match(Club home, Club away, DateTime date)
    {
        Home = home;
        Away = away;
        MatchDate = date;
    }

    public string GetResults() => HomeGoals.HasValue && AwayGoals.HasValue
                                  ? $"{Home} {HomeGoals} - {AwayGoals} {Away}"
                                  : $"{Home} - {Away} @ {MatchDate}";
}