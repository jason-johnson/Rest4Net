using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Rest4NetCore.Middleware;

namespace Rest4NetCore.Mvc
{
    public static class MvcApplicationBuilderExtensions
    {
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

            options.Assembly = Assembly.GetCallingAssembly();

            return app.UseMiddleware<RestMiddleware>(Options.Create(options));
        }

        public static IApplicationBuilder UseRest(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new RestOptions();

            options.Assembly = Assembly.GetCallingAssembly();

            return app.UseMiddleware<RestMiddleware>(Options.Create(options));
        }
    }
}
