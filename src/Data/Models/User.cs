// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Data.Repositories;

namespace CodeByJosey.MyLibrary.Data.Models;

public class User : IUniqueEntity
{
    [Unique]
    public string Username { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public byte[]? PasswordSalt { get; set; } = default;
    public string? Address { get; set; } = string.Empty;

    public string GetUniqueKey() => Username;
}