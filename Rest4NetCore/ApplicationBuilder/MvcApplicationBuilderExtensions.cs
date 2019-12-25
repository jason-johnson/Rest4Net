using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Rest4NetCore.Attributes;

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

            var ss = CompileTypes(types);

            return app.UseEndpoints(endpoints =>
            {
                // Mapping of endpoints goes here:
                endpoints.MapControllers();
                endpoints.MapControllerRoute("coffee", "Coffee/",
                    defaults: new { controller = "Coffee", action = "GetAll" });
            });
        }

        private static IEnumerable<TypeInfo> LoadAllDefinedTypes()
        {
            var assembly = Assembly.GetEntryAssembly();
            var refAssemblies = assembly.GetReferencedAssemblies().Select(Assembly.Load);

            return refAssemblies
                .Concat(new[] { assembly })
                .SelectMany(x => x.DefinedTypes);
        }

        private static string CompileTypes(IEnumerable<TypeInfo> types)
        {
            foreach (var type in types)
            {
                if(IsType(typeof(RestController), type))
                {
                    // TODO: Deal with REST controller
                }
                else if(HasAttrib(typeof(RestContractAttribute), type))
                {
                    // TODO: Deal with REST contract
                }
            }
            return "what do we return";
        }

        private static bool IsType(Type targ, TypeInfo t)
        {
            var ti = targ.GetTypeInfo();

            return ti.IsAssignableFrom(t.AsType()) && ti != t;
        }

        private static bool HasAttrib(Type attr, TypeInfo t)
        {
            return t.AsType().GetCustomAttributes(attr, true).Length > 0;
        }
    }
}
