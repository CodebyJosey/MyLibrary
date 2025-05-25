// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Data.Repositories;

namespace CodeByJosey.MyLibrary.Data.Models;

public class Product : IUniqueEntity
{
    [Unique]
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Calories { get; set; }
    public double Carbs { get; set; }
    public double Proteins { get; set; }
    public double Fats { get; set; }

    public string GetUniqueKey() => Name;
}