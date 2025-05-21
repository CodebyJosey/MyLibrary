namespace MyLibrary.Algorithms;
public class LineairSearch
{
    public int Search<T>(IEnumerable<T> enumerable, T target) where T : IComparable
    {
        int index = 0;
        foreach (T val in enumerable)
        {
            if (val.CompareTo(target) == 0) return index;
            index++;
        }
        return -1;
    }
}