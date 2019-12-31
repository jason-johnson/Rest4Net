using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Rest4NetCore.Middleware;

namespace Rest4NetCore.Mvc
{
    public static class MvcApplicationBuilderExtensions
    {
        private const string ENTRY_POINT_ASSEMBLY = "ENTRY_POINT_ASSEMBLY";

        public static IApplicationBuilder UseRest(this IApplicationBuilder app, RestOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            SetAssembly(options, app);

            return app.UseMiddleware<RestMiddleware>(Options.Create(options));
        }

        public static IApplicationBuilder UseRest(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new RestOptions();

            SetAssembly(options, app);

            return app.UseMiddleware<RestMiddleware>(Options.Create(options));
        }

        private static void SetAssembly(RestOptions restOptions, IApplicationBuilder app)
        {
            restOptions.Assembly = app.Properties.ContainsKey(ENTRY_POINT_ASSEMBLY) ? app.Properties[ENTRY_POINT_ASSEMBLY] as Assembly : Assembly.GetEntryAssembly();
        }
    }
}
