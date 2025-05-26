// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Models;

public class Club
{
    public string Name { get; }
    public string City { get; }

    public Club(string name, string city)
    {
        Name = name;
        City = city;
    }

    public override string ToString() => $"{Name} ({City})";
}
