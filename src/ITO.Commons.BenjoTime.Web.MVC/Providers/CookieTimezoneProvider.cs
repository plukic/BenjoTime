using ITO.Commons.BenjoTime.Core;
using Microsoft.AspNetCore.Http;
using System;
using TimeZoneConverter;

namespace ITO.Commons.BenjoTime.Web.MVC
{
    public class CookieTimezoneProvider : ITimezoneProvider
    {
        public TimeZoneInfo _defaultTimezone { get; set; } = TimeZoneInfo.Utc;
        private IHttpContextAccessor _httpContextAccessor;

        public CookieTimezoneProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetCookieName()
        {
            return Defaults.TimezoneCookieName;
        }
        public string GetCurrentTimezoneId()
        {
            if (!_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(GetCookieName()))
                return null;

            return _httpContextAccessor.HttpContext.Request.Cookies[GetCookieName()];
        }

        public TimeZoneInfo GetUserTimezoneInfo()
        {
            var currentTimezoneId = GetCurrentTimezoneId();

            if (currentTimezoneId == null)
                return _defaultTimezone;

            var timezoneInfoFromTimezoneId = ConvertTimezoneIdToTimezoneInfo(currentTimezoneId);
            if (timezoneInfoFromTimezoneId == null)
                return _defaultTimezone;

            return timezoneInfoFromTimezoneId;
        }

        private TimeZoneInfo ConvertTimezoneIdToTimezoneInfo(string currentTimezoneId)
        {
            try
            {

                return TZConvert.GetTimeZoneInfo(currentTimezoneId);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
