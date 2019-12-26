using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Rest4NetCore.Attributes;

namespace Rest4NetCore.Builder
{
    public class RestBuilder
    {
        private readonly List<Type> controllers = new List<Type>();
        private readonly List<Type> contracts = new List<Type>();

        private bool entryPointSeen;
        private List<Type> restContracts;
        private List<Type> restModels;
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

        public void MapRestControllers(Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints)
        {
            Build();
            endpoints.MapControllerRoute("coffee", "Coffee/",
                defaults: new { controller = "Coffee", action = "GetAll" });
        }

        private void Build()
        {
            entryPointSeen = false;
            restContracts = new List<Type>();
            restModels = new List<Type>();
            restControllers = new List<Type>();

            foreach (var contract in contracts)
            {
                var contractInfo = contract.GetCustomAttribute(typeof(RestContractAttribute), true) as RestContractAttribute;
                restContracts.Add(contract);
                restModels.Add(contractInfo.ModelClass);
            }

            foreach(var controller in this.controllers)
            {

            }
        }

        private static bool IsType(Type targ, Type t)
        {
            var ti = targ.GetTypeInfo();

            return ti.IsAssignableFrom(t) && targ != t;
        }

        private static bool HasAttrib(Type attr, Type t)
        {
            return t.GetCustomAttributes(attr, true).Length > 0;
        }
    }
}
