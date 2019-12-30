using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Rest4NetCore.Attributes;
using Rest4NetCore.Controller;

namespace Rest4NetCore.Mvc
{
    public static class MvcApplicationBuilderExtensions
    {
        private const string ENTRY_POINT_ASSEMBLY = "ENTRY_POINT_ASSEMBLY";

        public static IApplicationBuilder UseRest(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var assembly = app.Properties.ContainsKey(ENTRY_POINT_ASSEMBLY) ? app.Properties[ENTRY_POINT_ASSEMBLY] as Assembly : Assembly.GetEntryAssembly();

            var types = LoadAllDefinedTypes(assembly);

            var controller = new RestGenericController();

            return app.UseEndpoints(endpoints =>
            {
                foreach (var type in types)
                {
                    if (IsType(typeof(RestController), type))
                    {
                        foreach (var method in type.GetMethods())
                        {
                            if (HasAttrib(typeof(RestEntrypointAttribute), method))
                            {
                                controller.AddEntryPoint(type, method);
                                endpoints.Map("/", context => controller.HandleRequest(context));
                            }
                            else if (HasAttrib(typeof(RestServiceMethodAttribute), method))
                            {
                                var url = controller.AddServiceMethod(type, method);
                                endpoints.Map(url, context => controller.HandleRequest(context));
                            }
                        }
                    }
                    else if (HasAttrib(typeof(RestContractAttribute), type))
                    {
                        var ci = type.GetCustomAttribute(typeof(RestContractAttribute), true) as RestContractAttribute;

                        controller.AddContractMapping(ci, type);
                    }
                }
            });
        }

        private static IEnumerable<Type> LoadAllDefinedTypes(Assembly assembly)
        {
            var refAssemblies = assembly.GetReferencedAssemblies().Select(Assembly.Load);

            return refAssemblies
                .Concat(new[] { assembly })
                .SelectMany(x => x.DefinedTypes)
                .Select(x => x.AsType());
        }

        private static bool IsType(Type targ, Type t)
        {
            var ti = targ.GetTypeInfo();

            return ti.IsAssignableFrom(t) && targ != t;
        }

        private static bool HasAttrib(Type attr, ICustomAttributeProvider t)
        {
            return t.GetCustomAttributes(attr, true).Length > 0;
        }
    }
}
