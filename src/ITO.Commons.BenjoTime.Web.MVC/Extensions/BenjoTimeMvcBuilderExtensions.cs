using ITO.Commons.BenjoTime.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace ITO.Commons.BenjoTime.Web.MVC
{
    public static class BenjoTimeMvcBuilderExtensions
    {
        public static IMvcBuilder AddBenjoTime(this IMvcBuilder builder, TimezoneProviderType type)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            AddServicesCore(builder.Services, type);
            return builder;
        }

        private static void AddServicesCore(IServiceCollection services, TimezoneProviderType providerType)
        {

            if (providerType == TimezoneProviderType.FromCookie)
                services.TryAddScoped<ITimezoneProvider, CookieTimezoneProvider>();
            if(providerType == TimezoneProviderType.FromSettings)
                services.TryAddScoped<ITimezoneProvider, FromConfigurationTimezoneProvider>();

            services.TryAddScoped<IDateTimeConverter, DateTimeConverter>();
        }

     
    }
}
