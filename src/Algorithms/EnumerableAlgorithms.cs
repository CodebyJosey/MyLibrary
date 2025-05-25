// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Algorithms;

public static class EnumerableAlgorithms
{
    public static IEnumerable<T> Reverse<T>(IEnumerable<T> enumerable) => enumerable.Reverse();
    public static IEnumerable<T> Filter<T>(IEnumerable<T> enumerable, Func<T, bool> predicate) => enumerable.Where(predicate);
    public static int LineairSearch<T>(IEnumerable<T> enumerable, T target) where T : IComparable
    {
        int index = 0;
        foreach (T val in enumerable)
        {
            if (val.CompareTo(target) == 0) return index;
            index++;
        }
        return -1;
    }

    public static int BinarySearch<T>(IEnumerable<T> enumerable, T target) where T : IComparable
    {
        var sorted = enumerable.OrderBy(x => x).ToList();
        int left = 0;
        int right = sorted.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = sorted[mid].CompareTo(target);

            if (comparison == 0) return mid;
            else if (comparison < 0) left = mid + 1;
            else right = mid + 1;
        }
        return -1;
    }

    public static (T min, T max) FindMinAndMax<T>(IEnumerable<T> enumerable) where T : IComparable<T>
    {
        if (enumerable.Count() == 0) throw new ArgumentOutOfRangeException("Enumerable is empty!");

        T min = default!;
        T max = default!;

        foreach (T value in enumerable)
        {
            if (value.CompareTo(min) < 0) min = value;
            if (value.CompareTo(max) > 0) max = value;
        }

        return (min, max);
    }
}