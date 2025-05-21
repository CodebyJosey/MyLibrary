namespace MyLibrary.Algorithms;

public class BinarySearch
{
    public int Search<T>(IEnumerable<T> enumerable, T target) where T : IComparable
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
}