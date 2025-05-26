// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using System.Text.Json;
using CodeByJosey.MyLibrary.Data.Managers;
using CodeByJosey.MyLibrary.Data.Models;
using CodeByJosey.MyLibrary.Examples;
using CodeByJosey.MyLibrary.Utilities;
using CodeByJosey.MyLibrary.Validators;

namespace CodeByJosey.MyLibrary;

public class Program
{
    public static DatabaseManager<User> userManager = new DatabaseManager<User>();
    static void Main()
    {
        MatchProgram();
    }

    static void CreateAccountMenu()
    {
        Console.WriteLine("Enter your username:");
        string? username = Console.ReadLine();

        Console.WriteLine("Confirm your username:");
        string? usernameConfirm = Console.ReadLine();

        if (!username!.Equals(usernameConfirm)) return;

        Console.WriteLine("Enter your email:");
        string? email = Console.ReadLine();

        Console.WriteLine("Confirm your email:");
        string? emailConfirm = Console.ReadLine();

        if (!email!.Equals(emailConfirm)) return;

        EmailValidator emailValidator = new EmailValidator();
        if (!emailValidator.IsValid(email!)) return;

        Console.WriteLine("Enter your address:");
        string? address = Console.ReadLine();

        Console.WriteLine("Enter your password:");
        string? password = EncryptionUtility.HidePassword();

        Console.WriteLine("Confirm your password:");
        string? password2 = EncryptionUtility.HidePassword();

        if (password != password2) return;

        (string hash, byte[] salt) = EncryptionUtility.CreatePasswordHash(password);

        User user = new User() { Username = username, Email = email, Address = address!, Password = hash, PasswordSalt = salt };
        userManager.Insert(user);
    }

    public static void Login()
    {
        Console.WriteLine("Enter your username:");
        string? username = Console.ReadLine();

        Console.WriteLine("Enter your password:");
        string? password = EncryptionUtility.HidePassword();
        User? user = userManager.GetById(1);

        bool isValid = EncryptionUtility.VerifyPassword(password, user!.Password, user.PasswordSalt);
        Console.WriteLine(isValid ? "Password correct!" : "Password incorrect!");
    }

    public static void PopulateUsers()
    {
        int count = 0;
        string jsonPath = "Data/Imports/Users.json";
        string jsonString = File.ReadAllText(jsonPath);
        List<User>? users = JsonSerializer.Deserialize<List<User>>(jsonString);

        foreach (User user in users!)
        {
            count++;
            (string hash, byte[] salt) = EncryptionUtility.CreatePasswordHash(user.Password!);
            User myUser = new User() { Username = user.Username, Email = user.Email, Address = user.Address, Password = hash, PasswordSalt = salt };
            userManager.Insert(myUser);
        }

        Console.WriteLine($"Finished importing {count} users!");
    }

    public static void MatchProgram()
    {
        Eredivisie.Start();
    }
}


public class Composers
{
    public static Func<A, C> Compose<A, B, C>(Func<A, B> func1, Func<B, C> func2) => p => func2(func1(p));
    public static Func<int, int> ComposeN(Func<int, int> f, int n) => n == 0 ? p => p : p => ComposeN(f, n - 1)(f(p));
}