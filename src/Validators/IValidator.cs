namespace MyLibrary.Validators;

public interface IValidator<T>
{
    bool IsValid(T input);
    IEnumerable<string> GetErrors();
}