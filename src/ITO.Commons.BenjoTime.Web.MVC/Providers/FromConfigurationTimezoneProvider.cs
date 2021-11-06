using ITO.Commons.BenjoTime.Core;
using System;
using TimeZoneConverter;

namespace ITO.Commons.BenjoTime.Web.MVC
{
    public class FromConfigurationTimezoneProvider : ITimezoneProvider
    {
        private readonly BenjoTimeConfiguration _configuration;

        public FromConfigurationTimezoneProvider(BenjoTimeConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCurrentTimezoneId()
        {
            return _configuration.TimezoneId;
        }

        public TimeZoneInfo GetUserTimezoneInfo()
        {
            return TZConvert.GetTimeZoneInfo(GetCurrentTimezoneId());
        }
    }
}
