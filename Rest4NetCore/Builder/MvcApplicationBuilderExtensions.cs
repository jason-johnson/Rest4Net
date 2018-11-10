using System;
using Microsoft.AspNetCore.Builder;

namespace Rest4NetCore.Builder
{
    public static class MvcApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRest(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMvc(routes => 
            {
                routes.MapRoute("blog", "blog/",
                                defaults: new { controller = "Coffee", action = "GetAll" });
            });
        }
    }
}
