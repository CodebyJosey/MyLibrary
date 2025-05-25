// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using System.Text.RegularExpressions;

namespace CodeByJosey.MyLibrary.Validators;

public class URLValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string url)
    {
        _errors.Clear();
        if (string.IsNullOrWhiteSpace(url))
        {
            _errors.Add("Empty string was given.");
            return false;
        }

        var urlPattern = @"^(https?://|ftp://)([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}(/[^ ]*)?$";
        return Regex.IsMatch(url, urlPattern);
    }
    public IEnumerable<string> GetErrors() => _errors;
}