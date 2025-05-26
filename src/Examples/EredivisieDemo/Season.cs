// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Data.Managers;
using CodeByJosey.MyLibrary.Data.Models;

namespace CodeByJosey.MyLibrary.Examples;

public class Eredivisie
{
    public static void Start()
    {
        var clubs = new List<Club>
        {
            new("Ajax", "Amsterdam"),
            new("PSV", "Eindhoven"),
            new("Feyenoord", "Rotterdam"),
            new("AZ", "Alkmaar"),
            new("FC Twente", "Enschede")
        };

        var eredivisie = new Competition("Eredivisie", clubs);
        eredivisie.ScheduleMatches();

        var seasonManager = new SeasonManager(eredivisie);
        seasonManager.SimulateMatches();
        seasonManager.PrintStandings();
    }
}
