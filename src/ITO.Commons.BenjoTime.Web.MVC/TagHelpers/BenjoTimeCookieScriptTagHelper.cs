using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace ITO.Commons.BenjoTime.Web.MVC
{
    [HtmlTargetElement("benjotime-storetimezone-script", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class BenjoTimeCookieScriptTagHelper : TagHelper
    {
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }


            

            var apiKeyScript = $"<script type='text/javascript'> document.cookie = '{Defaults.TimezoneCookieName} ='+ Intl.DateTimeFormat().resolvedOptions().timeZone; </script>";
            output.Content.AppendHtml(apiKeyScript);
            // Don't output original tag
            output.TagName = null;
        }
    }
}