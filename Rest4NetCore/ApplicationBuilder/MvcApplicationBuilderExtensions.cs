using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Rest4NetCore.Builder;

namespace Rest4NetCore.ApplicationBuilder
{
    public static class MvcApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRest(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var types = LoadAllDefinedTypes();

            var builder = new RestBuilder(types);

            return app.UseEndpoints(endpoints =>
            {
                // Mapping of endpoints goes here:
                endpoints.MapControllers();
                builder.MapRestControllers(endpoints);
            });
        }

        private static IEnumerable<Type> LoadAllDefinedTypes()
        {
            var assembly = Assembly.GetEntryAssembly();
            var refAssemblies = assembly.GetReferencedAssemblies().Select(Assembly.Load);

            return refAssemblies
                .Concat(new[] { assembly })
                .SelectMany(x => x.DefinedTypes)
                .Select(x => x.AsType());
        }
    }
}
