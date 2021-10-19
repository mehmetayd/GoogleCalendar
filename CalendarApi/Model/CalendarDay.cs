using System;

namespace CalendarApi.Model
{
    public class CalendarDay
    {
        public CalendarDay(DateTime date, bool isHalf)
        {
            Date = date;
            IsHalf = isHalf;
        }

        public DateTime Date { get; }
        public bool IsHalf { get; }
    }
}
