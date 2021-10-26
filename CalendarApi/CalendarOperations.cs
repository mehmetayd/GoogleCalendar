using CalendarApi.Integration;
using CalendarApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarApi
{
    public class CalendarOperations
    {
        public IEnumerable<CalendarDay> GetHolidays(DateTime startDate, DateTime endDate)
        {
            var queryStartDate = startDate.Date;
            var queryEndDate = endDate.Date.AddDays(1);

            var googleCalendarService = new GoogleCalendarService();

            var googleHolidayEvents = from googleEvent in googleCalendarService
                                                            .GetHolidays(queryStartDate, queryEndDate)
                                                            .Items
                                      let date = DateTime.Parse(googleEvent.Start.Date).Date
                                      where !(date.Month == 12 && date.Day == 31)
                                      select googleEvent;

            var results = new List<CalendarDay>();

            foreach (var googleEvent in googleHolidayEvents)
            {
                var date = DateTime.Parse(googleEvent.Start.Date).Date;

                results.Add
                (
                    new CalendarDay
                    (
                        date,
                        googleEvent.Summary.ToLowerInvariant().Contains("Arifesi".ToLowerInvariant()) ||
                        !(date.Month == 12 && date.Day == 31)
                    )
                );
            }

            return results;
        }

        public IEnumerable<CalendarDay> GetWorkDays(DateTime startDate, DateTime endDate)
        {
            var holidays = GetHolidays(startDate, endDate).ToList();

            var rangeList = new List<DateTime>();

            startDate = startDate.Date;
            endDate = endDate.Date;

            // handle range population and weekends
            var loopDate = startDate;
            while (loopDate <= endDate)
            {
                if (loopDate.DayOfWeek == DayOfWeek.Saturday || loopDate.DayOfWeek == DayOfWeek.Sunday)
                    holidays.Add(new CalendarDay(loopDate, false));

                rangeList.Add(loopDate);
                loopDate = loopDate.AddDays(1);
            }

            holidays = holidays.Distinct(new CalendarDayEqualityComparerByDate()).ToList();

            var results = new List<CalendarDay>();

            results.AddRange
            (
                rangeList
                    .Except(holidays.Select(holiday => holiday.Date))
                    .Select(calendarDate => new CalendarDay(calendarDate, false))
            );

            results.AddRange
            (
                holidays
                    .Intersect
                    (
                        rangeList.Select(date => new CalendarDay(date, false)),
                        new CalendarDayEqualityComparerByDate()
                    )
                    .Where(holiday => holiday.IsHalf)
            );

            return results;
        }
        
        public CalendarDay GetWorkDay(DateTime date)
        {
            return GetWorkDays(date, date).SingleOrDefault();
        }

        public IEnumerable<CalendarDay> GetWorkDays(DateTime date, int count)
        {
            return GetWorkDays(date, date, count);
        }

        public IEnumerable<CalendarDay> GetWorkDays(DateTime startDate, DateTime endDate, int count)
        {
            var weekCount = (int)Math.Ceiling(count / 7.0d);

            var offset = weekCount * 7;

            var calendarDays = GetWorkDays(startDate, endDate.AddDays(offset));

            // worst-case scenario
            while (calendarDays.Count() < count)
            {
                offset += 7;

                calendarDays = GetWorkDays(startDate, endDate.AddDays(offset));
            }

            return calendarDays
                .OrderBy(calendarDay => calendarDay.Date)
                .Take(count);
        }
    }
}
