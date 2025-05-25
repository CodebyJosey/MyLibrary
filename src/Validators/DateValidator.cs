// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Validators;

public class DateValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string input)
    {
        _errors.Clear();
        return DateTime.TryParse(input, out _);
    }
    public IEnumerable<string> GetErrors() => _errors;
}