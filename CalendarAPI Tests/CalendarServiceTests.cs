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
        [InlineData("12.31.2021")] //yılbaşı 
        [InlineData("12.31.2020")] //yılbaşı 
        [InlineData("12.31.2019")] //yılbaşı
        [InlineData("10.05.2021")] //iş günü
        [InlineData("10.28.2021")] //yarım gün
        [InlineData("03.17.2020")] //iş günü
        [InlineData("03.13.2025")]
        [InlineData("04.05.2019")] //iş günü
        [InlineData("05.06.2019")] //iş günü
        public void DateIsWorkDay(DateTime date)
        {
            var calendarService = new CalendarOperations();

            var calendarDay = calendarService.GetWorkDay(date);

            Assert.NotNull(calendarDay);
        }

        [Theory]
        [InlineData("12.31.2021")] //yılbaşı 
        [InlineData("12.31.2020")] //yılbaşı 
        [InlineData("12.31.2019")] //yılbaşı 
        [InlineData("12.30.2021")] //iş günü
        [InlineData("04.30.2021")] //iş günü
        [InlineData("07.21.2020")] // iş günü
        public void DateIsFullWorkDay(DateTime date)
        {
            var calendarService = new CalendarOperations();

            var calendarDay = calendarService.GetWorkDay(date);

            Assert.NotNull(calendarDay);
            Assert.False(calendarDay.IsHalf);
        }

        [Theory]
        [InlineData("12.31.2021", "02.25.2022", 250)]
        [InlineData("12.31.2021", "02.25.2022", 25)]
        [InlineData("12.31.2021", "02.25.2022", 5)]
        [InlineData("05.12.2021", "05.20.2021", 4)] //18-19
        [InlineData("05.12.2021", "05.19.2021", 1)]
        [InlineData("10.21.2021", "10.22.2021", 2)]
        public void CountedWorkDaysProvided(DateTime startDate, DateTime endDate, int count)
        {
            var calendarService = new CalendarOperations();

            var calendarDays = calendarService
                .GetWorkDays(startDate, endDate, count)
                .ToList();

            calendarDays
                .Count
                .Should()
                .BeGreaterOrEqualTo(count);

            foreach (var calendarDay in calendarDays)
                ConsoleOutput.WriteLine(calendarDay.Date.ToString());
        }

        [Theory]
        [InlineData("10.28.2021", "10.28.2021", 3, 4)]
        [InlineData("10.28.2021", "11.05.2021", 3, 4)]
        public void CountedFullWorkDaysProvided(DateTime startDate, DateTime endDate, int requested, int returned)
        {
            var calendarService = new CalendarOperations();

            var calendarDays = calendarService
                .GetWorkDays(startDate, endDate, requested)
                .ToList();

            calendarDays
                .Count
                .Should()
                .BeGreaterOrEqualTo(returned);

            foreach (var calendarDay in calendarDays)
                ConsoleOutput.WriteLine(calendarDay.Date.ToString());
        }
    }
}
