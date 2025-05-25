// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Models;

public class Competition
{
    public readonly string? Name;
    public readonly List<Competitor> Competitors;

    public Competition(string nameOfCompetition, List<Competitor> competitors)
    {
        Name = nameOfCompetition;
        Competitors = competitors;
    }
}