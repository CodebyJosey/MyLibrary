// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value) => value == null || value == default || value == "";
    public static bool IsNullOrWhiteSpace(this string value) => value == null || value == default || value.Replace(" ", "") == "";
    public static string ToTitleCase(this string value)
    {
        string rts = "";
        IEnumerable<string> words = value.Split(" ");
        foreach (string word in words)
        {
            rts += char.ToUpper(word[0]) + word[1..] + " ";
        }
        return rts.Trim();
    }

    public static string Reverse(this string value)
    {
        string returning = "";
        for (int i = value.Length - 1; i >= 0; i--)
        {
            returning += value[i];
        }
        return returning;
    }

    public static string Capitalize(this string value) => char.ToUpper(value[0]) + value[1..];
    public static string ToUpper(this string value) => value.ToUpper();
}