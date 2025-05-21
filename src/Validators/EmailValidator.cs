namespace MyLibrary.Validators;
using System.Text.RegularExpressions;

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