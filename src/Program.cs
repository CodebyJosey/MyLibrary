using MyLibrary.Utilities;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Successfully started running...\n");

        // EmailValidator emailValidator = new EmailValidator();
        // CollectionValidator<string> collectionValidator = new CollectionValidator<string>(emailValidator, 1, 5);

        // List<string> emails = new List<string>
        // {
        //     "test@example.com",
        //     "invalid-email",
        //     "hello@world.com"
        // };
        // var result = collectionValidator.Validate(emails);

        // if (!result.IsValid)
        // {
        //     Console.WriteLine("Validation:");
        //     foreach (var error in result.Errors)
        //     {
        //         Console.WriteLine($"- {error}");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("All values are valid.");
        // }

        Console.WriteLine(MathUtilitities.Add("nig", 1.2));

        Console.WriteLine("\nStopped running as there's nothing left to run...");
    }
}


public class Composers
{
    public static Func<A, C> Compose<A, B, C>(Func<A, B> func1, Func<B, C> func2) => p => func2(func1(p));
    public static Func<int, int> ComposeN(Func<int, int> f, int n) => n == 0 ? p => p : p => ComposeN(f, n - 1)(f(p));
    // {
    //     if (n == 0) return p => p;
    //     if (n == 1) return f;
    //     return p => ComposeN(f, n - 1)(f(p));
    // }
}