using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Rest4NetCore.Attributes;

namespace Rest4NetCore.Builder
{
    public class RestBuilder
    {
        private readonly List<Type> controllers = new List<Type>();
        private readonly List<Type> contracts = new List<Type>();

        private Dictionary<Type, Type> restContractMap;
        private Dictionary<Type, Dictionary<string, Type>> restModelMap;
        private List<Type> restControllers;

        public RestBuilder(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (IsType(typeof(RestController), type))
                {
                    controllers.Add(type);
                }
                else if (HasAttrib(typeof(RestContractAttribute), type))
                {
                    contracts.Add(type);
                }
            }
        }

        public void MapRestControllers(IEndpointRouteBuilder endpoints)
        {
            Build(endpoints);
            endpoints.MapControllerRoute("coffee", "Coffee/",
                defaults: new { controller = "Coffee", action = "GetAll" });
        }

        private void Build(IEndpointRouteBuilder endpoints)
        {
            string entryPoint = null;
            restContractMap = new Dictionary<Type, Type>();
            restModelMap = new Dictionary<Type, Dictionary<string, Type>>();
            restControllers = new List<Type>();

            foreach (var contract in contracts)
            {
                AddContractMapping(contract);
            }

            foreach(var controller in controllers)
            {
                foreach (var method in controller.GetMethods())
                {
                    var name = $"{controller.Name}:{method.Name}";

                    if (HasAttrib(typeof(RestEntrypointAttribute), method))
                    {
                        if(!string.IsNullOrEmpty(entryPoint))
                        {
                            throw new Exception($"entry point defined twice: {entryPoint}, {name}:");
                        }

                        entryPoint = name;
                        endpoints.MapControllerRoute("entry", "/", new { controller = controller.Name, action = method.Name });
                    }
                    else if(HasAttrib(typeof(RestServiceMethodAttribute), method))
                    {
                        endpoints.MapControllerRoute(name, $"{controller.Name}/{method.Name}", new { controller = controller.Name, action = method.Name });
                    }
                }
            }
        }

        private void AddContractMapping(Type contract)
        {
            var contractInfo = contract.GetCustomAttribute(typeof(RestContractAttribute), true) as RestContractAttribute;

            if(!restModelMap.ContainsKey(contractInfo.ModelClass))
            {
                restModelMap.Add(contractInfo.ModelClass, new Dictionary<string, Type>());
            }

            restModelMap[contractInfo.ModelClass][contractInfo.Version] = contract;
            restContractMap[contract] = contractInfo.ModelClass;
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
