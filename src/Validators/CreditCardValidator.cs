namespace MyLibrary.Validators;

public class CreditCardValidator : IValidator<string>
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid(string cardNumber)
    {
        _errors.Clear();
        if (string.IsNullOrWhiteSpace(cardNumber))
        {
            _errors.Add("Empty string was given.");
            return false;
        }

        cardNumber = cardNumber.Replace(" ", "").Trim();
        if (!cardNumber.All(char.IsDigit) || cardNumber.Length < 13 || cardNumber.Length > 19)
        {
            _errors.Add("Cardnumber is invalid.");
            return false;
        }

        return IsValidLuhn(cardNumber);
    }
    private bool IsValidLuhn(string cardNumber)
    {
        int sum = 0;
        bool alternate = false;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int n = int.Parse(cardNumber[i].ToString());

            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }

            sum += n;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }
    public IEnumerable<string> GetErrors() => _errors;
}