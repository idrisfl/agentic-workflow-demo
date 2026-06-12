using BookingCalendar;

namespace BookingCalendar.Tests;

public class DateRangeTests
{
    [Fact]
    public void CountNights_ThreeNightStay_ReturnsThree()
    {
        // Check in on the 10th, check out on the 13th => 3 nights (10th, 11th, 12th).
        var checkIn = new DateOnly(2026, 1, 10);
        var checkOut = new DateOnly(2026, 1, 13);

        var nights = DateRange.CountNights(checkIn, checkOut);

        Assert.Equal(3, nights);
    }

    [Fact]
    public void CountNights_OneNightStay_ReturnsOne()
    {
        var checkIn = new DateOnly(2026, 3, 1);
        var checkOut = new DateOnly(2026, 3, 2);

        var nights = DateRange.CountNights(checkIn, checkOut);

        Assert.Equal(1, nights);
    }

    [Fact]
    public void CountNights_SameDay_ReturnsZero()
    {
        var day = new DateOnly(2026, 5, 20);

        var nights = DateRange.CountNights(day, day);

        Assert.Equal(0, nights);
    }

    [Fact]
    public void CountNights_CheckOutBeforeCheckIn_Throws()
    {
        var checkIn = new DateOnly(2026, 7, 10);
        var checkOut = new DateOnly(2026, 7, 9);

        Assert.Throws<ArgumentException>(() => DateRange.CountNights(checkIn, checkOut));
    }

    [Fact]
    public void EachDay_InclusiveRange_YieldsEveryDay()
    {
        var start = new DateOnly(2026, 2, 27);
        var end = new DateOnly(2026, 3, 1);

        var days = DateRange.EachDay(start, end).ToList();

        Assert.Equal(
            new[]
            {
                new DateOnly(2026, 2, 27),
                new DateOnly(2026, 2, 28),
                new DateOnly(2026, 3, 1),
            },
            days);
    }
}
