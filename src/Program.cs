using MyLibrary.Data.Managers;
using MyLibrary.Data.Models;
using MyLibrary.Utilities;
using MyLibrary.Validators;
public class Program
{
    static void Main()
    {
        Console.WriteLine("Successfully started running...\n");

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