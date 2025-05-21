namespace MyLibrary.Validators;

public class DateValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string input)
    {
        _errors.Clear();
        return DateTime.TryParse(input, out _);
    }
    public IEnumerable<string> GetErrors() => _errors;
}