// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Algorithms;

namespace CodeByJosey.MyLibrary.Validators;

public class CreditCardValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string cardNumber)
    {
        _errors.Clear();
        if (string.IsNullOrWhiteSpace(cardNumber))
        {
            _errors.Add("Empty string was given.");
            return false;
        }

        cardNumber = cardNumber.Replace(" ", "").Trim();
        if (!cardNumber.All(char.IsDigit) || cardNumber.Length < 13 || cardNumber.Length > 19)
        {
            _errors.Add("Cardnumber is invalid.");
            return false;
        }
        return ExtraAlgorithms.IsValidLuhn(cardNumber);
    }
    public IEnumerable<string> GetErrors() => _errors;
}