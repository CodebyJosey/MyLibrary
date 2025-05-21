namespace MyLibrary.Validators;
using System.Text.RegularExpressions;

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