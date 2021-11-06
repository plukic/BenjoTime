using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITO.Commons.BenjoTime.Core
{
    public interface ITimezoneProvider
    {
        string GetCurrentTimezoneId();
        TimeZoneInfo GetUserTimezoneInfo();
    }
}
