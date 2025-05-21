namespace MyLibrary.Validators;

public class PasswordValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string input)
    {
        _errors.Clear();

        // Minimum Length: The password should have a minimum length of at least 8 characters.
        if (input.Length <= 8)
        {
            _errors.Add("The length of the password is less than 8 characters.");
        }

        // Lowercase: It must contain at least one lowercase letter (a-z).
        if (!input.Any(char.IsLower))
        {
            _errors.Add("Password does not contain a lowercase character.");
        }

        // Uppercase: It must contain at least one uppercase letter (A - Z).
        if (!input.Any(char.IsUpper))
        {
            _errors.Add("Password does not contain a uppercase character.");
        }

        // Digits: It must contain at least one digit(0 - 9).
        if (!input.Any(char.IsDigit))
        {
            _errors.Add("Password does not contain a digit.");
        }

        // Special Characters: It must contain at least one special character (e.g. !@#$%^&*).
        if (!input.Any(character => "!@#$%^&*).".ToCharArray().Contains(character)))
        {
            _errors.Add("Password does not contain a special character.");
        }

        return _errors.Count == 0;
    }
    public IEnumerable<string> GetErrors() => _errors;
}