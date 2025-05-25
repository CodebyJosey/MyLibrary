// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Models;

public class Competitor
{
    public string Name { get; set; } = string.Empty;

    public Competitor(string name)
    {
        Name = name;
    }
}