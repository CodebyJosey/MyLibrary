// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Validators;

public class InputValidator
{
    public T Read<T>(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()!;

            try
            {
                if (typeof(T) == typeof(int) && int.TryParse(input, out int i))
                {
                    return (T)(object)i;
                }

                if (typeof(T) == typeof(decimal) && decimal.TryParse(input, out decimal d))
                {
                    return (T)(object)d;
                }

                if (typeof(T) == typeof(DateTime) && DateTime.TryParse(input, out DateTime dt))
                {
                    return (T)(object)dt;
                }

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)(input.Trim() ?? "");
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
            catch
            {
                Console.WriteLine("Input is not valid. Please try again.");
            }
        }
    }

    public T Read<T>(string prompt, T min, T max) where T : IComparable<T>
    {
        while (true)
        {
            T value = Read<T>(prompt);
            if (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0)
            {
                return value;
            }

            Console.WriteLine($"Value must be between {min} and {max}.");
        }
    }
}