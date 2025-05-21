namespace MyLibrary.Validators;

public class FileNameValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string fileName)
    {
        _errors.Clear();
        char[] forbiddenChars = ['\\', '/', ':', '*', '?', '"', '<', '>', '|'];

        if (string.IsNullOrWhiteSpace(fileName))
        {
            return false;
        }

        if (forbiddenChars.Any(c => fileName.Contains(c)) || !fileName.Contains('.'))
        {
            _errors.Add("Given filename is not well formatted.");
            return false;
        }

        if (fileName.Length > 255)
        {
            _errors.Add("Length of filename is too long.");
            return false;
        }

        return true;
    }
    public IEnumerable<string> GetErrors() => _errors;
}