// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Data.Repositories;

namespace CodeByJosey.MyLibrary.Data.Models;

public class Address : IUniqueEntity
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    [Unique]
    public string FullAddress => $"{Street}, {PostalCode}, {City}";

    public string GetUniqueKey() => FullAddress;
    public override string ToString() => FullAddress;
}
