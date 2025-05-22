using System.Runtime.CompilerServices;

namespace MyLibrary.Data.Models;

public class User : IUniqueEntity
{
    [Unique]
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public string GetUniqueKey() => Username;
}