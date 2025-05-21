namespace MyLibrary.Validators;
using System.Text.RegularExpressions;

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