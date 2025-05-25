// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using System.Text.RegularExpressions;

namespace CodeByJosey.MyLibrary.Validators;

public class PhoneNumberValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();
    public bool IsValid(string input)
    {
        _errors.Clear();
        var phonePattern = @"^\+?[0-9]{1,3}[-.\s]?(\(?[0-9]{1,4}?\)?[-.\s]?)?[0-9]{1,4}[-.\s]?[0-9]{1,4}[-.\s]?[0-9]{1,9}$";
        return Regex.IsMatch(input, phonePattern);
    }
    public IEnumerable<string> GetErrors() => _errors;
}