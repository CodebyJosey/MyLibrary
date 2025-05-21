namespace MyLibrary.Validators;

public class ValidationResult
{
    public List<string> Errors { get; }
    public ValidationResult(List<string> errors)
    {
        Errors = errors;
    }

    public bool IsValid => Errors.Count == 0;
}