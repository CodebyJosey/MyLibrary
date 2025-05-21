namespace MyLibrary.Extensions;

public static class DateTimeExtensions
{
    public static bool IsToday(DateTime obj)
    {
        return obj.Date == DateTime.Today;
    }

    public static string ToReadableString(DateTime obj)
    {
        return obj.ToString("dddd, dd MMMM yyyy");
    }

    public static int DaysUntil(DateTime obj)
    {
        return (obj - DateTime.Now).Days;
    }
}