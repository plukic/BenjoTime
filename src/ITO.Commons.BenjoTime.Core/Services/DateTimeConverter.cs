using System;

namespace ITO.Commons.BenjoTime.Core
{
    public class DateTimeConverter : IDateTimeConverter
    {

        private readonly ITimezoneProvider _timezoneProvider;

        public DateTimeConverter(ITimezoneProvider timezoneProvider)
        {
            _timezoneProvider = timezoneProvider;
        }

        public DateTime FromUserDateTimeToUTC(DateTime userDateTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(userDateTime, _timezoneProvider.GetUserTimezoneInfo());
        }

        public DateTime FromUTCToUserDateTime(DateTime utcTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, _timezoneProvider.GetUserTimezoneInfo());
        }
        public DateTime? FromUserDateTimeToUTC(DateTime? userDateTime)
        {
            if (!userDateTime.HasValue)
                return null;
            return FromUserDateTimeToUTC(userDateTime.Value);
        }
        public DateTime? FromUTCToUserDateTime(DateTime? utcTime)
        {
            if (!utcTime.HasValue)
                return null;
            return FromUTCToUserDateTime(utcTime.Value);
        }
    }
}
