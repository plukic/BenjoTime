using System;

namespace ITO.Commons.BenjoTime.Core
{
    public interface IDateTimeConverter
    {
        DateTime FromUTCToUserDateTime(DateTime utcTime);
        DateTime? FromUTCToUserDateTime(DateTime? utcTime);

        DateTime FromUserDateTimeToUTC(DateTime userDateTime);
        DateTime? FromUserDateTimeToUTC(DateTime? userDateTime);
    }
}
