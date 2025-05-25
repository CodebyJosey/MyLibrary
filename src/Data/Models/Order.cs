// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Data.Repositories;

namespace CodeByJosey.MyLibrary.Data.Models;

public class Order : IUniqueEntity
{
    public string Username { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new List<Product>();
    public DateTime OrderDate { get; set; }

    [Unique]
    public string OrderDetails => $"{Username}'s order at {OrderDate}";

    public string GetUniqueKey() => OrderDetails;
}