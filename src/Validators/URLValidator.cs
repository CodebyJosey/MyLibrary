namespace MyLibrary.Validators;
using System.Text.RegularExpressions;

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