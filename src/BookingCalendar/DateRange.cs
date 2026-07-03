namespace BookingCalendar;

/// <summary>
/// Helpers for working with inclusive calendar date ranges, used by the
/// booking engine to compute how long a stay lasts and which dates it covers.
/// </summary>
public static class DateRange
{
    /// <summary>
    /// Returns the number of nights covered by an inclusive booking from
    /// <paramref name="checkIn"/> to <paramref name="checkOut"/>.
    /// A guest who checks in on the 10th and out on the 13th stays 3 nights.
    /// </summary>
    public static int CountNights(DateOnly checkIn, DateOnly checkOut)
    {
        if (checkOut < checkIn)
        {
            throw new ArgumentException("checkOut must not be before checkIn.", nameof(checkOut));
        }

        return checkOut.DayNumber - checkIn.DayNumber;
    }

    /// <summary>
    /// Enumerates each calendar day in the inclusive range
    /// [<paramref name="start"/>, <paramref name="end"/>].
    /// </summary>
    public static IEnumerable<DateOnly> EachDay(DateOnly start, DateOnly end)
    {
        if (end < start)
        {
            throw new ArgumentException("end must not be before start.", nameof(end));
        }

        for (var day = start; day <= end; day = day.AddDays(1))
        {
            yield return day;
        }
    }
}
