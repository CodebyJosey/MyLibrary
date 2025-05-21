namespace MyLibrary.Validators;

public class CollectionValidator<T>
{
    private readonly IValidator<T> _itemValidator;
    private readonly int _minCount;
    private readonly int _maxCount;

    public CollectionValidator(IValidator<T> itemValidator, int minCount = 0, int maxCount = int.MaxValue)
    {
        _itemValidator = itemValidator;
        _minCount = minCount;
        _maxCount = maxCount;
    }

    public ValidationResult Validate(IEnumerable<T> coll)
    {
        List<string> errors = new List<string>();
        if (coll == null)
        {
            errors.Add("Collection may not be null.");
            return new ValidationResult(errors);
        }

        List<T> itemList = new List<T>(coll);
        if (itemList.Count < _minCount || itemList.Count > _maxCount)
        {
            errors.Add($"Collection must contain between {_minCount} and {_maxCount} items.");
            return new ValidationResult(errors);
        }

        foreach (var item in itemList)
        {
            var result = _itemValidator.IsValid(item);
            if (!result)
            {
                foreach (var error in _itemValidator.GetErrors())
                {
                    errors.Add(error);
                }
            }
        }

        return new ValidationResult(errors);
    }
}
