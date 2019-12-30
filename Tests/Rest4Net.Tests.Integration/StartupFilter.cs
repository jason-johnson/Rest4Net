using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Rest4Net.Tests.Integration
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.Properties.Add("ENTRY_POINT_ASSEMBLY", Assembly.GetExecutingAssembly());
                next(builder);
            };
        }
    }
}