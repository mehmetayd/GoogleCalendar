using CalendarApi.Integration;
using CalendarApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarApi
{
    public class CalendarOperations
    {
        public IList<CalendarDay> GetHolidays(DateTime startDate, DateTime endDate)    // IReadOnlyList
        {
            var queryStartDate = startDate.Date;
            var queryEndDate = endDate.Date.AddDays(1);

            var googleCalendarService = new GoogleCalendarService();

            //var googleHolidayEvents = googleCalendarService
            //    .GetHolidays(queryStartDate, queryEndDate)
            //    .Items
            //    .Where(item => !item.Summary.ToLowerInvariant().Contains("yılbaşı gecesi".ToLowerInvariant()));

            var googleHolidayEvents = googleCalendarService
               .GetHolidays(queryStartDate, queryEndDate)
               .Items;

            var results = new List<CalendarDay>();

            foreach (var googleEvent in googleHolidayEvents)
            {
                results.Add
                (
                    new CalendarDay
                    (
                        DateTime.Parse(googleEvent.Start.Date).Date,
                        googleEvent.Summary.ToLowerInvariant().Contains("Arifesi".ToLowerInvariant()) ||
                        googleEvent.Summary.ToLowerInvariant().Contains("gecesi".ToLowerInvariant())
                    )
                );
            }

            return results;
        }

        public IEnumerable<CalendarDay> GetWorkDays(DateTime startDate, DateTime endDate)
        {
            var holidays = GetHolidays(startDate, endDate);

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




        //public Events HalfDay(DateTime queryStartDate, DateTime queryEndDate)
        //{
        //    EventsResource.ListRequest listRequest = service.Events.List(tatilGunleriCalendarId);
        //    listRequest.TimeMin = queryStartDate;
        //    listRequest.TimeMax = queryEndDate;
        //    if (listRequest.Fields.Contains("bayram") || listRequest.Fields.Contains("yılbaşı") || listRequest.Fields.Contains("cumhuriyet"))
        //    {
        //        Events events = listRequest.Execute();
        //        return events;
        //    }

        //}
    }
}
