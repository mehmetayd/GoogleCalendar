using CalendarApi;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CalendarAPI_Tests
{
    public class CalendarServiceTests
    {
        private ITestOutputHelper ConsoleOutput { get; }

        public CalendarServiceTests(ITestOutputHelper consoleOutput)
        {
            ConsoleOutput = consoleOutput;
        }

        [Theory]
        [InlineData("10.05.2021")]
        [InlineData("10.28.2021")]
        [InlineData("03.17.2020")]
        [InlineData("03.13.2025")]
        [InlineData("04.06.2019")]
        [InlineData("05.06.2019")]
        public void DateIsWorkDay(DateTime date)
        {
            var calendarService = new CalendarOperations();

            var calendarDay = calendarService.GetWorkDay(date);

            Assert.NotNull(calendarDay);
        }

        [Theory]
        [InlineData("12.31.2021")]
        public void DateIsFullWorkDay(DateTime date)
        {
            var calendarService = new CalendarOperations();

            var calendarDay = calendarService.GetWorkDay(date);

            Assert.NotNull(calendarDay);
            Assert.False(calendarDay.IsHalf);
        }

        [Theory]
        [InlineData("12.31.2021", "02.25.2022", 25)]
        [InlineData("12.31.2021", "02.25.2022", 5)]
        [InlineData("05.12.2021", "05.19.2021", 3)]
        public void CountedWorkDaysProvided(DateTime startDate, DateTime endDate, int count)
        {
            var calendarService = new CalendarOperations();

            var calendarDays = calendarService
                .GetWorkDays(startDate, endDate, count)
                .ToList();

            calendarDays
                .Count
                .Should()
                .BeGreaterOrEqualTo(count)
                .And
                .BeLessOrEqualTo(count + 1);
            
            foreach (var calendarDay in calendarDays)
                ConsoleOutput.WriteLine(calendarDay.Date.ToString());

            Assert.Equal(calendarDays.Last().Date, endDate);
        }

        [Theory]
        [InlineData("12.31.2021", "02.25.2022", 250)]
        public void CountedWorkDaysShouldBeProvided(DateTime startDate, DateTime endDate, int count)
        {
            var calendarService = new CalendarOperations();

            var calendarDays = calendarService
                .GetWorkDays(startDate, endDate, count)
                .ToList();

            calendarDays
                .Count
                .Should()
                .BeGreaterOrEqualTo(count)
                .And
                .BeLessOrEqualTo(count + 1);
        }
    }
}
