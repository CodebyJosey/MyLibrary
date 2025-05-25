// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using System.Security.Cryptography;

namespace CodeByJosey.MyLibrary.Utilities;

public class EncryptionUtility
{
    public static byte[] GenerateSalt(int length = 16) => RandomNumberGenerator.GetBytes(length);
    public static string HashPassword(string password, byte[] salt, int iterations = 100_000)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);
        return Convert.ToBase64String(hash);
    }

    public static (string Hash, byte[] Salt) CreatePasswordHash(string password)
    {
        byte[] salt = GenerateSalt();
        string hash = HashPassword(password, salt);
        return (hash, salt);
    }

    public static bool VerifyPassword(string passwordInput, string storedHash, byte[] storedSalt)
    {
        var computedHash = HashPassword(passwordInput, storedSalt);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(computedHash),
            Convert.FromBase64String(storedHash)
        );
    }

    public static string HidePassword()
    {
        string password = string.Empty;
        ConsoleKeyInfo keyInfo;
        while (true)
        {
            keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b\b");
                }
            }
            else
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }
        }

        return password;
    }
}