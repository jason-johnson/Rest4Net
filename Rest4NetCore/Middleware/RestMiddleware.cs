using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rest4NetCore.Attributes;

namespace Rest4NetCore.Middleware
{
    public class RestMiddleware
    {
        private readonly RestOptions _options;
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly Dictionary<Type, Type> contractMap = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, Dictionary<string, Type>> modelMap = new Dictionary<Type, Dictionary<string, Type>>();
        private readonly Dictionary<PathString, KeyValuePair<Type, MethodInfo>> controllerMap = new Dictionary<PathString, KeyValuePair<Type, MethodInfo>>();

        public RestMiddleware(RequestDelegate next, IWebHostEnvironment hostingEnv, IOptions<RestOptions> options, ILoggerFactory loggerFactory)
        {
            if (hostingEnv == null)
            {
                throw new ArgumentNullException(nameof(hostingEnv));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options.Value;
            _logger = loggerFactory.CreateLogger<RestMiddleware>();

            var types = LoadAllDefinedTypes(_options.Assembly);

            foreach (var type in types)
            {
                if (IsType(typeof(RestController), type))
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (HasAttrib(typeof(RestEntrypointAttribute), method))
                        {
                            if(controllerMap.ContainsKey("/"))
                            {
                                var prev = controllerMap["/"];
                                throw new Exception($"Entry point defined by {prev.Key.Name}.{prev.Value.Name} and {type.Name}.{method.Name}");
                            }

                            _logger.LogDebug("Adding entry point");
                            controllerMap.Add("/", new KeyValuePair<Type, MethodInfo>(type, method));
                        }
                        else if (HasAttrib(typeof(RestServiceMethodAttribute), method))
                        {
                            var url = GenerateName(type.Name, method.Name);

                            _logger.LogDebug("Adding method");
                            controllerMap.Add(url, new KeyValuePair<Type, MethodInfo>(type, method));
                        }
                    }
                }
                else if (HasAttrib(typeof(RestContractAttribute), type))
                {
                    var ci = type.GetCustomAttribute(typeof(RestContractAttribute), true) as RestContractAttribute;

                    if (!modelMap.ContainsKey(ci.ModelClass))
                    {
                        modelMap.Add(ci.ModelClass, new Dictionary<string, Type>());
                    }

                    modelMap[ci.ModelClass][ci.Version] = type;
                    contractMap[type] = ci.ModelClass;
                }
            }
        }

        public Task Invoke(HttpContext context)
        {
            return _next(context);
        }

        #region helper methods

        private string GenerateName(string controller, string method)
        {
            var top = controller.Replace("Controller", "");
            return $"/{top}/{method}";
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

        #endregion
    }
}
