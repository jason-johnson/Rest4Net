using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Rest4Net.Tests.Integration
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                if (services == null)
                {
                    throw new ArgumentNullException(nameof(services));
                }

                services.TryAddEnumerable(ServiceDescriptor.Transient<IStartupFilter, StartupFilter>());
                services.BuildServiceProvider();
            });
        }
    }
}
