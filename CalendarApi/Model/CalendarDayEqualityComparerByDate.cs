using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CalendarApi.Model
{
    public class CalendarDayEqualityComparerByDate : EqualityComparer<CalendarDay>
    {
        public override bool Equals(CalendarDay x, CalendarDay y)
        {
            return x.Date == y.Date;
        }

        public override int GetHashCode([DisallowNull] CalendarDay obj)
        {
            return obj.Date.GetHashCode();
        }
    }
}
