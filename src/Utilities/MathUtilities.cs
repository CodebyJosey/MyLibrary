// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Utilities;

public class MathUtilitities
{
    public const double PI = 3.141592653589793;
    public static dynamic Add(dynamic a, dynamic b) => a + b;
    public static dynamic Subtract(dynamic a, dynamic b) => a - b;
    public static dynamic Divide(dynamic a, dynamic b) => a / b;
    public static dynamic Multiply(dynamic a, dynamic b) => a * b;
    public static dynamic Pow(dynamic a, int exponent) => exponent == 0 ? 1 : exponent < 0 ? 1 / Pow(a, -exponent) : a * Pow(a, exponent - 1);
    public static int Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);
    public static int Fibonacci(int n) => n <= 1 ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
    public static dynamic Abs(dynamic n) => n >= 0 ? n : -n;
    public static int Ceil(dynamic n) => Floor(n + 1);
    public static int Floor(dynamic n) => (int)n;
    public static double GetCircleSurface(dynamic r) => PI * Pow(r, 2);
    public static double Sum(IEnumerable<int> source) => source.Sum();
}