// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Extensions;

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