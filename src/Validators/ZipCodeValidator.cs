// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using System.Text.RegularExpressions;

namespace CodeByJosey.MyLibrary.Validators;

public class ZipCodeValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string zipCode)
    {
        _errors.Clear();
        zipCode = zipCode.Replace(" ", "").Trim();
        if (string.IsNullOrWhiteSpace(zipCode))
        {
            _errors.Add("Empty string was given.");
            return false;
        }

        var zipPattern = @"^\d{4}\s?[A-Za-z]{2}$";
        return Regex.IsMatch(zipCode, zipPattern);
    }
    public IEnumerable<string> GetErrors() => _errors;
}