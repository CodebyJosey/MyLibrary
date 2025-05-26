// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Models;

public class Standing
{
    public Club Club { get; }
    public int Played { get; private set; }
    public int Wins { get; private set; }
    public int Draws { get; private set; }
    public int Losses { get; private set; }
    public int GoalsFor { get; private set; }
    public int GoalsAgainst { get; private set; }

    public int Points => Wins * 3 + Draws;

    public Standing(Club club) => Club = club;

    public void ApplyResult(int goalsFor, int goalsAgainst)
    {
        Played++;
        GoalsFor += goalsFor;
        GoalsAgainst += goalsAgainst;

        if (goalsFor > goalsAgainst) Wins++;
        else if (goalsFor == goalsAgainst) Draws++;
        else Losses++;
    }

    public override string ToString() =>
        $"{Club.Name} - {Points} pts ({Wins}W {Draws}D {Losses}L)";
}
