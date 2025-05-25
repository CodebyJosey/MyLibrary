// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using System.Text.RegularExpressions;

namespace CodeByJosey.MyLibrary.Validators;

public class EmailValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();
    public bool IsValid(string input)
    {
        _errors.Clear();
        if (string.IsNullOrWhiteSpace(input))
        {
            _errors.Add("E-mail mag niet leeg zijn.");
            return false;
        }

        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(input, emailPattern))
        {
            _errors.Add("E-mail is niet geldig.");
            return false;
        }

        return true;
    }
    public IEnumerable<string> GetErrors() => _errors;
}