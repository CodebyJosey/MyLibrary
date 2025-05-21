namespace MyLibrary.Validators;
using System.Text.RegularExpressions;

public class HexColorValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string input)
    {
        _errors.Clear();
        var hexPattern = @"^#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{3})$";
        return Regex.IsMatch(input, hexPattern);
    }
    public IEnumerable<string> GetErrors() => _errors;
}